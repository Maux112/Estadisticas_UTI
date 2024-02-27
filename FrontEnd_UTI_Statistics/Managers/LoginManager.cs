using Azure;
using FrontEnd_UTI_Statistics.BD;
using FrontEnd_UTI_Statistics.BD.model;
using FrontEnd_UTI_Statistics.Models.Login;
using Newtonsoft.Json;

namespace FrontEnd_UTI_Statistics.Managers
{
    public class LoginManager
    {
        #region Validacion de credenciales de ususario
        /// <summary>
        /// Valida el usuario y añade un mensaje de descripcion de respuesta
        /// </summary>
        /// <param name="credenciales"></param>
        /// <returns></returns>
        public static CredencialesUsuarioResponseBd ValidaUsuario(CredencialesUsuarioFrontEnd credenciales)
        {
            CredencialesUsuarioResponseBd response = new CredencialesUsuarioResponseBd();
            try
            {
                
                //Mando los datos a la BD
                var responsebd = LoginBD.ValidaCredenciales(credenciales);
               
                string jsonData = JsonConvert.SerializeObject(responsebd.Data);
                response = JsonConvert.DeserializeObject<CredencialesUsuarioResponseBd>(jsonData);               
                return response;
            }
            catch (Exception ex)
            {
                return response;
            }
        }
        #endregion
    }
}
