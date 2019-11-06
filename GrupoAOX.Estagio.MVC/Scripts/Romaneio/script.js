var functions = {
    ObterArmazens: function (filial, parametro, pesquisa) {
        fGlobal.Ajax(gHostProjeto + 'Romaneio/ObterArmazens?filial=' + filial + "&parametro=" + parametro +
            "&pesquisa=" + pesquisa, "GET", null, functions.HtmlArmazem, null,
            null, function () { $('#carregando').removeAttr('display', 'none'); });
    },
    HtmlArmazem: function (data) {
        $('#carregando').css('display', 'none');
        functions.PreencherArmazens(JSON.parse(data));
        
    },
    PreencherArmazens: function (armazens) {
        $('#armazens').html('');
        var tr = "";
        $.each(armazens, function (i, item) {
            tr += "<tr>";
            tr += "<td><input type='radio' name='checkArmazem' class='checkArmazem' /></td>";
            tr += "<td class='codigo'>" + item.Codigo + "</td>";
            tr += "<td class='descricao'>" + item.Descricao + "</td>"; 
            tr += "</tr>";
        });
        $('#armazens').append(tr);
    },
    ObterLote: function (numLote) {
        fGlobal.Ajax(gHostProjeto + 'Lote/ObterLote?numLote=' + numLote, "GET", null, functions.CriaLinhaTabela, null,
            null, null);
    },
    CriaLinhaTabela: function (data) {
        var lote = data.retorno;
        if (fGlobal.IsEmpty(lote)) {
            fGlobal.EmitirNotificacao('Não encontrado', "Etiqueta não encontrada!\nPor favor, verifique se essa etiqueta não foi descartada", "danger");
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

            var romaneio = {
                ArmazemDestino: $('#ArmazemDestino').val().split('-')[0].trim(),
                NumeroDocumento: $('#NumeroDocumento').val(),
                CategoriaId: Number($('#categoriaId').val()),
                Lotes: lotes
            };
            this.Transferir(JSON.stringify(romaneio));
        }
        else {
            fGlobal.EmitirNotificacao('Validação', "Nenhuma etiqueta foi bipada!", "danger");
        }
    },
    Transferir: function (pRomaneio) {
        fGlobal.Ajax(gHostProjeto + 'Romaneio/Novo', 'POST', { requisicao: pRomaneio }, this.HtmlTransferencia,
            null, this.EsconderModal, this.MostrarModal);
    },
    HtmlTransferencia: function (data) {
        var retorno = data.retorno;
        if (retorno.ValidationResult.IsValid === true) {
            $('#btnVisualizarRomaneio').removeAttr('style', 'display:none');
            $('#btnVisualizarRomaneio').attr('href', gHostProjeto + 'Romaneio/VisualizarPDF?numRomaneio=' + retorno.NumeroDocumento);
            $('#btnNovoRomaneio').removeAttr('style', 'display:none');
            $('#btnTransferir').attr('style', 'display:none');
            $('#btnVoltar').removeAttr('style', 'display:none');
            $('#Etiqueta').attr('disabled', 'disabled');
            $('#ArmazemDestino').attr('disabled', 'disabled');
            fGlobal.EmitirNotificacao('Sucesso', 'Transferência realiza com sucesso', 'info');
        } else {
            this.ExibirErros(data.ValidationResult);
        }
    },
    VerificaEtiquetaJaBipada: function (etiqueta) {
        var etiquetaJaBipada = false;
        $('#lotes tr td.etiqueta').each(function (i, item) {
            if ($(item).text().trim() === etiqueta) {
                fGlobal.EmitirNotificacao('Validação',  "Etiqueta já bipada!", 'danger');
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
        fGlobal.EsconderModal('#modal-romaneio');
    },
    MostrarModal: function () {
        fGlobal.MostrarModal('#modal-romaneio');
    }
};

$(function () {
    $('#btnPesquisaArmazem').on('click', function () {
        $('#modal-armazens').modal('show');
        $('#pesquisa').val('');
        functions.ObterArmazens('5202', "", "");
    });

    $('#Etiqueta').on('keypress', function (e) {
        if (e.keyCode === 13) {
            e.preventDefault();
            if ($(this).val().length > 6) {
                functions.ObterLote($(this).val().trim());
            } else {
                fGlobal.EmitirNotificacao('Validação', "Etiqueta inválida!", "danger");
                $(this).val('');
            }
        }
    });

    $('#btnPesquisa').on('click', function () {
        var pesquisa = $('#pesquisa').val();
        if (fGlobal.IsNotEmpty(pesquisa)) {
            functions.ObterArmazens('5202', $('#armazem').val(), pesquisa.toUpperCase());
        } else {
            fGlobal.EmitirNotificacao('Validação', 'Informa a pesquisa!', "danger");
            $('#pesquisa').focus();
        }
    });

    $('#btnConfirmacaoArmazem').on('click', function () {
        var codigoArmazemSelecionado = $("input[name='checkArmazem']:checked").closest('tr').find('.codigo').text().trim();
        var descricaoArmazemSelecionado = $("input[name='checkArmazem']:checked").closest('tr').find('.descricao').text().trim();
        if (fGlobal.IsNotEmpty(codigoArmazemSelecionado)) {
            $('#ArmazemDestino').val(codigoArmazemSelecionado + ' - ' + descricaoArmazemSelecionado);
            $('#modal-armazens').modal('hide');
            $('#Etiqueta').focus();
        }
        else {
            fGlobal.EmitirNotificacao('Validação', 'Selecione um armazém!', 'danger');
        }
    });

    $('#btnTransferir').on('click', function () {
        if (fGlobal.IsNotEmpty($('#ArmazemDestino').val())) {
            functions.GerarRequisicaoRomaneio();
        } else {
            fGlobal.EmitirNotificacao("Validação", "Informe o armazém", "danger");
        }
        
    });

    $(document).on('click', '.remover', function () {
        $(this).closest('tr').remove();
    });
});