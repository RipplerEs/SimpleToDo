app.controller("toDoItemCtrl", ["$scope", "$http", function ($scope, $http) {
    $scope.toDoList = {};

    $scope.states = {
        showToDoForm: false,
    };

    $scope.new = { toDoItem: {} };
    $scope.update = { toDoItem: {} };


    $http.get("/api/ToDoItem").success(function(data) {
        $scope.toDoList = data;
    });

    $scope.showToDoForm = function(show) {
        $scope.update = { toDoItem: {} };
        $scope.states.showToDoForm = show;
    }

    $scope.setEdit = function(model) {
        $scope.showToDoForm(false);
        $scope.update.toDoItem.id = model.id;
        $scope.update.toDoItem.version = model.version;
        $scope.update.toDoItem.description = model.description;
    }

    $scope.clearEdit = function() {
        $scope.update = { toDoItem: {} };
    }

    $scope.isEditing = function (model) {
        return $scope.update.toDoItem.id === model.id;
    }

    $scope.addToDoItem = function () {
        $http.post("api/ToDoItem", $scope.new.toDoItem)
            .success(function(data) {
                $scope.new = { toDoItem: {} }
                $scope.states.showToDoForm = false;
            });
    };

    $scope.updateDescription = function () {
        $http.put("api/ToDoItem", $scope.update.toDoItem)
            .success(function () {
                $scope.update = { toDoItem: {} }
            });
    };

    $scope.complete = function () {
        $http.put("api/ToDoItem/Complete", $scope.completeItem)
            .success(function (data) {
                $scope.update = { toDoItem: {} }
            });
    };
}]);