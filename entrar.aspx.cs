using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Viagem.Classes;

namespace PID_3_Termo
{
    public partial class entrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sessao"] != null)          
                Response.Redirect("pesquisaPacote.aspx");            
          
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            usuario usr = new usuario();

            string resposta;
            if (usr.ValidadorCredenciais(ttbUsuarios.Text, ttbSenha.Text, out resposta))
            {
                Session["usuario"] = usr.GetUsuario();
                Session["permissao"] = usr.GetPermissao().ToString();  // Vai analisar o nivel de permissão do usuario, e liberar apenas as funções necessarias
                Session["sessao"] = "Ativa";
                Session["validade"] = usr.GetValidade();
                Response.Redirect("pesquisaPacote.aspx");

            }
            else
            {
                lbErro.Text = resposta;
            }
        }
    }
}