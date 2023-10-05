<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="cadastroUsuario.aspx.cs" Inherits="PID_3_Termo.cadastroUsuario" %>

<%@ Register Src="~/checkboxOnOFF.ascx" TagPrefix="uc1" TagName="checkboxOnOFF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
        table {
            /*width:400px;*/
            text-align:center;
        }
        
        .inputGrande{
            height: 45px;
            width: 300px;
        }
        span{
            font-size:20px;
            color:gray;
            font-weight:bold;
        }
        .gravar{
             height:50px;
            width:200px;
            text-align:center;
        }
        .gravar[type="submit"]:disabled{
            background:red ;
           
        }
          .gravar[type="submit"]:enabled{
            background:rgba(209, 209, 209, 0.2);
        }
          .erro{
              color:red;

          }
    </style>
    <link href="Stylesheet/Kury.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
         <span>
              Bem vindo
              <asp:Label ID="lbNomeUsuario" runat="server" Text="" CssClass="info"></asp:Label>
              | 
              Seu Usuário é valido até
              <asp:Label ID="lbValidadeUsuario" runat="server" Text="" CssClass="info"></asp:Label>

          </span>
            <table>
                <tr>
                    <td></td>
                    <td>
                        <asp:TextBox ID="tbNome" runat="server" placeholder="Nome do Usuario" CssClass="inputGrande"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                     <td>
                        <asp:TextBox ID="tbLogin" runat="server" AutoPostBack="True" OnTextChanged="tbLogin_TextChanged" placeholder="Login" CssClass="inputGrande"></asp:TextBox>

            

                    </td>
                    <td><asp:Label ID="lbErroLogin" runat="server" CssClass="erro"></asp:Label></td>
                </tr>
                <tr>
                    <td></td>
                     <td>
                        <asp:TextBox ID="tbSenha" runat="server" TextMode="Password" placeholder="Senha" CssClass="inputGrande"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    
                     <td>
                        <span> Estado do Usuario</span>
                         <br />
                         <uc1:checkboxOnOFF runat="server" id="Ativo" />                     

                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                     <td>
                        <asp:TextBox ID="tbEmail" runat="server" placeholder="Email" CssClass="inputGrande"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                     <td>
                         <span>Data de Expiração da conta</span>
                         <br />
                        <asp:TextBox ID="tbValidade" runat="server" TextMode="Date" CssClass="inputGrande"></asp:TextBox>                         
                    </td>
                    <td></td>
                </tr> 
                <tr>
                    <td></td>
                    <td>
                        <span>Selecione o tipo de Permissão do usuário</span>
                        <br />
                        <asp:DropDownList ID="ddlPermissao" runat="server" CssClass="inputGrande"></asp:DropDownList>
                    </td>
                    <td></td>
                </tr>             
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnGravar" runat="server" Text="Gravar" OnClick="btnGravar_Click" CssClass="gravar"/>
                    </td>
                    <td><asp:Label ID="lbErro" runat="server"></asp:Label></td>
                </tr>  

            </table>


            

            <br />
            

        </div>
</asp:Content>
