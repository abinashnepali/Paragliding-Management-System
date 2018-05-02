(function ($) {
    function Home() {
        var $this = this;
        var $cartItem = $('.container').find('.cartItem');
        var $cartArr = [];
        function loadDatePicker() {
            $("#datepicker").datepicker({
                minDate: 0,
                dateFormat: 'yy-mm-dd',
                onSelect: function () {
                    $('#pilotList').show();
                    $.get("api/pilot/search",
                        {
                            offSet: 0,
                            date: $(this).val()
                        },
                        function (data) {
                            htmlDom = "";
                            $.each(data, function (k, v) {
                                htmlDom += "<tr>";
                                htmlDom += "<td>";
                                v.photo = v.photo === null ? "/images/noimage.png" : v.photo;
                                htmlDom += "<img src='" + v.photo + "' alt='" + v.firstName + ' ' + v.lastName + "' class='img-responsive img-thumbnail' style='width: 150px; height: auto;'>";
                                htmlDom += "</td>";
                                htmlDom += "<td>";
                                htmlDom += v.firstName + ' ' + v.lastName;
                                htmlDom += "</td>";
                                htmlDom += "<td>";
                                htmlDom += "<button type='button' class='btn btn-success cart-pilot btn-space' data-staffid='" + v.staffID + "'>Hire</button>";
                                htmlDom += "<button type='button' class='btn btn-warning hide-pilot btn-space'>Hide</button>";
                                htmlDom += "</td>";
                                htmlDom += "</tr>";
                            });
                            $('#staffList').html(htmlDom);
                        }).fail(function () {
                            console.log("something went wrong.");
                        });
                }
            });
        };
        function pilotBooking() {
            $('#pilotList').on('click', '.cart-pilot', function () {
                var $staffID = $(this).attr('data-staffid');
                checkPilot($('#datepicker').val(), $staffID);
            });
            $('#pilotList').on('click', '.hide-pilot', function () {
                $(this).parent().parent().remove();
            });
            function checkPilot(BookedFor, StaffID) {
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    cache: false,
                    url: "/api/pilot/chkbookingstat",
                    data: JSON.stringify({
                        BookedFor: BookedFor,
                        StaffID: StaffID
                    }),
                    dataType: "json",
                    success: function (data) {
                        if (data === 0) {
                            if (typeof (Storage) !== "undefined") {
                                if (localStorage.clickcount) {
                                    localStorage.clickcount = Number(localStorage.clickcount) + 1;
                                } else {
                                    localStorage.clickcount = 1;
                                }
                                $cartItem.text(localStorage.clickcount);
                                $cartArr.push({"BookedFor": BookedFor, "StaffID": StaffID});                                
                            } else {
                                messageDisplay("Sorry, your browser does not support web storage...", "error");
                            }
                            localStorage.bookData = JSON.stringify($cartArr);
                        } else if (data === 1) {
                            messageDisplay('Pilot Already Booked For That Date', 'error');
                        }
                    },
                    error: function (error) {
                        console.log(error);
                    },
                    async: false,
                });
            };
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
            loadDatePicker();
            pilotBooking();
        };
    }
    $(function () {
        var self = new Home();
        self.init();
    })
}(jQuery))
