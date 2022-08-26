<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pagamento.aspx.cs" Inherits="Implanta.WebFormsCRUD.View.Web.pagamento" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pagamento - Cadastro</title>
    <link rel="stylesheet" href="css/style.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.2.4/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.inputmask/3.3.4/jquery.inputmask.bundle.min.js"></script>
    <script src="scripts/cute-alert.js"></script>
    <script src="scripts/pagamento.js"></script>
    
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <fieldset>
                <legend><h1>Pagamento - Cadastro</h1></legend>
                <div>
                <table style="width: 680px;">
                    <tr>
                        <td>
                            <label>Número:</label></td>
                        <td>
                            <asp:TextBox ID="txtNumero" runat="server" Enabled="false"></asp:TextBox></td>
                        <td>
                            <label>Data:</label></td>
                        <td>
                            <asp:TextBox ID="txtData" runat="server" type="date" />
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <td>
                            <label>Classificação:</label>
                        </td>
                        <td colspan="3">
                            <asp:DropDownList runat="server" ID="ddlClassificacoes"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>Favorecido:</label>
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txtFavorecido" runat="server" Width="85%" onblur="validarDadosAoSairDoInput()" MaxLength="200">
                            </asp:TextBox><span id="validadorFavorecido" class="span-validacao" style="color:red; display:none;">*</span>                            
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>CPF/CNPJ:</label></td>
                        <td>
                            <asp:TextBox ID="txtCPF" runat="server"></asp:TextBox>
                            <span id="validadorCPF" class="span-validacao" style="color:red; display:none;">*</span>
                            <input type="checkbox" text="PJ" onchange="validarMascara()" id="chkPJ" />
                            <label>Pessoa Jurídica</label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>Valor:</label></td>
                        <td>
                            <asp:TextBox ID="txtValor" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>Descrição:</label></td>
                        <td colspan="3">
                            <asp:TextBox ID="txtDescricao" runat="server" TextMode="MultiLine" Width="85%" onfocus="MontarDescricaoDoPagamento()"></asp:TextBox>                            
                        </td>
                    </tr>
                </table>
            </div>
            </fieldset>            
            <br />
            <center>
                <asp:Button ID="btnSalvar" Text="SALVAR" runat="server" OnClientClick="return ValidarCampos();" />
                <asp:Button ID="btnExcluir" Text="EXCLUIR" runat="server" OnClientClick="return ConfirmarExclusao();" />
                <asp:Button ID="btnCancelar" Text="CANCELAR" runat="server" />
            </center>
        </div>
    </form>
</body>
</html>
