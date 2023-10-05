using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Viagem;


namespace PID_3_Termo.Class
{
    public class venda
    {
        private DateTime _dataVenda;
        private int _cliente;
        private int _pacote;
        private DateTime _dataViagem;
        private int _diarias;
        private decimal _valorTotal;
        private int _FormaPagamento;
        private int _parcelas;
        private int _codigo;
        private DateTime _vencimento;
        private decimal _valorParcela;
        private decimal _ultimaParcela;

        public int SetCliente() { return _cliente; }
        public int SetPacotes() { return _pacote; }
        public string SetValorTotal() { return _valorTotal.ToString();}
        public string SetDataViagem() { return _dataViagem.Date.ToShortDateString(); }
        public int SetParcelas() { return _parcelas; }
        public string SetDiarias() { return _diarias.ToString(); }
        public string SetFormaPagamento() { return _FormaPagamento.ToString(); }
        
        public void GetCliente(int codigo)
        {
            _cliente = codigo;
        }
        
        public venda() { }
        public int getIdentity(SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand("select @@IDENTITY as id", con);
            Object i = cmd.ExecuteScalar();
            if (i == DBNull.Value)
                return 0;
            else
                return Convert.ToInt32(i);
        }

        /// <summary>
        /// Carrega as informações da venda para a Classe
        /// </summary>
        /// <param name="cliente"></param>
        /// <param name="pacote"></param>
        /// <param name="dataViagem"></param>
        /// <param name="diarias"></param>
        /// <param name="ValorTotal"></param>
        /// <param name="formaPagamento"></param>
        /// <param name="Parcela"></param>
        public venda(int cliente, int pacote, DateTime dataViagem, int diarias, decimal ValorTotal, int formaPagamento, int Parcela) { 
                    
            _cliente = cliente;
            _pacote = pacote;
            _dataViagem = dataViagem;
            _diarias = diarias;
            _valorTotal = ValorTotal;
            _FormaPagamento = formaPagamento;
            _parcelas = Parcela;

        }

        public DataTable TodosTiposParcelas()
        {
            SqlConnection con = new SqlConnection(banco.GetStrCon());
            string sql = "select * from formaspagamento order by codigo";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            con.Close();
            return dt;
        }
        
        public void GeradordeParcelas(int qtdParc, decimal valorTotal)
        {
            decimal valTotalRound;
            _valorParcela = Decimal.Round(valorTotal / qtdParc, 2);
            valTotalRound = _valorParcela * (qtdParc - 1);
            _ultimaParcela = valorTotal - valTotalRound;
            
        }

        public bool gravarVenda()
        {
            SqlTransaction trans = null;
            try
            {
                banco banc = new banco();
                SqlConnection con ;
                con = banc.GetConection();
                string sql = "insert into vendas(data,cliente,pacote,dataviagem,diarias,valortotal,formapagamento,parcelas)";
                sql += "values(@data,@cliente,@pacote,@dataviagem,@diarias,@valorTotal,@formapagamento,@parcelas)";
                
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Transaction = trans;
                trans = con.BeginTransaction();
                _dataVenda = DateTime.Now.Date;
                cmd.Parameters.AddWithValue("@data", _dataVenda);
                cmd.Parameters.AddWithValue("@cliente", _cliente);
                cmd.Parameters.AddWithValue("@pacote", _pacote);
                cmd.Parameters.AddWithValue("@dataviagem", _dataViagem);
                cmd.Parameters.AddWithValue("@diarias", _diarias);
                cmd.Parameters.AddWithValue("@valorTotal", _valorTotal);
                cmd.Parameters.AddWithValue("@formapagamento", _FormaPagamento);
                cmd.Parameters.AddWithValue("@parcelas", _parcelas);

                cmd.ExecuteNonQuery();
                _codigo = getIdentity(con); // Pega Codigo da Venda     

                sql = "delete from contasareceber where venda = @venda";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@venda", _codigo);
                cmd.ExecuteNonQuery();
                _vencimento = DateTime.Now.Date;

                for (int p = 1; p <= _parcelas; p++)
                {
                    sql = "insert into contasareceber(venda, parcela,vencimento,valor)";
                    sql += "values(@venda,@parcela,@vencimento,@valor)";
                    cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@venda", _codigo);
                    cmd.Parameters.AddWithValue("@parcela", p);
                    cmd.Parameters.AddWithValue("@vencimento", _vencimento);
                    if (p == _parcelas)
                        _valorParcela = _ultimaParcela;
                    cmd.Parameters.AddWithValue("@valor", _valorParcela);
                    cmd.ExecuteNonQuery();
                    _vencimento = _vencimento.AddMonths(1);
                }
                trans.Commit();
                con.Close();
                return false;
            }
            catch
            {
                trans.Rollback();
                return false;
            }

        }
        public bool AlterarVenda()
        {
            try
            { 
            SqlConnection con = new SqlConnection(banco.GetStrCon());
            string sql = "update vendas set pacote = @pacote,dataviagem = @dataviagem,diarias=@diarias,valortotal=@valorTotal,formapagamento=@formapagamento,parcelas=@parcelas where codigo=@codigo";
            

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@codigo", _codigo); 
            cmd.Parameters.AddWithValue("@pacote", _pacote);
            cmd.Parameters.AddWithValue("@dataviagem", _dataViagem);
            cmd.Parameters.AddWithValue("@diarias", _diarias);
            cmd.Parameters.AddWithValue("@valorTotal", _valorTotal);
            cmd.Parameters.AddWithValue("@formapagamento", _FormaPagamento);
            cmd.Parameters.AddWithValue("@parcelas", _parcelas);
            con.Open();
            cmd.ExecuteNonQuery();
            _codigo = getIdentity(con); // Pega Codigo da Venda     

            sql = "delete from contasareceber where venda = @venda";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@venda", _codigo);
            cmd.ExecuteNonQuery();
            _vencimento = DateTime.Now.Date;

            for (int p = 1; p <= _parcelas; p++)
            {
                sql = "insert into contasareceber(venda, parcela,vencimento,valor)";
                sql += "values(@venda,@parcela,@vencimento,@valor)";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@venda", _codigo);
                cmd.Parameters.AddWithValue("@parcela", p);
                cmd.Parameters.AddWithValue("@vencimento", _vencimento);
                if (p == _parcelas)
                    _valorParcela = _ultimaParcela;
                cmd.Parameters.AddWithValue("@valor", _valorParcela);
                cmd.ExecuteNonQuery();
                _vencimento = _vencimento.AddMonths(1);
            }
            con.Close();
            return true;
                }
            catch 
            {
                return false;
            }
        }
        public bool ExcluirVenda()
        {
            SqlConnection con = new SqlConnection(banco.GetStrCon());
            string sql = "delete from contasareceber where venda = @codigo)";
            
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.Parameters.AddWithValue("@codigo", _codigo);            
            cmd.ExecuteNonQuery();
            

            
            sql = "delete from contasareceber where codigo = @codigo)";
            cmd = new SqlCommand(sql, con);            
            cmd.Parameters.AddWithValue("@codigo", _codigo);
            cmd.ExecuteNonQuery();

            con.Close();


            return false;
        }

        public void RecuperarVenda()
        {
            SqlConnection con = new SqlConnection(banco.GetStrCon());

            string sql = "select * from vendas where cliente = @codigo order by data";

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@codigo", _cliente);
            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                _cliente = Convert.ToInt32(dr["cliente"]);
                _pacote = Convert.ToInt32(dr["pacote"]) ;
                _dataViagem = Convert.ToDateTime(dr["dataviagem"]);
                _diarias = Convert.ToInt32(dr["diarias"]);
                _valorTotal = Convert.ToDecimal(dr["valortotal"]);
                _FormaPagamento = Convert.ToInt32(dr["formapagamento"]);
                _parcelas = Convert.ToInt32(dr["parcelas"]);
            }
            dr.Close();
            con.Close();

        }
        public DataTable PesquisaVendaRelacionadasAoCliente()
        {
           
            SqlConnection con = new SqlConnection(banco.GetStrCon());

            string sql = @"SELECT           vendas.codigo, clientes.nome AS Cliente, vendas.data, vendas.dataviagem, vendas.diarias, vendas.valortotal, vendas.parcelas, pacotes.descricao, pacotes.valor, cidades.nome AS Cidade, formaspagamento.descricao AS DescricaoFormaPagamento
                           FROM             vendas INNER JOIN pacotes ON vendas.pacote = pacotes.codigo
                                            INNER JOIN formaspagamento ON vendas.formapagamento = formaspagamento.codigo 
                                            INNER JOIN clientes ON vendas.cliente = clientes.codigo 
                                            INNER JOIN cidades ON pacotes.cidade = cidades.codigo
                                            INNER JOIN estados ON cidades.uf = estados.uf
                           WHERE clientes.codigo = @codigo";

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@codigo", _cliente);
            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            
            DataTable dt = new DataTable();
            dt.Load(dr);
            con.Close();

            return dt;
           
        }
    }
}