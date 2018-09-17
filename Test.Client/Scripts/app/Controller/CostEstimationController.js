app.controller('costEstimationController', function ($scope, costEstimationService) {
    $scope.formData = {};
    $scope.GetCost = function() {
        getAll();
    }

    function getAll() {
        costEstimationService.distance = $scope.formData.distance;
        costEstimationService.stair = $scope.formData.stair;
        costEstimationService.custType = $scope.formData.custType;
        var servCall = costEstimationService.getSubs();

        servCall.then(function(d) {
            $scope.formData.cost = d.data;
            },
            function(error) {
                $log.error('Oops! Something went wrong while fetching the data.');
            });
    }
})   
