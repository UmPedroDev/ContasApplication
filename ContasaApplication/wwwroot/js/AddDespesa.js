$(document).ready(function () {
    $('#flexCheckDefault').change(function () {
        if ($(this).is(':checked')) {
            $('#parcelado').show();
        }
        else {
            $('#parcelado').hide();
        }
    });
});

document.getElementById("Price").addEventListener("input", function (event) {
    let value = event.target.value.replace(/\D/g, "");
    if (value.length > 2) {
        value = value.replace(/(\d)(\d{2})$/, "$1,$2");
    }
    event.target.value = value.replace(/(\d)(?=(\d{3})+(\D|$))/g, "$1.");
});

var cleave = new Cleave('#Price', {
    numeral: true,
    numeralThousandsGroupStyle: 'thousand',
    prefix: 'R$ ',
});


