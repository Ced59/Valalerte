using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ValarAlerte.Controllers
{
    public class UserController : Controller
    {

        [HttpPost]
        public IActionResult Index(string mail, string password)
        {
            List<string> errors = new List<string>();

            if (mail == null)
            {
                errors.Add("Merci de saisir votre adresse Mail.");
            }
            if (password == null)
            {
                errors.Add("Merci de saisir votre Mot de Passe.");
            }

            if (errors.Count > 0)
            {
                return RedirectToRoute(new { controller = "Home", action = "IndexError", errors = errors, mail = mail });
            }
            else
            {
                return View();
            }

            
        }
    }
}