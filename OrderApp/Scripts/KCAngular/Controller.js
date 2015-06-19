/// <reference path="../angular.js" />
/// <reference path="../angular.min.js" />
/// <reference path="Modules.js" />
/// <reference path="Services.js" />
app.controller("AngularJs_WCFController", function ($scope, $window, AngularJs_WCFService) {
    $scope.date = new Date();
    GetOrderMasters();
    //To get all records
    function GetOrderMasters() {
        var promiseGet = AngularJs_WCFService.getOrderMaster();
        promiseGet.then(function (pl) {
            $scope.OrderMastersDisp = pl.data
        },
        function (errorPl) {
        });
    }
    Hidetables()
    function Hidetables() {
        $scope.isRowHidden = false;
    }

    $scope.get = function (Order) {
        if (Order == null) {
            return;
        }
        if (Order.isRowHidden == true) {
            Order.isRowHidden = false;
            var promiseGet = AngularJs_WCFService.getOrderDetail(Order.Order_No);
            promiseGet.then(function (pl) {
                $scope.OrderDetailDisp = pl.data
            },
            function (errorPl) {
            });
        }
        else {
            Order.isRowHidden = true;
        }
    }
});