using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ValarAlerte.Models;
using ValarAlerte.ViewModels;

namespace ValarAlerte.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IndexError(List<string> errors, string mail)
        {
            ErrorViewModel error = new ErrorViewModel { Errors = errors, Mail = mail };

            return View("Index", error);
        }

        

       
    }
}
