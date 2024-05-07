
		// Hiển thị
	

	//Thêm mới 
	$(document).ready(function () {
		$("#GiaoVienForm").submit(function (e) {
			e.preventDefault();
			var formData = new FormData($(this)[0]);
			console.log(formData);
			$.ajax({
				url: "InsertGiaoVien/",
				type: "POST",
				data: formData,
				contentType: false,
				processData: false,
				success: function (response) {
					console.log(response)
					if (response.success) {
						Swal.fire({
							title: "Thành công !",
							text: response.success,
							icon: "success"
						});
						setTimeout(function () {
							window.location.reload();
						}, 1500);
						console.log(response.success);
					}

					else if (response.failed == "Mã giáo viên đã tồn tại !" || response.failed == "Tên đã tồn tại trong hệ thống !") {
						Swal.fire({
							title: "Lỗi  !",
							text: response.failed,
							icon: "warning"
						});

						console.log(response.failed);
					}
					else {
						Swal.fire({
							title: "Lỗi  !",
							text: "Bạn chưa nhập đầy đủ thông tin  ",
							icon: "error"
						});

						console.log(response.failed);
					}
				},
				error: function (xhr, status, error) {

					console.log(xhr.responseText);
				}
			})
		})
	})

	//Xóa 


	
