var functions = {
    ObterLote: function (numLote) {
        fGlobal.Ajax(gHostProjeto + 'Lote/ObterLote?numLote=' + numLote, "GET", null, functions.CriaLinhaTabela, null,
            null, null);
    },
    CriaLinhaTabela: function (data) {
        var lote = data.retorno;
        if (fGlobal.IsEmpty(lote)) {
            fGlobal.EmitirNotificacao('Validação', "Etiqueta não encontrada!\nPor favor, verifique se essa etiqueta não foi descartada", 'danger');
            $('#Etiqueta').val('');
        } else {
            if (functions.VerificaEtiquetaJaBipada(lote.Etiqueta) === false) {
                var linha = "<tr>";
                linha += "<td class='id'>" + lote.ApontamentoProducaoId + "</td>";
                linha += "<td class='etiqueta'>" + lote.Etiqueta + "</td>";
                linha += "<td class='op'>" + lote.OrderProducao + "</td>";
                linha += "<td class='produto'>" + lote.Produto + "</td>";
                linha += "<td><button type='button' class='btn btn-sm btn-danger remover'>Remover</button></td>";
                linha += "</tr>";
                $('#Etiqueta').val('');
                $('#lotes').append(linha);
            }
        }
    },
    GerarRequisicaoRomaneio: function () {
        if ($('#lotes tr').length > 0) {
            var lotes = [];

            $('#lotes tr').each(function (i, item) {
                var lote = {
                    ApontamentoProducaoId: $(item).find('.id').text().trim(),
                    Etiqueta: $(item).find('.etiqueta').text().trim(),
                    OrderProducao: $(item).find('.op').text().trim(),
                    Produto: $(item).find('.produto').text().trim()
                };
                lotes.push(lote);
            });

            var ordemExpedicao = {
                ArmazemDestino: "FT",
                NumeroDocumento: $('#NumeroDocumento').val(),
                CategoriaId: Number($('#categoriaId').val()),
                Lotes: lotes
            };
            this.Transferir(JSON.stringify(ordemExpedicao));
        }
        else {
            fGlobal.EmitirNotificacao('Validação', 'Nenhuma etiqueta foi bipada!', 'danger');
        }
    },
    Transferir: function (pOrdemExpedicao) {
        fGlobal.Ajax(gHostProjeto + 'OrdemExpedicao/Novo', 'POST', { requisicao: pOrdemExpedicao }, this.HtmlTransferencia,
            null, this.EsconderModal, this.MostrarModal);
    },
    HtmlTransferencia: function (data) {
        var retorno = data.retorno;
        if (retorno.ValidationResult.IsValid === true) {
            $('#btnVisualizarOrdemExpdicao').removeAttr('style', 'display:none');
            $('#btnVisualizarOrdemExpdicao').attr('href', gHostProjeto + 'OrdemExpedicao/VisualizarPDF?ordemExpedicao=' + retorno.NumeroDocumento);
            $('#btnNovoOrdemExpedicao').removeAttr('style', 'display:none');
            $('#btnVoltar').removeAttr('style', 'display:none');
            $('#btnTransferir').attr('style', 'display:none');
            $('#Etiqueta').attr('disabled', 'disabled');
            fGlobal.EmitirNotificacao('Sucesso', 'Transferência realizada com sucesso!', 'info');
        } else {
            this.ExibirErros(data.ValidationResult);
        }
    },
    VerificaEtiquetaJaBipada: function (etiqueta) {
        var etiquetaJaBipada = false;
        $('#lotes tr td.etiqueta').each(function (i, item) {
            if ($(item).text().trim() === etiqueta) {
                fGlobal.EmitirNotificacao('Validação', "Etiqueta já bipada!", 'danger');
                etiquetaJaBipada = true;
                $('#Etiqueta').val('');
                return;
            }
        });
        return etiquetaJaBipada;
    },
    ExibirErros: function (validationResult) {
        var alert = "";
        alert += '<div class="alert alert - warning alert - dismissible fade show" role="alert">';
        alert += validationResult.Erros[0].Message;
        alert += '<button type = "button" class="close" data - dismiss="alert" aria - label="Close">';
        alert += '<span aria-hidden="true">&times;</span>';
        alert += '</button>';
        alert += '</div>';
        $('#erros').append(alert);
    },
    EsconderModal: function () {
        fGlobal.EsconderModal('#modal-ordemExpedicao');
    },
    MostrarModal: function () {
        fGlobal.MostrarModal('#modal-ordemExpedicao');
    }
};

$(function () {
    $('#Etiqueta').focus();

    $('#Etiqueta').on('keypress', function (e) {
        if (e.keyCode === 13) {
            e.preventDefault();
            if ($(this).val().length > 6) {
                functions.ObterLote($(this).val().trim());
            } else {
                fGlobal.EmitirNotificacao('Validação', "Etiqueta inválida!", 'danger');
                $(this).val('');
            }
        }
    });

    $('#btnTransferir').on('click', function () {
        functions.GerarRequisicaoRomaneio();
    });

    $(document).on('click', '.remover', function () {
        $(this).closest('tr').remove();
    });
});