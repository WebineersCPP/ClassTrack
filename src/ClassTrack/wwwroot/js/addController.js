// addController.js

(function () {
    "use strict";

    angular.module("app-home")
        .controller("addController", addController);

    function addController($http, $window) {
        var vm = this;
        vm.loading = true;

        vm.majors = [];
        vm.subplans = [];
        vm.years = [];

        vm.selectedMajor = "";
        vm.selectedSubplan = "";
        vm.selectedYear;

        //TODO: retrieve years from school's website
        vm.years = [2012,2013,2014,2015,2016]


        // Call database to retrieve available catalog majors and subplans
        // TODO: display majors in alphabetical order
        $http.get("/api/cpp/majors")
            .then(function (response) {
                if (response.data != null) {
                    vm.majors = response.data;
                    angular.forEach(vm.majors, function (value, key) {
                        angular.forEach(value.subplans, function (v, k) {
                            vm.subplans.push(v);
                        });                        
                    });
                }
                else {
                    vm.errorMessage = "Not available majors to show.";
                }
            }, function (error) {
                vm.errorMessage = error.data;
            })
            .finally(function () {
                vm.loading = false;
            });

        // Query input text in search of majors
        vm.querySearchMajor = function (query) {
            var results = query ? vm.majors.filter(createFilterFor(query)) : vm.majors;
            return results;
        }

        // Query input text in search of subplans only belonging to selected major
        vm.querySearchSubplan = function (query) {
            var results = query ? vm.selectedMajor.subplans.filter(createFilterFor(query)) : vm.selectedMajor.subplans;
            return results;
        }

        // Create filter function for a query string
        var createFilterFor = function (query) {
            var lowercaseQuery = angular.lowercase(query);

            return function filterFn(item) {
                var lowercaseItem = angular.lowercase(item.title);
                return (lowercaseItem.indexOf(lowercaseQuery) === 0);
            };
        }
        
        // Refresh subplans list if major is changed
        vm.selectedItemChange = function (item) {
            vm.selectedSubplan = "";
        }

        // Call service in database to store newly created user curriculum sheet
        vm.submit = function () {
            // validate input
            if (!vm.selectedMajor || !vm.selectedYear) {
                vm.errorMessage = "Must specify input major and/or year";
            } else {
                var cs = {
                    year: parseInt(vm.selectedYear),
                    major: vm.selectedMajor.title,
                    subplan: vm.selectedSubplan.title
                };

                $http.post("/api/curriculum-sheet", cs)
                .then(function (response) {
                    if (response.data != null) {
                        var id = response.data.id;
                        $window.location.href = "#/detail/" + id;
                    }
                    else {
                        vm.errorMessage = "New curriculum sheet was not added";
                    }
                }, function (error) {
                    vm.errorMessage = error.data;
                })
                .finally(function () {
                    vm.loading = false;
                });
            }
        }
    }
})();

