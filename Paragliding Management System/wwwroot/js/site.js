﻿(function ($) {
    function Home() {
        var $this = this;
        var $cartItem = $('.container').find('.cartItem');
        var $cartArr = [];
        var $arrVar = [];
        var $bukDiv = $('#bookingDv');
        var $pilotList = $('#pilotList');
        function loadDatePicker() {
            $("#datepicker").datepicker({
                minDate: 0,
                dateFormat: 'yy-mm-dd',
                onSelect: function () {
                    $('#pilotList').show();
                    localStorage.BookedFor = $(this).val();
                    $.get("api/pilot/search",
                        {
                            offSet: 0,
                            date: $(this).val()
                        },
                        function (data) {
                            htmlDom = "";
                            $.each(data, function (k, v) {
                                htmlDom += "<div class='col-sm-6 col-md-4'>";
                                htmlDom += "<div class='thumbnail'>";
                                v.photo = v.photo === null ? "/images/noimage.png" : v.photo;
                                htmlDom += "<img src='" + v.photo + "' alt='" + v.firstName + ' ' + v.lastName + "'>";
                                htmlDom += "<div class='caption'>";
                                htmlDom += "<h3>";
                                htmlDom += v.firstName + ' ' + v.lastName;
                                htmlDom += "</h3>";
                                htmlDom += "<p>Pilot</P>";
                                htmlDom += "<p>";
                                htmlDom += "<a class='btn btn-success cart-pilot btn-space' data-staffid='" + v.staffID + "' data-staffName='" + v.firstName + ' ' + v.lastName +  "' role='button'>Hire</a>";
                                htmlDom += " <a class='btn btn-warning hide-pilot btn-space' role='button'>Hide</a>";
                                htmlDom += "</p>";
                                htmlDom += "</div>";
                                htmlDom += "</div>";
                                htmlDom += "</div>";
                            });
                            $('#staffList').html(htmlDom);                           
                        }).fail(function () {
                            console.log("something went wrong.");
                        });
                }
            });
        };
        function pilotBooking() {
            $pilotList.on('click', '.cart-pilot', function () {
                var $this = $(this);
                if (typeof (Storage) !== "undefined") {
                    if (localStorage.clickcount) {
                        localStorage.clickcount = Number(localStorage.clickcount) + 1;
                    } else {
                        localStorage.clickcount = 1;
                    }
                    $cartItem.text(localStorage.clickcount);
                    $cartArr.push({ "BookID": 0, "BookedFor": $('#datepicker').val(), "StaffID": $this.attr('data-staffid'), "StaffName": $this.attr('data-staffname') });
                    localStorage.cartVar = JSON.stringify($cartArr);
                } else {
                    messageDisplay("Sorry, your browser does not support web storage...", "error");
                }
                $this.attr('disabled', true);
            });
            $pilotList.on('click', '.hide-pilot', function () {
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
                                $cartArr.push({ "BookedFor": BookedFor, "StaffID": StaffID });
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
        function clearStorage() {
            if (typeof (Storage) !== "undefined") {
                localStorage.clickcount = 0;
            }
        };
        $this.init = function () {
            loadDatePicker();
            pilotBooking();
            clearStorage();            
        };
    }
    $(function () {
        var self = new Home();
        self.init();
    })
}(jQuery))
