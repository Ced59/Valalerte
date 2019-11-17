using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValarAlerte.Models;

namespace ValAlerte.ViewModels
{
    public class FormationUserViewModel
    {
        private List<Formation> formations;
        private User user;

        public List<Formation> Formations { get => formations; set => formations = value; }
        public User User { get => user; set => user = value; }
    }
}
