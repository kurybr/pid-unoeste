<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="entrar.aspx.cs" Inherits="PID_3_Termo.entrar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="loginPage">
        <table>
            <tr>
                <td><span>ESPAÇO ADIMINISTRATIVO</span></td>
            </tr>        
            <tr>
                <td><span> SEJA BEM VINDO </span></td>
            </tr>
            <tr>
                <td><img src="imagens/perfil.png" alt="Perfil" /></td>
            </tr> 
            <tr>
                <td> <asp:TextBox ID="ttbUsuarios" runat="server" placeholder="Usuário" CssClass="inputClear"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:TextBox ID="ttbSenha" runat="server" TextMode="Password" placeholder="Senha" CssClass="inputClear"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Button ID="btnEntrar" runat="server"  Text="Entrar" OnClick="btnEntrar_Click"  CssClass="inputLogar"/></td>
            </tr>
            <tr>
                <td><asp:Label ID="lbErro" runat="server" Text=""></asp:Label></td>
            </tr>
    </table>
    </div>
</asp:Content>
