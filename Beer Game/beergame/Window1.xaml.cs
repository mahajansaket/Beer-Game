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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        IList<beerg> ab = new List<beerg> { }; 
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;Integrated Security=True;AttachDbFilename=C:\Users\dell\Documents\Visual Studio 2013\Projects\beergame\beergame\Database1.mdf");
        public Window1()
        {
            InitializeComponent();
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select week,r_cost,w_cost,d_cost,f_cost from game where Week>0", con);
            DataTable dt = new DataTable("beerg");
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dt = ds.Tables[0];
            for(int i=0;i<dt.Rows.Count;i++)
            {
                ab.Add(new beerg { week = Convert.ToInt16(dt.Rows[i]["Week"].ToString()), r_cost=Convert.ToInt16(dt.Rows[i]["r_cost"]), w_cost = Convert.ToInt16(dt.Rows[i]["w_cost"].ToString()), d_cost = Convert.ToInt16(dt.Rows[i]["d_cost"].ToString()), f_cost = Convert.ToInt16(dt.Rows[i]["f_cost"].ToString())});
                //ab.Add(new beerg { week = Convert.ToInt16(dt.Rows[i]["Week"].ToString()), r_cost = Convert.ToInt16(dt.Rows[i]["r_cost"].ToString()), w_cost = Convert.ToInt16(dt.Rows[i]["w_cost"].ToString()), d_cost = Convert.ToInt16(dt.Rows[i]["d_cost"].ToString()), f_cost = Convert.ToInt16(dt.Rows[i]["f_cost"].ToString()) }); 
                //ab.Add(new beerg { week = Convert.ToInt16(dt.Rows[i]["Week"].ToString()), r_co = Convert.ToInt16(dt.Rows[i]["r_cost"].ToString()), w_co = Convert.ToInt16(dt.Rows[i]["w_cost"].ToString()), d_co = Convert.ToInt16(dt.Rows[i]["d_cost"].ToString()), f_co = Convert.ToInt16(dt.Rows[i]["f_cost"].ToString()) });
            }
            beergame.ItemsSource = null;
            beergame.ItemsSource = ab;
            con.Close();
        }
    }
    public class beerg
    {
        public int week { get; set; }
        public int r_cost { get; set; }
        public int w_cost { get; set; }
        public int d_cost { get; set; }
        public int f_cost { get; set; }
    }
}
