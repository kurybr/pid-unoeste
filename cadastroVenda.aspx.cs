using PID_3_Termo.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Viagem.Classes;

namespace PID_3_Termo
{
    public partial class cadastroVenda : System.Web.UI.Page
    {
        static public decimal ValorPacote; // Variavel responsavel por ficar com o valor do Pacote para ser usado em todos os modulos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /* CARREGAR PACOTES */
                pacote pac = new pacote();
                    ddlPacotes.DataTextField = "descricao";
                    ddlPacotes.DataValueField = "codigo";
                    ddlPacotes.DataSource = pac.TodosPacotes();
                    ddlPacotes.DataBind();
                    ddlPacotes.Items.Insert(0, new ListItem("Selecione um pacote", "0"));
                
                /* CARREGAR PARCELAS */
                for (int i = 1; i <= 12; i++)
                    {
                        ddlParcelas.Items.Add(i.ToString());
                    }

                /* CARREGAR FORMAS DE PAGAMENTOS */
                venda Vendas = new venda();
                rblFormaPagamento.DataTextField = "descricao";
                rblFormaPagamento.DataValueField = "codigo";
                rblFormaPagamento.DataSource = Vendas.TodosTiposParcelas();
                rblFormaPagamento.DataBind();
            }

            /* Buscar Pacote por Código */
            if (!string.IsNullOrEmpty(Request.QueryString["paccod"]) && lbValor.Text=="")
            {
                pacote pac = new pacote();
                int paccod;
                if (int.TryParse(Request.QueryString["paccod"], out paccod))
                {
                    pac.SetCodigo(paccod);
                    if (pac.LocalizarPeloCodigo())
                    {
                        ddlPacotes.SelectedValue = paccod.ToString();
                        lbValor.Text = pac.GetValor().ToString("N2");
                    }    
                }
            }

            /* Buscar Código da Venda */

            if (!string.IsNullOrEmpty(Request.QueryString["cod"]) && lbNomedoCliente.Text == "")
            {
                venda V = new venda();
                cliente C = new cliente();
                int codigo;

                if (int.TryParse(Request.QueryString["cod"], out codigo))
                {
                    V.GetCliente(codigo);
                    V.RecuperarVenda();
                }

                C.GetCod(V.SetCliente());
                if (C.BuscarClienteCod())
                {
                    lbNomedoCliente.Text = C.SetNome();
                    tbCodigoCliente.Text = codigo.ToString();
                    tbCodigoCliente.Enabled = false;
                }

                ddlPacotes.SelectedValue = V.SetPacotes().ToString();
                lbValorTotal.Text = V.SetValorTotal();
                tbDiarias.Text = V.SetDiarias();
                ttbDataViagem.Text = V.SetDataViagem();
                rblFormaPagamento.SelectedValue = V.SetFormaPagamento();
                ddlParcelas.SelectedValue = V.SetParcelas().ToString();
            }
        }
        protected void tbCodigoCliente_TextChanged(object sender, EventArgs e)
        {
            /* CHECAR CLIENTE */
            string codCliente = tbCodigoCliente.Text;
            string msgErro;
            string nomeCliente = utilitarios.ChecarCliente(codCliente, out msgErro);
            lbNomedoCliente.Text = nomeCliente;
            lbErroCliente.Text = msgErro;
        }        
        protected void ddlPacotes_SelectedIndexChanged(object sender, EventArgs e)
        {
            pacote pac = new pacote();
            int codigo;
            if (int.TryParse(ddlPacotes.SelectedValue, out codigo))
            {
                pac.SetCodigo(codigo);
                pac.LocalizarPeloCodigo();
                ValorPacote = pac.GetValor();
                lbValor.Text = ValorPacote.ToString();
            }
            if (Request.QueryString["cod"] != "")
            {
                tbDiarias.Text = utilitarios.LimpaPagina(); ;
                ttbDataViagem.Text = utilitarios.LimpaPagina(); ;
                lbErroDiarias.Text = utilitarios.LimpaPagina(); ;
                lbValorTotal.Text = utilitarios.LimpaPagina(); ;
            }
        }
        protected void ttbDataViagem_TextChanged(object sender, EventArgs e)
        {
            string msgDataErrada = "";
            DateTime dataAtual = DateTime.Now, data;

            if (utilitarios.ValidarData(ttbDataViagem.Text))
            {
                data = Convert.ToDateTime(ttbDataViagem.Text);
            }
            else
            {
                msgDataErrada = "Data Inválida.";
            }
            lbErroData.Text = msgDataErrada;
        }
        protected void tbDiarias_TextChanged(object sender, EventArgs e)
        {
            pacote pac = new pacote();
            int qtdDiarias;
            if (int.TryParse(tbDiarias.Text, out qtdDiarias))
                lbValorTotal.Text = utilitarios.calculaValorTotal(ValorPacote, qtdDiarias);
            else if (tbDiarias.Text != "")
                lbErroDiarias.Text = "Digite um valor valido";
            else
                lbErroDiarias.Text = "";
        }
        protected void rblFormaPagamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblFormaPagamento.SelectedValue == "1")
            {
                ddlParcelas.Enabled = false;
                ddlParcelas.SelectedValue = "1";
            }
            else
            {
                ddlParcelas.Enabled = true;
            }
        }
        protected void ddlParcelas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tabela;
            tabela = utilitarios.GerarTabelaParcelas(lbValorTotal.Text, ddlParcelas.SelectedValue);
            lbTbParcelas.Text = tabela;
        }
        protected void btnGravar_Click(object sender, EventArgs e)
        {
            int codigoCliente, pacote, diarias, Formapagamento, parcelas;
            string data = ttbDataViagem.Text;
            DateTime dataViagem;
            decimal valortotal;
            if (int.TryParse(tbCodigoCliente.Text, out codigoCliente))
            {
                if (DateTime.TryParse(ttbDataViagem.Text, out dataViagem))
                {
                    if (utilitarios.ValidarData(data))
                    {
                        if (int.TryParse(ddlPacotes.SelectedValue, out pacote))
                        {
                            if (int.TryParse(tbDiarias.Text, out diarias))
                            {
                                if (decimal.TryParse(lbValorTotal.Text, out valortotal))
                                {
                                    if (int.TryParse(rblFormaPagamento.SelectedValue, out Formapagamento))
                                    {
                                        if (int.TryParse(ddlParcelas.SelectedValue, out parcelas))
                                        {
                                            venda V = new venda(codigoCliente, pacote, dataViagem, diarias, valortotal, Formapagamento, parcelas);
                                            V.GeradordeParcelas(parcelas, valortotal);
                                            V.gravarVenda();
                                        };
                                    };
                                }
                            }
                        }
                    }
                }
            }

        }
        protected void btnAtualizar_Click(object sender, EventArgs e)
        {
             int codigoCliente, pacote,diarias,Formapagamento,parcelas;
            DateTime dataViagem;
            decimal valortotal;

            if (int.TryParse(tbCodigoCliente.Text, out codigoCliente))
            {

                if (DateTime.TryParse(ttbDataViagem.Text, out dataViagem))
                {
                    if (dataViagem >= DateTime.Now)
                    {

                        if (int.TryParse(ddlPacotes.SelectedValue, out pacote))
                        {

                            if (int.TryParse(tbDiarias.Text, out diarias))
                            {

                                if (decimal.TryParse(lbValorTotal.Text, out valortotal))
                                {

                                    if (int.TryParse(rblFormaPagamento.SelectedValue, out Formapagamento))
                                    {

                                        if (int.TryParse(ddlParcelas.SelectedValue, out parcelas))
                                        {
                                            venda V = new venda(codigoCliente, pacote, dataViagem, diarias, valortotal, Formapagamento, parcelas);
                                            V.GeradordeParcelas(parcelas, valortotal);
                                            V.AlterarVenda();

                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }


        }
        protected void btnExcluir_Click(object sender, EventArgs e)
        {

        }
        protected void ttbCPFCliente_TextChanged(object sender, EventArgs e)
        {
            cliente cli = new cliente();
            venda V = new venda();
            string cpf = ttbCPFCliente.Text;
            cli.GetCPF(cpf);
            if (cli.BuscarClienteCPF())
            {
                lbNomeCliente.Text = cli.SetNome();
                V.GetCliente(cli.SetCod());
                gvVendasRelacionadas.DataSource = V.PesquisaVendaRelacionadasAoCliente();
                gvVendasRelacionadas.DataBind();
            }
            else
            {
                lbErroCPF.Text = "Cliente não encontrado, por favor digite um CPF valido";
            }
        }
        

        
    }
}