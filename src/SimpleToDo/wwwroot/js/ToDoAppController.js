app.controller("toDoItemCtrl", ["$scope", "$http", function ($scope, $http) {
    $scope.toDoList = {};

    $scope.states = {
        showToDoForm: false
    };

    $scope.new = { toDoItem: {} }

    $http.get("/api/ToDoItem").success(function(data) {
        $scope.toDoList = data;
    });

    $scope.showToDoForm = function(show) {
        $scope.states.showToDoForm = show;
    }

    $scope.addToDoItem = function () {
        $http.post("api/ToDoItem", $scope.new.toDoItem)
            .success(function(data) {
                $scope.toDoList.push(data);
            });
    };
}]);