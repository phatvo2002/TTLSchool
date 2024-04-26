
function getData(url, data) {
    return new Promise((resolve, reject) => {
        $.ajax({
            url,
            type: 'GET',
            data,
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                resolve(response);
            },
            error: function (jqXHR, exception, error) {
                reject(error + ': ' + jqXHR.responseText);
            }
        });
    });
}

function showPopup(url) {
    $.get(url).done(function (data) {
        placeholderElement.html(data);
        placeholderElement.find('.modal').modal(options);
    });
}

function createHeader(form) {
    let token = $('input[name="__RequestVerificationToken"]', form).val();
    let headers = {};
    headers['X-XSRF-Token'] = token;
    return headers;
}

function postData(url, data, headers, contentType = 'application/x-www-form-urlencoded; charset=UTF-8') {
    return new Promise((resolve, reject) => {
        $.ajax({
            url,
            type: 'POST',
            headers,
            data,
            contentType,
            success: function (response) {
                resolve(response);
            },
            error: function (jqXHR, exception, error) {
                toastr.error(error + ': ' + jqXHR.responseText);
                reject(error + ': ' + jqXHR.responseText);
            }
        });
    });
}

function sweetAlert(contentValue, content = 'text') {
    return new Promise((resolve, reject) => {
        Swal.fire({
            [content]: contentValue,
            icon: 'question',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Có',
            cancelButtonText: 'Không'
        }).then((result) => {
            resolve(result.value);
        });
    });
}

function submitAddEdit(form) {
    $.validator.unobtrusive.parse(form);
    if ($(form).valid()) {
        let headers = createHeader(form);
        var model = $(form).serializeJSON();
        postData(app.Urls.addEditUrl, JSON.stringify(model), headers, 'application/json; charset=utf-8')
            .then((response) => {
                if (response.success) {
                    placeholderElement.find('.modal').modal('hide');
                    toastr.success(response.message);
                    dataTable.ajax.reload();
                }
                else {
                    toastr.error(response.message);
                }
            }).catch(err => console.log(err));
    }
    return false;
}

async function swalDeleteConfirmed(id) {
    $.ajax({
        type: 'GET',
        url: app.Urls.deleteUrl,
        data: { id: id },
        contentType: 'application/json; charset=utf-8',
        success: async function (response) {
            let result = await sweetAlert(response, 'html');
            if (result) {
                var form = $('#delete');                
                let headers = createHeader(form);
                let deleted = await postData(app.Urls.deleteConfirmedUrl, { id }, headers)
                if (deleted.success) {
                    toastr.success(deleted.message);
                    dataTable.ajax.reload();

                }
                else {
                    toastr.error(deleted.message);
                }
            }
        },
        error: function (jqXHR, exception, error) {
            toastr.error(error + ': ' + jqXHR.responseText);
        }
    });
}