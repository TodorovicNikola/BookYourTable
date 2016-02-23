var tableNumbers = new Array();

function bookTable() {
    var i = 0;

    $('#tablesTable tr').each(function () {
        $(this).find('td').each(function () {
            if ($(this).is('#clicked')) {
                tableNumbers.push(i);
            }
            i++;
        })
    })

    if (tableNumbers.length == 0) {
        alert("You Didn't Select Any Tables!");
        return;
    }

    var restaurantID = $("#restaurantID").val();
    var date = $("#date").val();
    var time = $("#time").val();
    var duration = $("#duration").val();

    $.post(
               "../Restaurant/ConfirmBookingTable",
               {
                   tableIndexes: tableNumbers,
                   restaurantID: restaurantID,
                   date: date,
                   time: time,
                   duration: duration
               },
               function (data) {
                   if (data.data == 0) {
                       location.replace("http://localhost:50353/Restaurant/BookingResult?result=" + "0" + "&reservationID=" + data.reservationID);
                   }
                   else if (data.data == 1) {
                       location.replace("http://localhost:50353/Restaurant/BookingResult?result=" + "1");
                   }
                   else{
                       location.replace("http://localhost:50353/Restaurant/BookingResult?result=" + "2");
                   }

               });
}

function tableClicked(el) {
    if (el.id=='clicked') {
        el.id = '';
    } else {
        el.id = 'clicked';
    }
}