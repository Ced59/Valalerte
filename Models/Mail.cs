using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ValarAlerte.Models
{
    public class Mail
    {
        private int id;
        private string subject;
        private string body;
        private DateTime dateEnvoi;
        private Session session;

        public int Id { get => id; set => id = value; }
        public string Subject { get => subject; set => subject = value; }
        public string Body { get => body; set => body = value; }
        public DateTime DateEnvoi { get => dateEnvoi; set => dateEnvoi = value; }
        public Session Session { get => session; set => session = value; }
    }
}
