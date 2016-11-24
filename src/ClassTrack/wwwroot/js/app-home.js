(function () {
    "use strict";

    // create the module
    angular.module("app-home", ['ngMaterial','ngRoute'])
        .config(function ($routeProvider) {
            $routeProvider.when("/", {
                controller: "homeController",
                controllerAs: "vm",
                templateUrl: "/views/homeView.html"
            });
            $routeProvider.when("/detail/:id", {
                controller: "csController",
                controllerAs: "vm",
                templateUrl: "/views/csView.html"
            });
            $routeProvider.when("/add", {
                controller: "addController",
                controllerAs: "vm",
                templateUrl: "/views/addView.html"
            });

            $routeProvider.otherwise({ redirectTo: "/" });
        });

})();