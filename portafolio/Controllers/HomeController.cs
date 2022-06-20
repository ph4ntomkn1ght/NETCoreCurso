using Microsoft.AspNetCore.Mvc;
using portafolio.Models;
using portafolio.Servicios;
using System.Diagnostics;

namespace portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {


            //var persona = new Persona() { 
            //    nombre = "Ramon Escamilla Aguilar",
            //    Edad = 15
            //};
            ViewBag.Nombre = "Ramon Escamilla";//Usamos el viewbag para mandar la informacion
            var repProy = new RepositorioProyectos();
            var proyectos = repProy.ObtenerProyectos().Take(3).ToList();
            var modelo = new HomeIndexViewModel() { proyectos = proyectos };
            return View(modelo);
        }
        
        public IActionResult Privacy()
        {
            return View("Privacy","Soy Franco Escamilla");//usamos un modelo fuertemente tipado
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}