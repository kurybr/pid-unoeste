using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Viagem.Classes;

namespace PID_3_Termo
{
    public partial class cadastroUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["permissao"]) != 5)
            {
                Response.Redirect("entrar.aspx");
            }

            if (!IsPostBack)
            {

                ddlPermissao.DataTextField = "descricao";
                ddlPermissao.DataValueField = "codigo";
                ddlPermissao.DataSource = usuario.NivelPermissao();
                ddlPermissao.DataBind();

            }


        }
        public void limpa()
        {
            tbNome.Text = "";
            tbLogin.Text = "";
            tbEmail.Text = "";
            tbSenha.Text = "";
            tbValidade.Text = "";
            ddlPermissao.SelectedValue = "1";
        }
        protected void btnGravar_Click(object sender, EventArgs e)
        {
            string nome = tbNome.Text;
            string login = tbLogin.Text;
            string senha = tbSenha.Text;
            string status ;
            string email = tbEmail.Text;

            if (Ativo.Checked)
                status = "S";
            else status = "N";


            int permissao;
            DateTime data;
            DateTime vencimento = DateTime.Now; ;
            if (DateTime.TryParse(tbValidade.Text, out data))
                if (int.TryParse(ddlPermissao.SelectedValue, out permissao))
                {
                    vencimento = data;
                    usuario usr = new usuario(nome, login, senha, status, email, vencimento, permissao);
                    if (usr.Gravar())
                    {
                        limpa();
                        lbErro.Text = "Cadastro Realizado com Sucesso";
                    }
                }
                else
                {
                    lbErro.Text = "Permissão Invalida";
                }
            else
            {
                lbErro.Text = "Digite uma data valida, e Futura";

            }
        }

        protected void tbLogin_TextChanged(object sender, EventArgs e)
        {
            usuario usr = new usuario();
            if (usr.ValidaLogin(tbLogin.Text) && Request.QueryString["cod"] == null)
            {
                lbErroLogin.Text = "Login Valido";
                btnGravar.Enabled = true;
                
            }
            else
            {
                lbErroLogin.Text = "Login já existe";
                btnGravar.Enabled = false;                

            }
        }
    }
}