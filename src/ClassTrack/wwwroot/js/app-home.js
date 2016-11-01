(function () {
    "use strict";

    // create the module
    angular.module("app-home", ["ngRoute"])
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

            $routeProvider.otherwise({ redirectTo: "/" });
        });

})();