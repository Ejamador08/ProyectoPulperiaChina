/// <reference path="Validaciones.js" />


function SoloNumeros() {
    if ((event.keyCode < 48) || (event.keyCode > 57))
        event.returnValue = false;
    

}

function SoloTexto() {
    if ((event.keyCode != 32) && (event.keyCode < 65) || (event.keyCode > 90) && (event.keyCode < 97) || (event.keyCode > 122))
        event.returnValue = false;

}



function EsoloNumeros(e) {
    key = e.KeyCode || e.which;
    t = String.fromCharCode(key);
    n = "0123456789";
    e = "8,37,38,46";
    tesp = false;
    for (var i in e) {
        if (key == e[i]) {
            tesp = true;
        }
    }

    if (n.indexOf(t) == -1 && !tesp) {
        return false;
    }
}

function vacio(q) { //la variable q contiene el valor del texbox

    for (i = 0; i < q.length; i++) { //la funcion q.length devuelve el tamaño de la palabra contenia por el textbox

        if (q.charAt(i) != " ") {//la funcion q.charAt nos deuelve el caracter contenido en la posicion i de la variable q

            return true

        }

    }

    return false;

}



//valida que el campo no este vacio y no tenga solo espacios en blanco

function valida(F) {



    if (vacio(F.campo.value) == false) {

        alert("Escriba su nombre");

        return false

    } else {

        alert("Gracias por su cooperacion");



        return true

    }

    //esta funcion recibe una palabra como parametro y verifica que todos los caracteres de la palabra sean caracteres validos.
    function ValidaCampo(campo) {

        var caracter

        var caracteres = "abcdefghijklmnopqrstuvwxyzñABCDEFGHIJKLMNOPQRSTUVWXYZÑáéíóúÁÉÍÓÚ" + String.fromCharCode(13)
        //en esta variable se guardaran todos los caracteres que pueden ser aceptados, la funcion String.fromCharCode(13) 
       // nos devuelve el caracter que en codigo se representa por un 13 en este caso el 13 representa un enter.



        var contador = 0

        for (var i = 0; i < campo.length; i++) {
            //creamos un ciclo para recorrer caracter por caracter la palabra contenida en la variable campo

            caracter = campo.substring(i, i + 1)
            //con la funcion substring obtenemos el caracter de la posicion i de la palabra a validar

            if (caracteres.indexOf(caracter) != -1) {
                //lo que hacemos aqui es buscar si el caracter contenido en la variable caracter se encuentra en la palabra caracteres,
                //esto a traves de la funcion indexOf la cual detecta si en una frase o cadena existe un valor o palabra identica. si es asi 
                //nos devuelve el indice que indica la pocicion donde lo encontro, si no lo encuentra nos manda un numero negativo.



                contador++

            } else {

                alert("ERROR: No se acepta el caracter '" + ubicacion + "'.")

                return false

            }

        }



        alert("Datos correctos.")

        return true

    }

}

function validarNumero(e) {
    var key;
    if (window.event) // IE
    {
        key = e.keyCode;
    }
    else if (e.which) // Netscape/Firefox/Opera
    {
        key = e.which;
    }

    if (key < 48 || key > 57) {
        return false;
    }
    return true;
}