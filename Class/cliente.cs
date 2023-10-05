using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Viagem;

namespace PID_3_Termo.Class
{
    public class cliente
    {
        private string _nome;
        private string _email;
        private string _cpf;
        private int _cod;

        public string SetNome() { return _nome; }
        public string SetEmail() { return _email; }
        public string SetCPF() { return _cpf; }
        public int SetCod() { return _cod; }
        public void GetCod(int cod) { _cod = cod; }
        //public void GetNome(string nome) { _nome = nome; }
        public void GetCPF(string cpf) { _cpf = cpf; }       

        public cliente() { }
        public cliente(string nome, string email, string cpf)
        {
            _nome = nome;
            _email = email;
            _cpf = cpf; 
        }
        public cliente(string nome, string email, string cpf, int cod) {
            _nome = nome;
            _email = email;
            _cpf = cpf;
            _cod = cod;
        }

        public bool Gravar()
        {

            SqlConnection con = new SqlConnection(banco.GetStrCon());
            string sql = @"insert into clientes(nome, email, cpf) values(@nome, @email, @cpf)";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            
                cmd.Parameters.AddWithValue("@nome", _nome);
                cmd.Parameters.AddWithValue("@email", _email);
                cmd.Parameters.AddWithValue("@cpf", _cpf);


                if (cmd.ExecuteNonQuery() > 0)
                {
                    con.Close();
                    return true;
                }
                else
                {
                    con.Close();
                    return false;
                }    


            
        }

        public bool Atualizar() {

            SqlConnection con = new SqlConnection(banco.GetStrCon());
            string sql = @"update clientes set nome=@nome, email=@email, cpf=@cpf where codigo=@cod";
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@nome", _nome);
            cmd.Parameters.AddWithValue("@email", _email);
            cmd.Parameters.AddWithValue("@cpf", _cpf);
            cmd.Parameters.AddWithValue("@cod", _cod);

            con.Open();
            if (cmd.ExecuteNonQuery() > 0)                
            {
                con.Close();
                return true;
            }            
            else
            { 
                con.Close();
                return false;
            }                
        }

        public bool Excluir()
        {
            SqlConnection con = new SqlConnection(banco.GetStrCon());
            string sql = "delete from pacotes where codigo = @cod";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@cod", _cod);
            con.Open();
            if (cmd.ExecuteNonQuery() > 0)
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }    

        }

        public bool BuscarClienteCod() {
            SqlConnection con = new SqlConnection(banco.GetStrCon());
            string sql = "select * from clientes where codigo = @cod";
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@cod", _cod);
            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            bool resultado = false;

            if (dr.Read())
            {

                _nome = dr["nome"].ToString();
                _email = dr["email"].ToString();
                _cpf = dr["cpf"].ToString();
                resultado = true;
            }

            dr.Close();
            con.Close();
            return resultado;
        }
        public bool BuscarClienteCPF() {
            SqlConnection con = new SqlConnection(banco.GetStrCon());
            string sql = "select * from clientes where cpf = @cpf";
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@cpf", _cpf);
            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            bool resultado = false;

            if (dr.Read())
            {
                _cod = Convert.ToInt32(dr["codigo"]);
                _nome = dr["nome"].ToString();
                _email = dr["email"].ToString();
                _cpf = dr["cpf"].ToString();
                resultado = true;
            }

            dr.Close();
            con.Close();
            return resultado;
            
        }
        
    }
}