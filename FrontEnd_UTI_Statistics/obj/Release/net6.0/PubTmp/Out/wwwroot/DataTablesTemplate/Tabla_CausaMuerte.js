//Para obntener la hora fecha actual
const ahoraServicioCausaMortalidad = new Date();
const fechaActuaCausaMortalidad = ahoraServicioCausaMortalidad.toISOString().slice(0, 19).replace('T', ' ');
$(document).ready(function () {
	$('#tablaCausaMortalidad').DataTable({
		language: {
			"lengthMenu": "Mostrar _MENU_ registros",
			"zeroRecords": "No se encontraron resultados",
			"info": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
			"infoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
			"infoFiltered": "(filtrado de un total de _MAX_ registros)",
			"sSearch": "Buscar:",
			"oPaginate": {
				"sFirst": "Primero",
				"sLast": "Último",
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
					columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15]
				},
				filename: "Causa Mortalidad" + fechaActuaCausaMortalidad, //nombre archivo
				title: "Causa Mortalidad" + fechaActuaCausaMortalidad
			},
			{
				extend: 'pdfHtml5',
				text: '<i class="fas fa-file-pdf"></i> ',
				titleAttr: 'Exportar a PDF',
				className: 'btn btn-danger',
				orientation: 'landscape',
				exportOptions: {
					columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15]
				},
				filename: "Causa Mortalidad" + fechaActuaCausaMortalidad, //nombre archivo
				title: "Causa Mortalidad" + fechaActuaCausaMortalidad,
				pageSize: 'legal'
			},
			{
				extend: 'print',
				text: '<i class="fa fa-print"></i> ',
				titleAttr: 'Imprimir',
				className: 'btn btn-info',
				orientation: 'landscape',
				exportOptions: {
					columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15]
				},
				filename: "Causa Mortalidad" + fechaActuaCausaMortalidad, //nombre archivo
				title: "Causa Mortalidad" + fechaActuaCausaMortalidad,
				pageSize: 'legal'
			},
		]
	});
});