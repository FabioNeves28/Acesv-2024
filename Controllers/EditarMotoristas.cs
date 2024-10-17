using Acesv2.Models;
using Acesvv.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

    public class EditarMotoristas : Controller
    {
        // GET: Transportadores/EditarMotorista
        public IActionResult TelaDados()
        {
            // Renderiza a view da página localizada em Views/EditarMotorista/TelaDados.cshtml
            return View();
        }
    }


