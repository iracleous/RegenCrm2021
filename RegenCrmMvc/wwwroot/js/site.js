// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(document).ready(function () {
     if ($("#Results").length != 0) {
        loadData()
  }
    
});

function loadData() {

    let urlAPI = 'https://localhost:44349/api/customer';
    let method = 'GET';

    $.ajax(
        {
            url: urlAPI,
            method: method
        })
        .done(result => {
            let resultData = "<table  class='table'>";
            result.forEach(customer => resultData += ('<tr>'
                + '<td>'+customer.id + '</td>'
                + '<td>'+customer.firstName + '</td>'
                + '<td>'+customer.lastName + '</td>'
                + '<td>' + customer.email + '</td>'
                + '<td>' + customer.dateOfBirth + '</td>'
                + '<td>' + customer.isActive + '</td>'
                + '<td>' + customer.balance + '</td>'
                + '</tr>'));

            resultData += '</table>';
            $("#Results").html(resultData);

        })
        .fail(failure => {
            console.log('error in communication');
            console.log(JSON.stringify(failure));
        });
}


function saveCustomer() {
    let urlAPI = 'https://localhost:44349/api/customer';
    let method = 'POST';
    let data = JSON.stringify({
        FirstName: $('#FirstName').val(),
        LastName: $('#LastName').val(),
        Email: $('#Email').val(),
        DateOfBirth: $('#DateOfBirth').val(),
        Balance: $('#Balance').val()
    });
    let contentType = 'application/json';
                  
    $.ajax(
        {
            url: urlAPI,
            method: method,
            contentType: contentType,
            data: data
        })
        .done(result => alert(JSON.stringify(result)))
        .fail(failure => alert(JSON.stringify(failure)));
}
 