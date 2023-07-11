$(document).ready(function () {
    function ViewModel() {
        var self = this;
        /*debugger;*/
        self.Id = ko.observable("");
        self.Name = ko.observable("");
        self.Email = ko.observable("");
        self.Ranks =  ko.observableArray([1, 2, 3, 4, 5]);
        self.Rank = ko.observable("");
        self.Salary = ko.observable("");
        self.Phone = ko.observable("");
        self.Url = ko.observable("");


        //Adding a player using the post request
        self.addPlayer = function () {
            debugger;
            var data = {
                name: self.Name(),
                email: self.Email(),
                rank: self.Rank(),
                salary: self.Salary(),
                phone: self.Phone(),
                url: self.Url()
            };
            /*debugger;*/
            $.ajax({
                type: "POST",
                url: "/api/Players",
                data: JSON.stringify(data),
                contentType: "application/json",
                success: function (response) {
                    setTimeout(function () {
                        document.querySelector('.alert("Player added successfully")');
                    }, 30000);
                    /*alert("Player added successfully")*/;
                    window.location.href = "/Players/List";
                },
                error: function (error) {
                    alert("Player not added!!!");
                }
            });
        };
        
        

        self.editPlayer = function (id) {
            /*debugger;*/
            //var editPlayerId = localStorage.getItem('editPlayerId');
            //localStorage.removeItem('editPlayerId');
            var editPlayerId = sessionStorage.getItem('editPlayerId');
            
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
            /*debugger;*/
            $.ajax({
                type: "PUT",
                url: "/api/Players/" + editPlayerId,
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
            /*debugger;*/
            $.ajax({
                type: "DELETE",
                url: "/api/Players" + id,
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



