using Acesv2.Models;
using Acesvv.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

public class TeladeLoginController : Controller
{
    // Ação para exibir a página TelaPosLogin
    public IActionResult TeladeLogin()
    {
        return View();
    }
}
