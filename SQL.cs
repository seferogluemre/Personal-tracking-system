using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelSistemi
{
     class SQL
    {
        public SqlConnection baglantı()
        {
            SqlConnection baglantı = new SqlConnection("Data Source=EMRE_SEFEROGLU\\SQLEXPRESS;Initial Catalog=PersonelTakip;Integrated Security=True");
            baglantı.Open();
            return baglantı;
        }
    }
}
