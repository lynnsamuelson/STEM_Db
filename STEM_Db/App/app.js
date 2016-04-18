var app = angular.module('STEM_Db', []);

app.controller('Controller', ["$scope", "$http", function ($scope, $http) {

    $scope.test = "hello STEM PARENTs";
    $scope.testing = function () {
        console.log("testing clicked");
    }
    //$scope.createBlog = function () {
    //    console.log("create blog clicked");
    //}
    console.log("found app.js");
    $scope.createBlog = function () {
        console.log("Found Create Blog Btn");
        console.log('blogTitle', $scope.blogTitle);
        $blog = {
            "BlogTitle": $scope.blogTitle
           
        }
        console.log("blogTitle", $blog);

        $blogString = JSON.stringify($blog);
        console.log("blogstring", $blogString);

        $http.post("/api/Blog/", $blogString).then(
                function (response) {
                    $window.location.reload();
                    console.log("SUCCESS");
                },
                function (response) {
                    console.log("ERRORRRRRR");
                }
                );
    }

}]);