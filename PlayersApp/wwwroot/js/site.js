﻿

//$(document).ready(function () {
//    $('#addplayerform').submit(function (event) {
//        event.preventdefault();
//        debugger;
//        var name = $("#name").val();
//        var email = $("#email").val();
//        var rank = $("#rank").val();
//        var salary = $("#salary").val();
//        var phone = $("#phone").val();
//        var url = $("#url").val();


//        var data = {
//            name: name,
//            email: email,
//            rank: rank,
//            salary: salary,
//            phone: phone,
//            url: url
//        };


//        $.ajax({
//            type: "post",
//            url: "https://localhost:7156/api/players",
//            /*url: "https://localhost:44854/api/players", */
//            data: json.stringify(data),
//            contenttype: "application/json",
//            success: function (response) {
//                alert("player added successfully");
//                window.location.href = "players/list";
//            },
//            error: function (error) {
//                alert("player not added!!!");
//            }
//        });
//    });
//});

$(document).ready(function () {
    function ViewModel() {
        var self = this;
        /*debugger;*/
        self.Id = ko.observable("");
        self.Name = ko.observable("");
        self.Email = ko.observable("");
        self.Rank = ko.observable("");
        self.Salary = ko.observable("");
        self.Phone = ko.observable("");
        self.Url = ko.observable("");

        var getData = function () {
            $.ajax({
                type: "GET",
                url: "https://localhost:7156/api/Players",
                success: function (response) {

                    //handle responce
                },

                error: function (error) {
                   //handle the error
                }
            });

        }

        //Adding a player using the post request
        self.addPlayer = function () {
            /*debugger;*/
            var data = {
                name: self.Name(),
                email: self.Email(),
                rank: self.Rank(),
                salary: self.Salary(),
                phone: self.Phone(),
                url: self.Url()
            };

            $.ajax({
                type: "POST",
                url: "https://localhost:7156/api/Players",
                data: JSON.stringify(data),
                contentType: "application/json",
                success: function (response) {
                    alert("Player added successfully");
                    window.location.href = "/Players/List";
                },
                error: function (error) {
                    alert("Player not added!!!");
                }
            });
        };
        
        

        self.editPlayer = function (id) {
            
            var editPlayerId = localStorage.getItem('editPlayerId');
            localStorage.removeItem('editPlayerId');
            console.log(editPlayerId);
            /*debugger;*/
            var data = {
                id: editPlayerId,
                name: self.Name(),
                email: self.Email(),
                rank: self.Rank(),
                salary: self.Salary(),
                phone: self.Phone(),
                url: self.Url()
            };

            $.ajax({
                type: "PUT",
                url: "https://localhost:7156/api/Players/" + editPlayerId,
                data: JSON.stringify(data),
                contentType: "application/json",
                success: function (response) {
                    alert("Player edited successfully");
                    window.location.href = "/Players/List";
                },
                error: function (error) {
                    alert("Player not edited!!!");
                }
            });
        };


        self.deletePlayer = function () {

            $.ajax({
                type: "DELETE",
                url: "https://localhost:7156/api/Players" + id,
                data: JSON.stringify(data),
                contentType: "application/json",
                success: function (response) {
                    alert("Player deleted successfully");
                    window.location.href = "/Players/List";
                },
                error: function (error) {
                    alert("Player not added!!!");
                }
            });
        };
    }



    var viewModel = new ViewModel();
    ko.applyBindings(viewModel);

    $('#addPlayerForm').submit(function (event) {
        event.preventDefault();
        /*debugger;*/
        viewModel.addPlayer();
    });
    $('#editPlayerForm').submit(function (event) {
        event.preventDefault();
        /*debugger;*/
        viewModel.editPlayer();
    });

});



