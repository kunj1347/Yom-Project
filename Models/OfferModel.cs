using System.Data;
using System.Data.SqlClient;

namespace testing.Models
{
    public class OfferModel
    {
        public string icon { get; set; }
        public string title { get; set; }
        public string discription { get; set; }


        SqlConnection con = new SqlConnection("Data Source = .\\SQLEXPRESS ; Database = yom; User Id=sa; Password=123; TrustServerCertificate=True");


        public int insert(string title, string discription, string icon)
        {
            SqlCommand cmd = new SqlCommand("insert into offer(title , discription ,icon)values('" + title + "', '" + discription + "','" + icon + "')", con);
            con.Open();

            return cmd.ExecuteNonQuery();
        }

        public DataSet select()
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[offer]", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds2 = new DataSet();
            da.Fill(ds2);
            return ds2;
        }

        public DataSet update_o(int id)
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[offer] where id = '" + id + "' ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public int update_data_o(int id, string title, string discription, string icon)
        {
            SqlCommand cmd = new SqlCommand("update [dbo].[offer] set title = '" + title + "',discription = '" + discription + "', icon = '" + icon + "' where id = '" + id + "'", con);
            con.Open();

            return cmd.ExecuteNonQuery();
        }
        public int Delete(int id)
        {
            SqlCommand cmd = new SqlCommand("delete from [dbo].[offer] where id = '" + id + "' ", con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }
    }
}
