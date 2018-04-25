(function ($) {
    function Staff() {
        var $this = this;   
        var $selectedFiles = '';
        var $imgPath = '/images/staff/';    
        function uploadFunction() {
            $('.divImg').on('change', '#imgUpload', function (e) {               
                imageUpload();            
            });
            function imageUpload() {
                var formData = new FormData();
                formData.append('file', $('#imgUpload')[0].files[0]);
                var _url = '/Staff/UploadImage';
                $.ajax({
                    type: "POST",
                    url: _url,
                    contentType: false,
                    processData: false,
                    data: formData,
                    success: function (response) {
                        var $imgPaths = $imgPath + response;
                        var html = '<img class="imgPreview" src = "'+ $imgPaths+'">'
                        $('.imgPrev').html(html);
                        $('.imgPrev').show();
                        $('#imgText').hide();
                    },
                    error: function (error) {                      
                        alert('There was error uploading files.', '');
                    }
                });
            }           
        };
        $this.init = function () {           
            uploadFunction();
        };
    }
    $(function () {
        var self = new Staff();        
        self.init();
    })
}(jQuery))
