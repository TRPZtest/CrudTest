// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
	$("#addEmployeeId").submit(function (event) {
	
		$("#AddingResult").html("");
	
		let formData = {
			Name: $("#name").val(),
			SurName: $("#surname").val(),
			Age: $("#age").val(),
			DepartmentId: $('#department').find(":selected").val(),
			ProgrammingLanguageId: $('#programmingLanguage').find(":selected").val()
		};

		$.ajax({
			type: "POST",
			url: "add",
			data: JSON.stringify(formData),		
			contentType: 'application/json; charset=utf-8',
			encode: true,
			
		}).done(function (data) {
			$("#AddingResult").html(
				'<div class="alert alert-success">Success</div>'
			);			
		})
		.fail(function (data) {
			console.log(data);
			if (data.hasOwnProperty('responseJSON'))
				$("#AddingResult").html(
					`<div class="alert alert-danger">Error: ${data.responseJSON.message}</div>`
				);
			else
				$("#AddingResult").html(
					'<div class="alert alert-danger">Generic Error</div>'
				);
		});

		event.preventDefault();
	});
});