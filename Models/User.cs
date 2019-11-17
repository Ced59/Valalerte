using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValAlerte.Tools;
using ValarAlerte.Tools.Bdds.BddValalerte;

namespace ValarAlerte.Models
{
    public class User
    {
        private int id;
        private string name;
        private string firstname;
        private string mailAdress;
        private string password;
        private string role;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Firstname { get => firstname; set => firstname = value; }
        public string MailAdress { get => mailAdress; set => mailAdress = value; }
        public string Password { get => password; set => password = value; }
        public string Role { get => role; set => role = value; }


        internal bool verifUserExist()
        {
            return BddValalerte.Instance.verifUserExist(this);
        }

        internal User login()
        {
            string hashPassword = Crypto.hashPassword(this.Password);
            return BddValalerte.Instance.ComparePassword(this.MailAdress, hashPassword);
        }
    }
}
