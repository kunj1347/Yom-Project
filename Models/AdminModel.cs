using System.Data.SqlClient;
using System.Data;

namespace testing.Models
{
    public class AdminModel
    {
        public string email { get; set; }
        public string password { get; set; }

        //public string title { get; set; }

        //public string discription { get; set; }

        //public string img {  get; set; }

        SqlConnection con = new SqlConnection("Data Source = .\\SQLEXPRESS ; Database = yom; User Id=sa; Password=123; TrustServerCertificate=True");
        public DataSet select(string email, string password)
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[admin] where email = '" + email + "' and password = '" + password + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

     

        //public int insert(string title, string discription , string img)
        //{
        //    SqlCommand cmd = new SqlCommand("insert into slider(title , discription ,img)values('"+title+"', '"+discription+"','"+img+"')",con);
        //    con.Open();

        //    return cmd.ExecuteNonQuery();
        //}

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
