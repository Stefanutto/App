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
    public class FilmesController : Controller
    {

        public IActionResult Index()
        {
            if (Session.usuario == null) return Redirect("/Login/Index");

            return View();
        }

        public IActionResult Add()
        {
            if (Session.usuario == null) return Redirect("/Login/Index");
            ViewBag.Message = "";
            return View();
        }

        [HttpPost]
        public IActionResult Add(Filme filme)
        {
            if (Session.usuario == null) return Redirect("/Login/Index");
            ViewBag.Message = "";

            //Defino a Cor do Alert
            ViewBag.AlertColor = "alert-warning";

            //Vou na class do filme para validar os campos digitados.
            ViewBag.Message = filme.ValidatingFields();

            //Verifico se existem erros nos campos digitados.
            if (!filme.ErrorValidatingFields)
            {
                //Insert no usuario
                if (new FilmeModel().InsertOrUpdateFilme(filme))
                {
                    ViewBag.AlertColor = "alert-success";
                    return Redirect("/Filmes/Edit/" + filme.Id);
                }
                else
                {
                    ViewBag.Message = "Erro.";
                }
            }
            return View(filme);

        }

        public IActionResult Edit(int id)
        {
            if (Session.usuario == null) return Redirect("/Login/Index");
            ViewBag.Message = "";
            ViewBag.id = id;

            return View(new FilmeModel().FindFime(id));
        }

        public IActionResult Delete(int id)
        {
            if (Session.usuario == null) return Redirect("/Login/Index");
            ViewBag.Message = "";
            new FilmeModel().DeleteFilme(id);

            return Redirect("/Filmes/Index");
        }
    }
}