using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Viagem.Classes
{
    public class pacote
    {

        private int _codigo;
        private string _Descricao;
        private decimal _valor;
        private int _cidade;

        public void SetCodigo(int codigo)
        {
            _codigo = codigo;
        }

        public int GetCodigo() {

            return _codigo;
        }

        public void SetDescricao(string Descricao)
        {
            _Descricao = Descricao;
        }

        public string GetDescricao() {

            return _Descricao;

        }

        public void SetValor(decimal valor)
        {
            _valor = valor;
        }

        public decimal GetValor() { return _valor; }

        public void SetCidade(int cidade) {
            _cidade = cidade;
        }

        public int GetCidade() {return _cidade;}

        
        public void Gravar()
        {

            SqlConnection con = new SqlConnection(banco.GetStrCon());
            string sql = "insert into pacotes(descricao,valor,cidade) values(@desc, @val, @cid)";
            
            // comandos de ordenação 
            // order by (define qual a ordem que vai retornar no banco )
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@desc", _Descricao);
            cmd.Parameters.AddWithValue("@val", _valor);
            cmd.Parameters.AddWithValue("@cid", _cidade);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();

            dt.Load(dr);
            dr.Close();
            con.Close();        

        }

        public void Atualizar()
        {

            SqlConnection con = new SqlConnection(banco.GetStrCon());
            string sql = "update pacotes set descricao=@desc,valor=@val,cidade=@cid where codigo = @cod";

            // comandos de ordenação 
            // order by (define qual a ordem que vai retornar no banco )

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@desc", _Descricao);
            cmd.Parameters.AddWithValue("@val", _valor);
            cmd.Parameters.AddWithValue("@cid", _cidade);
            cmd.Parameters.AddWithValue("@cod", _codigo);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();

            dt.Load(dr);
            dr.Close();
            con.Close();



        }

        public void Excluir()
        {

            SqlConnection con = new SqlConnection(banco.GetStrCon());
            string sql = "delete from pacotes where codigo = @cod";

            // comandos de ordenação 
            // order by (define qual a ordem que vai retornar no banco )

            SqlCommand cmd = new SqlCommand(sql, con);
         
            cmd.Parameters.AddWithValue("@cod", _codigo);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();

            dt.Load(dr);
            dr.Close();
            con.Close();



        }

        public bool LocalizarPeloCodigo() {

            SqlConnection con = new SqlConnection(banco.GetStrCon());
            string sql = "select * from pacotes where codigo = @cod";
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@cod", _codigo);
            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            bool resultado = false;

            if(dr.Read()){

                _Descricao = dr["descricao"].ToString();
                _valor = Convert.ToDecimal(dr["valor"]);
                _cidade = Convert.ToInt32(dr["cidade"]);
                resultado = true;
            }

            dr.Close();
            con.Close();

            // --------------------------

           
            return resultado;


            }

        public DataTable LocalizarPelaDescricao(){

            SqlConnection con = new SqlConnection(banco.GetStrCon());

            string sql = "select * from pacotes where descricao like @desc order by descricao";
            
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@desc", "%"+ _Descricao + "%");
            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();


            DataTable dt = new DataTable();
            dt.Load(dr);

            dr.Close();
            con.Close();

            return dt;
            
        }
        public DataTable LocalizarPelaCidade(string Nomecidade)
        {

            SqlConnection con = new SqlConnection(banco.GetStrCon());

            string sql = "select * from cidades where nome like @cidade order by nome";

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@cidade", "%" + Nomecidade + "%");
            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {                            
                _cidade = Convert.ToInt32(dr["codigo"]);             
            }

            dr.Close();

            sql = "select * from pacotes where cidade=@cidade order by descricao";
            
            cmd = new SqlCommand(sql, con);
            
            cmd.Parameters.AddWithValue("@cidade", _cidade);
            dr = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(dr);         
            con.Close();

            return dt;

        }

        public DataTable TodosPacotes()
        {
            SqlConnection con = new SqlConnection(banco.GetStrCon());
            string sql = "select * from pacotes order by codigo";
            SqlCommand cmd = new SqlCommand(sql, con);            
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            con.Close();
            return dt;
        }

    }
}