using DIAPOIO.BLL;
using DIAPOIO.MODEL;
using DIAPOIO.DAL;
using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using DIAPOIO.BLL.Autenticacao;
using System.Net.Mail;
using System.Text;
using System.Diagnostics;
//using iTextSharp.text.html.simpleparser;
//using iTextSharp.text.pdf;
//using iTextSharp.text;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Painel_Email_NovoEmail : System.Web.UI.Page
{
    string Param;
    CryptUtil crypt = new CryptUtil();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Page.RouteData.Values["Param"] != null)
            {
                lblId.Text = Page.RouteData.Values["Param"].ToString();

                if (lblId.Text == "0")
                {
                    lblMensagemNR.Text = "Nova Mensagem";

                    //Saber de onde esta vindo - Novo(Caixa de Entrada)
                    lblcontrol.Text = "0";

                    CarregarddlResp();
                    System.Web.UI.WebControls.ListItem selectResp = ddlResp.Items.FindByText(ControleAcesso.LerTicket().Nome);
                    if (selectResp != null)
                    {
                        ddlResp.ClearSelection();
                        selectResp.Selected = true;
                    };
                    CarregarSituacao();
                }
                else
                {
                    lblMensagemNR.Text = "Responder Mensagem";
                    //Saber de onde esta vindo - E-mail(Responder)
                    lblcontrol.Text = "1";

                    WebEmailModel email = new WebEmailModel();
                    WebEmailBLL obj = new WebEmailBLL();

                    DataSet ds = obj.CarregaEmailId(Convert.ToInt32(lblId.Text), ControleAcesso.LerTicket().CadastroId);

                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {

                        txtEmail.Text = ds.Tables[0].Rows[0]["email"].ToString();
                        txtCPF.Text = ds.Tables[0].Rows[0]["CPF"].ToString();
                        txtNome.Text = ds.Tables[0].Rows[0]["Nome"].ToString();
                        txtAssunto.Text = ds.Tables[0].Rows[0]["assunto"].ToString();

                        CarregarSituacao();
                        string formulario = ds.Tables[0].Rows[0]["formulario"].ToString();
                        System.Web.UI.WebControls.ListItem selectSitu = ddlSituacao.Items.FindByText(formulario);
                        if (selectSitu != null)
                        {
                            ddlSituacao.ClearSelection();
                            selectSitu.Selected = true;
                        };

                        CarregarddlResp();
                        System.Web.UI.WebControls.ListItem selectResp = ddlResp.Items.FindByText(ControleAcesso.LerTicket().Nome);
                        if (selectResp != null)
                        {
                            ddlResp.ClearSelection();
                            selectResp.Selected = true;
                        };
                    }
                }
            }
        }

    }

    protected void CarregarSituacao()
    {

        ddlSituacao.ClearSelection();
        ddlSituacao.DataValueField = "SituacaoContatoId";
        ddlSituacao.DataTextField = "SituacaoContato";
        ddlSituacao.DataSource = new WebSituacaoContatoBLL().GetSituacaoContatoNovo();
        ddlSituacao.DataBind();
    }

    protected void CarregarddlResp()
    {
        ddlResp.DataValueField = "UsuariowebId";
        ddlResp.DataTextField = "nome";
        ddlResp.DataSource = new WebEmailBLL().CarregaResponsavel();
        ddlResp.DataBind();
    }

    protected void txtEmail_TextChanged(object sender, EventArgs e)
    {
        WebCadastrosModel cad = new WebCadastrosModel();
        WebCadastrosBLL obj = new WebCadastrosBLL();

        cad.Email = txtEmail.Text;
        cad.CPF = String.Empty;
        string cpf1 = String.Empty;

        if (obj.ValidaCadastro(cad, cpf1) != null)
        {
            txtNome.Text = cad.Nome;
            txtEmail.Text = cad.Email;
            txtCPF.Text = cad.CPF;
            txtAssunto.Text = string.Empty;
            txtMessage.Text = string.Empty;
        }
        else
        {
            txtNome.Text = string.Empty;
            txtEmail.Text = cad.Email;
            txtCPF.Text = string.Empty;
            txtAssunto.Text = string.Empty;
            txtMessage.Text = string.Empty;

        }
    }

    protected void txtCPF_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string cpf = FuncoesBLL.RemoveCarecteres(txtCPF.Text, new[] { "-", "." });

            // Não deixar entrar campo com menos de 11 caracteres
            if (cpf.Length >= 11)
            {
                //Verificar se e campo CPF
                if (cpf.Length == 11)
                {
                    if (FuncoesBLL.CHKCPF(cpf, 1) == 1)
                    {
                        txtCPF.Focus();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                        Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
                        lblMsgTit.Visible = true;
                        lblMsgTit.Text = "CPF INVÁLIDO";

                        Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
                        lblMsgCont.Visible = true;
                        lblMsgCont.Text = " ";
                    }
                }
            }

        }
        catch (Exception ex)
        {
            Param = crypt.ActionEncrypt("3#" + ex.Message);
            Response.RedirectToRoute("PnlAlerta", new { Param = Param });
        }
    }

    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        if (lblcontrol.Text == "0")
        {
            Response.RedirectToRoute("EmlCaixaEntrada", new object { });
        }
        else
        {
            Response.RedirectToRoute("EmlCaixaEntradaEdita", new {Param = lblId.Text });
        }
    }

    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            //Instancia o objeto que monta a mensagem já passando como parâmetro o e-mail do remetente e destinatário
            MailMessage oEmail = new MailMessage();
            oEmail.From = new MailAddress(txtEmail.Text + "<site@advocaciamarcatto.com.br>", "Advocacia Marcatto");
            oEmail.To.Add(txtEmail.Text);
            //oEmail.CC.Add(txtcopia.Text);
            oEmail.Priority = MailPriority.Normal;
            oEmail.IsBodyHtml = false;

            //Define o asunto da mensagem
            oEmail.Subject = "Advocacia Marcatto - Email para " + txtNome.Text;

            //Define o conteúdo da mensagemS
            StringBuilder message = new StringBuilder();

            message.Append("Prezado(a), Sr.(a) " + txtNome.Text).Append(Environment.NewLine);
            message.Append(Environment.NewLine);
            message.Append("Existe uma nova mensagem para você em nosso site, para acompanhar acesse o link abaixo:").Append(Environment.NewLine);
            message.Append(Environment.NewLine);
            message.Append("http://advocaciamarcatto.com.br/AreaCliente").Append(Environment.NewLine);
            message.Append(Environment.NewLine);
            message.Append(Environment.NewLine);
            message.Append("Para ler a mensagem, acesse a nossa página (http://advocaciamarcatto.com.br) e vá até a Área do Cliente.").Append(Environment.NewLine);
            message.Append(Environment.NewLine);
            message.Append("Auxílio no acesso:").Append(Environment.NewLine);
            message.Append(Environment.NewLine);
            message.Append("Se não for cadastrado: Acesse o site e clique em Área do Cliente, então clique em Não Sou Cadastrado, preencha todos os campos solicitados e clique em Incluir. ").Append(Environment.NewLine);
            message.Append(Environment.NewLine);
            message.Append("Se já for cadastrado: Na Área do Cliente clique em Sou Cadastrado e faça login com seu CPF e senha.").Append(Environment.NewLine);
            message.Append(Environment.NewLine);
            message.Append("Não conseguiu encontrar a mensagem: Fazer o login e clicar em E-mails, se já possuir mensagens, elas aparecerão em vermelho. Se não possuir mensagens, a solicitação poderá ser feita clicando em Novo E-mail.").Append(Environment.NewLine);
            message.Append(Environment.NewLine);
            message.Append("Não conseguiu visualizar a mensagem: Fazer o login e clicar em E-mails, na mensagem em vermelho clicar em Visualizar, será a última opção do lado direito.").Append(Environment.NewLine);
            message.Append(Environment.NewLine);
            message.Append("Se precisar de ajuda com o cadastro ou com o acesso, entre em contato conosco através do fone (11) 3241-2600.").Append(Environment.NewLine);
            message.Append(Environment.NewLine);
            message.Append("Este é um e-mail automático, por favor, não responda.").Append(Environment.NewLine);
            message.Append(Environment.NewLine);
            message.Append("Atenciosamente, Advocacia Marcatto.").Append(Environment.NewLine);
            message.Append("http://advocaciamarcatto.com.br").Append(Environment.NewLine);


            oEmail.Body = message.ToString();

            SmtpClient oEnviar = new SmtpClient();
            oEnviar.Host = "smtp.office365.com"; //DIGITE AQUI O NOME DO SERVIDOR DE SMTP QUE VOCÊ IRA UTILIZAR
            oEnviar.Port = Convert.ToInt16("587");
            oEnviar.UseDefaultCredentials = false;
            oEnviar.DeliveryMethod = SmtpDeliveryMethod.Network;
            oEnviar.EnableSsl = true;
            oEnviar.TargetName = "STARTTLS/smtp.office365.com";
            oEnviar.Credentials = new System.Net.NetworkCredential("site@advocaciamarcatto.com.br", "Aj89((Maa')");

            try
            {
                oEnviar.Send(oEmail);

                WebEmailModel email = new WebEmailModel();
                email.Nome = txtNome.Text;
                email.Email = txtEmail.Text;
                email.Ddd = 0;
                email.Telefone = string.Empty;
                email.Cliente = string.Empty;
                email.Servidor = string.Empty;
                email.Status = string.Empty;
                email.Assunto = txtAssunto.Text;
                email.Mensagem = txtMessage.Text;
                email.Formulario = Convert.ToInt32(ddlSituacao.SelectedValue);
                email.SituacaoId = 4;
                email.Visualizado = 0;
                email.CPF = FuncoesBLL.RemoveCarecteres(txtCPF.Text, new[] { "-", "." });

                WebEmailBLL obj = new WebEmailBLL();
                int num = obj.ValidaContato(email);

                if (num >= 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                    Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
                    lblMsgTit.Visible = true;
                    lblMsgTit.Text = "Mensagem ja enviada";

                    Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
                    lblMsgCont.Visible = true;
                    lblMsgCont.Text = " ";
                }
                else
                {
                    WebEmailRespostaBLL objr = new WebEmailRespostaBLL();
                    WebEmailRespostaModel respo = new WebEmailRespostaModel();

                    //Se for mensagem nova
                    if (lblcontrol.Text == "0")
                    {
                        int atualiza = obj.AtualizaEmail(email, 1);
                        respo.Emailid = atualiza;
                    }
                    //senao pega o EmailId para responder a mensagem
                    else
                    {
                        respo.Emailid = Convert.ToInt32(lblId.Text);
                    }

                    respo.Resposta = txtMessage.Text;
                    respo.Usuariowebid = Convert.ToInt32(ControleAcesso.LerTicket().CadastroId.ToString());

                    obj.AtualizaResponsavelEmail(respo.Emailid, respo.Usuariowebid);

                    int valida = objr.AtualizaEmailResposta(respo, 2);
                    if (valida >= 1)
                    {
                        //lblMsgTit.Text = "Mensagem ja enviada";
                    }
                    else
                    {
                        int EmailRespostaId = objr.AtualizaEmailResposta(respo, 1);

                        WebDownloadEmailModel downemail = new WebDownloadEmailModel();
                        WebDownloadEmailBLL objde = new WebDownloadEmailBLL();

                        if (FileUploadNovoEmail.HasFile)     // CHECK IF ANY FILE HAS BEEN SELECTED.
                        {
                            string pasta = FuncoesBLL.RemoveCarecteres(email.CPF, new[] { "-", "." });
                            string caminho = Server.MapPath("~/AnexoEmail/" + pasta.ToString());
                            string arquivo = "";

                            if (!Directory.Exists(caminho))
                                Directory.CreateDirectory(caminho);

                            if (!File.Exists(caminho))
                            {
                                int iUploadedCnt = 0;
                                int iFailedCnt = 0;

                                HttpFileCollection hfc = Request.Files;
                                //lblFileList.Text = "Select <b>" + hfc.Count + "</b> file(s)";

                                if (hfc.Count <= 10)    // 10 FILES RESTRICTION.
                                {
                                    for (int i = 0; i <= hfc.Count - 1; i++)
                                    {
                                        HttpPostedFile hpf = hfc[i];
                                        if (hpf.ContentLength > 0)
                                        {
                                            arquivo = String.Format("[{0}]", DateTime.Now.ToString("ddMMyyyyHHmmssfff")) + hpf.FileName;

                                            if (!File.Exists(caminho + "\\" + arquivo))
                                            {
                                                //DirectoryInfo objDir = 
                                                //    new DirectoryInfo(Server.MapPath("CopyFiles\\"));

                                                string sFileName = Path.GetFileName(arquivo);
                                                string sFileExt = Path.GetExtension(arquivo);

                                                DirectoryInfo diretorio = new DirectoryInfo(caminho);

                                                // CHECK FOR DUPLICATE FILES.
                                                FileInfo[] objFI = diretorio.GetFiles(sFileName.Replace(sFileExt, "") + ".*");

                                                if (objFI.Length > 0)
                                                {
                                                    // CHECK IF FILE WITH THE SAME NAME EXISTS IGNORING THE EXTENTIONS
                                                    foreach (FileInfo file in objFI)
                                                    {
                                                        string sFileName1 = objFI[0].Name;
                                                        string sFileExt1 = Path.GetExtension(objFI[0].Name);

                                                        if (sFileName1.Replace(sFileExt1, "") == sFileName.Replace(sFileExt, ""))
                                                        {
                                                            iFailedCnt += 1;        // NOT ALLOWING DUPLICATE.
                                                            break;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    downemail.DownloadEmailid = 0;
                                                    downemail.NomeArquivo = arquivo;
                                                    downemail.Ativo = 1;
                                                    downemail.Arquivo = pasta;
                                                    downemail.EmailId = num;
                                                    downemail.DataEmailId = DateTime.Now;
                                                    downemail.EmailRespostaId = EmailRespostaId;

                                                    objde.AtualizaDownloadEmail(downemail, 1);
                                                    iUploadedCnt += 1;

                                                    // SAVE THE FILE IN A FOLDER.
                                                    hpf.SaveAs(Server.MapPath("~/AnexoEmail/" + pasta + "/") + downemail.NomeArquivo);

                                                }
                                            }
                                        }
                                    }
                                    lblUploadStatus.Text = "<b>" + iUploadedCnt + "</b> arquivo(s) Carregado.";
                                    lblFailedStatus.Text = "<b>" + iFailedCnt +
                                        "</b> duplicado arquivo (s) não pôde ser carregado.";
                                }
                            }
                            else lblUploadStatus.Text = "Max. 10 arquivos permitido.";
                        }
                        else lblUploadStatus.Text = "Nenhum arquivo selecionado.";

                    }
                    txtNome.Text = string.Empty;
                    txtEmail.Text = string.Empty;
                    txtAssunto.Text = string.Empty;
                    txtMessage.Text = string.Empty;
                    txtCPF.Text = string.Empty;
                    btnEnviar.Enabled = false;

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                    Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
                    lblMsgTit.Visible = true;
                    lblMsgTit.Text = "Mensagem enviada com sucesso";

                    Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
                    lblMsgCont.Visible = true;
                    lblMsgCont.Text = " ";

                    //Response.RedirectToRoute("AdmCaixaEntrada", new { });
                }
            }
            catch (Exception ex)
            {
                Param = crypt.ActionEncrypt("3#" + ex.Message);
                Response.RedirectToRoute("PnlAlerta", new { Param = Param });

            }
            oEmail.Dispose();
            //Response.RedirectToRoute("EmlCaixaEntrada", new { });
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
            lblMsgTit.Visible = true;
            lblMsgTit.Text = "Complete todos os campo!";

            Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
            lblMsgCont.Visible = true;
            lblMsgCont.Text = " ";

        }
    }
}