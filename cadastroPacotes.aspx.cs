using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Viagem.Classes;

namespace PID_3_Termo
{
    public partial class cadastroPacotes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["permissao"]) < 2)
            {
                Response.Redirect("entrar.aspx");
            }


            if (!string.IsNullOrEmpty(Request.QueryString["cod"]) && tbCodigo.Text == "")
            {

                pacote pac = new pacote();
                tbCodigo.Text = Request.QueryString["cod"];
                pac.SetCodigo(Convert.ToInt32(Request.QueryString["cod"]));
                pac.LocalizarPeloCodigo();

                tbDescricao.Text = pac.GetDescricao();
                tbValor.Text = pac.GetValor().ToString();
                ddlCidades.SelectedValue = pac.GetCidade().ToString();

            }


            if (!IsPostBack)
            {

                estado est = new estado();

                ddlEstados.DataTextField = "nome";
                ddlEstados.DataValueField = "uf";
                ddlEstados.DataSource = est.TodosEstados();
                ddlEstados.DataBind();
                ddlEstados.Items.Insert(0, new ListItem("Selecione um estado", "0"));

                ddlCidades.Enabled = false;

            };

        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            pacote pac = new pacote();

            pac.SetCidade(Convert.ToInt32(ddlCidades.SelectedValue));

            pac.SetDescricao(tbDescricao.Text);

            pac.SetValor(Convert.ToDecimal(tbValor.Text));

            pac.Gravar();
        }

        protected void btnAtualizar_Click(object sender, EventArgs e)
        {
            pacote pac = new pacote();

            pac.SetCodigo(Convert.ToInt32(tbCodigo.Text));
            pac.SetCidade(Convert.ToInt32(ddlCidades.SelectedValue));
            pac.SetDescricao(tbDescricao.Text);
            pac.SetValor(Convert.ToDecimal(tbValor.Text));

            pac.Atualizar();
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            pacote pac = new pacote();

            pac.SetCodigo(Convert.ToInt32(tbCodigo.Text));

            pac.Excluir();
        }

        protected void ddlEstados_SelectedIndexChanged(object sender, EventArgs e)
        {
            cidades cid = new cidades(); // Objeto criado

            ddlCidades.DataTextField = "nome";
            ddlCidades.DataValueField = "codigo";
            ddlCidades.DataSource = cid.LocalizarCidades(ddlEstados.SelectedValue); // recuperar as informações e joga para a lista
            ddlCidades.DataBind(); // aparece as informações na tela
            ddlCidades.Items.Insert(0, new ListItem("Selecione uma cidade", "0"));

            if (ddlEstados.SelectedValue != "0")
            {
                ddlCidades.Enabled = true;
            }
            else
                ddlCidades.Enabled = false;
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            Response.Redirect("pesquisaPacote.aspx");
        }
    }
}