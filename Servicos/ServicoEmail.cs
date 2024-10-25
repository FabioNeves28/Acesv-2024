using System.Net.Mail;
using System.Net.Mime;
using System.Text;

namespace Mvc_ConfRec.Servicos
{
    public class ServicoEmail
    {
        private readonly IConfiguration _configuration;

        public ServicoEmail(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool enviaEmail(String emailPara, String assunto, String corpoMensagem, String emailCC = null, List<string> caminhoAnexos = null, byte[] anexoBinario = null, string nomeAnexoBinario = "")
        {
            bool retorno = false;

            try
            {

                string emailFrom = "acesv2024@gmail.com";
                string smtpHost = "smtp.gmail.com";
                string smtpPorta = "587";
                string userName = "acesv2024@gmail.com";
                string password = "zxpr brfk fdwe rtct";
                string enableSSL = "true";

                MailMessage eMail = new MailMessage();


                                eMail.From = new MailAddress(emailFrom.ToString());

                emailPara = emailPara.Replace(';', ',');
                if (!string.IsNullOrEmpty(emailCC))
                    emailCC = emailCC.Replace(';', ',');

                                eMail.To.Add(emailPara.TrimEnd(','));

                                if (!string.IsNullOrEmpty(emailCC))
                    eMail.CC.Add(emailCC.TrimEnd(','));

                                eMail.Subject = assunto.ToString();

                                eMail.IsBodyHtml = true;

                                if (caminhoAnexos != null)
                {
                    foreach (string anexo in caminhoAnexos)
                    {
                        eMail.Attachments.Add(new System.Net.Mail.Attachment(anexo));
                    }
                }

                if (anexoBinario != null)
                {
                    MemoryStream ms = new MemoryStream();
                    ms.Write(anexoBinario, 0, anexoBinario.Length);
                    ms.Seek(0, SeekOrigin.Begin);

                                        ContentType ct = new ContentType();
                    ct.MediaType = MediaTypeNames.Application.Octet;
                    
                    Attachment attach = new Attachment(ms, ct);
                    attach.ContentDisposition.FileName = nomeAnexoBinario;
                    eMail.Attachments.Add(attach);
                }

                                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(corpoMensagem.ToString(), null, System.Net.Mime.MediaTypeNames.Text.Html);

                eMail.AlternateViews.Add(htmlView);

                                SmtpClient smtp = new SmtpClient();
                smtp.DeliveryFormat = SmtpDeliveryFormat.International;
                smtp.Host = smtpHost.ToString();
                smtp.Port = Convert.ToInt32(smtpPorta.ToString());
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential(userName, password);
                smtp.Send(eMail);

                smtp.Dispose();

                retorno = true;
            }
            catch (Exception ex)
            {
                retorno = false;
            }

            return retorno;
        }

        public static string padronizarCorpoEmail(string cabecalho, string msgCorpo, bool adicionarAssinatura = true)
        {
            StringBuilder sbCorpoMensagem = new StringBuilder();
            sbCorpoMensagem.Append("<html>");
            sbCorpoMensagem.Append("<head>");
            sbCorpoMensagem.Append("</head>");
            sbCorpoMensagem.Append("<body>");
            if (!string.IsNullOrEmpty(cabecalho))
                sbCorpoMensagem.Append("<p><span style = 'font -family: arial, helvetica, sans-serif; font-size: medium;'>" + cabecalho + "</span></p>");
            sbCorpoMensagem.Append("<p><br/><span style = 'font -family: arial, helvetica, sans-serif; font-size: medium;'>" + msgCorpo + "</span></p>");

            if (adicionarAssinatura)
            {
                sbCorpoMensagem.Append("<br>");
                sbCorpoMensagem.Append("<div>");
                sbCorpoMensagem.Append("</div>");
            }

            sbCorpoMensagem.Append("</body>");
            sbCorpoMensagem.Append("</html>");

            return sbCorpoMensagem.ToString();
        }
    }
}
