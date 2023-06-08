$(document).ready(function () {
    /*debugger;*/
    //var urlParams = new URLSearchParams(window.location.search);
    //var data = urlParams.get("data");

    // Parse the JSON data
    //var jsonData = JSON.parse(decodeURIComponent(data));


    var data = localStorage.getItem("FootBallData");
    var jsonData = JSON.parse(data);
    populateFootTable(jsonData);

    function populateFootTable(data) {
        /*debugger;*/
        if (Array.isArray(data)) {
            var table = $('#FootBallersTable');
            /*debugger;*/
            table.find('tbody').empty();

            data.forEach(function (player) {
                console.log(player);
                var row = $('<tr>');
                /*row.append('<td>' + player.id + '</td>');*/
                row.append('<td>' + player.name + '</td>');
                row.append('<td>' + player.email + '</td>');
                row.append('<td>' + player.phone + '</td>');
                row.append('<td>' + player.salary + '</td>');
                row.append('<td>' + player.foot + '</td>');
                row.append('<td>' + player.rank + '</td>');
                row.append('<td>' + player.goals + '</td>');
                row.append('<td><a href="' + player.url + '" class="btn">Image</a></td>');
                /*row.append('<td><a href="/Players/Edit" class="btn btn-dark" id="editButton" data-bind="click: $root.editPlayer.bind($data,' + player.id + ')" >Edit</a></td>');*/
                var editButton = $('<td><a class="btn btn-dark editButton">Edit</a></td>');
                editButton.find('.editButton').on('click', function () {

                    /*localStorage.setItem('editPlayerId', player.id);*/
                    sessionStorage.setItem('editPlayerId', player.id);
                    window.location.href = '/FootBall/Edit';
                    //window.location.href = '/FootBall/Edit?data = ' + encodeURIComponent(player.id);
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
        } else {
            console.error('Invalid data format. Expected an array.');
        }
    };

    function deletePlayer(id, name) {
        /*debugger;*/
        var ans = confirm("Are you sure you want to delete " + name);
        if (ans) {
            $.ajax({
                type: "DELETE",
                url: "http://localhost:54528/api/FootBalls/" + id,
                success: function (response) {
                    alert("Player DELETED successfully, kindly refresh the list");
                },

                error: function (error) {
                    alert("Error fetching players data:", error);
                    debugger;
                }
            });
        }
    };
});