 $(document).ready(function () {
        $("#filelogo").fileinput({
            showCaption: false,
            initialPreview: ["<img src='@StringTrimmer.QuotesRemover(ImageUrlResolver.ThumbNail(),ViewBag.Settings.LogoPath)' class='file-preview-image' style='width:100%;height:100%' alt='Desert' title='Desert'>"],
            showUpload: true,
            showRemove: false,
            allowedFileTypes: ["image"],
            allowedPreviewTypes: ["image"],
            allowedFileExtensions: ["jpg", "jpeg", "png"],
            uploadLabel: "Change Logo",
            uploadUrl: "/Api/SettingManage/ChangeLogo",
            uploadAsync: true
        });

        $('#filelogo').on('fileuploaded', function (event, data, previewId, index) {
            if(data.response!=null)
            {
                bootbox.alert(data.response, function() {
                    window.location.href = '/Setting/Index';
                });

            }
            else
            {
                bootbox.alert("Successfully updated logo");
            }
        });
    });