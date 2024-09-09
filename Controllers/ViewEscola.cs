using Acesv2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Acesvv.Controllers
{
    public class ViewEscola : Controller
    {
        private readonly BD _context;

        public ViewEscola(BD context)
        {
            _context = context;
        }
        private int ObtenhaEscolaIdComBaseNoNome(string nomeEscola)
        {
            var escola = _context.Escolas.FirstOrDefault(e => e.NomeEscola == nomeEscola);

            if (escola != null)
            {
                return escola.Id;
            }

            // Se a escola não for encontrada, retorne um valor padrão ou lance uma exceção, dependendo da sua lógica.
            // Neste exemplo, estamos retornando -1 se a escola não for encontrada.
            return -1;
        }
        // GET: Dados
        public IActionResult Index(string nomeEscolaEscolhida)
        {
            if (string.IsNullOrEmpty(nomeEscolaEscolhida))
            {
                ViewBag.ErrorMessage = "Escola não selecionada.";
                return View("Error");
            }

            int escolaId = ObtenhaEscolaIdComBaseNoNome(nomeEscolaEscolhida);

            if (escolaId == -1)
            {
                ViewBag.ErrorMessage = "Escola não encontrada.";
                return View("Error");
            }

            var transportadores = _context.Dados.Where(d => d.EscolasSelecionadas.Contains(escolaId.ToString())).ToList();
            ViewBag.Transportadores = transportadores; // Preencha a propriedade ViewBag.Transportadores


            return View(transportadores);
        }



    }
}
