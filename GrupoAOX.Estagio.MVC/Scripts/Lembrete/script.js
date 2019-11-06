$(function () {
    $('.concluido').on('change', function () {
        var lembreteId = $(this).closest('tr').find('td').first().text().trim();
        var concluido = $(this).is(':checked');
        var url = gHostProjeto + 'Lembrete/MarcarConclusao?id=' + lembreteId + "&concluido=" + concluido;
        fGlobal.Ajax(url, "GET", null, ExibeMensagemSucesso, null, null, null);
    });

    $('#parametro').on('change', function () {
        if ($(this).val() === "dataLancamento") {
            $('#busca').mask('99/99/9999');
        } else {
            $('#busca').unmask();
        }
    });

    function ExibeMensagemSucesso(data) {
        window.location = "/Lembrete/Index";
    }

});