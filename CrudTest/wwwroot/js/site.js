// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $("#addEmployeeId").submit(function (event) {
      event.preventDefault();

      console.log("test");

      var formData = {
        Name: $("#name").val(),
        SurName: $("#surname").val(),
        Age: $("age").val(),
        Department: $("#department").val(),
        ProgrammingLanguage: $("#programmingLanguage").val()       
      };
  
      $.ajax({
        type: "POST",
        url: "add",
        data: JSON.stringify(formData),
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        encode: true,
        })
          .done(function (data) {
          
        
          console.log(data);
        })  
          .fail(function (data) {
          console.log(data);
          if (data.hasOwnProperty('responseJSON'))
            $("form").html(
              `<div class="alert alert-danger">Error ${data.responseJSON.message}</div>`
            );
          else
            $("form").html(
              '<div class="alert alert-danger">Generic Error</div>'
            );
      });
;
  
      return false;
    });
  });