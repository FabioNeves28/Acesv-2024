using Acesv2.Models;
using Acesvv.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


    public class RecuperarSenha : Controller
    {
        public IActionResult TelaRecuperarSenha()
        {
            return View();
        }
    public IActionResult TelaNovaSenha()
    {
        return View();
    }
}
