var fGlobal = {
    Ajax: function (pUrl, pType, pValor, pFuncSuccess, pFuncError, pFuncComplete, pFuncBeforeSend, pDataType, pContentType, pAssync) {
        try {
            pDataType = pDataType === null ? "JSON" : pDataType;
            pContentType = pContentType === null ? "application/json; charset=utf-8" : pContentType;
            pAssync = pAssync === null ? true : pAssync;

            $.ajax({
                url: pUrl,
                type: pType,
                data: pValor,
                dataType: pDataType,
                assync: pAssync,
                crossDomain: true,
                success: function (data) {
                    if (pFuncSuccess !== null)
                        pFuncSuccess(data);
                },
                error: function (data) {
                    if (pFuncError !== null)
                        pFuncError(data);
                },
                complete: function (data) {
                    if (pFuncComplete !== null)
                        pFuncComplete(data);
                },
                beforeSend: function (data) {
                    if (pFuncBeforeSend !== null)
                        pFuncBeforeSend(data);
                }
            });
        } catch (e) {
            console.log("Erro ao enviar requisição AJAX! Detalhes: " + e.message);
        }
    },
    IsNotEmpty: function (pValue) {
        return pValue !== undefined && pValue !== null && pValue !== "" ? true : false;
    },
    IsEmpty: function (pValue) {
        return pValue === undefined || pValue === null || pValue === "" ? true : false;
    },
    EsconderModal: function (id) {
        $(id).modal('hide');
    },
    MostrarModal: function (id) {
        $(id).modal('show');
    },
    EmitirNotificacao: function (titulo, mensagem, tipo) {
        $.notify({
            title: titulo,
            message: mensagem
        },
            {
                type: 'pastel-' + tipo,
                delay: 5000,
                offset: {
                    x: 23,
                    y: 80
                },
                template: '<div data-notify="container" class="col-xs-11 col-sm-3 alert alert-{0}" role="alert">' +
                    '<button type="button" aria-hidden="true" class="close" data-notify="dismiss">×</button>' +
                    '<span data-notify="title">{1}</span>' +
                    '<span data-notify="message">{2}</span>' +
                    '</div>'
            });
    }
};

$(function () {
    $('#btnLogout').on('click', function () {
        sessionStorage.clear();
        $('#logoutForm').submit();
    });
});