using Microsoft.AspNetCore.Mvc;

namespace tp09.Controllers;

public class AccountController : Controller
{

    public IActionResult InicioSesion(){
        return View();
    }

    
    public IActionResult ContraseñaOlvidada(){
        ViewBag.error=false;
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
    
    public IActionResult CambiarContraseña(string contraseña, string usuario){
        int resultado=BD.CambiarContraseña(usuario,contraseña);
        if (resultado==1){
        return View("InicioSesion");}
        else{
            ViewBag.error=true;
            return View("ContraseñaOlvidada");
        }
    }

    public IActionResult Registrarse(){
        return View();
    }

    public IActionResult Registro(string usuario, string contraseña, string email, string fechanacimiento, char sexo, string fotoperfil){
        BD.Registro(usuario,contraseña,email,fechanacimiento,sexo,fotoperfil);
        return View("Registrado");
    }

    

}