<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="cadastroPacotes.aspx.cs" Inherits="PID_3_Termo.cadastroPacotes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
        #conteudo {
            margin: 0 auto;
            width:400px;
            text-align:center;
            
        }
           
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
     <div id="conteudo">
         <table>
         <tr>
             <td></td>
             <td>Codigo</td>
             <td></td>
         </tr>
         <tr>
             <td></td>
             <td><asp:TextBox ID="tbCodigo" runat="server"></asp:TextBox></td>
             <td></td>
         </tr>
         <tr>
             <td></td>
             <td>Descrição</td>
             <td></td>
         </tr>
         <tr>
             <td></td>
             <td><asp:TextBox ID="tbDescricao" runat="server"></asp:TextBox></td>
             <td></td>
         </tr>
         <tr>
             <td></td>
             <td>Valor</td>
             <td></td>
         </tr>
         <tr>
             <td></td>
             <td><asp:TextBox ID="tbValor" runat="server"></asp:TextBox></td>
             <td></td>
         </tr>
         <tr>
             <td></td>
             <td>Estados</td>
             <td></td>
         </tr>
         <tr>
             <td></td>
             <td><asp:DropDownList ID="ddlEstados" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEstados_SelectedIndexChanged">
        </asp:DropDownList></td>
             <td></td>
         </tr>
             <tr>
                 <td></td>
                 <td> Cidades</td>
                 <td></td>
             </tr>
             <tr>
                 <td></td>
                 <td> <asp:DropDownList ID="ddlCidades" runat="server" AutoPostBack="True">
        </asp:DropDownList></td>
                 <td></td>
             </tr>
             <tr>
                 <td><asp:Button ID="btnGravar" runat="server" OnClick="btnGravar_Click" Text="Gravar" /></td>
                 <td><asp:Button ID="btnAtualizar" runat="server" OnClick="btnAtualizar_Click" Text="Atualizar" /></td>
                 <td> <asp:Button ID="btnExcluir" runat="server" Text="Excluir" OnClick="btnExcluir_Click" /></td>
             </tr>
             <tr>
                 <td></td>
                 <td><asp:Button ID="btnPesquisar" runat="server" OnClick="btnPesquisar_Click" Text="Pesquisar" /></td>
                 <td></td>
             </tr>
        
        </table>
    </div>
</asp:Content>
