//objeto que contém as funções do arquivo.
var functions = {
    ImportarUsuarioAD: function (pUsuario) {
        fGlobal.Ajax(gHostProjeto + "Usuario/Novo", "POST", { "usuario": pUsuario }, null, null, null, null, null);
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