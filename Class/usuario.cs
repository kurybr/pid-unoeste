using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Viagem.Classes
{
    public class usuario
    {

        private int _codigo;
        private string _nome;
        private string _login;
        private string _senha;
        private string _ativo;
        private string _email;
        private DateTime _validade;
        private int _nivel;
        public string GetUsuario()
        {
            return _nome;
        }

        public int GetPermissao() {
            return _nivel;
        }

        public string GetValidade()
        {
            return _validade.ToShortDateString();
        }
        public usuario(){

        }
        public usuario(string nome, string login, string senha, string ativo, string email, DateTime validade, int nivel) {

            _codigo = 0;
            _nome = nome;
            _login = login;
            _senha = senha;
            _ativo = ativo;
            _email = email;
            _validade = validade;
            _nivel = nivel;

        }

        public bool ValidaLogin(string login) {
            SqlConnection con = new SqlConnection(banco.GetStrCon());
            string sql = @"select login from usuarios where login = @login";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@login", login);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                return false;
            }

            con.Close();

            return true;
        }

        public bool Gravar() {

            SqlConnection con = new SqlConnection(banco.GetStrCon());
            string sql = @"insert into usuarios(nome, login, senha, ativo, email, validade, nivel) values(@nome, @login, @senha,
                @ativo, @email, @validade, @nivel)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@nome", _nome);
            cmd.Parameters.AddWithValue("@login", _login);
            cmd.Parameters.AddWithValue("@senha", utilitarios.GerarMD5(_senha));
            cmd.Parameters.AddWithValue("@ativo",_ativo);
            cmd.Parameters.AddWithValue("@email", _email);
            cmd.Parameters.AddWithValue("@validade", _validade);
            cmd.Parameters.AddWithValue("@nivel",_nivel);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();


            return true;
        }

        public bool ValidadorCredenciais(string login, string senha, out string erro) {

            senha = utilitarios.GerarMD5(senha);
            String sql = "select * from usuarios where login=@login and senha=@senha";
            SqlConnection con = new SqlConnection(banco.GetStrCon());
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@senha", senha);
            con.Open();
            erro = "";
            SqlDataReader dr = cmd.ExecuteReader();
            
            if(dr.Read()){

                if (dr["login"].ToString() == login && dr["senha"].ToString() == senha )  {
                    _nome = dr["nome"].ToString();
                    _login = dr["login"].ToString();
                    _senha = dr["senha"].ToString();
                    _ativo = dr["ativo"].ToString();
                    _nivel = Convert.ToInt32(dr["nivel"]);
                    _validade = Convert.ToDateTime(dr["validade"]);
                 
                }
                
            }
            else
            {

                erro = "Usuario ou Senha Errada";
                return false;
                    
                    

             }
            con.Close();

            if (_ativo == "S")
            {
                if (_validade > DateTime.Now) { 
                return true;
                }
                else
                {
                    erro = "Sua Validade Expirou";
                    return false;
                }

            }
            else
            {
                erro = "Seu usuario está inativo";
                return true;
                
            }           

        }



        static public DataTable NivelPermissao() {
            
            SqlConnection con = new SqlConnection(banco.GetStrCon());
            string sql = @"select * from niveis order by descricao";
            SqlCommand cmd = new SqlCommand(sql, con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            con.Close();
            return dt;
        }


    }
}
