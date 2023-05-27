//$(document).ready(function () {
//    $('#addPlayerForm').submit(function (event) {
//        event.preventDefault(); // Prevent the form from submitting normally

//        var formData = $(this).serialize(); // Serialize the form data

//        $.ajax({
//            url: $(this).attr('action'), // Get the form action URL
//            type: $(this).attr('method'), // Get the form method (POST)
//            data: formData, // Set the form data
//            success: function (response) {
//                // Handle the success response
//                console.log(response);
//                // Optionally, you can redirect to another page
//                // window.location.href = '/Players/List';
//                window.location.href = '/Players/List';
//            },
//            error: function (xhr, status, error) {
//                // Handle the error response
//                console.log(xhr.responseText);
//            }
//        });
//    });
//});
//$(document).ready(function () {
//    $('#addPlayerForm').submit(function (event) {
//        event.preventDefault(); // Prevent the form from submitting normally

//        var formData = new FormData(this); // Create a new FormData object with the form data

//        fetch($(this).attr('action'), {
//            method: $(this).attr('method'), // Get the form method (POST)
//            body: formData // Set the form data as the request body
//        })
//            .then(function (response) {
//                // Handle the success response
//                if (response.ok) {
//                    console.log('Player added successfully');
//                    // Optionally, you can redirect to another page
//                    // window.location.href = '/Players/List';
//                } else {
//                    console.log('Error adding player');
//                }
//            })
//            .catch(function (error) {
//                // Handle the error
//                console.log('Error: ' + error.message);
//            });
//    });
//});

//const MyForm = document.getElementById('addPlayerForm');

//MyForm.addEventListener('submit', function (e) {
//    e.preventDefault();

//    const player = new FormData(MyForm);

//    console.log([...player]);

//    fetch("")
//})


$(document).ready(function () {
    $('#addPlayerForm').submit(function (event) {
        event.preventDefault();
        debugger;
        var name = $("#Name").val();
        var Email = $("#email").val();
        var rank = $("#rank").val();
        var salary = $("#salary").val();
        var phone = $("#phone").val();
        var url = $("#url").val();

        var data = {
            Name: name,
            Email: email,
            Rank: rank,
            Salary: salary,
            Phone: phone,
            Url: url
        };


        $.ajax({
            type: "POST",
            url: "https://localhost:7156/api/Players",
            data: JSON.stringify(data),
            contentType: "application/json",
            success: function (response) {
                alert("Player added successfully");
                window.location.href = "/List";
            },
            error: function (error) {
                alert("Player not added!!!");
            }
        });
    });
});