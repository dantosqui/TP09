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
    public IActionResult Login(string usuario,string contraseña){
        bool correcto = BD.Login(usuario,contraseña);
        if (correcto){
            return View("PaginaInicio");
        }
        else{
            ViewBag.ErrorInicio="Contraseña o usuario incorrectos. Intente otra vez.";
            return View("InicioSesion");
        }
    }
    public IActionResult PaginaInicio(){
        return View();
    }
}
