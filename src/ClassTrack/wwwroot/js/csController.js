// csController.js

(function () {
    "use strict";

    angular.module("app-home")
        .controller("csController", csController);

    function csController($routeParams, $http) {
        var vm = this;
        vm.loading = true;
        var id = $routeParams.id;

        vm.hcolor = 0;

        vm.year = 0;
        vm.major = "";
        vm.subplan = "";
        vm.minUnits = 0;
        vm.modules = [];
        
        // Call server to retrieve appropriate curriculum sheet
        $http.get("/api/curriculum-sheet/" + id)
            .then(function (response) {
                if (response.data) {
                    var cs = response.data;
                    vm.year = cs.year;
                    vm.major = cs.major;
                    vm.subplan = cs.subplan;
                    vm.minUnits = cs.minUnitsReq;
                    angular.copy(cs.modules, vm.modules);
                }
                else {
                    vm.errorMessage = "Unable to retrieve catalog (id: " + id + ")";
                }
            }, function (error) {
                vm.errorMessage = "Error retrieving catalog: " + error;
            })
            .finally(function () {
                vm.loading = false;
            });

        // If module is a submodule, indent it a bit to the right
        vm.isSubmodule = function (module) {
            return module.isSubmodule == true ? true : false;
        };

        // If item is a course, allow user to highlight it
        vm.isHighlightable = function (item) {
            return item.isCourse == true ? true : false;
        };

        // Retrieve hightlight color code from item and color it in the UI
        vm.highlightColor = function (item) {
            switch(item.highlightColor) {
                case 0:
                    return "";
                    break;
                case 1:
                    return "hcolor-hastaken";
                    break;
                case 2:
                    return "hcolor-istaking";
                    break;
                default:
                    return "";
            }
        };

        // Highlight item and store update to database
        vm.highlight = function (item) {
            item.loading = true;

            $http.post("/api/item/update-highlight?itemId=" + item.id + "&hcolor=" + vm.hcolor)
                .then(function (response) {
                    if (response) {
                        // update highlight color in view
                        item.highlightColor = vm.hcolor;
                    }
                    else {
                        vm.errorMessage = "Unable to update item (id: " + id + ")";
                    }
                }, function (error) {
                    vm.errorMessage = "Error updating item: " + error;
                })
                .finally(function () {
                    item.loading = false;
                });           
        };

        // Activate highlight button
        $('#hcolor-container a').on('click', function () {
            $('#hcolor-container a').removeClass('active');
            $(this).addClass('active');
        })

    }
})();

