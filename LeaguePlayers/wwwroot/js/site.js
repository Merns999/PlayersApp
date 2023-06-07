$(document).ready(function () {
    function ViewModel() {
        /*debugger;*/
        var self = this;
        //self.Id = ko.observable("");

        //basketball stuff
        self.Name = ko.observable("");
        self.Email = ko.observable("");
        self.Url = ko.observable("");
        self.Phone = ko.observable("");
        self.Hand = ko.observable("");
        self.Rank = ko.observable("");
        self.Salary = ko.observable("");
        self.Shots = ko.observable("");
        ///football stuff
        self.Foot = ko.observable("");
        self.FootRank = ko.observable("");
        self.FootSalary = ko.observable("");
        self.FootPhone = ko.observable("");
        self.FootUrl = ko.observable("");
        self.FootEmail = ko.observable("");
        self.FootName = ko.observable("");
        self.Goals = ko.observable("");
        

        self.addBasketBallPlayer = function () {
            /*debugger;*/
            var data = {
                /*Id: this.Id(),*/
                name: self.Name(),
                email: self.Email(),
                url: self.Url(),
                phone: self.Phone(),
                hand: self.Hand(),
                rank: self.Rank(),
                salary: self.Salary(),
                shots: self.Shots()
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
        self.addFootBallPlayer = function () {
            debugger;
            var fdata = {
                //Id: this.Id(),
                name: self.FootName(),
                email: self.FootEmail(),
                url: self.FootUrl(),
                phone: self.FootPhone(),
                foot: self.Foot(),
                rank: self.FootRank(),
                salary: self.FootSalary(),
                goals: self.Goals()
            };
            $.ajax({
                type: "POST",
                url: "http://localhost:54528/api/FootBalls",
                data: JSON.stringify(fdata),
                contentType: "application/json",
                success: function (responce) {
                    //handle success message
                    alert("The FootBall Player was added successfully");
                    window.location.href = "/FootBall/Index";
                },
                error: function (error) {
                    //handle error
                    debugger;
                }
            });
        };

        self.getFootBallPlayers = function () {
            /*debugger;*/
            $.ajax({
                type: "GET",
                url: "http://localhost:54528/api/FootBalls",
                success: function (responce) {
                    //handle success message
                    /*debugger;*/
                    
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
        self.getBasketBallPlayers = function () {
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
        /*debugger;*/
        viewModel.addFootBallPlayer();
    });
    $('#addBasketBallPlayerForm').submit(function (event) {
        event.preventDefault();
        /*debugger;*/
        viewModel.addBasketBallPlayer();
    });

    $('#BasketButton').click(function (event) {
        event.preventDefault();
        /*debugger;*/
        viewModel.getBasketBallPlayers();
    });
    $('#FootButton').click(function (event) {
        event.preventDefault();
        /*debugger;*/
        viewModel.getFootBallPlayers();
    });
});