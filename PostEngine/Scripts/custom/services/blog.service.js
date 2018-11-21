app.service("svc_blog", ['$http', 'svc_root', function ($http, svc_root) {

	this.GetPublicPosts = function (callback) {
		$http.get(svc_root.root + "blog/public").then(callback);
	};

	this.GetPosts = function (id,callback) {
		$http.get(svc_root.root + "blog/" + id).then(callback);
	};

	this.GetPostsEditor = function (callback) {
		$http.get(svc_root.root + "blog").then(callback);
	};

	this.SavePost = function (data,callback) {
		$http.post(svc_root.root + "blog",data).then(callback);
	};

	this.UpdatePost = function (data, callback) {
		console.log(data);
		$http.put(svc_root.root + "blog/" + data.id, data).then(callback);
	};

	this.SaveComment = function (data, callback) {
		$http.post(svc_root.root + "blog/Comment", data).then(callback);
	};


}]);


