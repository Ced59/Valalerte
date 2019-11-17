using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ValarAlerte.Models
{
    public class Formateur : User
    {
        private List<Session> sessions;

        public List<Session> Sessions { get => sessions; set => sessions = value; }
        
    }
}
