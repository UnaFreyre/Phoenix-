﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using web_app.Filters;
using web_app.Models;

namespace web_app.Controllers
{
    [UsuarioLogado]
    public class HomeController : Controller
    {
        private readonly Repositories.ADO.SQLServer.Professor sProf;
        private readonly Repositories.ADO.SQLServer.Estudante sEstudante;
        private readonly Repositories.ADO.SQLServer.Login sLogin;
        private readonly ILogger<HomeController> _logger;
        public HomeController(IConfiguration configuration) // objeto configuration => parte do framework que permite ler o arquivo appsettings.json - GetConnectionString => método do framework que permite ler a chave ConnectionStrings deste arquivo.
        {
            this.sProf = new Repositories.ADO.SQLServer.Professor(configuration.GetConnectionString(Configurations.Appsettings.getKeyConnectionString()));
            this.sEstudante = new Repositories.ADO.SQLServer.Estudante(configuration.GetConnectionString(Configurations.Appsettings.getKeyConnectionString()));
            this.sLogin = new Repositories.ADO.SQLServer.Login(configuration.GetConnectionString(Configurations.Appsettings.getKeyConnectionString()));
            //Configurations.Appsettings.getKeyConnectionString => nossa classe de configuração para trazer a chave que deve ser lida, neste caso: DefaultConnection.
        }
        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;            
        //}

        public IActionResult Index()
        {
            var viewModel = new List<Conjunto>(); // Cria uma lista de Conjunto
            var conjunto = new Conjunto();
            conjunto.Professores = sProf.get();
            conjunto.Estudantes = sEstudante.get();
            conjunto.Logins = sLogin.get();
            viewModel.Add(conjunto); // Adiciona o objeto Conjunto à lista

            return View(viewModel);
        }
        //public IActionResult MinhaView()
        //{
        //    var viewModel = new Conjunto();
        //    viewModel.Professores =sProf.get();
        //    viewModel.Alunos = sEstudante.get();

        //    return View(viewModel);
        //}
        public ActionResult Delete(int professorid)
        {
            this.sProf.delete(professorid);
            return RedirectToAction(nameof(Index));
        }
        public ActionResult DeleteE(int estudanteid)
        {
            this.sEstudante.delete(estudanteid);
            return RedirectToAction(nameof(Index));
        }
        public ActionResult DeleteL(int loginid)
        {
            this.sLogin.delete(loginid);
            return RedirectToAction(nameof(Index));
        }
        //Professor Create
        // GET: ProfessorController/Create
        public ActionResult CreateProf()
        {
            return View();
        }

        // POST: ProfessorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProf(Models.Professor professor)
        {
            try
            {
                sProf.add(professor);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //Professor Edit
        // GET: ProfessorController/Edit/5
        public ActionResult EditProf(int professorid)
        {
            return View(this.sProf.getById(professorid));
        }

        // POST: ProfessorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProf(int professorid, Models.Professor professor)
        {
            try
            {
                this.sProf.update(professorid, professor);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        //Estudante Create
        public ActionResult CreateEstu()
        {
            return View();
        }

        // POST: ProfessorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEstu(Models.Estudante estudante)
        {
            try
            {
                sEstudante.add(estudante);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult CreateLogin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateLogin(Models.Login login)
        {
            try
            {
                sLogin.Add(login);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult EditLogin(int loginid)
        {
            return View(this.sLogin.getById(loginid));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditLogin(int loginid, Models.Login login)
        {
            try
            {
                this.sLogin.update(loginid, login);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        //Estudante edit
        public ActionResult EditEstudante(int estudanteid)
        {
            return View(this.sEstudante.getById(estudanteid));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEstudante(int estudanteid, Models.Estudante estudante)
        {
            try
            {
                this.sEstudante.update(estudanteid, estudante);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}