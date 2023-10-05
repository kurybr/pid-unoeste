using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Viagem
{
    public class banco
    {
        //private static string _srtCon = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\kury_love\documents\visual studio 2013\Projects\PID 3 Termo\App_Data\bancodados.mdf;Integrated Security=True";
        private static string _srtCon = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\UNOESTE\3 semestre\PID3\PID 3 Termo\App_Data\bancodados.mdf;Integrated Security=True";
        
        public static string GetStrCon() {
            return _srtCon;
        }

        public SqlConnection GetConection()
        {
            return new SqlConnection(_srtCon);
        }

    }
}