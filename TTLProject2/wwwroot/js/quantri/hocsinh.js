
$(document).ready(function () {

	$('#hocsinhtable').dataTable({
		"bInfo": false,
		"responsive": false,
		"autoWidth": false,
		"ajax": {
			"type": "GET",
			"url": "GetListHocSinh/",
			"contentType": "application/json",
			"datatype": "json",
			"dataSrc": function (json) {
				console.log(json.data)
				return json.data;
			},

		},
		"columnDefs": [
			{ "data": "maHocSinh", "className": "text-center font-size-15", "orderable": false, "targets": 0 },
			{ "data": "hoTen", "className": "text-center font-size-15", "orderable": false, "targets": 1 },
			{
				"data": "ngaySinh", "className": "text-center font-size-15", "orderable": false, "targets": 2,
				"render": function (data, type, row, meta) {
					if (data)
						return moment(data).format('DD/MM/YYYY');
					return '';
				}
			},
			{ "data": "soDienThoai", "className": "text-center font-size-15", "orderable": false, "targets": 3 },
			{ "data": "maLop", "className": "text-center font-size-15", "orderable": false, "targets": 4 },
			{ "data": "diaChiNha", "className": "text-center font-size-15", "orderable": false, "targets": 5 },
			
			{
				"targets": 7,
				"data": "maHocSinh",
				"orderable": false,
				"render": function (data) {
					return "<input type='checkbox'  value=" + data + " class='myCheckbox text-center' id='myCheckbox' />"
				}
			}
		],
		language: {
			search: '<i class="fa fa-search pos-abs mt-2 ml-3 text-blue-m2"  style="position: absolute; left: 58%; top: 5%; color:#0984e3"> </i>',
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



