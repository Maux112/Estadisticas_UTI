using FrontEnd_UTI_Statistics.BD.model;
using static FrontEnd_UTI_Statistics.BD.ExecutorSp;
using System.Data;
using static FrontEnd_UTI_Statistics.Models.Registro.RgistrarInsert;

namespace FrontEnd_UTI_Statistics.BD
{
    public class RegistrarBd
    {//Obtenemos la ruta de conexion con la BD
        private readonly static string _conexion = new ConexionBd().CadConexionUTI();

        #region Agregar Colaborador
        
        public static GeneralResponse InsertarRegistro(RegistromodelFrontEnd dtoReg)
        {
            try
            {
                StoreProcedure storeProcedure = new StoreProcedure("dbo.SP_INSERTAR_REGISTRO_INGRESO_UTI");
              
                storeProcedure.AgregarParametro("@SEXO_BIT", dtoReg.Sexo);
                storeProcedure.AgregarParametro("@EDAD_IN", dtoReg.Edad);
                storeProcedure.AgregarParametro("@FECHA_INGRESO_DT", dtoReg.FechaIngreso);
                storeProcedure.AgregarParametro("@FECHA_EGRESO_DT", dtoReg.FechaEgreso);
                storeProcedure.AgregarParametro("@OI_ID_IN", dtoReg.OrigenIngreso);
                storeProcedure.AgregarParametro("@CIN_ID_IN", dtoReg.CausaIngreso);
                storeProcedure.AgregarParametro("@SCIN_ID_IN", dtoReg.SubCausaIngreso);
                storeProcedure.AgregarParametro("@SE_ID_IN", dtoReg.ServicioEgreso);
                storeProcedure.AgregarParametro("@CM_ID_IN", dtoReg.CausaMortalidad);
                DataTable dataTable = storeProcedure.RealizarConsulta(_conexion);
                if (storeProcedure.Error.Length <= 0)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        //1 si da error
                        Int32 idColaborador = 1;
                        int i = 0;
                        foreach (DataRow row in dataTable.Rows)
                        {

                            idColaborador = Convert.ToInt32(dataTable.Rows[i]["Resultado"]);

                        }
                        return GeneralResponse.Success(idColaborador);
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
                return GeneralResponse.Exception(ex);
            }
        }
        #endregion
    }
}
