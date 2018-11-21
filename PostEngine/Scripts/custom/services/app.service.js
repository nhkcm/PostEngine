app.service("svc_app", ['$http', '$rootScope', function ($http, $rootScope) {
	var that = this;
	this.UpdateFilter = function (strFilter) {
		that.strFilter = strFilter;
		$rootScope.$broadcast("filterChange");		
	};
  }]);  