function mostrar() {
    var tipo = document.getElementById("password");
    

    if (tipo.type == 'password') {//va entrar cuando el tipo sea password para convertirlo en tipo texto 
        tipo.type = 'text';
        
        document.getElementById('IDD').setAttribute('class', "bi bi-eye");//cambiamo el atributo a ojo mostrar por la ID de <i>

    }
    else {
        tipo.type = 'password';
        
        document.getElementById('IDD').setAttribute('class', "bi bi-eye-slash"); //cambiar el valor de un atributo de javaScrip obtenemos por la ID del campo le estamos cambiando el tipo de class

    }
}