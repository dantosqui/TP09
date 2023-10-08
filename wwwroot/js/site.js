function Checkear(){

    const checkcontra=checkcontraseña()
    const checkcoinci=checkcoincidencia()
    if (checkcontra && checkcoinci){
        document.getElementById("submitform").removeAttribute("disabled")
    }
    else{
        document.getElementById("submitform").setAttribute("disabled", "xd")
    }
}

function checkcontraseña(){
    const contra=document.getElementById("campocontraseña").value
    let valido
    valido=TieneMasDe8Caracteres(contra)
    valido=TieneCaracteresEspeciales(contra)&valido
    valido=TieneMayuscula(contra)&valido

        return valido;
       
}

function TieneCaracteresEspeciales(contra){
    const caracteresEspeciales='!#$%&/()=¡¿"|°¬@<>+}{-_.:,;~*^[]*'
    let i=0;
    let caracs=false;
    while(i<contra.length && !caracs){
        caracs=caracteresEspeciales.indexOf(contra[i])!==-1
        i++
    }

    const spancaracter=document.getElementById("caracterEspecial")
    if (caracs){
        spancaracter.style.color="green"
        return true;
    }
    else{
        spancaracter.style.color="red"
        return false;
    }
}
function TieneMasDe8Caracteres(contra){
    const spanlength=document.getElementById("largo")
    if (contra.length>8){
        
        spanlength.style.color="green"
        return true;
    }
    else{
        spanlength.style.color="red"
        return false;
    }
}
function TieneMayuscula(contra){
    const letras="qwertyuiopasdfghjklñzxcvbnmQWERTYUIOPASDFGHJKLÑZXCVBNM" 
    i=0
    caracs=false
    while(i<contra.length && !caracs){

        caracs=contra[i].toUpperCase()===contra[i] && letras.indexOf(contra[i])!==-1
        i++
    } 

    const spanmayus=document.getElementById("letraMayuscula")
    if (caracs){
        spanmayus.style.color="green"
        return true;
    }
    else{
        spanmayus.style.color="red"
        return false;
    }
}

function checkcoincidencia(){
    const contraseña1 = document.getElementById("campocontraseña").value
    const contraseña2 = document.getElementById("campocontraseña2").value
    const spancoinciden=document.getElementById("coinciden")
    if(contraseña1===contraseña2){
        spancoinciden.innerHTML="Las contraseñas coinciden"
        spancoinciden.style.color="green"
        
        return true;
    }
    else{
        spancoinciden.innerHTML="Las contraseñas no coinciden"
        spancoinciden.style.color="red"
        return false;
    }
}

