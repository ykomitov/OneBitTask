(function () {
    'use strict';

    function data($http, $q, $route, $location, notifier, baseServiceUrl) {

        function get(url, queryParams) {
            var deferred = $q.defer();

            $http.get(baseServiceUrl + '/' + url, { params: queryParams })
                 .then(function (response) {
                     deferred.resolve(response.data);
                 }, function (err) {
                     err = getErrorMessage(err);
                     notifier.error(err);
                     deferred.reject(err);
                 });

            return deferred.promise;
        }

        function post(url, postData) {
            var deferred = $q.defer();

            $http.post(baseServiceUrl + '/' + url, postData)
                 .then(function (response) {
                     deferred.resolve(response.data);
                     $location.path('/');
                 }, function (err) {
                     err = getErrorMessage(err);
                     notifier.error(err);
                     deferred.reject(err);
                 });

            return deferred.promise;
        }

        function put(url, updatedContact) {
            var deferred = $q.defer();

            if (!updatedContact) {
                $http.put(baseServiceUrl + '/' + url)
                .then(function (response) {
                    deferred.resolve(response);
                    $route.reload();
                }, function (err) {
                    err = getErrorMessage(err);
                    notifier.error(err);
                    deferred.reject(err);
                });
            } else {
                $http.put(baseServiceUrl + '/' + url, updatedContact)
                .then(function (response) {
                    deferred.resolve(response.data);
                    $route.reload();
                }, function (err) {
                    err = getErrorMessage(err);
                    notifier.error(err);
                    deferred.reject(err);
                });
            }

            return deferred.promise;
        }

        function deleteContact(url) {
            var deferred = $q.defer();

            $http.delete(baseServiceUrl + '/' + url)
                 .then(function (response) {
                     deferred.resolve(response.data);
                     $route.reload();
                 }, function (err) {
                     err = getErrorMessage(err);
                     notifier.error(err);
                     deferred.reject(err);
                 });

            return deferred.promise;
        }

        function getErrorMessage(response) {

            var error = response.data.ModelState;

            if (error && error[Object.keys(error)[0]][0]) {
                error = error[Object.keys(error)[0]][0];
            }
            else {
                error = response.data.message;
            }

            return error;
        }

        return {
            get: get,
            post: post,
            put: put,
            deleteContact: deleteContact
        }
    }

    angular.module('myApp.services')
           .factory('data', ['$http', '$q', '$route', '$location', 'notifier', 'baseServiceUrl', data]);

}());