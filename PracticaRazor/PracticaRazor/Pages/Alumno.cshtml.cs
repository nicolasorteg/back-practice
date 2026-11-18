using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PracticaRazor.Pages;

public class Alumno : PageModel {

    // datos
    public string Nombre { get; set; } = string.Empty;
    public int? Edad { get; set; } // no es obligatoria
    
    public void OnGet(int? edad, string nombre) {
        Edad = edad;
        Nombre = nombre;
    }
}