namespace FrontEnd_UTI_Statistics.BD.model
{
    public class GeneralResponse
    {
        /// <summary>
        /// Realizamos la declarancion del modelo
        /// </summary>
        public int State { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public object Exceptions { get; set; }

        /// <summary>
        /// Metodo general para cuando todo es correcto
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Retorna un objeto</returns>
        public static GeneralResponse Success(object data)
        {
            GeneralResponse res = new GeneralResponse
            {
                State = 0,
                Message = "Response_OK",
                Data = data,
                Exceptions = null
            };
            return res;
        }
        /// <summary>
        /// Metodo general para que devuelva la excepcio
        /// </summary>
        /// <param name="data"></param>
        /// <returns>la exepcion</returns>
        public static GeneralResponse Exception(object data)
        {
            GeneralResponse res = new GeneralResponse
            {
                State = 1,
                Message = "Ocurrio una exepcion",
                Data = null,
                Exceptions = data
            };
            return res;
        }
        /// <summary>
        /// Este error es para especificarlo al momento de llamar solo tiene un nombre de error
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static GeneralResponse Error(string data)
        {
            GeneralResponse res = new GeneralResponse
            {
                State = 2,
                Message = data,
                Data = null,
                Exceptions = null
            };
            return res;
        }
    }
}
