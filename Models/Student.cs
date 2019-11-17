using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ValarAlerte.Models
{
    public class Student : User
    {
        private Formation formation;
        private Session session;

        public Formation Formation { get => formation; set => formation = value; }
        public Session Session { get => session; set => session = value; }
    }
}
