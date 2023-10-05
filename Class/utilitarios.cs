using PID_3_Termo.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Viagem.Classes
{
    public class utilitarios
    {

        public static string GerarMD5(string input)
        {
            MD5 md5Hasher = new MD5CryptoServiceProvider();
            byte[] hash = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
                sb.Append(hash[i].ToString("x2"));
            return sb.ToString().ToLower();
        }
        /* Daqui Pra Baixo Foi Alterado o arquivo por Hilderney */
        public static bool ValidarData(string pdata)
        {
            DateTime data;
            bool ok = false;
            if (DateTime.TryParse(pdata, out data))
            {
                if (Convert.ToDateTime(pdata) > DateTime.Now)
                {
                    ok = true;
                }
            }
            return ok;
        }
        public static string GerarTabelaParcelas(string ValorTotal, string qntParcelas)
        {
            decimal valorParcela, valorTotal = Convert.ToDecimal(ValorTotal), ultimaParcela;
            int parcelas=Convert.ToInt32(qntParcelas);
            decimal valorTotalRound;
            valorParcela = Decimal.Round(valorTotal / parcelas, 2);
            valorTotalRound = valorParcela * (parcelas - 1);
            ultimaParcela = valorTotal - valorTotalRound;
            string tabela = "";

            if (ValorTotal != "")
            {
                tabela = "<table> <th> Parcela </th> <th> Valor </th>";
                for (int i = 1; i <= parcelas; i++)
                {
                    tabela += "<tr> <td>" + i + "ª" + " parcela </td>";
                    if (i != parcelas)
                    {
                        tabela += "<td> R$ " + valorParcela + "</td>";
                    }
                    else
                    {
                        tabela += "<td> R$ " + ultimaParcela + "</td>";
                    }
                    tabela += "</tr>";
                }
                tabela += "</table>";
            }

            return tabela;
        }
        public static string calculaValorTotal(decimal valor, int diarias)
        {
            decimal valorTotal = valor * diarias;
            string lbValorTotal = valorTotal.ToString();
            return lbValorTotal;
        }
        public static string LimpaPagina()
        {
            string valor = "";
            return valor;
        }
        public static string ChecarCliente(string codCliente, out string msgErro)
        {
            // Verifica se o cliente existe
            int cod;
            string nome = "";
            if (int.TryParse(codCliente, out cod))
            {
                cliente cli = new cliente();
                cli.GetCod(cod);
                if (cli.BuscarClienteCod())
                {
                    nome = cli.SetNome();
                    msgErro = "";
                }
                else
                {
                    msgErro = @"Cliente não existe, em caso de duvida acesse <a href='cadastroCliente.aspx'>Cadastro de cliente</a> e realize uma pesquisa";
                }
            }
            else
            {
                msgErro = "Digite um codigo valido";
            }
            return nome;
        }
    }
}