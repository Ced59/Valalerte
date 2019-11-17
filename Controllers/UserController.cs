using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ValarAlerte.Models;

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
                string pattern = @"^[A-z0-9._-]+(@)[a-z-9_-]+\.[a-z]{2,5}$";
                Regex r = new Regex(pattern);

                if (!r.IsMatch(mail))
                {
                    errors.Add("Cette adresse mail n'est pas valide.");

                    return RedirectToRoute(new { controller = "Home", action = "IndexError", errors = errors, mail = mail });
                }


                User u = new User { MailAdress = mail, Password = password };

                if (!u.verifUser())
                {
                    errors.Add("Il n'y a pas d'utilisateur avec cette adresse mail / mot de passe.");

                    return RedirectToRoute(new { controller = "Home", action = "IndexError", errors = errors, mail = mail });
                }

                return View();
            }

            
        }
    }
}