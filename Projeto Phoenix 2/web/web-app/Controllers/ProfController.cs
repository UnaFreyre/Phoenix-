using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace web_app.Controllers
{
    public class ProfController : Controller
    {
        // GET: ProfController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProfController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProfController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProfController/Create
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

        // GET: ProfController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProfController/Edit/5
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

        // GET: ProfController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProfController/Delete/5
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
