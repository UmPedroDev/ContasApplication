$(document).ready(function () {
    $(document).on("click", ".item", function (event) {

        // Obtém o ID específico da tabela associada ao item clicado
        var tabelaId = $(this).data("table");

        // Esconde todas as tabelas antes de exibir a correta
        $(".table").fadeOut(function () {
            $("#" + tabelaId).fadeIn();
        });

        // Evita que o clique no item feche imediatamente a tabela
        event.stopPropagation();
    });

    // Fecha a tabela se clicar fora dela
    $(document).on("click", function (event) {
        if (!$(event.target).closest(".table, .item").length) {
            $(".table").fadeOut();
        }
    });
});

