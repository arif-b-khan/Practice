'use strict';

/* jasmine specs for controllers go here */

describe('controllers', function(){
  beforeEach(module('myApp.controllers'));
    var scope;
    beforeEach(inject(function ($rootScope, $controller) {
        scope = $rootScope.$new();
        $controller('Calculator', { $scope: scope });
    }));

  it('should validate the value of Sum method', inject(function() {
        var result = scope.Sum(10, 10);
        expect(result).toEqual(20);
  }));

  it('should validate value of Subtraction', inject(function() {
        var result = scope.Subtract(20, 10);
        expect(result).toEqual(10);
    }));

    it('should validate value of division', inject(function () {
        var result = scope.Division(10, 2);
        expect(result).toEqual(5);        
    }));

    it('should validate value of multiplication', inject(function () {
        var result = scope.Multiply(2, 2);
        expect(result).toEqual(4);
    }));
});
