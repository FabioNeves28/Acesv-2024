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

                //TODO: Verificar se é necessário alterar as configurações de email, host esta dando timeout
                string emailFrom = "fabioalvesneves@gmail.com";
                string smtpHost = "smtp.gmail.com";
                string smtpPorta = "465";
                string userName = "fabioalvesneves@gmail.com";
                string password = "xcrw vvhr qoll nfaj";
                string enableSSL = "true";

                MailMessage eMail = new MailMessage();


                //Email De
                eMail.From = new MailAddress(emailFrom.ToString());

                emailPara = emailPara.Replace(';', ',');
                if (!string.IsNullOrEmpty(emailCC))
                    emailCC = emailCC.Replace(';', ',');

                //Email Para
                eMail.To.Add(emailPara.TrimEnd(','));

                //Email CC
                if (!string.IsNullOrEmpty(emailCC))
                    eMail.CC.Add(emailCC.TrimEnd(','));

                //Assunto
                eMail.Subject = assunto.ToString();

                //Mensagem
                eMail.IsBodyHtml = true;

                // Obtem os anexos contidos em um arquivo arraylist e inclui na mensagem
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

                    // Create attachment
                    ContentType ct = new ContentType();
                    ct.MediaType = MediaTypeNames.Application.Octet;
                    //ct.Name = nomeAnexo;

                    Attachment attach = new Attachment(ms, ct);
                    attach.ContentDisposition.FileName = nomeAnexoBinario;
                    eMail.Attachments.Add(attach);
                }

                //Cria uma visualização alternativa do HTML 
                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(corpoMensagem.ToString(), null, System.Net.Mime.MediaTypeNames.Text.Html);

                eMail.AlternateViews.Add(htmlView);

                //Informações do SMTP 
                SmtpClient smtp = new SmtpClient();
                smtp.DeliveryFormat = SmtpDeliveryFormat.International;
                smtp.Host = smtpHost.ToString();
                smtp.Port = Convert.ToInt32(smtpPorta.ToString());
                smtp.EnableSsl = Convert.ToBoolean(enableSSL);
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
