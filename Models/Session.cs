using System;
using System.Collections.Generic;

namespace ValarAlerte.Models
{
    public class Session
    {
        private int idSession;      
        private DateTime dateDebut;
        private DateTime dateFin;
        private List<User> students;

        public int IdSession { get => idSession; set => idSession = value; }
        public DateTime DateDebut { get => dateDebut; set => dateDebut = value; }
        public DateTime DateFin { get => dateFin; set => dateFin = value; }
        public List<User> Students { get => students; set => students = value; }
    }
}