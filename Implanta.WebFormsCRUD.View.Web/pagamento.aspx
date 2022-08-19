<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pagamento.aspx.cs" Inherits="Implanta.WebFormsCRUD.View.Web.pagamento" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pagamento - Cadastro</title>
    <link rel="stylesheet" href="css/style.css" />
    <script src="scripts/cute-alert.js"></script>
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
                    <tr>
                        <td>
                            <label>Favorecido:</label>
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txtFavorecido" runat="server" Width="85%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>CPF:</label></td>
                        <td>
                            <asp:TextBox ID="txtCPF" runat="server"></asp:TextBox>
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
                            <asp:TextBox ID="txtDescricao" runat="server" TextMode="MultiLine" Width="85%"></asp:TextBox>                            
                        </td>
                    </tr>
                </table>
            </div>
            </fieldset>            
            <br />
            <center>
                <asp:Button ID="btnSalvar" Text="SALVAR" runat="server" />
                <asp:Button ID="btnExcluir" Text="EXCLUIR" runat="server" />
                <asp:Button ID="btnCancelar" Text="CANCELAR" runat="server" />
            </center>
        </div>
    </form>
</body>
</html>
