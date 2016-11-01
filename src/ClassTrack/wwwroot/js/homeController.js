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
                if (response.data != null) {
                    vm.curriculumSheets = response.data;
                }
                else {
                    vm.errorMessage = "You don't have any curriculum sheets saved.";
                }
            }, function (error) {
                vm.errorMessage = "Unable to retrieve catalogs: " + error;
            })
            .finally(function () {
                vm.loading = false;
            });
    }

})();