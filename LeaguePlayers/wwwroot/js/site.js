$(document).ready(function () {
    function ViewModel() {
        /*debugger;*/
        this.Id = ko.observable("");
        this.Name = ko.observable("");
        this.Email = ko.observable("");
        this.Url = ko.observable("");
        this.Phone = ko.observable("");
        this.Hand = ko.observable("");
        this.Rank = ko.observable("");
        this.Salary = ko.observable("");
        this.Shots = ko.observable("");
        this.Foot = ko.observable("");
        this.Goals = ko.observable("");

        this.addBasketBallPlayer = function () {
            debugger;
            var data = {
                /*Id: this.Id(),*/
                name: this.Name(),
                email: this.Email(),
                url: this.Url(),
                phone: this.Phone(),
                hand: this.Hand(),
                rank: this.Rank(),
                salary: this.Salary(),
                shots: this.Shots()
            };
            $.ajax({
                type: "POST",
                url: "http://localhost:54528/api/BasketBalls",
                data: JSON.stringify(data),
                contentType: "application/json",
                success: function (responce) {
                    //handle success message
                    alert("The BasketBall Player was added successfully");
                    window.location.href = "/BasketBall/Index";
                },
                error: function (error) {
                    //handle error
                }
            });
        };
        this.addFootBallPlayer = function () {
            debugger;
            var data = {
                //Id: this.Id(),
                name: this.name(),
                Email: this.Email(),
                Url: this.Url(),
                Phone: this.Phone(),
                Foot: this.Hand(),
                Rank: this.Rank(),
                Salary: this.Salary(),
                Goals: this.Shots()
            };
            $.ajax({
                type: "POST",
                url: "http://localhost:5175/api/FootBalls",
                data: JSON.stringify(data),
                contentType: "application/json",
                success: function (responce) {
                    //handle success message
                    console.log(responce)
                },
                error: function (error) {
                    //handle error
                }
            });
        };

        this.getFootBallPlayers = function () {
            debugger;
            $.ajax({
                type: "GET",
                url: "http://localhost:54528/api/FootBalls",
                success: function (responce) {
                    //handle success message
                    debugger;
                    
                    //window.location.href = "/FootBall/Index?data=" + encodeURIComponent(JSON.stringify(responce));
                    localStorage.setItem("FootBallData", JSON.stringify(responce));
                    window.location.href = "/FootBall/Index";
                },
                error: function (error) {
                    //handle error
                    console.log("Error fetching players data:", error);
                }
            });
        };
        this.getBasketBallPlayers = function () {
            /*debugger;*/
            $.ajax({
                type: "GET",
                url: "http://localhost:54528/api/BasketBalls",
                success: function (responce) {
                    //handle success message
                    localStorage.setItem("BasketBallData", JSON.stringify(responce));
                    window.location.href = "/BasketBall/Index";
                    
                },
                error: function (error) {
                    //handle error
                    console.log("Error fetching players data:", error);
                }
            });
        };
    };

    

    var viewModel = new ViewModel();
    ko.applyBindings(viewModel);

    $('#addFootBallPlayerForm').submit(function (event) {
        event.preventDefault();
        debugger;
        viewModel.addFootBallPlayer();
    });
    $('#addBasketBallPlayerForm').submit(function (event) {
        event.preventDefault();
        debugger;
        viewModel.addBasketBallPlayer();
    });

    $('#BasketButton').click(function (event) {
        event.preventDefault();
        debugger;
        viewModel.getBasketBallPlayers();
    });
    $('#FootButton').click(function (event) {
        event.preventDefault();
        debugger;
        viewModel.getFootBallPlayers();
    });
});