// Write your JavaScript code.
$(function () {
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
                        htmlDom += "<button type='button' class='btn btn-success btn-space'>Hire</button>";
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
    $('#pilotList').on('click', '.hide-pilot', function () {
        $(this).parent().parent().remove();
    });

});