app.controller("toDoItemCtrl", ["$scope", "$http", function ($scope, $http) {
    $scope.toDoList = {};

    $scope.states = {
        showToDoForm: false
    };

    $scope.ver = -1;
    $scope.checkedVer = -1;
    $scope.new = { toDoItem: {} };
    $scope.update = { toDoItem: {} };
    $scope.completeItem = { toDoItem: {} };

    $scope.refresh = function() {
        $http.get("/api/ToDoItem").success(function(data, status, headers) {
            $scope.toDoList = data;
            $scope.ver = headers()['version'];
        });
    };

    $scope.refresh();

    $scope.showToDoForm = function(show) {
        $scope.update = { toDoItem: {} };
        $scope.states.showToDoForm = show;
    };

    $scope.setEdit = function(model) {
        $scope.showToDoForm(false);
        $scope.update.toDoItem.id = model.id;
        $scope.update.toDoItem.version = model.version;
        $scope.update.toDoItem.description = model.description;
    };

    $scope.clearEdit = function() {
        $scope.update = { toDoItem: {} };
    };

    $scope.isEditing = function(model) {
        return $scope.update.toDoItem.id === model.id;
    };

    $scope.addToDoItem = function () {
        $http.post("api/ToDoItem", $scope.new.toDoItem)
            .success(function(data) {
                $scope.new = { toDoItem: {} };
                $scope.states.showToDoForm = false;
            });
    };

    $scope.updateDescription = function () {
        $http.put("api/ToDoItem/Update", $scope.update.toDoItem)
            .success(function () {
                $scope.update = { toDoItem: {} };
            });
    };

    $scope.complete = function (model) {
        $http.put("api/ToDoItem/Complete", model)
            .success(function (data) {
                $scope.update = { toDoItem: {} };
            })
            .error(function(error) {
            });
    };

    $scope.checkVer = function () {
        $http.head("api/ToDoItem/Version")
            .success(function (data, status, headers) {
                $scope.checkedVer = headers()['version'];
            })
            .error(function (error) {
            });
    };

    setInterval(function () {
        $scope.checkVer();

        if (parseInt($scope.checkedVer, 10) !== parseInt($scope.ver, 10)) {
            $scope.refresh();
        }
    }, 50);
}]);