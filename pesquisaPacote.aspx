<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="pesquisaPacote.aspx.cs" Inherits="PID_3_Termo.pesquisaPacote" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        table {
            /*width:400px;*/
            text-align: center;
            vertical-align: bottom;
        }

        .inputGrande {
            height: 45px;
            width: 300px;
        }

        span {
            font-size: 20px;
            color: gray;
            font-weight: bold;
        }

        .gravar {
            height: 50px;
            width: 200px;
            text-align: center;
        }

            .gravar[type="submit"]:disabled {
                background: red;
            }

            .gravar[type="submit"]:enabled {
                background: rgba(209, 209, 209, 0.2);
            }

        .erro {
            color: red;
        }

        .info {
            color: #ff9900;
        }
        .links_internos{
            list-style:none;            
        }
            .links_internos li:hover:nth-child(2n+1) {
                border-bottom: 2px solid red;
               
            }
            .links_internos li:hover:nth-child(2n+2) {
                border-bottom: 2px solid blue;               
            }

        .links_internos li{
            display: inline;
            font-weight: bold;
            margin-left: 30px;
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
        <ul class="links_internos">
            
            <li>
                <asp:Label ID="lbCadastroUsuario" runat="server" Text="Label"></asp:Label></li>
            <!--Nivel de permissão 5-->
            <li><span><a href="cadastroCliente.aspx">Cadastro de Clientes</a></span></li>
            <li><span><a href="cadastroPacotes.aspx">Cadastro de Pacotes</a></span></li>
            <li><span><a href="cadastroVenda.aspx">Cadastro de Venda</a></span></li>
            <li><span><a href="pesquisaPacote">Pesquisa de Pacotes</a></span></li>
        </ul>
        <br />

        <h2>Pagina de Pesquisa de Pacote</h2>
        <h4>Pesquise por uma das caracteristicas a baixo</h4>



        <table>
            <tr>
                <td colspan="2">
                    <span>Editar Pacote, digite o Codigo</span>
                </td>
            </tr>
            <tr>
                <td>

                    <asp:TextBox ID="ttbcodigo" runat="server" CssClass="inputGrande"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnPes_Cod" runat="server" OnClick="btnPesquisar_Click" Text="Editar" CssClass="gravar" /></td>
            </tr>
            <tr>
                <td colspan="2">
                    <span>Pesquisar por Descrição</span>
                </td>
            </tr>
            <tr>
                <td>

                    <asp:TextBox ID="ttbdesc" runat="server" CssClass="inputGrande"></asp:TextBox>


                </td>
                <td>
                    <asp:Button ID="btnpes_desc" runat="server" OnClick="btnpes_desc_Click" Text="Pesquisar" CssClass="gravar" />

                </td>
            </tr>
            <tr>
                <td colspan="2"><span>Pesquisar por Cidade</span></td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="ttbCidade" runat="server" CssClass="inputGrande"></asp:TextBox></td>
                <td>
                    <asp:Button ID="btnPesquisa_Cidade" runat="server" Text="Pesquisar" OnClick="btnPesquisa_Cidade_Click" CssClass="gravar" /></td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvDados" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="codigo" HeaderText="Codigo" />
                            <asp:HyperLinkField DataNavigateUrlFields="codigo" DataNavigateUrlFormatString="pesquisaPacote.aspx?cod={0}" DataTextField="descricao" HeaderText="Descrição" />
                            <asp:BoundField DataField="valor" HeaderText="Valor" />
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                </td>
                <td></td>
            </tr>

        </table>
    </div>
</asp:Content>
