

function CaculateDiemTb() {
	var diemMieng = parseFloat(document.getElementById("mieng").value);
	var diemKiemTra15PhutLan1 = parseFloat(document.getElementById("diem15L1").value);
	var diemKiemTra15PhutLan2 = parseFloat(document.getElementById("diem15L2").value);
	var diemKiemTra1Tiet = parseFloat(document.getElementById("diem1tiet").value);
	var diemGk = parseFloat(document.getElementById("diemgk").value);
	var diemck = parseFloat(document.getElementById("diemck").value);

	var tongDiem = diemMieng + diemKiemTra15PhutLan1 + diemKiemTra15PhutLan2 + diemKiemTra1Tiet + (diemGk * 2) + (diemck * 3);
	var tongSoDiem = 4 + 5;

	var diemTrungBinh = tongDiem / tongSoDiem;

	document.getElementById("total").value = diemTrungBinh.toFixed(2)
}



$(document).ready(function () {
	$.urlParam = function (name) {
		var results = new RegExp('[\?&]' + name + '=([^&#]*)').exec(window.location.href);
		if (results == null) {
			return null;
		}
		return decodeURI(results[1]) || 0;
	}
	var maMonHoc = $('#maMonHoc').val();
	var maLop = $.urlParam('maLop');
	var data = []
	data.push(maMonHoc, maLop)
	console.log(data)
	$("#Lop10A1").dataTable({
		"bInfo": false,
		"responsive": false,
		"autoWidth": false,
		"ajax": {
			"type": "GET",
			"url": "/QuanLyDiem/GetListDiemHocSinhByMaLop/",
			"data": { id: maMonHoc , maLop :maLop },
		
			"contentType": "application/json",
			"datatype": "json",
			"dataSrc": function (json) {
				console.log(json.data)
				return json.data;
			},

		},
		"columnDefs": [
			{ "data": "hoten", "className": "text-center font-size-15", "orderable": false, "targets": 0 },
			{
				"data": "maHocKiNamHoc", "className": "text-center font-size-15", "orderable": false, "targets": 1,
				"render": function (data) {
					if (data == 1)
						return "<span>Học kì I năm 2024-2025</span>"
					if (data == 2)
						return "<span>Học kì II năm 2024-2025</span>"
				}
			},
			{
				"data": "maMonHoc", "className": "text-center font-size-15", "orderable": false, "targets": 2,
				"render": function (data) {
					if (data == 12)
						return "<span> Vật Lý</span>"
					if (data == 1)
						return "<span>Toán</span>"
					if (data == 2)
						return "<span>Ngữ văn</span>"
					if (data == 3)
						return "<span>Ngoại ngữ</span>"
					if (data == 4)
						return "<span>Sinh học</span>"
					if (data == 5)
						return "<span>Lịch sử</span>"
					if (data == 6)
						return "<span>Địa lý</span>"
					if (data == 7)
						return "<span>Hóa Học</span>"
					if (data == 8)
						return "<span>GDCD</span>"
					if (data == 9)
						return "<span>Công nghệ </span>"
					if (data == 10)
						return "<span>Tin Học</span>"
					if (data == 11)
						return "<span>Thể Dục</span>"
					
				}
			},
			{
				"data": "diemKiemTraMieng", "className": "text-center font-size-15", "orderable": false, "targets": 3,

			},
			{ "data": "diem15PhutLan1", "className": "text-center font-size-15", "orderable": false, "targets": 4 },
			{ "data": "diem15PhutLan2", "className": "text-center font-size-15", "orderable": false, "targets": 5 },
			{ "data": "diemKT1Tiet", "className": "text-center font-size-15", "orderable": false, "targets": 6 },
			{ "data": "diemGk", "className": "text-center font-size-15", "orderable": false, "targets": 7 },
			{ "data": "diemCk", "className": "text-center font-size-15", "orderable": false, "targets": 8 },
			{
				"data": "diemTbHk", "className": "text-center font-size-15", "orderable": false, "targets": 9,
				"render": function (data) {
					var result = data.toFixed(2)
					return `<span>${result}</span>`
				}
			},
			{
				"data": null, "className": "text-center font-size-15", "orderable": false, "targets": 10,
				"render": function () {
					return "<span class='text-primary'> <i class='fa-solid fa-pen-to-square'></i></span>"
				}
			},

		],
		language: {
			search: '<i class="fa fa-search pos-abs mt-2 ml-3 text-blue-m2"  style="position: absolute; left: 57%; top: 3%; color:#0984e3"> </i>',
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
		
		
	})
})
$(document).ready(function () {
	$("#themmoi").submit(function (e) {
		e.preventDefault();
		var formData = new FormData($(this)[0]);
		console.log(formData);
		$.ajax({
			url: "/QuanLyDiem/InsertDiemHocSinh",
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
				else {
					Swal.fire({
						title: "Lỗi  !",
						text: response.error,
						icon: "error"
					});
					console.log(response.error);
				}



			},
			error: function (xhr, status, error) {

				console.log(xhr.responseText);
			}
		})
	})
})
