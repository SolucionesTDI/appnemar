using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Email
    {
        public int IdMail { get; set; }
        public string NomEmail { get; set; }
        public string Imap { get; set; }
        public string Smtp { get; set; }
        public int PortImap { get; set; }
        public int PortSmtp { get; set; }
        public bool Ssl { get; set; }
        public string Servermail { get; set; }
        public string Usermail { get; set; }
        public string Passmail { get; set; }
        public bool? Principal { get; set; }
        public string Asunto { get; set; }
        public string Body { get; set; }
        public string MailTo { get; set; }
        public string MailFrom { get; set; }
        public string MailFromName { get; set; }
        public string MailCC { get; set; }
        public string MailBcc { get; set; }
        public string Replyto { get; set; }
        public string Adjuntos { get; set; }
    }
}
