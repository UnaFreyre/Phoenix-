using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace web_app.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly Repositories.ADO.SQLServer.Professor repository;

        public ProfessorController(IConfiguration configuration) // objeto configuration => parte do framework que permite ler o arquivo appsettings.json - GetConnectionString => método do framework que permite ler a chave ConnectionStrings deste arquivo.
        {
            this.repository = new Repositories.ADO.SQLServer.Professor(configuration.GetConnectionString(Configurations.Appsettings.getKeyConnectionString()));
            //Configurations.Appsettings.getKeyConnectionString => nossa classe de configuração para trazer a chave que deve ser lida, neste caso: DefaultConnection.
        }
        // GET: ProfessorController
        public ActionResult Index()
        {
            return View(this.repository.get());
        }

        // GET: ProfessorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProfessorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProfessorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProfessorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProfessorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProfessorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProfessorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
