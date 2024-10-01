using System.Data.SqlClient;
using System.Data;

namespace testing.Models
{
    public class CommentModel
    {

        public string name { get; set; }

        public string country { get; set; }

        public string city { get; set; }

        public string msg { get; set; }




        SqlConnection con = new SqlConnection("Data Source = .\\SQLEXPRESS ; Database = yom; User Id=sa; Password=123; TrustServerCertificate=True");


        public int insert(string name , string country , string city , string msg)
        {
            SqlCommand cmd = new SqlCommand("insert into msg(name , country , city , msg)values('" + name+ "', '" + country+ "','" + city+ "' , '" + msg + "')", con);
            con.Open();

            return cmd.ExecuteNonQuery();
        }
        public DataSet select()
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[msg]", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public int Delete(int id)
        {
            SqlCommand cmd = new SqlCommand("delete from [dbo].[msg] where id = '" + id + "' ", con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }

        //public DataSet update(int id)
        //{
        //    SqlCommand cmd = new SqlCommand("select * from [dbo].[msg] where id = '" + id + "' ", con);
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    return ds;
        //}

        //public int update_data(int id, string title, string name, string date, string cat, string discription, string filename)
        //{
        //    SqlCommand cmd = new SqlCommand("update [dbo].[msg] set title = '" + title + "',name = '" + name + "' , date = '" + date + "', cat = '" + cat + "',discription = '" + discription + "', image = '" + filename + "' where id = '" + id + "'", con);
        //    con.Open();

        //    return cmd.ExecuteNonQuery();
        //}
    }
}
