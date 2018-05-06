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
                        html += '<tr id="tr' + $cartArr[i].StaffID + '"><td>' + $cartArr[i].StaffName + '</td><td>' + localStorage.BookedFor + '</td><td><a class="btn btn-danger" id="remCart" href="javascript:void(0)" data-stafid=' + $cartArr[i].StaffID + '><i class="glyphicon glyphicon-trash"></i>Remove From Cart</a></td></tr>';
                    }
                    $bukDivTable.html(html);
                }
            } else {
                messageDisplay("Sorry, your browser does not support web storage...", "error");
            }
        };
        function other() {
            $bukDiv.on('click', '#createBooking', function () {
                var currentUrl = window.location.pathname;
                var redirectUrl = $("#RedirectTo").val() + '?ReturnUrl=' + currentUrl;
                if (localStorage.cartVar !== '[]') {
                    var i = 0, len = $cartArr.length, BookedBy = '', StaffID = '';
                    for (i; i < len; i++) {
                        StaffID += $cartArr[i].StaffID + ',';
                    }
                    if (userIDTemp === "") {
                        window.location.href = redirectUrl;
                    } else {
                        saveBooking(0, userIDTemp, StaffID);
                    }
                } else {
                    messageDisplay('Cart Is Empty', 'error');
                }
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
                config.method = "api/Book/Save";
                config.data = JSON.stringify({
                    BookID: BookID,
                    BookedFors: localStorage.BookedFor,
                    BookedBy: BookedBy,
                    StaffIDs: StaffID
                });
                config.successMethod = saveBookingSuccess;
                config.errorMethod = ajaxFailure;
                ajaxCall(config);
            };
            function saveBookingSuccess(data) {
                var res = data;
                console.log(res);
            };
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
