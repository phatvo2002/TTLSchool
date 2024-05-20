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
				"data": "maGiaoVien", "className": "text-center font-size-15", "orderable": false, targets: 0,
				"render": function (data, type, row, meta) {
					return `<a style="font-family:'Times New Roman';text-decoration:none;"  href="">${data}</a>`;
				}
			},

			{
				"data": "hoTen", "className": "text-center font-size-15", "orderable": false, "targets": 1,
				"render": function (data, type, row, meta) {
					return `<a style="font-family:'Times New Roman';text-decoration:none;" href="/ChinhSuaThongTin/ThongTinGiaoVien/${row.maGiaoVien}" >${data}</a>`;
				}
			},
			{
				"data": "ngaySinh", "className": "text-center font-size-15", targets: 2, "orderable": false, "render": function (data, type, row) {

					if (type === "display") {

						var ngay = new Date(data);
						return ngay.getDate() + '/' + (ngay.getMonth() + 1) + '/' + ngay.getFullYear();
					}

					return data;
				}
			},
			{ "data": "dienThoai", "className": "text-center font-size-15", "orderable": false, targets: 3 },
			{ "data": "email", "className": "text-center font-size-15", "orderable": false, targets: 4 },
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
				"className": "text-center font-size-35",
				"orderable": false,
				"render": function (data) {
					return "<span class='text-center fs-3' style='height:40px' id='xoaGiaoVien' onclick='deleteGv(\"" + data + "\")'><i class='fa-solid fa-trash text-danger'></i></span>"
				}
			}
		],
		searching: false,
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
			style: 'multis'
		},
		order: [],//no specific initial ordering,

	})
})

function deleteGv(data) {
	console.log("Deleting teacher with ID:", data);
	Swal.fire({
		title: "Bạn có chắc là muốn xóa giáo viên này?",

		icon: "info",
		showCancelButton: true,
		confirmButtonColor: "#3085d6",
		cancelButtonColor: "#d33",
		confirmButtonText: "có"
	}).then((result) => {
		if (result.isConfirmed) {
			$.ajax({
				type: "POST",
				url: "/QuanLy/DeleteGv/",
				data: { maGiaoVien: data },
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
					} else {
						Swal.fire({
							title: "Lỗi",
							text: response.failed,
							icon: "error"
						});
					}
				}
			})
		}
	});

}

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