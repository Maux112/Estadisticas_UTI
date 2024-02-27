///////PARA TASA DE INGRESOS/////////////
$("#btnVerGraficoTasaIngresos").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico: Tasa de Ingresos");
    $("#modal-1").modal("show");
    tasaIngresosGrafico();
});
function tasaIngresosGrafico() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var tasaIngresos2019 = miObjeto.contador2019;
    var tasaIngresos2020 = miObjeto.contador2020;
    var tasaIngresos2021 = miObjeto.contador2021;
    var tasaIngresos2022 = miObjeto.contador2022;
    var tasaIngresos2023 = miObjeto.contador2023;

   // alert(tasaIngresos2019);
    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'column'
        },
        title: {
            text: 'Tasa de Ingresos 2019-2023'
        },
        xAxis: {
            categories: ['Ingresos 2019', 'Ingresos 2020', 'Ingresos 2021', 'Ingresos 2022', 'Ingresos 2023']
        },
        series: [{
            data: [
                {
                    name: '2019',
                    color: '#BB8FCE',
                    y: tasaIngresos2019
                },
                {
                    name: '2020',
                    color: '#0097A7',
                    y: tasaIngresos2020
                },
                {
                    name: '2021',
                    color: '#D98880',
                    y: tasaIngresos2021
                },
                {
                    name: '2022',
                    color: '#F5B041',
                    y: tasaIngresos2022
                },
                {
                    name: '2023',
                    color: '#196F3D',
                    y: tasaIngresos2023
                }]
        }]
    });

}


/////////////////SEXO/////////////////////////////
$("#verGraficoSexo2019").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoSex2019();
});
function graficoSex2019() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajeMasculino2019 = miObjeto.contadorSex2019m;
    var porcentajeFemenino2019 = miObjeto.contadorSex2019f;

    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Porcentaje de varones y mujeres que ingresaron al servicio en 2019'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: '2019',
            colorByPoint: true,
            data: [{
                name: 'Varones',
                y: porcentajeMasculino2019,
                sliced: true,
                selected: true          
            }, {
                name: 'Mujeres',
                y: porcentajeFemenino2019
            }]
        }]
    });
}
$("#verGraficoSexo2020").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoSex2020();
});
function graficoSex2020() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajeMasculino2020 = miObjeto.contadorSex2020m;
    var porcentajeFemenino2020 = miObjeto.contadorSex2020f;

    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Porcentaje de varones y mujeres que ingresaron al servicio en 2020'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: '2020',
            colorByPoint: true,
            data: [{
                name: 'Varones',
                y: porcentajeMasculino2020,
                sliced: true,
                selected: true
            }, {
                name: 'Mujeres',
                y: porcentajeFemenino2020
            }]
        }]
    });
}
$("#verGraficoSexo2021").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoSex2021();
});
function graficoSex2021() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajeMasculino2021 = miObjeto.contadorSex2021m;
    var porcentajeFemenino2021 = miObjeto.contadorSex2021f;

    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Porcentaje de varones y mujeres que ingresaron al servicio en 2021'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: '2021',
            colorByPoint: true,
            data: [{
                name: 'Varones',
                y: porcentajeMasculino2021,
                sliced: true,
                selected: true
            }, {
                name: 'Mujeres',
                y: porcentajeFemenino2021
            }]
        }]
    });
}
$("#verGraficoSexo2022").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoSex2022();
});
function graficoSex2022() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajeMasculino2022 = miObjeto.contadorSex2022m;
    var porcentajeFemenino2022 = miObjeto.contadorSex2022f;

    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Porcentaje de varones y mujeres que ingresaron al servicio en 2022'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: '2022',
            colorByPoint: true,
            data: [{
                name: 'Varones',
                y: porcentajeMasculino2022,
                sliced: true,
                selected: true
            }, {
                name: 'Mujeres',
                y: porcentajeFemenino2022
            }]
        }]
    });
}
$("#verGraficoSexo2023").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoSex2023();
});
function graficoSex2023() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajeMasculino2023 = miObjeto.contadorSex2023m;
    var porcentajeFemenino2023 = miObjeto.contadorSex2023f;

    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Porcentaje de varones y mujeres que ingresaron al servicio en 2023'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: '2023',
            colorByPoint: true,
            data: [{
                name: 'Varones',
                y: porcentajeMasculino2023,
                sliced: true,
                selected: true
            }, {
                name: 'Mujeres',
                y: porcentajeFemenino2023
            }]
        }]
    });
}
$("#verGraficoSexoGlobal").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoSexGlobal();
});
function graficoSexGlobal() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajeMasculinoGlobal = miObjeto.contadorSexMasTotal;
    var porcentajeFemeninoGlobal = miObjeto.contadorSexFemTotal;

    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Porcentaje de varones y mujeres que ingresaron al servicio 2019 -2023'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: 'Global',
            colorByPoint: true,
            data: [{
                name: 'Varones',
                y: porcentajeMasculinoGlobal,
                sliced: true,
                selected: true
            }, {
                name: 'Mujeres',
                y: porcentajeFemeninoGlobal
            }]
        }]
    });
}
/////////////////Grupo etario/////////////////////////////

$("#verGraficoEdad2019").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoEdad2019();
});
function graficoEdad2019() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajeMenores30anos2019 = miObjeto.Menores30anos2019;
    var porcentajeAdultos30_59anos2019 = miObjeto.Adultos30_59anos2019;
    var porcentajeMayoresde60anos2019 = miObjeto.Mayoresde60anos2019;

    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Porcentaje Grupo Etario 2019'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: '2019',
            colorByPoint: true,
            data: [{
                name: 'Menores de 30 a 59 años',
                y: porcentajeMenores30anos2019,
                sliced: true,
                selected: true
            }, {
                name: 'Adultos de 30 a 59 años',
                y: porcentajeAdultos30_59anos2019
            }, {
                name: 'Mayores de 60 años',
                y: porcentajeMayoresde60anos2019
            }]
        }]
    });
}
$("#verGraficoEdad2020").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoEdad2020();
});
function graficoEdad2020() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajeMenores30anos2020 = miObjeto.Menores30anos2020;
    var porcentajeAdultos30_59anos2020 = miObjeto.Adultos30_59anos2020;
    var porcentajeMayoresde60anos2020 = miObjeto.Mayoresde60anos2020;

    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Porcentaje Grupo Etario 2020'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: '2020',
            colorByPoint: true,
            data: [{
                name: 'Menores de 30 a 59 años',
                y: porcentajeMenores30anos2020,
                sliced: true,
                selected: true
            }, {
                name: 'Adultos de 30 a 59 años',
                y: porcentajeAdultos30_59anos2020
            }, {
                name: 'Mayores de 60 años',
                y: porcentajeMayoresde60anos2020
            }]
        }]
    });
}
$("#verGraficoEdad2021").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoEdad2021();
});
function graficoEdad2021() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajeMenores30anos2021 = miObjeto.Menores30anos2021;
    var porcentajeAdultos30_59anos2021 = miObjeto.Adultos30_59anos2021;
    var porcentajeMayoresde60anos2021 = miObjeto.Mayoresde60anos2021;

    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Porcentaje Grupo Etario 2021'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: '2021',
            colorByPoint: true,
            data: [{
                name: 'Menores de 30 a 59 años',
                y: porcentajeMenores30anos2021,
                sliced: true,
                selected: true
            }, {
                name: 'Adultos de 30 a 59 años',
                y: porcentajeAdultos30_59anos2021
            }, {
                name: 'Mayores de 60 años',
                y: porcentajeMayoresde60anos2021
            }]
        }]
    });
}

$("#verGraficoEdad2022").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoEdad2022();
});
function graficoEdad2022() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajeMenores30anos2022 = miObjeto.Menores30anos2022;
    var porcentajeAdultos30_59anos2022 = miObjeto.Adultos30_59anos2022;
    var porcentajeMayoresde60anos2022 = miObjeto.Mayoresde60anos2022;

    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Porcentaje Grupo Etario 2022'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: '2022',
            colorByPoint: true,
            data: [{
                name: 'Menores de 30 a 59 años',
                y: porcentajeMenores30anos2022,
                sliced: true,
                selected: true
            }, {
                name: 'Adultos de 30 a 59 años',
                y: porcentajeAdultos30_59anos2022
            }, {
                name: 'Mayores de 60 años',
                y: porcentajeMayoresde60anos2022
            }]
        }]
    });
}
$("#verGraficoEdad2023").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoEdad2023();
});
function graficoEdad2023() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajeMenores30anos2023 = miObjeto.Menores30anos2023;
    var porcentajeAdultos30_59anos2023 = miObjeto.Adultos30_59anos2023;
    var porcentajeMayoresde60anos2023 = miObjeto.Mayoresde60anos2023;

    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Porcentaje Grupo Etario 2023'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: '2023',
            colorByPoint: true,
            data: [{
                name: 'Menores de 30 a 59 años',
                y: porcentajeMenores30anos2023,
                sliced: true,
                selected: true
            }, {
                name: 'Adultos de 30 a 59 años',
                y: porcentajeAdultos30_59anos2023
            }, {
                name: 'Mayores de 60 años',
                y: porcentajeMayoresde60anos2023
            }]
        }]
    });
}

$("#verGraficoEdadGlobal").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoEdadGlobal();
});
function graficoEdadGlobal() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajeMenores30anosGlobal = miObjeto.Menores30anosGlobal;
    var porcentajeAdultos30_59anosGlobal = miObjeto.Adultos30_59anosGlobal;
    var porcentajeMayoresde60anosGlobal = miObjeto.Mayoresde60anosGlobal;

    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Porcentaje Grupo Etario 2019 - 2023'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: 'Global',
            colorByPoint: true,
            data: [{
                name: 'Menores de 30 a 59 años',
                y: porcentajeMenores30anosGlobal,
                sliced: true,
                selected: true
            }, {
                name: 'Adultos de 30 a 59 años',
                y: porcentajeAdultos30_59anosGlobal
            }, {
                name: 'Mayores de 60 años',
                y: porcentajeMayoresde60anosGlobal
            }]
        }]
    });
}


/////////////////Estancia Uti/////////////////////////////

////////////////Origen de Ingreso/////////////////////////////

$("#verGraficoOriIngre2019").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoOrigenIngreso2019();
});
function graficoOrigenIngreso2019() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajeoicontEmergencias2019 = miObjeto.oicontEmergencias2019;
    var porcentajeoicontQuirofano2019 = miObjeto.oicontQuirofano2019;
    var porcentajeoicontSalacomun2019 = miObjeto.oicontSalacomun2019;
    var porcentajeoicontTransferenciadeotraUTI2019 = miObjeto.oicontTransferenciadeotraUTI2019;
    var porcentajeoicontOtros2019 = miObjeto.oicontOtros2019;

    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Servicios de origen de ingreso 2019'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: '2019',
            colorByPoint: true,
            data: [{
                name: 'Emergencias',
                y: porcentajeoicontEmergencias2019,
                sliced: true,
                selected: true
            }, {
                name: 'Quirofano',
                y: porcentajeoicontQuirofano2019
            }, {
                name: 'Sala común',
                y: porcentajeoicontSalacomun2019
            }, {               
                name: 'Transferencia de otra UTI',
                y: porcentajeoicontTransferenciadeotraUTI2019
            }, {
                name: 'Otros',
                y: porcentajeoicontOtros2019
            }]
        }]
    });
}
$("#verGraficoOriIngre2020").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoOrigenIngreso2020();
});
function graficoOrigenIngreso2020() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajeoicontEmergencias2020 = miObjeto.oicontEmergencias2020;
    var porcentajeoicontQuirofano2020 = miObjeto.oicontQuirofano2020;
    var porcentajeoicontSalacomun2020 = miObjeto.oicontSalacomun2020;
    var porcentajeoicontTransferenciadeotraUTI2020 = miObjeto.oicontTransferenciadeotraUTI2020;
    var porcentajeoicontOtros2020 = miObjeto.oicontOtros2020;

    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Servicios de origen de ingreso 2020'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: '2020',
            colorByPoint: true,
            data: [{
                name: 'Emergencias',
                y: porcentajeoicontEmergencias2020,
                sliced: true,
                selected: true
            }, {
                name: 'Quirofano',
                y: porcentajeoicontQuirofano2020
            }, {
                name: 'Sala común',
                y: porcentajeoicontSalacomun2020
            }, {
                name: 'Transferencia de otra UTI',
                y: porcentajeoicontTransferenciadeotraUTI2020
            }, {
                name: 'Otros',
                y: porcentajeoicontOtros2020
            }]
        }]
    });
}

$("#verGraficoOriIngre2021").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoOrigenIngreso2021();
});
function graficoOrigenIngreso2021() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajeoicontEmergencias2021 = miObjeto.oicontEmergencias2021;
    var porcentajeoicontQuirofano2021 = miObjeto.oicontQuirofano2021;
    var porcentajeoicontSalacomun2021 = miObjeto.oicontSalacomun2021;
    var porcentajeoicontTransferenciadeotraUTI2021 = miObjeto.oicontTransferenciadeotraUTI2021;
    var porcentajeoicontOtros2021 = miObjeto.oicontOtros2021;

    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Servicios de origen de ingreso 2021'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: '2021',
            colorByPoint: true,
            data: [{
                name: 'Emergencias',
                y: porcentajeoicontEmergencias2021,
                sliced: true,
                selected: true
            }, {
                name: 'Quirofano',
                y: porcentajeoicontQuirofano2021
            }, {
                name: 'Sala común',
                y: porcentajeoicontSalacomun2021
            }, {
                name: 'Transferencia de otra UTI',
                y: porcentajeoicontTransferenciadeotraUTI2021
            }, {
                name: 'Otros',
                y: porcentajeoicontOtros2021
            }]
        }]
    });
}
$("#verGraficoOriIngre2022").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoOrigenIngreso2022();
});
function graficoOrigenIngreso2022() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajeoicontEmergencias2022 = miObjeto.oicontEmergencias2022;
    var porcentajeoicontQuirofano2022 = miObjeto.oicontQuirofano2022;
    var porcentajeoicontSalacomun2022 = miObjeto.oicontSalacomun2022;
    var porcentajeoicontTransferenciadeotraUTI2022 = miObjeto.oicontTransferenciadeotraUTI2022;
    var porcentajeoicontOtros2022 = miObjeto.oicontOtros2022;

    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Servicios de origen de ingreso 2022'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: '2022',
            colorByPoint: true,
            data: [{
                name: 'Emergencias',
                y: porcentajeoicontEmergencias2022,
                sliced: true,
                selected: true
            }, {
                name: 'Quirofano',
                y: porcentajeoicontQuirofano2022
            }, {
                name: 'Sala común',
                y: porcentajeoicontSalacomun2022
            }, {
                name: 'Transferencia de otra UTI',
                y: porcentajeoicontTransferenciadeotraUTI2022
            }, {
                name: 'Otros',
                y: porcentajeoicontOtros2022
            }]
        }]
    });
}
$("#verGraficoOriIngre2023").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoOrigenIngreso2023();
});
function graficoOrigenIngreso2023() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajeoicontEmergencias2023 = miObjeto.oicontEmergencias2023;
    var porcentajeoicontQuirofano2023 = miObjeto.oicontQuirofano2023;
    var porcentajeoicontSalacomun2023 = miObjeto.oicontSalacomun2023;
    var porcentajeoicontTransferenciadeotraUTI2023 = miObjeto.oicontTransferenciadeotraUTI2023;
    var porcentajeoicontOtros2023 = miObjeto.oicontOtros2023;

    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Servicios de origen de ingreso 2023'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: '2023',
            colorByPoint: true,
            data: [{
                name: 'Emergencias',
                y: porcentajeoicontEmergencias2023,
                sliced: true,
                selected: true
            }, {
                name: 'Quirofano',
                y: porcentajeoicontQuirofano2023
            }, {
                name: 'Sala común',
                y: porcentajeoicontSalacomun2023
            }, {
                name: 'Transferencia de otra UTI',
                y: porcentajeoicontTransferenciadeotraUTI2023
            }, {
                name: 'Otros',
                y: porcentajeoicontOtros2023
            }]
        }]
    });
}

$("#verGraficoOriIngreGlobal").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoOrigenIngresoGlobal();
});
function graficoOrigenIngresoGlobal() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajeoicontEmergenciasGlobal = miObjeto.totalGlobalEmergencias;
    var porcentajeoicontQuirofanoGlobal = miObjeto.totalGlobalQuirofano;
    var porcentajeoicontSalacomunGlobal = miObjeto.totalGlobalSalaComun;
    var porcentajeoicontTransferenciadeotraUTIGlobal = miObjeto.totalGlobalTransferenciaOtraUTI;
    var porcentajeoicontOtrosGlobal = miObjeto.totalGlobalOtros;

    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Servicios de origen de ingreso Global'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: 'Global',
            colorByPoint: true,
            data: [{
                name: 'Emergencias',
                y: porcentajeoicontEmergenciasGlobal,
                sliced: true,
                selected: true
            }, {
                name: 'Quirofano',
                y: porcentajeoicontQuirofanoGlobal
            }, {
                name: 'Sala común',
                y: porcentajeoicontSalacomunGlobal
            }, {
                name: 'Transferencia de otra UTI',
                y: porcentajeoicontTransferenciadeotraUTIGlobal
            }, {
                name: 'Otros',
                y: porcentajeoicontOtrosGlobal
            }]
        }]
    });
}

////////////////SERVICIO DE EGRESO/////////////////////////////
$("#verGraficoServEgre2019").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoServEgre2019();
});
function graficoServEgre2019() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajesecontSalacomun2019 = miObjeto.secontSalacomun2019;
    var porcentajesecontTerapia_intermedia2019 = miObjeto.secontTerapia_intermedia2019;
    var porcentajesecontAlta_hospitalaria2019 = miObjeto.secontAlta_hospitalaria2019;
    var porcentajesecontFallece2019 = miObjeto.secontFallece2019;


    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Servicios de egreso y tasa bruta de mortalidad 2019'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: '2019',
            colorByPoint: true,
            data: [{
                name: 'Sala común',
                y: porcentajesecontSalacomun2019,
                sliced: true,
                selected: true
            }, {
                name: 'Terapia Intermedia',
                y: porcentajesecontTerapia_intermedia2019
            }, {
                name: 'Alta hospitalaria',
                y: porcentajesecontAlta_hospitalaria2019
            }, {
                name: 'Fallece',
                y: porcentajesecontFallece2019
            }]
        }]
    });
}

$("#verGraficoServEgre2020").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoServEgre2020();
});
function graficoServEgre2020() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajesecontSalacomun2020 = miObjeto.secontSalacomun2020;
    var porcentajesecontTerapia_intermedia2020 = miObjeto.secontTerapia_intermedia2020;
    var porcentajesecontAlta_hospitalaria2020 = miObjeto.secontAlta_hospitalaria2020;
    var porcentajesecontFallece2020 = miObjeto.secontFallece2020;


    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Servicios de egreso y tasa bruta de mortalidad 2020'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: '2020',
            colorByPoint: true,
            data: [{
                name: 'Sala común',
                y: porcentajesecontSalacomun2020,
                sliced: true,
                selected: true
            }, {
                name: 'Terapia Intermedia',
                y: porcentajesecontTerapia_intermedia2020
            }, {
                name: 'Alta hospitalaria',
                y: porcentajesecontAlta_hospitalaria2020
            }, {
                name: 'Fallece',
                y: porcentajesecontFallece2020
            }]
        }]
    });
}
$("#verGraficoServEgre2021").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoServEgre2021();
});
function graficoServEgre2021() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajesecontSalacomun2021 = miObjeto.secontSalacomun2021;
    var porcentajesecontTerapia_intermedia2021 = miObjeto.secontTerapia_intermedia2021;
    var porcentajesecontAlta_hospitalaria2021 = miObjeto.secontAlta_hospitalaria2021;
    var porcentajesecontFallece2021 = miObjeto.secontFallece2021;


    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Servicios de egreso y tasa bruta de mortalidad 2021'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: '2021',
            colorByPoint: true,
            data: [{
                name: 'Sala común',
                y: porcentajesecontSalacomun2021,
                sliced: true,
                selected: true
            }, {
                name: 'Terapia Intermedia',
                y: porcentajesecontTerapia_intermedia2021
            }, {
                name: 'Alta hospitalaria',
                y: porcentajesecontAlta_hospitalaria2021
            }, {
                name: 'Fallece',
                y: porcentajesecontFallece2021
            }]
        }]
    });
}

$("#verGraficoServEgre2022").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoServEgre2022();
});
function graficoServEgre2022() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajesecontSalacomun2022 = miObjeto.secontSalacomun2022;
    var porcentajesecontTerapia_intermedia2022 = miObjeto.secontTerapia_intermedia2022;
    var porcentajesecontAlta_hospitalaria2022 = miObjeto.secontAlta_hospitalaria2022;
    var porcentajesecontFallece2022 = miObjeto.secontFallece2022;


    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Servicios de egreso y tasa bruta de mortalidad 2022'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: '2022',
            colorByPoint: true,
            data: [{
                name: 'Sala común',
                y: porcentajesecontSalacomun2022,
                sliced: true,
                selected: true
            }, {
                name: 'Terapia Intermedia',
                y: porcentajesecontTerapia_intermedia2022
            }, {
                name: 'Alta hospitalaria',
                y: porcentajesecontAlta_hospitalaria2022
            }, {
                name: 'Fallece',
                y: porcentajesecontFallece2022
            }]
        }]
    });
}

$("#verGraficoServEgre2023").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoServEgre2023();
});
function graficoServEgre2023() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajesecontSalacomun2023 = miObjeto.secontSalacomun2023;
    var porcentajesecontTerapia_intermedia2023 = miObjeto.secontTerapia_intermedia2023;
    var porcentajesecontAlta_hospitalaria2023 = miObjeto.secontAlta_hospitalaria2023;
    var porcentajesecontFallece2023 = miObjeto.secontFallece2023;


    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Servicios de egreso y tasa bruta de mortalidad 2023'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: '2023',
            colorByPoint: true,
            data: [{
                name: 'Sala común',
                y: porcentajesecontSalacomun2023,
                sliced: true,
                selected: true
            }, {
                name: 'Terapia Intermedia',
                y: porcentajesecontTerapia_intermedia2023
            }, {
                name: 'Alta hospitalaria',
                y: porcentajesecontAlta_hospitalaria2023
            }, {
                name: 'Fallece',
                y: porcentajesecontFallece2023
            }]
        }]
    });
}

$("#verGraficoServEgreGlobal").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoServEgreGlobal();
});
function graficoServEgreGlobal() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajesecontSalacomunGlobal = miObjeto.secontSalacomunGlobal;
    var porcentajesecontTerapia_intermediaGlobal = miObjeto.secontTerapia_intermediaGlobal;
    var porcentajesecontAlta_hospitalariaGlobal = miObjeto.secontAlta_hospitalariaGlobal;
    var porcentajesecontFalleceGlobal = miObjeto.secontFalleceGlobal;


    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Servicios de egreso y tasa bruta de mortalidad 2019-2023'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: 'Global',
            colorByPoint: true,
            data: [{
                name: 'Sala común',
                y: porcentajesecontSalacomunGlobal,
                sliced: true,
                selected: true
            }, {
                name: 'Terapia Intermedia',
                y: porcentajesecontTerapia_intermediaGlobal
            }, {
                name: 'Alta hospitalaria',
                y: porcentajesecontAlta_hospitalariaGlobal
            }, {
                name: 'Fallece',
                y: porcentajesecontFalleceGlobal
            }]
        }]
    });
}


//////////////// SERVICIOS DE EGRESO Y TASA BRUTA DE MORTALIDAD /////////////////////////////
$("#verGraficoCausaMortalidad2019").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoCausaMortalidad2019();
});
function graficoCausaMortalidad2019() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajecmNeurologico2019 = miObjeto.cmNeurologico2019;
    var porcentajecmRespiratorio2019 = miObjeto.cmRespiratorio2019;
    var porcentajecmCardiovascular2019 = miObjeto.cmCardiovascular2019;
    var porcentajecmGastrointestinal2019 = miObjeto.cmGastrointestinal2019;
    var porcentajecmRenalEndocrinologico2019 = miObjeto.cmRenalEndocrinologico2019;
    var porcentajecmFallaMultiorganica2019 = miObjeto.cmFallaMultiorganica2019;
    var porcentajecmOtros2019 = miObjeto.cmOtros2019;
    var porcentajecmNoFallecidos2019 = miObjeto.cmNoFallecidos2019;

    //alert(porcentajecmNeurologico2019);
    //alert(porcentajecmRespiratorio2019);
    //alert(porcentajecmCardiovascular2019);

    //alert(porcentajecmCardiovascular2019);

    //alert(porcentajecmGastrointestinal2019);

    //alert(porcentajecmRenalEndocrinologico2019);
    //alert(porcentajecmFallaMultiorganica2019);
    //alert(porcentajecmOtros2019);
    //alert(porcentajecmNoFallecidos2019);







    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Prevalencia de causa de mortalidad bruta 2019'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: '2019',
            colorByPoint: true,
            data: [{
                name: 'Neurológico',
                y: porcentajecmNeurologico2019,
                sliced: true,
                selected: true
            }, {
                name: 'Respiratorio',
                y: porcentajecmRespiratorio2019
            }, {
                name: 'Cardiovascular',
                y: porcentajecmCardiovascular2019
            }, {
                name: 'Gastrointestinal',
                y: porcentajecmGastrointestinal2019
            }, {
                name: 'Renal-Endocrinológico',
                y: porcentajecmRenalEndocrinologico2019
            }, {
                name: 'Falla Multiorgánica',
                y: porcentajecmFallaMultiorganica2019
            }, {
                name: 'Otros',
                y: porcentajecmOtros2019
            }, {
                name: 'No Fallecidos',
                y: porcentajecmNoFallecidos2019
            }]
        }]
    });
}
$("#verGraficoCausaMortalidad2020").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoCausaMortalidad2020();
});
function graficoCausaMortalidad2020() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajecmNeurologico2020 = miObjeto.cmNeurologico2020;
    var porcentajecmRespiratorio2020 = miObjeto.cmRespiratorio2020;
    var porcentajecmCardiovascular2020 = miObjeto.cmCardiovascular2020;
    var porcentajecmGastrointestinal2020 = miObjeto.cmGastrointestinal2020;
    var porcentajecmRenalEndocrinologico2020 = miObjeto.cmRenalEndocrinologico2020;
    var porcentajecmFallaMultiorganica2020 = miObjeto.cmFallaMultiorganica2020;
    var porcentajecmOtros2020 = miObjeto.cmOtros2020;
    var porcentajecmNoFallecidos2020 = miObjeto.cmNoFallecidos2020;




    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Prevalencia de causa de mortalidad bruta 2020'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: '2020',
            colorByPoint: true,
            data: [{
                name: 'Neurológico',
                y: porcentajecmNeurologico2020,
                sliced: true,
                selected: true
            }, {
                name: 'Respiratorio',
                y: porcentajecmRespiratorio2020
            }, {
                name: 'Cardiovascular',
                y: porcentajecmCardiovascular2020
            }, {
                name: 'Gastrointestinal',
                y: porcentajecmGastrointestinal2020
            }, {
                name: 'Renal-Endocrinológico',
                y: porcentajecmRenalEndocrinologico2020
            }, {
                name: 'Falla Multiorgánica',
                y: porcentajecmFallaMultiorganica2020
            }, {
                name: 'Otros',
                y: porcentajecmOtros2020
            }, {
                name: 'No Fallecidos',
                y: porcentajecmNoFallecidos2020
            }]
        }]
    });
}
$("#verGraficoCausaMortalidad2021").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoCausaMortalidad2021();
});
function graficoCausaMortalidad2021() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajecmNeurologico2021 = miObjeto.cmNeurologico2021;
    var porcentajecmRespiratorio2021 = miObjeto.cmRespiratorio2021;
    var porcentajecmCardiovascular2021 = miObjeto.cmCardiovascular2021;
    var porcentajecmGastrointestinal2021 = miObjeto.cmGastrointestinal2021;
    var porcentajecmRenalEndocrinologico2021 = miObjeto.cmRenalEndocrinologico2021;
    var porcentajecmFallaMultiorganica2021 = miObjeto.cmFallaMultiorganica2021;
    var porcentajecmOtros2021 = miObjeto.cmOtros2021;
    var porcentajecmNoFallecidos2021 = miObjeto.cmNoFallecidos2021;



    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Prevalencia de causa de mortalidad bruta 2021'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: '2021',
            colorByPoint: true,
            data: [{
                name: 'Neurológico',
                y: porcentajecmNeurologico2021,
                sliced: true,
                selected: true
            }, {
                name: 'Respiratorio',
                y: porcentajecmRespiratorio2021
            }, {
                name: 'Cardiovascular',
                y: porcentajecmCardiovascular2021
            }, {
                name: 'Gastrointestinal',
                y: porcentajecmGastrointestinal2021
            }, {
                name: 'Renal-Endocrinológico',
                y: porcentajecmRenalEndocrinologico2021
            }, {
                name: 'Falla Multiorgánica',
                y: porcentajecmFallaMultiorganica2021
            }, {
                name: 'Otros',
                y: porcentajecmOtros2021
             }, {
                name: 'No Fallecidos',
                y: porcentajecmNoFallecidos2021
            }]
        }]
    });
}
$("#verGraficoCausaMortalidad2022").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoCausaMortalidad2022();
});
function graficoCausaMortalidad2022() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajecmNeurologico2022 = miObjeto.cmNeurologico2022;
    var porcentajecmRespiratorio2022 = miObjeto.cmRespiratorio2022;
    var porcentajecmCardiovascular2022 = miObjeto.cmCardiovascular2022;
    var porcentajecmGastrointestinal2022 = miObjeto.cmGastrointestinal2022;
    var porcentajecmRenalEndocrinologico2022 = miObjeto.cmRenalEndocrinologico2022;
    var porcentajecmFallaMultiorganica2022 = miObjeto.cmFallaMultiorganica2022;
    var porcentajecmOtros2022 = miObjeto.cmOtros2022;
    var porcentajecmNoFallecidos2022 = miObjeto.cmNoFallecidos2022;



    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Prevalencia de causa de mortalidad bruta 2022'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: '2022',
            colorByPoint: true,
            data: [{
                name: 'Neurológico',
                y: porcentajecmNeurologico2022,
                sliced: true,
                selected: true
            }, {
                name: 'Respiratorio',
                y: porcentajecmRespiratorio2022
            }, {
                name: 'Cardiovascular',
                y: porcentajecmCardiovascular2022
            }, {
                name: 'Gastrointestinal',
                y: porcentajecmGastrointestinal2022
            }, {
                name: 'Renal-Endocrinológico',
                y: porcentajecmRenalEndocrinologico2022
            }, {
                name: 'Falla Multiorgánica',
                y: porcentajecmFallaMultiorganica2022
            }, {
                name: 'Otros',
                y: porcentajecmOtros2022
            }, {
                name: 'No Fallecidos',
                y: porcentajecmNoFallecidos2022
            }]
        }]
    });
}
$("#verGraficoCausaMortalidad2023").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoCausaMortalidad2023();
});
function graficoCausaMortalidad2023() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajecmNeurologico2023 = miObjeto.cmNeurologico2023;
    var porcentajecmRespiratorio2023 = miObjeto.cmRespiratorio2023;
    var porcentajecmCardiovascular2023 = miObjeto.cmCardiovascular2023;
    var porcentajecmGastrointestinal2023 = miObjeto.cmGastrointestinal2023;
    var porcentajecmRenalEndocrinologico2023 = miObjeto.cmRenalEndocrinologico2023;
    var porcentajecmFallaMultiorganica2023 = miObjeto.cmFallaMultiorganica2023;
    var porcentajecmOtros2023 = miObjeto.cmOtros2023;
    var porcentajecmNoFallecidos2023 = miObjeto.cmNoFallecidos2023;



    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Prevalencia de causa de mortalidad bruta 2023'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: '2023',
            colorByPoint: true,
            data: [{
                name: 'Neurológico',
                y: porcentajecmNeurologico2023,
                sliced: true,
                selected: true
            }, {
                name: 'Respiratorio',
                y: porcentajecmRespiratorio2023
            }, {
                name: 'Cardiovascular',
                y: porcentajecmCardiovascular2023
            }, {
                name: 'Gastrointestinal',
                y: porcentajecmGastrointestinal2023
            }, {
                name: 'Renal-Endocrinológico',
                y: porcentajecmRenalEndocrinologico2023
            }, {
                name: 'Falla Multiorgánica',
                y: porcentajecmFallaMultiorganica2023
            }, {
                name: 'Otros',
                y: porcentajecmOtros2023
            }, {
                name: 'No Fallecidos',
                y: porcentajecmNoFallecidos2023
            }]
        }]
    });
}
$("#verGraficoCausaMortalidadGlobal").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoCausaMortalidadGlobal();
});
function graficoCausaMortalidadGlobal() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajecmNeurologicoGlobal = miObjeto.cmNeurologicoGlobal;
    var porcentajecmRespiratorioGlobal = miObjeto.cmRespiratorioGlobal;
    var porcentajecmCardiovascularGlobal = miObjeto.cmCardiovascularGlobal;
    var porcentajecmGastrointestinalGlobal = miObjeto.cmGastrointestinalGlobal;
    var porcentajecmRenalEndocrinologicoGlobal = miObjeto.cmRenalEndocrinologicoGlobal;
    var porcentajecmFallaMultiorganicaGlobal = miObjeto.cmFallaMultiorganicaGlobal;
    var porcentajecmOtrosGlobal = miObjeto.cmOtrosGlobal;
    var porcentajecmNoFallecidosGlobal = miObjeto.cmNoFallecidosGlobal;


    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Prevalencia de causa de mortalidad bruta Global'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: 'Global',
            colorByPoint: true,
            data: [{
                name: 'Neurológico',
                y: porcentajecmNeurologicoGlobal,
                sliced: true,
                selected: true
            }, {
                name: 'Respiratorio',
                y: porcentajecmRespiratorioGlobal
            }, {
                name: 'Cardiovascular',
                y: porcentajecmCardiovascularGlobal
            }, {
                name: 'Gastrointestinal',
                y: porcentajecmGastrointestinalGlobal
            }, {
                name: 'Renal-Endocrinológico',
                y: porcentajecmRenalEndocrinologicoGlobal
            }, {
                name: 'Falla Multiorgánica',
                y: porcentajecmFallaMultiorganicaGlobal
            }, {
                name: 'Otros',
                y: porcentajecmOtrosGlobal
            }, {
                name: 'No Fallecidos',
                y: porcentajecmNoFallecidosGlobal
            }]
        }]
    });
}

//////////////// PREVALENCIA DE PATOLOGIAS DE CAUSA DE INGRESO /////////////////////////////
$("#verGraficoCausaIngreso2019").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoCausaIngreso2019();
});
function graficoCausaIngreso2019() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajeciNeurologico2019 = miObjeto.cicontNeurologico2019;
    var porcentajeciRespiratorio2019 = miObjeto.cicontRespiratorio2019;
    var porcentajeciCardiovascular2019 = miObjeto.cicontCardiovascular2019;
    var porcentajeciGastrointestinal2019 = miObjeto.cicontGastrointestinal2019;
    var porcentajeciRenalEndocrinologico2019 = miObjeto.cicontRenalEndocrinologico2019;
    var porcentajecicontOtros2019 = miObjeto.cicontOtros2019;

    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Prevalencia de patologías de causa de ingreso 2019'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: '2019',
            colorByPoint: true,
            data: [{
                name: 'Neurológico',
                y: porcentajeciNeurologico2019,
                sliced: true,
                selected: true
            }, {
                name: 'Respiratorio',
                y: porcentajeciRespiratorio2019
            }, {
                name: 'Cardiovascular',
                y: porcentajeciCardiovascular2019
            }, {
                name: 'Gastrointestinal',
                y: porcentajeciGastrointestinal2019
            }, {
                name: 'Renal-Endocrinológico',
                y: porcentajeciRenalEndocrinologico2019
            }, {
                name: 'Otros',
                y: porcentajecicontOtros2019
            }]
        }]
    });
}
$("#verGraficoCausaIngreso2020").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoCausaIngreso2020();
});
function graficoCausaIngreso2020() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajeciNeurologico2020 = miObjeto.cicontNeurologico2020;
    var porcentajeciRespiratorio2020 = miObjeto.cicontRespiratorio2020;
    var porcentajeciCardiovascular2020 = miObjeto.cicontCardiovascular2020;
    var porcentajeciGastrointestinal2020 = miObjeto.cicontGastrointestinal2020;
    var porcentajeciRenalEndocrinologico2020 = miObjeto.cicontRenalEndocrinologico2020;
    var porcentajecicontOtros2020 = miObjeto.cicontOtros2020;

    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Prevalencia de patologías de causa de ingreso 2020'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: '2020',
            colorByPoint: true,
            data: [{
                name: 'Neurológico',
                y: porcentajeciNeurologico2020,
                sliced: true,
                selected: true
            }, {
                name: 'Respiratorio',
                y: porcentajeciRespiratorio2020
            }, {
                name: 'Cardiovascular',
                y: porcentajeciCardiovascular2020
            }, {
                name: 'Gastrointestinal',
                y: porcentajeciGastrointestinal2020
            }, {
                name: 'Renal-Endocrinológico',
                y: porcentajeciRenalEndocrinologico2020
            }, {
                name: 'Otros',
                y: porcentajecicontOtros2020
            }]
        }]
    });
}
$("#verGraficoCausaIngreso2021").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoCausaIngreso2021();
});
function graficoCausaIngreso2021() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajeciNeurologico2021 = miObjeto.cicontNeurologico2021;
    var porcentajeciRespiratorio2021 = miObjeto.cicontRespiratorio2021;
    var porcentajeciCardiovascular2021 = miObjeto.cicontCardiovascular2021;
    var porcentajeciGastrointestinal2021 = miObjeto.cicontGastrointestinal2021;
    var porcentajeciRenalEndocrinologico2021 = miObjeto.cicontRenalEndocrinologico2021;
    var porcentajecicontOtros2021 = miObjeto.cicontOtros2021;

    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Prevalencia de patologías de causa de ingreso 2021'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: '2021',
            colorByPoint: true,
            data: [{
                name: 'Neurológico',
                y: porcentajeciNeurologico2021,
                sliced: true,
                selected: true
            }, {
                name: 'Respiratorio',
                y: porcentajeciRespiratorio2021
            }, {
                name: 'Cardiovascular',
                y: porcentajeciCardiovascular2021
            }, {
                name: 'Gastrointestinal',
                y: porcentajeciGastrointestinal2021
            }, {
                name: 'Renal-Endocrinológico',
                y: porcentajeciRenalEndocrinologico2021
            }, {
                name: 'Otros',
                y: porcentajecicontOtros2021
            }]
        }]
    });
}
$("#verGraficoCausaIngreso2022").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoCausaIngreso2022();
});
function graficoCausaIngreso2022() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajeciNeurologico2022 = miObjeto.cicontNeurologico2022;
    var porcentajeciRespiratorio2022 = miObjeto.cicontRespiratorio2022;
    var porcentajeciCardiovascular2022 = miObjeto.cicontCardiovascular2022;
    var porcentajeciGastrointestinal2022 = miObjeto.cicontGastrointestinal2022;
    var porcentajeciRenalEndocrinologico2022 = miObjeto.cicontRenalEndocrinologico2022;
    var porcentajecicontOtros2022 = miObjeto.cicontOtros2022;

    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Prevalencia de patologías de causa de ingreso 2022'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: '2022',
            colorByPoint: true,
            data: [{
                name: 'Neurológico',
                y: porcentajeciNeurologico2022,
                sliced: true,
                selected: true
            }, {
                name: 'Respiratorio',
                y: porcentajeciRespiratorio2022
            }, {
                name: 'Cardiovascular',
                y: porcentajeciCardiovascular2022
            }, {
                name: 'Gastrointestinal',
                y: porcentajeciGastrointestinal2022
            }, {
                name: 'Renal-Endocrinológico',
                y: porcentajeciRenalEndocrinologico2022
            }, {
                name: 'Otros',
                y: porcentajecicontOtros2022
            }]
        }]
    });
}
$("#verGraficoCausaIngreso2023").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoCausaIngreso2023();
});
function graficoCausaIngreso2023() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajeciNeurologico2023 = miObjeto.cicontNeurologico2023;
    var porcentajeciRespiratorio2023 = miObjeto.cicontRespiratorio2023;
    var porcentajeciCardiovascular2023 = miObjeto.cicontCardiovascular2023;
    var porcentajeciGastrointestinal2023 = miObjeto.cicontGastrointestinal2023;
    var porcentajeciRenalEndocrinologico2023 = miObjeto.cicontRenalEndocrinologico2023;
    var porcentajecicontOtros2023 = miObjeto.cicontOtros2023;

    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Prevalencia de patologías de causa de ingreso 2023'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: '2023',
            colorByPoint: true,
            data: [{
                name: 'Neurológico',
                y: porcentajeciNeurologico2023,
                sliced: true,
                selected: true
            }, {
                name: 'Respiratorio',
                y: porcentajeciRespiratorio2023
            }, {
                name: 'Cardiovascular',
                y: porcentajeciCardiovascular2023
            }, {
                name: 'Gastrointestinal',
                y: porcentajeciGastrointestinal2023
            }, {
                name: 'Renal-Endocrinológico',
                y: porcentajeciRenalEndocrinologico2023
            }, {
                name: 'Otros',
                y: porcentajecicontOtros2023
            }]
        }]
    });
}
$("#verGraficoCausaIngresoGlobal").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoCausaIngresoGlobal();
});
function graficoCausaIngresoGlobal() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajeciNeurologicoGlobal = miObjeto.cicontNeurologicoTotal;
    var porcentajeciRespiratorioGlobal = miObjeto.cicontRespiratorioTotal;
    var porcentajeciCardiovascularGlobal = miObjeto.cicontCardiovascularTotal;
    var porcentajeciGastrointestinalGlobal = miObjeto.cicontGastrointestinalTotal;
    var porcentajeciRenalEndocrinologicoGlobal = miObjeto.cicontRenalEndocrinologicoTotal;
    var porcentajecicontOtrosGlobal = miObjeto.cicontOtrosTotal;
    //alert(porcentajeciNeurologicoGlobal);
    //alert(porcentajeciRespiratorioGlobal);
    //alert(porcentajeciCardiovascularGlobal);
    //alert(porcentajeciGastrointestinalGlobal);
    //alert(porcentajeciRenalEndocrinologicoGlobal);
    //alert(porcentajecicontOtrosGlobal);
    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Prevalencia de patologías de causa de ingreso 2019-2023'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: 'Global',
            colorByPoint: true,
            data: [{
                name: 'Neurológico',
                y: porcentajeciNeurologicoGlobal,
                sliced: true,
                selected: true
            }, {
                name: 'Respiratorio',
                y: porcentajeciRespiratorioGlobal
            }, {
                name: 'Cardiovascular',
                y: porcentajeciCardiovascularGlobal
            }, {
                name: 'Gastrointestinal',
                y: porcentajeciGastrointestinalGlobal
            }, {
                name: 'Renal-Endocrinológico',
                y: porcentajeciRenalEndocrinologicoGlobal
            }, {
                name: 'Otros',
                y: porcentajecicontOtrosGlobal
            }]
        }]
    });
}

//////////////// SUBCATEGORIAS DE CAUSA DE INGRESO /////////////////////////////
//Neurológico
$("#verGraficoSubNeuroCausaIngreso2019").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoSubNeuroCausaIngreso2019();
});
function graficoSubNeuroCausaIngreso2019() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajesubNcicontTEC2019 = miObjeto.subNcicontTEC2019;
    var porcentajesubNcicontAVC2019 = miObjeto.subNcicontAVC2019;
    var porcentajesubNcicontEpilepsia2019 = miObjeto.subNcicontEpilepsia2019;
    var porcentajesubNcicontMeningitis2019 = miObjeto.subNcicontMeningitis2019;
    var porcentajesubNcicontOtros2019 = miObjeto.subNcicontOtros2019;


    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Subcategorías de causa de ingreso Neurológico 2019'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: '2019',
            colorByPoint: true,
            data: [{
                name: 'TEC',
                y: porcentajesubNcicontTEC2019,
                sliced: true,
                selected: true
            }, {
                name: 'AVC',
                y: porcentajesubNcicontAVC2019
            }, {
                name: 'Epilepsia',
                y: porcentajesubNcicontEpilepsia2019
            }, {
                name: 'Meningitis',
                y: porcentajesubNcicontMeningitis2019           
            }, {
                name: 'Otros',
                y: porcentajesubNcicontOtros2019
            }]
        }]
    });
}
$("#verGraficoSubNeuroCausaIngreso2020").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoSubNeuroCausaIngreso2020();
});
function graficoSubNeuroCausaIngreso2020() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajesubNcicontTEC2020 = miObjeto.subNcicontTEC2020;
    var porcentajesubNcicontAVC2020 = miObjeto.subNcicontAVC2020;
    var porcentajesubNcicontEpilepsia2020 = miObjeto.subNcicontEpilepsia2020;
    var porcentajesubNcicontMeningitis2020 = miObjeto.subNcicontMeningitis2020;
    var porcentajesubNcicontOtros2020 = miObjeto.subNcicontOtros2020;


    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Subcategorías de causa de ingreso Neurológico 2020'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: '2020',
            colorByPoint: true,
            data: [{
                name: 'TEC',
                y: porcentajesubNcicontTEC2020,
                sliced: true,
                selected: true
            }, {
                name: 'AVC',
                y: porcentajesubNcicontAVC2020
            }, {
                name: 'Epilepsia',
                y: porcentajesubNcicontEpilepsia2020
            }, {
                name: 'Meningitis',
                y: porcentajesubNcicontMeningitis2020
            }, {
                name: 'Otros',
                y: porcentajesubNcicontOtros2020
            }]
        }]
    });
}
$("#verGraficoSubNeuroCausaIngreso2021").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoSubNeuroCausaIngreso2021();
});
function graficoSubNeuroCausaIngreso2021() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajesubNcicontTEC2021 = miObjeto.subNcicontTEC2021;
    var porcentajesubNcicontAVC2021 = miObjeto.subNcicontAVC2021;
    var porcentajesubNcicontEpilepsia2021 = miObjeto.subNcicontEpilepsia2021;
    var porcentajesubNcicontMeningitis2021 = miObjeto.subNcicontMeningitis2021;
    var porcentajesubNcicontOtros2021 = miObjeto.subNcicontOtros2021;


    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Subcategorías de causa de ingreso Neurológico 2021'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: '2021',
            colorByPoint: true,
            data: [{
                name: 'TEC',
                y: porcentajesubNcicontTEC2021,
                sliced: true,
                selected: true
            }, {
                name: 'AVC',
                y: porcentajesubNcicontAVC2021
            }, {
                name: 'Epilepsia',
                y: porcentajesubNcicontEpilepsia2021
            }, {
                name: 'Meningitis',
                y: porcentajesubNcicontMeningitis2021
            }, {
                name: 'Otros',
                y: porcentajesubNcicontOtros2021
            }]
        }]
    });
}
$("#verGraficoSubNeuroCausaIngreso2022").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoSubNeuroCausaIngreso2022();
});
function graficoSubNeuroCausaIngreso2022() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajesubNcicontTEC2022 = miObjeto.subNcicontTEC2022;
    var porcentajesubNcicontAVC2022 = miObjeto.subNcicontAVC2022;
    var porcentajesubNcicontEpilepsia2022 = miObjeto.subNcicontEpilepsia2022;
    var porcentajesubNcicontMeningitis2022 = miObjeto.subNcicontMeningitis2022;
    var porcentajesubNcicontOtros2022 = miObjeto.subNcicontOtros2022;


    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Subcategorías de causa de ingreso Neurológico 2022'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: '2022',
            colorByPoint: true,
            data: [{
                name: 'TEC',
                y: porcentajesubNcicontTEC2022,
                sliced: true,
                selected: true
            }, {
                name: 'AVC',
                y: porcentajesubNcicontAVC2022
            }, {
                name: 'Epilepsia',
                y: porcentajesubNcicontEpilepsia2022
            }, {
                name: 'Meningitis',
                y: porcentajesubNcicontMeningitis2022
            }, {
                name: 'Otros',
                y: porcentajesubNcicontOtros2022
            }]
        }]
    });
}
$("#verGraficoSubNeuroCausaIngreso2023").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoSubNeuroCausaIngreso2023();
});
function graficoSubNeuroCausaIngreso2023() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajesubNcicontTEC2023 = miObjeto.subNcicontTEC2023;
    var porcentajesubNcicontAVC2023 = miObjeto.subNcicontAVC2023;
    var porcentajesubNcicontEpilepsia2023 = miObjeto.subNcicontEpilepsia2023;
    var porcentajesubNcicontMeningitis2023 = miObjeto.subNcicontMeningitis2023;
    var porcentajesubNcicontOtros2023 = miObjeto.subNcicontOtros2023;


    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Subcategorías de causa de ingreso Neurológico 2023'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: '2023',
            colorByPoint: true,
            data: [{
                name: 'TEC',
                y: porcentajesubNcicontTEC2023,
                sliced: true,
                selected: true
            }, {
                name: 'AVC',
                y: porcentajesubNcicontAVC2023
            }, {
                name: 'Epilepsia',
                y: porcentajesubNcicontEpilepsia2023
            }, {
                name: 'Meningitis',
                y: porcentajesubNcicontMeningitis2023
            }, {
                name: 'Otros',
                y: porcentajesubNcicontOtros2023
            }]
        }]
    });
}
$("#verGraficoSubNeuroCausaIngresoGlobal").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoSubNeuroCausaIngresoGlobal();
});
function graficoSubNeuroCausaIngresoGlobal() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajesubNcicontTECGlobal = miObjeto.subNcicontTECTotal;
    var porcentajesubNcicontAVCGlobal = miObjeto.subNcicontAVCTotal;
    var porcentajesubNcicontEpilepsiaGlobal = miObjeto.subNcicontEpilepsiaTotal;
    var porcentajesubNcicontMeningitisGlobal = miObjeto.subNcicontMeningitisTotal;
    var porcentajesubNcicontOtrosGlobal = miObjeto.subNcicontOtrosTotal;


    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Subcategorías de causa de ingreso Neurológico 2019 - 2023'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: 'Global',
            colorByPoint: true,
            data: [{
                name: 'TEC',
                y: porcentajesubNcicontTECGlobal,
                sliced: true,
                selected: true
            }, {
                name: 'AVC',
                y: porcentajesubNcicontAVCGlobal
            }, {
                name: 'Epilepsia',
                y: porcentajesubNcicontEpilepsiaGlobal
            }, {
                name: 'Meningitis',
                y: porcentajesubNcicontMeningitisGlobal
            }, {
                name: 'Otros',
                y: porcentajesubNcicontOtrosGlobal
            }]
        }]
    });
}
//Respiratorio 
$("#verGraficoSubRespCausaIngreso2019").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoSubRespCausaIngreso2019();
});
function graficoSubRespCausaIngreso2019() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajesubResciChoqueSeptico_Neumonia2019 = miObjeto.subResciChoqueSeptico_Neumonia2019;
    var porcentajesubResciTEP2019 = miObjeto.subResciTEP2019;
    var porcentajesubResciEAP2019 = miObjeto.subResciEAP2019;
    var porcentajesubResciAsma_EPOC2019 = miObjeto.subResciAsma_EPOC2019;
    var porcentajesubResciOtros2019 = miObjeto.subResciOtros2019;


    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Subcategorías de causa de ingreso Respiratorio 2019'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: '2019',
            colorByPoint: true,
            data: [{
                name: 'Choque Séptico - Neumonía',
                y: porcentajesubResciChoqueSeptico_Neumonia2019,
                sliced: true,
                selected: true
            }, {
                name: 'TEP',
                y: porcentajesubResciTEP2019
            }, {
                name: 'EAP',
                y: porcentajesubResciEAP2019
            }, {
                name: 'Asma - EPOC',
                y: porcentajesubResciAsma_EPOC2019
            }, {
                name: 'Otros',
                y: porcentajesubResciOtros2019
            }]
        }]
    });
}
$("#verGraficoSubRespCausaIngreso2020").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoSubRespCausaIngreso2020();
});
function graficoSubRespCausaIngreso2020() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajesubResciChoqueSeptico_Neumonia2020 = miObjeto.subResciChoqueSeptico_Neumonia2020;
    var porcentajesubResciTEP2020 = miObjeto.subResciTEP2020;
    var porcentajesubResciEAP2020 = miObjeto.subResciEAP2020;
    var porcentajesubResciAsma_EPOC2020 = miObjeto.subResciAsma_EPOC2020;
    var porcentajesubResciOtros2020 = miObjeto.subResciOtros2020;


    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Subcategorías de causa de ingreso Respiratorio 2020'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: '2020',
            colorByPoint: true,
            data: [{
                name: 'Choque Séptico - Neumonía',
                y: porcentajesubResciChoqueSeptico_Neumonia2020,
                sliced: true,
                selected: true
            }, {
                name: 'TEP',
                y: porcentajesubResciTEP2020
            }, {
                name: 'EAP',
                y: porcentajesubResciEAP2020
            }, {
                name: 'Asma - EPOC',
                y: porcentajesubResciAsma_EPOC2020
            }, {
                name: 'Otros',
                y: porcentajesubResciOtros2020
            }]
        }]
    });
}
$("#verGraficoSubRespCausaIngreso2021").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoSubRespCausaIngreso2021();
});
function graficoSubRespCausaIngreso2021() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajesubResciChoqueSeptico_Neumonia2021 = miObjeto.subResciChoqueSeptico_Neumonia2021;
    var porcentajesubResciTEP2021 = miObjeto.subResciTEP2021;
    var porcentajesubResciEAP2021 = miObjeto.subResciEAP2021;
    var porcentajesubResciAsma_EPOC2021 = miObjeto.subResciAsma_EPOC2021;
    var porcentajesubResciOtros2021 = miObjeto.subResciOtros2021;


    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Subcategorías de causa de ingreso Respiratorio 2021'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: '2021',
            colorByPoint: true,
            data: [{
                name: 'Choque Séptico - Neumonía',
                y: porcentajesubResciChoqueSeptico_Neumonia2021,
                sliced: true,
                selected: true
            }, {
                name: 'TEP',
                y: porcentajesubResciTEP2021
            }, {
                name: 'EAP',
                y: porcentajesubResciEAP2021
            }, {
                name: 'Asma - EPOC',
                y: porcentajesubResciAsma_EPOC2021
            }, {
                name: 'Otros',
                y: porcentajesubResciOtros2021
            }]
        }]
    });
}
$("#verGraficoSubRespCausaIngreso2022").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoSubRespCausaIngreso2022();
});
function graficoSubRespCausaIngreso2022() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajesubResciChoqueSeptico_Neumonia2022 = miObjeto.subResciChoqueSeptico_Neumonia2022;
    var porcentajesubResciTEP2022 = miObjeto.subResciTEP2022;
    var porcentajesubResciEAP2022 = miObjeto.subResciEAP2022;
    var porcentajesubResciAsma_EPOC2022 = miObjeto.subResciAsma_EPOC2022;
    var porcentajesubResciOtros2022 = miObjeto.subResciOtros2022;


    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Subcategorías de causa de ingreso Respiratorio 2022'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: '2022',
            colorByPoint: true,
            data: [{
                name: 'Choque Séptico - Neumonía',
                y: porcentajesubResciChoqueSeptico_Neumonia2022,
                sliced: true,
                selected: true
            }, {
                name: 'TEP',
                y: porcentajesubResciTEP2022
            }, {
                name: 'EAP',
                y: porcentajesubResciEAP2022
            }, {
                name: 'Asma - EPOC',
                y: porcentajesubResciAsma_EPOC2022
            }, {
                name: 'Otros',
                y: porcentajesubResciOtros2022
            }]
        }]
    });
}
$("#verGraficoSubRespCausaIngreso2023").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoSubRespCausaIngreso2023();
});
function graficoSubRespCausaIngreso2023() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajesubResciChoqueSeptico_Neumonia2023 = miObjeto.subResciChoqueSeptico_Neumonia2023;
    var porcentajesubResciTEP2023 = miObjeto.subResciTEP2023;
    var porcentajesubResciEAP2023 = miObjeto.subResciEAP2023;
    var porcentajesubResciAsma_EPOC2023 = miObjeto.subResciAsma_EPOC2023;
    var porcentajesubResciOtros2023 = miObjeto.subResciOtros2023;


    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Subcategorías de causa de ingreso Respiratorio 2023'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: '2023',
            colorByPoint: true,
            data: [{
                name: 'Choque Séptico - Neumonía',
                y: porcentajesubResciChoqueSeptico_Neumonia2023,
                sliced: true,
                selected: true
            }, {
                name: 'TEP',
                y: porcentajesubResciTEP2023
            }, {
                name: 'EAP',
                y: porcentajesubResciEAP2023
            }, {
                name: 'Asma - EPOC',
                y: porcentajesubResciAsma_EPOC2023
            }, {
                name: 'Otros',
                y: porcentajesubResciOtros2023
            }]
        }]
    });
}
$("#verGraficoSubRespCausaIngresoGlobal").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoSubRespCausaIngresoGlobal();
});
function graficoSubRespCausaIngresoGlobal() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajesubResciChoqueSeptico_NeumoniaGlobal = miObjeto.subResciChoqueSeptico_NeumoniaTotal;
    var porcentajesubResciTEPGlobal = miObjeto.subResciTEPTotal;
    var porcentajesubResciEAPGlobal = miObjeto.subResciEAPTotal;
    var porcentajesubResciAsma_EPOCGlobal = miObjeto.subResciAsma_EPOCTotal;
    var porcentajesubResciOtrosGlobal = miObjeto.subResciOtrosTotal;


    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Subcategorías de causa de ingreso Respiratorio Global'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: 'Global',
            colorByPoint: true,
            data: [{
                name: 'Choque Séptico - Neumonía',
                y: porcentajesubResciChoqueSeptico_NeumoniaGlobal,
                sliced: true,
                selected: true
            }, {
                name: 'TEP',
                y: porcentajesubResciTEPGlobal
            }, {
                name: 'EAP',
                y: porcentajesubResciEAPGlobal
            }, {
                name: 'Asma - EPOC',
                y: porcentajesubResciAsma_EPOCGlobal
            }, {
                name: 'Otros',
                y: porcentajesubResciOtrosGlobal
            }]
        }]
    });
}
//Cardiovascular
$("#verGraficoSubCardioCausaIngreso2019").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoSubCardioCausaIngreso2019();
});
function graficoSubCardioCausaIngreso2019() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajesubCarciChoqueCardiogenico2019 = miObjeto.subCarciChoqueCardiogenico2019;
    var porcentajesubCarciPostOperadoCirugiaCardiaca2019 = miObjeto.subCarciPostOperadoCirugiaCardiaca2019;
    var porcentajesubCarciTaquiarritmiaBradiarritmia2019 = miObjeto.subCarciTaquiarritmiaBradiarritmia2019;
    var porcentajesubCarciCrisisHipertensivas2019 = miObjeto.subCarciCrisisHipertensivas2019;
    var porcentajesubCarciPostParo2019 = miObjeto.subCarciPostParo2019;
    var porcentajesubCarciOtros2019 = miObjeto.subCarciOtros2019;


    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Subcategorías de causa de ingreso Cardiovascular 2019'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: '2019',
            colorByPoint: true,
            data: [{
                name: 'Choque cardiogénico',
                y: porcentajesubCarciChoqueCardiogenico2019,
                sliced: true,
                selected: true
            }, {
                name: 'Post operado cirugía cardiaca',
                y: porcentajesubCarciPostOperadoCirugiaCardiaca2019
            }, {
                name: 'Taquiarritmia - bradiarritmia',
                y: porcentajesubCarciTaquiarritmiaBradiarritmia2019
            }, {
                name: 'Crisis hipertensivas',
                y: porcentajesubCarciCrisisHipertensivas2019
            }, {
                name: 'Post paro',
                y: porcentajesubCarciPostParo2019
            }, {
                name: 'Otros',
                y: porcentajesubCarciOtros2019
            }]
        }]
    });
}
$("#verGraficoSubCardioCausaIngreso2020").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoSubCardioCausaIngreso2020();
});
function graficoSubCardioCausaIngreso2020() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajesubCarciChoqueCardiogenico2020 = miObjeto.subCarciChoqueCardiogenico2020;
    var porcentajesubCarciPostOperadoCirugiaCardiaca2020 = miObjeto.subCarciPostOperadoCirugiaCardiaca2020;
    var porcentajesubCarciTaquiarritmiaBradiarritmia2020 = miObjeto.subCarciTaquiarritmiaBradiarritmia2020;
    var porcentajesubCarciCrisisHipertensivas2020 = miObjeto.subCarciCrisisHipertensivas2020;
    var porcentajesubCarciPostParo2020 = miObjeto.subCarciPostParo2020;
    var porcentajesubCarciOtros2020 = miObjeto.subCarciOtros2020;


    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Subcategorías de causa de ingreso Cardiovascular 2020'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: '2020',
            colorByPoint: true,
            data: [{
                name: 'Choque cardiogénico',
                y: porcentajesubCarciChoqueCardiogenico2020,
                sliced: true,
                selected: true
            }, {
                name: 'Post operado cirugía cardiaca',
                y: porcentajesubCarciPostOperadoCirugiaCardiaca2020
            }, {
                name: 'Taquiarritmia - bradiarritmia',
                y: porcentajesubCarciTaquiarritmiaBradiarritmia2020
            }, {
                name: 'Crisis hipertensivas',
                y: porcentajesubCarciCrisisHipertensivas2020
            }, {
                name: 'Post paro',
                y: porcentajesubCarciPostParo2020
            }, {
                name: 'Otros',
                y: porcentajesubCarciOtros2020
            }]
        }]
    });
}
$("#verGraficoSubCardioCausaIngreso2021").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoSubCardioCausaIngreso2021();
});
function graficoSubCardioCausaIngreso2021() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajesubCarciChoqueCardiogenico2021 = miObjeto.subCarciChoqueCardiogenico2021;
    var porcentajesubCarciPostOperadoCirugiaCardiaca2021 = miObjeto.subCarciPostOperadoCirugiaCardiaca2021;
    var porcentajesubCarciTaquiarritmiaBradiarritmia2021 = miObjeto.subCarciTaquiarritmiaBradiarritmia2021;
    var porcentajesubCarciCrisisHipertensivas2021 = miObjeto.subCarciCrisisHipertensivas2021;
    var porcentajesubCarciPostParo2021 = miObjeto.subCarciPostParo2021;
    var porcentajesubCarciOtros2021 = miObjeto.subCarciOtros2021;


    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Subcategorías de causa de ingreso Cardiovascular 2021'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: '2021',
            colorByPoint: true,
            data: [{
                name: 'Choque cardiogénico',
                y: porcentajesubCarciChoqueCardiogenico2021,
                sliced: true,
                selected: true
            }, {
                name: 'Post operado cirugía cardiaca',
                y: porcentajesubCarciPostOperadoCirugiaCardiaca2021
            }, {
                name: 'Taquiarritmia - bradiarritmia',
                y: porcentajesubCarciTaquiarritmiaBradiarritmia2021
            }, {
                name: 'Crisis hipertensivas',
                y: porcentajesubCarciCrisisHipertensivas2021
            }, {
                name: 'Post paro',
                y: porcentajesubCarciPostParo2021
            }, {
                name: 'Otros',
                y: porcentajesubCarciOtros2021
            }]
        }]
    });
}
$("#verGraficoSubCardioCausaIngreso2022").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoSubCardioCausaIngreso2022();
});
function graficoSubCardioCausaIngreso2022() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajesubCarciChoqueCardiogenico2022 = miObjeto.subCarciChoqueCardiogenico2022;
    var porcentajesubCarciPostOperadoCirugiaCardiaca2022 = miObjeto.subCarciPostOperadoCirugiaCardiaca2022;
    var porcentajesubCarciTaquiarritmiaBradiarritmia2022 = miObjeto.subCarciTaquiarritmiaBradiarritmia2022;
    var porcentajesubCarciCrisisHipertensivas2022 = miObjeto.subCarciCrisisHipertensivas2022;
    var porcentajesubCarciPostParo2022 = miObjeto.subCarciPostParo2022;
    var porcentajesubCarciOtros2022 = miObjeto.subCarciOtros2022;


    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Subcategorías de causa de ingreso Cardiovascular 2022'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: '2022',
            colorByPoint: true,
            data: [{
                name: 'Choque cardiogénico',
                y: porcentajesubCarciChoqueCardiogenico2022,
                sliced: true,
                selected: true
            }, {
                name: 'Post operado cirugía cardiaca',
                y: porcentajesubCarciPostOperadoCirugiaCardiaca2022
            }, {
                name: 'Taquiarritmia - bradiarritmia',
                y: porcentajesubCarciTaquiarritmiaBradiarritmia2022
            }, {
                name: 'Crisis hipertensivas',
                y: porcentajesubCarciCrisisHipertensivas2022
            }, {
                name: 'Post paro',
                y: porcentajesubCarciPostParo2022
            }, {
                name: 'Otros',
                y: porcentajesubCarciOtros2022
            }]
        }]
    });
}
$("#verGraficoSubCardioCausaIngreso2023").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoSubCardioCausaIngreso2023();
});
function graficoSubCardioCausaIngreso2023() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajesubCarciChoqueCardiogenico2023 = miObjeto.subCarciChoqueCardiogenico2023;
    var porcentajesubCarciPostOperadoCirugiaCardiaca2023 = miObjeto.subCarciPostOperadoCirugiaCardiaca2023;
    var porcentajesubCarciTaquiarritmiaBradiarritmia2023 = miObjeto.subCarciTaquiarritmiaBradiarritmia2023;
    var porcentajesubCarciCrisisHipertensivas2023 = miObjeto.subCarciCrisisHipertensivas2023;
    var porcentajesubCarciPostParo2023 = miObjeto.subCarciPostParo2023;
    var porcentajesubCarciOtros2023 = miObjeto.subCarciOtros2023;


    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Subcategorías de causa de ingreso Cardiovascular 2023'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: '2023',
            colorByPoint: true,
            data: [{
                name: 'Choque cardiogénico',
                y: porcentajesubCarciChoqueCardiogenico2023,
                sliced: true,
                selected: true
            }, {
                name: 'Post operado cirugía cardiaca',
                y: porcentajesubCarciPostOperadoCirugiaCardiaca2023
            }, {
                name: 'Taquiarritmia - bradiarritmia',
                y: porcentajesubCarciTaquiarritmiaBradiarritmia2023
            }, {
                name: 'Crisis hipertensivas',
                y: porcentajesubCarciCrisisHipertensivas2023
            }, {
                name: 'Post paro',
                y: porcentajesubCarciPostParo2023
            }, {
                name: 'Otros',
                y: porcentajesubCarciOtros2023
            }]
        }]
    });
}
$("#verGraficoSubCardioCausaIngresoGlobal").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoSubCardioCausaIngresoGlobal();
});
function graficoSubCardioCausaIngresoGlobal() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajesubCarciChoqueCardiogenicoGlobal = miObjeto.subCarciChoqueCardiogenicoTotal;
    var porcentajesubCarciPostOperadoCirugiaCardiacaGlobal = miObjeto.subCarciPostOperadoCirugiaCardiacaTotal;
    var porcentajesubCarciTaquiarritmiaBradiarritmiaGlobal = miObjeto.subCarciTaquiarritmiaBradiarritmiaTotal;
    var porcentajesubCarciCrisisHipertensivasGlobal = miObjeto.subCarciCrisisHipertensivasTotal;
    var porcentajesubCarciPostParoGlobal = miObjeto.subCarciPostParoTotal;
    var porcentajesubCarciOtrosGlobal = miObjeto.subCarciOtrosTotal;


    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Subcategorías de causa de ingreso Cardiovascular 2019 - 2023'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: 'Global',
            colorByPoint: true,
            data: [{
                name: 'Choque cardiogénico',
                y: porcentajesubCarciChoqueCardiogenicoGlobal,
                sliced: true,
                selected: true
            }, {
                name: 'Post operado cirugía cardiaca',
                y: porcentajesubCarciPostOperadoCirugiaCardiacaGlobal
            }, {
                name: 'Taquiarritmia - bradiarritmia',
                y: porcentajesubCarciTaquiarritmiaBradiarritmiaGlobal
            }, {
                name: 'Crisis hipertensivas',
                y: porcentajesubCarciCrisisHipertensivasGlobal
            }, {
                name: 'Post paro',
                y: porcentajesubCarciPostParoGlobal
            }, {
                name: 'Otros',
                y: porcentajesubCarciOtrosGlobal
            }]
        }]
    });
}
//Gastrointestinal
$("#verGraficoSubGastroCausaIngreso2019").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoSubGastroCausaIngreso2019();
});
function graficoSubGastroCausaIngreso2019() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajesubGasciPancreatitisAguda2019 = miObjeto.subGasciPancreatitisAguda2019;
    var porcentajesubGasciHemorragiaDigestiva2019 = miObjeto.subGasciHemorragiaDigestiva2019;
    var porcentajesubGasciPostOperadosComplicados2019 = miObjeto.subGasciPostOperadosComplicados2019;
    var porcentajesubGasciOtros2019 = miObjeto.subGasciOtros2019;

    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Subcategorías de causa de ingreso Gastrointestinal  2019'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: '2019',
            colorByPoint: true,
            data: [{
                name: 'Pancreatitis aguda',
                y: porcentajesubGasciPancreatitisAguda2019,
                sliced: true,
                selected: true
            }, {
                name: 'Hemorragia digestiva',
                y: porcentajesubGasciHemorragiaDigestiva2019
            }, {
                name: 'Post operados complicados',
                y: porcentajesubGasciPostOperadosComplicados2019
            }, {
                name: 'Otros',
                y: porcentajesubGasciOtros2019
            
            }]
        }]
    });
}
$("#verGraficoSubGastroCausaIngreso2020").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoSubGastroCausaIngreso2020();
});
function graficoSubGastroCausaIngreso2020() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajesubGasciPancreatitisAguda2020 = miObjeto.subGasciPancreatitisAguda2020;
    var porcentajesubGasciHemorragiaDigestiva2020 = miObjeto.subGasciHemorragiaDigestiva2020;
    var porcentajesubGasciPostOperadosComplicados2020 = miObjeto.subGasciPostOperadosComplicados2020;
    var porcentajesubGasciOtros2020 = miObjeto.subGasciOtros2020;

    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Subcategorías de causa de ingreso Gastrointestinal  2020'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: '2020',
            colorByPoint: true,
            data: [{
                name: 'Pancreatitis aguda',
                y: porcentajesubGasciPancreatitisAguda2020,
                sliced: true,
                selected: true
            }, {
                name: 'Hemorragia digestiva',
                y: porcentajesubGasciHemorragiaDigestiva2020
            }, {
                name: 'Post operados complicados',
                y: porcentajesubGasciPostOperadosComplicados2020
            }, {
                name: 'Otros',
                y: porcentajesubGasciOtros2020

            }]
        }]
    });
}
$("#verGraficoSubGastroCausaIngreso2021").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoSubGastroCausaIngreso2021();
});
function graficoSubGastroCausaIngreso2021() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajesubGasciPancreatitisAguda2021 = miObjeto.subGasciPancreatitisAguda2021;
    var porcentajesubGasciHemorragiaDigestiva2021 = miObjeto.subGasciHemorragiaDigestiva2021;
    var porcentajesubGasciPostOperadosComplicados2021 = miObjeto.subGasciPostOperadosComplicados2021;
    var porcentajesubGasciOtros2021 = miObjeto.subGasciOtros2021;

    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Subcategorías de causa de ingreso Gastrointestinal  2021'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: '2021',
            colorByPoint: true,
            data: [{
                name: 'Pancreatitis aguda',
                y: porcentajesubGasciPancreatitisAguda2021,
                sliced: true,
                selected: true
            }, {
                name: 'Hemorragia digestiva',
                y: porcentajesubGasciHemorragiaDigestiva2021
            }, {
                name: 'Post operados complicados',
                y: porcentajesubGasciPostOperadosComplicados2021
            }, {
                name: 'Otros',
                y: porcentajesubGasciOtros2021

            }]
        }]
    });
}
$("#verGraficoSubGastroCausaIngreso2022").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoSubGastroCausaIngreso2022();
});
function graficoSubGastroCausaIngreso2022() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajesubGasciPancreatitisAguda2022 = miObjeto.subGasciPancreatitisAguda2022;
    var porcentajesubGasciHemorragiaDigestiva2022 = miObjeto.subGasciHemorragiaDigestiva2022;
    var porcentajesubGasciPostOperadosComplicados2022 = miObjeto.subGasciPostOperadosComplicados2022;
    var porcentajesubGasciOtros2022 = miObjeto.subGasciOtros2022;

    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Subcategorías de causa de ingreso Gastrointestinal  2022'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: '2022',
            colorByPoint: true,
            data: [{
                name: 'Pancreatitis aguda',
                y: porcentajesubGasciPancreatitisAguda2022,
                sliced: true,
                selected: true
            }, {
                name: 'Hemorragia digestiva',
                y: porcentajesubGasciHemorragiaDigestiva2022
            }, {
                name: 'Post operados complicados',
                y: porcentajesubGasciPostOperadosComplicados2022
            }, {
                name: 'Otros',
                y: porcentajesubGasciOtros2022

            }]
        }]
    });
}
$("#verGraficoSubGastroCausaIngreso2023").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoSubGastroCausaIngreso2023();
});
function graficoSubGastroCausaIngreso2023() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajesubGasciPancreatitisAguda2023 = miObjeto.subGasciPancreatitisAguda2023;
    var porcentajesubGasciHemorragiaDigestiva2023 = miObjeto.subGasciHemorragiaDigestiva2023;
    var porcentajesubGasciPostOperadosComplicados2023 = miObjeto.subGasciPostOperadosComplicados2023;
    var porcentajesubGasciOtros2023 = miObjeto.subGasciOtros2023;

    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Subcategorías de causa de ingreso Gastrointestinal  2023'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: '2023',
            colorByPoint: true,
            data: [{
                name: 'Pancreatitis aguda',
                y: porcentajesubGasciPancreatitisAguda2023,
                sliced: true,
                selected: true
            }, {
                name: 'Hemorragia digestiva',
                y: porcentajesubGasciHemorragiaDigestiva2023
            }, {
                name: 'Post operados complicados',
                y: porcentajesubGasciPostOperadosComplicados2023
            }, {
                name: 'Otros',
                y: porcentajesubGasciOtros2023

            }]
        }]
    });
}
$("#verGraficoSubGastroCausaIngresoGlobal").click(function () {
    $(".modal-header").css("background-color", "#004c46");
    $(".modal-header").css("color", "white");
    $(".modal-title").text("Gráfico de Torta");
    $("#modal-1").modal("show");
    graficoSubGastroCausaIngresoGlobal();
});
function graficoSubGastroCausaIngresoGlobal() {
    var miObjeto = JSON.parse(document.getElementById('miObjeto').dataset.miObjeto);
    // Acceso a cada propiedad del objeto
    var porcentajesubGasciPancreatitisAgudaGlobal = miObjeto.subGasciPancreatitisAgudaTotal;
    var porcentajesubGasciHemorragiaDigestivaGlobal = miObjeto.subGasciHemorragiaDigestivaTotal;
    var porcentajesubGasciPostOperadosComplicadosGlobal = miObjeto.subGasciPostOperadosComplicadosTotal;
    var porcentajesubGasciOtrosGlobal = miObjeto.subGasciOtrosTotal;

    Highcharts.chart('contenedor-modal', {
        chart: {
            type: 'pie',
            plotBackgroundColor: '#f8f9fa', //color de fondo del gráfico
            plotBorderwidth: 1,
            plotShadow: false,
        },
        title: {
            text: 'Subcategorías de causa de ingreso Gastrointestinal 2019 - 2023'
        },
        tooltip: {
            pointFormat: '{series.name}:<b>{point.percentage:.2f}</b>%',
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '{point.name}:<b>{point.percentage:.2f}</b>%'
                }
            }
        },
        series: [{
            name: 'Global',
            colorByPoint: true,
            data: [{
                name: 'Pancreatitis aguda',
                y: porcentajesubGasciPancreatitisAgudaGlobal,
                sliced: true,
                selected: true
            }, {
                name: 'Hemorragia digestiva',
                y: porcentajesubGasciHemorragiaDigestivaGlobal
            }, {
                name: 'Post operados complicados',
                y: porcentajesubGasciPostOperadosComplicadosGlobal
            }, {
                name: 'Otros',
                y: porcentajesubGasciOtrosGlobal

            }]
        }]
    });
}