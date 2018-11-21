app.service("svc_user", ['$http', 'svc_root', function ($http, svc_root) {
	this.Login = function (data,callback) {
		$http.post(svc_root.root + "user",data).then(callback);
	};
}]);