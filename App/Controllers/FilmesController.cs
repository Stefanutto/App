using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Func;
using EF.Domain;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class FilmesController : Controller
    {

        public IActionResult Index()
        {
            if (Session.usuario == null)
                return Redirect("/Login/Index");

            return View();
        }
    }
}