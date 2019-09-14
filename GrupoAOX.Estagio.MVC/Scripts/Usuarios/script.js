//objeto que contém as funções do arquivo.
var functions = {
    ImportarUsuarioAD: function (pUsuario) {
        fGlobal.Ajax(gHostProjeto + "Usuario/Novo", "POST", { "usuario": pUsuario }, functions.HtmlUsuario, null, null, null, null);
    },
    HtmlUsuario: function (data) {
        if (data.IsValid === true) {
            window.location = gHostProjeto + 'Usuario/Index';
        } else {
            functions.ExibirErrosValidacao(data.Erros);
        }
    },
    ExibirErrosValidacao: function (erros) {
        $('#erros').find('.alert').remove();
        var html = "";
        html += '<div class="alert alert-danger alert-dismissible fade show" role="alert">';
        $.each(erros, function (i, item) {
            html += '<p>' + item.Message + '</p>';
        });
        html += '<button type="button" class="close" data-dismiss="alert" aria-label="Close">';
        html += '<span aria-hidden="true">&times;</span>';
        html += '</button>';
        html += '</div >';

        $('#erros').append(html);
    }
};

$("#btn-salvar").on("click", function () {
    var nome = $("table #nome").text().trim();
    var login = $("table #login").text().trim();
    var email = $("table #email").text().trim();

    var dadosUsuario =
    {
        UsuarioId: 0,
        Nome: nome,
        Login: login,
        Email: email,
        Ativo: true,
        Filiais: null,
        Permissoes: null
    };

    var usuario = JSON.stringify(dadosUsuario);
    functions.ImportarUsuarioAD(usuario);
});