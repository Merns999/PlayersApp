$(document).ready(function () {

    /*debugger;*/
    $.ajax({
        type: "GET",
        url: "/api/Players",
        success: function (response) {

            populateTable(response);
        },
        error: function (error) {
            console.log("Error fetching players data:", error);
        }
    });

    function populateTable(data) {
        var table = $('#playersTable');

        table.find('tbody').empty();

        data.forEach(function (player) {
            console.log(player);
            var row = $('<tr>');
            /*row.append('<td>' + player.id + '</td>');*/
            row.append('<td>' + player.name + '</td>');
            row.append('<td>' + player.email + '</td>');
            row.append('<td>' + player.rank + '</td>');
            row.append('<td>' + player.salary + '</td>');
            row.append('<td>' + player.phone + '</td>');
            row.append('<td><a href="' + player.url + '" class="btn">Image</a></td>');
            /*row.append('<td><a href="/Players/Edit" class="btn btn-dark" id="editButton" data-bind="click: $root.editPlayer.bind($data,' + player.id + ')" >Edit</a></td>');*/
            var editButton = $('<td><a class="btn btn-dark editButton">Edit</a></td>');
            editButton.find('.editButton').on('click', function () {
                
                /*localStorage.setItem('editPlayerId', player.id);*/
                sessionStorage.setItem('editPlayerId', player.id);
                window.location.href = '/Players/Edit';
            });
            row.append(editButton);
            /*row.append('<td><a class="btn btn-danger" onclick="deletePlayer('+player.id+')" id="deleteButton" >Delete</a></td>');*/
            var deleteButton = $('<td><a class="btn btn-danger" id="deleteButton">Delete</a></td>');
            deleteButton.find('#deleteButton').on('click', function () {
                deletePlayer(player.id, player.name);
            });
            row.append(deleteButton);
            table.append(row);
        });
        
        function deletePlayer(id, name){
            /*debugger;*/
            var ans = confirm("Are you sure you want to delete " + name);
            if (ans) {
                $.ajax({
                    type: "DELETE",
                    url: "/api/Players/" + id,
                    success: function (response) {
                        alert("Player DELETED successfully");
                        window.location.href = "/Players/List";
                    },

                    error: function (error) {
                        alert("Error fetching players data:", error);
                    }
                });
            }
        };
    };
});