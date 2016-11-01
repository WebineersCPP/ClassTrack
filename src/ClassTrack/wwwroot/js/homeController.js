// homeController.js

(function () {
    "use strict";

    angular.module("app-home")
        .controller("homeController", homeController);

    function homeController($http) {
        var vm = this;
        vm.loading = true;
        vm.curriculumSheets = [];

        $http.get("/api/curriculum-sheet")
            .then(function (response) {
                // success
                vm.curriculumSheets = response.data;
            }, function (error) {
                // failure
                vm.errorMessage = "Unable to retrieve catalog: " + error;
            })
            .finally(function () {
                vm.loading = false;
            });
    }

})();