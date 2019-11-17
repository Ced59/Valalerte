using System;

namespace ValarAlerte.Models
{
    public class Session
    {
        private int idSession;      
        private DateTime anneDebut;
        private DateTime anneeFin;

        public int IdSession { get => idSession; set => idSession = value; }
        public DateTime AnneDebut { get => anneDebut; set => anneDebut = value; }
        public DateTime AnneeFin { get => anneeFin; set => anneeFin = value; }

    }
}