
(function (app) {
    app.filter('statusFilter', function () {
        return function (intput) {
            if (intput)
                return 'Kích hoạt';
            else
                return 'Khóa';
        }
    });
})(angular.module('prshop.common'));