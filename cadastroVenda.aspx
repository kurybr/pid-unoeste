<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="cadastroVenda.aspx.cs" Inherits="PID_3_Termo.cadastroVenda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
    table, .tabela{
    float:left;
        border-style:none;
    }
        .auto-style1 {
            height: 26px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>Entre com o codigo do cliente</td>
            <td><asp:TextBox ID="tbCodigoCliente" runat="server" AutoPostBack="True" OnTextChanged="tbCodigoCliente_TextChanged"></asp:TextBox></td>
            <td> <asp:Label ID="lbErroCliente" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td> Nome do Cliente:</td>
            <td> <asp:Label ID="lbNomedoCliente" runat="server"></asp:Label></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">Selecione o Pacote:</td>
            <td class="auto-style1"><asp:DropDownList ID="ddlPacotes" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPacotes_SelectedIndexChanged"></asp:DropDownList></td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td>Preço pacote (valor diaria): R$:</td>
            <td><asp:Label ID="lbValor" runat="server"></asp:Label></td>
            <td></td>
        </tr>
        <tr>
            <td> Data da Viagem:</td>
            <td> <asp:TextBox ID="ttbDataViagem" runat="server" TextMode="DateTime" AutoPostBack="True" OnTextChanged="ttbDataViagem_TextChanged"></asp:TextBox></td>
            <td>
                <asp:Label ID="lbErroData" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td> Diarias:</td>
            <td> 
                <asp:TextBox ID="tbDiarias" runat="server" AutoPostBack="True" OnTextChanged="tbDiarias_TextChanged"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="lbErroDiarias" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Valor Total:</td>
            <td><asp:Label ID="lbValorTotal" runat="server"></asp:Label></td>
            <td></td>
        </tr>
        <tr>
            <td>Forma de Pagamento</td>
            <td><asp:RadioButtonList ID="rblFormaPagamento" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblFormaPagamento_SelectedIndexChanged"> </asp:RadioButtonList></td>
            <td></td>
        </tr>
        <tr>
            <td>Parcelas:</td>
            <td> <asp:DropDownList ID="ddlParcelas" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlParcelas_SelectedIndexChanged" > </asp:DropDownList></td>
            <td></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnGravar" runat="server" OnClick="btnGravar_Click" Text="Gravar" />
                <asp:Button ID="btnAtualizar" runat="server" Text="Atualizar" OnClick="btnAtualizar_Click" />
                <asp:Button ID="btnExcluir" runat="server" Text="Excluir" OnClick="btnExcluir_Click" />
            </td>            
        </tr>
    </table>
    <table class="pesquisaCliente">
        <tr>
           <td>
               Digite o CPF do Cliente
           </td>
           <td>
               <asp:TextBox runat="server" ID="ttbCPFCliente" AutoPostBack="True" OnTextChanged="ttbCPFCliente_TextChanged"></asp:TextBox>
           </td>
           <td>
               <asp:Label ID="lbErroCPF" runat="server"></asp:Label>
           </td>
       </tr>
        <tr>
           <td>Cliente Selecionado:</td>
           <td><asp:Label ID="lbNomeCliente" runat="server"></asp:Label></td>
           <td></td>
        </tr>
        <tr>
            <td colspan="2">Vendas Relacionadas:</td>
            <td></td>
        </tr>
    </table>
    <br />
    <br />
    <br />
    <br />
    <asp:Label ID="lbTbParcelas" runat="server"></asp:Label>
    <br />
               <asp:GridView EditRowStyle-CssClass="tabelas" CssClass="tabela" runat="server" ID="gvVendasRelacionadas" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
                   <AlternatingRowStyle BackColor="White" />
                   <Columns>
                       <asp:HyperLinkField HeaderText="Nome do Pacote" DataTextField="descricao" DataNavigateUrlFields="codigo" DataNavigateUrlFormatString="cadastroVenda.aspx?vendcod={0}"></asp:HyperLinkField>
                   </Columns>

<EditRowStyle CssClass="tabelas"></EditRowStyle>
                   <FooterStyle BackColor="#CCCC99" />
                   <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                   <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                   <RowStyle BackColor="#F7F7DE" />
                   <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                   <SortedAscendingCellStyle BackColor="#FBFBF2" />
                   <SortedAscendingHeaderStyle BackColor="#848384" />
                   <SortedDescendingCellStyle BackColor="#EAEAD3" />
                   <SortedDescendingHeaderStyle BackColor="#575357" />

                 </asp:GridView>
    <br />


    


</asp:Content>
