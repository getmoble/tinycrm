
//$(document).ready(function () {
//    alert("hi");
//            $("#avatar").change(function () {
//                var file_data = $("#avatar").prop("files")[0];
//                var form_data = new FormData();
//                form_data.append("file", file_data)
//                form_data.append("user_id", 123)
//                $.ajax({
//                    url: "/AgentApi/UploadImageFiles",
//                    dataType: 'json',
//                    cache: false,
//                    contentType: false,
//                    processData: false,
//                    data: form_data,
//                    type: 'post',
//                    success: function (files, data, xhr) {
//                            changePic(files.Name);
//                    },

//                })
//            });
//    });
//var path = null;
//function changePic(strPath) {
//    var that = {};
//    var vm = ko.toJS(strPath);
//    var o = document.getElementById("ThumbnailImageS");
//    var imagPath = new String("/Upload/Agent/")
//    imagPath = imagPath.concat(strPath);
//    o.src = imagPath;;
//    path = ko.toJS(strPath);
//    alert(imagPath);
//    //return that;
//}