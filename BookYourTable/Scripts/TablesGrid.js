
function openModal() {
   $("#modal").show({
        message: 'Your most favorite fruit: <input type="text" class="form-control">',
        onhide: function (dialogRef) {
            var fruit = dialogRef.getModalBody().find('input').val();
            if ($.trim(fruit.toLowerCase()) !== 'banana') {
                alert('Need banana!');
                return false;
            }
        },
        buttons: [{
            label: 'Close',
            action: function (dialogRef) {
                dialogRef.close();
            }
        }]
    });
}

function closeModal() {
    $("#modal").hide(); 
}

var lastClicked;
var grid;
var instruction;
var insertedElements = false;
var width;
var height;
var submitConfigurationLink;
var seatNumbers = new Array();

function applyModal() {
    width = $("#matrixWidth").val();

    if (width == "") {
        alert("Width Must Be a Whole Number!");
    }

    if (isNaN(width)) {
        $("#matrixWidth").val("");
        alert("Width Must Be a Whole Number!");
    }

    if (width % 1 != 0 || width == 0) {
        $("#matrixWidth").val("");
        alert("Width Must Be a Positive Whole Number!");
    }

    height = $("#matrixHeight").val();

    if (height == "") {
        alert("Height Must Be a Whole Number!");
    }

    if (isNaN(height)) {
        $("#matrixHeight").val("");
        alert("Height Must Be a Whole Number!");
    }

    if (height % 1 != 0 || height == 0) {
        $("#matrixHeight").val("");
        alert("Height Must Be a Positive Whole Number!");
    }

    $(grid).remove();
    $(instruction).remove();
    $(submitConfigurationLink).remove();

    if (insertedElements == false) {
        $("<br id=\"secondSectionBR\"/>").insertAfter(".clearDiv");
        $("<hr id=\"secondSectionHR\"/>").insertAfter("#secondSectionBR");
        insertedElements = true;
    }
      
    grid = clickableGrid(height, width, function (el, row, col, i) {
    if (el.id == 'clicked') {
        el.className = 'cell'; el.id = 'notClicked';
    }
    else {
        el.className = 'clicked cell'; el.id = 'clicked';
    }

    });

    function clickableGrid(rows, cols, callback) {
        var i = 0;
        var grid = document.createElement('table');
        grid.className = 'grid';
        grid.id = 'mainTable';
        for (var r = 0; r < rows; ++r) {
            var tr = grid.appendChild(document.createElement('tr'));
            tr.className = 'active';
            for (var c = 0; c < cols; ++c) {
                var cell = tr.appendChild(document.createElement('td'));
                cell.className = 'cell';
                cell.id = 'notClicked';
                cell.innerHTML = ++i;
                cell.addEventListener('click', (function (el, r, c, i) {
                    return function () {
                        callback(el, r, c, i);
                    }
                })(cell, r, c, i), false);
            }
        }
        return grid;
    }

    $(grid).insertAfter("#secondSectionHR");

    instruction = document.createElement('table');
    instruction.className = 'grid';
    instruction.id = 'instruction';
    var instructionTR = instruction.appendChild(document.createElement('tr'));
    var instructionTD1 = instructionTR.appendChild(document.createElement('td'));
    instructionTD1.className ='cell clicked';
    instructionTD1.innerHTML = 'table';
    var instructionTD2 = instructionTR.appendChild(document.createElement('td'));
    instructionTD2.className = 'cell';
    instructionTD2.innerHTML = 'empty';

    $(instruction).insertAfter(".grid");

    submitConfigurationLink = document.createElement('a');
    submitConfigurationLink.className = 'btn btn-primary btn-configure';

    submitConfigurationLink.onclick = function () {
        

        var i = 0;

        $('#mainTable tr').each(function () {
            $(this).find('td').each(function () {
                alert($(this).attr('class'));
                if ($(this).is('#clicked')) {
                    seatNumbers.push(i);
                }
                i++;
            })
        })

        if (seatNumbers.length == 0) {
            alert("You Didn't Select Any Tables!");
            return;
        }

        $.post(
                   "../Restaurant/ConfigureRestaurant",
                   {
                       tableIndexes: seatNumbers,
                       width: width,
                       height: height
                   },
                   function () {
                       alert("Successfully Configured Tables!");

                   });
    };

    submitConfigurationLink.innerHTML = 'Configure Seats';

    $(submitConfigurationLink).insertAfter("#instruction");

    $("#modal").hide();
}



