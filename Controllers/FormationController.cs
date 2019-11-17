using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ValAlerte.Tools;
using ValarAlerte.Models;
using ValAlerte.ViewModels;

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
            User u = createUserWithViewBag();

            if (!ViewBag.logged)
            {
                List<string> errors = new List<string>();
                errors.Add(ErrorMessages.Disconnect());

                return RedirectToRoute(new { controller = "Home", action = "IndexError", errors = errors, mail = "" });
            }
            Formation f = new Formation();

            List<Formation> formations = new List<Formation>();
            formations = f.getFormations();

            FormationUserViewModel model = new FormationUserViewModel { Formations = formations, User = u };

            return View("AddFormation", model);
        }

        public IActionResult Add(string name)
        {
            UserConnect(ViewBag);
            User u = createUserWithViewBag();

            if (!ViewBag.logged)
            {
                List<string> errors = new List<string>();
                errors.Add(ErrorMessages.Disconnect());

                return RedirectToRoute(new { controller = "Home", action = "IndexError", errors = errors, mail = "" });
            }

            Formation f = new Formation { Name = name };

            f = f.Add();

            List<Formation> formations = new List<Formation>();
            formations = f.getFormations();

            FormationUserViewModel model = new FormationUserViewModel { Formations = formations, User = u };
                
            return View("AddFormation", model);
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

        private User createUserWithViewBag()
        {
            return new User
            {
                Firstname = ViewBag.FirstName,
                Id = Convert.ToInt32(ViewBag.Id),
                Name = ViewBag.Name,
                MailAdress = ViewBag.MailAdress,
                Role = ViewBag.Role
            };
        }


    }
}