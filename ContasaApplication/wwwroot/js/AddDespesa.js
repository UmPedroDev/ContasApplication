$(document).ready(function () {
    $('#flexCheckDefault').change(function () {
        if ($(this).is(':checked')) {
            $('#parcelado').show();
            $('#flexCheckData').prop('disabled', true);
        }
        else {
            $('#parcelado').hide();
            $('#flexCheckData').prop('disabled', false);
        }
    });
});


$(document).ready(function () {
    $('#flexCheckData').change(function () {
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
    const parcelas = document.getElementById('QuantidadeParcelas');
    const parcelasPagas = document.getElementById('QuantidadeParcelasPagas');

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

    parcelas.addEventListener('input', () => {
        const valor1 = parseFloat(parcelas.value);

        if (valor1 > 0) {
            parcelasPagas.disabled = false;
            parcelasPagas.max = valor1;
        } else {
            parcelasPagas.disabled = true;
            parcelasPagas.value = '';
        }
    });

    parcelasPagas.addEventListener('input', () => {
        const valor1 = parseFloat(parcelas.value);
        const valor2 = parseFloat(parcelasPagas.value);

        if (valor2 >= valor1) {
            parcelasPagas.value = valor1 - 1;
        }
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

document.addEventListener("DOMContentLoaded", function () {
    const checkboxes = [
        document.getElementById("flexCheckDefault"),
        document.getElementById("flexCheckData"),
        document.getElementById("flexCheckContaFixa")
    ];

    checkboxes.forEach((checkbox, idx) => {
        checkbox.addEventListener("change", function () {
            if (checkbox.checked) {
                // Desabilita os outros
                checkboxes.forEach((cb, i) => {
                    if (i !== idx) {
                        cb.disabled = true;
                    }
                });
            } else {
                // Reativa todos se nenhum estiver marcado
                const algumMarcado = checkboxes.some(cb => cb.checked);
                if (!algumMarcado) {
                    checkboxes.forEach(cb => cb.disabled = false);
                }
            }
        });
    });
});

document.addEventListener("DOMContentLoaded", function () {
    const inputData = document.getElementById("inputData");

    const hoje = new Date();
    hoje.setDate(hoje.getDate() + 1); // para permitir apenas *de amanhã em diante*

    const ano = hoje.getFullYear();
    const mes = String(hoje.getMonth() + 1).padStart(2, '0');
    const dia = String(hoje.getDate()).padStart(2, '0');

    const dataMinima = `${ano}-${mes}-${dia}`;

    inputData.min = dataMinima;
});