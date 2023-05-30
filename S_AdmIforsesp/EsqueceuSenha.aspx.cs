using DIAPOIO.BLL;
using DIAPOIO.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EsqueceuSenha : System.Web.UI.Page
{
    string Param;
    CryptUtil crypt = new CryptUtil();

    protected void Page_Load(object sender, EventArgs e)
    {
        Panel1.Visible = false;
    }

    protected void btnEsqSenha_Click(object sender, EventArgs e)
    {
        try
        {
            UsuarioWebModel usuario = new UsuarioWebModel();
            usuario.Login = txtEmail.Text;

            UsuarioWebBLL obj = new UsuarioWebBLL();
            obj.VerificarEmail(usuario);

            if (usuario.UsuarioWebId > 0)
            {

                //Instancia o objeto que monta a mensagem já passando como parâmetro o e-mail do remetente e destinatário
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(txtEmail.Text + "<sistema@diapoio.com.br>", "sistema ADM Sispesp");
                mail.To.Add("sispesp@sispesp.com");
                mail.ReplyTo = new MailAddress(txtEmail.Text);

                //Define o asunto da mensagem
                mail.Subject = "Recuperação de Senha";

                //Define o conteúdo da mensagem
                StringBuilder message = new StringBuilder();

                message.Append("<b>Recuperação de Senha</b>" + "<br>");
                message.Append("========================================" + "<br>");
                message.Append("<b>Email:</b>" + usuario.Login + "<br>");
                message.Append("<b>Senha Cadastrada:</b>" + usuario.Senha + "<br>");
                message.Append("========================================");

                mail.Body = message.ToString();
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.Normal;

                //Determina a codificação da mensagem no padrão brasileiro
                mail.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");

                //Determina a codificação do assunto da mensagem no padrão brasileito
                mail.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");

                //Instancia o objeto de envio da mensagem
                SmtpClient smtp = new SmtpClient();

                //Determina o servidor de envio da mensagem
                smtp.Host = "smtp.zoho.com";

                //Determina a porta do servidor SMTP
                smtp.Port = Convert.ToInt16("587");

                smtp.UseDefaultCredentials = false;

                //Instancia o objeto que permite fazer autenticação no envio de e-mails via SMTP
                smtp.Credentials = new System.Net.NetworkCredential("sistema@diapoio.com.br", "Did!sed3@123");

                smtp.EnableSsl = true;
                try
                {
                    //Envia a mensagem
                    smtp.Send(mail);

                    Panel1.Visible = true;
                    lblMsg.Text = "E-mail enviado com sucesso";
                    //Param = crypt.ActionEncrypt("#" + "E-mail enviado com sucesso ");
                    //Response.RedirectToRoute("Errorpage", new { Param = Param });
                }
                catch (Exception ex)
                {
                    Param = crypt.ActionEncrypt("#" + ex.Message);
                    Response.RedirectToRoute("Errorpage", new { Param = Param });
                }
                mail.Dispose();
            }
            else
            {
                Panel1.Visible = true;
                lblMsg.Text = "E-mail não Encontrato / Cadastrado";
                //Param = crypt.ActionEncrypt("#" + "E-mail não Encontrato / Cadastrado.");
                //Response.RedirectToRoute("Errorpage", new { Param = Param });

            }
        }
        catch (Exception ex)
        {
            Param = crypt.ActionEncrypt("#" + ex.Message);
            Response.RedirectToRoute("Errorpage", new { Param = Param });
        }
    }


}