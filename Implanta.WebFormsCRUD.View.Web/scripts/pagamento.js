$(document).ready(function () {
    $('#txtCPF').inputmask('999.999.999-99');
});

function ValidarCampos() {
    var sucesso = true;
    var mensagem = "";
    var nomeFavorecido = $('#txtFavorecido').val();
    var cpf = $('#txtCPF').val();

    $('.span-validacao').hide();

    if (!nomeFavorecido) {
        sucesso = false;
        mensagem = 'Informe o favorecido';
        $('#validadorFavorecido').show();
    }
    else if (nomeFavorecido.length > 200) {
        {
            sucesso = false;
            mensagem = 'O campo favorecido deve ter no máximo 200 caracteres';
        }
    }
    else if (!cpf) {
        sucesso = false;
        mensagem = "informe o cpf";
        $('#validadorCPF').show();
    }


    if (!sucesso)
        ExibirAlerta(mensagem, true);

    return sucesso;
}

function validarDadosAoSairDoInput() {
    //var nomeFavorecido = $('#txtFavorecido').val();
    //if (nomeFavorecido.length > 200) {        
    //    var mensagem = 'O campo favorecido deve ter no máximo 200 caracteres';
    //    $('#txtFavorecido').val(nomeFavorecido.substring(0, 200));
    //    ExibirAlerta(mensagem, true);
    //}
}

function MontarDescricaoDoPagamento() {
    const favorecido = $('#txtFavorecido').val();
    const cpf = $('#txtCPF').val();
    const valor = $('#txtValor').val();

    const descricao = 'Pagamento à ' + favorecido + " , CPF " + cpf + ", no valor de R$ " + valor;
    $('#txtDescricao').val(descricao);
}

var confirmarAcaoExcluir = true;
function ConfirmarExclusao() {

    if (confirmarAcaoExcluir) {
        cuteAlert({
            type: 'question',
            title: 'Exclusão de pagamento',
            message: 'Deseja excluir o pagamento?',
            confirmText: 'Sim',
            cancelText: 'Não',
            img: '../Img/delete-icon.jpg'
        }).then((result) => {
            if (result) {
                confirmarAcaoExcluir = false;
                $('#btnExcluir').trigger('click');
            }

        }).catch(erro => console.log(erro))
    }
    else {
        return true;
    }

    return false;
}

function ExibirAlerta(texto, erro) {
    if (erro)
        cuteAlert({ type: 'error', title: 'Erro!', message: texto });
    else
        cuteAlert({ type: 'success', title: 'Sucesso!', message: texto });
}


function validarMascara() {
    var isPJ = $('#chkPJ').is(':checked');

    if (isPJ) {
        $('#txtCPF').inputmask('99.999.999/9999-99');        
    }
    else
        $('#txtCPF').inputmask('999.999.999-99');

}