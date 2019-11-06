$(function () {
    $('#btnGerarRelatorio').on('click', function () {
        if ($('#ordemExpedicao').val().trim() !== "") {
            gerarRelatorio();
        } else {
            fGlobal.EmitirNotificacao('Validação', "Informe o numero da ordem de expedição!", 'danger');
        }

    });

    $('#numRomaneio').on('keypress', function (e) {
        if (e.keyCode === 13) {
            e.preventDefault();
            if ($('#ordemExpedicao').val().trim() !== "") {
                gerarRelatorio();
            }
            else {
                fGlobal.EmitirNotificacao('Validação', "Informe o numero da ordem de expedição!", 'danger');
            }
        }
    });
});

function gerarRelatorio() {
    var exportar = $('#exportarPara').val();
    if (exportar === "pdf") {
        $('#form-report').attr('action', gHostProjeto + "OrdemExpedicao/VisualizarPDF");
    } else if (exportar === "excel") {
        $('#form-report').attr('action', gHostProjeto + "OrdemExpedicao/VisualizarExcel");
    }
    $('#form-report').submit();
}