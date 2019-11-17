using System.Collections.Generic;

namespace ValarAlerte.Models
{
    public class Formation
    {
        private int idFormation;
        private string name;
        private List<Session> sessions;

        public int IdFormation { get => idFormation; set => idFormation = value; }
        public string Name { get => name; set => name = value; }
        public List<Session> Sessions { get => sessions; set => sessions = value; }
    }
}