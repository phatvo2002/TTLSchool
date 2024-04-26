const postFile = (fileData, form, type, nam, text) => {
    var token = $('input[name="__RequestVerificationToken"]', form).val();
    var headers = {};
    headers['X-XSRF-Token'] = token;
    var formData = new FormData();
    formData.append('file', fileData);
    formData.append('type', type);
    formData.append('nam', nam);
    formData.append('text', text);
    return new Promise((resolve, reject) => {
        $.ajax({
            type: "POST",
            enctype: 'multipart/form-data',
            url: "/File/Upload",
            headers: headers,
            data: formData,
            processData: false,
            contentType: false,
            cache: false,
            timeout: 600000,
            success: function (response) {
                resolve(response.fileName);
            },
            error: function (jqXHR, exception, error) {
                alert(error + ':' + jqXHR.responseText);
                reject(error + ':' + jqXHR.responseText);
            }
        });
    });
}