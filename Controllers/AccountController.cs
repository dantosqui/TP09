using Microsoft.AspNetCore.Mvc;

namespace tp09.Controllers;

public class AccountController : Controller
{

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

    public IActionResult CambiarContraseña(string contraseña, string usuario){
        BD.CambiarContraseña(usuario,contraseña);
        return View("InicioSesion");
    }

}