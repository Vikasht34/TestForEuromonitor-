app.service("costEstimationService", function ($http, $scope) {
    this.distance = "";
    this.custType = "";
    this.stair = "";
    this.getCost = function () {

        var path = "http://localhost:56038/api/" + "GetCostEstimation";
        return $http.get(path, { params: { distance: this.distance, stair: this.custType, custType: this.stair} });
    }
});  