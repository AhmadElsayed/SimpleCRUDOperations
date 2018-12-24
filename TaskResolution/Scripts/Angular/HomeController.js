var app = angular.module("taskApp", []);

app.controller('StudentsController', function ($scope, $http) {
    $scope.title = "Test";
    $scope.selectedStudent;

    $scope.AddNewStudent = function () {
        $scope.selectedStudent = Student.getEmpty();
        $("#myModal").modal('show');
    }

    $scope.EditStudent = function (student) {
        $scope.selectedStudent = Student.clone(student);
        $("#myModal").modal('show');
    }

    $scope.UpdateStudent = function () {
        var IsAddNew = $scope.selectedStudent.id === -1 ? true : false;
        var verb = IsAddNew ? "POST" : "PUT",
            Url = "/api/Students" + (IsAddNew ? "" : ("/" + $scope.selectedStudent.id));

        $http({
            method: verb,
            url: Url,
            data: $scope.selectedStudent
        }).then(function mySuccess(response) {
            if (IsAddNew) {
                debugger;
                $scope.selectedStudent.id = response.data.id;
                $scope.students.push(Student.clone($scope.selectedStudent));
            }
            else {
                $scope.students[$scope.students.indexOf($scope.selectedStudent)] = JSON.parse(JSON.stringify($scope.selectedStudent));
            }
            $("#myModal").modal('hide');
            // success message
        }, function myError(response) {
            // failure message
        });
    }

    $scope.DeleteStudent = function (id) {
        $http({
            method: 'DELETE',
            url: '/api/Students/' + id,
            data: $scope.selectedStudent
        }).then(function mySuccess(response) {
            $scope.students = $scope.students.filter(x => x.id !== id);
            // success message
        }, function myError(response) {
            // failure message
        });
    }

    $scope.AddSubject = function () {
        if (!$scope.selectedStudent.subjects) $scope.selectedStudent.subjects = [];
        if ($scope.selectedSubject) {
            if ($scope.selectedStudent.subjects.filter(x => x.id === +JSON.parse($scope.selectedSubject).id).length == 0) {
                $scope.selectedStudent.subjects.push(JSON.parse($scope.selectedSubject));
            }
            else {
                alert("Subject already added before");
            }
        }
    }

    $scope.RemoveSubject = function (subject) {
        var index = $scope.selectedStudent.subjects.indexOf(subject);

        if (index > -1) {
            $scope.selectedStudent.subjects.splice(index, 1);
        }
    }

    $scope.checkNumber = function () {
        if ($scope.students.filter(x => +x.number == +$scope.selectedStudent.number).length !== 0)
            $scope.NumberIsNotValid = true;
        else
            $scope.NumberIsNotValid = false;
    }

    // GetSubjects
    $http.get('/api/Subjects').then(function (data) {
        $scope.subjects = data.data;
    });

    // GetStudents
    $http.get('/api/Students').then(function (data) {
        $scope.students = data.data;
    });
});