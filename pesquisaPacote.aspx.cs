using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Viagem.Classes;

namespace PID_3_Termo
{
    public partial class pesquisaPacote : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { 

                if (Session["sessao"] == null)
                    Response.Redirect("entrar.aspx");
                else {
                    lbNomeUsuario.Text = Session["usuario"].ToString();
                    lbValidadeUsuario.Text = Session["validade"].ToString();
                }

                if (Session["permissao"].ToString() == "5")
                {
                    lbCadastroUsuario.Text = @"<a href='cadastroUsuario.aspx'>Cadastro de Usuario</a>";
                }





            }

            if (string.IsNullOrEmpty(Request.QueryString["cod"]))
            {
                
                int codigo;
                if(int.TryParse(Request.QueryString["cod"], out codigo))
                {
                    pacote pac = new pacote();
                    pac.SetCodigo(codigo);

                    gvDados.DataSource = pac.LocalizarPeloCodigo();
                    gvDados.DataBind();
                }




            }

        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            pacote pac = new pacote();
            int codigo;
            int.TryParse(ttbcodigo.Text, out codigo);

            pac.SetCodigo(codigo);
            if (pac.LocalizarPeloCodigo())
            {
                Response.Redirect("pesquisaPacote.aspx?cod=" + pac.GetCodigo().ToString());

            }
        }

        protected void btnpes_desc_Click(object sender, EventArgs e)
        {
            pacote pac = new pacote();

            pac.SetDescricao(ttbdesc.Text);

            gvDados.DataSource = pac.LocalizarPelaDescricao(); // o DataSource recebe o modulo de pesquisa... que é um datatable
            gvDados.DataBind();
        }

        protected void btnPesquisa_Cidade_Click(object sender, EventArgs e)
        {
            pacote pac = new pacote();            

            gvDados.DataSource = pac.LocalizarPelaCidade(ttbCidade.Text); // o DataSource recebe o modulo de pesquisa... que é um datatable
            gvDados.DataBind();
        }

       

     
    }
}