using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Func;
using App.Models;
using EF.Domain;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class GeneroController : Controller
    {
        public IActionResult Index()
        {
            if (Session.usuario == null) return Redirect("/Login/Index");
            return View();
        }

        public IActionResult Delete(int id)
        {
            if (Session.usuario == null) return Redirect("/Login/Index");
            ViewBag.Message = "";
            new GeneroModel().DeleteGenero(id);

            return Redirect("/Filmes/Index");
        }

        public IActionResult Add()
        {
            if (Session.usuario == null) return Redirect("/Login/Index");
            ViewBag.Message = "";
            return View();
        }

        [HttpPost]
        public IActionResult Add(Genero genero)
        {
            if (Session.usuario == null) return Redirect("/Login/Index");
            ViewBag.Message = "";

            //Defino a Cor do Alert
            ViewBag.AlertColor = "alert-warning";

            //Vou na class do filme para validar os campos digitados.
            ViewBag.Message = genero.ValidatingFields();

            //Verifico se existem erros nos campos digitados.
            if (!genero.ErrorValidatingFields)
            {
                //Insert no usuario
                if (new GeneroModel().InsertOrUpdateGenero(genero))
                {
                    ViewBag.AlertColor = "alert-success";
                    ViewBag.Message = "Genero cadastrado com sucesso";
                    return View(null);
                    //return Redirect("/Filmes/Edit/" + filme.Id);
                }
                else
                {
                    ViewBag.Message = "Erro.";
                }
            }
            return View(genero);
        }

        public IActionResult Edit(int id)
        {
            if (Session.usuario == null) return Redirect("/Login/Index");
            ViewBag.Message = "";
            ViewBag.id = id;

            return View(new GeneroModel().FindGenero(id));
        }
    }
}