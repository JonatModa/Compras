//------------------------------------------------------mostrar icono de ojo mostrar contrase�a------------------------------------------------------------------------------------------------------------------------------------
function mostrar() {
    var tipo = document.getElementById("password");
    var tipo2 = document.getElementById("password2");
    
    if (tipo.type == 'password') {//va entrar cuando el tipo sea password para convertirlo en tipo texto 
        tipo.type = 'text';
        tipo2.type = 'text';
        document.getElementById('IDD').setAttribute('class', "bi bi-eye");//cambiamo el atributo a ojo mostrar por la ID de <i>
       
    }
    else {
        tipo.type = 'password';
        tipo2.type = 'password';
        document.getElementById('IDD').setAttribute('class', "bi bi-eye-slash"); //cambiar el valor de un atributo de javaScrip obtenemos por la ID del campo le estamos cambiando el tipo de class
       
    }
}

//------------------------------------------------------------ codigo para ver si coinciden las contrase�a---------------------------------------------------------------------------------------------------------------------------

//function verificarPasswords() {
//    // Ontenemos los valores de los campos de contrase�as 
//    pass1 = document.getElementById('password');
//    pass2 = document.getElementById('password2')

//     // Verificamos si las constrase�as no coinciden 
//    if (pass1.value != pass2.value) {

//        // Si las constrase�as no coinciden mostramos un mensaje 
//        document.getElementById("error").classList.add("mostrar");
//        const btncompra = document.getElementById('login');
//        btncompra.disabled = true;
//        return false;

//    }
//    else {
//        // Si las contrase�as coinciden ocultamos el mensaje de error
//        document.getElementById("error").classList.remove("mostrar");

//        // Mostramos un mensaje mencionando que las Contrase�as coinciden
//        document.getElementById("ok").classList.remove("ocultar");

//        // Desabilitamos el bot�n de login
//        const btncompra = document.getElementById('login');
//        btncompra.disabled = false;
//        /*document.getElementById("login").disabled = true;*/

//        return true;
//    }
//}

