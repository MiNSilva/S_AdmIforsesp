using DIAPOIO.BLL;
using DIAPOIO.BLL.Autenticacao;
using DIAPOIO.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EnviaEmailNotificacao : System.Web.UI.Page
{
    string Param;
    CryptUtil crypt = new CryptUtil();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //string horaIni = "09:00:00";
            //string horaFim = "09:30:00";

            //DateTime data = DateTime.Now;
            //string horaAgora = data.ToLongTimeString();

            //if (horaAgora.CompareTo(horaIni) > -1 && horaAgora.CompareTo(horaFim) < 1)
            ////if (int.Parse(horaAgora) >= int.Parse(horaIni) && int.Parse(horaAgora) <= int.Parse(horaFim))
            //{
            CarregarListaNotificacao();
            //}
        }

    }

    protected void CarregarListaNotificacao()
    {
        WebEmailBLL obj = new WebEmailBLL();
        DataSet ds = obj.EnviaNotificacoesEmail();

        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                //Instancia o objeto que monta a mensagem já passando como parâmetro o e-mail do remetente e destinatário
                MailMessage oEmail = new MailMessage();
                oEmail.From = new MailAddress(ds.Tables[0].Rows[i]["Email"].ToString() + "<site@advocaciamarcatto.com.br>", "Advocacia Marcatto");
                oEmail.To.Add(ds.Tables[0].Rows[i]["Email"].ToString());
                oEmail.CC.Add("nogueira.michelle@gmail.com");
                oEmail.Priority = MailPriority.Normal;
                oEmail.IsBodyHtml = false;

                //Define o asunto da mensagem
                oEmail.Subject = "PENDÊNCIAS E-MAILS/CLIENTES - SITE MARCATTO - TESTE";

                //Define o conteúdo da mensagemS
                StringBuilder message = new StringBuilder();

                message.Append("Prezado(a)," + ds.Tables[0].Rows[i]["Nome"].ToString()).Append(Environment.NewLine);
                message.Append(Environment.NewLine);
                message.Append("Existem " + ds.Tables[0].Rows[i]["quantidade"].ToString() + " e-mails pendentes de resposta na sua caixa de entrada. Por favor, verifique o prazo de cada situação e retorne ao cliente.").Append(Environment.NewLine);
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

                    string url = HttpContext.Current.Request.Url.AbsoluteUri;
                    FuncoesBLL objf = new FuncoesBLL();
                    objf.Atividades(url, "Enviou email para: " + ds.Tables[0].Rows[i]["Email"].ToString(), ControleAcesso.LerTicket().CadastroId);

                }
                catch (Exception ex)
                {
                    Param = crypt.ActionEncrypt("3#" + ex.Message);
                    Response.RedirectToRoute("PnlAlerta", new { Param = Param });

                }
                oEmail.Dispose();

            }
        }
    }

}