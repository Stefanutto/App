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
    public class LocacaoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Delete(int id)
        {
            if (Session.usuario == null) return Redirect("/Login/Index");
            ViewBag.Message = "";
            new LocacaoModel().DeleteLocacao(id);

            return Redirect("/Filmes/Index");
        }
        public IActionResult Add()
        {
            if (Session.usuario == null) return Redirect("/Login/Index");
            ViewBag.Message = "";
            return View();
        }

        [HttpPost]
        public IActionResult Add(Locacao locacao)
        {
            if (Session.usuario == null) return Redirect("/Login/Index");
            ViewBag.Message = "";

            //Defino a Cor do Alert
            ViewBag.AlertColor = "alert-warning";

            //Vou na class do filme para validar os campos digitados.
            ViewBag.Message = locacao.ValidatingFields();

            //Verifico se existem erros nos campos digitados.
            if (!locacao.ErrorValidatingFields)
            {
                //Insert no usuario
                if (new LocacaoModel().InsertOrUpdateLocacao(locacao))
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
            return View(locacao);
        }

        public IActionResult Edit(int id)
        {
            if (Session.usuario == null) return Redirect("/Login/Index");
            ViewBag.Message = "";
            ViewBag.id = id;

            return View(new LocacaoModel().FindLocacao(id));
        }
    }
}