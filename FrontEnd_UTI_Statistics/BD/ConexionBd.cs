using Microsoft.Data.SqlClient;
namespace FrontEnd_UTI_Statistics.BD
{
    public class ConexionBd
    {
        public string CadConexionUTI()
        {
            string strRespuesta = String.Empty;
            try
            {
                string cnnServer = "BD_UTI_STATISTICS.mssql.somee.com";
                string cnnDatabase = "BD_UTI_STATISTICS";
                string cnnUser = "Mauro112_SQLLogin_1";
                string cnnPass = "hldjkcd6d4";
                strRespuesta = "Persist Security Info=True;User ID=" + cnnUser + ";Pwd=" + cnnPass + ";Server=" + cnnServer + ";Database=" + cnnDatabase + ";TrustServerCertificate = True;";



                //string cnnServer = ".";
                //string cnnDatabase = "BD_UTI_STATISTICS";
                //strRespuesta = "Persist Security Info=True;Integrated Security=True;Server=" + cnnServer + ";Database=" + cnnDatabase + ";TrustServerCertificate=True;";

            }
            catch (SqlException ex)
            {
                // Manejo de excepciones específicas de SQL Server
                strRespuesta = "Error de SQL Server: " + ex.Message;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones generales
                strRespuesta = "Error general: " + ex.Message;
            }
            return strRespuesta;
        }
    }
}
