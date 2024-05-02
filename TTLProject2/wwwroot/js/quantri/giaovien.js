
		// Hiển thị
	$(document).ready(function () {
		$('#giaovientable').dataTable({
			"bInfo": false,
			"responsive": false,
			"autoWidth": false,
			"ajax": {
				"type": "GET",
				"url": "GetGiaoVienList/",
				"contentType": "application/json",
				"datatype": "json",
				"dataSrc": function (json) {
					console.log(json.data)
					return json.data;
				},

			},
			"columnDefs": [
				{
					"data": "maGiaoVien", "className": "text-center font-size-15", "orderable": false, targets :0,
					"render": function (data, type, row, meta) {
						return `<a style="font-family:'Times New Roman';text-decoration:none;"  href="">${data}</a>`;
					}
				},
				{
					"data": "hoTen", "className": "text-center font-size-15", "orderable": false, targets: 1,
					"render": function (data, type, row, meta) {
						return `<a style="font-family:'Times New Roman';text-decoration:none;" href="" >${data}</a>`;
					}
				},
				{
					"data": "ngaySinh", "className": "text-center font-size-15", targets: 2, "orderable": false,  "render": function (data, type, row) {

						if (type === "display") {

							var ngay = new Date(data);
							return ngay.getDate() + '/' + (ngay.getMonth() + 1) + '/' + ngay.getFullYear();
						}

						return data;
					}
				},
				{ "data": "dienThoai", "className": "text-center font-size-15", "orderable": false , targets: 3 },
				{ "data": "email", "className": "text-center font-size-15", "orderable": false, targets: 4},
				{
					"data": "maMonHoc", "className": "text-center font-size-15", "orderable": false,
					targets: 5,
					"render": function (data) {
						if (data == 1)
							return "<span>Toán</span>"
						if (data == 2)
							return "<span>Ngữ văn</span>"
						if (data == 3)
							return "<span>Ngoại Ngữ</span>"
						if (data == 4)
							return "<span>Sinh Học</span>"
						if (data == 5)
							return "<span>Lịch Sử</span>"
						if (data == 6)
							return "<span>Địa Lý</span>"
						if (data == 7)
							return "<span>Hóa Học</span>"
						if (data == 8)
							return "<span>GDCD</span>"
						if (data == 9)
							return "<span>Công Nghệ</span>"
						if (data == 10)
							return "<span>Tin Học</span>"
						if (data == 11)
							return "<span>Thể Dục</span>"

					}
				},
				{

					"data": "maTrangThai", "className": "text-center font-size-15", "orderable": false,
					targets: 6,
					"render": function (data) {
						if (data == 6)
							return "<span class='badge rounded-pill bg-success'  >Đang Dạy</span>";
						if (data == 7)
							return "<span class='adge rounded-pill bg-warning text-dark' >Nghỉ thai sản</span>";
						if (data == 8)
							return "<span class='badge rounded-pill bg-danger'  >Đang Dạy</span>";
						if (data == 1)
							return "<span class='badge rounded-pill bg-success'  >Đang Học</span>";
					}
				},
				{
					
					"data": "maGiaoVien",
					"targets": 7,
					"render": function (data) {
						return "<input type='checkbox'  value=" + data + " class='myCheckbox' id='myCheckbox' />"
					}
				}
			],
			language: {
				search: '<i class="fa fa-search pos-abs mt-2 ml-3 text-blue-m2"  style="position: absolute; left: 56%; top: 2%; color:#0984e3"> </i>',
				searchPlaceholder: " Tra cứu ...",
				emptyTable: "Dữ liệu hiện tại chưa có...",
				zeroRecords: "Không tìm thấy dữ liệu...",

				loadingRecords: "<img src='/asset/images/loadingdata.gif' style='width: 40px; height: 40px;'/>",
				paginate: {
					"first": "First",
					"last": "Last",
					"next": "Tiếp theo",
					"previous": "Quay lại"
				}
			},
			oLanguage: {
				"sLengthMenu": "Hiển thị  _MENU_ mẫu tin",
				"sZeroRecords": "Nothing found - sorry",
				"sInfo": "Hiển thị  _START_ đến _END_ của _TOTAL_ mẫu tin",
				"sInfoEmpty": "",
				"sInfoFiltered": "(filtered from _MAX_ total records)"
			},
			select: {
				rows: {
					_: '(đã chọn %d dòng)',
					0: '',
					1: '(đã chọn 1 dòng)'
				}
			},
			select: {
				style: 'multis'
			},
			order: [],//no specific initial ordering,
		
		})
	})

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
	$(document).ready(function () {

		$('#delete-btn').click(function (e) {

			var listData = "";
			$('.myCheckbox:checked').each(function () {
				var data = $(this).val();
				console.log("Giá trị của data khi click vào checkbox: " + data);
				listData = data;
			});
			//var dataNumbers = listData.map(function (str) {
			//    return parseInt(str);
			//});
			console.log(listData)

			if (listData === "") {
				toastr.warning('bạn chưa chọn dữ liệu');
			} else {
				$.ajax({
					type: "POST",
					url: "DeleteGv/" + listData,
					success: function (response) {
						console.log(response)
						if (response.success) {
							Swal.fire({
								title: "Thành công !",
								text: response.success,
								icon: "success"
							});
							
						} else {
							Swal.fire({
								title: "Lỗi",
								text: response.failed,
								icon: "error"
							});
						}
					}
				});
				
			}


		});

	function Delete(ids) {
		Swal.fire({
			title: "Bạn có muốn xóa không ?",
			text: "",
			icon: "warning",
			showCancelButton: true,
			confirmButtonColor: "#3085d6",
			cancelButtonColor: "#d33",
			confirmButtonText: "Có "
		}).then((result) => {
			if (result.isConfirmed) {
				var requests = ids.map(function (id) {
					console.log(id)
					return $.ajax({
						type: "POST",
						url: "https://localhost:44395/QuanLy/DeleteGv/" + id,

					});
				});
				$.when.apply($, requests).done(function () {
					var responses = arguments;
					if (responses.success == true) {
						Swal.fire({
							title: "Xóa !",
							text: "Dữ liệu của bạn đã xóa thành công .",
							icon: "success"
						});
						setTimeout(function () {
							window.location.reload();
						}, 1500);
					}


				});
			}
		});
			}
		})
