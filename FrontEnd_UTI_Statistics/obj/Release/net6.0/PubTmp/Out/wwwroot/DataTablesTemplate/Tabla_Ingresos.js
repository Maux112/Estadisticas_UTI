//Para obntener la hora fecha actual
const ahoraTasaIngresos = new Date();
const fechaActualTasaIngresos = ahoraTasaIngresos.toISOString().slice(0, 19).replace('T', ' ');

$(document).ready(function () {
	$('#tablaTasaIngresos').DataTable({
		language: {
			"lengthMenu": "Mostrar _MENU_ registros",
			"zeroRecords": "No se encontraron resultados",
			"info": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
			"infoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
			"infoFiltered": "(filtrado de un total de _MAX_ registros)",
			"sSearch": "Buscar:",
			"oPaginate": {
				"sFirst": "Primero",
				"sLast": "�ltimo",
				"sNext": "Siguiente",
				"sPrevious": "Anterior"
			},
			"sProcessing": "Procesando...",
		},
		//para usar los botones   
		responsive: "true",
		dom: 'Bfrtilp',
		buttons: [
			{
				extend: 'excelHtml5',
				text: '<i class="fas fa-file-excel"></i> ',
				titleAttr: 'Exportar a Excel',
				className: 'btn btn-success',
				orientation: 'portrait',
				exportOptions: {
					columns: [0, 1, 2, 3]
				},
				filename: "Ingresos " + fechaActualTasaIngresos, //nombre archivo
				title: "Ingresos " + fechaActualTasaIngresos
			},
			{
				extend: 'pdfHtml5',
				text: '<i class="fas fa-file-pdf"></i> ',
				titleAttr: 'Exportar a PDF',
				className: 'btn btn-danger',
				orientation: 'portrait',
				exportOptions: {
					columns: [0, 1, 2, 3]
				},
				filename: "Ingresos " + fechaActualTasaIngresos, //nombre archivo
				title: "Ingresos " + fechaActualTasaIngresos
			},
			{
				extend: 'print',
				text: '<i class="fa fa-print"></i> ',
				titleAttr: 'Imprimir',
				className: 'btn btn-info',
				orientation: 'portrait',
				exportOptions: {
					columns: [0, 1, 2, 3]
				},
				filename: "Ingresos " + fechaActualTasaIngresos, //nombre archivo
				title: "Ingresos " + fechaActualTasaIngresos
			},
		]
	});
});