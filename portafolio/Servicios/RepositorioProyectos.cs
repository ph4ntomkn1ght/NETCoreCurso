using portafolio.Models;

namespace portafolio.Servicios
{
    public interface IRepositorioProyectos
    {
        List<Proyecto> ObtenerProyectos();
    }
    public class RepositorioProyectos: IRepositorioProyectos
    {

        public List<Proyecto> ObtenerProyectos()
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
    }
}
