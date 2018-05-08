(function ($) {
    function Cart() {
        var $this = this;
        var $bukDiv = $('#bookingDv');
        var $bukDivTable = $('#bookingDv').find('#cartBody');
        var $cartArr = '';
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
                url: window.location.origin + '/' + config.method,
                data: config.data,
                dataType: config.dataType,
                success: config.successMethod,
                error: config.errorMethod,
                async: config.async,
                headers: config.headers,
            });
        };
        function ajaxFailure(error) {
            console.log(error);
        };
        function other() {
            loadBooking();
            $bukDiv.on('click', '#cancel-book', function () {
                var bookID = $(this).attr('data-bookid');
                cancelBooking(bookID);
            });
            function loadBooking() {
                config.type = "GET";
                config.method = "api/Book/History";
                config.data = '';
                config.successMethod = loadBookingSuccess;
                config.errorMethod = ajaxFailure;
                ajaxCall(config);
            };
            function loadBookingSuccess(data) {
                $('#cartHead').hide();
                $('#cartTblHd').show();
                var html = '';
                var i = 0, len = data.length;
                for (i; i < len; i++) {
                    html += '<tr><td>';
                    //html += data[i].users.userName;
                    //html += '</td><td>';
                    html += data[i].firstName;
                    html += '</td><td>';
                    html += data[i].bookedOn;
                    html += '</td><td>';
                    html += data[i].bookedFors;
                    html += '</td><td><button id="cancel-book" type="button" class="btn btn-success cancel-book btn-space" data-bookid="' + data[i].bookID + '">Cancel Booking</button>';
                }
                $('#cartTableBody').html(html);
            }
            function cancelBooking(bookID) {
                config.type = "POST";
                config.method = "api/Book/Cancel/" + bookID;
                config.data = '';
                config.dataType = '';
                config.successMethod = cancelBookingSuccess;
                config.errorMethod = ajaxFailure;
                ajaxCall(config);
            };
            function cancelBookingSuccess() {
                messageDisplay('Booking Canceled Successfully', 'success');
            }
            function messageDisplay(message, msgType) {
                msgType = msgType.toLowerCase();
                if (msgType === 'info') {
                    $("#messageSection").addClass('isa_info');
                    $("#messageSection").removeClass('isa_success');
                    $("#messageSection").removeClass('isa_error');
                    $("#mgdLabel").addClass('lblInfo');
                    $("#mgdLabel").removeClass('lblSuccess');
                    $("#mgdLabel").removeClass('lblError');
                } else if (msgType === 'success') {
                    $("#messageSection").addClass('isa_success');
                    $("#messageSection").removeClass('isa_info');
                    $("#messageSection").removeClass('isa_error');
                    $("#mgdLabel").addClass('lblSuccess');
                    $("#mgdLabel").removeClass('lblInfo');
                    $("#mgdLabel").removeClass('lblError');
                } else if (msgType === 'error') {
                    $("#messageSection").addClass('isa_error');
                    $("#messageSection").removeClass('isa_info');
                    $("#messageSection").removeClass('isa_success');
                    $("#mgdLabel").addClass('lblError');
                    $("#mgdLabel").removeClass('lblInfo');
                    $("#mgdLabel").removeClass('lblSuccess');
                }
                $("#messageSection").fadeIn();
                $("#mgdLabel").text(message);
            };
        };
        $this.init = function () {
            other();
        };
    }
    $(function () {
        var self = new Cart();
        self.init();
    })
}(jQuery))
