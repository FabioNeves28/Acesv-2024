﻿using Acesv2.Models;
using Acesvv.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

public class LoginController : Controller
{
    
    public IActionResult TelaPosLogin()
    {
        return View();
    }
    public IActionResult TelaDeLogin()
    {
        return View();
    }
}
