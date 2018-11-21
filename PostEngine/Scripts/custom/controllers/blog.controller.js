app.controller('ctrl_blog', ['$scope', 'svc_blog', 'svc_app', function ($scope, svc_blog, svc_app) {

	var approving = false;

	function cargarPosts() {
		if (svc_app.rol == 'editor') {
			console.log("load for editor")
			svc_blog.GetPostsEditor(function (res) {
				$scope.posts = res.data.Content;
			});
		} else {
			console.log("load for writter")
			svc_blog.GetPosts(svc_app.user.id, function (res) {
				$scope.posts = res.data.Content;
			});
		}
	}

	svc_blog.GetPublicPosts(function (res) {
		$scope.posts = res.data.Content;
	});

	$scope.$on('filterChange', function () {
		$scope.navBarFilter = svc_app.strFilter;
		console.log($scope.navBarFilter);
	});

	$scope.$on('loginStateChange', function () {
		cargarPosts();
		$scope.rol = svc_app.rol;
	});	

	$scope.showPost = function (item) {	
		if (approving) return;

		$scope.selectedPost = item;
		$scope.showModalTitle = item.title;


		$('#modalCompletePost').modal();
	};

	$scope.Activar = function (item) {
		item.ClassActivo = "active";
	};

	$scope.Desactivar = function (item) {
		item.ClassActivo = "";
	};

	$scope.Crear = function () {
		if ($scope.newTitle == undefined || $scope.newTitle == "") {
			alert("debe proveer un titulo");
		} else if (svc_app.user == undefined || svc_app.user == null) {
			$('#modalLogin').modal();
		} else {
			$('#modalNewPost').modal();
		}
	}

	$scope.savePost = function () {
		var data = {
			title: $scope.newTitle,
			text: $scope.PostText,
			is_public: $scope.is_public,
			user_id: svc_app.user.id
		}		

		svc_blog.SavePost(data, function (res) {
			if (res.data.ResponseType == 1) {
				alert("no pudo guardarse el post");
			} else {
				$('#modalNewPost').modal('hide');
				cargarPosts();
				alert("Post saved successfully");
			}
		});
	}

	$scope.Approve = function (item) {
		approving = true;

		svc_blog.UpdatePost(item, function (res) {
			if (res.data.ResponseType == 1) {
				alert("no pudo aprovarse el post");
			} else {				
				cargarPosts();
				alert("Post update successfully");
			}
		});


	}

	$scope.AddComment = function () {
		var data = $scope.new_comment;
		data.post_id = $scope.selectedPost.id;

		svc_blog.SaveComment(data, function (res) {
			if (res.data.ResponseType == 1) {
				alert("no pudo agregarse el commentario");
			} else {
				$('#modalCompletePost').modal('hide');
				cargarPosts();
				alert("Comment submit successfully");
			}

			$scope.new_comment = {};
		});		
	}
}]);