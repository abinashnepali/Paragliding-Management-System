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
                url: config.method,
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
        function loadCart() {
            if (typeof (Storage) !== "undefined") {
                if (localStorage.cartVar) {
                    $cartArr = JSON.parse(localStorage.cartVar);
                    var html = '', i = 0, len = $cartArr.length;
                    for (i; i < len; i++) {
                        html += '<tr id="tr' + $cartArr[i].StaffID + '"><td>' + $cartArr[i].StaffName + '</td><td>' + $cartArr[i].BookedFor + '</td><td><a class="btn btn-danger" id="remCart" href="javascript:void(0)" data-stafid=' + $cartArr[i].StaffID + '><i class="glyphicon glyphicon-trash"></i>Remove From Cart</a></td></tr>';
                    }
                    $bukDivTable.html(html);
                }
            } else {
                messageDisplay("Sorry, your browser does not support web storage...", "error");
            }
        };
        function other() {
            loadBooking();
            $bukDiv.on('click', '#createBooking', function () {
                var currentUrl = window.location.pathname;
                var redirectUrl = $("#RedirectTo").val() + '?ReturnUrl=' + currentUrl;
                if (localStorage.cartVar !== '[]') {
                    var i = 0, len = $cartArr.length, BookedBy = '', StaffID = '', BookedFor = '';
                    for (i; i < len; i++) {
                        BookedFor = $cartArr[0].BookedFor;
                        StaffID += $cartArr[i].StaffID + ',';
                    }
                    if (userIDTemp === "") {
                        window.location.href = redirectUrl;
                    } else {
                        saveBooking(0, userIDTemp, StaffID, BookedFor);
                    }
                } else {
                    messageDisplay('Cart Is Empty', 'error');
                }
            });
            $bukDiv.on('click', '#cancel-book', function () {
                var bookID = $(this).attr('data-bookid');
                cancelBooking(bookID);
            });
            $bukDiv.on('click', '#remCart', function () {
                var staffID = $(this).attr('data-stafid');
                var i = 0, len = $cartArr.length;
                for (i; i < len; i++) {
                    if ($cartArr[i].StaffID && $cartArr[i].StaffID === staffID) {
                        $cartArr.splice(i, 1);
                        break;
                    }
                }
                $bukDivTable.find('#tr' + staffID).remove();
                localStorage.cartVar = JSON.stringify($cartArr);
            });

            function saveBooking(BookID, BookedBy, StaffID) {
                config.type = "POST";
                config.method = "api/Book/Save";
                config.data = JSON.stringify({
                    BookID: BookID,
                    BookedFors: BookedFor,
                    BookedBy: BookedBy
                });
                config.successMethod = saveBookingSuccess;
                config.errorMethod = ajaxFailure;
                config.contentType = "application/json",
                    ajaxCall(config);
            };
            function saveBookingSuccess(data) {
                var res = data;
                switch (res) {
                    case 0:
                        loadBooking();
                        messageDisplay('Pilot Booked Successfully', 'success');
                        break;
                    case 1:
                        messageDisplay('Pilot Already Booked For This Date', 'success');
                        break;
                    default:
                }
            };
            function loadBooking() {
                config.type = "GET";
                config.method = "api/Book/All";
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
                    html += data[i].users.userName;
                    html += '</td><td>';
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
            loadCart();           
            other();
        };
    }
    $(function () {
        var self = new Cart();
        self.init();
    })
}(jQuery))
