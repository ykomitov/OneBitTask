(function () {
    'use strict';

    function config($routeProvider) {
        var CONTROLLER_AS_VIEW_MODEL = 'vm';

        $routeProvider
             .when('/', {
                 templateUrl: 'views/partials/home/home.html',
                 controller: 'HomeController',
                 controllerAs: CONTROLLER_AS_VIEW_MODEL
             })
             .when('/create', {
                 templateUrl: 'views/partials/contacts/create.html',
                 controller: 'CreateContactController',
                 controllerAs: CONTROLLER_AS_VIEW_MODEL
             })
            .otherwise({ redirectTo: '/' });
    }

    angular.module('myApp.services', []);
    angular.module('myApp.controllers', ['myApp.services']);
    angular.module('myApp', ['ngRoute', 'myApp.controllers']).
        config(['$routeProvider', config])
        .value('toastr', toastr)
        .constant('baseServiceUrl', 'http://localhost:53249');
}());