using Microsoft.AspNetCore.Mvc;
using AgendaMedica.Models;

namespace AgendaMedica.Controllers
{
    public class PrevisionController : Controller
    {
        private BdagendaContext db = new();

        public IActionResult Index()
        {
            return View();
        }
    }
}
