// Espera a que el documento esté completamente cargado
document.addEventListener('DOMContentLoaded', function () {
    $('form').submit(function (e) {
        e.preventDefault(); // Prevenir el envío predeterminado del formulario
        //alert("dasd");
        var nombreUsuario = $('#loginUsuario').val();
        var claveUsuario = $('#loginClave').val();


        var dtoUsrLogin = {
            Usuario: nombreUsuario,
            Clave: claveUsuario,
        };
        $.ajax({
            url: '/Login/Login',
            type: "post",
            dataType: "json",
            data: dtoUsrLogin,
            success: function (responseLogin) {

                if (responseLogin.success) {
                    Swal.fire({
                        title: responseLogin.title,
                        text: responseLogin.message,
                        icon: responseLogin.icon
                    }).then((result) => {
                        if (result.isConfirmed) {
                            window.location.href = responseLogin.url; // Redirige a la URL proporcionada por el servidor
                        }
                    });
                }
                else {
                    // Manejar la respuesta del servidor, por ejemplo:
                    Swal.fire({
                        title: responseLogin.title,
                        text: responseLogin.message,
                        icon: responseLogin.icon
                    });
                }

            },
            error: function (error) {
                // Mostrar mensaje de error al usuario
                Swal.fire({
                    title: "Error",
                    text: "Error js: " + error,
                    icon: "error"
                });
                console.log(error);
            }
        });
        // Resto del código para procesar la información del formulario...
    });








    const passwordInput = document.getElementById('loginClave');
    const showPasswordButton = document.getElementById('muestraClave');
    const eyeCloseIcon = `
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="#F2E9E4" class="bi bi-eye-slash-fill" viewBox="0 0 16 16">
                    <path d="m10.79 12.912-1.614-1.615a3.5 3.5 0 0 1-4.474-4.474l-2.06-2.06C.938 6.278 0 8 0 8s3 5.5 8 5.5a7.029 7.029 0 0 0 2.79-.588zM5.21 3.088A7.028 7.028 0 0 1 8 2.5c5 0 8 5.5 8 5.5s-.939 1.721-2.641 3.238l-2.062-2.062a3.5 3.5 0 0 0-4.474-4.474L5.21 3.089z" />
                    <path d="M5.525 7.646a2.5 2.5 0 0 0 2.829 2.829l-2.83-2.829zm4.95.708-2.829-2.83a2.5 2.5 0 0 1 2.829 2.829zm3.171 6-12-12 .708-.708 12 12-.708.708z" />
                </svg>`;
    const eyeIcon = `<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="#F2E9E4" class="bi bi-eye-fill" viewBox="0 0 16 16">
          <path d="M10.5 8a2.5 2.5 0 1 1-5 0 2.5 2.5 0 0 1 5 0z"/>
          <path d="M0 8s3-5.5 8-5.5S16 8 16 8s-3 5.5-8 5.5S0 8 0 8zm8 3.5a3.5 3.5 0 1 0 0-7 3.5 3.5 0 0 0 0 7z"/>
        </svg>`;
    showPasswordButton.addEventListener('click', () => {
        if (passwordInput.value.trim() !== '') { // Verificar si el campo no está vacío
            if (passwordInput.type === 'password') {
                passwordInput.type = 'text';
                showPasswordButton.innerHTML = eyeIcon;
                passwordInput.stylefontFamily = 'sans-serif';
            } else {
                passwordInput.type = 'password';
                passwordInput.stylefontFamily = 'sans-serif';
                showPasswordButton.innerHTML = eyeCloseIcon;
            }
        }
    });
});


