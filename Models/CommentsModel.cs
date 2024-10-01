using System.Data.SqlClient;
using System.Data;

namespace testing.Models
{
    public class CommentsModel
    {
        public string title { get; set; }

        public string name { get; set; }

        public string country { get; set; }

        public string state { get; set; }

        SqlConnection con = new SqlConnection("Data Source = .\\SQLEXPRESS ; Database = yom; User Id=sa; Password=123; TrustServerCertificate=True");


        public int insert(string title, string name, string country , string state)
        {
            SqlCommand cmd = new SqlCommand("insert into comments(comments , name ,country ,state)values('" + title + "', '" + name + "','" + country + "' , '"+ state+"')", con);
            con.Open();

            return cmd.ExecuteNonQuery();
        } 

        public DataSet select()
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[comments]", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

    }
}
