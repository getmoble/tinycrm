    function ThumbNail(thumbNail) {
        $("#filelogo").fileinput({
            showCaption: false,
            initialPreview: ["<img src='thumbNail' class='file-preview-image' style='width:100%;height:100%' alt='Desert' title='Desert'>"],
            showUpload: true,
            showRemove: false,
            allowedFileTypes: ["image"],
            allowedPreviewTypes: ["image"],
            allowedFileExtensions: ["jpg", "jpeg", "png"],
            uploadLabel: "Change Logo",
            uploadUrl: "/Api/SettingsApi/ChangeLogo",
            uploadAsync: true
        });

        $('#filelogo').on('fileuploaded', function(event, data, previewId, index) {
            if (data.response != null) {
                bootbox.alert(data.response, function() {
                    window.location.href = '/Settings/Index';
                });

            } else {
                bootbox.alert("Successfully updated logo");
            }
        });
    }