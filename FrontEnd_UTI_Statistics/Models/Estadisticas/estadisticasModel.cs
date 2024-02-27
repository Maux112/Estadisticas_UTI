namespace FrontEnd_UTI_Statistics.Models.Estadisticas
{
    public class estadisticasModel
    {
        #region ingresos
        //Promedio de ingresos mensuales
        public int Ingresos_totales { get; set; }
        public int contador2019 { get; set; }
        public int contador2020 { get; set; }
        public int contador2021 { get; set; }
        public int contador2022 { get; set; }
        public int contador2023 { get; set; }

        //porcentajes
        public double porcentajeIngresos2019 { get; set; }
        public double porcentajeIngresos2020 { get; set; }
        public double porcentajeIngresos2021 { get; set; }
        public double porcentajeIngresos2022 { get; set; }
        public double porcentajeIngresos2023 { get; set; }

        // Calcular promedio por año
        public double promedioIngresos2019 { get; set; }
        public double promedioIngresos2020 { get; set; }
        public double promedioIngresos2021 { get; set; }
        public double promedioIngresos2022 { get; set; }
        public double promedioIngresos2023 { get; set; }
        #endregion

        #region sexo
        //Porcentaje de varones y mujeres 
        public int contadorSexFemTotal { get; set; }
        public int contadorSexMasTotal { get; set; }

        public int contadorSex2019f { get; set; }
        public int contadorSex2020f { get; set; }
        public int contadorSex2021f { get; set; }
        public int contadorSex2022f { get; set; }
        public int contadorSex2023f { get; set; }


        public int contadorSex2019m { get; set; }
        public int contadorSex2020m { get; set; }
        public int contadorSex2021m { get; set; }
        public int contadorSex2022m { get; set; }
        public int contadorSex2023m { get; set; }

        public int totalSex { get; set; }
        //porcentaje Global
        public double porcentajeallf { get; set; }
        public double porcentajeallm { get; set; }

        // Calcular el total de cada año por sexo
        public int total2019 { get; set; }
        public int total2020 { get; set; }
        public int total2021 { get; set; }
        public int total2022 { get; set; }
        public int total2023 { get; set; }

        // Calcular el porcentaje para cada año
        public double porcentaje2019f { get; set; }
        public double porcentaje2019m { get; set; }

        public double porcentaje2020f { get; set; }
        public double porcentaje2020m { get; set; }

        public double porcentaje2021f { get; set; }
        public double porcentaje2021m { get; set; }

        public double porcentaje2022f { get; set; }
        public double porcentaje2022m { get; set; }

        public double porcentaje2023f { get; set; }
        public double porcentaje2023m { get; set; }
        #endregion

        #region Edad
        public int moda2019Edad { get; set; }
        public double media2019Edad { get; set; }
        public double promedi2019Edad { get; set; }

        public int moda2020Edad { get; set; }
        public double media2020Edad { get; set; }
        public double promedi2020Edad { get; set; }

        public int moda2021Edad { get; set; }
        public double media2021Edad { get; set; }
        public double promedi2021Edad { get; set; }

        public int moda2022Edad { get; set; }
        public double media2022Edad { get; set; }
        public double promedi2022Edad { get; set; }

        public int moda2023Edad { get; set; }
        public double media2023Edad { get; set; }
        public double promedi2023Edad { get; set; }
        //Para la discriminacion de edad
        public int Menores30anos2019 { get; set; }
        public int Adultos30_59anos2019 { get; set; }
        public int Mayoresde60anos2019 { get; set; }

        public int Menores30anos2020 { get; set; }
        public int Adultos30_59anos2020 { get; set; }
        public int Mayoresde60anos2020 { get; set; }

        public int Menores30anos2021 { get; set; }
        public int Adultos30_59anos2021 { get; set; }
        public int Mayoresde60anos2021 { get; set; }

        public int Menores30anos2022 { get; set; }
        public int Adultos30_59anos2022 { get; set; }
        public int Mayoresde60anos2022 { get; set; }

        public int Menores30anos2023 { get; set; }
        public int Adultos30_59anos2023 { get; set; }
        public int Mayoresde60anos2023 { get; set; }

        public int totalEdad2019 { get; set; }
        public double porcentajeMenores30anos2019 { get; set; }
        public double porcentajeAdultos30_59anos2019 { get; set; }
        public double porcentajeMayoresde60anos2019 { get; set; }


        public int totalEdad2020 { get; set; }
        public double porcentajeMenores30anos2020 { get; set; }
        public double porcentajeAdultos30_59anos2020 { get; set; }
        public double porcentajeMayoresde60anos2020 { get; set; }


        public int totalEdad2021 { get; set; }
        public double porcentajeMenores30anos2021 { get; set; }
        public double porcentajeAdultos30_59anos2021 { get; set; }
        public double porcentajeMayoresde60anos2021 { get; set; }


        public int totalEdad2022 { get; set; }
        public double porcentajeMenores30anos2022 { get; set; }
        public double porcentajeAdultos30_59anos2022 { get; set; }
        public double porcentajeMayoresde60anos2022 { get; set; }

        public int totalEdad2023 { get; set; }
        public double porcentajeMenores30anos2023 { get; set; }
        public double porcentajeAdultos30_59anos2023 { get; set; }
        public double porcentajeMayoresde60anos2023 { get; set; }


        //global
        public int totalEdadGlobal { get; set; }

        public int Menores30anosGlobal { get; set; }
        public int Adultos30_59anosGlobal { get; set; }
        public int Mayoresde60anosGlobal { get; set; }

        public double porcentajeMenores30anosGlobal { get; set; }
        public double porcentajeAdultos30_59anosGlobal { get; set; }
        public double porcentajeMayoresde60anosGlobal { get; set; }


        #endregion

        #region Dias Inter
        public int moda2019EstDias { get; set; }
        public double media2019EstDias { get; set; }
        public double promedi2019EstDias { get; set; }

        public int moda2020EstDias { get; set; }
        public double media2020EstDias { get; set; }
        public double promedi2020EstDias { get; set; }

        public int moda2021EstDias { get; set; }
        public double media2021EstDias { get; set; }
        public double promedi2021EstDias { get; set; }

        public int moda2022EstDias { get; set; }
        public double media2022EstDias { get; set; }
        public double promedi2022EstDias { get; set; }

        public int moda2023EstDias { get; set; }
        public double media2023EstDias { get; set; }
        public double promedi2023EstDias { get; set; }
        #endregion

        #region Origen Ingresos
        public int oicontEmergencias2019 { get; set; }
        public int oicontQuirofano2019 { get; set; }
        public int oicontSalacomun2019 { get; set; }
        public int oicontTransferenciadeotraUTI2019 { get; set; }
        public int oicontOtros2019 { get; set; }

        public int oicontEmergencias2020 { get; set; }
        public int oicontQuirofano2020 { get; set; }
        public int oicontSalacomun2020 { get; set; }
        public int oicontTransferenciadeotraUTI2020 { get; set; }
        public int oicontOtros2020 { get; set; }

        public int oicontEmergencias2021 { get; set; }
        public int oicontQuirofano2021 { get; set; }
        public int oicontSalacomun2021 { get; set; }
        public int oicontTransferenciadeotraUTI2021 { get; set; }
        public int oicontOtros2021 { get; set; }

        public int oicontEmergencias2022 { get; set; }
        public int oicontQuirofano2022 { get; set; }
        public int oicontSalacomun2022 { get; set; }
        public int oicontTransferenciadeotraUTI2022 { get; set; }
        public int oicontOtros2022 { get; set; }

        public int oicontEmergencias2023 { get; set; }
        public int oicontQuirofano2023 { get; set; }
        public int oicontSalacomun2023 { get; set; }
        public int oicontTransferenciadeotraUTI2023 { get; set; }
        public int oicontOtros2023 { get; set; }


        // Contadores globales
        public int totalGlobalEmergencias { get; set; }
        public int totalGlobalQuirofano { get; set; }
        public int totalGlobalSalaComun { get; set; }
        public int totalGlobalTransferenciaOtraUTI { get; set; }
        public int totalGlobalOtros { get; set; }



        public int TotalGlobal { get; set; }

        public double porcentajeEmergencias { get; set; }
        public double porcentajeQuirofano { get; set; }
        public double porcentajeSalaComun { get; set; }
        public double porcentajeTransferenciaOtraUTI { get; set; }
        public double porcentajeOtros { get; set; }

        //Individuales
        public int totaOI2019 { get; set; }
        public double porcentajeEmergencias2019 { get; set; }
        public double porcentajeQuirofano2019 { get; set; }
        public double porcentajeSalaComun2019 { get; set; }
        public double porcentajeTransferenciaOtraUTI2019 { get; set; }
        public double porcentajeOtros2019 { get; set; }

        public int totaOI2020 { get; set; }
        public double porcentajeEmergencias2020 { get; set; }
        public double porcentajeQuirofano2020 { get; set; }
        public double porcentajeSalaComun2020 { get; set; }
        public double porcentajeTransferenciaOtraUTI2020 { get; set; }
        public double porcentajeOtros2020 { get; set; }

        public int totaOI2021 { get; set; }
        public double porcentajeEmergencias2021 { get; set; }
        public double porcentajeQuirofano2021 { get; set; }
        public double porcentajeSalaComun2021 { get; set; }
        public double porcentajeTransferenciaOtraUTI2021 { get; set; }
        public double porcentajeOtros2021 { get; set; }

        public int totaOI2022 { get; set; }
        public double porcentajeEmergencias2022 { get; set; }
        public double porcentajeQuirofano2022 { get; set; }
        public double porcentajeSalaComun2022 { get; set; }
        public double porcentajeTransferenciaOtraUTI2022 { get; set; }
        public double porcentajeOtros2022 { get; set; }

        public int totaOI2023 { get; set; }
        public double porcentajeEmergencias2023 { get; set; }
        public double porcentajeQuirofano2023 { get; set; }
        public double porcentajeSalaComun2023 { get; set; }
        public double porcentajeTransferenciaOtraUTI2023 { get; set; }
        public double porcentajeOtros2023 { get; set; }

        #endregion

        #region Causa Ingreso
        public int cicontNeurologico2019 { get; set; }
        public int cicontRespiratorio2019 { get; set; }
        public int cicontCardiovascular2019 { get; set; }
        public int cicontGastrointestinal2019 { get; set; }
        public int cicontRenalEndocrinologico2019 { get; set; }
        public int cicontOtros2019 { get; set; }

        public int cicontNeurologico2020 { get; set; }
        public int cicontRespiratorio2020 { get; set; }
        public int cicontCardiovascular2020 { get; set; }
        public int cicontGastrointestinal2020 { get; set; }
        public int cicontRenalEndocrinologico2020 { get; set; }
        public int cicontOtros2020 { get; set; }

        public int cicontNeurologico2021 { get; set; }
        public int cicontRespiratorio2021 { get; set; }
        public int cicontCardiovascular2021 { get; set; }
        public int cicontGastrointestinal2021 { get; set; }
        public int cicontRenalEndocrinologico2021 { get; set; }
        public int cicontOtros2021 { get; set; }

        public int cicontNeurologico2022 { get; set; }
        public int cicontRespiratorio2022 { get; set; }
        public int cicontCardiovascular2022 { get; set; }
        public int cicontGastrointestinal2022 { get; set; }
        public int cicontRenalEndocrinologico2022 { get; set; }
        public int cicontOtros2022 { get; set; }

        public int cicontNeurologico2023 { get; set; }
        public int cicontRespiratorio2023 { get; set; }
        public int cicontCardiovascular2023 { get; set; }
        public int cicontGastrointestinal2023 { get; set; }
        public int cicontRenalEndocrinologico2023 { get; set; }
        public int cicontOtros2023 { get; set; }


        //NeurolOgico 2019
        public int subNcicontTEC2019 { get; set; }
        public int subNcicontAVC2019 { get; set; }
        public int subNcicontEpilepsia2019 { get; set; }
        public int subNcicontMeningitis2019 { get; set; }
        public int subNcicontOtros2019 { get; set; }

        //Respiratorio 2019
        public int subResciChoqueSeptico_Neumonia2019 { get; set; }
        public int subResciTEP2019 { get; set; }
        public int subResciEAP2019 { get; set; }
        public int subResciAsma_EPOC2019 { get; set; }
        public int subResciOtros2019 { get; set; }

        //Cardiovascular 2019
        public int subCarciChoqueCardiogenico2019 { get; set; }
        public int subCarciPostOperadoCirugiaCardiaca2019 { get; set; }
        public int subCarciTaquiarritmiaBradiarritmia2019 { get; set; }
        public int subCarciCrisisHipertensivas2019 { get; set; }
        public int subCarciPostParo2019 { get; set; }
        public int subCarciOtros2019 { get; set; }

        //Gastrointestinal 2019
        public int subGasciPancreatitisAguda2019 { get; set; }
        public int subGasciHemorragiaDigestiva2019 { get; set; }
        public int subGasciPostOperadosComplicados2019 { get; set; }
        public int subGasciOtros2019 { get; set; }







        //NeurolOgico 2020
        public int subNcicontTEC2020 { get; set; }
        public int subNcicontAVC2020 { get; set; }
        public int subNcicontEpilepsia2020 { get; set; }
        public int subNcicontMeningitis2020 { get; set; }
        public int subNcicontOtros2020 { get; set; }


        //Respiratorio 2020
        public int subResciChoqueSeptico_Neumonia2020 { get; set; }
        public int subResciTEP2020 { get; set; }
        public int subResciEAP2020 { get; set; }
        public int subResciAsma_EPOC2020 { get; set; }
        public int subResciOtros2020 { get; set; }

        //Cardiovascular 2020
        public int subCarciChoqueCardiogenico2020 { get; set; }
        public int subCarciPostOperadoCirugiaCardiaca2020 { get; set; }
        public int subCarciTaquiarritmiaBradiarritmia2020 { get; set; }
        public int subCarciCrisisHipertensivas2020 { get; set; }
        public int subCarciPostParo2020 { get; set; }
        public int subCarciOtros2020 { get; set; }

        //Gastrointestinal 2020
        public int subGasciPancreatitisAguda2020 { get; set; }
        public int subGasciHemorragiaDigestiva2020 { get; set; }
        public int subGasciPostOperadosComplicados2020 { get; set; }
        public int subGasciOtros2020 { get; set; }



        //NeurolOgico 2021
        public int subNcicontTEC2021 { get; set; }
        public int subNcicontAVC2021 { get; set; }
        public int subNcicontEpilepsia2021 { get; set; }
        public int subNcicontMeningitis2021 { get; set; }
        public int subNcicontOtros2021 { get; set; }

        //Respiratorio 2021
        public int subResciChoqueSeptico_Neumonia2021 { get; set; }
        public int subResciTEP2021 { get; set; }
        public int subResciEAP2021 { get; set; }
        public int subResciAsma_EPOC2021 { get; set; }
        public int subResciOtros2021 { get; set; }

        //Cardiovascular 2021
        public int subCarciChoqueCardiogenico2021 { get; set; }
        public int subCarciPostOperadoCirugiaCardiaca2021 { get; set; }
        public int subCarciTaquiarritmiaBradiarritmia2021 { get; set; }
        public int subCarciCrisisHipertensivas2021 { get; set; }
        public int subCarciPostParo2021 { get; set; }
        public int subCarciOtros2021 { get; set; }

        //Gastrointestinal 2021
        public int subGasciPancreatitisAguda2021 { get; set; }
        public int subGasciHemorragiaDigestiva2021 { get; set; }
        public int subGasciPostOperadosComplicados2021 { get; set; }
        public int subGasciOtros2021 { get; set; }


        //NeurolOgico 2022
        public int subNcicontTEC2022 { get; set; }
        public int subNcicontAVC2022 { get; set; }
        public int subNcicontEpilepsia2022 { get; set; }
        public int subNcicontMeningitis2022 { get; set; }
        public int subNcicontOtros2022 { get; set; }

        //Respiratorio 2022
        public int subResciChoqueSeptico_Neumonia2022 { get; set; }
        public int subResciTEP2022 { get; set; }
        public int subResciEAP2022 { get; set; }
        public int subResciAsma_EPOC2022 { get; set; }
        public int subResciOtros2022 { get; set; }

        //Cardiovascular 2022
        public int subCarciChoqueCardiogenico2022 { get; set; }
        public int subCarciPostOperadoCirugiaCardiaca2022 { get; set; }
        public int subCarciTaquiarritmiaBradiarritmia2022 { get; set; }
        public int subCarciCrisisHipertensivas2022 { get; set; }
        public int subCarciPostParo2022 { get; set; }
        public int subCarciOtros2022 { get; set; }

        //Gastrointestinal 2022
        public int subGasciPancreatitisAguda2022 { get; set; }
        public int subGasciHemorragiaDigestiva2022 { get; set; }
        public int subGasciPostOperadosComplicados2022 { get; set; }
        public int subGasciOtros2022 { get; set; }

        //NeurolOgico 2023
        public int subNcicontTEC2023 { get; set; }
        public int subNcicontAVC2023 { get; set; }
        public int subNcicontEpilepsia2023 { get; set; }
        public int subNcicontMeningitis2023 { get; set; }
        public int subNcicontOtros2023 { get; set; }

        //Respiratorio 2023
        public int subResciChoqueSeptico_Neumonia2023 { get; set; }
        public int subResciTEP2023 { get; set; }
        public int subResciEAP2023 { get; set; }
        public int subResciAsma_EPOC2023 { get; set; }
        public int subResciOtros2023 { get; set; }

        //Cardiovascular 2023
        public int subCarciChoqueCardiogenico2023 { get; set; }
        public int subCarciPostOperadoCirugiaCardiaca2023 { get; set; }
        public int subCarciTaquiarritmiaBradiarritmia2023 { get; set; }
        public int subCarciCrisisHipertensivas2023 { get; set; }
        public int subCarciPostParo2023 { get; set; }
        public int subCarciOtros2023 { get; set; }

        //Gastrointestinal 2023
        public int subGasciPancreatitisAguda2023 { get; set; }
        public int subGasciHemorragiaDigestiva2023 { get; set; }
        public int subGasciPostOperadosComplicados2023 { get; set; }
        public int subGasciOtros2023 { get; set; }


        //Global Categorias
        public int cicontNeurologicoTotal { get; set; }
        public int cicontRespiratorioTotal { get; set; }
        public int cicontCardiovascularTotal { get; set; }
        public int cicontGastrointestinalTotal { get; set; }
        public int cicontRenalEndocrinologicoTotal { get; set; }
        public int cicontOtrosTotal { get; set; }

        public int ciTotalCategoria { get; set; }
        public double ciporcentajecicontNeurologicoTotal { get; set; }
        public double ciporcentajecicontRespiratorioTotal { get; set; }
        public double ciporcentajecicontCardiovascularTotal { get; set; }
        public double ciporcentajecicontGastrointestinalTotal { get; set; }
        public double ciporcentajecicontRenalEndocrinologicoTotal { get; set; }
        public double ciporcentajecicontOtrosTotal { get; set; }

        //Categorias por año

        public int totaCI2019 { get; set; }
        public double ciporcentajecicontNeurologico2019 { get; set; }
        public double ciporcentajecicontRespiratorio2019 { get; set; }
        public double ciporcentajecicontCardiovascular2019 { get; set; }
        public double ciporcentajecicontGastrointestinal2019 { get; set; }
        public double ciporcentajecicontRenalEndocrinologico2019 { get; set; }
        public double ciporcentajecicontOtros2019 { get; set; }


        public int totaCI2020 { get; set; }
        public double ciporcentajecicontNeurologico2020 { get; set; }
        public double ciporcentajecicontRespiratorio2020 { get; set; }
        public double ciporcentajecicontCardiovascular2020 { get; set; }
        public double ciporcentajecicontGastrointestinal2020 { get; set; }
        public double ciporcentajecicontRenalEndocrinologico2020 { get; set; }
        public double ciporcentajecicontOtros2020 { get; set; }

        public int totaCI2021 { get; set; }
        public double ciporcentajecicontNeurologico2021 { get; set; }
        public double ciporcentajecicontRespiratorio2021 { get; set; }
        public double ciporcentajecicontCardiovascular2021 { get; set; }
        public double ciporcentajecicontGastrointestinal2021 { get; set; }
        public double ciporcentajecicontRenalEndocrinologico2021 { get; set; }
        public double ciporcentajecicontOtros2021 { get; set; }

        public int totaCI2022 { get; set; }
        public double ciporcentajecicontNeurologico2022 { get; set; }
        public double ciporcentajecicontRespiratorio2022 { get; set; }
        public double ciporcentajecicontCardiovascular2022 { get; set; }
        public double ciporcentajecicontGastrointestinal2022 { get; set; }
        public double ciporcentajecicontRenalEndocrinologico2022 { get; set; }
        public double ciporcentajecicontOtros2022 { get; set; }

        public int totaCI2023 { get; set; }
        public double ciporcentajecicontNeurologico2023 { get; set; }
        public double ciporcentajecicontRespiratorio2023 { get; set; }
        public double ciporcentajecicontCardiovascular2023 { get; set; }
        public double ciporcentajecicontGastrointestinal2023 { get; set; }
        public double ciporcentajecicontRenalEndocrinologico2023 { get; set; }
        public double ciporcentajecicontOtros2023 { get; set; }


        //Subcategorias Global

        //NeurolOgico Total
        public int subNcicontTECTotal { get; set; }
        public int subNcicontAVCTotal { get; set; }
        public int subNcicontEpilepsiaTotal { get; set; }
        public int subNcicontMeningitisTotal { get; set; }
        public int subNcicontOtrosTotal { get; set; }


        public double subporcentajesubNcicontTECTotal { get; set; }
        public double subporcentajesubNcicontAVCTotal { get; set; }
        public double subporcentajesubNcicontEpilepsiaTotal { get; set; }
        public double subporcentajesubNcicontMeningitisTotal { get; set; }
        public double subporcentajesubNcicontOtrosTotal { get; set; }

        //Respiratorio Total
        public int subResciChoqueSeptico_NeumoniaTotal { get; set; }
        public int subResciTEPTotal { get; set; }
        public int subResciEAPTotal { get; set; }
        public int subResciAsma_EPOCTotal { get; set; }
        public int subResciOtrosTotal { get; set; }

        public double subporcentajesubResciChoqueSeptico_NeumoniaTotal { get; set; }
        public double subporcentajesubResciTEPTotal { get; set; }
        public double subporcentajesubResciEAPTotal { get; set; }
        public double subporcentajesubResciAsma_EPOCTotal { get; set; }
        public double subporcentajesubResciOtrosTotal { get; set; }

        //Cardiovascular Total
        public int subCarciChoqueCardiogenicoTotal { get; set; }
        public int subCarciPostOperadoCirugiaCardiacaTotal { get; set; }
        public int subCarciTaquiarritmiaBradiarritmiaTotal { get; set; }
        public int subCarciCrisisHipertensivasTotal { get; set; }
        public int subCarciPostParoTotal { get; set; }
        public int subCarciOtrosTotal { get; set; }

        public double subporcentajesubCarciChoqueCardiogenicoTotal { get; set; }
        public double subporcentajesubCarciPostOperadoCirugiaCardiacaTotal { get; set; }
        public double subporcentajesubCarciTaquiarritmiaBradiarritmiaTotal { get; set; }
        public double subporcentajesubCarciCrisisHipertensivasTotal { get; set; }
        public double subporcentajesubCarciPostParoTotal { get; set; }
        public double subporcentajesubCarciOtrosTotal { get; set; }
        //Gastrointestinal Total
        public int subGasciPancreatitisAgudaTotal { get; set; }
        public int subGasciHemorragiaDigestivaTotal { get; set; }
        public int subGasciPostOperadosComplicadosTotal { get; set; }
        public int subGasciOtrosTotal { get; set; }

        public double subporcentajesubGasciPancreatitisAgudaTotal { get; set; }
        public double subporcentajesubsubGasciHemorragiaDigestivaTotal { get; set; }
        public double subporcentajesubGasciPostOperadosComplicadosTotal { get; set; }
        public double subporcentajesubGasciOtrosTotal { get; set; }


        //Subcategorias por año


        //NeurolOgico 2019                    
        public double porcentajesubNcicontTEC2019 { get; set; }
        public double porcentajesubNcicontAVC2019 { get; set; }
        public double porcentajesubNcicontEpilepsia2019 { get; set; }
        public double porcentajesubNcicontMeningitis2019 { get; set; }
        public double porcentajesubNcicontOtros2019 { get; set; }
        //Respiratorio 2019
        public double porcentajesubResciChoqueSeptico_Neumonia2019 { get; set; }
        public double porcentajesubResciTEP2019 { get; set; }
        public double porcentajesubResciEAP2019 { get; set; }
        public double porcentajesubResciAsma_EPOC2019 { get; set; }
        public double porcentajesubResciOtros2019 { get; set; }
        public double porcentajesubCarciChoqueCardiogenico2019 { get; set; }
        public double porcentajesubCarciPostOperadoCirugiaCardiaca2019 { get; set; }
        public double porcentajesubCarciTaquiarritmiaBradiarritmia2019 { get; set; }
        public double porcentajesubCarciCrisisHipertensivas2019 { get; set; }
        public double porcentajesubCarciPostParo2019 { get; set; }
        public double porcentajesubCarciOtros2019 { get; set; }
        //Gastrointestinal 2019
        public double porcentajesubGasciPancreatitisAguda2019 { get; set; }
        public double porcentajesubGasciHemorragiaDigestiva2019 { get; set; }
        public double porcentajesubGasciPostOperadosComplicados2019 { get; set; }
        public double porcentajesubGasciOtros2019 { get; set; }
        //NeurolOgico 2020                    
        public double porcentajesubNcicontTEC2020 { get; set; }
        public double porcentajesubNcicontAVC2020 { get; set; }
        public double porcentajesubNcicontEpilepsia2020 { get; set; }
        public double porcentajesubNcicontMeningitis2020 { get; set; }
        public double porcentajesubNcicontOtros2020 { get; set; }
        //Respiratorio 2020
        public double porcentajesubResciChoqueSeptico_Neumonia2020 { get; set; }
        public double porcentajesubResciTEP2020 { get; set; }
        public double porcentajesubResciEAP2020 { get; set; }
        public double porcentajesubResciAsma_EPOC2020 { get; set; }
        public double porcentajesubResciOtros2020 { get; set; }
        //Cardiovascular 2020
        public double porcentajesubCarciChoqueCardiogenico2020 { get; set; }
        public double porcentajesubCarciPostOperadoCirugiaCardiaca2020 { get; set; }
        public double porcentajesubCarciTaquiarritmiaBradiarritmia2020 { get; set; }
        public double porcentajesubCarciCrisisHipertensivas2020 { get; set; }
        public double porcentajesubCarciPostParo2020 { get; set; }
        public double porcentajesubCarciOtros2020 { get; set; }
        //Gastrointestinal 2020
        public double porcentajesubGasciPancreatitisAguda2020 { get; set; }
        public double porcentajesubGasciHemorragiaDigestiva2020 { get; set; }
        public double porcentajesubGasciPostOperadosComplicados2020 { get; set; }
        public double porcentajesubGasciOtros2020 { get; set; }
        //NeurolOgico 2021                    
        public double porcentajesubNcicontTEC2021 { get; set; }
        public double porcentajesubNcicontAVC2021 { get; set; }
        public double porcentajesubNcicontEpilepsia2021 { get; set; }
        public double porcentajesubNcicontMeningitis2021 { get; set; }
        public double porcentajesubNcicontOtros2021 { get; set; }
        //Respiratorio 2021
        public double porcentajesubResciChoqueSeptico_Neumonia2021 { get; set; }
        public double porcentajesubResciTEP2021 { get; set; }
        public double porcentajesubResciEAP2021 { get; set; }
        public double porcentajesubResciAsma_EPOC2021 { get; set; }
        public double porcentajesubResciOtros2021 { get; set; }
        //Cardiovascular 2021
        public double porcentajesubCarciChoqueCardiogenico2021 { get; set; }
        public double porcentajesubCarciPostOperadoCirugiaCardiaca2021 { get; set; }
        public double porcentajesubCarciTaquiarritmiaBradiarritmia2021 { get; set; }
        public double porcentajesubCarciCrisisHipertensivas2021 { get; set; }
        public double porcentajesubCarciPostParo2021 { get; set; }
        public double porcentajesubCarciOtros2021 { get; set; }
        //Gastrointestinal 2021
        public double porcentajesubGasciPancreatitisAguda2021 { get; set; }
        public double porcentajesubGasciHemorragiaDigestiva2021 { get; set; }
        public double porcentajesubGasciPostOperadosComplicados2021 { get; set; }
        public double porcentajesubGasciOtros2021 { get; set; }


        //NeurolOgico 2022                    
        public double porcentajesubNcicontTEC2022 { get; set; }
        public double porcentajesubNcicontAVC2022 { get; set; }
        public double porcentajesubNcicontEpilepsia2022 { get; set; }
        public double porcentajesubNcicontMeningitis2022 { get; set; }
        public double porcentajesubNcicontOtros2022 { get; set; }
        //Respiratorio 2022
        public double porcentajesubResciChoqueSeptico_Neumonia2022 { get; set; }
        public double porcentajesubResciTEP2022 { get; set; }
        public double porcentajesubResciEAP2022 { get; set; }
        public double porcentajesubResciAsma_EPOC2022 { get; set; }
        public double porcentajesubResciOtros2022 { get; set; }
        //Cardiovascular 2022
        public double porcentajesubCarciChoqueCardiogenico2022 { get; set; }
        public double porcentajesubCarciPostOperadoCirugiaCardiaca2022 { get; set; }
        public double porcentajesubCarciTaquiarritmiaBradiarritmia2022 { get; set; }
        public double porcentajesubCarciCrisisHipertensivas2022 { get; set; }
        public double porcentajesubCarciPostParo2022 { get; set; }
        public double porcentajesubCarciOtros2022 { get; set; }
        //Gastrointestinal 2022
        public double porcentajesubGasciPancreatitisAguda2022 { get; set; }
        public double porcentajesubGasciHemorragiaDigestiva2022 { get; set; }
        public double porcentajesubGasciPostOperadosComplicados2022 { get; set; }
        public double porcentajesubGasciOtros2022 { get; set; }

        //NeurolOgico 2023                    
        public double porcentajesubNcicontTEC2023 { get; set; }
        public double porcentajesubNcicontAVC2023 { get; set; }
        public double porcentajesubNcicontEpilepsia2023 { get; set; }
        public double porcentajesubNcicontMeningitis2023 { get; set; }
        public double porcentajesubNcicontOtros2023 { get; set; }
        //Respiratorio 2023
        public double porcentajesubResciChoqueSeptico_Neumonia2023 { get; set; }
        public double porcentajesubResciTEP2023 { get; set; }
        public double porcentajesubResciEAP2023 { get; set; }
        public double porcentajesubResciAsma_EPOC2023 { get; set; }
        public double porcentajesubResciOtros2023 { get; set; }
        //Cardiovascular 2023
        public double porcentajesubCarciChoqueCardiogenico2023 { get; set; }
        public double porcentajesubCarciPostOperadoCirugiaCardiaca2023 { get; set; }
        public double porcentajesubCarciTaquiarritmiaBradiarritmia2023 { get; set; }
        public double porcentajesubCarciCrisisHipertensivas2023 { get; set; }
        public double porcentajesubCarciPostParo2023 { get; set; }
        public double porcentajesubCarciOtros2023 { get; set; }
        //Gastrointestinal 2023
        public double porcentajesubGasciPancreatitisAguda2023 { get; set; }
        public double porcentajesubGasciHemorragiaDigestiva2023 { get; set; }
        public double porcentajesubGasciPostOperadosComplicados2023 { get; set; }
        public double porcentajesubGasciOtros2023 { get; set; }

        #endregion

        #region Servicio Egreso
        public int secontSalacomun2019 { get; set; }
        public int secontTerapia_intermedia2019 { get; set; }
        public int secontAlta_hospitalaria2019 { get; set; }
        public int secontFallece2019 { get; set; }

        public int secontSalacomun2020 { get; set; }
        public int secontTerapia_intermedia2020 { get; set; }
        public int secontAlta_hospitalaria2020 { get; set; }
        public int secontFallece2020 { get; set; }

        public int secontSalacomun2021 { get; set; }
        public int secontTerapia_intermedia2021 { get; set; }
        public int secontAlta_hospitalaria2021 { get; set; }
        public int secontFallece2021 { get; set; }

        public int secontSalacomun2022 { get; set; }
        public int secontTerapia_intermedia2022 { get; set; }
        public int secontAlta_hospitalaria2022 { get; set; }
        public int secontFallece2022 { get; set; }

        public int secontSalacomun2023 { get; set; }
        public int secontTerapia_intermedia2023 { get; set; }
        public int secontAlta_hospitalaria2023 { get; set; }
        public int secontFallece2023 { get; set; }
        //TOTALgLOVALES
        public int secontSalacomunGlobal { get; set; }
        public int secontTerapia_intermediaGlobal { get; set; }
        public int secontAlta_hospitalariaGlobal { get; set; }
        public int secontFalleceGlobal { get; set; }

        public int seTotalGlobales { get; set; }


        public double seporcentajeSalacomunGlobal { get; set; }
        public double seporcentajeTerapia_intermediaGlobal { get; set; }
        public double seporcentajeAlta_hospitalariaGlobal { get; set; }
        public double seporcentajeFalleceGlobal { get; set; }


        //Individuales
        public int secontall2019 { get; set; }

        public double seporcentajeSalacomun2019 { get; set; }
        public double seporcentajeTerapia_intermedia2019 { get; set; }
        public double seporcentajeAlta_hospitalaria2019 { get; set; }
        public double seporcentajeFallece2019 { get; set; }


        public int secontall2020 { get; set; }

        public double seporcentajeSalacomun2020 { get; set; }
        public double seporcentajeTerapia_intermedia2020 { get; set; }
        public double seporcentajeAlta_hospitalaria2020 { get; set; }
        public double seporcentajeFallece2020 { get; set; }

        public int secontall2021 { get; set; }

        public double seporcentajeSalacomun2021 { get; set; }
        public double seporcentajeTerapia_intermedia2021 { get; set; }
        public double seporcentajeAlta_hospitalaria2021 { get; set; }
        public double seporcentajeFallece2021 { get; set; }

        public int secontall2022 { get; set; }

        public double seporcentajeSalacomun2022 { get; set; }
        public double seporcentajeTerapia_intermedia2022 { get; set; }
        public double seporcentajeAlta_hospitalaria2022 { get; set; }
        public double seporcentajeFallece2022 { get; set; }

        public int secontall2023 { get; set; }

        public double seporcentajeSalacomun2023 { get; set; }
        public double seporcentajeTerapia_intermedia2023 { get; set; }
        public double seporcentajeAlta_hospitalaria2023 { get; set; }
        public double seporcentajeFallece2023 { get; set; }
        #endregion

        #region Causa Egreso
        public int cmNeurologico2019 { get; set; }
        public int cmRespiratorio2019 { get; set; }
        public int cmCardiovascular2019 { get; set; }
        public int cmGastrointestinal2019 { get; set; }
        public int cmRenalEndocrinologico2019 { get; set; }
        public int cmFallaMultiorganica2019 { get; set; }
        public int cmOtros2019 { get; set; }
        public int cmNoFallecidos2019 { get; set; }

        public int cmNeurologico2020 { get; set; }
        public int cmRespiratorio2020 { get; set; }
        public int cmCardiovascular2020 { get; set; }
        public int cmGastrointestinal2020 { get; set; }
        public int cmRenalEndocrinologico2020 { get; set; }
        public int cmFallaMultiorganica2020 { get; set; }
        public int cmOtros2020 { get; set; }
        public int cmNoFallecidos2020 { get; set; }

        public int cmNeurologico2021 { get; set; }
        public int cmRespiratorio2021 { get; set; }
        public int cmCardiovascular2021 { get; set; }
        public int cmGastrointestinal2021 { get; set; }
        public int cmRenalEndocrinologico2021 { get; set; }
        public int cmFallaMultiorganica2021 { get; set; }
        public int cmOtros2021 { get; set; }
        public int cmNoFallecidos2021 { get; set; }

        public int cmNeurologico2022 { get; set; }
        public int cmRespiratorio2022 { get; set; }
        public int cmCardiovascular2022 { get; set; }
        public int cmGastrointestinal2022 { get; set; }
        public int cmRenalEndocrinologico2022 { get; set; }
        public int cmFallaMultiorganica2022 { get; set; }
        public int cmOtros2022 { get; set; }
        public int cmNoFallecidos2022 { get; set; }


        public int cmNeurologico2023 { get; set; }
        public int cmRespiratorio2023 { get; set; }
        public int cmCardiovascular2023 { get; set; }
        public int cmGastrointestinal2023 { get; set; }
        public int cmRenalEndocrinologico2023 { get; set; }
        public int cmFallaMultiorganica2023 { get; set; }
        public int cmOtros2023 { get; set; }
        public int cmNoFallecidos2023 { get; set; }


        //Global causa de mortalidad
        public int cmNeurologicoGlobal { get; set; }
        public int cmRespiratorioGlobal { get; set; }
        public int cmCardiovascularGlobal { get; set; }
        public int cmGastrointestinalGlobal { get; set; }
        public int cmRenalEndocrinologicoGlobal { get; set; }
        public int cmFallaMultiorganicaGlobal { get; set; }
        public int cmOtrosGlobal { get; set; }
        public int cmNoFallecidosGlobal { get; set; }


        public int cmTotalGlobal { get; set; }

        public double cmporcentajeNeurologicosGlobal { get; set; }
        public double cmporcentajeRespiratorioGlobal { get; set; }
        public double cmporcentajeCardiovascularGlobal { get; set; }
        public double cmporcentajeGastrointestinalGlobal { get; set; }
        public double cmporcentajeEndocrinologicoGlobal { get; set; }
        public double cmporcentajeFallaMultiorganicaGlobal { get; set; }
        public double cmporcentajeOtrosGlobal { get; set; }
        public double cmporcentajeNoFallecidosGlobal { get; set; }

        //Individual

        public int cmTotal2019 { get; set; }
        public double cmporcentajeNeurologicos2019 { get; set; }
        public double cmporcentajeRespiratorio2019 { get; set; }
        public double cmporcentajeCardiovascular2019 { get; set; }
        public double cmporcentajeGastrointestinal2019 { get; set; }
        public double cmporcentajeEndocrinologico2019 { get; set; }
        public double cmporcentajeFallaMultiorganica2019 { get; set; }
        public double cmporcentajeOtros2019 { get; set; }
        public double cmporcentajeNoFallecidos2019 { get; set; }



        public int cmTotal2020 { get; set; }
        public double cmporcentajeNeurologicos2020 { get; set; }
        public double cmporcentajeRespiratorio2020 { get; set; }
        public double cmporcentajeCardiovascular2020 { get; set; }
        public double cmporcentajeGastrointestinal2020 { get; set; }
        public double cmporcentajeEndocrinologico2020 { get; set; }
        public double cmporcentajeFallaMultiorganica2020 { get; set; }
        public double cmporcentajeOtros2020 { get; set; }
        public double cmporcentajeNoFallecidos2020 { get; set; }


        public int cmTotal2021 { get; set; }
        public double cmporcentajeNeurologicos2021 { get; set; }
        public double cmporcentajeRespiratorio2021 { get; set; }
        public double cmporcentajeCardiovascular2021 { get; set; }
        public double cmporcentajeGastrointestinal2021 { get; set; }
        public double cmporcentajeEndocrinologico2021 { get; set; }
        public double cmporcentajeFallaMultiorganica2021 { get; set; }
        public double cmporcentajeOtros2021 { get; set; }
        public double cmporcentajeNoFallecidos2021 { get; set; }


        public int cmTotal2022 { get; set; }
        public double cmporcentajeNeurologicos2022 { get; set; }
        public double cmporcentajeRespiratorio2022 { get; set; }
        public double cmporcentajeCardiovascular2022 { get; set; }
        public double cmporcentajeGastrointestinal2022 { get; set; }
        public double cmporcentajeEndocrinologico2022 { get; set; }
        public double cmporcentajeFallaMultiorganica2022 { get; set; }
        public double cmporcentajeOtros2022 { get; set; }
        public double cmporcentajeNoFallecidos2022 { get; set; }


        public int cmTotal2023 { get; set; }
        public double cmporcentajeNeurologicos2023 { get; set; }
        public double cmporcentajeRespiratorio2023 { get; set; }
        public double cmporcentajeCardiovascular2023 { get; set; }
        public double cmporcentajeGastrointestinal2023 { get; set; }
        public double cmporcentajeEndocrinologico2023 { get; set; }
        public double cmporcentajeFallaMultiorganica2023 { get; set; }
        public double cmporcentajeOtros2023 { get; set; }
        public double cmporcentajeNoFallecidos2023 { get; set; }
        #endregion

    }
}
