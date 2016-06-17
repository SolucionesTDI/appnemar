using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entidades;
using System.Text.RegularExpressions;
using System.Globalization;
/// <summary>
/// Descripción breve de generales
/// </summary>
public class generales
{
    protected bool invalid = false;
	public generales()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    public static void enviarMail(Email datamail)
    {
        using (System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage())
        {
            System.Net.Mail.MailAddress from = new System.Net.Mail.MailAddress(datamail.MailFrom, datamail.MailFromName);
            message.From = from;
            
            // Dirección de destino
            if (!string.IsNullOrEmpty(datamail.MailTo.Trim()))
            {
                message.To.Add(datamail.MailTo);
            }

            if (!string.IsNullOrEmpty(datamail.MailCC.Trim()))
            {
                message.CC.Add(datamail.MailCC);
            }

            if (!string.IsNullOrEmpty(datamail.MailBcc.Trim()))
            {
                message.Bcc.Add(datamail.MailBcc);
            }


            // Asunto 
            message.Subject =datamail.Asunto;
            // Mensaje 
            message.Body = datamail.Body;
            
            /*
            if (!string.IsNullOrEmpty(datamail.Adjuntos))
            {
                message.Attachments.Add(new System.Net.Mail.Attachment(rutafirma));
            }
            */
        
            // Se envía el mensaje y se informa al usuario
            System.Net.Mail.SmtpClient smpt = new System.Net.Mail.SmtpClient(datamail.Smtp, datamail.PortSmtp);
            string mensaje = string.Empty;
            try
            {
                smpt.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                message.IsBodyHtml = true;
                smpt.EnableSsl = (datamail.Ssl) ? true : false;
                smpt.UseDefaultCredentials = false;
                //smpt.Credentials = new System.Net.NetworkCredential("demo@solucionestdi.com", usuario.PassMail);
                smpt.Timeout = 360000;
                smpt.Credentials = new System.Net.NetworkCredential(datamail.Usermail, datamail.Passmail);
                smpt.Send(message);
                
            }
            catch (Exception ex)
            {
                throw new Exception("Email no enviado: " + ex.Message);
            }
            finally
            {
                smpt.Dispose();
            }
            
        }
    }

    public bool IsValidEmail(string strIn)
    {
        invalid = false;
        if (String.IsNullOrEmpty(strIn))
            return false;

        // Use IdnMapping class to convert Unicode domain names.
        try
        {
            strIn = Regex.Replace(strIn, @"(@)(.+)$", DomainMapper,
                                  RegexOptions.None, TimeSpan.FromMilliseconds(200));
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }

        if (invalid)
            return false;

        // Return true if strIn is in valid e-mail format.
        try
        {
            return Regex.IsMatch(strIn,
                  @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                  @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                  RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }

    private string DomainMapper(Match match)
    {
        // IdnMapping class with default property values.
        IdnMapping idn = new IdnMapping();

        string domainName = match.Groups[2].Value;
        try
        {
            domainName = idn.GetAscii(domainName);
        }
        catch (ArgumentException)
        {
            invalid = true;
        }
        return match.Groups[1].Value + domainName;
    }

}