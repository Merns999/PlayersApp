$(document).ready(function () {
   
            $.ajax({
                type: "GET",
                url: "https://localhost:7156/api/Players",
                success: function (response) {
                    
                    populateTable(response);
                },

                error: function (error) {
                    console.log("Error fetching players data:", error);
                }
            });

            function populateTable(data) {
                var table = $('#playersTable');

                // Clear table body
                table.find('tbody').empty();
                
                // Populate table rows
                data.forEach(function (player) {
                    console.log(player);
                    var row = $('<tr>');
                    row.append('<td>' + player.name + '</td>');
                    row.append('<td>' + player.email + '</td>');
                    row.append('<td>' + player.rank + '</td>');
                    row.append('<td>' + player.salary + '</td>');
                    row.append('<td>' + player.phone + '</td>');
                    row.append('<td><a href="' + player.url + '" class="btn">Image</a></td>');
                    row.append('<td><a href="/Players/Edit/' + player.id + '" class="btn btn-dark">Edit</a></td>');
                    row.append('<td><a href="/Players/Delete/' + player.id + '" class="btn btn-danger">Delete</a></td>');

                    table.append(row);
                });
            };
    

});