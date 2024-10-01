using System.Data;
using System.Data.SqlClient;

namespace testing.Models
{   
    public class HomeModel
    {

        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }



        SqlConnection con = new SqlConnection("Data Source = .\\SQLEXPRESS ; Database = yom; User Id=sa; Password=123; TrustServerCertificate=True");

        public int insert(string name, string email, string password)
        {
            SqlCommand cmd = new SqlCommand("insert into register(name,email,password)values('" + name + "','" + email + "','" + password + "'  )", con);
            con.Open();

            return cmd.ExecuteNonQuery();
        }
        public DataSet select(string email, string password)
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[register] where email = '" + email + "' and password = '" + password + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        //public DataSet select()
        //{
        //    SqlCommand cmd = new SqlCommand("select * from [dbo].[slider]", con);
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    return ds;
        //}

    }
}
