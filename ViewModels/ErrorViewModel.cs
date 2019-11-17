using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ValarAlerte.ViewModels
{
    public class ErrorViewModel
    {
        private List<string> errors;
        private string mail;

        public List<string> Errors { get => errors; set => errors = value; }
        public string Mail { get => mail; set => mail = value; }
    }
}
