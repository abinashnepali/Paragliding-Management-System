(function ($) {
    function Cart() {
        var $this = this;
        var $bukDiv = $('#bookingDv');
        var $bukDivTable = $('#bookingDv').find('#cartBody');
        var $cartArr = '';
        function loadCart() {
            if (typeof (Storage) !== "undefined") {
                if (localStorage.cartVar) {
                    $cartArr = JSON.parse(localStorage.cartVar);
                    var html = '', i = 0, len = $cartArr.length;
                    for (i; i < len; i++) {
                        html += '<tr id="tr' + $cartArr[i].StaffID +'"><td>' + $cartArr[i].StaffName + '</td><td>' + $cartArr[i].BookedFor + '</td><td><a class="btn btn-danger" id="remCart" href="javascript:void(0)" data-stafid=' + $cartArr[i].StaffID + '><i class="glyphicon glyphicon-trash"></i>Remove From Cart</a></td></tr>';
                    }
                    $bukDivTable.html(html);
                }
            } else {
                messageDisplay("Sorry, your browser does not support web storage...", "error");
            }
        };
        function other() {
            $bukDiv.on('click', '#createBooking', function () {
                if (localStorage.cartVar !== '[]') {
                    var BookedFor = $cartArr[i].BookedFor;
                    var BookedBy = $cartArr[i].BookedBy;
                    var StaffID = $cartArr[i].StaffID;
                    saveBooking(0, BookedFor, BookedBy, StaffID);
                } else {
                    messageDisplay('Cart Is Empty', 'error');
                }
            });
            $bukDiv.on('click', '#remCart', function () {
                var staffID = $(this).attr('data-stafid');
                var result = $cartArr.filter(function (staff) {
                    if (staff.StaffID == staffID) {
                        return false;
                    }
                    return true;
                });
                $bukDivTable.find('#tr' + staffID).remove();
                localStorage.cartVar = JSON.stringify(result);
            });
            function saveBooking(BookID, BookedFor, BookedBy, StaffID) {
                var form = $('#frmBook');
                var validator = form.validate(),
                    serialized = form.serializeArray(),
                    data = {};
                if (!validator.valid()) { return; }
                // turn the array of form properties into a regular JavaScript object
                for (var i = 0; i < serialized.length; i++) {
                    data[serialized[i].name] = serialized[i].value;
                }
                config.method = "api/Book/Save";
                config.data = JSON.stringify({
                    BookID: BookID,
                    BookedFor: BookedFor,
                    BookedBy: BookedBy,
                    StaffID: StaffID
                });
                config.successMethod = saveBookingSuccess;
                config.errorMethod = function (error) {
                    ajaxFailure(error, validator);
                };
                ajaxCall(config);
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
