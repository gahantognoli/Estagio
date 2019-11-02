var functions = {
    ObterLote: function (numLote) {
        fGlobal.Ajax(gHostProjeto + 'Lote/ObterLote?numLote=' + numLote, "GET", null, functions.CriaLinhaTabela, null,
            null, null);
    },
    CriaLinhaTabela: function (data) {
        var lote = data.retorno;
        if (fGlobal.IsEmpty(lote)) {
            alert("Etiqueta não encontrada!\nPor favor, verifique se essa etiqueta não foi descartada");
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
    GerarRequisicao: function () {
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

            this.Descartar(JSON.stringify(lotes));
        }
        else {
            alert('Nenhuma etiqueta foi bipada!');
            $('#modal-confirmar').modal('hide');
        }
    },
    Descartar: function (pLotes) {
        fGlobal.Ajax(gHostProjeto + 'Lote/Descartar', 'POST', { requisicao: pLotes }, this.HtmlDescarte,
            null, this.EsconderModal, this.MostrarModal);
    },
    HtmlDescarte: function (data) {
        var retorno = data.retorno;
        alert("Etiquetas Descartadas com sucesso!");
        window.location = gHostProjeto + "Lote/Descartar";
    },
    VerificaEtiquetaJaBipada: function (etiqueta) {
        var etiquetaJaBipada = false;
        $('#lotes tr td.etiqueta').each(function (i, item) {
            if ($(item).text().trim() === etiqueta) {
                alert("Etiqueta já bipada!");
                etiquetaJaBipada = true;
                $('#Etiqueta').val('');
                return;
            }
        });
        return etiquetaJaBipada;
    },
    EsconderModal: function () {
        fGlobal.EsconderModal('#modal-descarte');
    },
    MostrarModal: function () {
        fGlobal.MostrarModal('#modal-descarte');
        $('#modal-confirmar').modal('hide');
    }
};

$(function () {
    $('#Etiqueta').on('keypress', function (e) {
        if (e.keyCode === 13) {
            e.preventDefault();
            if ($(this).val().length > 6) {
                functions.ObterLote($(this).val().trim());
            } else {
                alert("Etiqueta inválida!");
                $(this).val('');
            }
        }
    });

    $('#btnConfimarDescarte').on('click', function () {
        functions.GerarRequisicao();
    });

    $(document).on('click', '.remover', function () {
        $(this).closest('tr').remove();
    });

});