/// <reference path="../typings/angularjs/angular.d.ts" />
/// <reference path="../typings/jquery/jquery.d.ts" />  
/// <reference path="eligibilitymodel.ts" />
var Questions;
(function (Questions) {
    var Controller = (function () {
        function Controller($scope, $http) {
            this.httpService = $http;
            var controller = this;
            $scope.nextQuestion = function () {
                $scope.nQuestion = new Model.Question();
                $http.get("/api/Eligibility").success(function (data, status, headers, config) {
                    $scope.nQuestion.options = data.options;
                    $scope.nQuestion.title = data.title;
                    $scope.nQuestion.answered = false;
                    $scope.nQuestion.working = false;
                }).error(function (data, status, headers, config) {
                    $scope.nQuestion.title = "error 1";
                    $scope.nQuestion.working = false;
                });
            };
            $scope.sendAnswer = function (option) {
                $scope.nQuestion = new Model.Question();
                $scope.nQuestion.working = true;
                $scope.nQuestion.answered = true;
                $http.post("/api/Eligibility", { 'questionId': option.questionId, 'optionId': option.id }).success(function (data, status, headers, config) {
                    $scope.nQuestion.correctAnswer = (data === true);
                    $scope.nQuestion.working = false;
                    //
                    $scope.nQuestion.options = data.options;
                    $scope.nQuestion.title = data.title;
                    $scope.nQuestion.answered = false;
                    $scope.nQuestion.working = false;
                    //
                }).error(function (data, status, headers, config) {
                    $scope.nQuestion.title = "error 2";
                    $scope.nQuestion.working = false;
                });
            };
        }
        return Controller;
    })();
    Questions.Controller = Controller;
})(Questions || (Questions = {}));
//# sourceMappingURL=eligibilityController.js.map