using System.Runtime.Serialization;

namespace FrontEnd_UTI_Statistics.Models.Registro
{

    public class ListaRegistroResponseBd
    {
        public List<RegistroResponseBd> lista_usuarios { get; set; }
    }
    public class RegistroResponseBd
    {
        public int Sexo { get; set; }
        public int Edad { get; set; }
        public string FechaIngreso { get; set; }
        public string FechaEgreso { get; set; }
        public string EstanciaDias { get; set; }
        public string OrigenIngreso { get; set; }
        public string CausaIngreso { get; set; }
        public string SubCausaIngreso { get; set; }
        public string ServicioEgreso { get; set; }
        public string CausaMortalidad { get; set; }
    }


}
