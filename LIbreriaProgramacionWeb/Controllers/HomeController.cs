using LIbreriaProgramacionWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LIbreriaProgramacionWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly LiberiaprograwebContext context;

        public HomeController(LiberiaprograwebContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var datos = context.Libros.OrderBy(x => x.Titulo).Include(x=>x.IdGeneroNavigation);
            return View(datos);
        }
        [Route("DetallesLibro/{titulo}")]
        public IActionResult DetallesLibro(string titulo) 
        {
            var datos = context.Libros.Include(x=>x.IdGeneroNavigation).FirstOrDefault(x=>x.Titulo == titulo.Replace("-"," "));
            return View(datos);
        }
    }
}
