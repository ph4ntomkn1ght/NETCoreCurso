using Microsoft.AspNetCore.Mvc;
using portafolio.Models;
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
            var proyectos = ObtenerProyectos().Take(3).ToList();
            var modelo = new HomeIndexViewModel() { proyectos = proyectos };
            return View(modelo);
        }
        private List<Proyecto> ObtenerProyectos()
        {
            return new List<Proyecto>()
            {
                new Proyecto
                {
                    Titulo = "Amazon",
                    Descripcion = "E-Commerce realizado en ASP.NET Core",
                    Link ="https://amazon.com",
                    ImagenURL ="/img/amazon.PNG"
                },
                new Proyecto
                {
                    Titulo = "Google",
                    Descripcion = "Buscador realizado en ASP.NET Core",
                    Link ="https://google.com",
                    ImagenURL ="/img/reddit.PNG"
                },
                new Proyecto
                {
                    Titulo = "Youtube",
                    Descripcion = "Reproductor de videos realizado en ASP.NET Core",
                    Link ="https://youtube.com",
                    ImagenURL ="/img/steam.PNG"
                }

            };
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