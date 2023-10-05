using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Viagem.Classes
{
    public class cidades
    {
        public DataTable LocalizarCidades(string uf) {

            SqlConnection con = new SqlConnection(banco.GetStrCon());
            string sql = "select * from cidades where uf = @uf order by nome";

            // comandos de ordenação 
            // order by (define qual a ordem que vai retornar no banco )
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@uf", uf);

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