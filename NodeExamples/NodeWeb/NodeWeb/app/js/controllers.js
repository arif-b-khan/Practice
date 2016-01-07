'use strict';

/* Controllers */

angular.module('myApp.controllers', []).
  controller('Calculator', ['$scope', function ($scope) {
        $scope.Sum = function (n1, n2) {
            var result = 0;
            result = n1 + n2;
            return result;
        };

        $scope.Subtract = function (n1, n2) {
            return n1 - n2;        
        };

        $scope.Division = function (n1, n2) {
            return n1 / n2;
        };

        $scope.Multiply = function (n1, n2) {
            return n1 * n2;
        };

  }])
  .controller('MyCtrl2', [function() {

  }]);