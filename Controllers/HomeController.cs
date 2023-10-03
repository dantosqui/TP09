using Microsoft.AspNetCore.Mvc;

namespace tp09.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult InicioSesion(){
        return View();
    }
    
    public IActionResult PaginaInicio(){
        return View();
    }

    public IActionResult ContraseñaOlvidada(){
        return View();
    }

    
}
