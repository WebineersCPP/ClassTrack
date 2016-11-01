// csController.js

(function () {
    "use strict";

    angular.module("app-home")
        .controller("csController", csController);

    function csController($routeParams, $http) {
        var vm = this;
        vm.loading = true;
        var id = $routeParams.id;

        vm.year = 0;
        vm.major = "";
        vm.subplan = "";
        vm.minUnits = 0;
        vm.modules = [];
        
        $http.get("/api/curriculum-sheet/" + id)
            .then(function (response) {
                if (response.data) {
                    vm.year = response.data.year;
                    vm.major = response.data.major;
                    vm.subplan = response.data.subplan;
                    vm.minUnits = response.data.minUnitsReq;
                    angular.copy(response.data.modules, vm.modules);
                }
                else {
                    vm.errorMessage = "Unable to retrieve catalog.";
                }
            }, function (error) {
                vm.errorMessage = "Error retrieving catalog: " + error;
            })
            .finally(function () {
                vm.loading = false;
            });
    }
})();

