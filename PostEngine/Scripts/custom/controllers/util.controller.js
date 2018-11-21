app.controller("ctrl_util", ['$scope', 'svc_app', function ($scope, svc_app) {

	$scope.username = "";

	$scope.$on('loginStateChange', function () {
		if (svc_app != undefined) {						
			$scope.username = svc_app.user.name;
			$scope.isLogged = true;
		}
	});
	
	$scope.UpdateFilter = function () {
		svc_app.UpdateFilter($scope.textFilter);		
	};

	$scope.login = function () {
		$('#modalLogin').modal();
	};

}]);
