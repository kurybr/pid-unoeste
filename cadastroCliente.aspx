<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="cadastroCliente.aspx.cs" Inherits="PID_3_Termo.cadastroCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <span>
              Bem vindo
              <asp:Label ID="lbNomeUsuario" runat="server" Text="" CssClass="info"></asp:Label>
              | 
              Seu Usuário é valido até
              <asp:Label ID="lbValidadeUsuario" runat="server" Text="" CssClass="info"></asp:Label>

          </span>
     <table>
         <tr>
             <td>Codigo do Cliente :</td>
                    <td>
                        <asp:TextBox ID="tbCod" runat="server"></asp:TextBox>
                    </td>
         </tr>
                <tr>
                    <td>Nome do Cliente :</td>
                    <td>
                        <asp:TextBox ID="tbNome" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Email:</td>
                     <td>
                        <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td>CPF:</td>
                     
                     <td>
                        <asp:TextBox ID="tbCPF" runat="server"></asp:TextBox>
                    </td>
                </tr>
         </table>
              <asp:Button ID="brnGravar" runat="server" Text="Gravar" OnClick="brnGravar_Click" />
              <asp:Button ID="btnAtualiza" runat="server" OnClick="btnAtualiza_Click" Text="Atualizar" />
              <asp:Button ID="btnExclui" runat="server" OnClick="btnExclui_Click" Text="Excluir" />
              <br />
     <br />
     Selecione o Tipo de Pesquisa<asp:RadioButtonList ID="rblTipoPesquisa" runat="server">
         <asp:ListItem Value="cpf">CPF</asp:ListItem>
         <asp:ListItem Value="cod">CODIGO</asp:ListItem>
     </asp:RadioButtonList>
     <br />
              <asp:Button ID="btnPesquisa" runat="server" OnClick="btnPesquisa_Click" Text="Pesquisa" />
              <br />
              <asp:Label ID="lbErro" runat="server"></asp:Label>
</asp:Content>
