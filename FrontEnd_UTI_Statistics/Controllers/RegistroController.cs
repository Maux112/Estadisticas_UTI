using FrontEnd_UTI_Statistics.BD;
using FrontEnd_UTI_Statistics.Managers;
using FrontEnd_UTI_Statistics.Models.Registro;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static FrontEnd_UTI_Statistics.Models.Registro.RgistrarInsert;

namespace FrontEnd_UTI_Statistics.Controllers
{
    [Authorize]
    public class RegistroController : Controller
    {
      
        public IActionResult ListaRegistros()
        {
            //Obtenemos el valor del token
            
            ListaRegistroResponseBd listaUsuarios = RegistroManager.ListaRegistros();
            if (listaUsuarios == null)
            {
                listaUsuarios=new ListaRegistroResponseBd();
            }

            return View(listaUsuarios);
           // return View();
        }



        #region Registrar Usuario

        [HttpPost]
        public IActionResult InsertarRegistro(RegistromodelFrontEnd registrarUsr)
        {
            try
            {

                string urlDestino = "/Registro/ListaRegistros";
                bool respRegistrarUsr = RegistroManager.InsertarRegistro(registrarUsr);
                if (respRegistrarUsr)
                {
                    //Para devolver al js
                    var jsonResponse = new
                    {
                        success = true,
                        title = "Éxito",
                        message = "El usuario se registro correctamente.",
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
                        message = "Ocurrio un error al registrar Usuario.",
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
                    message = "Ocurrió una exepcion durante el Cambio de estado: " + ex.Message,
                    icon = "error",
                    url = ""
                };
                return Json(errorResponse);
            }
        }
        #endregion
    }
}
