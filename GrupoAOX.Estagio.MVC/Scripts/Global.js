﻿var fGlobal = {
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
    }
};

$(function () {
    $('#btnLogout').on('click', function () {
        sessionStorage.clear();
        $('#logoutForm').submit();
    });
});