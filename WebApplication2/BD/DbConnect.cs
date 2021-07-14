using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto.BD
{
    class DbConnect
    {
        SqlConnection miCnx = null;
        public SqlConnection MiCnx { get => miCnx; set => miCnx = value; }

        public DbConnect()
        {
            MiCnx = new SqlConnection(
            "Data Source=161.22.42.238,54321;Initial Catalog=bbdd_MRO;User ID=sa;Password=123456789Net3;");
            MiCnx.Open();
        }
    }
}