/// <reference path="../angular.js" />
/// <reference path="../angular.min.js" />
/// <reference path="Modules.js" />

app.service("AngularJs_WCFService", function ($http) {
    //Get order master records
    this.getOrderMaster = function () {
        return $http.get("http://localhost:62871/Service1.svc/GetOrderMaster");
    };

    //Search order master rcords
    this.getSearchOrder = function (OrderNO) {
        return $http.get("http://localhost:62871/Service1.svc/SearchOrderMaster/" + OrderNO);
    }

    //Search order details records
    this.getOrderDetail = function (OrderNO){
        return $http.get("http://localhost:62871/Service1.svc/OrderDetails/" + OrderNO);
    }
});