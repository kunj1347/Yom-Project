﻿using System.Data.SqlClient;
using System.Data;

namespace testing.Models
{
    public class WorktextModel
    {
        public string title { get; set; }

        public string name { get; set; }

        public string date { get; set; }

        public string cat { get; set; }

        public string discription1 { get; set; }

        public string heading { get; set; }

        public string discription2 { get; set; }


        SqlConnection con = new SqlConnection("Data Source = .\\SQLEXPRESS ; Database = yom; User Id=sa; Password=123; TrustServerCertificate=True");


        public int insert(string title, string name, string date, string cat, string discription1, string heading , string discription2)
        {
            SqlCommand cmd = new SqlCommand("insert into work_text(title , name , date , cat  , discription1 ,heading , discription2)values('" + title + "', '" + name + "','" + date + "' , '" + cat + "', '" + discription1 + "','" + heading + "', ' " + discription2+ "')", con);
            con.Open();

            return cmd.ExecuteNonQuery();
        }
        public DataSet select()
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[work_text]", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public int Delete(int id)
        {
            SqlCommand cmd = new SqlCommand("delete from [dbo].[work_text] where id = '" + id + "' ", con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }

        public DataSet update(int id)
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].[work_text] where id = '" + id + "' ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public int update_data(int id, string title, string name, string date, string cat, string discription1, string heading, string discription2)
        {
            SqlCommand cmd = new SqlCommand("update [dbo].[work_text] set title = '" + title + "',name = '" + name + "' , date = '" + date + "', cat = '" + cat + "',discription1 = '" + discription1 + "', heading = '"+ heading +"', discription2 = '"+discription2+"' where id = '" + id + "'", con);
            con.Open();

            return cmd.ExecuteNonQuery();
        }

    }
}
