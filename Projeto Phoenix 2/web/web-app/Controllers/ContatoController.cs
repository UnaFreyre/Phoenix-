using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace web_app.Controllers
{
    public class ContatoController : Controller
    {
        // GET: ContatoController
        public ActionResult Index()
        {
            return View();
        }
    }
}
