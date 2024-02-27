using FrontEnd_UTI_Statistics.BD.model;
using static FrontEnd_UTI_Statistics.BD.ExecutorSp;
using System.Data;
using FrontEnd_UTI_Statistics.Models.Registro;

namespace FrontEnd_UTI_Statistics.BD
{
    public class ListaRegistro
    {
        //Obtenemos la ruta de conexion con la BD
        private readonly static string _conexion = new ConexionBd().CadConexionUTI();

        #region Lista Registro
        /// <summary>
        /// Lista los usuarios con sus datos
        /// </summary>
        /// <returns></returns>
        public static GeneralResponse ListaUsuarios()
        {
            try
            {
                ListaRegistroResponseBd itemsList = new ListaRegistroResponseBd();
                List<RegistroResponseBd> ListaUsuarios = new List<RegistroResponseBd>();
                StoreProcedure storeProcedure = new StoreProcedure("dbo.SP_OBTENER_REGISTROS_INGRESO_UTI");
                DataTable dataTable = storeProcedure.RealizarConsulta(_conexion);

                if (storeProcedure.Error.Length <= 0)
                {

                    if (dataTable.Rows.Count > 0)
                    {

                        int i = 0;
                        foreach (DataRow row in dataTable.Rows)
                        {
                            RegistroResponseBd item = new RegistroResponseBd()
                            {
                                Sexo = Convert.ToInt32(dataTable.Rows[i]["REGIN_SEXO_BIT"]),
                                Edad = Convert.ToInt32(dataTable.Rows[i]["REGIN_EDAD_IN"]),
                                FechaIngreso = dataTable.Rows[i]["REGIN_FECHA_INGRESO_DT"].ToString(),
                                FechaEgreso = dataTable.Rows[i]["REGIN_FECHA_EGRESO_DT"].ToString(),
                                EstanciaDias = dataTable.Rows[i]["REGIN_ESTANCIA_DIAS_IN"].ToString(),
                                OrigenIngreso = dataTable.Rows[i]["OI_DESCRIPCION_VR"].ToString(),
                                CausaIngreso = dataTable.Rows[i]["CIN_DESCRIPCION_VR"].ToString(),
                                SubCausaIngreso = dataTable.Rows[i]["SCIN_DESCRIPCION_VR"].ToString(),
                                ServicioEgreso = dataTable.Rows[i]["SE_DESCRIPCION_VR"].ToString(),
                                CausaMortalidad = dataTable.Rows[i]["CM_DESCRIPCION_VR"].ToString(),                               
                            };
                            i++;
                            ListaUsuarios.Add(item);
                        }
                        itemsList.lista_usuarios = ListaUsuarios;

                        return GeneralResponse.Success(itemsList);
                    }
                    else
                    {
                        //Logger.Error(storeProcedure.Error);
                        return GeneralResponse.Error("Sql Error");
                    }
                }
                else
                {
                    return GeneralResponse.Error("Sp Error");
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
