using Microsoft.AspNetCore.Mvc;

namespace tp09.Controllers;

public class AccountController : Controller
{

    public IActionResult InicioSesion(){
        return View();
    }

    
    public IActionResult ContraseñaOlvidada(){
        ViewBag.error=false;
        ViewBag.Preguntas=BD.ListarPreguntas();
        return View();
    }
    
    public IActionResult Login(string usuario,string contraseña){
        bool correcto = BD.Login(usuario,contraseña);
        if (correcto){
            Usuarios user = BD.GetUsuario(usuario);
            ViewBag.Usuario=user;
            return View("PaginaInicio");
        }

        else{
            ViewBag.ErrorInicio="Contraseña o usuario incorrectos. Intente otra vez.";
            
            return View("InicioSesion");
        }
    }
    
    public IActionResult CambiarContraseña(string contraseña, string usuario, int idpregunta, string respuesta){
        int rta=BD.ValidarPregunta(idpregunta,respuesta,usuario);
        int resultado=BD.CambiarContraseña(usuario,contraseña);
        if (resultado==1 && rta==1){
        return View("InicioSesion");}
        else{
            ViewBag.error=true;
            ViewBag.Preguntas=BD.ListarPreguntas();
            return View("ContraseñaOlvidada");
        }
    }

    public IActionResult Registrarse(){
        ViewBag.Preguntas=BD.ListarPreguntas();
        return View();

    }

    public IActionResult Registro(string usuario, string contraseña, string email, string fechanacimiento, char sexo, string fotoperfil,int idpregunta,string respuesta){
        BD.Registro(usuario,contraseña,email,fechanacimiento,sexo,fotoperfil,idpregunta,respuesta);
        return View("Registrado");
    }



}