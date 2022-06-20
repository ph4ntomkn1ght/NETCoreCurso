using Microsoft.AspNetCore.Mvc;
using portafolio.Models;
using portafolio.Servicios;
using System.Diagnostics;

namespace portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorioProyectos repProy;
        private readonly ServicioDelimitado servicioDelimitado;
        private readonly ServicioTransitorio servicioTransitorio;
        private readonly ServicioUnico servicioUnico;

        public HomeController(ILogger<HomeController> logger,IRepositorioProyectos repProy,ServicioDelimitado servicioDelimitado,ServicioTransitorio servicioTransitorio,ServicioUnico servicioUnico)
        {
            _logger = logger;
            this.repProy = repProy;
            this.servicioDelimitado = servicioDelimitado;
            this.servicioTransitorio = servicioTransitorio;
            this.servicioUnico = servicioUnico;
        }

        public IActionResult Index()
        {


            //var persona = new Persona() { 
            //    nombre = "Ramon Escamilla Aguilar",
            //    Edad = 15
            //};
            
            var proyectos = repProy.ObtenerProyectos().Take(3).ToList();
            var guidViewModel = new EjemploGUIDViewModel() {
                Delimitado = servicioDelimitado.ObtenerGuid,
                Transitorio = servicioTransitorio.ObtenerGuid,
                Unico = servicioUnico.ObtenerGuid
            };
            var modelo = new HomeIndexViewModel() { proyectos = proyectos,
                EjemploGUID_1 = guidViewModel
            };
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