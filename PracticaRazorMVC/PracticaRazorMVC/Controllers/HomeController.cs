using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PracticaRazorMVC.Models;

namespace PracticaRazorMVC.Controllers;

public class HomeController : Controller {
    public IActionResult Index() {
        return View();
    }

    public IActionResult Privacy() {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    public IActionResult Hola() {
        return View();
    }
    
    [HttpGet("home/alumno")]
    public IActionResult Alumno(string? nombre) {
        var saludo = string.IsNullOrWhiteSpace(nombre)
            ? "hola"
            : $"hola {nombre}";

        return View("Alumno", saludo);
    }
    
    [HttpGet("home/alumno/{edad:int}")]
    public IActionResult PuedeVotar(int edad, string? nombre)
    {
        if (edad < 0 || edad > 120) {
            return View("PuedeVotar", "La edad debe estar entre 0 y 120");
        }

        var mensaje = edad >= 18
            ? "Puedes votar campeón"
            : "No puedes votar crack";

        if (!string.IsNullOrWhiteSpace(nombre)) {
            mensaje = $"{nombre}, {mensaje.ToLowerInvariant()}";
        }

        return View("PuedeVotar", mensaje);
    }
    
    [HttpGet("home/edad/{edad}")]
    public IActionResult Edad(int edad)
    {
        ViewData["TituloPagina"] = "Tu edad";
        return View(edad);
    }
}