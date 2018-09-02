//\Assets\admin\libs\angular\angular.js


(function (app) {
    app.controller('productAddController', productAddController);

    productAddController.$inject = ['apiService', '$scope', 'notificationService', '$state'];


    function productAddController(apiService, $scope, notificationService, $state) {
        $scope.productCategory = {
            CreatedDate: new Date(),
            Status: true
        }

       
        $scope.AddProduct = AddProduct;
        $scope.ckeditorOptions = {
            language: 'vi',
            height:"200px",
            
        }

        function AddProduct() {
            apiService.post('api/products/create', $scope.productCategory, function (result) {
                notificationService.displaySuccess(result.data.Name + ' đã được thêm mới')
                $state.go('product_categories');
            }, function (error) {
                notificationService.displayError('Thêm mới không thành công.');

            });
        }


        function loadProductCategory() {
            apiService.get('/api/productcategory/getallparents', null, function (result) {
                $scope.productCategories = result.data;
            }, function () {
                console.log('Cannot get list parent');
            })

        }
        $scope.ChooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.product.Image = fileUrl;
            }
            finder.popup();
        }
        loadProductCategory();

    }


})(angular.module('prshop.product_categories'))