using Microsoft.Data.SqlClient;
using System.Data;

namespace FrontEnd_UTI_Statistics.BD
{
    public class ExecutorSp
    {
        private string _mensajeError = String.Empty;
        private readonly List<StoreProcedure> _lote = new List<StoreProcedure>();

        public ExecutorSp()
        {
        }
        public List<StoreProcedure> Items
        {
            get { return _lote; }
        }
        public string Error
        {
            get { return _mensajeError; }
        }

        public class StoreProcedure
        {
            private string _nombreSp = String.Empty;
            private List<ParametrosSp> _lista = new List<ParametrosSp>();
            private string _mensajeError = String.Empty;

            public StoreProcedure(string nombreStoreProcedure)
            {
                this._nombreSp = nombreStoreProcedure;
            }

            public void AgregarParametro(string nombreParametro, object valorParametro)
            {
                _lista.Add(new ParametrosSp(nombreParametro, valorParametro));
            }

            public List<ParametrosSp> Items
            {
                get { return _lista; }
                set { _lista = value; }
            }

            public string NombreSp
            {
                get { return _nombreSp; }
                set { _nombreSp = value; }
            }

            public string Error
            {
                get { return _mensajeError; }
            }
            public DataTable RealizarConsulta(string cadenaConexion)
            {
                DataTable consulta = new DataTable();
                SqlConnection conexion = new SqlConnection(cadenaConexion);
                SqlDataAdapter comando = new SqlDataAdapter(_nombreSp, conexion);
                comando.SelectCommand.CommandType = CommandType.StoredProcedure;
                comando.SelectCommand.CommandTimeout = 60;
                for (int cont = 0; cont < _lista.Count; cont++)
                {
                    if (_lista[cont].ValorParametro == null)
                        comando.SelectCommand.Parameters.AddWithValue(_lista[cont].NombreParametro, DBNull.Value);
                    else
                        comando.SelectCommand.Parameters.AddWithValue(_lista[cont].NombreParametro, _lista[cont].ValorParametro);
                }
                try
                {
                    conexion.Open();
                    comando.Fill(consulta);
                    _mensajeError = String.Empty;
                }
                catch (SqlException error)
                {
                    //Logger.Error(error.Message);
                    _mensajeError = error.Message;
                    conexion.Close();
                    // SqlConnection.ClearAllPools();
                }
                finally
                {
                    conexion.Close();
                    // SqlConnection.ClearAllPools();
                }

                return consulta;
            }
        }

        public class ParametrosSp
        {
            private string _nombre = String.Empty;
            private object _valor = null;
            public ParametrosSp(string nombreParametro, object valorParametro)
            {
                this._nombre = nombreParametro;
                this._valor = valorParametro;
            }
            public string NombreParametro
            {
                get { return _nombre; }
                set { _nombre = value; }
            }
            public object ValorParametro
            {
                get { return _valor; }
                set { _valor = value; }
            }
        }
    }
}
