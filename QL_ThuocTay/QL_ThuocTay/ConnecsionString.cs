using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;
using System.Drawing;
using System.Windows.Forms;

namespace QL_ThuocTay
{
    public class ConnecsionString
    {
        static SqlConnection cnn;
        static SqlDataAdapter da;
        static DataSet ds;
        static SqlCommand cmd;
        private static string _Sqlconn;

        //static SqlConnection _Sqlconn = new SqlConnection(Properties.Settings.Default.SqlCon);


        public static void openConnection()
        {
             _Sqlconn =(Properties.Settings.Default.SqlCon);
            cnn = new SqlConnection(_Sqlconn);
            try
            {
                cnn.Open();
            }
            catch
            {/////
                MessageBox.Show("Lỗi", "Không thể kết nối đến cơ sở dữ liệu");
                return;
            }
        }

        public static void executeQuery(String sql)
        {
            cmd = new SqlCommand();
            openConnection();
            try
            {
                cmd.Connection = cnn;
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi", "Không thể thực thi !");
                return;
            }

        }

        public static DataSet getDataSet(String sql)
        {

            openConnection();
            da = new SqlDataAdapter(sql, cnn);
            ds = new DataSet();
            da.Fill(ds);
            cnn.Close();
            return ds;
        }

        public static DataTable getDataTable(String sql)
        {
            openConnection();
            da = new SqlDataAdapter(sql, cnn);
            ds = new DataSet();
            da.Fill(ds);
            cnn.Close();
            return ds.Tables[0];
        }

        public static SqlConnection getConnection()
        {
            return new SqlConnection(_Sqlconn);
        }
    }
}
