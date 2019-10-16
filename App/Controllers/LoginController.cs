using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF.Domain;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View(new Usuario());
        }
        
        [HttpPost]
        public ActionResult Add(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine(usuario);
                return View("Index");
            }

            Console.WriteLine(usuario);
            return Redirect("Index");

        }

    }
}