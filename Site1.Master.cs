using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PID_3_Termo
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sessao"] == null)
            {
                lbAcesso.Text = "<a href='entrar.aspx'>Acesse sua Conta</a>";
            }
            else{
                lbAcesso.Text = "<a href='sair.aspx'>Sair</a>";
            }
        }
    }
}