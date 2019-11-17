using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ValarAlerte.Models
{
    public class User
    {
        private int id;
        private string name;
        private string firstname;
        private string mailAdress;
        private string password;
        

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Firstname { get => firstname; set => firstname = value; }
        public string MailAdress { get => mailAdress; set => mailAdress = value; }
        public string Password { get => password; set => password = value; }

        public enum Role {Directeur, Formateur, Etudiant};

    }
}
