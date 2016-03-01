/// <reference path="../typings/angularjs/angular.d.ts" />
/// <reference path="../typings/jquery/jquery.d.ts" />  
/// <reference path="eligibilitymodel.ts" />

module Questions {
    export interface Scope {
        answered: boolean;
        title: string;
        options: string[];
        correctAnswer: boolean;
        working: boolean;

        nQuestion: Model.Question;

        nextQuestion: Function;
        sendAnswer: Function;
    }

    export class Controller {
        private httpService: any;

        constructor($scope: Scope, $http: any) {
            this.httpService = $http;
            
            var controller = this;

            $scope.nextQuestion = () => {
                $scope.nQuestion = new Model.Question();
                
                $http.get("/api/api/Eligibility").success((data, status, headers, config) => {
                    $scope.nQuestion.options = data.options;
                    $scope.nQuestion.title = data.title;
                    $scope.nQuestion.answered = false;
                    $scope.nQuestion.working = false;
                }).error((data, status, headers, config) => {
                    $scope.nQuestion.title = "error 1";
                    $scope.nQuestion.working = false;
                });
            }

            $scope.sendAnswer = option => {
                $scope.nQuestion = new Model.Question();

                $scope.nQuestion.working = true;
                $scope.nQuestion.answered = true;

                $http.post("/api/api/Eligibility", { 'questionId': option.questionId, 'optionId': option.id }).success(function (data, status, headers, config) {
                    $scope.nQuestion.correctAnswer = (data === true);
                    $scope.nQuestion.working = false;

                    //
                    $scope.nQuestion.options = data.options;
                    $scope.nQuestion.title = data.title;
                    $scope.nQuestion.answered = false;
                    $scope.nQuestion.working = false;
                    //

                }).error((data, status, headers, config) => {
                    $scope.nQuestion.title = "error 2";
                    $scope.nQuestion.working = false;
                });
            };
        }
        
    }
}