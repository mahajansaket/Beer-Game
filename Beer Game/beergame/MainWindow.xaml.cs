using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Data.OleDb;

namespace beergame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IList<gamebeer> aaa = new List<gamebeer> { };
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;Integrated Security=True;AttachDbFilename=C:\Users\dell\Documents\Visual Studio 2013\Projects\beergame\beergame\Database1.mdf");
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int a = Convert.ToInt32(inco.Text);
            int b = Convert.ToInt32(rord.Text);
            int c = Convert.ToInt32(word.Text);
            int d = Convert.ToInt32(dord.Text);
            int f = Convert.ToInt32(ford.Text);
            int g = Convert.ToInt32(week.Text);
            g = g - 1;
            /*SqlDataAdapter sda = new SqlDataAdapter("Select r_in, w_in, d_in, f_in, r_del, w_del, d_del, f_del, r_bo, w_bo, d_bo, f_bo from game where week = "+g,con);
            DataTable dt = new DataTable("gamebeer");
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dt = ds.Tables[0];
            //MessageBox.Show("pika");
            for (int i = 0; i < dt.Rows.Count;i++ )
            {
                MessageBox.Show("pika");
                aaa.Add(new gamebeer { r_del = Convert.ToInt32(dt.Rows[i]["r_del"].ToString()), w_del = Convert.ToInt32(dt.Rows[i]["w_del"].ToString()), d_del = Convert.ToInt32(dt.Rows[i]["d_del"].ToString()), f_del = Convert.ToInt32(dt.Rows[i]["f_del"].ToString()), r_inv = Convert.ToInt32(dt.Rows[i]["r_in"].ToString()), w_inv = Convert.ToInt32(dt.Rows[i]["w_in"].ToString()), d_inv = Convert.ToInt32(dt.Rows[i]["d_in"].ToString()), f_inv = Convert.ToInt32(dt.Rows[i]["f_in"].ToString()), r_bo = Convert.ToInt32(dt.Rows[i]["r_bo"].ToString()), w_bo = Convert.ToInt32(dt.Rows[i]["w_bo"].ToString()), d_bo = Convert.ToInt32(dt.Rows[i]["d_bo"].ToString()), f_bo = Convert.ToInt32(dt.Rows[i]["f_bo"].ToString()) });
            }*/
            con.Open();
            SqlCommand cmd = new SqlCommand("Select r_total_in, w_total_in, d_total_in, f_total_in, r_in, w_in, d_in, f_in, r_del, w_del, d_del, f_del, r_bo, w_bo, d_bo, f_bo, r_total_del, w_total_del, d_total_del, f_total_del, f_order from game where week = " + g, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            while(rdr.Read())
            {
                //int pqr = (int)rdr["r_del"];
                int r_inc_del = (int)rdr["w_del"];
                int w_inc_del = (int)rdr["d_del"];
                int d_inc_del = (int)rdr["f_del"];
                int f_inc_del = (int)rdr["f_order"];
                int r_avail = ((int)rdr["r_in"]) + r_inc_del;
                int w_avail = ((int)rdr["w_in"]) + w_inc_del;
                int d_avail = ((int)rdr["d_in"]) + d_inc_del;
                int f_avail = ((int)rdr["f_in"]) + f_inc_del;
                int r_incom_or = a;
                int w_incom_or = b;
                int d_incom_or = c;
                int f_incom_or = d;
                int r_your_del;
                int w_your_del;
                int d_your_del;
                int f_your_del;
                if((int)rdr["r_bo"]+r_incom_or<r_avail)
                {
                    r_your_del = (int)rdr["r_bo"] + r_incom_or;
                }
                else
                {
                    r_your_del = r_avail;
                }
                if ((int)rdr["w_bo"] + w_incom_or < w_avail)
                {
                    w_your_del = (int)rdr["w_bo"] + w_incom_or;
                }
                else
                {
                    w_your_del = w_avail;
                }
                if ((int)rdr["d_bo"] + d_incom_or < d_avail)
                {
                    d_your_del = (int)rdr["d_bo"] + d_incom_or;
                }
                else
                {
                    d_your_del = d_avail;
                }
                if ((int)rdr["f_bo"] + f_incom_or < f_avail)
                {
                    f_your_del = (int)rdr["f_bo"] + f_incom_or;
                }
                else
                {
                    f_your_del = f_avail;
                }
                int r_totin = (int)rdr["r_total_in"] + a;
                int w_totin = (int)rdr["w_total_in"] + b;
                int d_totin = (int)rdr["d_total_in"] + c;
                int f_totin = (int)rdr["f_total_in"] + d;
                int r_back_o = r_totin - ((int)rdr["r_total_del"] + r_your_del);
                int w_back_o = w_totin - ((int)rdr["w_total_del"] + w_your_del);
                int d_back_o = d_totin - ((int)rdr["d_total_del"] + d_your_del);
                int f_back_o = f_totin - ((int)rdr["f_total_del"] + f_your_del);
                int r_totdel = ((int)rdr["r_total_del"] + r_your_del);
                int w_totdel = ((int)rdr["w_total_del"] + w_your_del);
                int d_totdel = ((int)rdr["d_total_del"] + d_your_del);
                int f_totdel = ((int)rdr["f_total_del"] + f_your_del);
                int r_inven = r_avail - r_your_del;
                int w_inven = w_avail - w_your_del;
                int d_inven = d_avail - d_your_del;
                int f_inven = f_avail - f_your_del;
                int r_cos = (r_back_o * 2) + r_inven;
                int w_cos = (w_back_o * 2) + w_inven;
                int d_cos = (d_back_o * 2) + d_inven;
                int f_cos = (f_back_o * 2) + f_inven;

                con.Close();

                MessageBox.Show("All the values have been calculated.");

                con.Open();
                //SqlCommand srd = new SqlCommand("insert into game (Week,r_inc_d,r_av,r_inc_o,r_bo,r_in,r_cost,r_order,r_del,w_inc_d,w_av,w_inc_o,w_bo,w_in,w_cost,w_order,w_del,d_inc_d,d_av,d_inc_o,d_bo,d_in,d_cost,d_order,d_del,f_inc_d,f_av,f_inc_o,f_bo,f_in,f_cost,f_order,f_del,) values (" +g+ "," + r_inc_del + "," + r_avail + "," + r_incom_or + "," + r_back_o + "," + r_inven + "," + r_cos + "," + b + "," + r_your_del + "," + w_inc_del + "," + w_avail + "," + w_incom_or + "," + w_back_o + "," + w_inven + "," + w_cos + "," + c + "," + w_your_del + "," + d_inc_del + "," + d_avail + "," + d_incom_or + "," + d_back_o + "," + d_inven + "," + d_cos + "," + d + "," + d_your_del + "," + f_inc_del + "," + f_avail + "," + f_incom_or + "," + f_back_o + "," + f_inven + "," + f_cos + "," + f + "," + f_your_del + ")", con);
                //srd.ExecuteNonQuery();
                g = g + 1;
                SqlCommand srd = new SqlCommand("insert into game values (" + g + "," + r_inc_del + "," + r_avail + "," + r_incom_or + "," + r_back_o + "," + r_inven + "," + r_totin + "," + r_cos + "," + b + "," + r_your_del + "," + r_totdel + "," + 
                                                w_inc_del + "," + w_avail + "," + w_incom_or + "," + w_back_o + "," + w_inven + "," + w_totin + "," + w_cos + "," + c + "," + w_your_del + "," + w_totdel + "," +
                                                d_inc_del + "," + d_avail + "," + d_incom_or + "," + d_back_o + "," + d_inven + "," + d_totin + "," + d_cos + "," + d + "," + d_your_del + "," + d_totdel + "," +
                                                f_inc_del + "," + f_avail + "," + f_incom_or + "," + f_back_o + "," + f_inven + "," + f_totin + "," + f_cos + "," + f + "," + f_your_del + "," + f_totdel + ")", con);
                srd.ExecuteNonQuery();
                con.Close();
                //this.Close();
                //MessageBox.Show(r_avail.ToString());
            }
            //con.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window1 mw = new Window1();
            mw.Show();
        }
    }

    public class gamebeer
    {
        public int r_del { get; set; }
        public int w_del { get; set; }
        public int d_del { get; set; }
        public int f_del { get; set; }
        public int r_inv { get; set; }
        public int w_inv { get; set; }
        public int d_inv { get; set; }
        public int f_inv { get; set; }
        public int r_bo { get; set; }
        public int w_bo { get; set; }
        public int d_bo { get; set; }
        public int f_bo { get; set; }
        public int r_tdel { get; set; }
        public int w_tdel { get; set; }
        public int d_tdel { get; set; }
        public int f_tdel { get; set; }
        public int r_tin { get; set; }
        public int w_tin { get; set; }
        public int d_tin { get; set; }
        public int f_tin { get; set; }
        public int f_order { get; set; }
    }
}
