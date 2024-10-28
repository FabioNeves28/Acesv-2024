using Microsoft.AspNetCore.Mvc;

namespace Acesvv.Controllers
{
    public class NovoAssociadoController : Controller
    {
        public IActionResult NovoAssociado()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NovoAssociado(string codigo)
        {
            const string codigoCorreto = "N0vo4ssociado2024";

            if (codigo == codigoCorreto)
            {
                return Redirect("/Identity/Account/Register");

            }
            else
            {
                ModelState.AddModelError(string.Empty, "Erro: o código fornecido está incorreto.");
                return View();
            }
        }
    }
    public class NovoAssociadoModel
    {
        public string Codigo { get; set; }
    }
}
