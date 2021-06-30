using System;
using System.Collections.Generic;
using System.IO;
using E_PlayersMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_PlayersMVC.Controllers
{
    [Route("Login")]
    public class LoginController : Controller
    {
        Jogador jogadorModel = new Jogador();

        [TempData]
        public string Mensagem { get; set; }

        public IActionResult Index()
        {
            return View();
        }

        [Route("Logar")]
        public IActionResult Logar(IFormCollection form)
        {
            List<string> Arquivocsv = jogadorModel.LerTodasLinhasCSV("Database/Jogador.csv");

            var logado =
            Arquivocsv.Find(
                x =>
                x.Split(";")[3] == form["Email"] &&
                x.Split(";")[4] == form["Senha"]
            );


            if (logado != null)
            {
                HttpContext.Session.SetString("_UserName", logado.Split(";")[1]);

                return LocalRedirect("~/");
            }

            Mensagem = "Dados incorretos, tente novamente...";
            return LocalRedirect("~/Login");
        }

        [Route("Deslogar")]
        public IActionResult Deslogar()
        {
            HttpContext.Session.Remove("_UserName");
            return LocalRedirect("~/");
        }

    }
}