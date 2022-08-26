<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pagamentos.aspx.cs" Inherits="Implanta.WebFormsCRUD.View.Web.pagamentos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pagamentos - Busca</title>
     <link rel="stylesheet" href="css/style.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.2.4/jquery.min.js"></script>
    <script src="scripts/cute-alert.js"></script>
    <script src="scripts/pagamentos.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <fieldset>
                <legend>
                    <h1>Pagamentos - Busca</h1>
                </legend>
                <div>
                </div>
                <div>
                    <table style="width: 380px;">
                        <tr>
                            <td>
                                <label>Número:</label>
                                <asp:TextBox ID="txtNumero" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <label>Favorecido:</label>
                                <asp:TextBox ID="txtFavorecido" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div>
                    <asp:Button ID="btnBuscar" ClientIDMode="Static" runat="server" Text="PESQUISAR" OnClientClick="return ValidarCamposPesquisa();" />
                    <asp:Button ID="btnNovo" ClientIDMode="Static" runat="server" PostBackUrl="pagamento.aspx" Text="NOVO" />
                </div>
                <br />
                <center>
                    <asp:GridView ID="gridViewResultado" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:HyperLinkField
                                Text="Editar"
                                DataNavigateUrlFields="IdPagamento"
                                DataNavigateUrlFormatString="pagamento.aspx?cod={0}"  />
                            <asp:BoundField DataField="Numero" HeaderText="Número" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="DataPagamento" HeaderText="Data" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Favorecido" HeaderText="Favorecido" ItemStyle-Width="60%" />
                            <asp:BoundField DataField="Valor" HeaderText="Valor" DataFormatString="{0:n2}" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Right" />
                        </Columns>
                    </asp:GridView>                    
                </center>
            </fieldset>
            <br />
        </div>
    </form>
</body>
</html>
