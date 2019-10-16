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
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            Session.usuario = null;
            ViewBag.Message = "";
            return View();
        }

        [HttpPost]
        public IActionResult Index(Usuario usuario)
        {
            UsuarioModel usuarioModel = new UsuarioModel();

            if (usuarioModel.ValidatingLogin(usuario))
                return Redirect("/Filmes/Index");
  
            ViewBag.Message = "Usuário e/ou Senha inválidas";
            return View();

        }


        public IActionResult Singup()
        {
            ViewBag.Message = "";
            return View();
        }
        
        [HttpPost]
        public ActionResult Singup(Usuario usuario)
        {
            //Defino a Cor do Alert
            ViewBag.AlertColor = "alert-warning";

            //Vou na class do usuario para validar os campos digitados.
            ViewBag.Message = usuario.ValidatingFields();

            //Verifico se existem erros nos campos digitados.
            if(!usuario.ErrorValidatingFields)
            {
                UsuarioModel usuarioModel = new UsuarioModel();
                //Verifico se no banco de dados já tem esse usuario cadastrado.
                if (usuarioModel.UserExists(usuario))
                {
                    ViewBag.Message = "Usuário já cadastrado";
                    //Não vou fazer a recuperação de senha por que acredito que não é o fodo desse teste.
                }
                else
                {
                    //Insert no usuario
                    if (usuarioModel.InsertUser(usuario))
                    {
                        ViewBag.AlertColor = "alert-success";
                    }
                    else
                    {
                        ViewBag.Message = "Erro ao tentar cadastrar o usuário.";
                    }
                }
            }
            

            return View("Singup");
        }


    }
}