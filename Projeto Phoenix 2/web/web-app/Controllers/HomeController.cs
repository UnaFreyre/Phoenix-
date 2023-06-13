using Microsoft.AspNetCore.Mvc;
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
        private readonly ILogger<HomeController> _logger;
        public HomeController(IConfiguration configuration) // objeto configuration => parte do framework que permite ler o arquivo appsettings.json - GetConnectionString => método do framework que permite ler a chave ConnectionStrings deste arquivo.
        {
            this.sProf = new Repositories.ADO.SQLServer.Professor(configuration.GetConnectionString(Configurations.Appsettings.getKeyConnectionString()));
            this.sEstudante = new Repositories.ADO.SQLServer.Estudante(configuration.GetConnectionString(Configurations.Appsettings.getKeyConnectionString()));
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