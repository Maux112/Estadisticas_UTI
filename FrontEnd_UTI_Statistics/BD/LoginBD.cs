using FrontEnd_UTI_Statistics.BD.model;
using static FrontEnd_UTI_Statistics.BD.ExecutorSp;
using System.Data;
using FrontEnd_UTI_Statistics.Models.Login;

namespace FrontEnd_UTI_Statistics.BD
{
    public class LoginBD
    {
        //Obtenemos la ruta de conexion con la BD
        private readonly static string _conexion = new ConexionBd().CadConexionUTI();

        #region Validacion de credenciales de usuario
        /// <summary>
        /// VALIDAMOS LAS CREDENCIALES DEL USUARIO PARA VER SI EXISTE O SI ESTA DESHABILITADO
        /// </summary>
        /// <param name="credenciales"></param>
        /// <returns></returns>
        public static GeneralResponse ValidaCredenciales(CredencialesUsuarioFrontEnd credenciales)
        {
            try
            {
                StoreProcedure storeProcedure = new StoreProcedure("dbo.ValidarCredenciales");
                storeProcedure.AgregarParametro("@nombreUsuario", credenciales.Usuario);
                storeProcedure.AgregarParametro("@contraseña", credenciales.Clave);
                DataTable dataTable = storeProcedure.RealizarConsulta(_conexion);
                if (dataTable.Rows.Count == 1)
                {
                    CredencialesUsuarioResponseBd validaCredenciales = new CredencialesUsuarioResponseBd();
                    int i = 0;
                    foreach (DataRow row in dataTable.Rows)
                    {
                        validaCredenciales.respuesta = Convert.ToInt32(dataTable.Rows[i]["Resultado"]);
                    }
                    return GeneralResponse.Success(validaCredenciales);
                }
                else
                {
                    //Logger.Error(storeProcedure.Error);
                    return GeneralResponse.Error("Sql Error");
                }
            }
            catch (Exception ex)
            {
                //Logger.Fatal(ex.Message);
                return GeneralResponse.Exception(ex);
            }
        }
        #endregion
    }
}
