using Acesv2.Models;
using Acesvv.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace Acesvv.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BD _context;

        public HomeController(ILogger<HomeController> logger, BD context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            //Retorna todas as escolas da tabela Escolas
            var escolas = _context.Escolas.ToList();
            ViewBag.Escolas = new SelectList(escolas, "Id", "NomeEscola");
            return View();

        }
        public IActionResult RedirectToViewEscola(int escolaId)
        {
            return RedirectToAction("Index", "ViewEscola", new { id = escolaId });
        }
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