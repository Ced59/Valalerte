using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ValAlerte.Tools;

namespace ValAlerte.Controllers
{
    public class FormationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddFormation()
        {
            UserConnect(ViewBag);

            if (!ViewBag.logged)
            {
                List<string> errors = new List<string>();
                errors.Add(ErrorMessages.Disconnect());

                return RedirectToRoute(new { controller = "Home", action = "IndexError", errors = errors, mail = "" });
            }

            return View("AddFormation");
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