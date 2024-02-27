using Azure;
using FrontEnd_UTI_Statistics.BD;
using FrontEnd_UTI_Statistics.BD.model;
using FrontEnd_UTI_Statistics.Models.Estadisticas;
using FrontEnd_UTI_Statistics.Models.Login;
using FrontEnd_UTI_Statistics.Models.Registro;
using Newtonsoft.Json;
using System.Diagnostics.Metrics;
using System.Security.Claims;
using static FrontEnd_UTI_Statistics.Models.Registro.RgistrarInsert;

namespace FrontEnd_UTI_Statistics.Managers
{
    public class RegistroManager
    {
        #region Lista Usuarios
       
        public static ListaRegistroResponseBd ListaRegistros()
        {
            ListaRegistroResponseBd response = new ListaRegistroResponseBd();
            try
            {
                //Obtenemos datos del usuario
                var respuestaListaUsuarios = ListaRegistro.ListaUsuarios();
                if (respuestaListaUsuarios.Data != null)
                {
                    string jsonData = JsonConvert.SerializeObject(respuestaListaUsuarios.Data);
                    response = JsonConvert.DeserializeObject<ListaRegistroResponseBd>(jsonData);

                    // foreach(var item in respuestaListaUsuarios.Data)



                    return response ;
                }
                else
                {
                    return response;
                }


            }
            catch (Exception ex)
            {
                return response;
            }


        }
        #endregion

        #region Insertar Usuario
        public static bool InsertarRegistro(RegistromodelFrontEnd requestFrontEnd)
        {
            try
            {
                if (requestFrontEnd.ServicioEgreso != 4) 
                {
                    requestFrontEnd.CausaMortalidad = 0;
                }
                if (requestFrontEnd.CausaIngreso == 5 || requestFrontEnd.CausaIngreso==6)
                {
                    requestFrontEnd.SubCausaIngreso = 0;
                }

                var respuesta =RegistrarBd.InsertarRegistro(requestFrontEnd);

                int response;
                string jsonData = JsonConvert.SerializeObject(respuesta.Data);
                response = JsonConvert.DeserializeObject<int>(jsonData);
                if (response == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

                
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region estadisticas

        public static estadisticasModel estadisticas()
        {
            estadisticasModel responseEst = new estadisticasModel();
            ListaRegistroResponseBd response = new ListaRegistroResponseBd();
            try
            {
                //Obtenemos datos del usuario
                var respuestaListaUsuarios = ListaRegistro.ListaUsuarios();
                if (respuestaListaUsuarios.Data != null)
                {
                    string jsonData = JsonConvert.SerializeObject(respuestaListaUsuarios.Data);
                    response = JsonConvert.DeserializeObject<ListaRegistroResponseBd>(jsonData);

                    #region Promedio de ingresos mensuales
                    //barras
                    int Ingresos_totales=0;
                    int contador2019 = 0;
                    int contador2020 = 0;
                    int contador2021 = 0;
                    int contador2022 = 0;
                    int contador2023 = 0;

                    foreach (var item in response.lista_usuarios)
                    {
                        DateTime fechaIngreso = DateTime.Parse(item.FechaIngreso); // Suponiendo que FechaIngreso es de tipo DateTime
                        Ingresos_totales++;
                        // Sumar los ingresos correspondientes a cada año
                        if (fechaIngreso.Year == 2019)
                        {
                            contador2019++;
                        }
                        else if (fechaIngreso.Year == 2020)
                        {
                            contador2020++;
                        }
                        else if (fechaIngreso.Year == 2021)
                        {
                            contador2021++;
                        }
                        else if (fechaIngreso.Year == 2022)
                        {
                            contador2022++;
                        }
                        else if (fechaIngreso.Year == 2023)
                        {
                            contador2023++;
                        }
                    }

                    // Calcular promedio por año
                    double promedioIngresos2019 = contador2019 / 12;
                    double promedioIngresos2020 = contador2020 / 12;
                    double promedioIngresos2021 = contador2021 / 12;
                    double promedioIngresos2022 = contador2022 / 12;
                    double promedioIngresos2023 = contador2023 / 12;

                    double porcentajeIngresos2019 = 0;
                    double porcentajeIngresos2020 = 0;
                    double porcentajeIngresos2021 = 0;
                    double porcentajeIngresos2022 = 0;
                    double porcentajeIngresos2023 = 0;

                    if (Ingresos_totales !=0) 
                    {
                         porcentajeIngresos2019 = (double)contador2019 / Ingresos_totales * 100;
                         porcentajeIngresos2020 = (double)contador2020 / Ingresos_totales * 100;
                         porcentajeIngresos2021 = (double)contador2021 / Ingresos_totales * 100;
                         porcentajeIngresos2022 = (double)contador2022 / Ingresos_totales * 100;
                         porcentajeIngresos2023 = (double)contador2023 / Ingresos_totales * 100;

                    }


                    #endregion

                    #region Porcentaje de varones y mujeres 

                    int contadorSexFemTotal = 0;
                    int contadorSexMasTotal = 0;

                    int contadorSex2019f = 0;
                    int contadorSex2020f = 0;
                    int contadorSex2021f = 0;
                    int contadorSex2022f = 0;
                    int contadorSex2023f = 0;


                    int contadorSex2019m = 0;
                    int contadorSex2020m = 0;
                    int contadorSex2021m = 0;
                    int contadorSex2022m = 0;
                    int contadorSex2023m = 0;

                    foreach (var item in response.lista_usuarios)
                    {
                        DateTime fechaIngreso = DateTime.Parse(item.FechaIngreso); // Suponiendo que FechaIngreso es de tipo DateTime
                        // Sumar los ingresos correspondientes a cada año
                        if (fechaIngreso.Year == 2019)
                        {
                            if (item.Sexo == 0)
                            {
                                contadorSex2019m++;
                            }
                            else
                            {
                                contadorSex2019f++;
                            }
                        }
                        else if (fechaIngreso.Year == 2020)
                        {
                            if (item.Sexo == 0)
                            {
                                contadorSex2020m++;
                            }
                            else
                            {
                                contadorSex2020f++;
                            }
                        }
                        else if (fechaIngreso.Year == 2021)
                        {
                            if (item.Sexo == 0)
                            {
                                contadorSex2021m++;
                            }
                            else
                            {
                                contadorSex2021f++;
                            }
                        }
                        else if (fechaIngreso.Year == 2022)
                        {
                            if (item.Sexo == 0)
                            {
                                contadorSex2022m++;
                            }
                            else
                            {
                                contadorSex2022f++;
                            }
                        }
                        else if (fechaIngreso.Year == 2023)
                        {
                            if (item.Sexo == 0)
                            {
                                contadorSex2023m++;
                            }
                            else
                            {
                                contadorSex2023f++;
                            }
                        }
                    }

                    contadorSexFemTotal =  contadorSex2019f + contadorSex2020f +contadorSex2021f+contadorSex2022f +contadorSex2023f ;
                    contadorSexMasTotal = contadorSex2019m + contadorSex2020m + contadorSex2021m + contadorSex2022m + contadorSex2023m;
                    int totalSex = contadorSexFemTotal + contadorSexMasTotal;
                    //porcentaje Global
                    double porcentajeallf = 0;
                    double porcentajeallm = 0;


                    if (totalSex != 0) 
                    {
                        porcentajeallf = (double)contadorSexFemTotal / totalSex * 100;
                        porcentajeallm = (double)contadorSexMasTotal / totalSex * 100;
                    }


                    // Calcular el total de cada año por sexo
                    int total2019 = contadorSex2019f + contadorSex2019m;
                    int total2020 = contadorSex2020f + contadorSex2020m;
                    int total2021 = contadorSex2021f + contadorSex2021m;
                    int total2022 = contadorSex2022f + contadorSex2022m;
                    int total2023 = contadorSex2023f + contadorSex2023m;

                    // Calcular el porcentaje para cada año
                    double porcentaje2019f = 0;
                    double porcentaje2019m = 0;
                    if (total2019 != 0)
                    {
                        porcentaje2019f = (double)contadorSex2019f / total2019 * 100;
                        porcentaje2019m = (double)contadorSex2019m / total2019 * 100;
                    }



                    double porcentaje2020f = 0;
                    double porcentaje2020m = 0;
                    if (total2020 != 0)
                    {
                        porcentaje2020f = (double)contadorSex2020f / total2020 * 100;
                        porcentaje2020m = (double)contadorSex2020m / total2020 * 100;
                    }



                    double porcentaje2021f = 0;
                    double porcentaje2021m = 0;
                    if (total2021 != 0)
                    {
                        porcentaje2021f = (double)contadorSex2021f / total2021 * 100;
                        porcentaje2021m = (double)contadorSex2021m / total2021 * 100;
                    }



                    double porcentaje2022f = 0;
                    double porcentaje2022m = 0;
                    if (total2022 != 0)
                    {
                        porcentaje2022f = (double)contadorSex2022f / total2022 * 100;
                        porcentaje2022m = (double)contadorSex2022m / total2022 * 100;
                    }


                    double porcentaje2023f = 0;
                    double porcentaje2023m = 0;
                    if (total2023 != 0)
                    {
                        porcentaje2023f = (double)contadorSex2023f / total2023 * 100;
                        porcentaje2023m = (double)contadorSex2023m / total2023 * 100;
                    }
                    #endregion

                    #region MODA MEDIA PROMEDIO POR AÑO EN ESTE CASO 2019 2020 2021 2022 2023

                    int moda2019Edad = 0;
                    double media2019Edad = 0;
                    double promedi2019Edad = 0;

                    int moda2020Edad = 0;
                    double media2020Edad = 0;
                    double promedi2020Edad = 0;

                    int moda2021Edad = 0;
                    double media2021Edad = 0;
                    double promedi2021Edad = 0;

                    int moda2022Edad = 0;
                    double media2022Edad = 0;
                    double promedi2022Edad = 0;

                    int moda2023Edad = 0;
                    double media2023Edad = 0;
                    double promedi2023Edad = 0;
                    //Para la discriminacion de edad
                    int Menores30anos2019 = 0;
                    int Adultos30_59anos2019 = 0;
                    int Mayoresde60anos2019 = 0;

                    int Menores30anos2020 = 0;
                    int Adultos30_59anos2020 = 0;
                    int Mayoresde60anos2020 = 0;

                    int Menores30anos2021 = 0;
                    int Adultos30_59anos2021 = 0;
                    int Mayoresde60anos2021 = 0;

                    int Menores30anos2022 = 0;
                    int Adultos30_59anos2022 = 0;
                    int Mayoresde60anos2022 = 0;

                    int Menores30anos2023 = 0;
                    int Adultos30_59anos2023 = 0;
                    int Mayoresde60anos2023 = 0;

                    foreach (var item in response.lista_usuarios)
                    {
                        DateTime fechaIngreso = DateTime.Parse(item.FechaIngreso); // Suponiendo que FechaIngreso es de tipo string y representa la fecha de ingreso
                        int edad = item.Edad; // Suponiendo que Edad es de tipo int y representa la edad del usuario

                        // Discriminar las edades por rangos y por año
                        if (fechaIngreso.Year == 2019)
                        {
                            if (edad < 30)
                                Menores30anos2019++;
                            else if (edad >= 30 && edad <= 59)
                                Adultos30_59anos2019++;
                            else
                                Mayoresde60anos2019++;
                        }
                        else if (fechaIngreso.Year == 2020)
                        {
                            if (edad < 30)
                                Menores30anos2020++;
                            else if (edad >= 30 && edad <= 59)
                                Adultos30_59anos2020++;
                            else
                                Mayoresde60anos2020++;
                        }
                        else if (fechaIngreso.Year == 2021)
                        {
                            if (edad < 30)
                                Menores30anos2021++;
                            else if (edad >= 30 && edad <= 59)
                                Adultos30_59anos2021++;
                            else
                                Mayoresde60anos2021++;
                        }
                        else if (fechaIngreso.Year == 2022)
                        {
                            if (edad < 30)
                                Menores30anos2022++;
                            else if (edad >= 30 && edad <= 59)
                                Adultos30_59anos2022++;
                            else
                                Mayoresde60anos2022++;
                        }
                        else if (fechaIngreso.Year == 2023)
                        {
                            if (edad < 30)
                                Menores30anos2023++;
                            else if (edad >= 30 && edad <= 59)
                                Adultos30_59anos2023++;
                            else
                                Mayoresde60anos2023++;
                        }
                    }

                    int totalEdad2019 = Menores30anos2019 + Adultos30_59anos2019 + Mayoresde60anos2019;
                    double porcentajeMenores30anos2019 = 0;
                    double porcentajeAdultos30_59anos2019 = 0;
                    double porcentajeMayoresde60anos2019 = 0;
                    if (totalEdad2019!=0) 
                    {
                         porcentajeMenores30anos2019 = (double)Menores30anos2019 / totalEdad2019 * 100;
                         porcentajeAdultos30_59anos2019 = (double)Adultos30_59anos2019 / totalEdad2019 * 100;
                         porcentajeMayoresde60anos2019 = (double)Mayoresde60anos2019 / totalEdad2019 * 100;
                    }



                    int totalEdad2020 = Menores30anos2020 + Adultos30_59anos2020 + Mayoresde60anos2020;
                    double porcentajeMenores30anos2020 = 0;
                    double porcentajeAdultos30_59anos2020 = 0;
                    double porcentajeMayoresde60anos2020 = 0;
                    if (totalEdad2020 != 0)
                    {
                        porcentajeMenores30anos2020 = (double)Menores30anos2020 / totalEdad2020 * 100;
                        porcentajeAdultos30_59anos2020 = (double)Adultos30_59anos2020 / totalEdad2020 * 100;
                        porcentajeMayoresde60anos2020 = (double)Mayoresde60anos2020 / totalEdad2020 * 100;
                    }

                    int totalEdad2021 = Menores30anos2021 + Adultos30_59anos2021 + Mayoresde60anos2021;
                    double porcentajeMenores30anos2021 = 0;
                    double porcentajeAdultos30_59anos2021 = 0;
                    double porcentajeMayoresde60anos2021 = 0;
                    if (totalEdad2021 != 0)
                    {
                        porcentajeMenores30anos2021 = (double)Menores30anos2021 / totalEdad2021 * 100;
                        porcentajeAdultos30_59anos2021 = (double)Adultos30_59anos2021 / totalEdad2021 * 100;
                        porcentajeMayoresde60anos2021 = (double)Mayoresde60anos2021 / totalEdad2021 * 100;
                    }

                    int totalEdad2022 = Menores30anos2022 + Adultos30_59anos2022 + Mayoresde60anos2022;
                    double porcentajeMenores30anos2022 = 0;
                    double porcentajeAdultos30_59anos2022 = 0;
                    double porcentajeMayoresde60anos2022 = 0;
                    if (totalEdad2022 != 0)
                    {
                        porcentajeMenores30anos2022 = (double)Menores30anos2022 / totalEdad2022 * 100;
                        porcentajeAdultos30_59anos2022 = (double)Adultos30_59anos2022 / totalEdad2022 * 100;
                        porcentajeMayoresde60anos2022 = (double)Mayoresde60anos2022 / totalEdad2022 * 100;
                    }
                    int totalEdad2023 = Menores30anos2023 + Adultos30_59anos2023 + Mayoresde60anos2023;
                    double porcentajeMenores30anos2023 = 0;
                    double porcentajeAdultos30_59anos2023 = 0;
                    double porcentajeMayoresde60anos2023 = 0;
                    if (totalEdad2023 != 0)
                    {
                        porcentajeMenores30anos2023 = (double)Menores30anos2023 / totalEdad2023 * 100;
                        porcentajeAdultos30_59anos2023 = (double)Adultos30_59anos2023 / totalEdad2023 * 100;
                        porcentajeMayoresde60anos2023 = (double)Mayoresde60anos2023 / totalEdad2023 * 100;
                    }


                    //global
                    int totalEdadGlobal = totalEdad2019 + totalEdad2020 + totalEdad2021 + totalEdad2022 + totalEdad2023;

                    int Menores30anosGlobal = Menores30anos2019 + Menores30anos2020 + Menores30anos2021 + Menores30anos2022 + Menores30anos2023;
                    int Adultos30_59anosGlobal = Adultos30_59anos2019 + Adultos30_59anos2020 + Adultos30_59anos2021 + Adultos30_59anos2022 + Adultos30_59anos2023;
                    int Mayoresde60anosGlobal = Mayoresde60anos2019 + Mayoresde60anos2020 + Mayoresde60anos2021 + Mayoresde60anos2022 + Mayoresde60anos2023;


                    double porcentajeMenores30anosGlobal = 0;
                    double porcentajeAdultos30_59anosGlobal = 0;
                    double porcentajeMayoresde60anosGlobal = 0;
                    if (totalEdad2023 != 0)
                    {
                        porcentajeMenores30anosGlobal = (double)Menores30anosGlobal / totalEdadGlobal * 100;
                        porcentajeAdultos30_59anosGlobal = (double)Adultos30_59anosGlobal / totalEdadGlobal * 100;
                        porcentajeMayoresde60anosGlobal = (double)Mayoresde60anosGlobal / totalEdadGlobal * 100;
                    }
                

                    Dictionary<int, List<int>> edadesPorAnio = new Dictionary<int, List<int>>(); // Diccionario para almacenar las edades por año

                    foreach (var item in response.lista_usuarios)
                    {
                        DateTime fechaIngreso = DateTime.Parse(item.FechaIngreso); // Suponiendo que FechaIngreso es de tipo string y representa la fecha de ingreso
                        int edad = item.Edad; // Suponiendo que Edad es de tipo int y representa la edad del usuario

                        // Verificar si el año ya está en el diccionario, si no, se agrega
                        if (!edadesPorAnio.ContainsKey(fechaIngreso.Year))
                        {
                            edadesPorAnio.Add(fechaIngreso.Year, new List<int>());
                        }

                        // Agregar la edad al año correspondiente
                        edadesPorAnio[fechaIngreso.Year].Add(edad);
                    }
                   
                    // Calcular la media, moda y promedio por cada año
                    foreach (var kvp in edadesPorAnio)
                    {
                        int anio = kvp.Key;
                        List<int> edades = kvp.Value;

                        // Media
                        double media = edades.Average();

                        // Moda
                        var grupoEdades = edades.GroupBy(x => x);
                        var moda = grupoEdades.OrderByDescending(g => g.Count()).First().Key;

                        // Promedio
                        double promedio = edades.Sum() / (double)edades.Count;

                      

                        if (anio == 2019)
                        {
                             moda2019Edad=moda;
                             media2019Edad=media;
                             promedi2019Edad=promedio;
                        }
                        else if (anio == 2020)
                        {
                             moda2020Edad = moda;
                             media2020Edad = media;
                             promedi2020Edad = promedio;
                        }
                        else if (anio == 2021)
                        {
                             moda2021Edad = moda;
                             media2021Edad = media;
                             promedi2021Edad = promedio;
                        }
                        else if (anio == 2022) 
                        {
                             moda2022Edad = moda;
                             media2022Edad = media;
                             promedi2022Edad = promedio;
                        }
                        else if (anio == 2023)
                        {
                             moda2023Edad = moda;
                             media2023Edad = media;
                             promedi2023Edad = promedio;
                        }
                    }

                    #endregion

                    #region MODA MEDIA PROMEDIO POR AÑO dias de internacion

                    int moda2019EstDias = 0;
                    double media2019EstDias = 0;
                    double promedi2019EstDias = 0;

                    int moda2020EstDias = 0;
                    double media2020EstDias = 0;
                    double promedi2020EstDias = 0;

                    int moda2021EstDias = 0;
                    double media2021EstDias = 0;
                    double promedi2021EstDias = 0;

                    int moda2022EstDias = 0;
                    double media2022EstDias = 0;
                    double promedi2022EstDias = 0;

                    int moda2023EstDias = 0;
                    double media2023EstDias = 0;
                    double promedi2023EstDias = 0;
                    Dictionary<int, List<int>> diasInternacionPorAnio = new Dictionary<int, List<int>>(); // Diccionario para almacenar las edades por año

                    foreach (var item in response.lista_usuarios)
                    {
                        DateTime fechaIngreso = DateTime.Parse(item.FechaIngreso); // Suponiendo que FechaIngreso es de tipo string y representa la fecha de ingreso
                        int estanciaDias = Int32.Parse(item.EstanciaDias); // Suponiendo que Edad es de tipo int y representa la edad del usuario

                        // Verificar si el año ya está en el diccionario, si no, se agrega
                        if (!diasInternacionPorAnio.ContainsKey(fechaIngreso.Year))
                        {
                            diasInternacionPorAnio.Add(fechaIngreso.Year, new List<int>());
                        }

                        // Agregar la edad al año correspondiente
                        diasInternacionPorAnio[fechaIngreso.Year].Add(estanciaDias);
                    }
                    
                    // Calcular la media, moda y promedio por cada año
                    foreach (var kvp in diasInternacionPorAnio)
                    {
                        int anio = kvp.Key;
                        List<int> estdias = kvp.Value;

                        // Media
                        double media = estdias.Average();

                        // Moda
                        var grupoEdades = estdias.GroupBy(x => x);
                        var moda = grupoEdades.OrderByDescending(g => g.Count()).First().Key;

                        // Promedio
                        double promedio = estdias.Sum() / (double)estdias.Count;

                        if (anio == 2019)
                        {
                            moda2019EstDias = moda;
                            media2019EstDias = media;
                            promedi2019EstDias = promedio;
                        }
                        else if (anio == 2020)
                        {
                            moda2020EstDias = moda;
                            media2020EstDias = media;
                            promedi2020EstDias = promedio;
                        }
                        else if (anio == 2021)
                        {
                            moda2021EstDias = moda;
                            media2021EstDias = media;
                            promedi2021EstDias = promedio;
                        }
                        else if (anio == 2022)
                        {
                            moda2022EstDias = moda;
                            media2022EstDias = media;
                            promedi2022EstDias = promedio;
                        }
                        else if (anio == 2023)
                        {
                            moda2023EstDias = moda;
                            media2023EstDias = media;
                            promedi2023EstDias = promedio;
                        }
                    }

                    #endregion

                    #region Origen de Ingresos
                    int oicontEmergencias2019 = 0;
                    int oicontQuirofano2019 = 0;
                    int oicontSalacomun2019 = 0;
                    int oicontTransferenciadeotraUTI2019 = 0;
                    int oicontOtros2019 = 0;

                    int oicontEmergencias2020 = 0;
                    int oicontQuirofano2020 = 0;
                    int oicontSalacomun2020 = 0;
                    int oicontTransferenciadeotraUTI2020 = 0;
                    int oicontOtros2020 = 0;

                    int oicontEmergencias2021 = 0;
                    int oicontQuirofano2021 = 0;
                    int oicontSalacomun2021 = 0;
                    int oicontTransferenciadeotraUTI2021 = 0;
                    int oicontOtros2021 = 0;

                    int oicontEmergencias2022 = 0;
                    int oicontQuirofano2022 = 0;
                    int oicontSalacomun2022 = 0;
                    int oicontTransferenciadeotraUTI2022 = 0;
                    int oicontOtros2022 = 0;

                    int oicontEmergencias2023 = 0;
                    int oicontQuirofano2023 = 0;
                    int oicontSalacomun2023 = 0;
                    int oicontTransferenciadeotraUTI2023 = 0;
                    int oicontOtros2023 = 0;


                    // Contadores globales
                    int totalGlobalEmergencias = 0;
                    int totalGlobalQuirofano = 0;
                    int totalGlobalSalaComun = 0;
                    int totalGlobalTransferenciaOtraUTI = 0;
                    int totalGlobalOtros = 0;

                    // Inicializar un diccionario para mantener el recuento de cada tipo de origen de ingreso por año
                    Dictionary<int, Dictionary<string, int>> conteoPorAnio = new Dictionary<int, Dictionary<string, int>>();

                    // Iterar sobre la lista de usuarios
                    foreach (var item in response.lista_usuarios)
                    {
                        DateTime fechaIngreso = DateTime.Parse(item.FechaIngreso);
                        string origenIngreso = item.OrigenIngreso;

                        // Verificar si el año ya está en el diccionario, si no, agregarlo
                        if (!conteoPorAnio.ContainsKey(fechaIngreso.Year))
                        {
                            conteoPorAnio[fechaIngreso.Year] = new Dictionary<string, int>();
                        }

                        // Verificar si el tipo de origen de ingreso ya está en el diccionario para ese año, si no, inicializarlo
                        if (!conteoPorAnio[fechaIngreso.Year].ContainsKey(origenIngreso))
                        {
                            conteoPorAnio[fechaIngreso.Year][origenIngreso] = 0;
                        }

                        // Incrementar el recuento del tipo de origen de ingreso para ese año
                        conteoPorAnio[fechaIngreso.Year][origenIngreso]++;
                    }

                    // Ahora tienes el conteo de cada tipo de origen de ingreso por año en el diccionario conteoPorAño

                    // Iterar sobre el diccionario conteoPorAño y mostrar los resultados
                    foreach (var kvpAnio in conteoPorAnio)
                    {
                        int anio = kvpAnio.Key;
                        Dictionary<string, int> conteoPorOrigen = kvpAnio.Value;

                        //Console.WriteLine($"Conteo de origen de ingreso para el año {año}:");
                        foreach (var kvpOrigen in conteoPorOrigen)
                        {
                            string origen = kvpOrigen.Key;
                            int conteo = kvpOrigen.Value;
                            //.WriteLine($"- {origen}: {conteo}");

                            if (anio == 2019) 
                            {
                                if (origen == "EMERGENCIAS") 
                                {
                                    oicontEmergencias2019=conteo;
                                    
                                }
                                else if (origen == "QUIRÓFANO")
                                {
                                    oicontQuirofano2019 = conteo;
                                    
                                }
                                else if (origen == "SALA COMÚN")
                                {
                                    oicontSalacomun2019 = conteo;
                                    
                                }
                                else if (origen == "TRANSFERENCIA DE OTRA UTI")
                                {
                                    
                                    oicontTransferenciadeotraUTI2019 = conteo;
                                    
                                }
                                else if (origen == "OTROS")
                                {
                                    oicontOtros2019 = conteo;
                                }

                            }
                            else if (anio == 2020)
                            {
                                if (origen == "EMERGENCIAS")
                                {
                                    oicontEmergencias2020 = conteo;

                                }
                                else if (origen == "QUIRÓFANO")
                                {
                                    oicontQuirofano2020 = conteo;

                                }
                                else if (origen == "SALA COMÚN")
                                {
                                    oicontSalacomun2020 = conteo;

                                }
                                else if (origen == "TRANSFERENCIA DE OTRA UTI")
                                {

                                    oicontTransferenciadeotraUTI2020 = conteo;

                                }
                                else if (origen == "OTROS")
                                {
                                    oicontOtros2020 = conteo;
                                }
                            }
                            else if (anio == 2021)
                            {
                                if (origen == "EMERGENCIAS")
                                {
                                    oicontEmergencias2021 = conteo;

                                }
                                else if (origen == "QUIRÓFANO")
                                {
                                    oicontQuirofano2021 = conteo;

                                }
                                else if (origen == "SALA COMÚN")
                                {
                                    oicontSalacomun2021 = conteo;

                                }
                                else if (origen == "TRANSFERENCIA DE OTRA UTI")
                                {

                                    oicontTransferenciadeotraUTI2021 = conteo;

                                }
                                else if (origen == "OTROS")
                                {
                                    oicontOtros2021 = conteo;
                                }
                            }
                            else if (anio == 2022)
                            {
                                if (origen == "EMERGENCIAS")
                                {
                                    oicontEmergencias2022 = conteo;

                                }
                                else if (origen == "QUIRÓFANO")
                                {
                                    oicontQuirofano2022 = conteo;

                                }
                                else if (origen == "SALA COMÚN")
                                {
                                    oicontSalacomun2022 = conteo;

                                }
                                else if (origen == "TRANSFERENCIA DE OTRA UTI")
                                {

                                    oicontTransferenciadeotraUTI2022 = conteo;

                                }
                                else if (origen == "OTROS")
                                {
                                    oicontOtros2022 = conteo;
                                }
                            }
                            else if (anio == 2023)
                            {
                                if (origen == "EMERGENCIAS")
                                {
                                    oicontEmergencias2023 = conteo;

                                }
                                else if (origen == "QUIRÓFANO")
                                {
                                    oicontQuirofano2023 = conteo;

                                }
                                else if (origen == "SALA COMÚN")
                                {
                                    oicontSalacomun2023 = conteo;

                                }
                                else if (origen == "TRANSFERENCIA DE OTRA UTI")
                                {

                                    oicontTransferenciadeotraUTI2023 = conteo;

                                }
                                else if (origen == "OTROS")
                                {
                                    oicontOtros2023 = conteo;
                                }
                            }



                        }
                        //Console.WriteLine(); // Espacio en blanco entre años
                    }


                    // Globales
                    totalGlobalEmergencias = oicontEmergencias2019+ oicontEmergencias2020+ oicontEmergencias2021+ oicontEmergencias2022+ oicontEmergencias2023;
                    totalGlobalQuirofano = oicontQuirofano2019+ oicontQuirofano2020+ oicontQuirofano2021+ oicontQuirofano2022+ oicontQuirofano2023;
                    totalGlobalSalaComun = oicontSalacomun2019+ oicontSalacomun2020+ oicontSalacomun2021+ oicontSalacomun2022+ oicontSalacomun2023;
                    totalGlobalTransferenciaOtraUTI = oicontTransferenciadeotraUTI2019+ oicontTransferenciadeotraUTI2020+ oicontTransferenciadeotraUTI2021+ oicontTransferenciadeotraUTI2022+ oicontTransferenciadeotraUTI2023;
                    totalGlobalOtros = oicontOtros2019+ oicontOtros2020+ oicontOtros2021+ oicontOtros2022+ oicontOtros2023;
                    
                    int TotalGlobal = totalGlobalEmergencias + totalGlobalQuirofano + totalGlobalSalaComun + totalGlobalTransferenciaOtraUTI + totalGlobalOtros;

                    double porcentajeEmergencias = 0;
                    double porcentajeQuirofano = 0;
                    double porcentajeSalaComun = 0;
                    double porcentajeTransferenciaOtraUTI = 0;
                    double porcentajeOtros = 0;
                    if (TotalGlobal!=0) 
                    {
                        porcentajeEmergencias = (double)totalGlobalEmergencias / TotalGlobal * 100;
                        porcentajeQuirofano = (double)totalGlobalQuirofano / TotalGlobal * 100;
                        porcentajeSalaComun = (double)totalGlobalSalaComun / TotalGlobal * 100;
                        porcentajeTransferenciaOtraUTI = (double)totalGlobalTransferenciaOtraUTI / TotalGlobal * 100;
                        porcentajeOtros = (double)totalGlobalOtros / TotalGlobal * 100;
                    }

                    //Individuales
                    int totaOI2019 = oicontEmergencias2019 + oicontQuirofano2019 + oicontSalacomun2019 + oicontTransferenciadeotraUTI2019 + oicontOtros2019;
                    double porcentajeEmergencias2019 = 0;
                    double porcentajeQuirofano2019 = 0;
                    double porcentajeSalaComun2019 = 0;
                    double porcentajeTransferenciaOtraUTI2019 = 0;
                    double porcentajeOtros2019 = 0;
                    if (totaOI2019 != 0)
                    {
                        porcentajeEmergencias2019 = (double)oicontEmergencias2019 / totaOI2019 * 100;
                        porcentajeQuirofano2019 = (double)oicontQuirofano2019 / totaOI2019 * 100;
                        porcentajeSalaComun2019 = (double)oicontSalacomun2019 / totaOI2019 * 100;
                        porcentajeTransferenciaOtraUTI2019 = (double)oicontTransferenciadeotraUTI2019 / totaOI2019 * 100;
                        porcentajeOtros2019 = (double)oicontOtros2019 / totaOI2019 * 100;
                    }



                    int totaOI2020 = oicontEmergencias2020 + oicontQuirofano2020 + oicontSalacomun2020 + oicontTransferenciadeotraUTI2020 + oicontOtros2020;
                    double porcentajeEmergencias2020 = 0;
                    double porcentajeQuirofano2020 = 0;
                    double porcentajeSalaComun2020 = 0;
                    double porcentajeTransferenciaOtraUTI2020 = 0;
                    double porcentajeOtros2020 = 0;
                    if (totaOI2020 != 0)
                    {
                        porcentajeEmergencias2020 = (double)oicontEmergencias2020 / totaOI2020 * 100;
                        porcentajeQuirofano2020 = (double)oicontQuirofano2020 / totaOI2020 * 100;
                        porcentajeSalaComun2020 = (double)oicontSalacomun2020 / totaOI2020 * 100;
                        porcentajeTransferenciaOtraUTI2020 = (double)oicontTransferenciadeotraUTI2020 / totaOI2020 * 100;
                        porcentajeOtros2020 = (double)oicontOtros2020 / totaOI2020 * 100;
                    }

                    int totaOI2021 = oicontEmergencias2021 + oicontQuirofano2021 + oicontSalacomun2021 + oicontTransferenciadeotraUTI2021 + oicontOtros2021;
                    double porcentajeEmergencias2021 = 0;
                    double porcentajeQuirofano2021 = 0;
                    double porcentajeSalaComun2021 = 0;
                    double porcentajeTransferenciaOtraUTI2021 = 0;
                    double porcentajeOtros2021 = 0;
                    if (totaOI2021 != 0)
                    {
                        porcentajeEmergencias2021 = (double)oicontEmergencias2021 / totaOI2021 * 100;
                        porcentajeQuirofano2021 = (double)oicontQuirofano2021 / totaOI2021 * 100;
                        porcentajeSalaComun2021 = (double)oicontSalacomun2021 / totaOI2021 * 100;
                        porcentajeTransferenciaOtraUTI2021 = (double)oicontTransferenciadeotraUTI2021 / totaOI2021 * 100;
                        porcentajeOtros2021 = (double)oicontOtros2021 / totaOI2021 * 100;
                    }

                    int totaOI2022 = oicontEmergencias2022 + oicontQuirofano2022 + oicontSalacomun2022 + oicontTransferenciadeotraUTI2022 + oicontOtros2022;
                    double porcentajeEmergencias2022 = 0;
                    double porcentajeQuirofano2022 = 0;
                    double porcentajeSalaComun2022 = 0;
                    double porcentajeTransferenciaOtraUTI2022 = 0;
                    double porcentajeOtros2022 = 0;
                    if (totaOI2022 != 0)
                    {
                        porcentajeEmergencias2022 = (double)oicontEmergencias2022 / totaOI2022 * 100;
                        porcentajeQuirofano2022 = (double)oicontQuirofano2022 / totaOI2022 * 100;
                        porcentajeSalaComun2022 = (double)oicontSalacomun2022 / totaOI2022 * 100;
                        porcentajeTransferenciaOtraUTI2022 = (double)oicontTransferenciadeotraUTI2022 / totaOI2022 * 100;
                        porcentajeOtros2022 = (double)oicontOtros2022 / totaOI2022 * 100;
                    }

                    int totaOI2023 = oicontEmergencias2023 + oicontQuirofano2023 + oicontSalacomun2023 + oicontTransferenciadeotraUTI2023 + oicontOtros2023;
                    double porcentajeEmergencias2023 = 0;
                    double porcentajeQuirofano2023 = 0;
                    double porcentajeSalaComun2023 = 0;
                    double porcentajeTransferenciaOtraUTI2023 = 0;
                    double porcentajeOtros2023 = 0;
                    if (totaOI2023 != 0)
                    {
                        porcentajeEmergencias2023 = (double)oicontEmergencias2023 / totaOI2023 * 100;
                        porcentajeQuirofano2023 = (double)oicontQuirofano2023 / totaOI2023 * 100;
                        porcentajeSalaComun2023 = (double)oicontSalacomun2023 / totaOI2023 * 100;
                        porcentajeTransferenciaOtraUTI2023 = (double)oicontTransferenciadeotraUTI2023 / totaOI2023 * 100;
                        porcentajeOtros2023 = (double)oicontOtros2023 / totaOI2023 * 100;
                    }

                    #endregion

                    #region causaIngreso


                    int cicontNeurologico2019 = 0;
                    int cicontRespiratorio2019 = 0;
                    int cicontCardiovascular2019 = 0;
                    int cicontGastrointestinal2019 = 0;
                    int cicontRenalEndocrinologico2019 = 0;
                    int cicontOtros2019 = 0;

                    int cicontNeurologico2020 = 0;
                    int cicontRespiratorio2020 = 0;
                    int cicontCardiovascular2020 = 0;
                    int cicontGastrointestinal2020 = 0;
                    int cicontRenalEndocrinologico2020 = 0;
                    int cicontOtros2020 = 0;

                    int cicontNeurologico2021 = 0;
                    int cicontRespiratorio2021 = 0;
                    int cicontCardiovascular2021 = 0;
                    int cicontGastrointestinal2021 = 0;
                    int cicontRenalEndocrinologico2021 = 0;
                    int cicontOtros2021 = 0;

                    int cicontNeurologico2022 = 0;
                    int cicontRespiratorio2022 = 0;
                    int cicontCardiovascular2022 = 0;
                    int cicontGastrointestinal2022 = 0;
                    int cicontRenalEndocrinologico2022 = 0;
                    int cicontOtros2022 = 0;

                    int cicontNeurologico2023 = 0;
                    int cicontRespiratorio2023 = 0;
                    int cicontCardiovascular2023 = 0;
                    int cicontGastrointestinal2023 = 0;
                    int cicontRenalEndocrinologico2023 = 0;
                    int cicontOtros2023 = 0;


                    //NeurolOgico 2019
                    int subNcicontTEC2019 = 0;
                    int subNcicontAVC2019 = 0;
                    int subNcicontEpilepsia2019 = 0;
                    int subNcicontMeningitis2019 = 0;
                    int subNcicontOtros2019 = 0;

                    //Respiratorio 2019
                    int subResciChoqueSeptico_Neumonia2019 = 0;
                    int subResciTEP2019 = 0;
                    int subResciEAP2019 = 0;
                    int subResciAsma_EPOC2019 = 0;
                    int subResciOtros2019 = 0;

                    //Cardiovascular 2019
                    int subCarciChoqueCardiogenico2019 = 0;
                    int subCarciPostOperadoCirugiaCardiaca2019 = 0;
                    int subCarciTaquiarritmiaBradiarritmia2019 = 0;
                    int subCarciCrisisHipertensivas2019 = 0;
                    int subCarciPostParo2019 = 0;
                    int subCarciOtros2019 = 0;

                    //Gastrointestinal 2019
                    int subGasciPancreatitisAguda2019 = 0;
                    int subGasciHemorragiaDigestiva2019 = 0;
                    int subGasciPostOperadosComplicados2019 = 0;
                    int subGasciOtros2019 = 0;







                    //NeurolOgico 2020
                    int subNcicontTEC2020 = 0;
                    int subNcicontAVC2020 = 0;
                    int subNcicontEpilepsia2020 = 0;
                    int subNcicontMeningitis2020 = 0;
                    int subNcicontOtros2020 = 0;


                    //Respiratorio 2020
                    int subResciChoqueSeptico_Neumonia2020 = 0;
                    int subResciTEP2020 = 0;
                    int subResciEAP2020 = 0;
                    int subResciAsma_EPOC2020 = 0;
                    int subResciOtros2020 = 0;

                    //Cardiovascular 2020
                    int subCarciChoqueCardiogenico2020 = 0;
                    int subCarciPostOperadoCirugiaCardiaca2020 = 0;
                    int subCarciTaquiarritmiaBradiarritmia2020 = 0;
                    int subCarciCrisisHipertensivas2020 = 0;
                    int subCarciPostParo2020 = 0;
                    int subCarciOtros2020 = 0;

                    //Gastrointestinal 2020
                    int subGasciPancreatitisAguda2020 = 0;
                    int subGasciHemorragiaDigestiva2020 = 0;
                    int subGasciPostOperadosComplicados2020 = 0;
                    int subGasciOtros2020 = 0;



                    //NeurolOgico 2021
                    int subNcicontTEC2021 = 0;
                    int subNcicontAVC2021 = 0;
                    int subNcicontEpilepsia2021 = 0;
                    int subNcicontMeningitis2021 = 0;
                    int subNcicontOtros2021 = 0;

                    //Respiratorio 2021
                    int subResciChoqueSeptico_Neumonia2021 = 0;
                    int subResciTEP2021 = 0;
                    int subResciEAP2021 = 0;
                    int subResciAsma_EPOC2021 = 0;
                    int subResciOtros2021 = 0;

                    //Cardiovascular 2021
                    int subCarciChoqueCardiogenico2021 = 0;
                    int subCarciPostOperadoCirugiaCardiaca2021 = 0;
                    int subCarciTaquiarritmiaBradiarritmia2021 = 0;
                    int subCarciCrisisHipertensivas2021 = 0;
                    int subCarciPostParo2021 = 0;
                    int subCarciOtros2021 = 0;

                    //Gastrointestinal 2021
                    int subGasciPancreatitisAguda2021 = 0;
                    int subGasciHemorragiaDigestiva2021 = 0;
                    int subGasciPostOperadosComplicados2021 = 0;
                    int subGasciOtros2021 = 0;


                    //NeurolOgico 2022
                    int subNcicontTEC2022 = 0;
                    int subNcicontAVC2022 = 0;
                    int subNcicontEpilepsia2022 = 0;
                    int subNcicontMeningitis2022 = 0;
                    int subNcicontOtros2022 = 0;

                    //Respiratorio 2022
                    int subResciChoqueSeptico_Neumonia2022 = 0;
                    int subResciTEP2022 = 0;
                    int subResciEAP2022 = 0;
                    int subResciAsma_EPOC2022 = 0;
                    int subResciOtros2022 = 0;

                    //Cardiovascular 2022
                    int subCarciChoqueCardiogenico2022 = 0;
                    int subCarciPostOperadoCirugiaCardiaca2022 = 0;
                    int subCarciTaquiarritmiaBradiarritmia2022 = 0;
                    int subCarciCrisisHipertensivas2022 = 0;
                    int subCarciPostParo2022 = 0;
                    int subCarciOtros2022 = 0;

                    //Gastrointestinal 2022
                    int subGasciPancreatitisAguda2022 = 0;
                    int subGasciHemorragiaDigestiva2022 = 0;
                    int subGasciPostOperadosComplicados2022 = 0;
                    int subGasciOtros2022 = 0;

                    //NeurolOgico 2023
                    int subNcicontTEC2023 = 0;
                    int subNcicontAVC2023 = 0;
                    int subNcicontEpilepsia2023 = 0;
                    int subNcicontMeningitis2023 = 0;
                    int subNcicontOtros2023 = 0;

                    //Respiratorio 2023
                    int subResciChoqueSeptico_Neumonia2023 = 0;
                    int subResciTEP2023 = 0;
                    int subResciEAP2023 = 0;
                    int subResciAsma_EPOC2023 = 0;
                    int subResciOtros2023 = 0;

                    //Cardiovascular 2023
                    int subCarciChoqueCardiogenico2023 = 0;
                    int subCarciPostOperadoCirugiaCardiaca2023 = 0;
                    int subCarciTaquiarritmiaBradiarritmia2023 = 0;
                    int subCarciCrisisHipertensivas2023 = 0;
                    int subCarciPostParo2023 = 0;
                    int subCarciOtros2023 = 0;

                    //Gastrointestinal 2023
                    int subGasciPancreatitisAguda2023 = 0;
                    int subGasciHemorragiaDigestiva2023 = 0;
                    int subGasciPostOperadosComplicados2023 = 0;
                    int subGasciOtros2023 = 0;


                    // Inicializar un diccionario para mantener el recuento de cada causa de mortalidad por año
                    Dictionary<int, Dictionary<string, int>> conteoPorAnioCausaIngreso = new Dictionary<int, Dictionary<string, int>>();

                    // Iterar sobre la lista de usuarios
                    foreach (var item in response.lista_usuarios)
                    {
                        DateTime fechaCausaIngreso = DateTime.Parse(item.FechaIngreso); // Suponiendo que FechaMortalidad es de tipo DateTime
                        string causaIngreso = item.CausaIngreso; // Suponiendo que CausaMortalidad es una propiedad que contiene la causa de la mortalidad

                        // Verificar si el año ya está en el diccionario, si no, agregarlo
                        if (!conteoPorAnioCausaIngreso.ContainsKey(fechaCausaIngreso.Year))
                        {
                            conteoPorAnioCausaIngreso[fechaCausaIngreso.Year] = new Dictionary<string, int>();
                        }

                        // Verificar si la causa de mortalidad ya está en el diccionario para ese año, si no, inicializarla
                        if (!conteoPorAnioCausaIngreso[fechaCausaIngreso.Year].ContainsKey(causaIngreso))
                        {
                            conteoPorAnioCausaIngreso[fechaCausaIngreso.Year][causaIngreso] = 0;
                        }

                        // Incrementar el recuento de la causa de mortalidad para ese año
                        conteoPorAnioCausaIngreso[fechaCausaIngreso.Year][causaIngreso]++;
                    }
                    foreach (var kvpAnio in conteoPorAnioCausaIngreso)
                    {
                        int anio = kvpAnio.Key;
                        Dictionary<string, int> conteoPorCausaIngreso = kvpAnio.Value;

                        // Console.WriteLine($"Conteo de causa de mortalidad para el año {anio}:");
                        foreach (var kvpCausaIngreso in conteoPorCausaIngreso)
                        {
                            string categoriaPrincipal = kvpCausaIngreso.Key;
                            int conteo = kvpCausaIngreso.Value;
                            if (anio == 2019)
                            {
                                if (categoriaPrincipal == "NEUROLÓGICO")
                                {
                                    cicontNeurologico2019 = conteo;

                                }
                                else if (categoriaPrincipal == "RESPIRATORIO")
                                {
                                    cicontRespiratorio2019 = conteo;

                                }
                                else if (categoriaPrincipal == "CARDIOVASCULAR")
                                {
                                    cicontCardiovascular2019 = conteo;

                                }
                                else if (categoriaPrincipal == "GASTROINTESTINAL")
                                {
                                    cicontGastrointestinal2019 = conteo;

                                }
                                else if (categoriaPrincipal == "RENAL-ENDOCRINOLÓGICO")
                                {
                                    cicontRenalEndocrinologico2019 = conteo;

                                }
                                else if (categoriaPrincipal == "OTROS")
                                {
                                    cicontOtros2019 = conteo;
                                }
                            }
                            else if (anio == 2020)
                            {
                                if (categoriaPrincipal == "NEUROLÓGICO")
                                {
                                    cicontNeurologico2020 = conteo;

                                }
                                else if (categoriaPrincipal == "RESPIRATORIO")
                                {
                                    cicontRespiratorio2020 = conteo;

                                }
                                else if (categoriaPrincipal == "CARDIOVASCULAR")
                                {
                                    cicontCardiovascular2020 = conteo;

                                }
                                else if (categoriaPrincipal == "GASTROINTESTINAL")
                                {
                                    cicontGastrointestinal2020 = conteo;

                                }
                                else if (categoriaPrincipal == "RENAL-ENDOCRINOLÓGICO")
                                {
                                    cicontRenalEndocrinologico2020 = conteo;

                                }

                                else if (categoriaPrincipal == "OTROS")
                                {
                                    cicontOtros2020 = conteo;
                                }
                            }
                            else if (anio == 2021)
                            {
                                if (categoriaPrincipal == "NEUROLÓGICO")
                                {
                                    cicontNeurologico2021 = conteo;

                                }
                                else if (categoriaPrincipal == "RESPIRATORIO")
                                {
                                    cicontRespiratorio2021 = conteo;

                                }
                                else if (categoriaPrincipal == "CARDIOVASCULAR")
                                {
                                    cicontCardiovascular2021 = conteo;

                                }
                                else if (categoriaPrincipal == "GASTROINTESTINAL")
                                {
                                    cicontGastrointestinal2021 = conteo;

                                }
                                else if (categoriaPrincipal == "RENAL-ENDOCRINOLÓGICO")
                                {
                                    cicontRenalEndocrinologico2021 = conteo;

                                }

                                else if (categoriaPrincipal == "OTROS")
                                {
                                    cicontOtros2021 = conteo;
                                }
                            }
                            else if (anio == 2022)
                            {
                                if (categoriaPrincipal == "NEUROLÓGICO")
                                {
                                    cicontNeurologico2022 = conteo;

                                }
                                else if (categoriaPrincipal == "RESPIRATORIO")
                                {
                                    cicontRespiratorio2022 = conteo;

                                }
                                else if (categoriaPrincipal == "CARDIOVASCULAR")
                                {
                                    cicontCardiovascular2022 = conteo;

                                }
                                else if (categoriaPrincipal == "GASTROINTESTINAL")
                                {
                                    cicontGastrointestinal2022 = conteo;

                                }
                                else if (categoriaPrincipal == "RENAL-ENDOCRINOLÓGICO")
                                {
                                    cicontRenalEndocrinologico2022 = conteo;

                                }

                                else if (categoriaPrincipal == "OTROS")
                                {
                                    cicontOtros2022 = conteo;
                                }
                            }
                            else if (anio == 2023)
                            {
                                if (categoriaPrincipal == "NEUROLÓGICO")
                                {
                                    cicontNeurologico2023 = conteo;

                                }
                                else if (categoriaPrincipal == "RESPIRATORIO")
                                {
                                    cicontRespiratorio2023 = conteo;

                                }
                                else if (categoriaPrincipal == "CARDIOVASCULAR")
                                {
                                    cicontCardiovascular2023 = conteo;

                                }
                                else if (categoriaPrincipal == "GASTROINTESTINAL")
                                {
                                    cicontGastrointestinal2023 = conteo;

                                }
                                else if (categoriaPrincipal == "RENAL-ENDOCRINOLÓGICO")
                                {
                                    cicontRenalEndocrinologico2023 = conteo;

                                }

                                else if (categoriaPrincipal == "OTROS")
                                {
                                    cicontOtros2023 = conteo;
                                }
                            }
                        }

                    }


                    // Inicializar un diccionario para mantener el recuento de cada causa de mortalidad por año
                    Dictionary<int, Dictionary<string, int>> conteoPorAnioSubCausaIngreso = new Dictionary<int, Dictionary<string, int>>();

                    // Iterar sobre la lista de usuarios
                    foreach (var item in response.lista_usuarios)
                    {
                        DateTime fechaSubCausaIngreso = DateTime.Parse(item.FechaIngreso); // Suponiendo que FechaMortalidad es de tipo DateTime
                        string subCausaIngreso = item.SubCausaIngreso; // Suponiendo que CausaMortalidad es una propiedad que contiene la causa de la mortalidad

                        // Verificar si el año ya está en el diccionario, si no, agregarlo
                        if (!conteoPorAnioSubCausaIngreso.ContainsKey(fechaSubCausaIngreso.Year))
                        {
                            conteoPorAnioSubCausaIngreso[fechaSubCausaIngreso.Year] = new Dictionary<string, int>();
                        }

                        // Verificar si la causa de mortalidad ya está en el diccionario para ese año, si no, inicializarla
                        if (!conteoPorAnioSubCausaIngreso[fechaSubCausaIngreso.Year].ContainsKey(subCausaIngreso))
                        {
                            conteoPorAnioSubCausaIngreso[fechaSubCausaIngreso.Year][subCausaIngreso] = 0;
                        }

                        // Incrementar el recuento de la causa de mortalidad para ese año
                        conteoPorAnioSubCausaIngreso[fechaSubCausaIngreso.Year][subCausaIngreso]++;
                    }

                    foreach (var kvpAnio in conteoPorAnioSubCausaIngreso)
                    {
                        int anio = kvpAnio.Key;
                        Dictionary<string, int> conteoPorSubCausaIngreso = kvpAnio.Value;

                        // Console.WriteLine($"Conteo de causa de mortalidad para el año {anio}:");
                        foreach (var kvpSubCausaIngreso in conteoPorSubCausaIngreso)
                        {
                            string subcategoria = kvpSubCausaIngreso.Key;
                            int conteoSubcategoria = kvpSubCausaIngreso.Value;
                            if (anio == 2019)
                            {
                                if (subcategoria == "TEC")
                                {
                                    subNcicontTEC2019 = conteoSubcategoria;
                                }
                                else if (subcategoria == "AVC")
                                {
                                    subNcicontAVC2019 = conteoSubcategoria;
                                }
                                else if (subcategoria == "EPILEPSIA")
                                {
                                    subNcicontEpilepsia2019 = conteoSubcategoria;
                                }
                                else if (subcategoria == "MENINGITIS")
                                {
                                    subNcicontMeningitis2019 = conteoSubcategoria;
                                }
                                else if (subcategoria == "N.OTROS")
                                {
                                    subNcicontOtros2019 = conteoSubcategoria;
                                }
                                else if (subcategoria == "CHOQUE SÉPTICO- NEUMONÍA")
                                {
                                    subResciChoqueSeptico_Neumonia2019 = conteoSubcategoria;
                                }
                                else if (subcategoria == "TEP")
                                {
                                    subResciTEP2019 = conteoSubcategoria;
                                }
                                else if (subcategoria == "EAP")
                                {
                                    subResciEAP2019 = conteoSubcategoria;
                                }
                                else if (subcategoria == "ASMA, EPOC")
                                {
                                    subResciAsma_EPOC2019 = conteoSubcategoria;
                                }
                                else if (subcategoria == "R.OTROS")
                                {
                                    subResciOtros2019 = conteoSubcategoria;
                                }
                                else if (subcategoria == "CHOQUE CARDIOGÉNICO")
                                {
                                    subCarciChoqueCardiogenico2019 = conteoSubcategoria;
                                }
                                else if (subcategoria == "POST OPERADO CIRUGÍA CARDIACA")
                                {
                                    subCarciPostOperadoCirugiaCardiaca2019 = conteoSubcategoria;
                                }
                                else if (subcategoria == "TAQUIARRITMIA- BRADIARRITMIA")
                                {
                                    subCarciTaquiarritmiaBradiarritmia2019 = conteoSubcategoria;
                                }
                                else if (subcategoria == "CRISIS HIPERTENSIVAS")
                                {
                                    subCarciCrisisHipertensivas2019 = conteoSubcategoria;
                                }
                                else if (subcategoria == "POST PARO")
                                {
                                    subCarciPostParo2019 = conteoSubcategoria;
                                }
                                else if (subcategoria == "C.OTROS")
                                {
                                    subCarciOtros2019 = conteoSubcategoria;
                                }
                                else if (subcategoria == "PANCREATITIS AGUDA")
                                {
                                    subGasciPancreatitisAguda2019 = conteoSubcategoria;
                                }
                                else if (subcategoria == "HEMORRAGIA DIGESTIVA")
                                {
                                    subGasciHemorragiaDigestiva2019 = conteoSubcategoria;
                                }
                                else if (subcategoria == "POST OPERADOS COMPLICADOS")
                                {
                                    subGasciPostOperadosComplicados2019 = conteoSubcategoria;
                                }
                                else if (subcategoria == "G.OTROS")
                                {
                                    subGasciOtros2019 = conteoSubcategoria;
                                }
                            }
                            else if (anio == 2020)
                            {
                                if (subcategoria == "TEC")
                                {
                                    subNcicontTEC2020 = conteoSubcategoria;
                                }
                                else if (subcategoria == "AVC")
                                {
                                    subNcicontAVC2020 = conteoSubcategoria;
                                }
                                else if (subcategoria == "EPILEPSIA")
                                {
                                    subNcicontEpilepsia2020 = conteoSubcategoria;
                                }
                                else if (subcategoria == "MENINGITIS")
                                {
                                    subNcicontMeningitis2020 = conteoSubcategoria;
                                }
                                else if (subcategoria == "N.OTROS")
                                {
                                    subNcicontOtros2020 = conteoSubcategoria;
                                }
                                else if (subcategoria == "CHOQUE SÉPTICO- NEUMONÍA")
                                {
                                    subResciChoqueSeptico_Neumonia2020 = conteoSubcategoria;
                                }
                                else if (subcategoria == "TEP")
                                {
                                    subResciTEP2020 = conteoSubcategoria;
                                }
                                else if (subcategoria == "EAP")
                                {
                                    subResciEAP2020 = conteoSubcategoria;
                                }
                                else if (subcategoria == "ASMA, EPOC")
                                {
                                    subResciAsma_EPOC2020 = conteoSubcategoria;
                                }
                                else if (subcategoria == "R.OTROS")
                                {
                                    subResciOtros2020 = conteoSubcategoria;
                                }
                                else if (subcategoria == "CHOQUE CARDIOGÉNICO")
                                {
                                    subCarciChoqueCardiogenico2020 = conteoSubcategoria;
                                }
                                else if (subcategoria == "POST OPERADO CIRUGÍA CARDIACA")
                                {
                                    subCarciPostOperadoCirugiaCardiaca2020 = conteoSubcategoria;
                                }
                                else if (subcategoria == "TAQUIARRITMIA- BRADIARRITMIA")
                                {
                                    subCarciTaquiarritmiaBradiarritmia2020 = conteoSubcategoria;
                                }
                                else if (subcategoria == "CRISIS HIPERTENSIVAS")
                                {
                                    subCarciCrisisHipertensivas2020 = conteoSubcategoria;
                                }
                                else if (subcategoria == "POST PARO")
                                {
                                    subCarciPostParo2020 = conteoSubcategoria;
                                }
                                else if (subcategoria == "C.OTROS")
                                {
                                    subCarciOtros2020 = conteoSubcategoria;
                                }
                                else if (subcategoria == "PANCREATITIS AGUDA")
                                {
                                    subGasciPancreatitisAguda2020 = conteoSubcategoria;
                                }
                                else if (subcategoria == "HEMORRAGIA DIGESTIVA")
                                {
                                    subGasciHemorragiaDigestiva2020 = conteoSubcategoria;
                                }
                                else if (subcategoria == "POST OPERADOS COMPLICADOS")
                                {
                                    subGasciPostOperadosComplicados2020 = conteoSubcategoria;
                                }
                                else if (subcategoria == "G.OTROS")
                                {
                                    subGasciOtros2020 = conteoSubcategoria;
                                }
                            }
                            else if (anio == 2021)
                            {
                                if (subcategoria == "TEC")
                                {
                                    subNcicontTEC2021 = conteoSubcategoria;
                                }
                                else if (subcategoria == "AVC")
                                {
                                    subNcicontAVC2021 = conteoSubcategoria;
                                }
                                else if (subcategoria == "EPILEPSIA")
                                {
                                    subNcicontEpilepsia2021 = conteoSubcategoria;
                                }
                                else if (subcategoria == "MENINGITIS")
                                {
                                    subNcicontMeningitis2021 = conteoSubcategoria;
                                }
                                else if (subcategoria == "N.OTROS")
                                {
                                    subNcicontOtros2021 = conteoSubcategoria;
                                }
                                else if (subcategoria == "CHOQUE SÉPTICO- NEUMONÍA")
                                {
                                    subResciChoqueSeptico_Neumonia2021 = conteoSubcategoria;
                                }
                                else if (subcategoria == "TEP")
                                {
                                    subResciTEP2021 = conteoSubcategoria;
                                }
                                else if (subcategoria == "EAP")
                                {
                                    subResciEAP2021 = conteoSubcategoria;
                                }
                                else if (subcategoria == "ASMA, EPOC")
                                {
                                    subResciAsma_EPOC2021 = conteoSubcategoria;
                                }
                                else if (subcategoria == "R.OTROS")
                                {
                                    subResciOtros2021 = conteoSubcategoria;
                                }
                                else if (subcategoria == "CHOQUE CARDIOGÉNICO")
                                {
                                    subCarciChoqueCardiogenico2021 = conteoSubcategoria;
                                }
                                else if (subcategoria == "POST OPERADO CIRUGÍA CARDIACA")
                                {
                                    subCarciPostOperadoCirugiaCardiaca2021 = conteoSubcategoria;
                                }
                                else if (subcategoria == "TAQUIARRITMIA- BRADIARRITMIA")
                                {
                                    subCarciTaquiarritmiaBradiarritmia2021 = conteoSubcategoria;
                                }
                                else if (subcategoria == "CRISIS HIPERTENSIVAS")
                                {
                                    subCarciCrisisHipertensivas2021 = conteoSubcategoria;
                                }
                                else if (subcategoria == "POST PARO")
                                {
                                    subCarciPostParo2021 = conteoSubcategoria;
                                }
                                else if (subcategoria == "C.OTROS")
                                {
                                    subCarciOtros2021 = conteoSubcategoria;
                                }
                                else if (subcategoria == "PANCREATITIS AGUDA")
                                {
                                    subGasciPancreatitisAguda2021 = conteoSubcategoria;
                                }
                                else if (subcategoria == "HEMORRAGIA DIGESTIVA")
                                {
                                    subGasciHemorragiaDigestiva2021 = conteoSubcategoria;
                                }
                                else if (subcategoria == "POST OPERADOS COMPLICADOS")
                                {
                                    subGasciPostOperadosComplicados2021 = conteoSubcategoria;
                                }
                                else if (subcategoria == "G.OTROS")
                                {
                                    subGasciOtros2021 = conteoSubcategoria;
                                }
                            }
                            else if (anio == 2022)
                            {
                                if (subcategoria == "TEC")
                                {
                                    subNcicontTEC2022 = conteoSubcategoria;
                                }
                                else if (subcategoria == "AVC")
                                {
                                    subNcicontAVC2022 = conteoSubcategoria;
                                }
                                else if (subcategoria == "EPILEPSIA")
                                {
                                    subNcicontEpilepsia2022 = conteoSubcategoria;
                                }
                                else if (subcategoria == "MENINGITIS")
                                {
                                    subNcicontMeningitis2022 = conteoSubcategoria;
                                }
                                else if (subcategoria == "N.OTROS")
                                {
                                    subNcicontOtros2022 = conteoSubcategoria;
                                }
                                else if (subcategoria == "CHOQUE SÉPTICO- NEUMONÍA")
                                {
                                    subResciChoqueSeptico_Neumonia2022 = conteoSubcategoria;
                                }
                                else if (subcategoria == "TEP")
                                {
                                    subResciTEP2022 = conteoSubcategoria;
                                }
                                else if (subcategoria == "EAP")
                                {
                                    subResciEAP2022 = conteoSubcategoria;
                                }
                                else if (subcategoria == "ASMA, EPOC")
                                {
                                    subResciAsma_EPOC2022 = conteoSubcategoria;
                                }
                                else if (subcategoria == "R.OTROS")
                                {
                                    subResciOtros2022 = conteoSubcategoria;
                                }
                                else if (subcategoria == "CHOQUE CARDIOGÉNICO")
                                {
                                    subCarciChoqueCardiogenico2022 = conteoSubcategoria;
                                }
                                else if (subcategoria == "POST OPERADO CIRUGÍA CARDIACA")
                                {
                                    subCarciPostOperadoCirugiaCardiaca2022 = conteoSubcategoria;
                                }
                                else if (subcategoria == "TAQUIARRITMIA- BRADIARRITMIA")
                                {
                                    subCarciTaquiarritmiaBradiarritmia2022 = conteoSubcategoria;
                                }
                                else if (subcategoria == "CRISIS HIPERTENSIVAS")
                                {
                                    subCarciCrisisHipertensivas2022 = conteoSubcategoria;
                                }
                                else if (subcategoria == "POST PARO")
                                {
                                    subCarciPostParo2022 = conteoSubcategoria;
                                }
                                else if (subcategoria == "C.OTROS")
                                {
                                    subCarciOtros2022 = conteoSubcategoria;
                                }
                                else if (subcategoria == "PANCREATITIS AGUDA")
                                {
                                    subGasciPancreatitisAguda2022 = conteoSubcategoria;
                                }
                                else if (subcategoria == "HEMORRAGIA DIGESTIVA")
                                {
                                    subGasciHemorragiaDigestiva2022 = conteoSubcategoria;
                                }
                                else if (subcategoria == "POST OPERADOS COMPLICADOS")
                                {
                                    subGasciPostOperadosComplicados2022 = conteoSubcategoria;
                                }
                                else if (subcategoria == "G.OTROS")
                                {
                                    subGasciOtros2022 = conteoSubcategoria;
                                }
                            }
                            else if (anio == 2023)
                            {
                                if (subcategoria == "TEC")
                                {
                                    subNcicontTEC2023 = conteoSubcategoria;
                                }
                                else if (subcategoria == "AVC")
                                {
                                    subNcicontAVC2023 = conteoSubcategoria;
                                }
                                else if (subcategoria == "EPILEPSIA")
                                {
                                    subNcicontEpilepsia2023 = conteoSubcategoria;
                                }
                                else if (subcategoria == "MENINGITIS")
                                {
                                    subNcicontMeningitis2023 = conteoSubcategoria;
                                }
                                else if (subcategoria == "N.OTROS")
                                {
                                    subNcicontOtros2023 = conteoSubcategoria;
                                }
                                else if (subcategoria == "CHOQUE SÉPTICO- NEUMONÍA")
                                {
                                    subResciChoqueSeptico_Neumonia2023 = conteoSubcategoria;
                                }
                                else if (subcategoria == "TEP")
                                {
                                    subResciTEP2023 = conteoSubcategoria;
                                }
                                else if (subcategoria == "EAP")
                                {
                                    subResciEAP2023 = conteoSubcategoria;
                                }
                                else if (subcategoria == "ASMA, EPOC")
                                {
                                    subResciAsma_EPOC2023 = conteoSubcategoria;
                                }
                                else if (subcategoria == "R.OTROS")
                                {
                                    subResciOtros2023 = conteoSubcategoria;
                                }
                                else if (subcategoria == "CHOQUE CARDIOGÉNICO")
                                {
                                    subCarciChoqueCardiogenico2023 = conteoSubcategoria;
                                }
                                else if (subcategoria == "POST OPERADO CIRUGÍA CARDIACA")
                                {
                                    subCarciPostOperadoCirugiaCardiaca2023 = conteoSubcategoria;
                                }
                                else if (subcategoria == "TAQUIARRITMIA- BRADIARRITMIA")
                                {
                                    subCarciTaquiarritmiaBradiarritmia2023 = conteoSubcategoria;
                                }
                                else if (subcategoria == "CRISIS HIPERTENSIVAS")
                                {
                                    subCarciCrisisHipertensivas2023 = conteoSubcategoria;
                                }
                                else if (subcategoria == "POST PARO")
                                {
                                    subCarciPostParo2023 = conteoSubcategoria;
                                }
                                else if (subcategoria == "C.OTROS")
                                {
                                    subCarciOtros2023 = conteoSubcategoria;
                                }
                                else if (subcategoria == "PANCREATITIS AGUDA")
                                {
                                    subGasciPancreatitisAguda2023 = conteoSubcategoria;
                                }
                                else if (subcategoria == "HEMORRAGIA DIGESTIVA")
                                {
                                    subGasciHemorragiaDigestiva2023 = conteoSubcategoria;
                                }
                                else if (subcategoria == "POST OPERADOS COMPLICADOS")
                                {
                                    subGasciPostOperadosComplicados2023 = conteoSubcategoria;
                                }
                                else if (subcategoria == "G.OTROS")
                                {
                                    subGasciOtros2023 = conteoSubcategoria;
                                }
                            }



                        }
                    }


                    //Global Categorias
                    int cicontNeurologicoTotal = cicontNeurologico2019+ cicontNeurologico2020+ cicontNeurologico2021+ cicontNeurologico2022+ cicontNeurologico2023;
                    int cicontRespiratorioTotal = cicontRespiratorio2019+ cicontRespiratorio2020+ cicontRespiratorio2021+ cicontRespiratorio2022+ cicontRespiratorio2023;
                    int cicontCardiovascularTotal = cicontCardiovascular2019+cicontCardiovascular2020+cicontCardiovascular2021+ cicontCardiovascular2022+ cicontCardiovascular2023;
                    int cicontGastrointestinalTotal = cicontGastrointestinal2019+ cicontGastrointestinal2020+ cicontGastrointestinal2021+ cicontGastrointestinal2022+ cicontGastrointestinal2023;
                    int cicontRenalEndocrinologicoTotal = cicontRenalEndocrinologico2019+ cicontRenalEndocrinologico2020+ cicontRenalEndocrinologico2021+ cicontRenalEndocrinologico2022+ cicontRenalEndocrinologico2023;
                    int cicontOtrosTotal = cicontOtros2019+ cicontOtros2020+ cicontOtros2021+ cicontOtros2022+ cicontOtros2023;

                    int ciTotalCategoria = cicontNeurologicoTotal + cicontRespiratorioTotal + cicontCardiovascularTotal + cicontGastrointestinalTotal  + cicontRenalEndocrinologicoTotal + cicontOtrosTotal;

                    double ciporcentajecicontNeurologicoTotal = 0;
                    double ciporcentajecicontRespiratorioTotal = 0;
                    double ciporcentajecicontCardiovascularTotal = 0;
                    double ciporcentajecicontGastrointestinalTotal = 0;
                    double ciporcentajecicontRenalEndocrinologicoTotal = 0;
                    double ciporcentajecicontOtrosTotal = 0;
                    if (ciTotalCategoria!=0) 
                    {
                         ciporcentajecicontNeurologicoTotal = (double)cicontNeurologicoTotal / ciTotalCategoria * 100;
                         ciporcentajecicontRespiratorioTotal = (double)cicontRespiratorioTotal / ciTotalCategoria * 100;
                         ciporcentajecicontCardiovascularTotal = (double)cicontCardiovascularTotal / ciTotalCategoria * 100;
                         ciporcentajecicontGastrointestinalTotal = (double)cicontGastrointestinalTotal / ciTotalCategoria * 100;
                         ciporcentajecicontRenalEndocrinologicoTotal = (double)cicontRenalEndocrinologicoTotal / ciTotalCategoria * 100;
                         ciporcentajecicontOtrosTotal = (double)cicontOtrosTotal / ciTotalCategoria * 100;
                    }


                    //Categorias por año
                    //2019
                    int totaCI2019 = cicontNeurologico2019 + cicontRespiratorio2019 + cicontCardiovascular2019 + cicontGastrointestinal2019 + cicontRenalEndocrinologico2019+cicontOtros2019;
                    double ciporcentajecicontNeurologico2019 = 0;
                    double ciporcentajecicontRespiratorio2019 = 0;
                    double ciporcentajecicontCardiovascular2019 = 0;
                    double ciporcentajecicontGastrointestinal2019 = 0;
                    double ciporcentajecicontRenalEndocrinologico2019 = 0;
                    double ciporcentajecicontOtros2019 = 0;

                    if (totaCI2019 != 0)
                    {
                         ciporcentajecicontNeurologico2019 = (double)cicontNeurologico2019 / totaCI2019 * 100;
                         ciporcentajecicontRespiratorio2019 = (double)cicontRespiratorio2019 / totaCI2019 * 100;
                         ciporcentajecicontCardiovascular2019 = (double)cicontCardiovascular2019 / totaCI2019 * 100;
                         ciporcentajecicontGastrointestinal2019 = (double)cicontGastrointestinal2019 / totaCI2019 * 100;
                         ciporcentajecicontRenalEndocrinologico2019 = (double)cicontRenalEndocrinologico2019 / totaCI2019 * 100;
                         ciporcentajecicontOtros2019 = (double)cicontOtros2019 / totaCI2019 * 100;
                    }
                    //2020

                    int totaCI2020 = cicontNeurologico2020 + cicontRespiratorio2020 + cicontCardiovascular2020 + cicontGastrointestinal2020 + cicontRenalEndocrinologico2020 + cicontOtros2020;
                    double ciporcentajecicontNeurologico2020 = 0;
                    double ciporcentajecicontRespiratorio2020 = 0;
                    double ciporcentajecicontCardiovascular2020 = 0;
                    double ciporcentajecicontGastrointestinal2020 = 0;
                    double ciporcentajecicontRenalEndocrinologico2020 = 0;
                    double ciporcentajecicontOtros2020 = 0;

                    if (totaCI2020 != 0)
                    {
                        ciporcentajecicontNeurologico2020 = (double)cicontNeurologico2020 / totaCI2020 * 100;
                        ciporcentajecicontRespiratorio2020 = (double)cicontRespiratorio2020 / totaCI2020 * 100;
                        ciporcentajecicontCardiovascular2020 = (double)cicontCardiovascular2020 / totaCI2020 * 100;
                        ciporcentajecicontGastrointestinal2020 = (double)cicontGastrointestinal2020 / totaCI2020 * 100;
                        ciporcentajecicontRenalEndocrinologico2020 = (double)cicontRenalEndocrinologico2020 / totaCI2020 * 100;
                        ciporcentajecicontOtros2020 = (double)cicontOtros2020 / totaCI2020 * 100;
                    }
                    //2021
                    int totaCI2021 = cicontNeurologico2021 + cicontRespiratorio2021 + cicontCardiovascular2021 + cicontGastrointestinal2021 + cicontRenalEndocrinologico2021 + cicontOtros2021;
                    double ciporcentajecicontNeurologico2021 = 0;
                    double ciporcentajecicontRespiratorio2021 = 0;
                    double ciporcentajecicontCardiovascular2021 = 0;
                    double ciporcentajecicontGastrointestinal2021 = 0;
                    double ciporcentajecicontRenalEndocrinologico2021 = 0;
                    double ciporcentajecicontOtros2021 = 0;

                    if (totaCI2021 != 0)
                    {
                        ciporcentajecicontNeurologico2021 = (double)cicontNeurologico2021 / totaCI2021 * 100;
                        ciporcentajecicontRespiratorio2021 = (double)cicontRespiratorio2021 / totaCI2021 * 100;
                        ciporcentajecicontCardiovascular2021 = (double)cicontCardiovascular2021 / totaCI2021 * 100;
                        ciporcentajecicontGastrointestinal2021 = (double)cicontGastrointestinal2021 / totaCI2021 * 100;
                        ciporcentajecicontRenalEndocrinologico2021 = (double)cicontRenalEndocrinologico2021 / totaCI2021 * 100;
                        ciporcentajecicontOtros2021 = (double)cicontOtros2021 / totaCI2021 * 100;
                    }
                    //2022
                    int totaCI2022 = cicontNeurologico2022 + cicontRespiratorio2022 + cicontCardiovascular2022 + cicontGastrointestinal2022 + cicontRenalEndocrinologico2022 + cicontOtros2022;
                    double ciporcentajecicontNeurologico2022 = 0;
                    double ciporcentajecicontRespiratorio2022 = 0;
                    double ciporcentajecicontCardiovascular2022 = 0;
                    double ciporcentajecicontGastrointestinal2022 = 0;
                    double ciporcentajecicontRenalEndocrinologico2022 = 0;
                    double ciporcentajecicontOtros2022 = 0;

                    if (totaCI2022 != 0)
                    {
                        ciporcentajecicontNeurologico2022 = (double)cicontNeurologico2022 / totaCI2022 * 100;
                        ciporcentajecicontRespiratorio2022 = (double)cicontRespiratorio2022 / totaCI2022 * 100;
                        ciporcentajecicontCardiovascular2022 = (double)cicontCardiovascular2022 / totaCI2022 * 100;
                        ciporcentajecicontGastrointestinal2022 = (double)cicontGastrointestinal2022 / totaCI2022 * 100;
                        ciporcentajecicontRenalEndocrinologico2022 = (double)cicontRenalEndocrinologico2022 / totaCI2022 * 100;
                        ciporcentajecicontOtros2022 = (double)cicontOtros2022 / totaCI2022 * 100;
                    }
                    //2023
                    int totaCI2023 = cicontNeurologico2023 + cicontRespiratorio2023 + cicontCardiovascular2023 + cicontGastrointestinal2023 + cicontRenalEndocrinologico2023 + cicontOtros2023;
                    double ciporcentajecicontNeurologico2023 = 0;
                    double ciporcentajecicontRespiratorio2023 = 0;
                    double ciporcentajecicontCardiovascular2023 = 0;
                    double ciporcentajecicontGastrointestinal2023 = 0;
                    double ciporcentajecicontRenalEndocrinologico2023 = 0;
                    double ciporcentajecicontOtros2023 = 0;

                    if (totaCI2023 != 0)
                    {
                        ciporcentajecicontNeurologico2023 = (double)cicontNeurologico2023 / totaCI2023 * 100;
                        ciporcentajecicontRespiratorio2023 = (double)cicontRespiratorio2023 / totaCI2023 * 100;
                        ciporcentajecicontCardiovascular2023 = (double)cicontCardiovascular2023 / totaCI2023 * 100;
                        ciporcentajecicontGastrointestinal2023 = (double)cicontGastrointestinal2023 / totaCI2023 * 100;
                        ciporcentajecicontRenalEndocrinologico2023 = (double)cicontRenalEndocrinologico2023 / totaCI2023 * 100;
                        ciporcentajecicontOtros2023 = (double)cicontOtros2023 / totaCI2023 * 100;
                    }


                    //Subcategorias Global

                    //NeurolOgico Total
                    int subNcicontTECTotal = subNcicontTEC2019+ subNcicontTEC2020+ subNcicontTEC2021+ subNcicontTEC2022+ subNcicontTEC2023;
                    int subNcicontAVCTotal = subNcicontAVC2019+ subNcicontAVC2020+ subNcicontAVC2021+ subNcicontAVC2022+ subNcicontAVC2023;
                    int subNcicontEpilepsiaTotal = subNcicontEpilepsia2019+ subNcicontEpilepsia2020+ subNcicontEpilepsia2021+ subNcicontEpilepsia2022+ subNcicontEpilepsia2023;
                    int subNcicontMeningitisTotal = subNcicontMeningitis2019+ subNcicontMeningitis2020+ subNcicontMeningitis2021+ subNcicontMeningitis2022+ subNcicontMeningitis2023;
                    int subNcicontOtrosTotal = subNcicontOtros2019+ subNcicontOtros2020+ subNcicontOtros2021+ subNcicontOtros2022+ subNcicontOtros2023;

                    double subporcentajesubNcicontTECTotal = 0;
                    double subporcentajesubNcicontAVCTotal = 0;
                    double subporcentajesubNcicontEpilepsiaTotal = 0;
                    double subporcentajesubNcicontMeningitisTotal = 0;
                    double subporcentajesubNcicontOtrosTotal = 0;
                    if (cicontNeurologicoTotal!=0) 
                    {
                         subporcentajesubNcicontTECTotal = (double)subNcicontTECTotal / cicontNeurologicoTotal * 100;
                         subporcentajesubNcicontAVCTotal = (double)subNcicontAVCTotal / cicontNeurologicoTotal * 100;
                         subporcentajesubNcicontEpilepsiaTotal = (double)subNcicontEpilepsiaTotal / cicontNeurologicoTotal * 100;
                         subporcentajesubNcicontMeningitisTotal = (double)subNcicontMeningitisTotal / cicontNeurologicoTotal * 100;
                         subporcentajesubNcicontOtrosTotal = (double)subNcicontOtrosTotal / cicontNeurologicoTotal * 100;
                    }
                    

                    //Respiratorio Total
                    int subResciChoqueSeptico_NeumoniaTotal = subResciChoqueSeptico_Neumonia2019+ subResciChoqueSeptico_Neumonia2020+ subResciChoqueSeptico_Neumonia2021+ subResciChoqueSeptico_Neumonia2022+ subResciChoqueSeptico_Neumonia2023;
                    int subResciTEPTotal = subResciTEP2019+ subResciTEP2020+ subResciTEP2021+ subResciTEP2022+ subResciTEP2023;
                    int subResciEAPTotal = subResciEAP2019+ subResciEAP2020+ subResciEAP2021+ subResciEAP2022+ subResciEAP2023;
                    int subResciAsma_EPOCTotal = subResciAsma_EPOC2019+ subResciAsma_EPOC2020+ subResciAsma_EPOC2021+ subResciAsma_EPOC2022+ subResciAsma_EPOC2023;
                    int subResciOtrosTotal = subResciOtros2019+ subResciOtros2020+ subResciOtros2021+ subResciOtros2022+ subResciOtros2023;

                    double subporcentajesubResciChoqueSeptico_NeumoniaTotal = 0;
                    double subporcentajesubResciTEPTotal = 0;
                    double subporcentajesubResciEAPTotal = 0;
                    double subporcentajesubResciAsma_EPOCTotal = 0;
                    double subporcentajesubResciOtrosTotal = 0;
                    if (cicontRespiratorioTotal != 0)
                    {
                        subporcentajesubResciChoqueSeptico_NeumoniaTotal = (double)subResciChoqueSeptico_NeumoniaTotal / cicontRespiratorioTotal * 100;
                        subporcentajesubResciTEPTotal = (double)subResciTEPTotal / cicontRespiratorioTotal * 100;
                        subporcentajesubResciEAPTotal = (double)subResciEAPTotal / cicontRespiratorioTotal * 100;
                        subporcentajesubResciAsma_EPOCTotal = (double)subResciAsma_EPOCTotal / cicontRespiratorioTotal * 100;
                        subporcentajesubResciOtrosTotal = (double)subResciOtrosTotal / cicontRespiratorioTotal * 100;
                    }
                    //Cardiovascular Total
                    int subCarciChoqueCardiogenicoTotal = subCarciChoqueCardiogenico2019+ subCarciChoqueCardiogenico2020+ subCarciChoqueCardiogenico2021+ subCarciChoqueCardiogenico2022+ subCarciChoqueCardiogenico2023;
                    int subCarciPostOperadoCirugiaCardiacaTotal = subCarciPostOperadoCirugiaCardiaca2019+ subCarciPostOperadoCirugiaCardiaca2020+ subCarciPostOperadoCirugiaCardiaca2021+ subCarciPostOperadoCirugiaCardiaca2022+ subCarciPostOperadoCirugiaCardiaca2023;
                    int subCarciTaquiarritmiaBradiarritmiaTotal = subCarciTaquiarritmiaBradiarritmia2019+ subCarciTaquiarritmiaBradiarritmia2020+ subCarciTaquiarritmiaBradiarritmia2021+ subCarciTaquiarritmiaBradiarritmia2022+ subCarciTaquiarritmiaBradiarritmia2023;
                    int subCarciCrisisHipertensivasTotal = subCarciCrisisHipertensivas2019+ subCarciCrisisHipertensivas2020+ subCarciCrisisHipertensivas2021+ subCarciCrisisHipertensivas2022+ subCarciCrisisHipertensivas2023;
                    int subCarciPostParoTotal = subCarciPostParo2019+ subCarciPostParo2020+ subCarciPostParo2021+ subCarciPostParo2022+ subCarciPostParo2023;
                    int subCarciOtrosTotal = subCarciOtros2019+ subCarciOtros2020+ subCarciOtros2021+ subCarciOtros2022+ subCarciOtros2023;
                    
                    double subporcentajesubCarciChoqueCardiogenicoTotal = 0;
                    double subporcentajesubCarciPostOperadoCirugiaCardiacaTotal = 0;
                    double subporcentajesubCarciTaquiarritmiaBradiarritmiaTotal = 0;
                    double subporcentajesubCarciCrisisHipertensivasTotal = 0;
                    double subporcentajesubCarciPostParoTotal = 0;
                    double subporcentajesubCarciOtrosTotal = 0;

                    if (cicontCardiovascularTotal!=0) 
                    {
                         subporcentajesubCarciChoqueCardiogenicoTotal = (double)subCarciChoqueCardiogenicoTotal / cicontCardiovascularTotal * 100;
                         subporcentajesubCarciPostOperadoCirugiaCardiacaTotal = (double)subCarciPostOperadoCirugiaCardiacaTotal / cicontCardiovascularTotal * 100;
                         subporcentajesubCarciTaquiarritmiaBradiarritmiaTotal = (double)subCarciTaquiarritmiaBradiarritmiaTotal / cicontCardiovascularTotal * 100;
                         subporcentajesubCarciCrisisHipertensivasTotal = (double)subCarciCrisisHipertensivasTotal / cicontCardiovascularTotal * 100;
                         subporcentajesubCarciPostParoTotal = (double)subCarciPostParoTotal / cicontCardiovascularTotal * 100;
                         subporcentajesubCarciOtrosTotal = (double)subCarciOtrosTotal / cicontCardiovascularTotal * 100;
                    }
                    //Gastrointestinal Total
                    int subGasciPancreatitisAgudaTotal = subGasciPancreatitisAguda2019+ subGasciPancreatitisAguda2020+ subGasciPancreatitisAguda2021+ subGasciPancreatitisAguda2022+ subGasciPancreatitisAguda2023;
                    int subGasciHemorragiaDigestivaTotal = subGasciHemorragiaDigestiva2019+ subGasciHemorragiaDigestiva2020+ subGasciHemorragiaDigestiva2021+ subGasciHemorragiaDigestiva2022+ subGasciHemorragiaDigestiva2023;
                    int subGasciPostOperadosComplicadosTotal = subGasciPostOperadosComplicados2019+ subGasciPostOperadosComplicados2020+ subGasciPostOperadosComplicados2021+ subGasciPostOperadosComplicados2022+ subGasciPostOperadosComplicados2023;
                    int subGasciOtrosTotal = subGasciOtros2019+ subGasciOtros2020+ subGasciOtros2021+ subGasciOtros2022+ subGasciOtros2023;
                    
                    double subporcentajesubGasciPancreatitisAgudaTotal = 0;
                    double subporcentajesubsubGasciHemorragiaDigestivaTotal = 0;
                    double subporcentajesubGasciPostOperadosComplicadosTotal = 0;
                    double subporcentajesubGasciOtrosTotal = 0;
                    if (cicontGastrointestinalTotal != 0)
                    {
                         subporcentajesubGasciPancreatitisAgudaTotal = (double)subGasciPancreatitisAgudaTotal / cicontGastrointestinalTotal * 100;
                         subporcentajesubsubGasciHemorragiaDigestivaTotal = (double)subGasciHemorragiaDigestivaTotal / cicontGastrointestinalTotal * 100;
                         subporcentajesubGasciPostOperadosComplicadosTotal = (double)subGasciPostOperadosComplicadosTotal / cicontGastrointestinalTotal * 100;
                         subporcentajesubGasciOtrosTotal = (double)subGasciOtrosTotal / cicontGastrointestinalTotal * 100;
                    }

                    //Subcategorias por año


                    //NeurolOgico 2019                    
                    double porcentajesubNcicontTEC2019 = 0;
                    double porcentajesubNcicontAVC2019 = 0;
                    double porcentajesubNcicontEpilepsia2019 = 0;
                    double porcentajesubNcicontMeningitis2019 = 0;
                    double porcentajesubNcicontOtros2019 = 0;
                    if (cicontNeurologico2019!=0) 
                    {
                         porcentajesubNcicontTEC2019 = (double)subNcicontTEC2019 / cicontNeurologico2019 * 100;
                         porcentajesubNcicontAVC2019 = (double)subNcicontAVC2019 / cicontNeurologico2019 * 100;
                         porcentajesubNcicontEpilepsia2019 = (double)subNcicontEpilepsia2019 / cicontNeurologico2019 * 100;
                         porcentajesubNcicontMeningitis2019 = (double)subNcicontMeningitis2019 / cicontNeurologico2019 * 100;
                         porcentajesubNcicontOtros2019 = (double)subNcicontOtros2019 / cicontNeurologico2019 * 100;
                    }
                    //Respiratorio 2019
                    double porcentajesubResciChoqueSeptico_Neumonia2019 = 0;
                    double porcentajesubResciTEP2019 = 0;
                    double porcentajesubResciEAP2019 = 0;
                    double porcentajesubResciAsma_EPOC2019 = 0;
                    double porcentajesubResciOtros2019 = 0;
                    if (cicontRespiratorio2019 != 0)
                    {
                         porcentajesubResciChoqueSeptico_Neumonia2019 = (double)subResciChoqueSeptico_Neumonia2019 / cicontRespiratorio2019 * 100;
                         porcentajesubResciTEP2019 = (double)subResciTEP2019 / cicontRespiratorio2019 * 100;
                         porcentajesubResciEAP2019 = (double)subResciEAP2019 / cicontRespiratorio2019 * 100;
                         porcentajesubResciAsma_EPOC2019 = (double)subResciAsma_EPOC2019 / cicontRespiratorio2019 * 100;
                         porcentajesubResciOtros2019 = (double)subResciOtros2019 / cicontRespiratorio2019 * 100;
                    }
                    //Cardiovascular 2019
                    double porcentajesubCarciChoqueCardiogenico2019 = 0;
                    double porcentajesubCarciPostOperadoCirugiaCardiaca2019 = 0;
                    double porcentajesubCarciTaquiarritmiaBradiarritmia2019 = 0;
                    double porcentajesubCarciCrisisHipertensivas2019 = 0;
                    double porcentajesubCarciPostParo2019 = 0;
                    double porcentajesubCarciOtros2019 = 0;
                    if (cicontCardiovascular2019 != 0)
                    {
                         porcentajesubCarciChoqueCardiogenico2019 = (double)subCarciChoqueCardiogenico2019 / cicontCardiovascular2019 * 100;
                         porcentajesubCarciPostOperadoCirugiaCardiaca2019 = (double)subCarciPostOperadoCirugiaCardiaca2019 / cicontCardiovascular2019 * 100;
                         porcentajesubCarciTaquiarritmiaBradiarritmia2019 = (double)subCarciTaquiarritmiaBradiarritmia2019 / cicontCardiovascular2019 * 100;
                         porcentajesubCarciCrisisHipertensivas2019 = (double)subCarciCrisisHipertensivas2019 / cicontCardiovascular2019 * 100;
                         porcentajesubCarciPostParo2019 = (double)subCarciPostParo2019 / cicontCardiovascular2019 * 100;
                         porcentajesubCarciOtros2019 = (double)subCarciOtros2019 / cicontCardiovascular2019 * 100;
                    }
                    //Gastrointestinal 2019
                    double porcentajesubGasciPancreatitisAguda2019 = 0;
                    double porcentajesubGasciHemorragiaDigestiva2019 = 0;
                    double porcentajesubGasciPostOperadosComplicados2019 = 0;
                    double porcentajesubGasciOtros2019 = 0;
                    if (cicontGastrointestinal2019 != 0)
                    {
                         porcentajesubGasciPancreatitisAguda2019 = (double)subGasciPancreatitisAguda2019 / cicontGastrointestinal2019 * 100;
                         porcentajesubGasciHemorragiaDigestiva2019 = (double)subGasciHemorragiaDigestiva2019 / cicontGastrointestinal2019 * 100;
                         porcentajesubGasciPostOperadosComplicados2019 = (double)subGasciPostOperadosComplicados2019 / cicontGastrointestinal2019 * 100;
                         porcentajesubGasciOtros2019 = (double)subGasciOtros2019 / cicontGastrointestinal2019 * 100;
                    }



                    //NeurolOgico 2020                    
                    double porcentajesubNcicontTEC2020 = 0;
                    double porcentajesubNcicontAVC2020 = 0;
                    double porcentajesubNcicontEpilepsia2020 = 0;
                    double porcentajesubNcicontMeningitis2020 = 0;
                    double porcentajesubNcicontOtros2020 = 0;
                    if (cicontNeurologico2020 != 0)
                    {
                        porcentajesubNcicontTEC2020 = (double)subNcicontTEC2020 / cicontNeurologico2020 * 100;
                        porcentajesubNcicontAVC2020 = (double)subNcicontAVC2020 / cicontNeurologico2020 * 100;
                        porcentajesubNcicontEpilepsia2020 = (double)subNcicontEpilepsia2020 / cicontNeurologico2020 * 100;
                        porcentajesubNcicontMeningitis2020 = (double)subNcicontMeningitis2020 / cicontNeurologico2020 * 100;
                        porcentajesubNcicontOtros2020 = (double)subNcicontOtros2020 / cicontNeurologico2020 * 100;
                    }
                    //Respiratorio 2020
                    double porcentajesubResciChoqueSeptico_Neumonia2020 = 0;
                    double porcentajesubResciTEP2020 = 0;
                    double porcentajesubResciEAP2020 = 0;
                    double porcentajesubResciAsma_EPOC2020 = 0;
                    double porcentajesubResciOtros2020 = 0;
                    if (cicontRespiratorio2020 != 0)
                    {
                        porcentajesubResciChoqueSeptico_Neumonia2020 = (double)subResciChoqueSeptico_Neumonia2020 / cicontRespiratorio2020 * 100;
                        porcentajesubResciTEP2020 = (double)subResciTEP2020 / cicontRespiratorio2020 * 100;
                        porcentajesubResciEAP2020 = (double)subResciEAP2020 / cicontRespiratorio2020 * 100;
                        porcentajesubResciAsma_EPOC2020 = (double)subResciAsma_EPOC2020 / cicontRespiratorio2020 * 100;
                        porcentajesubResciOtros2020 = (double)subResciOtros2020 / cicontRespiratorio2020 * 100;
                    }
                    //Cardiovascular 2020
                    double porcentajesubCarciChoqueCardiogenico2020 = 0;
                    double porcentajesubCarciPostOperadoCirugiaCardiaca2020 = 0;
                    double porcentajesubCarciTaquiarritmiaBradiarritmia2020 = 0;
                    double porcentajesubCarciCrisisHipertensivas2020 = 0;
                    double porcentajesubCarciPostParo2020 = 0;
                    double porcentajesubCarciOtros2020 = 0;
                    if (cicontCardiovascular2020 != 0)
                    {
                        porcentajesubCarciChoqueCardiogenico2020 = (double)subCarciChoqueCardiogenico2020 / cicontCardiovascular2020 * 100;
                        porcentajesubCarciPostOperadoCirugiaCardiaca2020 = (double)subCarciPostOperadoCirugiaCardiaca2020 / cicontCardiovascular2020 * 100;
                        porcentajesubCarciTaquiarritmiaBradiarritmia2020 = (double)subCarciTaquiarritmiaBradiarritmia2020 / cicontCardiovascular2020 * 100;
                        porcentajesubCarciCrisisHipertensivas2020 = (double)subCarciCrisisHipertensivas2020 / cicontCardiovascular2020 * 100;
                        porcentajesubCarciPostParo2020 = (double)subCarciPostParo2020 / cicontCardiovascular2020 * 100;
                        porcentajesubCarciOtros2020 = (double)subCarciOtros2020 / cicontCardiovascular2020 * 100;
                    }
                    //Gastrointestinal 2020
                    double porcentajesubGasciPancreatitisAguda2020 = 0;
                    double porcentajesubGasciHemorragiaDigestiva2020 = 0;
                    double porcentajesubGasciPostOperadosComplicados2020 = 0;
                    double porcentajesubGasciOtros2020 = 0;
                    if (cicontGastrointestinal2020 != 0)
                    {
                        porcentajesubGasciPancreatitisAguda2020 = (double)subGasciPancreatitisAguda2020 / cicontGastrointestinal2020 * 100;
                        porcentajesubGasciHemorragiaDigestiva2020 = (double)subGasciHemorragiaDigestiva2020 / cicontGastrointestinal2020 * 100;
                        porcentajesubGasciPostOperadosComplicados2020 = (double)subGasciPostOperadosComplicados2020 / cicontGastrointestinal2020 * 100;
                        porcentajesubGasciOtros2020 = (double)subGasciOtros2020 / cicontGastrointestinal2020 * 100;
                    }

                    //NeurolOgico 2021                    
                    double porcentajesubNcicontTEC2021 = 0;
                    double porcentajesubNcicontAVC2021 = 0;
                    double porcentajesubNcicontEpilepsia2021 = 0;
                    double porcentajesubNcicontMeningitis2021 = 0;
                    double porcentajesubNcicontOtros2021 = 0;
                    if (cicontNeurologico2021 != 0)
                    {
                        porcentajesubNcicontTEC2021 = (double)subNcicontTEC2021 / cicontNeurologico2021 * 100;
                        porcentajesubNcicontAVC2021 = (double)subNcicontAVC2021 / cicontNeurologico2021 * 100;
                        porcentajesubNcicontEpilepsia2021 = (double)subNcicontEpilepsia2021 / cicontNeurologico2021 * 100;
                        porcentajesubNcicontMeningitis2021 = (double)subNcicontMeningitis2021 / cicontNeurologico2021 * 100;
                        porcentajesubNcicontOtros2021 = (double)subNcicontOtros2021 / cicontNeurologico2021 * 100;
                    }
                    //Respiratorio 2021
                    double porcentajesubResciChoqueSeptico_Neumonia2021 = 0;
                    double porcentajesubResciTEP2021 = 0;
                    double porcentajesubResciEAP2021 = 0;
                    double porcentajesubResciAsma_EPOC2021 = 0;
                    double porcentajesubResciOtros2021 = 0;
                    if (cicontRespiratorio2021 != 0)
                    {
                        porcentajesubResciChoqueSeptico_Neumonia2021 = (double)subResciChoqueSeptico_Neumonia2021 / cicontRespiratorio2021 * 100;
                        porcentajesubResciTEP2021 = (double)subResciTEP2021 / cicontRespiratorio2021 * 100;
                        porcentajesubResciEAP2021 = (double)subResciEAP2021 / cicontRespiratorio2021 * 100;
                        porcentajesubResciAsma_EPOC2021 = (double)subResciAsma_EPOC2021 / cicontRespiratorio2021 * 100;
                        porcentajesubResciOtros2021 = (double)subResciOtros2021 / cicontRespiratorio2021 * 100;
                    }
                    //Cardiovascular 2021
                    double porcentajesubCarciChoqueCardiogenico2021 = 0;
                    double porcentajesubCarciPostOperadoCirugiaCardiaca2021 = 0;
                    double porcentajesubCarciTaquiarritmiaBradiarritmia2021 = 0;
                    double porcentajesubCarciCrisisHipertensivas2021 = 0;
                    double porcentajesubCarciPostParo2021 = 0;
                    double porcentajesubCarciOtros2021 = 0;
                    if (cicontCardiovascular2021 != 0)
                    {
                        porcentajesubCarciChoqueCardiogenico2021 = (double)subCarciChoqueCardiogenico2021 / cicontCardiovascular2021 * 100;
                        porcentajesubCarciPostOperadoCirugiaCardiaca2021 = (double)subCarciPostOperadoCirugiaCardiaca2021 / cicontCardiovascular2021 * 100;
                        porcentajesubCarciTaquiarritmiaBradiarritmia2021 = (double)subCarciTaquiarritmiaBradiarritmia2021 / cicontCardiovascular2021 * 100;
                        porcentajesubCarciCrisisHipertensivas2021 = (double)subCarciCrisisHipertensivas2021 / cicontCardiovascular2021 * 100;
                        porcentajesubCarciPostParo2021 = (double)subCarciPostParo2021 / cicontCardiovascular2021 * 100;
                        porcentajesubCarciOtros2021 = (double)subCarciOtros2021 / cicontCardiovascular2021 * 100;
                    }
                    //Gastrointestinal 2021
                    double porcentajesubGasciPancreatitisAguda2021 = 0;
                    double porcentajesubGasciHemorragiaDigestiva2021 = 0;
                    double porcentajesubGasciPostOperadosComplicados2021 = 0;
                    double porcentajesubGasciOtros2021 = 0;
                    if (cicontGastrointestinal2021 != 0)
                    {
                        porcentajesubGasciPancreatitisAguda2021 = (double)subGasciPancreatitisAguda2021 / cicontGastrointestinal2021 * 100;
                        porcentajesubGasciHemorragiaDigestiva2021 = (double)subGasciHemorragiaDigestiva2021 / cicontGastrointestinal2021 * 100;
                        porcentajesubGasciPostOperadosComplicados2021 = (double)subGasciPostOperadosComplicados2021 / cicontGastrointestinal2021 * 100;
                        porcentajesubGasciOtros2021 = (double)subGasciOtros2021 / cicontGastrointestinal2021 * 100;
                    }

                    //NeurolOgico 2022                    
                    double porcentajesubNcicontTEC2022 = 0;
                    double porcentajesubNcicontAVC2022 = 0;
                    double porcentajesubNcicontEpilepsia2022 = 0;
                    double porcentajesubNcicontMeningitis2022 = 0;
                    double porcentajesubNcicontOtros2022 = 0;
                    if (cicontNeurologico2022 != 0)
                    {
                        porcentajesubNcicontTEC2022 = (double)subNcicontTEC2022 / cicontNeurologico2022 * 100;
                        porcentajesubNcicontAVC2022 = (double)subNcicontAVC2022 / cicontNeurologico2022 * 100;
                        porcentajesubNcicontEpilepsia2022 = (double)subNcicontEpilepsia2022 / cicontNeurologico2022 * 100;
                        porcentajesubNcicontMeningitis2022 = (double)subNcicontMeningitis2022 / cicontNeurologico2022 * 100;
                        porcentajesubNcicontOtros2022 = (double)subNcicontOtros2022 / cicontNeurologico2022 * 100;
                    }
                    //Respiratorio 2022
                    double porcentajesubResciChoqueSeptico_Neumonia2022 = 0;
                    double porcentajesubResciTEP2022 = 0;
                    double porcentajesubResciEAP2022 = 0;
                    double porcentajesubResciAsma_EPOC2022 = 0;
                    double porcentajesubResciOtros2022 = 0;
                    if (cicontRespiratorio2022 != 0)
                    {
                        porcentajesubResciChoqueSeptico_Neumonia2022 = (double)subResciChoqueSeptico_Neumonia2022 / cicontRespiratorio2022 * 100;
                        porcentajesubResciTEP2022 = (double)subResciTEP2022 / cicontRespiratorio2022 * 100;
                        porcentajesubResciEAP2022 = (double)subResciEAP2022 / cicontRespiratorio2022 * 100;
                        porcentajesubResciAsma_EPOC2022 = (double)subResciAsma_EPOC2022 / cicontRespiratorio2022 * 100;
                        porcentajesubResciOtros2022 = (double)subResciOtros2022 / cicontRespiratorio2022 * 100;
                    }
                    //Cardiovascular 2022
                    double porcentajesubCarciChoqueCardiogenico2022 = 0;
                    double porcentajesubCarciPostOperadoCirugiaCardiaca2022 = 0;
                    double porcentajesubCarciTaquiarritmiaBradiarritmia2022 = 0;
                    double porcentajesubCarciCrisisHipertensivas2022 = 0;
                    double porcentajesubCarciPostParo2022 = 0;
                    double porcentajesubCarciOtros2022 = 0;
                    if (cicontCardiovascular2022 != 0)
                    {
                        porcentajesubCarciChoqueCardiogenico2022 = (double)subCarciChoqueCardiogenico2022 / cicontCardiovascular2022 * 100;
                        porcentajesubCarciPostOperadoCirugiaCardiaca2022 = (double)subCarciPostOperadoCirugiaCardiaca2022 / cicontCardiovascular2022 * 100;
                        porcentajesubCarciTaquiarritmiaBradiarritmia2022 = (double)subCarciTaquiarritmiaBradiarritmia2022 / cicontCardiovascular2022 * 100;
                        porcentajesubCarciCrisisHipertensivas2022 = (double)subCarciCrisisHipertensivas2022 / cicontCardiovascular2022 * 100;
                        porcentajesubCarciPostParo2022 = (double)subCarciPostParo2022 / cicontCardiovascular2022 * 100;
                        porcentajesubCarciOtros2022 = (double)subCarciOtros2022 / cicontCardiovascular2022 * 100;
                    }
                    //Gastrointestinal 2022
                    double porcentajesubGasciPancreatitisAguda2022 = 0;
                    double porcentajesubGasciHemorragiaDigestiva2022 = 0;
                    double porcentajesubGasciPostOperadosComplicados2022 = 0;
                    double porcentajesubGasciOtros2022 = 0;
                    if (cicontGastrointestinal2022 != 0)
                    {
                        porcentajesubGasciPancreatitisAguda2022 = (double)subGasciPancreatitisAguda2022 / cicontGastrointestinal2022 * 100;
                        porcentajesubGasciHemorragiaDigestiva2022 = (double)subGasciHemorragiaDigestiva2022 / cicontGastrointestinal2022 * 100;
                        porcentajesubGasciPostOperadosComplicados2022 = (double)subGasciPostOperadosComplicados2022 / cicontGastrointestinal2022 * 100;
                        porcentajesubGasciOtros2022 = (double)subGasciOtros2022 / cicontGastrointestinal2022 * 100;
                    }
                    //NeurolOgico 2023                    
                    double porcentajesubNcicontTEC2023 = 0;
                    double porcentajesubNcicontAVC2023 = 0;
                    double porcentajesubNcicontEpilepsia2023 = 0;
                    double porcentajesubNcicontMeningitis2023 = 0;
                    double porcentajesubNcicontOtros2023 = 0;
                    if (cicontNeurologico2023 != 0)
                    {
                        porcentajesubNcicontTEC2023 = (double)subNcicontTEC2023 / cicontNeurologico2023 * 100;
                        porcentajesubNcicontAVC2023 = (double)subNcicontAVC2023 / cicontNeurologico2023 * 100;
                        porcentajesubNcicontEpilepsia2023 = (double)subNcicontEpilepsia2023 / cicontNeurologico2023 * 100;
                        porcentajesubNcicontMeningitis2023 = (double)subNcicontMeningitis2023 / cicontNeurologico2023 * 100;
                        porcentajesubNcicontOtros2023 = (double)subNcicontOtros2023 / cicontNeurologico2023 * 100;
                    }
                    //Respiratorio 2023
                    double porcentajesubResciChoqueSeptico_Neumonia2023 = 0;
                    double porcentajesubResciTEP2023 = 0;
                    double porcentajesubResciEAP2023 = 0;
                    double porcentajesubResciAsma_EPOC2023 = 0;
                    double porcentajesubResciOtros2023 = 0;
                    if (cicontRespiratorio2023 != 0)
                    {
                        porcentajesubResciChoqueSeptico_Neumonia2023 = (double)subResciChoqueSeptico_Neumonia2023 / cicontRespiratorio2023 * 100;
                        porcentajesubResciTEP2023 = (double)subResciTEP2023 / cicontRespiratorio2023 * 100;
                        porcentajesubResciEAP2023 = (double)subResciEAP2023 / cicontRespiratorio2023 * 100;
                        porcentajesubResciAsma_EPOC2023 = (double)subResciAsma_EPOC2023 / cicontRespiratorio2023 * 100;
                        porcentajesubResciOtros2023 = (double)subResciOtros2023 / cicontRespiratorio2023 * 100;
                    }
                    //Cardiovascular 2023
                    double porcentajesubCarciChoqueCardiogenico2023 = 0;
                    double porcentajesubCarciPostOperadoCirugiaCardiaca2023 = 0;
                    double porcentajesubCarciTaquiarritmiaBradiarritmia2023 = 0;
                    double porcentajesubCarciCrisisHipertensivas2023 = 0;
                    double porcentajesubCarciPostParo2023 = 0;
                    double porcentajesubCarciOtros2023 = 0;
                    if (cicontCardiovascular2023 != 0)
                    {
                        porcentajesubCarciChoqueCardiogenico2023 = (double)subCarciChoqueCardiogenico2023 / cicontCardiovascular2023 * 100;
                        porcentajesubCarciPostOperadoCirugiaCardiaca2023 = (double)subCarciPostOperadoCirugiaCardiaca2023 / cicontCardiovascular2023 * 100;
                        porcentajesubCarciTaquiarritmiaBradiarritmia2023 = (double)subCarciTaquiarritmiaBradiarritmia2023 / cicontCardiovascular2023 * 100;
                        porcentajesubCarciCrisisHipertensivas2023 = (double)subCarciCrisisHipertensivas2023 / cicontCardiovascular2023 * 100;
                        porcentajesubCarciPostParo2023 = (double)subCarciPostParo2023 / cicontCardiovascular2023 * 100;
                        porcentajesubCarciOtros2023 = (double)subCarciOtros2023 / cicontCardiovascular2023 * 100;
                    }
                    //Gastrointestinal 2023
                    double porcentajesubGasciPancreatitisAguda2023 = 0;
                    double porcentajesubGasciHemorragiaDigestiva2023 = 0;
                    double porcentajesubGasciPostOperadosComplicados2023 = 0;
                    double porcentajesubGasciOtros2023 = 0;
                    if (cicontGastrointestinal2023 != 0)
                    {
                        porcentajesubGasciPancreatitisAguda2023 = (double)subGasciPancreatitisAguda2023 / cicontGastrointestinal2023 * 100;
                        porcentajesubGasciHemorragiaDigestiva2023 = (double)subGasciHemorragiaDigestiva2023 / cicontGastrointestinal2023 * 100;
                        porcentajesubGasciPostOperadosComplicados2023 = (double)subGasciPostOperadosComplicados2023 / cicontGastrointestinal2023 * 100;
                        porcentajesubGasciOtros2023 = (double)subGasciOtros2023 / cicontGastrointestinal2023 * 100;
                    }


                    #endregion

                    #region Servicio Egreso
                    int secontSalacomun2019 = 0;
                    int secontTerapia_intermedia2019 = 0;
                    int secontAlta_hospitalaria2019 = 0;
                    int secontFallece2019 = 0;

                    int secontSalacomun2020 = 0;
                    int secontTerapia_intermedia2020 = 0;
                    int secontAlta_hospitalaria2020 = 0;
                    int secontFallece2020 = 0;

                    int secontSalacomun2021 = 0;
                    int secontTerapia_intermedia2021 = 0;
                    int secontAlta_hospitalaria2021 = 0;
                    int secontFallece2021 = 0;

                    int secontSalacomun2022 = 0;
                    int secontTerapia_intermedia2022 = 0;
                    int secontAlta_hospitalaria2022 = 0;
                    int secontFallece2022 = 0;

                    int secontSalacomun2023 = 0;
                    int secontTerapia_intermedia2023 = 0;
                    int secontAlta_hospitalaria2023 = 0;
                    int secontFallece2023 = 0;


                    // Inicializar un diccionario para mantener el recuento de cada tipo de servicio de egreso por año
                    Dictionary<int, Dictionary<string, int>> conteoPorAnoServicioEgreso = new Dictionary<int, Dictionary<string, int>>();

                    // Iterar sobre la lista de usuarios
                    foreach (var item in response.lista_usuarios)
                    {
                        DateTime fechaEgreso = DateTime.Parse(item.FechaEgreso); // Suponiendo que FechaEgreso es de tipo DateTime
                        string servicioEgreso = item.ServicioEgreso; // Suponiendo que ServicioEgreso es una propiedad que contiene el tipo de servicio de egreso

                        // Verificar si el año ya está en el diccionario, si no, agregarlo
                        if (!conteoPorAnoServicioEgreso.ContainsKey(fechaEgreso.Year))
                        {
                            conteoPorAnoServicioEgreso[fechaEgreso.Year] = new Dictionary<string, int>();
                        }

                        // Verificar si el tipo de servicio de egreso ya está en el diccionario para ese año, si no, inicializarlo
                        if (!conteoPorAnoServicioEgreso[fechaEgreso.Year].ContainsKey(servicioEgreso))
                        {
                            conteoPorAnoServicioEgreso[fechaEgreso.Year][servicioEgreso] = 0;
                        }

                        // Incrementar el recuento del tipo de servicio de egreso para ese año
                        conteoPorAnoServicioEgreso[fechaEgreso.Year][servicioEgreso]++;
                    }

                    // Ahora tienes el conteo de cada tipo de servicio de egreso por año en el diccionario conteoPorAñoServicioEgreso
                    // Iterar sobre el diccionario conteoPorAñoServicioEgreso y mostrar los resultados
                    foreach (var kvpAnio in conteoPorAnoServicioEgreso)
                    {
                        int anio = kvpAnio.Key;
                        Dictionary<string, int> conteoPorServicioEgreso = kvpAnio.Value;

                        //Console.WriteLine($"Conteo de servicio de egreso para el año {año}:");
                        foreach (var kvpServicioEgreso in conteoPorServicioEgreso)
                        {
                            string servicioEgreso = kvpServicioEgreso.Key;
                            int conteo = kvpServicioEgreso.Value;
                            //Console.WriteLine($"- {servicioEgreso}: {conteo}");



                            if (anio == 2019)
                            {

                                if (servicioEgreso == "SALA COMÚN")
                                {
                                    secontSalacomun2019 = conteo;

                                }
                                else if (servicioEgreso == "TERAPIA INTERMEDIA")
                                {
                                    secontTerapia_intermedia2019 = conteo;

                                }
                                else if (servicioEgreso == "ALTA HOSPITALARIA")
                                {
                                    secontAlta_hospitalaria2019 = conteo;

                                }
                                else if (servicioEgreso == "FALLECE")
                                {

                                    secontFallece2019 = conteo;

                                }
                                

                            }
                            else if (anio == 2020)
                            {
                                if (servicioEgreso == "SALA COMÚN")
                                {
                                    secontSalacomun2020 = conteo;

                                }
                                else if (servicioEgreso == "TERAPIA INTERMEDIA")
                                {
                                    secontTerapia_intermedia2020 = conteo;

                                }
                                else if (servicioEgreso == "ALTA HOSPITALARIA")
                                {
                                    secontAlta_hospitalaria2020 = conteo;

                                }
                                else if (servicioEgreso == "FALLECE")
                                {

                                    secontFallece2020 = conteo;

                                }
                            }
                            else if (anio == 2021)
                            {
                                if (servicioEgreso == "SALA COMÚN")
                                {
                                    secontSalacomun2021 = conteo;

                                }
                                else if (servicioEgreso == "TERAPIA INTERMEDIA")
                                {
                                    secontTerapia_intermedia2021 = conteo;

                                }
                                else if (servicioEgreso == "ALTA HOSPITALARIA")
                                {
                                    secontAlta_hospitalaria2021 = conteo;

                                }
                                else if (servicioEgreso == "FALLECE")
                                {

                                    secontFallece2021 = conteo;

                                }
                            }
                            else if (anio == 2022)
                            {
                                if (servicioEgreso == "SALA COMÚN")
                                {
                                    secontSalacomun2022 = conteo;

                                }
                                else if (servicioEgreso == "TERAPIA INTERMEDIA")
                                {
                                    secontTerapia_intermedia2022 = conteo;

                                }
                                else if (servicioEgreso == "ALTA HOSPITALARIA")
                                {
                                    secontAlta_hospitalaria2022 = conteo;

                                }
                                else if (servicioEgreso == "FALLECE")
                                {

                                    secontFallece2022 = conteo;

                                }
                            }
                            else if (anio == 2023)
                            {
                                if (servicioEgreso == "SALA COMÚN")
                                {
                                    secontSalacomun2023 = conteo;

                                }
                                else if (servicioEgreso == "TERAPIA INTERMEDIA")
                                {
                                    secontTerapia_intermedia2023 = conteo;

                                }
                                else if (servicioEgreso == "ALTA HOSPITALARIA")
                                {
                                    secontAlta_hospitalaria2023 = conteo;

                                }
                                else if (servicioEgreso == "FALLECE")
                                {

                                    secontFallece2023 = conteo;

                                }
                            }
                        }
                        //Console.WriteLine(); // Espacio en blanco entre años
                    }


                    //TOTALgLOVALES
                    int secontSalacomunGlobal = secontSalacomun2019 + secontSalacomun2020 + secontSalacomun2021 + secontSalacomun2022 + secontSalacomun2023;
                    int secontTerapia_intermediaGlobal = secontTerapia_intermedia2019 + secontTerapia_intermedia2020 + secontTerapia_intermedia2021 + secontTerapia_intermedia2022 + secontTerapia_intermedia2023;
                    int secontAlta_hospitalariaGlobal= secontAlta_hospitalaria2019+ secontAlta_hospitalaria2020+ secontAlta_hospitalaria2021+ secontAlta_hospitalaria2022+ secontAlta_hospitalaria2023;
                    int secontFalleceGlobal = secontFallece2019+ secontFallece2020+ secontFallece2021+ secontFallece2022+ secontFallece2023;

                    int seTotalGlobales = secontSalacomunGlobal + secontTerapia_intermediaGlobal + secontAlta_hospitalariaGlobal + secontFalleceGlobal;
                   
                    
                    double seporcentajeSalacomunGlobal = 0;
                    double seporcentajeTerapia_intermediaGlobal = 0;
                    double seporcentajeAlta_hospitalariaGlobal = 0;
                    double seporcentajeFalleceGlobal = 0;
                    if (seTotalGlobales != 0)
                    {
                        seporcentajeSalacomunGlobal = (double)secontSalacomunGlobal / seTotalGlobales * 100;
                        seporcentajeTerapia_intermediaGlobal = (double)secontTerapia_intermediaGlobal / seTotalGlobales * 100;
                        seporcentajeAlta_hospitalariaGlobal = (double)secontAlta_hospitalariaGlobal / seTotalGlobales * 100;
                        seporcentajeFalleceGlobal = (double)secontFalleceGlobal / seTotalGlobales * 100;
                    }


                    //Individuales
                    int secontall2019 = secontSalacomun2019 + secontTerapia_intermedia2019 +secontAlta_hospitalaria2019 +secontFallece2019;

                    double seporcentajeSalacomun2019 = 0;
                    double seporcentajeTerapia_intermedia2019 = 0;
                    double seporcentajeAlta_hospitalaria2019 = 0;
                    double seporcentajeFallece2019 = 0;
                    if (secontall2019 != 0) 
                    {
                        seporcentajeSalacomun2019 = (double)secontSalacomun2019 / secontall2019 * 100;
                        seporcentajeTerapia_intermedia2019 = (double)secontTerapia_intermedia2019 / secontall2019 * 100;
                        seporcentajeAlta_hospitalaria2019 = (double)secontAlta_hospitalaria2019 / secontall2019 * 100;
                        seporcentajeFallece2019 = (double)secontFallece2019 / secontall2019 * 100;
                    }

                    int secontall2020 = secontSalacomun2020 + secontTerapia_intermedia2020 + secontAlta_hospitalaria2020 + secontFallece2020;

                    double seporcentajeSalacomun2020 = 0;
                    double seporcentajeTerapia_intermedia2020 = 0;
                    double seporcentajeAlta_hospitalaria2020 = 0;
                    double seporcentajeFallece2020 = 0;
                    if (secontall2020 != 0)
                    {
                        seporcentajeSalacomun2020 = (double)secontSalacomun2020 / secontall2020 * 100;
                        seporcentajeTerapia_intermedia2020 = (double)secontTerapia_intermedia2020 / secontall2020 * 100;
                        seporcentajeAlta_hospitalaria2020 = (double)secontAlta_hospitalaria2020 / secontall2020 * 100;
                        seporcentajeFallece2020 = (double)secontFallece2020 / secontall2020 * 100;
                    }

                    int secontall2021 = secontSalacomun2021 + secontTerapia_intermedia2021 + secontAlta_hospitalaria2021 + secontFallece2021;

                    double seporcentajeSalacomun2021 = 0;
                    double seporcentajeTerapia_intermedia2021 = 0;
                    double seporcentajeAlta_hospitalaria2021 = 0;
                    double seporcentajeFallece2021 = 0;
                    if (secontall2021 != 0)
                    {
                        seporcentajeSalacomun2021 = (double)secontSalacomun2021 / secontall2021 * 100;
                        seporcentajeTerapia_intermedia2021 = (double)secontTerapia_intermedia2021 / secontall2021 * 100;
                        seporcentajeAlta_hospitalaria2021 = (double)secontAlta_hospitalaria2021 / secontall2021 * 100;
                        seporcentajeFallece2021 = (double)secontFallece2021 / secontall2021 * 100;
                    }

                    int secontall2022 = secontSalacomun2022 + secontTerapia_intermedia2022 + secontAlta_hospitalaria2022 + secontFallece2022;

                    double seporcentajeSalacomun2022 = 0;
                    double seporcentajeTerapia_intermedia2022 = 0;
                    double seporcentajeAlta_hospitalaria2022 = 0;
                    double seporcentajeFallece2022 = 0;
                    if (secontall2022 != 0)
                    {
                        seporcentajeSalacomun2022 = (double)secontSalacomun2022 / secontall2022 * 100;
                        seporcentajeTerapia_intermedia2022 = (double)secontTerapia_intermedia2022 / secontall2022 * 100;
                        seporcentajeAlta_hospitalaria2022 = (double)secontAlta_hospitalaria2022 / secontall2022 * 100;
                        seporcentajeFallece2022 = (double)secontFallece2022 / secontall2022 * 100;
                    }

                    int secontall2023 = secontSalacomun2023 + secontTerapia_intermedia2023 + secontAlta_hospitalaria2023 + secontFallece2023;

                    double seporcentajeSalacomun2023 = 0;
                    double seporcentajeTerapia_intermedia2023 = 0;
                    double seporcentajeAlta_hospitalaria2023 = 0;
                    double seporcentajeFallece2023 = 0;
                    if (secontall2023 != 0)
                    {
                        seporcentajeSalacomun2023 = (double)secontSalacomun2023 / secontall2023 * 100;
                        seporcentajeTerapia_intermedia2023 = (double)secontTerapia_intermedia2023 / secontall2023 * 100;
                        seporcentajeAlta_hospitalaria2023 = (double)secontAlta_hospitalaria2023 / secontall2023 * 100;
                        seporcentajeFallece2023 = (double)secontFallece2023 / secontall2023 * 100;
                    }
                    #endregion

                    #region Causa de Mortalidad

                    int cmNeurologico2019 = 0;
                    int cmRespiratorio2019 = 0;
                    int cmCardiovascular2019 = 0;
                    int cmGastrointestinal2019 = 0;
                    int cmRenalEndocrinologico2019 = 0;
                    int cmFallaMultiorganica2019 = 0;
                    int cmOtros2019 = 0;
                    int cmNoFallecidos2019 = 0;

                    int cmNeurologico2020 = 0;
                    int cmRespiratorio2020 = 0;
                    int cmCardiovascular2020 = 0;
                    int cmGastrointestinal2020 = 0;
                    int cmRenalEndocrinologico2020 = 0;
                    int cmFallaMultiorganica2020 = 0;
                    int cmOtros2020 = 0;
                    int cmNoFallecidos2020 = 0;

                    int cmNeurologico2021 = 0;
                    int cmRespiratorio2021 = 0;
                    int cmCardiovascular2021 = 0;
                    int cmGastrointestinal2021 = 0;
                    int cmRenalEndocrinologico2021 = 0;
                    int cmFallaMultiorganica2021 = 0;
                    int cmOtros2021 = 0;
                    int cmNoFallecidos2021 = 0;

                    int cmNeurologico2022 = 0;
                    int cmRespiratorio2022 = 0;
                    int cmCardiovascular2022 = 0;
                    int cmGastrointestinal2022 = 0;
                    int cmRenalEndocrinologico2022 = 0;
                    int cmFallaMultiorganica2022 = 0;
                    int cmOtros2022 = 0;
                    int cmNoFallecidos2022 = 0;


                    int cmNeurologico2023 = 0;
                    int cmRespiratorio2023 = 0;
                    int cmCardiovascular2023 = 0;
                    int cmGastrointestinal2023 = 0;
                    int cmRenalEndocrinologico2023 = 0;
                    int cmFallaMultiorganica2023 = 0;
                    int cmOtros2023 = 0;
                    int cmNoFallecidos2023 = 0;


                    // Inicializar un diccionario para mantener el recuento de cada causa de mortalidad por año
                    Dictionary<int, Dictionary<string, int>> conteoPorAnoCausaMortalidad = new Dictionary<int, Dictionary<string, int>>();

                    // Iterar sobre la lista de usuarios
                    foreach (var item in response.lista_usuarios)
                    {
                        DateTime fechaMortalidad = DateTime.Parse(item.FechaEgreso); // Suponiendo que FechaMortalidad es de tipo DateTime
                        string causaMortalidad = item.CausaMortalidad; // Suponiendo que CausaMortalidad es una propiedad que contiene la causa de la mortalidad

                        // Verificar si el año ya está en el diccionario, si no, agregarlo
                        if (!conteoPorAnoCausaMortalidad.ContainsKey(fechaMortalidad.Year))
                        {
                            conteoPorAnoCausaMortalidad[fechaMortalidad.Year] = new Dictionary<string, int>();
                        }

                        // Verificar si la causa de mortalidad ya está en el diccionario para ese año, si no, inicializarla
                        if (!conteoPorAnoCausaMortalidad[fechaMortalidad.Year].ContainsKey(causaMortalidad))
                        {
                            conteoPorAnoCausaMortalidad[fechaMortalidad.Year][causaMortalidad] = 0;
                        }

                        // Incrementar el recuento de la causa de mortalidad para ese año
                        conteoPorAnoCausaMortalidad[fechaMortalidad.Year][causaMortalidad]++;
                    }

                    // Ahora tienes el conteo de cada causa de mortalidad por año en el diccionario conteoPorAñoCausaMortalidad
                    // Iterar sobre el diccionario conteoPorAñoCausaMortalidad y mostrar los resultados
                    foreach (var kvpAnio in conteoPorAnoCausaMortalidad)
                    {
                        int anio = kvpAnio.Key;
                        Dictionary<string, int> conteoPorCausaMortalidad = kvpAnio.Value;

                       // Console.WriteLine($"Conteo de causa de mortalidad para el año {año}:");
                        foreach (var kvpCausaMortalidad in conteoPorCausaMortalidad)
                        {
                            string causaMortalidad = kvpCausaMortalidad.Key;
                            int conteo = kvpCausaMortalidad.Value;
                            //Console.WriteLine($"- {causaMortalidad}: {conteo}");


                            if (anio == 2019)
                            {
                                
                                if (causaMortalidad == "NEUROLÓGICO")
                                {
                                    cmNeurologico2019= conteo;
                                }
                                else if (causaMortalidad == "RESPIRATORIO")
                                {
                                    cmRespiratorio2019 = conteo;                                   
                                }
                                else if (causaMortalidad == "CARDIOVASCULAR")
                                {
                                    cmCardiovascular2019 = conteo;
                                                                    
                                }
                                else if (causaMortalidad == "GASTROINTESTINAL")
                                {
                                    cmGastrointestinal2019 = conteo;
                                                                 
                                }
                                else if (causaMortalidad == "RENAL-ENDOCRINOLÓGICO")
                                {
                                    cmRenalEndocrinologico2019 = conteo;                                    
                                }
                                else if (causaMortalidad == "FALLA MULTIORGANICA")
                                {
                                    cmFallaMultiorganica2019 = conteo;                                  
                                }
                                else if (causaMortalidad == "OTROS")
                                {
                                    cmOtros2019 = conteo;
                                }
                                else 
                                {
                                    cmNoFallecidos2019 = conteo;
                                }


                            }
                            else if (anio == 2020)
                            {
                                if (causaMortalidad == "NEUROLÓGICO")
                                {
                                    cmNeurologico2020 = conteo;
                                }
                                else if (causaMortalidad == "RESPIRATORIO")
                                {
                                    cmRespiratorio2020 = conteo;
                                }
                                else if (causaMortalidad == "CARDIOVASCULAR")
                                {
                                    cmCardiovascular2020 = conteo;

                                }
                                else if (causaMortalidad == "GASTROINTESTINAL")
                                {
                                    cmGastrointestinal2020 = conteo;

                                }
                                else if (causaMortalidad == "RENAL-ENDOCRINOLÓGICO")
                                {
                                    cmRenalEndocrinologico2020 = conteo;
                                }
                                else if (causaMortalidad == "FALLA MULTIORGANICA")
                                {
                                    cmFallaMultiorganica2020 = conteo;
                                }
                                else if (causaMortalidad == "OTROS")
                                {
                                    cmOtros2020 = conteo;
                                }
                                else
                                {
                                    cmNoFallecidos2020 = conteo;
                                }

                            }
                            else if (anio == 2021)
                            {
                                if (causaMortalidad == "NEUROLÓGICO")
                                {
                                    cmNeurologico2021 = conteo;
                                }
                                else if (causaMortalidad == "RESPIRATORIO")
                                {
                                    cmRespiratorio2021 = conteo;
                                }
                                else if (causaMortalidad == "CARDIOVASCULAR")
                                {
                                    cmCardiovascular2021 = conteo;

                                }
                                else if (causaMortalidad == "GASTROINTESTINAL")
                                {
                                    cmGastrointestinal2021 = conteo;

                                }
                                else if (causaMortalidad == "RENAL-ENDOCRINOLÓGICO")
                                {
                                    cmRenalEndocrinologico2021 = conteo;
                                }
                                else if (causaMortalidad == "FALLA MULTIORGANICA")
                                {
                                    cmFallaMultiorganica2021 = conteo;
                                }
                                else if (causaMortalidad == "OTROS")
                                {
                                    cmOtros2021 = conteo;
                                }
                                else
                                {
                                    cmNoFallecidos2021 = conteo;
                                }
                            }
                            else if (anio == 2022)
                            {
                                if (causaMortalidad == "NEUROLÓGICO")
                                {
                                    cmNeurologico2022 = conteo;
                                }
                                else if (causaMortalidad == "RESPIRATORIO")
                                {
                                    cmRespiratorio2022 = conteo;
                                }
                                else if (causaMortalidad == "CARDIOVASCULAR")
                                {
                                    cmCardiovascular2022 = conteo;

                                }
                                else if (causaMortalidad == "GASTROINTESTINAL")
                                {
                                    cmGastrointestinal2022 = conteo;

                                }
                                else if (causaMortalidad == "RENAL-ENDOCRINOLÓGICO")
                                {
                                    cmRenalEndocrinologico2022 = conteo;
                                }
                                else if (causaMortalidad == "FALLA MULTIORGANICA")
                                {
                                    cmFallaMultiorganica2022 = conteo;
                                }
                                else if (causaMortalidad == "OTROS")
                                {
                                    cmOtros2022 = conteo;
                                }
                                else
                                {
                                    cmNoFallecidos2022 = conteo;
                                }
                            }
                            else if (anio == 2023)
                            {
                                if (causaMortalidad == "NEUROLÓGICO")
                                {
                                    cmNeurologico2023 = conteo;
                                }
                                else if (causaMortalidad == "RESPIRATORIO")
                                {
                                    cmRespiratorio2023 = conteo;
                                }
                                else if (causaMortalidad == "CARDIOVASCULAR")
                                {
                                    cmCardiovascular2023 = conteo;

                                }
                                else if (causaMortalidad == "GASTROINTESTINAL")
                                {
                                    cmGastrointestinal2023 = conteo;

                                }
                                else if (causaMortalidad == "RENAL-ENDOCRINOLÓGICO")
                                {
                                    cmRenalEndocrinologico2023 = conteo;
                                }
                                else if (causaMortalidad == "FALLA MULTIORGANICA")
                                {
                                    cmFallaMultiorganica2023 = conteo;
                                }
                                else if (causaMortalidad == "OTROS")
                                {
                                    cmOtros2023 = conteo;
                                }
                                else
                                {
                                    cmNoFallecidos2023 = conteo;
                                }

                            }


                        }
                        //Console.WriteLine(); // Espacio en blanco entre años
                    }


                    
                    //Global causa de mortalidad
                    int cmNeurologicoGlobal = cmNeurologico2019 + cmNeurologico2020 + cmNeurologico2021 + cmNeurologico2022 + cmNeurologico2023;
                    int cmRespiratorioGlobal = cmRespiratorio2019 + cmRespiratorio2020 + cmRespiratorio2021 + cmRespiratorio2022 + cmRespiratorio2023;
                    int cmCardiovascularGlobal = cmCardiovascular2019 + cmCardiovascular2020 + cmCardiovascular2021 + cmCardiovascular2022 + cmCardiovascular2023;
                    int cmGastrointestinalGlobal = cmGastrointestinal2019 + cmGastrointestinal2020 + cmGastrointestinal2021 + cmGastrointestinal2022 + cmGastrointestinal2023;
                    int cmRenalEndocrinologicoGlobal = cmRenalEndocrinologico2019 + cmRenalEndocrinologico2020 + cmRenalEndocrinologico2021 + cmRenalEndocrinologico2022 + cmRenalEndocrinologico2023;
                    int cmFallaMultiorganicaGlobal = cmFallaMultiorganica2019 + cmFallaMultiorganica2020 + cmFallaMultiorganica2021 + cmFallaMultiorganica2022 + cmFallaMultiorganica2023;
                    int cmOtrosGlobal = cmOtros2019 + cmOtros2020 + cmOtros2021 + cmOtros2022 + cmOtros2023;
                    int cmNoFallecidosGlobal = cmNoFallecidos2019 + cmNoFallecidos2020 + cmNoFallecidos2021 + cmNoFallecidos2022 + cmNoFallecidos2023;


                    int cmTotalGlobal = cmNeurologicoGlobal + cmRespiratorioGlobal + cmCardiovascularGlobal + cmGastrointestinalGlobal + cmRenalEndocrinologicoGlobal+ cmFallaMultiorganicaGlobal+ cmOtrosGlobal+ cmNoFallecidosGlobal;

                    double cmporcentajeNeurologicosGlobal = 0;
                    double cmporcentajeRespiratorioGlobal = 0;
                    double cmporcentajeCardiovascularGlobal = 0;
                    double cmporcentajeGastrointestinalGlobal = 0;
                    double cmporcentajeEndocrinologicoGlobal = 0;
                    double cmporcentajeFallaMultiorganicaGlobal = 0;
                    double cmporcentajeOtrosGlobal = 0;
                    double cmporcentajeNoFallecidosGlobal = 0;
                    if (cmTotalGlobal != 0)
                    {
                        cmporcentajeNeurologicosGlobal = (double)cmNeurologicoGlobal / cmTotalGlobal * 100;
                        cmporcentajeRespiratorioGlobal = (double)cmRespiratorioGlobal / cmTotalGlobal * 100;
                        cmporcentajeCardiovascularGlobal = (double)cmCardiovascularGlobal / cmTotalGlobal * 100;
                        cmporcentajeGastrointestinalGlobal = (double)cmGastrointestinalGlobal / cmTotalGlobal * 100;
                        cmporcentajeEndocrinologicoGlobal = (double)cmRenalEndocrinologicoGlobal / cmTotalGlobal * 100;
                        cmporcentajeFallaMultiorganicaGlobal = (double)cmFallaMultiorganicaGlobal / cmTotalGlobal * 100;
                        cmporcentajeOtrosGlobal = (double)cmOtrosGlobal / cmTotalGlobal * 100;
                        cmporcentajeNoFallecidosGlobal = (double)cmNoFallecidosGlobal / cmTotalGlobal * 100;
                    }
                    //Individual
                    //2019
                    int cmTotal2019 = cmNeurologico2019 + cmRespiratorio2019 + cmCardiovascular2019 + cmGastrointestinal2019+ cmRenalEndocrinologico2019+ cmFallaMultiorganica2019+ cmOtros2019+ cmNoFallecidos2019;
                    double cmporcentajeNeurologicos2019 = 0;
                    double cmporcentajeRespiratorio2019 = 0;
                    double cmporcentajeCardiovascular2019 = 0;
                    double cmporcentajeGastrointestinal2019 = 0;
                    double cmporcentajeEndocrinologico2019 = 0;
                    double cmporcentajeFallaMultiorganica2019 = 0;
                    double cmporcentajeOtros2019 = 0;
                    double cmporcentajeNoFallecidos2019 = 0;
                    if (cmTotal2019 != 0)
                    {
                        cmporcentajeNeurologicos2019 = (double)cmNeurologico2019 / cmTotal2019 * 100;
                        cmporcentajeRespiratorio2019 = (double)cmRespiratorio2019 / cmTotal2019 * 100;
                        cmporcentajeCardiovascular2019 = (double)cmCardiovascular2019 / cmTotal2019 * 100;
                        cmporcentajeGastrointestinal2019 = (double)cmGastrointestinal2019 / cmTotal2019 * 100;
                        cmporcentajeEndocrinologico2019 = (double)cmRenalEndocrinologico2019 / cmTotal2019 * 100;
                        cmporcentajeFallaMultiorganica2019 = (double)cmFallaMultiorganica2019 / cmTotal2019 * 100;
                        cmporcentajeOtros2019 = (double)cmOtros2020 / cmTotal2019 * 100;
                        cmporcentajeNoFallecidos2019 = (double)cmNoFallecidos2019 / cmTotal2019 * 100;
                    }
                   
                    

                    //2020

                    int cmTotal2020 = cmNeurologico2020 + cmRespiratorio2020 + cmCardiovascular2020 + cmGastrointestinal2020 + cmRenalEndocrinologico2020 + cmFallaMultiorganica2020 + cmOtros2020 + cmNoFallecidos2020;
                    double cmporcentajeNeurologicos2020 = 0;
                    double cmporcentajeRespiratorio2020 = 0;
                    double cmporcentajeCardiovascular2020 = 0;
                    double cmporcentajeGastrointestinal2020 = 0;
                    double cmporcentajeEndocrinologico2020 = 0;
                    double cmporcentajeFallaMultiorganica2020 = 0;
                    double cmporcentajeOtros2020 = 0;
                    double cmporcentajeNoFallecidos2020 = 0;
                    if (cmTotal2020 != 0)
                    {
                        cmporcentajeNeurologicos2020 = (double)cmNeurologico2020 / cmTotal2020 * 100;
                        cmporcentajeRespiratorio2020 = (double)cmRespiratorio2020 / cmTotal2020 * 100;
                        cmporcentajeCardiovascular2020 = (double)cmCardiovascular2020 / cmTotal2020 * 100;
                        cmporcentajeGastrointestinal2020 = (double)cmGastrointestinal2020 / cmTotal2020 * 100;
                        cmporcentajeEndocrinologico2020 = (double)cmRenalEndocrinologico2020 / cmTotal2020 * 100;
                        cmporcentajeFallaMultiorganica2020 = (double)cmFallaMultiorganica2020 / cmTotal2020 * 100;
                        cmporcentajeOtros2020 = (double)cmOtrosGlobal / cmTotal2020 * 100;
                        cmporcentajeNoFallecidos2020 = (double)cmNoFallecidos2020 / cmTotal2020 * 100;
                    }

                    //2021
                    int cmTotal2021 = cmNeurologico2021 + cmRespiratorio2021  + cmCardiovascular2021 + cmGastrointestinal2021 + cmRenalEndocrinologico2021 + cmFallaMultiorganica2021 + cmOtros2021 + cmNoFallecidos2021;
                    double cmporcentajeNeurologicos2021 = 0;
                    double cmporcentajeRespiratorio2021 = 0;
                    double cmporcentajeCardiovascular2021 = 0;
                    double cmporcentajeGastrointestinal2021 = 0;
                    double cmporcentajeEndocrinologico2021 = 0;
                    double cmporcentajeFallaMultiorganica2021 = 0;
                    double cmporcentajeOtros2021 = 0;
                    double cmporcentajeNoFallecidos2021 = 0;
                    if (cmTotal2021 != 0)
                    {
                        cmporcentajeNeurologicos2021 = (double)cmNeurologico2021 / cmTotal2021 * 100;
                        cmporcentajeRespiratorio2021 = (double)cmRespiratorio2021 / cmTotal2021 * 100;
                        cmporcentajeCardiovascular2021 = (double)cmCardiovascular2021 / cmTotal2021 * 100;
                        cmporcentajeGastrointestinal2021 = (double)cmGastrointestinal2021 / cmTotal2021 * 100;
                        cmporcentajeEndocrinologico2021 = (double)cmRenalEndocrinologico2021 / cmTotal2021 * 100;
                        cmporcentajeFallaMultiorganica2021 = (double)cmFallaMultiorganica2021 / cmTotal2021 * 100;
                        cmporcentajeOtros2021 = (double)cmOtros2021 / cmTotal2021 * 100;
                        cmporcentajeNoFallecidos2021 = (double)cmNoFallecidos2021 / cmTotal2021 * 100;
                    }
                    //2022
                    int cmTotal2022 = cmNeurologico2022  + cmRespiratorio2022 + cmCardiovascular2022 + cmGastrointestinal2022 + cmRenalEndocrinologico2022 + cmFallaMultiorganica2022 + cmOtros2022 + cmNoFallecidos2022;
                    double cmporcentajeNeurologicos2022 = 0;
                    double cmporcentajeRespiratorio2022 = 0;
                    double cmporcentajeCardiovascular2022 = 0;
                    double cmporcentajeGastrointestinal2022 = 0;
                    double cmporcentajeEndocrinologico2022 = 0;
                    double cmporcentajeFallaMultiorganica2022 = 0;
                    double cmporcentajeOtros2022 = 0;
                    double cmporcentajeNoFallecidos2022 = 0;
                    if (cmTotal2022 != 0)
                    {
                        cmporcentajeNeurologicos2022 = (double)cmNeurologico2022 / cmTotal2022 * 100;
                        cmporcentajeRespiratorio2022 = (double)cmRespiratorio2022 / cmTotal2022 * 100;
                        cmporcentajeCardiovascular2022 = (double)cmCardiovascular2022 / cmTotal2022 * 100;
                        cmporcentajeGastrointestinal2022 = (double)cmGastrointestinal2022 / cmTotal2022 * 100;
                        cmporcentajeEndocrinologico2022 = (double)cmRenalEndocrinologico2022 / cmTotal2022 * 100;
                        cmporcentajeFallaMultiorganica2022 = (double)cmFallaMultiorganica2022 / cmTotal2022 * 100;
                        cmporcentajeOtros2022 = (double)cmOtros2022 / cmTotal2022 * 100;
                        cmporcentajeNoFallecidos2022 = (double)cmNoFallecidos2022 / cmTotal2022 * 100;
                    }
                    //2023
                    int cmTotal2023 = cmNeurologico2023  + cmRespiratorio2023 + cmCardiovascular2023 + cmGastrointestinal2023 + cmRenalEndocrinologico2023 + cmFallaMultiorganica2023 + cmOtros2023+ cmNoFallecidos2023;
                    double cmporcentajeNeurologicos2023 = 0;
                    double cmporcentajeRespiratorio2023 = 0;
                    double cmporcentajeCardiovascular2023 = 0;
                    double cmporcentajeGastrointestinal2023 = 0;
                    double cmporcentajeEndocrinologico2023 = 0;
                    double cmporcentajeFallaMultiorganica2023 = 0;
                    double cmporcentajeOtros2023 = 0;
                    double cmporcentajeNoFallecidos2023 = 0;
                    if (cmTotal2023 != 0)
                    {
                        cmporcentajeNeurologicos2023 = (double)cmNeurologico2023 / cmTotal2023 * 100;
                        cmporcentajeRespiratorio2023 = (double)cmRespiratorio2023 / cmTotal2023 * 100;
                        cmporcentajeCardiovascular2023 = (double)cmCardiovascular2023 / cmTotal2023 * 100;
                        cmporcentajeGastrointestinal2023 = (double)cmGastrointestinal2023 / cmTotal2023 * 100;
                        cmporcentajeEndocrinologico2023 = (double)cmRenalEndocrinologico2023 / cmTotal2023 * 100;
                        cmporcentajeFallaMultiorganica2023 = (double)cmFallaMultiorganica2023 / cmTotal2023 * 100;
                        cmporcentajeOtros2023 = (double)cmOtros2023 / cmTotal2023 * 100;
                        cmporcentajeNoFallecidos2023 = (double)cmNoFallecidos2023 / cmTotal2023 * 100;
                    }
                    #endregion

                    #region llenado delmodelote

                    #region ingresos
                    //Promedio de ingresos mensuales
                    responseEst.Ingresos_totales = Ingresos_totales;
                    responseEst.contador2019 = contador2019;
                    responseEst.contador2020 = contador2020;
                    responseEst.contador2021 = contador2021;
                    responseEst.contador2022 = contador2022;
                    responseEst.contador2023 = contador2023;
                    //porcentajes
                    responseEst.porcentajeIngresos2019 = porcentajeIngresos2019;
                    responseEst.porcentajeIngresos2020 = porcentajeIngresos2020;
                    responseEst.porcentajeIngresos2021 = porcentajeIngresos2021;
                    responseEst.porcentajeIngresos2022 = porcentajeIngresos2022;
                    responseEst.porcentajeIngresos2023 = porcentajeIngresos2023;
                    // Calcular promedio por año
                    responseEst.promedioIngresos2019 = promedioIngresos2019;
                    responseEst.promedioIngresos2020 = promedioIngresos2020;
                    responseEst.promedioIngresos2021 = promedioIngresos2021;
                    responseEst.promedioIngresos2022 = promedioIngresos2022;
                    responseEst.promedioIngresos2023 = promedioIngresos2023;
                    #endregion

                    #region sexo
                    //Porcentaje de varones y mujeres 
                    responseEst.contadorSexFemTotal = contadorSexFemTotal;
                    responseEst.contadorSexMasTotal = contadorSexMasTotal;

                    responseEst.contadorSex2019f = contadorSex2019f;
                    responseEst.contadorSex2020f = contadorSex2020f;
                    responseEst.contadorSex2021f = contadorSex2021f;
                    responseEst.contadorSex2022f = contadorSex2022f;
                    responseEst.contadorSex2023f = contadorSex2023f;


                    responseEst.contadorSex2019m = contadorSex2019m;
                    responseEst.contadorSex2020m = contadorSex2020m;
                    responseEst.contadorSex2021m = contadorSex2021m;
                    responseEst.contadorSex2022m = contadorSex2022m;
                    responseEst.contadorSex2023m = contadorSex2023m;

                    responseEst.totalSex = totalSex;
                    //porcentaje Global
                    responseEst.porcentajeallf = porcentajeallf;
                    responseEst.porcentajeallm = porcentajeallm;

                    // Calcular el total de cada año por sexo
                    responseEst.total2019 = total2019;
                    responseEst.total2020 = total2020;
                    responseEst.total2021 = total2021;
                    responseEst.total2022 = total2022;
                    responseEst.total2023 = total2023;

                    // Calcular el porcentaje para cada año
                    responseEst.porcentaje2019f = porcentaje2019f;
                    responseEst.porcentaje2019m = porcentaje2019m;

                    responseEst.porcentaje2020f = porcentaje2020f;
                    responseEst.porcentaje2020m = porcentaje2020m;

                    responseEst.porcentaje2021f = porcentaje2021f;
                    responseEst.porcentaje2021m = porcentaje2021m;

                    responseEst.porcentaje2022f = porcentaje2022f;
                    responseEst.porcentaje2022m = porcentaje2022m;

                    responseEst.porcentaje2023f = porcentaje2023f;
                    responseEst.porcentaje2023m = porcentaje2023m;
                    #endregion

                    #region Edad
                    responseEst.moda2019Edad = moda2019Edad;
                    responseEst.media2019Edad = media2019Edad;
                    responseEst.promedi2019Edad = promedi2019Edad;

                    responseEst.moda2020Edad = moda2020Edad;
                    responseEst.media2020Edad = media2020Edad;
                    responseEst.promedi2020Edad = promedi2020Edad;

                    responseEst.moda2021Edad = moda2021Edad;
                    responseEst.media2021Edad = media2021Edad;
                    responseEst.promedi2021Edad = promedi2021Edad;

                    responseEst.moda2022Edad = moda2022Edad;
                    responseEst.media2022Edad = media2022Edad;
                    responseEst.promedi2022Edad = promedi2022Edad;

                    responseEst.moda2023Edad = moda2023Edad;
                    responseEst.media2023Edad = media2023Edad;
                    responseEst.promedi2023Edad = promedi2023Edad;
                    //Para la discriminacion de edad
                    responseEst.Menores30anos2019 = Menores30anos2019;
                    responseEst.Adultos30_59anos2019 = Adultos30_59anos2019;
                    responseEst.Mayoresde60anos2019 = Mayoresde60anos2019;

                    responseEst.Menores30anos2020 = Menores30anos2020;
                    responseEst.Adultos30_59anos2020 = Adultos30_59anos2020;
                    responseEst.Mayoresde60anos2020 = Mayoresde60anos2020;

                    responseEst.Menores30anos2021 = Menores30anos2021;
                    responseEst.Adultos30_59anos2021 = Adultos30_59anos2021;
                    responseEst.Mayoresde60anos2021 = Mayoresde60anos2021;

                    responseEst.Menores30anos2022 = Menores30anos2022;
                    responseEst.Adultos30_59anos2022 = Adultos30_59anos2022;
                    responseEst.Mayoresde60anos2022 = Mayoresde60anos2022;

                    responseEst.Menores30anos2023 = Menores30anos2023;
                    responseEst.Adultos30_59anos2023 = Adultos30_59anos2023;
                    responseEst.Mayoresde60anos2023 = Mayoresde60anos2023;

                    responseEst.totalEdad2019 = totalEdad2019;
                    responseEst.porcentajeMenores30anos2019 = porcentajeMenores30anos2019;
                    responseEst.porcentajeAdultos30_59anos2019 = porcentajeAdultos30_59anos2019;
                    responseEst.porcentajeMayoresde60anos2019 = porcentajeMayoresde60anos2019;


                    responseEst.totalEdad2020 = totalEdad2020;
                    responseEst.porcentajeMenores30anos2020 = porcentajeMenores30anos2020;
                    responseEst.porcentajeAdultos30_59anos2020 = porcentajeAdultos30_59anos2020;
                    responseEst.porcentajeMayoresde60anos2020 = porcentajeMayoresde60anos2020;


                    responseEst.totalEdad2021 = totalEdad2021;
                    responseEst.porcentajeMenores30anos2021 = porcentajeMenores30anos2021;
                    responseEst.porcentajeAdultos30_59anos2021 = porcentajeAdultos30_59anos2021;
                    responseEst.porcentajeMayoresde60anos2021 = porcentajeMayoresde60anos2021;


                    responseEst.totalEdad2022 = totalEdad2022;
                    responseEst.porcentajeMenores30anos2022 = porcentajeMenores30anos2022;
                    responseEst.porcentajeAdultos30_59anos2022 = porcentajeAdultos30_59anos2022;
                    responseEst.porcentajeMayoresde60anos2022 = porcentajeMayoresde60anos2022;

                    responseEst.totalEdad2023 = totalEdad2023;
                    responseEst.porcentajeMenores30anos2023 = porcentajeMenores30anos2023;
                    responseEst.porcentajeAdultos30_59anos2023 = porcentajeAdultos30_59anos2023;
                    responseEst.porcentajeMayoresde60anos2023 = porcentajeMayoresde60anos2023;


                    //global
                    responseEst.totalEdadGlobal = totalEdadGlobal;

                    responseEst.Menores30anosGlobal = Menores30anosGlobal;
                    responseEst.Adultos30_59anosGlobal = Adultos30_59anosGlobal;
                    responseEst.Mayoresde60anosGlobal = Mayoresde60anosGlobal;

                    responseEst.porcentajeMenores30anosGlobal = porcentajeMenores30anosGlobal;
                    responseEst.porcentajeAdultos30_59anosGlobal = porcentajeAdultos30_59anosGlobal;
                    responseEst.porcentajeMayoresde60anosGlobal = porcentajeMayoresde60anosGlobal;


                    #endregion

                    #region Dias Inter
                    responseEst.moda2019EstDias = moda2019EstDias;
                    responseEst.media2019EstDias = media2019EstDias;
                    responseEst.promedi2019EstDias = promedi2019EstDias;

                    responseEst.moda2020EstDias = moda2020EstDias;
                    responseEst.media2020EstDias = media2020EstDias;
                    responseEst.promedi2020EstDias = promedi2020EstDias;

                    responseEst.moda2021EstDias = moda2021EstDias;
                    responseEst.media2021EstDias = media2021EstDias;
                    responseEst.promedi2021EstDias = promedi2021EstDias;

                    responseEst.moda2022EstDias = moda2022EstDias;
                    responseEst.media2022EstDias = media2022EstDias;
                    responseEst.promedi2022EstDias = promedi2022EstDias;

                    responseEst.moda2023EstDias = moda2023EstDias;
                    responseEst.media2023EstDias = media2023EstDias;
                    responseEst.promedi2023EstDias = promedi2023EstDias;
                    #endregion

                    #region Origen Ingresos
                    responseEst.oicontEmergencias2019 = oicontEmergencias2019;
                    responseEst.oicontQuirofano2019 = oicontQuirofano2019;
                    responseEst.oicontSalacomun2019 = oicontSalacomun2019;
                    responseEst.oicontTransferenciadeotraUTI2019 = oicontTransferenciadeotraUTI2019;
                    responseEst.oicontOtros2019 = oicontOtros2019;

                    responseEst.oicontEmergencias2020 = oicontEmergencias2020;
                    responseEst.oicontQuirofano2020 = oicontQuirofano2020;
                    responseEst.oicontSalacomun2020 = oicontSalacomun2020;
                    responseEst.oicontTransferenciadeotraUTI2020 = oicontTransferenciadeotraUTI2020;
                    responseEst.oicontOtros2020 = oicontOtros2020;

                    responseEst.oicontEmergencias2021 = oicontEmergencias2021;
                    responseEst.oicontQuirofano2021 = oicontQuirofano2021;
                    responseEst.oicontSalacomun2021 = oicontSalacomun2021;
                    responseEst.oicontTransferenciadeotraUTI2021 = oicontTransferenciadeotraUTI2021;
                    responseEst.oicontOtros2021 = oicontOtros2021;

                    responseEst.oicontEmergencias2022 = oicontEmergencias2022;
                    responseEst.oicontQuirofano2022 = oicontQuirofano2022;
                    responseEst.oicontSalacomun2022 = oicontSalacomun2022;
                    responseEst.oicontTransferenciadeotraUTI2022 = oicontTransferenciadeotraUTI2022;
                    responseEst.oicontOtros2022 = oicontOtros2022;

                    responseEst.oicontEmergencias2023 = oicontEmergencias2023;
                    responseEst.oicontQuirofano2023 = oicontQuirofano2023;
                    responseEst.oicontSalacomun2023 = oicontSalacomun2023;
                    responseEst.oicontTransferenciadeotraUTI2023 = oicontTransferenciadeotraUTI2023;
                    responseEst.oicontOtros2023 = oicontOtros2023;


                    // Contadores globales
                    responseEst.totalGlobalEmergencias = totalGlobalEmergencias;
                    responseEst.totalGlobalQuirofano = totalGlobalQuirofano;
                    responseEst.totalGlobalSalaComun = totalGlobalSalaComun;
                    responseEst.totalGlobalTransferenciaOtraUTI = totalGlobalTransferenciaOtraUTI;
                    responseEst.totalGlobalOtros = totalGlobalOtros;



                    responseEst.TotalGlobal = TotalGlobal;

                    responseEst.porcentajeEmergencias = porcentajeEmergencias;
                    responseEst.porcentajeQuirofano = porcentajeQuirofano;
                    responseEst.porcentajeSalaComun = porcentajeSalaComun;
                    responseEst.porcentajeTransferenciaOtraUTI = porcentajeTransferenciaOtraUTI;
                    responseEst.porcentajeOtros = porcentajeOtros;

                    //Individuales
                    responseEst.totaOI2019 = totaOI2019;
                    responseEst.porcentajeEmergencias2019 = porcentajeEmergencias2019;
                    responseEst.porcentajeQuirofano2019 = porcentajeQuirofano2019;
                    responseEst.porcentajeSalaComun2019 = porcentajeSalaComun2019;
                    responseEst.porcentajeTransferenciaOtraUTI2019 = porcentajeTransferenciaOtraUTI2019;
                    responseEst.porcentajeOtros2019 = porcentajeOtros2019;

                    responseEst.totaOI2020 = totaOI2020;
                    responseEst.porcentajeEmergencias2020 = porcentajeEmergencias2020;
                    responseEst.porcentajeQuirofano2020 = porcentajeQuirofano2020;
                    responseEst.porcentajeSalaComun2020 = porcentajeSalaComun2020;
                    responseEst.porcentajeTransferenciaOtraUTI2020 = porcentajeTransferenciaOtraUTI2020;
                    responseEst.porcentajeOtros2020 = porcentajeOtros2020;

                    responseEst.totaOI2021 = totaOI2021;
                    responseEst.porcentajeEmergencias2021 = porcentajeEmergencias2021;
                    responseEst.porcentajeQuirofano2021 = porcentajeQuirofano2021;
                    responseEst.porcentajeSalaComun2021 = porcentajeSalaComun2021;
                    responseEst.porcentajeTransferenciaOtraUTI2021 = porcentajeTransferenciaOtraUTI2021;
                    responseEst.porcentajeOtros2021 = porcentajeOtros2021;

                    responseEst.totaOI2022 = totaOI2022;
                    responseEst.porcentajeEmergencias2022 = porcentajeEmergencias2022;
                    responseEst.porcentajeQuirofano2022 = porcentajeQuirofano2022;
                    responseEst.porcentajeSalaComun2022 = porcentajeSalaComun2022;
                    responseEst.porcentajeTransferenciaOtraUTI2022 = porcentajeTransferenciaOtraUTI2022;
                    responseEst.porcentajeOtros2022 = porcentajeOtros2022;

                    responseEst.totaOI2023 = totaOI2023;
                    responseEst.porcentajeEmergencias2023 = porcentajeEmergencias2023;
                    responseEst.porcentajeQuirofano2023 = porcentajeQuirofano2023;
                    responseEst.porcentajeSalaComun2023 = porcentajeSalaComun2023;
                    responseEst.porcentajeTransferenciaOtraUTI2023 = porcentajeTransferenciaOtraUTI2023;
                    responseEst.porcentajeOtros2023 = porcentajeOtros2023;

                    #endregion

                    #region Causa Ingreso
                    responseEst.cicontNeurologico2019 = cicontNeurologico2019;
                    responseEst.cicontRespiratorio2019 = cicontRespiratorio2019;
                    responseEst.cicontCardiovascular2019 = cicontCardiovascular2019;
                    responseEst.cicontGastrointestinal2019 = cicontGastrointestinal2019;
                    responseEst.cicontRenalEndocrinologico2019 = cicontRenalEndocrinologico2019;
                    responseEst.cicontOtros2019 = cicontOtros2019;

                    responseEst.cicontNeurologico2020 = cicontNeurologico2020;
                    responseEst.cicontRespiratorio2020 = cicontRespiratorio2020;
                    responseEst.cicontCardiovascular2020 = cicontCardiovascular2020;
                    responseEst.cicontGastrointestinal2020 = cicontGastrointestinal2020;
                    responseEst.cicontRenalEndocrinologico2020 = cicontRenalEndocrinologico2020;
                    responseEst.cicontOtros2020 = cicontOtros2020;

                    responseEst.cicontNeurologico2021 = cicontNeurologico2021;
                    responseEst.cicontRespiratorio2021 = cicontRespiratorio2021;
                    responseEst.cicontCardiovascular2021 = cicontCardiovascular2021;
                    responseEst.cicontGastrointestinal2021 = cicontGastrointestinal2021;
                    responseEst.cicontRenalEndocrinologico2021 = cicontRenalEndocrinologico2021;
                    responseEst.cicontOtros2021 = cicontOtros2021;

                    responseEst.cicontNeurologico2022 = cicontNeurologico2022;
                    responseEst.cicontRespiratorio2022 = cicontRespiratorio2022;
                    responseEst.cicontCardiovascular2022 = cicontCardiovascular2022;
                    responseEst.cicontGastrointestinal2022 = cicontGastrointestinal2022;
                    responseEst.cicontRenalEndocrinologico2022 = cicontRenalEndocrinologico2022;
                    responseEst.cicontOtros2022 = cicontOtros2022;

                    responseEst.cicontNeurologico2023 = cicontNeurologico2023;
                    responseEst.cicontRespiratorio2023 = cicontRespiratorio2023;
                    responseEst.cicontCardiovascular2023 = cicontCardiovascular2023;
                    responseEst.cicontGastrointestinal2023 = cicontGastrointestinal2023;
                    responseEst.cicontRenalEndocrinologico2023 = cicontRenalEndocrinologico2023;
                    responseEst.cicontOtros2023 = cicontOtros2023;


                    //NeurolOgico 2019
                    responseEst.subNcicontTEC2019 = subNcicontTEC2019;
                    responseEst.subNcicontAVC2019 = subNcicontAVC2019;
                    responseEst.subNcicontEpilepsia2019 = subNcicontEpilepsia2019;
                    responseEst.subNcicontMeningitis2019 = subNcicontMeningitis2019;
                    responseEst.subNcicontOtros2019 = subNcicontOtros2019;

                    //Respiratorio 2019
                    responseEst.subResciChoqueSeptico_Neumonia2019 = subResciChoqueSeptico_Neumonia2019;
                    responseEst.subResciTEP2019 = subResciTEP2019;
                    responseEst.subResciEAP2019 = subResciEAP2019;
                    responseEst.subResciAsma_EPOC2019 = subResciAsma_EPOC2019;
                    responseEst.subResciOtros2019 = subResciOtros2019;

                    //Cardiovascular 2019
                    responseEst.subCarciChoqueCardiogenico2019 = subCarciChoqueCardiogenico2019;
                    responseEst.subCarciPostOperadoCirugiaCardiaca2019 = subCarciPostOperadoCirugiaCardiaca2019;
                    responseEst.subCarciTaquiarritmiaBradiarritmia2019 = subCarciTaquiarritmiaBradiarritmia2019;
                    responseEst.subCarciCrisisHipertensivas2019 = subCarciCrisisHipertensivas2019;
                    responseEst.subCarciPostParo2019 = subCarciPostParo2019;
                    responseEst.subCarciOtros2019 = subCarciOtros2019;

                    //Gastrointestinal 2019
                    responseEst.subGasciPancreatitisAguda2019 = subGasciPancreatitisAguda2019;
                    responseEst.subGasciHemorragiaDigestiva2019 = subGasciHemorragiaDigestiva2019;
                    responseEst.subGasciPostOperadosComplicados2019 = subGasciPostOperadosComplicados2019;
                    responseEst.subGasciOtros2019 = subGasciOtros2019;


                    //NeurolOgico 2020
                    responseEst.subNcicontTEC2020 = subNcicontTEC2020;
                    responseEst.subNcicontAVC2020 = subNcicontAVC2020;
                    responseEst.subNcicontEpilepsia2020 = subNcicontEpilepsia2020;
                    responseEst.subNcicontMeningitis2020 = subNcicontMeningitis2020;
                    responseEst.subNcicontOtros2020 = subNcicontOtros2020;


                    //Respiratorio 2020
                    responseEst.subResciChoqueSeptico_Neumonia2020 = subResciChoqueSeptico_Neumonia2020;
                    responseEst.subResciTEP2020 = subResciTEP2020;
                    responseEst.subResciEAP2020 = subResciEAP2020;
                    responseEst.subResciAsma_EPOC2020 = subResciAsma_EPOC2020;
                    responseEst.subResciOtros2020 = subResciOtros2020;

                    //Cardiovascular 2020
                    responseEst.subCarciChoqueCardiogenico2020 = subCarciChoqueCardiogenico2020;
                    responseEst.subCarciPostOperadoCirugiaCardiaca2020 = subCarciPostOperadoCirugiaCardiaca2020;
                    responseEst.subCarciTaquiarritmiaBradiarritmia2020 = subCarciTaquiarritmiaBradiarritmia2020;
                    responseEst.subCarciCrisisHipertensivas2020 = subCarciCrisisHipertensivas2020;
                    responseEst.subCarciPostParo2020 = subCarciPostParo2020;
                    responseEst.subCarciOtros2020 = subCarciOtros2020;

                    //Gastrointestinal 2020
                    responseEst.subGasciPancreatitisAguda2020 = subGasciPancreatitisAguda2020;
                    responseEst.subGasciHemorragiaDigestiva2020 = subGasciHemorragiaDigestiva2020;
                    responseEst.subGasciPostOperadosComplicados2020 = subGasciPostOperadosComplicados2020;
                    responseEst.subGasciOtros2020 = subGasciOtros2020;



                    //NeurolOgico 2021
                    responseEst.subNcicontTEC2021 = subNcicontTEC2021;
                    responseEst.subNcicontAVC2021 = subNcicontAVC2021;
                    responseEst.subNcicontEpilepsia2021 = subNcicontEpilepsia2021;
                    responseEst.subNcicontMeningitis2021 = subNcicontMeningitis2021;
                    responseEst.subNcicontOtros2021 = subNcicontOtros2021;

                    //Respiratorio 2021
                    responseEst.subResciChoqueSeptico_Neumonia2021 = subResciChoqueSeptico_Neumonia2021;
                    responseEst.subResciTEP2021 = subResciTEP2021;
                    responseEst.subResciEAP2021 = subResciEAP2021;
                    responseEst.subResciAsma_EPOC2021 = subResciAsma_EPOC2021;
                    responseEst.subResciOtros2021 = subResciOtros2021;

                    //Cardiovascular 2021
                    responseEst.subCarciChoqueCardiogenico2021 = subCarciChoqueCardiogenico2021;
                    responseEst.subCarciPostOperadoCirugiaCardiaca2021 = subCarciPostOperadoCirugiaCardiaca2021;
                    responseEst.subCarciTaquiarritmiaBradiarritmia2021 = subCarciTaquiarritmiaBradiarritmia2021;
                    responseEst.subCarciCrisisHipertensivas2021 = subCarciCrisisHipertensivas2021;
                    responseEst.subCarciPostParo2021 = subCarciPostParo2021;
                    responseEst.subCarciOtros2021 = subCarciOtros2021;

                    //Gastrointestinal 2021
                    responseEst.subGasciPancreatitisAguda2021 = subGasciPancreatitisAguda2021;
                    responseEst.subGasciHemorragiaDigestiva2021 = subGasciHemorragiaDigestiva2021;
                    responseEst.subGasciPostOperadosComplicados2021 = subGasciPostOperadosComplicados2021;
                    responseEst.subGasciOtros2021 = subGasciOtros2021;


                    //NeurolOgico 2022
                    responseEst.subNcicontTEC2022 = subNcicontTEC2022;
                    responseEst.subNcicontAVC2022 = subNcicontAVC2022;
                    responseEst.subNcicontEpilepsia2022 = subNcicontEpilepsia2022;
                    responseEst.subNcicontMeningitis2022 = subNcicontMeningitis2022;
                    responseEst.subNcicontOtros2022 = subNcicontOtros2022;

                    //Respiratorio 2022
                    responseEst.subResciChoqueSeptico_Neumonia2022 = subResciChoqueSeptico_Neumonia2022;
                    responseEst.subResciTEP2022 = subResciTEP2022;
                    responseEst.subResciEAP2022 = subResciEAP2022;
                    responseEst.subResciAsma_EPOC2022 = subResciAsma_EPOC2022;
                    responseEst.subResciOtros2022 = subResciOtros2022;

                    //Cardiovascular 2022
                    responseEst.subCarciChoqueCardiogenico2022 = subCarciChoqueCardiogenico2022;
                    responseEst.subCarciPostOperadoCirugiaCardiaca2022 = subCarciPostOperadoCirugiaCardiaca2022;
                    responseEst.subCarciTaquiarritmiaBradiarritmia2022 = subCarciTaquiarritmiaBradiarritmia2022;
                    responseEst.subCarciCrisisHipertensivas2022 = subCarciCrisisHipertensivas2022;
                    responseEst.subCarciPostParo2022 = subCarciPostParo2022;
                    responseEst.subCarciOtros2022 = subCarciOtros2022;

                    //Gastrointestinal 2022
                    responseEst.subGasciPancreatitisAguda2022 = subGasciPancreatitisAguda2022;
                    responseEst.subGasciHemorragiaDigestiva2022 = subGasciHemorragiaDigestiva2022;
                    responseEst.subGasciPostOperadosComplicados2022 = subGasciPostOperadosComplicados2022;
                    responseEst.subGasciOtros2022 = subGasciOtros2022;

                    //NeurolOgico 2023
                    responseEst.subNcicontTEC2023 = subNcicontTEC2023;
                    responseEst.subNcicontAVC2023 = subNcicontAVC2023;
                    responseEst.subNcicontEpilepsia2023 = subNcicontEpilepsia2023;
                    responseEst.subNcicontMeningitis2023 = subNcicontMeningitis2023;
                    responseEst.subNcicontOtros2023 = subNcicontOtros2023;

                    //Respiratorio 2023
                    responseEst.subResciChoqueSeptico_Neumonia2023 = subResciChoqueSeptico_Neumonia2023;
                    responseEst.subResciTEP2023 = subResciTEP2023;
                    responseEst.subResciEAP2023 = subResciEAP2023;
                    responseEst.subResciAsma_EPOC2023 = subResciAsma_EPOC2023;
                    responseEst.subResciOtros2023 = subResciOtros2023;

                    //Cardiovascular 2023
                    responseEst.subCarciChoqueCardiogenico2023 = subCarciChoqueCardiogenico2023;
                    responseEst.subCarciPostOperadoCirugiaCardiaca2023 = subCarciPostOperadoCirugiaCardiaca2023;
                    responseEst.subCarciTaquiarritmiaBradiarritmia2023 = subCarciTaquiarritmiaBradiarritmia2023;
                    responseEst.subCarciCrisisHipertensivas2023 = subCarciCrisisHipertensivas2023;
                    responseEst.subCarciPostParo2023 = subCarciPostParo2023;
                    responseEst.subCarciOtros2023 = subCarciOtros2023;

                    //Gastrointestinal 2023
                    responseEst.subGasciPancreatitisAguda2023 = subGasciPancreatitisAguda2023;
                    responseEst.subGasciHemorragiaDigestiva2023 = subGasciHemorragiaDigestiva2023;
                    responseEst.subGasciPostOperadosComplicados2023 = subGasciPostOperadosComplicados2023;
                    responseEst.subGasciOtros2023 = subGasciOtros2023;


                    //Global Categorias
                    responseEst.cicontNeurologicoTotal = cicontNeurologicoTotal;
                    responseEst.cicontRespiratorioTotal = cicontRespiratorioTotal;
                    responseEst.cicontCardiovascularTotal = cicontCardiovascularTotal;
                    responseEst.cicontGastrointestinalTotal = cicontGastrointestinalTotal;
                    responseEst.cicontRenalEndocrinologicoTotal = cicontRenalEndocrinologicoTotal;
                    responseEst.cicontOtrosTotal = cicontOtrosTotal;

                    responseEst.ciTotalCategoria = ciTotalCategoria;
                    responseEst.ciporcentajecicontNeurologicoTotal = ciporcentajecicontNeurologicoTotal;
                    responseEst.ciporcentajecicontRespiratorioTotal = ciporcentajecicontRespiratorioTotal;
                    responseEst.ciporcentajecicontCardiovascularTotal = ciporcentajecicontCardiovascularTotal;
                    responseEst.ciporcentajecicontGastrointestinalTotal = ciporcentajecicontGastrointestinalTotal;
                    responseEst.ciporcentajecicontRenalEndocrinologicoTotal = ciporcentajecicontRenalEndocrinologicoTotal;
                    responseEst.ciporcentajecicontOtrosTotal = ciporcentajecicontOtrosTotal;

                    //Categorias por año

                    responseEst.totaCI2019 = totaCI2019;
                    responseEst.ciporcentajecicontNeurologico2019 = ciporcentajecicontNeurologico2019;
                    responseEst.ciporcentajecicontRespiratorio2019 = ciporcentajecicontRespiratorio2019;
                    responseEst.ciporcentajecicontCardiovascular2019 = ciporcentajecicontCardiovascular2019;
                    responseEst.ciporcentajecicontGastrointestinal2019 = ciporcentajecicontGastrointestinal2019;
                    responseEst.ciporcentajecicontRenalEndocrinologico2019 = ciporcentajecicontRenalEndocrinologico2019;
                    responseEst.ciporcentajecicontOtros2019 = ciporcentajecicontOtros2019;


                    responseEst.totaCI2020 = totaCI2020;
                    responseEst.ciporcentajecicontNeurologico2020 = ciporcentajecicontNeurologico2020;
                    responseEst.ciporcentajecicontRespiratorio2020 = ciporcentajecicontRespiratorio2020;
                    responseEst.ciporcentajecicontCardiovascular2020 = ciporcentajecicontCardiovascular2020;
                    responseEst.ciporcentajecicontGastrointestinal2020 = ciporcentajecicontGastrointestinal2020;
                    responseEst.ciporcentajecicontRenalEndocrinologico2020 = ciporcentajecicontRenalEndocrinologico2020;
                    responseEst.ciporcentajecicontOtros2020 = ciporcentajecicontOtros2020;

                    responseEst.totaCI2021 = totaCI2021;
                    responseEst.ciporcentajecicontNeurologico2021 = ciporcentajecicontNeurologico2021;
                    responseEst.ciporcentajecicontRespiratorio2021 = ciporcentajecicontRespiratorio2021;
                    responseEst.ciporcentajecicontCardiovascular2021 = ciporcentajecicontCardiovascular2021;
                    responseEst.ciporcentajecicontGastrointestinal2021 = ciporcentajecicontGastrointestinal2021;
                    responseEst.ciporcentajecicontRenalEndocrinologico2021 = ciporcentajecicontRenalEndocrinologico2021;
                    responseEst.ciporcentajecicontOtros2021 = ciporcentajecicontOtros2021;

                    responseEst.totaCI2022 = totaCI2022;
                    responseEst.ciporcentajecicontNeurologico2022 = ciporcentajecicontNeurologico2022;
                    responseEst.ciporcentajecicontRespiratorio2022 = ciporcentajecicontRespiratorio2022;
                    responseEst.ciporcentajecicontCardiovascular2022 = ciporcentajecicontCardiovascular2022;
                    responseEst.ciporcentajecicontGastrointestinal2022 = ciporcentajecicontGastrointestinal2022;
                    responseEst.ciporcentajecicontRenalEndocrinologico2022 = ciporcentajecicontRenalEndocrinologico2022;
                    responseEst.ciporcentajecicontOtros2022 = ciporcentajecicontOtros2022;

                    responseEst.totaCI2023 = totaCI2023;
                    responseEst.ciporcentajecicontNeurologico2023 = ciporcentajecicontNeurologico2023;
                    responseEst.ciporcentajecicontRespiratorio2023 = ciporcentajecicontRespiratorio2023;
                    responseEst.ciporcentajecicontCardiovascular2023 = ciporcentajecicontCardiovascular2023;
                    responseEst.ciporcentajecicontGastrointestinal2023 = ciporcentajecicontGastrointestinal2023;
                    responseEst.ciporcentajecicontRenalEndocrinologico2023 = ciporcentajecicontRenalEndocrinologico2023;
                    responseEst.ciporcentajecicontOtros2023 = ciporcentajecicontOtros2023;


                    //Subcategorias Global

                    //NeurolOgico Total
                    responseEst.subNcicontTECTotal = subNcicontTECTotal;
                    responseEst.subNcicontAVCTotal = subNcicontAVCTotal;
                    responseEst.subNcicontEpilepsiaTotal = subNcicontEpilepsiaTotal;
                    responseEst.subNcicontMeningitisTotal = subNcicontMeningitisTotal;
                    responseEst.subNcicontOtrosTotal = subNcicontOtrosTotal;


                    responseEst.subporcentajesubNcicontTECTotal = subporcentajesubNcicontTECTotal;
                    responseEst.subporcentajesubNcicontAVCTotal = subporcentajesubNcicontAVCTotal;
                    responseEst.subporcentajesubNcicontEpilepsiaTotal = subporcentajesubNcicontEpilepsiaTotal;
                    responseEst.subporcentajesubNcicontMeningitisTotal = subporcentajesubNcicontMeningitisTotal;
                    responseEst.subporcentajesubNcicontOtrosTotal = subporcentajesubNcicontOtrosTotal;

                    //Respiratorio Total
                    responseEst.subResciChoqueSeptico_NeumoniaTotal = subResciChoqueSeptico_NeumoniaTotal;
                    responseEst.subResciTEPTotal = subResciTEPTotal;
                    responseEst.subResciEAPTotal = subResciEAPTotal;
                    responseEst.subResciAsma_EPOCTotal = subResciAsma_EPOCTotal;
                    responseEst.subResciOtrosTotal = subResciOtrosTotal;

                    responseEst.subporcentajesubResciChoqueSeptico_NeumoniaTotal = subporcentajesubResciChoqueSeptico_NeumoniaTotal;
                    responseEst.subporcentajesubResciTEPTotal = subporcentajesubResciTEPTotal;
                    responseEst.subporcentajesubResciEAPTotal = subporcentajesubResciEAPTotal;
                    responseEst.subporcentajesubResciAsma_EPOCTotal = subporcentajesubResciAsma_EPOCTotal;
                    responseEst.subporcentajesubResciOtrosTotal = subporcentajesubResciOtrosTotal;

                    //Cardiovascular Total
                    responseEst.subCarciChoqueCardiogenicoTotal = subCarciChoqueCardiogenicoTotal;
                    responseEst.subCarciPostOperadoCirugiaCardiacaTotal = subCarciPostOperadoCirugiaCardiacaTotal;
                    responseEst.subCarciTaquiarritmiaBradiarritmiaTotal = subCarciTaquiarritmiaBradiarritmiaTotal;
                    responseEst.subCarciCrisisHipertensivasTotal = subCarciCrisisHipertensivasTotal;
                    responseEst.subCarciPostParoTotal = subCarciPostParoTotal;
                    responseEst.subCarciOtrosTotal = subCarciOtrosTotal;

                    responseEst.subporcentajesubCarciChoqueCardiogenicoTotal = subporcentajesubCarciChoqueCardiogenicoTotal;
                    responseEst.subporcentajesubCarciPostOperadoCirugiaCardiacaTotal = subporcentajesubCarciPostOperadoCirugiaCardiacaTotal;
                    responseEst.subporcentajesubCarciTaquiarritmiaBradiarritmiaTotal = subporcentajesubCarciTaquiarritmiaBradiarritmiaTotal;
                    responseEst.subporcentajesubCarciCrisisHipertensivasTotal = subporcentajesubCarciCrisisHipertensivasTotal;
                    responseEst.subporcentajesubCarciPostParoTotal = subporcentajesubCarciPostParoTotal;
                    responseEst.subporcentajesubCarciOtrosTotal = subporcentajesubCarciOtrosTotal;
                    //Gastrointestinal Total
                    responseEst.subGasciPancreatitisAgudaTotal = subGasciPancreatitisAgudaTotal;
                    responseEst.subGasciHemorragiaDigestivaTotal = subGasciHemorragiaDigestivaTotal;
                    responseEst.subGasciPostOperadosComplicadosTotal = subGasciPostOperadosComplicadosTotal;
                    responseEst.subGasciOtrosTotal = subGasciOtrosTotal;

                    responseEst.subporcentajesubGasciPancreatitisAgudaTotal = subporcentajesubGasciPancreatitisAgudaTotal;
                    responseEst.subporcentajesubsubGasciHemorragiaDigestivaTotal = subporcentajesubsubGasciHemorragiaDigestivaTotal;
                    responseEst.subporcentajesubGasciPostOperadosComplicadosTotal = subporcentajesubGasciPostOperadosComplicadosTotal;
                    responseEst.subporcentajesubGasciOtrosTotal = subporcentajesubGasciOtrosTotal;


                    //Subcategorias por año


                    //NeurolOgico 2019                    
                    responseEst.porcentajesubNcicontTEC2019 = porcentajesubNcicontTEC2019;
                    responseEst.porcentajesubNcicontAVC2019 = porcentajesubNcicontAVC2019;
                    responseEst.porcentajesubNcicontEpilepsia2019 = porcentajesubNcicontEpilepsia2019;
                    responseEst.porcentajesubNcicontMeningitis2019 = porcentajesubNcicontMeningitis2019;
                    responseEst.porcentajesubNcicontOtros2019 = porcentajesubNcicontOtros2019;
                    //Respiratorio 2019
                    responseEst.porcentajesubResciChoqueSeptico_Neumonia2019 = porcentajesubResciChoqueSeptico_Neumonia2019;
                    responseEst.porcentajesubResciTEP2019 = porcentajesubResciTEP2019;
                    responseEst.porcentajesubResciEAP2019 = porcentajesubResciEAP2019;
                    responseEst.porcentajesubResciAsma_EPOC2019 = porcentajesubResciAsma_EPOC2019;
                    responseEst.porcentajesubResciOtros2019 = porcentajesubResciOtros2019;
                    //Cardiovascular 2019
                    responseEst.porcentajesubCarciChoqueCardiogenico2019 = porcentajesubCarciChoqueCardiogenico2019;
                    responseEst.porcentajesubCarciPostOperadoCirugiaCardiaca2019 = porcentajesubCarciPostOperadoCirugiaCardiaca2019;
                    responseEst.porcentajesubCarciTaquiarritmiaBradiarritmia2019 = porcentajesubCarciTaquiarritmiaBradiarritmia2019;
                    responseEst.porcentajesubCarciCrisisHipertensivas2019 = porcentajesubCarciCrisisHipertensivas2019;
                    responseEst.porcentajesubCarciPostParo2019 = porcentajesubCarciPostParo2019;
                    responseEst.porcentajesubCarciOtros2019 = porcentajesubCarciOtros2019;
                    //Gastrointestinal 2019
                    responseEst.porcentajesubGasciPancreatitisAguda2019 = porcentajesubGasciPancreatitisAguda2019;
                    responseEst.porcentajesubGasciHemorragiaDigestiva2019 = porcentajesubGasciHemorragiaDigestiva2019;
                    responseEst.porcentajesubGasciPostOperadosComplicados2019 = porcentajesubGasciPostOperadosComplicados2019;
                    responseEst.porcentajesubGasciOtros2019 = porcentajesubGasciOtros2019;
                    //NeurolOgico 2020                    
                    responseEst.porcentajesubNcicontTEC2020 = porcentajesubNcicontTEC2020;
                    responseEst.porcentajesubNcicontAVC2020 = porcentajesubNcicontAVC2020;
                    responseEst.porcentajesubNcicontEpilepsia2020 = porcentajesubNcicontEpilepsia2020;
                    responseEst.porcentajesubNcicontMeningitis2020 = porcentajesubNcicontMeningitis2020;
                    responseEst.porcentajesubNcicontOtros2020 = porcentajesubNcicontOtros2020;
                    //Respiratorio 2020
                    responseEst.porcentajesubResciChoqueSeptico_Neumonia2020 = porcentajesubResciChoqueSeptico_Neumonia2020;
                    responseEst.porcentajesubResciTEP2020 = porcentajesubResciTEP2020;
                    responseEst.porcentajesubResciEAP2020 = porcentajesubResciEAP2020;
                    responseEst.porcentajesubResciAsma_EPOC2020 = porcentajesubResciAsma_EPOC2020;
                    responseEst.porcentajesubResciOtros2020 = porcentajesubResciOtros2020;
                    //Cardiovascular 2020
                    responseEst.porcentajesubCarciChoqueCardiogenico2020 = porcentajesubCarciChoqueCardiogenico2020;
                    responseEst.porcentajesubCarciPostOperadoCirugiaCardiaca2020 = porcentajesubCarciPostOperadoCirugiaCardiaca2020;
                    responseEst.porcentajesubCarciTaquiarritmiaBradiarritmia2020 = porcentajesubCarciTaquiarritmiaBradiarritmia2020;
                    responseEst.porcentajesubCarciCrisisHipertensivas2020 = porcentajesubCarciCrisisHipertensivas2020;
                    responseEst.porcentajesubCarciPostParo2020 = porcentajesubCarciPostParo2020;
                    responseEst.porcentajesubCarciOtros2020 = porcentajesubCarciOtros2020;
                    //Gastrointestinal 2020
                    responseEst.porcentajesubGasciPancreatitisAguda2020 = porcentajesubGasciPancreatitisAguda2020;
                    responseEst.porcentajesubGasciHemorragiaDigestiva2020 = porcentajesubGasciHemorragiaDigestiva2020;
                    responseEst.porcentajesubGasciPostOperadosComplicados2020 = porcentajesubGasciPostOperadosComplicados2020;
                    responseEst.porcentajesubGasciOtros2020 = porcentajesubGasciOtros2020;
                    //NeurolOgico 2021                    
                    responseEst.porcentajesubNcicontTEC2021 = porcentajesubNcicontTEC2021;
                    responseEst.porcentajesubNcicontAVC2021 = porcentajesubNcicontAVC2021;
                    responseEst.porcentajesubNcicontEpilepsia2021 = porcentajesubNcicontEpilepsia2021;
                    responseEst.porcentajesubNcicontMeningitis2021 = porcentajesubNcicontMeningitis2021;
                    responseEst.porcentajesubNcicontOtros2021 = porcentajesubNcicontOtros2021;
                    //Respiratorio 2021
                    responseEst.porcentajesubResciChoqueSeptico_Neumonia2021 = porcentajesubResciChoqueSeptico_Neumonia2021;
                    responseEst.porcentajesubResciTEP2021 = porcentajesubResciTEP2021;
                    responseEst.porcentajesubResciEAP2021 = porcentajesubResciEAP2021;
                    responseEst.porcentajesubResciAsma_EPOC2021 = porcentajesubResciAsma_EPOC2021;
                    responseEst.porcentajesubResciOtros2021 = porcentajesubResciOtros2021;
                    //Cardiovascular 2021
                    responseEst.porcentajesubCarciChoqueCardiogenico2021 = porcentajesubCarciChoqueCardiogenico2021;
                    responseEst.porcentajesubCarciPostOperadoCirugiaCardiaca2021 = porcentajesubCarciPostOperadoCirugiaCardiaca2021;
                    responseEst.porcentajesubCarciTaquiarritmiaBradiarritmia2021 = porcentajesubCarciTaquiarritmiaBradiarritmia2021;
                    responseEst.porcentajesubCarciCrisisHipertensivas2021 = porcentajesubCarciCrisisHipertensivas2021;
                    responseEst.porcentajesubCarciPostParo2021 = porcentajesubCarciPostParo2021;
                    responseEst.porcentajesubCarciOtros2021 = porcentajesubCarciOtros2021;
                    //Gastrointestinal 2021
                    responseEst.porcentajesubGasciPancreatitisAguda2021 = porcentajesubGasciPancreatitisAguda2021;
                    responseEst.porcentajesubGasciHemorragiaDigestiva2021 = porcentajesubGasciHemorragiaDigestiva2021;
                    responseEst.porcentajesubGasciPostOperadosComplicados2021 = porcentajesubGasciPostOperadosComplicados2021;
                    responseEst.porcentajesubGasciOtros2021 = porcentajesubGasciOtros2021;


                    //NeurolOgico 2022                    
                    responseEst.porcentajesubNcicontTEC2022 = porcentajesubNcicontTEC2022;
                    responseEst.porcentajesubNcicontAVC2022 = porcentajesubNcicontAVC2022;
                    responseEst.porcentajesubNcicontEpilepsia2022 = porcentajesubNcicontEpilepsia2022;
                    responseEst.porcentajesubNcicontMeningitis2022 = porcentajesubNcicontMeningitis2022;
                    responseEst.porcentajesubNcicontOtros2022 = porcentajesubNcicontOtros2022;
                    //Respiratorio 2022
                    responseEst.porcentajesubResciChoqueSeptico_Neumonia2022 = porcentajesubResciChoqueSeptico_Neumonia2022;
                    responseEst.porcentajesubResciTEP2022 = porcentajesubResciTEP2022;
                    responseEst.porcentajesubResciEAP2022 = porcentajesubResciEAP2022;
                    responseEst.porcentajesubResciAsma_EPOC2022 = porcentajesubResciAsma_EPOC2022;
                    responseEst.porcentajesubResciOtros2022 = porcentajesubResciOtros2022;
                    //Cardiovascular 2022
                    responseEst.porcentajesubCarciChoqueCardiogenico2022 = porcentajesubCarciChoqueCardiogenico2022;
                    responseEst.porcentajesubCarciPostOperadoCirugiaCardiaca2022 = porcentajesubCarciPostOperadoCirugiaCardiaca2022;
                    responseEst.porcentajesubCarciTaquiarritmiaBradiarritmia2022 = porcentajesubCarciTaquiarritmiaBradiarritmia2022;
                    responseEst.porcentajesubCarciCrisisHipertensivas2022 = porcentajesubCarciCrisisHipertensivas2022;
                    responseEst.porcentajesubCarciPostParo2022 = porcentajesubCarciPostParo2022;
                    responseEst.porcentajesubCarciOtros2022 = porcentajesubCarciOtros2022;
                    //Gastrointestinal 2022
                    responseEst.porcentajesubGasciPancreatitisAguda2022 = porcentajesubGasciPancreatitisAguda2022;
                    responseEst.porcentajesubGasciHemorragiaDigestiva2022 = porcentajesubGasciHemorragiaDigestiva2022;
                    responseEst.porcentajesubGasciPostOperadosComplicados2022 = porcentajesubGasciPostOperadosComplicados2022;
                    responseEst.porcentajesubGasciOtros2022 = porcentajesubGasciOtros2022;

                    //NeurolOgico 2023                    
                    responseEst.porcentajesubNcicontTEC2023 = porcentajesubNcicontTEC2023;
                    responseEst.porcentajesubNcicontAVC2023 = porcentajesubNcicontAVC2023;
                    responseEst.porcentajesubNcicontEpilepsia2023 = porcentajesubNcicontEpilepsia2023;
                    responseEst.porcentajesubNcicontMeningitis2023 = porcentajesubNcicontMeningitis2023;
                    responseEst.porcentajesubNcicontOtros2023 = porcentajesubNcicontOtros2023;
                    //Respiratorio 2023
                    responseEst.porcentajesubResciChoqueSeptico_Neumonia2023 = porcentajesubResciChoqueSeptico_Neumonia2023;
                    responseEst.porcentajesubResciTEP2023 = porcentajesubResciTEP2023;
                    responseEst.porcentajesubResciEAP2023 = porcentajesubResciEAP2023;
                    responseEst.porcentajesubResciAsma_EPOC2023 = porcentajesubResciAsma_EPOC2023;
                    responseEst.porcentajesubResciOtros2023 = porcentajesubResciOtros2023;
                    //Cardiovascular 2023
                    responseEst.porcentajesubCarciChoqueCardiogenico2023 = porcentajesubCarciChoqueCardiogenico2023;
                    responseEst.porcentajesubCarciPostOperadoCirugiaCardiaca2023 = porcentajesubCarciPostOperadoCirugiaCardiaca2023;
                    responseEst.porcentajesubCarciTaquiarritmiaBradiarritmia2023 = porcentajesubCarciTaquiarritmiaBradiarritmia2023;
                    responseEst.porcentajesubCarciCrisisHipertensivas2023 = porcentajesubCarciCrisisHipertensivas2023;
                    responseEst.porcentajesubCarciPostParo2023 = porcentajesubCarciPostParo2023;
                    responseEst.porcentajesubCarciOtros2023 = porcentajesubCarciOtros2023;
                    //Gastrointestinal 2023
                    responseEst.porcentajesubGasciPancreatitisAguda2023 = porcentajesubGasciPancreatitisAguda2023;
                    responseEst.porcentajesubGasciHemorragiaDigestiva2023 = porcentajesubGasciHemorragiaDigestiva2023;
                    responseEst.porcentajesubGasciPostOperadosComplicados2023 = porcentajesubGasciPostOperadosComplicados2023;
                    responseEst.porcentajesubGasciOtros2023 = porcentajesubGasciOtros2023;

                    #endregion

                    #region Servicio Egreso
                    responseEst.secontSalacomun2019 = secontSalacomun2019;
                    responseEst.secontTerapia_intermedia2019 = secontTerapia_intermedia2019;
                    responseEst.secontAlta_hospitalaria2019 = secontAlta_hospitalaria2019;
                    responseEst.secontFallece2019 = secontFallece2019;

                    responseEst.secontSalacomun2020 = secontSalacomun2020;
                    responseEst.secontTerapia_intermedia2020 = secontTerapia_intermedia2020;
                    responseEst.secontAlta_hospitalaria2020 = secontAlta_hospitalaria2020;
                    responseEst.secontFallece2020 = secontFallece2020;

                    responseEst.secontSalacomun2021 = secontSalacomun2021;
                    responseEst.secontTerapia_intermedia2021 = secontTerapia_intermedia2021;
                    responseEst.secontAlta_hospitalaria2021 = secontAlta_hospitalaria2021;
                    responseEst.secontFallece2021 = secontFallece2021;

                    responseEst.secontSalacomun2022 = secontSalacomun2022;
                    responseEst.secontTerapia_intermedia2022 = secontTerapia_intermedia2022;
                    responseEst.secontAlta_hospitalaria2022 = secontAlta_hospitalaria2022;
                    responseEst.secontFallece2022 = secontFallece2022;

                    responseEst.secontSalacomun2023 = secontSalacomun2023;
                    responseEst.secontTerapia_intermedia2023 = secontTerapia_intermedia2023;
                    responseEst.secontAlta_hospitalaria2023 = secontAlta_hospitalaria2023;
                    responseEst.secontFallece2023 = secontFallece2023;
                    //TOTALgLOVALES
                    responseEst.secontSalacomunGlobal = secontSalacomunGlobal;
                    responseEst.secontTerapia_intermediaGlobal = secontTerapia_intermediaGlobal;
                    responseEst.secontAlta_hospitalariaGlobal = secontAlta_hospitalariaGlobal;
                    responseEst.secontFalleceGlobal = secontFalleceGlobal;

                    responseEst.seTotalGlobales = seTotalGlobales;


                    responseEst.seporcentajeSalacomunGlobal = seporcentajeSalacomunGlobal;
                    responseEst.seporcentajeTerapia_intermediaGlobal = seporcentajeTerapia_intermediaGlobal;
                    responseEst.seporcentajeAlta_hospitalariaGlobal = seporcentajeAlta_hospitalariaGlobal;
                    responseEst.seporcentajeFalleceGlobal = seporcentajeFalleceGlobal;


                    //Individuales
                    responseEst.secontall2019 = secontall2019;

                    responseEst.seporcentajeSalacomun2019 = seporcentajeSalacomun2019;
                    responseEst.seporcentajeTerapia_intermedia2019 = seporcentajeTerapia_intermedia2019;
                    responseEst.seporcentajeAlta_hospitalaria2019 = seporcentajeAlta_hospitalaria2019;
                    responseEst.seporcentajeFallece2019 = seporcentajeFallece2019;


                    responseEst.secontall2020 = secontall2020;

                    responseEst.seporcentajeSalacomun2020 = seporcentajeSalacomun2020;
                    responseEst.seporcentajeTerapia_intermedia2020 = seporcentajeTerapia_intermedia2020;
                    responseEst.seporcentajeAlta_hospitalaria2020 = seporcentajeAlta_hospitalaria2020;
                    responseEst.seporcentajeFallece2020 = seporcentajeFallece2020;

                    responseEst.secontall2021 = secontall2021;

                    responseEst.seporcentajeSalacomun2021 = seporcentajeSalacomun2021;
                    responseEst.seporcentajeTerapia_intermedia2021 = seporcentajeTerapia_intermedia2021;
                    responseEst.seporcentajeAlta_hospitalaria2021 = seporcentajeAlta_hospitalaria2021;
                    responseEst.seporcentajeFallece2021 = seporcentajeFallece2021;

                    responseEst.secontall2022 = secontall2022;

                    responseEst.seporcentajeSalacomun2022 = seporcentajeSalacomun2022;
                    responseEst.seporcentajeTerapia_intermedia2022 = seporcentajeTerapia_intermedia2022;
                    responseEst.seporcentajeAlta_hospitalaria2022 = seporcentajeAlta_hospitalaria2022;
                    responseEst.seporcentajeFallece2022 = seporcentajeFallece2022;

                    responseEst.secontall2023 = secontall2023;

                    responseEst.seporcentajeSalacomun2023 = seporcentajeSalacomun2023;
                    responseEst.seporcentajeTerapia_intermedia2023 = seporcentajeTerapia_intermedia2023;
                    responseEst.seporcentajeAlta_hospitalaria2023 = seporcentajeAlta_hospitalaria2023;
                    responseEst.seporcentajeFallece2023 = seporcentajeFallece2023;
                    #endregion

                    #region Causa Egreso
                    responseEst.cmNeurologico2019 = cmNeurologico2019;
                    responseEst.cmRespiratorio2019 = cmRespiratorio2019;
                    responseEst.cmCardiovascular2019 = cmCardiovascular2019;
                    responseEst.cmGastrointestinal2019 = cmGastrointestinal2019;
                    responseEst.cmRenalEndocrinologico2019 = cmRenalEndocrinologico2019;
                    responseEst.cmFallaMultiorganica2019 = cmFallaMultiorganica2019;
                    responseEst.cmOtros2019 = cmOtros2019;
                    responseEst.cmNoFallecidos2019 = cmNoFallecidos2019;

                    responseEst.cmNeurologico2020 = cmNeurologico2020;
                    responseEst.cmRespiratorio2020 = cmRespiratorio2020;
                    responseEst.cmCardiovascular2020 = cmCardiovascular2020;
                    responseEst.cmGastrointestinal2020 = cmGastrointestinal2020;
                    responseEst.cmRenalEndocrinologico2020 = cmRenalEndocrinologico2020;
                    responseEst.cmFallaMultiorganica2020 = cmFallaMultiorganica2020;
                    responseEst.cmOtros2020 = cmOtros2020;
                    responseEst.cmNoFallecidos2020 = cmNoFallecidos2020;

                    responseEst.cmNeurologico2021 = cmNeurologico2021;
                    responseEst.cmRespiratorio2021 = cmRespiratorio2021;
                    responseEst.cmCardiovascular2021 = cmCardiovascular2021;
                    responseEst.cmGastrointestinal2021 = cmGastrointestinal2021;
                    responseEst.cmRenalEndocrinologico2021 = cmRenalEndocrinologico2021;
                    responseEst.cmFallaMultiorganica2021 = cmFallaMultiorganica2021;
                    responseEst.cmOtros2021 = cmOtros2021;
                    responseEst.cmNoFallecidos2021 = cmNoFallecidos2021;

                    responseEst.cmNeurologico2022 = cmNeurologico2022;
                    responseEst.cmRespiratorio2022 = cmRespiratorio2022;
                    responseEst.cmCardiovascular2022 = cmCardiovascular2022;
                    responseEst.cmGastrointestinal2022 = cmGastrointestinal2022;
                    responseEst.cmRenalEndocrinologico2022 = cmRenalEndocrinologico2022;
                    responseEst.cmFallaMultiorganica2022 = cmFallaMultiorganica2022;
                    responseEst.cmOtros2022 = cmOtros2022;
                    responseEst.cmNoFallecidos2022 = cmNoFallecidos2022;


                    responseEst.cmNeurologico2023 = cmNeurologico2023;
                    responseEst.cmRespiratorio2023 = cmRespiratorio2023;
                    responseEst.cmCardiovascular2023 = cmCardiovascular2023;
                    responseEst.cmGastrointestinal2023 = cmGastrointestinal2023;
                    responseEst.cmRenalEndocrinologico2023 = cmRenalEndocrinologico2023;
                    responseEst.cmFallaMultiorganica2023 = cmFallaMultiorganica2023;
                    responseEst.cmOtros2023 = cmOtros2023;
                    responseEst.cmNoFallecidos2023 = cmNoFallecidos2023;


                    //Global causa de mortalidad
                    responseEst.cmNeurologicoGlobal = cmNeurologicoGlobal;
                    responseEst.cmRespiratorioGlobal = cmRespiratorioGlobal;
                    responseEst.cmCardiovascularGlobal = cmCardiovascularGlobal;
                    responseEst.cmGastrointestinalGlobal = cmGastrointestinalGlobal;
                    responseEst.cmRenalEndocrinologicoGlobal = cmRenalEndocrinologicoGlobal;
                    responseEst.cmFallaMultiorganicaGlobal = cmFallaMultiorganicaGlobal;
                    responseEst.cmOtrosGlobal = cmOtrosGlobal;
                    responseEst.cmNoFallecidosGlobal = cmNoFallecidosGlobal;


                    responseEst.cmTotalGlobal = cmTotalGlobal;

                    responseEst.cmporcentajeNeurologicosGlobal = cmporcentajeNeurologicosGlobal;
                    responseEst.cmporcentajeRespiratorioGlobal = cmporcentajeRespiratorioGlobal;
                    responseEst.cmporcentajeCardiovascularGlobal = cmporcentajeCardiovascularGlobal;
                    responseEst.cmporcentajeGastrointestinalGlobal = cmporcentajeGastrointestinalGlobal;
                    responseEst.cmporcentajeEndocrinologicoGlobal = cmporcentajeEndocrinologicoGlobal;
                    responseEst.cmporcentajeFallaMultiorganicaGlobal = cmporcentajeFallaMultiorganicaGlobal;
                    responseEst.cmporcentajeOtrosGlobal = cmporcentajeOtrosGlobal;
                    responseEst.cmporcentajeNoFallecidosGlobal = cmporcentajeNoFallecidosGlobal;

                    //Individual

                    responseEst.cmTotal2019 = cmTotal2019;
                    responseEst.cmporcentajeNeurologicos2019 = cmporcentajeNeurologicos2019;
                    responseEst.cmporcentajeRespiratorio2019 = cmporcentajeRespiratorio2019;
                    responseEst.cmporcentajeCardiovascular2019 = cmporcentajeCardiovascular2019;
                    responseEst.cmporcentajeGastrointestinal2019 = cmporcentajeGastrointestinal2019;
                    responseEst.cmporcentajeEndocrinologico2019 = cmporcentajeEndocrinologico2019;
                    responseEst.cmporcentajeFallaMultiorganica2019 = cmporcentajeFallaMultiorganica2019;
                    responseEst.cmporcentajeOtros2019 = cmporcentajeOtros2019;
                    responseEst.cmporcentajeNoFallecidos2019 = cmporcentajeNoFallecidos2019;



                    responseEst.cmTotal2020 = cmTotal2020;
                    responseEst.cmporcentajeNeurologicos2020 = cmporcentajeNeurologicos2020;

                    responseEst.cmporcentajeRespiratorio2020 = cmporcentajeRespiratorio2020;
                    responseEst.cmporcentajeCardiovascular2020 = cmporcentajeCardiovascular2020;
                    responseEst.cmporcentajeGastrointestinal2020 = cmporcentajeGastrointestinal2020;
                    responseEst.cmporcentajeEndocrinologico2020 = cmporcentajeEndocrinologico2020;
                    responseEst.cmporcentajeFallaMultiorganica2020 = cmporcentajeFallaMultiorganica2020;
                    responseEst.cmporcentajeOtros2020 = cmporcentajeOtros2020;
                    responseEst.cmporcentajeNoFallecidos2020 = cmporcentajeNoFallecidos2020;


                    responseEst.cmTotal2021 = cmTotal2021;
                    responseEst.cmporcentajeNeurologicos2021 = cmporcentajeNeurologicos2021;

                    responseEst.cmporcentajeRespiratorio2021 = cmporcentajeRespiratorio2021;
                    responseEst.cmporcentajeCardiovascular2021 = cmporcentajeCardiovascular2021;
                    responseEst.cmporcentajeGastrointestinal2021 = cmporcentajeGastrointestinal2021;
                    responseEst.cmporcentajeEndocrinologico2021 = cmporcentajeEndocrinologico2021;
                    responseEst.cmporcentajeFallaMultiorganica2021 = cmporcentajeFallaMultiorganica2021;
                    responseEst.cmporcentajeOtros2021 = cmporcentajeOtros2021;
                    responseEst.cmporcentajeNoFallecidos2021 = cmporcentajeNoFallecidos2021;


                    responseEst.cmTotal2022 = cmTotal2022;
                    responseEst.cmporcentajeNeurologicos2022 = cmporcentajeNeurologicos2022;
                    responseEst.cmporcentajeRespiratorio2022 = cmporcentajeRespiratorio2022;
                    responseEst.cmporcentajeCardiovascular2022 = cmporcentajeCardiovascular2022;
                    responseEst.cmporcentajeGastrointestinal2022 = cmporcentajeGastrointestinal2022;
                    responseEst.cmporcentajeEndocrinologico2022 = cmporcentajeEndocrinologico2022;
                    responseEst.cmporcentajeFallaMultiorganica2022 = cmporcentajeFallaMultiorganica2022;
                    responseEst.cmporcentajeOtros2022 = cmporcentajeOtros2022;
                    responseEst.cmporcentajeNoFallecidos2022 = cmporcentajeNoFallecidos2022;


                    responseEst.cmTotal2023 = cmTotal2023;
                    responseEst.cmporcentajeNeurologicos2023 = cmporcentajeNeurologicos2023;
                    responseEst.cmporcentajeRespiratorio2023 = cmporcentajeRespiratorio2023;
                    responseEst.cmporcentajeCardiovascular2023 = cmporcentajeCardiovascular2023;
                    responseEst.cmporcentajeGastrointestinal2023 = cmporcentajeGastrointestinal2023;
                    responseEst.cmporcentajeEndocrinologico2023 = cmporcentajeEndocrinologico2023;
                    responseEst.cmporcentajeFallaMultiorganica2023 = cmporcentajeFallaMultiorganica2023;
                    responseEst.cmporcentajeOtros2023 = cmporcentajeOtros2023;
                    responseEst.cmporcentajeNoFallecidos2023 = cmporcentajeNoFallecidos2023;
                    #endregion


                    #endregion





                    return responseEst;
                }
                else
                {
                    return responseEst;
                }


            }
            catch (Exception ex)
            {
                return responseEst;
            }


        }
        #endregion
    }


}
