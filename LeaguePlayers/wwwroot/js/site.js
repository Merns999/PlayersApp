$(document).ready(function () {
    function ViewModel() {
        /*debugger;*/
        this.Id = ko.observable("");
        this.name = ko.observable("");
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
                name: this.name(),
                Email: this.Email(),
                Url: this.Url(),
                Phone: this.Phone(),
                Hand: this.Hand(),
                Rank: this.Rank(),
                Salary: this.Salary(),
                Shots: this.Shots()
            };
            $.ajax({
                type: "POST",
                url: "http://localhost:54528/api/BasketBalls",
                data: JSON.stringify(data),
                contentType: "application/json",
                success: function (responce) {
                    //handle success message

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
                    /*debugger;*/
                    window.location.href = "/FootBall/Index?data=" + encodeURIComponent(JSON.stringify(responce));
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
                    window.location.href = "/BasketBall/Index?data=" + encodeURIComponent(JSON.stringify(responce));
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