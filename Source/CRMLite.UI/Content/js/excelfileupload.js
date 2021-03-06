$('#excelfileuploader').on('change', function (e) {
            var files = e.target.files;
            if (files.length > 0) {
                if (window.FormData !== undefined) {
                    var data = new FormData();
                    for (var x = 0; x < files.length; x++) {
                        data.append("file" + x, files[x]);
                    }

                    $.ajax({
                        type: "POST",
                        url: '/DataExport/UploadFile',
                        contentType: false,
                        processData: false,
                        data: data,
                        success: function (result) {
                            document.getElementById("file").value = result;
                        },
                        error: function (xhr, status, p3, p4) {
                            var err = "Error " + " " + status + " " + p3 + " " + p4;
                            if (xhr.responseText && xhr.responseText[0] === "{")
                                err = JSON.parse(xhr.responseText).Message;
                            console.log(err);
                        }
                    });
                } else {
                    bootbox.alert("This browser doesn't support HTML5 file uploads!");
                }
            }
        });