//Para obntener la hora fecha actual
const ahora = new Date();
const fechaActual = ahora.toISOString().slice(0, 19).replace('T', ' ');
$(document).ready(function () {
	$('#tablaGestionIngresos').DataTable({
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
					columns: [0, 1, 2, 3, 4, 5,6,7,8,9]
				},
				filename: "Registros " + fechaActual, //nombre archivo
				title: "Registros " + fechaActual
			},
			{
				extend: 'pdfHtml5',
				text: '<i class="fas fa-file-pdf"></i> ',
				titleAttr: 'Exportar a PDF',
				className: 'btn btn-danger',
				orientation: 'landscape',
				exportOptions: {
					columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
				},
				filename: "Registros " + fechaActual, //nombre archivo
				title: "Registros " + fechaActual,
				pageSize: 'legal'
			},
			{
				extend: 'print',
				text: '<i class="fa fa-print"></i> ',
				titleAttr: 'Imprimir',
				className: 'btn btn-info',
				orientation: 'landscape',
				exportOptions: {
					columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
				},
				filename: "Registros " + fechaActual, //nombre archivo
				title: "Registros " + fechaActual,
				pageSize: 'legal'
			},
		]
	});

	//alert("Js de dataTable Listo");





	//Esto Captura los datos es para registrar ususario
	$('#btnInsertarRegistro').click(function () {
		// Capturar los valores de los campos del modal
		var sexo = $('input[name="sexo_ingreso"]:checked').val();
		var edad = $('#edad_ingreso').val();
		var fechaIngreso = $('#fechIngreso').val();
		var fechaEgreso = $('#fechEgreso').val();
		var origenIngreso = $('#origenIngreso').val();
		var causaIngreso = $('#causaIngreso').val();
		var subCausaIngreso = $('#SubcausaIngreso').val();
		var servicioEgreso = $('#servicioEngreso').val();
		var causaMuerte = $('#causaMortalidad').val();


		//alert(sexo);
		//alert(edad);
		//alert(fechaIngreso);
		//alert(fechaEgreso);
		//alert(origenIngreso);
		//alert(causaIngreso);
		//alert(subCausaIngreso);
		//alert(servicioEgreso);
		//alert(causaMuerte);

		// Crear objeto con los datos a enviar al controlador
		var datosToSendIstReg = {
			Sexo: sexo,
			Edad: edad,
			FechaIngreso: fechaIngreso,
			FechaEgreso: fechaEgreso,
			OrigenIngreso: origenIngreso,
			CausaIngreso: causaIngreso,
			SubCausaIngreso: subCausaIngreso,
			ServicioEgreso: servicioEgreso,
			CausaMortalidad: causaMuerte
		};

		// Realizar la solicitud AJAX para enviar los datos al controlador
		$.ajax({
			url: '/Registro/InsertarRegistro',
			async: false,
			type: "post",
			dataType: "json",
			data: datosToSendIstReg,
			success: function (responseRegistrarUsr) {
				if (responseRegistrarUsr.success) {
					Swal.fire({
						title: responseRegistrarUsr.title,
						text: responseRegistrarUsr.message,
						icon: responseRegistrarUsr.icon
					}).then((result) => {
						if (result.isConfirmed) {
							window.location.href = responseRegistrarUsr.url; // Redirige a la URL proporcionada por el servidor
						}
					});
				}
				else {
					// Manejar la respuesta del servidor, por ejemplo:
					Swal.fire({
						title: responseRegistrarUsr.title,
						text: responseRegistrarUsr.message,
						icon: responseRegistrarUsr.icon
					});
				}
			},
			error: function (error) {
				// Mostrar mensaje de error al usuario
				Swal.fire({
					title: "Error",
					text: "Error js: " + error,
					icon: "error"
				});
				console.log(error);
			}
		});
	});















	//pARA EL SELECT DE SUB CAUSA
	// Simular evento de cambio al cargar la página para que las subcategorías se carguen automáticamente
	$('#causaIngreso').change();

	$('#causaIngreso').change(function () {
		var causaIngresoValue = $(this).val();
		var subcausaIngreso = $('#SubcausaIngreso');
		var subCategoriaDiv = $('#subCategoriaDiv');

		subcausaIngreso.empty(); // Clear previous options

		// Populate subcausaIngreso based on causaIngresoValue
		switch (causaIngresoValue) {
			case "1":
				subcausaIngreso.show();
				subcausaIngreso.append($('<option>', { value: 1, text: 'TEC' }));
				subcausaIngreso.append($('<option>', { value: 2, text: 'AVC' }));
				subcausaIngreso.append($('<option>', { value: 3, text: 'EPILEPSIA' }));
				subcausaIngreso.append($('<option>', { value: 4, text: 'MENINGITIS' }));
				subcausaIngreso.append($('<option>', { value: 5, text: 'OTROS' }));
				break;
			case "2":
				subcausaIngreso.show();
				subcausaIngreso.append($('<option>', { value: 6, text: 'CHOQUE SÉPTICO- NEUMONÍA' }));
				subcausaIngreso.append($('<option>', { value: 7, text: 'TEP' }));
				subcausaIngreso.append($('<option>', { value: 8, text: 'EAP' }));
				subcausaIngreso.append($('<option>', { value: 9, text: 'ASMA, EPOC' }));
				subcausaIngreso.append($('<option>', { value: 10, text: 'OTROS' }));
				break;
			case "3":
				subcausaIngreso.show();
				subcausaIngreso.append($('<option>', { value: 11, text: 'CHOQUE CARDIOGÉNICO' }));
				subcausaIngreso.append($('<option>', { value: 12, text: 'POST OPERADO CIRUGÍA CARDIACA' }));
				subcausaIngreso.append($('<option>', { value: 13, text: 'TAQUIARRITMIA- BRADIARRITMIA' }));
				subcausaIngreso.append($('<option>', { value: 14, text: 'CRISIS HIPERTENSIVAS' }));
				subcausaIngreso.append($('<option>', { value: 15, text: 'POST PARO' }));
				subcausaIngreso.append($('<option>', { value: 16, text: 'OTROS' }));
				break;
			case "4":
				subcausaIngreso.show();
				subcausaIngreso.append($('<option>', { value: 17, text: 'PANCREATITIS AGUDA' }));
				subcausaIngreso.append($('<option>', { value: 18, text: 'HEMORRAGIA DIGESTIVA' }));
				subcausaIngreso.append($('<option>', { value: 19, text: 'POST OPERADOS COMPLICADOS' }));
				subcausaIngreso.append($('<option>', { value: 20, text: 'OTROS' }));
				break;
			case "5":
			case "6":
				subcausaIngreso.hide();
				break;
			default:
				subcausaIngreso.hide();
				break;
		}

		// Ocultar el div de subcategorías si se selecciona "RENAL-ENDOCRINOLÓGICO" o "OTROS"
		if (causaIngresoValue == "5" || causaIngresoValue == "6") {
			subCategoriaDiv.hide();
		} else {
			subCategoriaDiv.show();
		}
	});
		
	

	//para causa muerteee
	$("#servicioEngreso").change(function () {
		if ($(this).val() == "4") {
			$("#causaMortalidadDiv").show();
		} else {
			$("#causaMortalidadDiv").hide();
		}
	});
});






