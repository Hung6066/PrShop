﻿/// <reference path=/Assets/admin/libs/angular/angular.js" />

(function (app) {
    app.factory('apiService', apiService);

    apiService.$inject = ['$http'];
    
    function apiService($http) {
        return {
            get : get
        }
        function get(url, params, success, failed) {
            $http.get(url, params).then(function (result) {
                success(result);
            }, function (error) {
                failed(result)
            });
        }
    }

})(angular.module('prshop.common'));