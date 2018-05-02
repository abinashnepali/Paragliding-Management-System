(function ($) {
    function Book() {
        var $this = this;  
        var $bookingDv = $('#bookingDv');
        var config = {
            isPostBack: false,
            async: false,
            cache: false,
            type: 'POST',
            contentType: "application/json; charset=utf-8",
            data: { data: '' },
            dataType: 'json',
            method: "",
            successMethod: "",
            errorMethod: "",
            headers: "",
        };
        function ajaxCall(config) {
            $.ajax({
                type: config.type,
                contentType: config.contentType,
                cache: config.cache,
                url: config.method,
                data: config.data,
                dataType: config.dataType,
                success: config.successMethod,
                error: config.errorMethod,
                async: config.async,
                headers: config.headers,
            });
        };
        function ajaxFailure(error, validator) {
            try {
                var errorMessage = JSON.parse(error.responseText);
                if (errorMessage.ModelState) {
                    messageDisplay(errorMessage.ModelState, 'error');
                } else {
                    validator.showErrors(errorMessage);
                    $('label[class=error]').addClass('text-danger');
                }
            } catch (e) {
                console.log(e.message);
            }
        };
        function AddBooking() {
            $bookingDv.off().on('click', '#createBooking', function () {
                try {
                    config.type = "GET";
                    config.dataType = "";
                    config.method = "/Booking/AddBooking";
                    config.successMethod = AddBookingSuccess;
                    config.errorMethod = AddBookingFailure;
                    ajaxCall(config);
                } catch (e) {
                    console.log(e.message);
                }
            });
        };
        function AddBookingSuccess(data) {
            try {
                $bookingDv.next('.modal').find('.modal-content').html(data);
            } catch (e) {
                console.log(e.message);
            }
        };
        function AddBookingFailure(error) {
            console.log(error);
        };
        function initilizeModel() {
            $("#modal-action-Employee").on('loaded.bs.modal', function (e) {

            }).on('hidden.bs.modal', function (e) {
                $(this).removeData('bs.modal');
            });
        }
        $this.init = function () {
            initilizeModel();
            AddBooking();
        }
    }
    $(function () {
        var self = new Book();
        self.init();
    })
}(jQuery))
