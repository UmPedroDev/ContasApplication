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

$(document).ready(function () {
    $('#form-check-despesaFutura').change(function () {
        if ($(this).is(':checked')) {
            $('#dataFutura').show();
        }
        else {
            $('#dataFutura').hide();
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

document.querySelectorAll("#QuantidadeParcelas").forEach(input => {
    let maxValue = 500;
    input.addEventListener("keypress", function (event) {
        if (event.key === "-" || event.key === "e") {
            event.preventDefault();
        }
    });

    input.addEventListener("input", function () {
        if (this.value < 0) {
            this.value = 0;
        }
    });

    input.addEventListener("blur", function () {
        if (this.value > maxValue) {
            this.value = maxValue;
        }
    });
});
