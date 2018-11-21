app.controller("ctrl_user", ['$scope', 'svc_app', 'svc_user', '$rootScope', function ($scope, svc_app, svc_user, $rootScope) {
	$scope.login = function () {

		var data = {
			username: $scope.username,
			password: $scope.password
		}

		svc_user.Login(data, function (res) {
			if (res.data.ResponseType == 1) {
				alert("username or password incorrect!");
			} else {
				svc_app.user = res.data.Content;
				svc_app.isLogin = true;
				svc_app.rol = res.data.Content.rol;
				$('#modalLogin').modal('hide');
				$rootScope.$broadcast('loginStateChange');
			}
		});		

	};
}]);