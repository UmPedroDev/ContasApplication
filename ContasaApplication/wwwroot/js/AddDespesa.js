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

console.log("Script carregado!");

document.addEventListener("DOMContentLoaded", function () {
    const input = document.getElementById("Price");

    input.addEventListener("input", function (event) {
        let value = event.target.value.replace(/\D/g, ""); // Remove tudo que não for número
        if (value) {
            value = (parseFloat(value) / 100).toLocaleString("pt-BR", {
                minimumFractionDigits: 2,
                maximumFractionDigits: 2
            });
        }
        event.target.value = value; // Atualiza o campo com a formatação correta
    });
});


//teste.
