$(document).ready(function () {



    $.urlParam = function (name) {
        var results = new RegExp('[\?&]' + name + '=([^&#]*)').exec(window.location.href);
        if (results == null) {
            return null;
        }
        return decodeURI(results[1]) || 0;
    }

    var maHocSinh = $.urlParam('MaHocSinh');
    var DiemTb = 0;

    var Hocluc = $('#Hocluc')
    var result = 0;
    var DiemToan = 0;
    $.ajax({
        type: "GET",
        url: "/QuanLyThongTinHocSinh/GetListDiemHocSinh/",
        data: { MaHocSinh: maHocSinh },
        contentType: "application/json",
        datatype: "json",
        dataSrc: function (json) {
            console.log("API Response:", json);
            return json.data;
        },
        success: function (data) {

            console.log("Student Grades:", data);
            for (var i = 0; i < data.data.length; i++) {
                DiemTb = (DiemTb + data.data[i].diemTbHk)
                if (data.data[i].tenMonHoc == 'Toán') {
                    DiemToan = data.data[i].diemTbHk

                }
                if (data.data[i].tenMonHoc == 'Ngữ văn') {
                    var diemNguVan = data.data[i].diemTbHk
                }
                if (data.data[i].tenMonHoc == 'Ngoại Ngữ') {
                    var diemNgoaiNgu = data.data[i].diemTbHk
                }
                if (data.data[i].tenMonHoc == 'Sinh Học') {
                    var diemSinhHoc = data.data[i].diemTbHk
                }
                if (data.data[i].tenMonHoc == 'Lịch Sử') {
                    var diemLichSu = data.data[i].diemTbHk
                }
                if (data.data[i].tenMonHoc == 'Địa Lý') {
                    var diemDiaLy = data.data[i].diemTbHk
                }
                if (data.data[i].tenMonHoc == 'Hóa Học') {
                    var diemHoaHoc = data.data[i].diemTbHk
                }
                if (data.data[i].tenMonHoc == 'GDCD') {
                    var diemGdcd = data.data[i].diemTbHk
                }
                if (data.data[i].tenMonHoc == 'Vật Lý') {
                    var diemVl = data.data[i].diemTbHk
                }


            }
            result = DiemTb / 9
            console.log(diemNguVan)

            if ((DiemToan >= 8.0 || diemNguVan >= 8.0) && diemNgoaiNgu >= 6.5 && diemSinhHoc >= 6.5 && diemLichSu
                >= 6.5 && diemDiaLy >= 6.5 && diemHoaHoc >= 6.5 && diemGdcd >= 6.5 && diemVl >= 6.5 && diemNguVan >= 6.5) {
                var xepLoai = $('#Hocluc').html("Xếp loại học lực học kì : <b class='text-danger'>Giỏi</b>")
            }
            else if ((DiemToan >= 6.5 || diemNguVan >= 6.5) && diemNgoaiNgu >= 5.0 && diemSinhHoc >= 5.0 && diemLichSu
                >= 5.0 && diemDiaLy >= 5.0 && diemHoaHoc >= 5.0 && diemGdcd >= 5.0 && diemVl >= 5.0 && diemNguVan >= 5.0) {
                var xepLoai = $('#Hocluc').html("Xếp loại học lực học kì : <b class='text-danger'>Khá</b>")
            }
            else if ((DiemToan >= 5.0 || diemNguVan >= 5.0) && diemNgoaiNgu >= 3.5 && diemSinhHoc >= 3.5 && diemLichSu
                >= 3.5 && diemDiaLy >= 3.5 && diemHoaHoc >= 3.5 && diemGdcd >= 3.5 && diemVl >= 3.5 && diemNguVan >= 3.5) {
                var xepLoai = $('#Hocluc').html("Xếp loại học lực học kì : <b class='text-danger'>Trung Bình</b>")
            }
            else if ((DiemToan >= 3.5 || diemNguVan >= 3.5) && diemNgoaiNgu >= 2.0 && diemSinhHoc >= 2.0 && diemLichSu
                >= 2.0 & diemDiaLy >= 2.0 && diemHoaHoc >= 2.0 && diemGdcd >= 2.0 && diemVl >= 2.0 && diemNguVan >= 2.0) {
                var xepLoai = $('#Hocluc').html("Xếp loại học lực học kì : <b class='text-danger'>Yếu</b>")
            }
            else {
                var xepLoai = $('#Hocluc').html("Xếp loại học lực học kì : <b>Kém</b>")
            }

            var diemtb = $('#DiemTb').html("Điểm trung bình học kì : <b  class='text-danger'>" + result.toFixed(2) + "</b>")

            return result
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.error("API Error:", textStatus, errorThrown);
        }
    });



    $("#DiemThi").dataTable({
        "bInfo": false,
        "responsive": false,
        "autoWidth": false,
        "ajax": {
            "type": "GET",
            "url": "/QuanLyThongTinHocSinh/GetListDiemHocSinh/",
            "data": { MaHocSinh: maHocSinh },

            "contentType": "application/json",
            "datatype": "json",
            "dataSrc": function (json) {

                for (var i = 0; i < json.data.length; i++) {
                    DiemTb = (DiemTb + json.data[i].diemTbHk)

                }

                return json.data;
            },

        },
        "columnDefs": [
            {
                "data": null, "orderable": false, "className": "text-center font-size-15", "targets": 0, "render": function (data, type, row, meta) {
                    return meta.row + 1;
                }
            },
            { "data": "tenMonHoc", "className": "text-center font-size-15", "orderable": false, "targets": 1 },
            {
                "data": null, "className": "text-center font-size-15", "orderable": false, "targets": 2,
                "render": function (data, type, row, meta) {
                    if (row.maHocKiNamHoc === "1") {

                        return "<p>" + row.diemKiemTraMieng.toFixed(2) + "</p>"
                    }
                }
            },
            {
                "data": null, "className": "text-center font-size-15", "orderable": false, "targets": 3,
                "render": function (data, type, row, meta) {
                    if (row.maHocKiNamHoc === "1") {
                        return "<p>" + row.diem15PhutLan1.toFixed(2) + "</p>"
                    }
                }
            },
            {
                "data": null, "className": "text-center font-size-15", "orderable": false, "targets": 4,
                "render": function (data, type, row, meta) {
                    if (row.maHocKiNamHoc === "1") {
                        return "<p>" + row.diem15PhutLan2.toFixed(2) + "</p>"
                    }
                }
            },
            {
                "data": null, "className": "text-center font-size-15", "orderable": false, "targets": 5,
                "render": function (data, type, row, meta) {
                    if (row.maHocKiNamHoc === "1") {
                        return "<p>" + row.diemKT1Tiet.toFixed(2) + "</p>"
                    }
                }
            },
            {
                "data": null, "className": "text-center font-size-15", "orderable": false, "targets": 6,
                "render": function (data, type, row, meta) {
                    if (row.maHocKiNamHoc === "1") {
                        return "<p>" + row.diemGk.toFixed(2) + "</p>"
                    }
                }
            },
            {
                "data": null, "className": "text-center font-size-15", "orderable": false, "targets": 7,
                "render": function (data, type, row, meta) {
                    if (row.maHocKiNamHoc === "1") {
                        return "<p>" + row.diemCk.toFixed(2) + "</p>"
                    }
                }
            },
            {
                "data": null, "className": "text-center font-size-15", "orderable": false, "targets": 8,
                "render": function (data, type, row, meta) {
                    if (row.maHocKiNamHoc === "1") {
                        return "<p>" + row.diemTbHk + "</p>"
                    }
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
        searching: false,
        paginate: false,
        layout: {
            topStart: {
                buttons: [

                    {
                        extend: 'print',
                        text: 'In bảng Điểm',
                        messageTop:
                            'Bảng điểm Học kì 1 năm học 2024 -2025',
                        title: 'Trường THPT Thạnh Lộc  ',

                        messageBottom: null
                    }
                ]
            }
        }



    })





})