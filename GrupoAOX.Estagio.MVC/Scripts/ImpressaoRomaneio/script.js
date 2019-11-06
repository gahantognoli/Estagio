$(function () {
    $('#btnGerarRelatorio').on('click', function () {
        if ($('#numRomaneio').val().trim() !== "") {
            gerarRelatorio();
        } else {
            fGlobal.EmitirNotificacao('Validação', "Informe o numero do romaneio!", 'danger');
        }

    });

    $('#numRomaneio').on('keypress', function (e) {
        if (e.keyCode === 13) {
            e.preventDefault();
            if ($('#numRomaneio').val().trim() !== "") {
                gerarRelatorio();
            }
            else {
                fGlobal.EmitirNotificacao('Validação', "Informe o numero do romaneio!", 'danger');
            }
        }
    });
});

function gerarRelatorio() {
    var exportar = $('#exportarPara').val();
    if (exportar === "pdf") {
        $('#form-report').attr('action', gHostProjeto + "Romaneio/VisualizarPDF");
    } else if (exportar === "excel") {
        $('#form-report').attr('action', gHostProjeto + "Romaneio/VisualizarExcel");
    }
    $('#form-report').submit();
}