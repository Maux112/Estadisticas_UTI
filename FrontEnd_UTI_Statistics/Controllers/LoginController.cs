using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using FrontEnd_UTI_Statistics.Models.Login;
using FrontEnd_UTI_Statistics.Managers;

namespace FrontEnd_UTI_Statistics.Controllers

{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// Este es el inicio de sesion se modificó para usar la autenticacion de microsoft
        /// mediante cookies
        /// </summary>
        /// <param name="credenciales"></param>
        /// <returns>La autenticacion en coocies ver Program.cs para configurar</returns>
        [HttpPost]
        public async Task<IActionResult> Login(CredencialesUsuarioFrontEnd credenciales)
        {
            try
            {
                string usuario = credenciales.Usuario;
                string pass = credenciales.Clave;


                //Llamo a la interfaz
                //DatosUsuarioFrontEnd respuestaManager = this.inicioSessionFrontEnd.InicioSesion(credenciales);
                //Establezco como variable la direccion del controller
                string urlDestino = "/Registro/ListaRegistros";

                CredencialesUsuarioResponseBd loginresponse =LoginManager.ValidaUsuario(credenciales);
                
                

                //Validamos si el usuario existe o esta deshabilitado
                if (loginresponse.respuesta==0)
                {
                    #region Aca añadimos datos que queremos guardar en las Cookies con claims
                    var claims = new List<Claim> {                  
                    new Claim("idUser" ,usuario)              
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                    #endregion

                    //Para devolver al js
                    var jsonResponse = new
                    {
                        success = true,
                        title = "Bienvenid@",
                        message = "",
                        icon = "success",
                        url = urlDestino
                    };
                    return Json(jsonResponse);
                }
                else
                {
                    //Para devolver al js
                    var jsonResponse = new
                    {
                        success = false,
                        title = "Error",
                        message = "Usuario no válido",
                        icon = "error",
                        url = ""
                    };
                    return Json(jsonResponse);
                }

            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    success = false,
                    title = "Error",
                    message = "Ocurrió una exepcion durante el Inicio de sesión: " + ex.Message,
                    icon = "error",
                    url = ""
                };
                return Json(errorResponse);
            }
        }

        /// <summary>
        /// Aca cierro la sesion borrando las cookies, se lo llama de layout.cshtml en shared
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> CerrarSession()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Login");
        }
    }
}
