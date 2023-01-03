
$(document).ready(function () {
	$("#EditEmployeeId").submit(function (event) {

		$("#OperationResult").html("");

		let formData = {
			Id: $("#employeeId").text(),
			Name: $("#name").val(),
			SurName: $("#surname").val(),
			Age: $("#age").val(),
			DepartmentId: $('#department').find(":selected").val(),
			ProgrammingLanguageId: $('#programmingLanguage').find(":selected").val()
		};

		console.log(formData);

		$.ajax({
			type: "POST",
			url: "edit",
			data: JSON.stringify(formData),
			contentType: 'application/json; charset=utf-8',
			encode: true,

		}).done(function (data) {
			$("#OperationResult").html(
				'<div class="alert alert-success">Success</div>'
			);
		})
			.fail(function (data) {
				console.log(data);
				if (data.hasOwnProperty('responseJSON'))
					$("#OperationResult").html(
						`<div class="alert alert-danger">Error: ${data.responseJSON.message}</div>`
					);
				else
					$("#OperationResult").html(
						'<div class="alert alert-danger">Generic Error</div>'
					);
			});

		event.preventDefault();
	});
});