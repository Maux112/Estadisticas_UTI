namespace FrontEnd_UTI_Statistics.Models.Registro
{
    public class RgistrarInsert
    {
        public class RegistromodelFrontEnd
        {
            public int Sexo { get; set; }
            public int Edad { get; set; }
            public DateTime FechaIngreso { get; set; }
            public DateTime FechaEgreso { get; set; }
            public int OrigenIngreso { get; set; }
            public int CausaIngreso { get; set; }
            public int SubCausaIngreso { get; set; }
            public int ServicioEgreso { get; set; }
            public int CausaMortalidad { get; set; }
        }
    }
}
