using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ValAlerte.Tools;
using ValarAlerte.Models;

namespace ValarAlerte.Controllers
{
    public class UserController : Controller
    {

        [HttpPost]
        public IActionResult Login(string mail, string password)
        {
            List<string> errors = new List<string>();

            if (mail == null)
            {
                errors.Add(ErrorMessages.MissMail());
            }
            if (password == null)
            {
                errors.Add(ErrorMessages.MissMdp());
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
                    errors.Add(ErrorMessages.InvalidMail());

                    return RedirectToRoute(new { controller = "Home", action = "IndexError", errors = errors, mail = mail });
                }


                User u = new User { MailAdress = mail, Password = password };

                if (!u.verifUserExist())
                {
                    errors.Add(ErrorMessages.FailedLogin());

                    return RedirectToRoute(new { controller = "Home", action = "IndexError", errors = errors, mail = mail });
                }

                u = u.login();

                if (u.Name == null)
                {
                    errors.Add(ErrorMessages.FailedLogin());

                    return RedirectToRoute(new { controller = "Home", action = "IndexError", errors = errors, mail = mail });
                }

                else
                {
                    HttpContext.Session.SetString("logged", "true");
                    HttpContext.Session.SetString("name", u.Name);
                    HttpContext.Session.SetString("idUser", u.Id.ToString());
                    HttpContext.Session.SetString("role", u.Role);
                    HttpContext.Session.SetString("firstname", u.Firstname);
                    HttpContext.Session.SetString("mail", u.MailAdress);

                    return RedirectToRoute(new { controller = "User", action = "Index" });
                }              
            }           
        }

        public IActionResult Index()
        {
            UserConnect(ViewBag);

            User u = new User 
            { 
                Firstname = ViewBag.FirstName, 
                Id = Convert.ToInt32(ViewBag.Id), 
                Name = ViewBag.Name, 
                MailAdress = ViewBag.MailAdress,
                Role = ViewBag.Role 
            };

            

            return View("Index", u);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }



        private void UserConnect(dynamic v)
        {
            bool? logged = Convert.ToBoolean(HttpContext.Session.GetString("logged"));
            if (logged == true)
            {
                v.Logged = logged;
                v.Name = HttpContext.Session.GetString("name");
                v.Id = HttpContext.Session.GetString("idUser");
                v.MailAdress = HttpContext.Session.GetString("mail");
                v.Role = HttpContext.Session.GetString("role");
                v.FirstName = HttpContext.Session.GetString("firstname");
                
            }

            else
            {
                v.Logged = false;
            }
        }
    }
}