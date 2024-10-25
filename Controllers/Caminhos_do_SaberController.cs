using Acesv2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Acesvv.Controllers
{
    public class Caminhos_do_SaberController : Controller
    {
        private readonly BD _context;

        public Caminhos_do_SaberController(BD context)
        {
            _context = context;
        }

        // GET: Dados
        public async Task<IActionResult> Index()
        {
            var dadosEscola = _context.Dados.Where(d => d.Escola.NomeEscola == "Caminhos do Saber").ToList();

            if (dadosEscola.Count == 0)
            {
                ViewBag.ErrorMessage = "Não foram encontrados transportadores para essa escola.";
                return View("Error");
            }

            return View(dadosEscola);
        }



    }
}
