
$(document).ready(function () {
    $("#IniciarSesion").on("submit", function (event) {
        // Prevenir el envío del formulario por defecto
        event.preventDefault();
        $("#ErrorMensaje").html("");
        if (ValidateForm()) {

            const _modelo = {
                Password: $("#txPassword").val(),
                Usuario: $("#txUsuario").val(),
            };

            fetch("/Administracion/Login/IniciarSesion", {
                method: "POST",
                headers: { "Content-Type": "application/json; charset=utf-8" },
                body: JSON.stringify(_modelo)
            })
                .then(res => res.json())
                .then(res => {

                    if (res.usuario.id == -1) {
                        $("#ErrorMensaje").html("Usuario no encontrado");
                    } else if (res.usuario.id == 0) {
                        $("#ErrorMensaje").html("Password incorrecto");
                    } else {
                        if (res.usuario.cat_Rol.id == 1) {
                            window.location.href = '/Operacion/Captura';
                        } else {
                            $("#ErrorMensaje").html("Perfil no encontrado");
                        } 
                    }
                });
        } else {
            $("#ErrorMensaje").html("Completa los campos marcados");
        }
        
    });
});

function ValidateForm() {
    var result = false;
    $('#txPassword').css("border", "2px solid #e91e63");
    $('#txUsuario').css("border", "2px solid #e91e63");

    if ($('#txPassword').val().length > 0) {
        $('#txPassword').css("border", "0px");

        if ($('#txUsuario').val().length > 0) {
            $('#txUsuario').css("border", "0px");
            result = true;
        }
    } 

    return result;
}

function ValidaInput(Id) {
    if ($('#' + Id).val().length > 0) {
        $('#' + Id).css("border", "0px");
    } else {
        $('#' + Id).css("border", "1px solid red");
    }
}
