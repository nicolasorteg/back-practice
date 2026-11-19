using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PracticaRazor.Pages;

public class Edad : PageModel {
    
    public int Años { get; set; } 
    
    public void OnGet(int edad) {
        Años = edad;
    }
}