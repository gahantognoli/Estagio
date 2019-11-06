$(function () {

    $('#btnGerarRelatorio').on('click', function () {
        if ($('#dataInicio').val().trim() !== "" && $('#dataFim').val().trim() !== "") {
            gerarRelatorio();
        } else {
            fGlobal.EmitirNotificacao('Validação', "Informe as datas!", 'danger');
        }

    });

    $('#dataInicio').on('keypress', function (e) {
        if (e.keyCode === 13) {
            e.preventDefault();
            if ($('#dataInicio').val().trim() !== "" && $('#dataFim').val().trim() !== "") {
                gerarRelatorio();
            }
            else {
                fGlobal('Validação', "Informe as datas!", 'danger');
            }
        }
    });

    $('#dataFim').on('keypress', function (e) {
        if (e.keyCode === 13) {
            e.preventDefault();
            if ($('#dataInicio').val().trim() !== "" && $('#dataFim').val().trim() !== "") {
                gerarRelatorio();
            }
            else {
                fGlobal.EmitirNotificacao('Validação', "Informe as datas!", 'danger');
            }
        }
    });
});

function gerarRelatorio() {
    var exportar = $('#exportarPara').val();
    $('#form-report').attr('action', gHostProjeto + "Relatorios/GerarRelatorioMovimentosGerados");

    setTimeout(function () { $('#form-report').submit(); }, 300);
}