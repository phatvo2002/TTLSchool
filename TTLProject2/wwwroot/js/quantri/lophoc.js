
$(document).ready(function () {
    $('#lophoctables').dataTable({
        "bInfo": false,
        "responsive": false,
        "autoWidth": false,
        "ajax": {
            "type": "GET",
            "url": "getAllLopHoc/",
            "contentType": "application/json",
            "datatype": "json",
            "dataSrc": function (json) {
                console.log(json.data)
                return json.data;
            },

        },
        "columnDefs": [
            { "data": "maLop", "className": "text-center font-size-15", "orderable": false, "targets": 0 },
            { "data": "tenLop", "className": "text-center font-size-15", "orderable": false, "targets": 1 },
            { "data": "siSo", "className": "text-center font-size-15", "orderable": false, "targets": 2 },
            { "data": "hocNgoaiNgu", "className": "text-center font-size-15", "orderable": false, "targets": 3 },
            { "data": "tenNienKhoa", "className": "text-center font-size-15", "orderable": false, "targets": 4 },
            { "data": "hoTen", "className": "text-center font-size-15", "orderable": false, "targets": 5 },
            {
                "targets": 6,
                "data": "maLop",
                "render": function (data) {
                    return "<input type='checkbox'  value=" + data + " class='myCheckbox text-center' id='myCheckbox' />"
                }
            }
        ],
        language: {
            search: '<i class="fa fa-search pos-abs mt-2 ml-3 text-blue-m2"  style="position: absolute; left: 56%; top: 3%; color:#0984e3"> </i>',
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

//insert 


//delete
$(document).ready(function () {
    $('#delete-btn').click(function () {

        var listData = [];
        $('.myCheckbox:checked').each(function () {
            var data = $(this).val();
            console.log("Giá trị của data khi click vào checkbox: " + data);
            listData.push(data);
        });
        //var dataNumbers = listData.map(function (str) {
        //    return parseInt(str);
        //});
        console.log(listData)

        if (listData.length === 0) {
            toastr.warning('bạn chưa chọn dữ liệu');
        } else {

            Delete(listData);
            // }
        }

    });


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
                    url: 'QuanLy/DeleteLop/' + id

                });
            });
            $.when.apply($, requests).done(function () {
                var responses = arguments;
                if (responses.length === 1) {
                    Swal.fire({
                        title: "Xóa !",
                        text: "Dữ liệu của bạn đã xóa thành công .",
                        icon: "success"
                    });
                    setTimeout(function () {
                        window.location.reload();
                    }, 1500);
                } else {
                    for (var i = 0; i < responses.length; i++) {
                        var data = responses[i][0];
                        if (data.success) {
                            Swal.fire({
                                title: "Xóa !",
                                text: "Dữ liệu của bạn đã xóa thành công .",
                                icon: "success"
                            });
                            setTimeout(function () {
                                window.location.reload();
                            }, 1500);
                        } else {
                            alert("error");
                        }
                    }
                }

            });
        }
    });
}