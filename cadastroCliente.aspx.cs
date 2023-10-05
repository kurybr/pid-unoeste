using PID_3_Termo.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PID_3_Termo
{
    public partial class cadastroCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["permissao"]) > 1)
            {
                Response.Redirect("entrar.aspx");
            }
        }

        protected void brnGravar_Click(object sender, EventArgs e)
        {
            string nome = tbNome.Text;
            string email = tbEmail.Text;
            string cpf = tbCPF.Text;
            if (nome != "" && email != "" && cpf != "")
            {
                cliente cli = new cliente(nome, email, cpf);
                if (cli.Gravar())
                {
                    lbErro.Text = "Cadastro Realizado com Sucesso";
                    Limpa();
                }
            }
            else
            {
                lbErro.Text = "Preencha todos os campos";

               
            }
        }

        private void Limpa()
        {
            tbCod.Text = "";
            tbCod.Enabled = true;
            tbCPF.Enabled = true;
            tbNome.Text = "";
            tbEmail.Text = "";
            tbCPF.Text = "";
        }
        protected void btnAtualiza_Click(object sender, EventArgs e)
        {
            string nome = tbNome.Text;
            string email = tbEmail.Text;
            string cpf = tbCPF.Text;
            int cod;
            cliente cli;
            if (int.TryParse(tbCod.Text, out cod)){
                cli = new cliente(nome, email, cpf,cod);
                if (cli.Atualizar())
                {
                    lbErro.Text = "Cadastro Atualizado com Sucesso";
                    Limpa();
                }

            }
            else
                lbErro.Text = "Digite codigo valido";

            
        }

        protected void btnExclui_Click(object sender, EventArgs e)
        {
            int cod;
            cliente cli = new cliente() ;
            if (int.TryParse(tbCod.Text, out cod))
                cli.GetCod(cod);

            else
                lbErro.Text = "Digite codigo valido";
        }

        protected void btnPesquisa_Click(object sender, EventArgs e)
        {
            if (rblTipoPesquisa.SelectedValue == "cod")
            {
                int cod;
                cliente cli = new cliente();
                if (int.TryParse(tbCod.Text, out cod))
                {
                    cli.GetCod(cod);
                    cli.BuscarClienteCod();
                    tbNome.Text = cli.SetNome();
                    tbEmail.Text = cli.SetEmail();
                    tbCPF.Text = cli.SetCPF();
                    tbCod.Enabled = false;
                }
                else
                    lbErro.Text = "Digite codigo valido";
            }
            else if (rblTipoPesquisa.SelectedValue == "cpf") {

                string cpf = tbCPF.Text;
                cliente cli = new cliente();
                cli.GetCPF(cpf);

                if (cli.BuscarClienteCPF()) { 
                tbNome.Text = cli.SetNome();
                tbEmail.Text = cli.SetEmail();
                tbCPF.Text = cli.SetCPF();
                tbCod.Text = cli.SetCod().ToString();
                tbCod.Enabled = false; // Não deve ser modificado
                tbCPF.Enabled = false; // Não deve ser modificado, se a busca foi feita utilizando ele como chave
                }
                else
                lbErro.Text = "Digite um CPF valido";


            }
        }

        
    }
}