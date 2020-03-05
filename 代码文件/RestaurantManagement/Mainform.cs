using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestaurantManagement;

namespace RestaurantManagement
{
    
    public partial class Mainform : Form
    {
        public Mainform()
        {
            InitializeComponent();
           
        }

        private void 个人信息编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Change mf_c=new Change();
            mf_c.ShowDialog();
        }


        private void 查询消费记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
             CheckCost check_cost= new CheckCost();
             check_cost.User = username;
            check_cost.Show();
        }

        
        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        private void Mainform_Load(object sender, EventArgs e)
        {
            this.label4.Text = username;
            string conStr = @"Data Source=.;Initial Catalog=CanteenManagement;Integrated Security=True";
            SqlConnection con = new SqlConnection(conStr);
            string sqlstr = "SELECT PeopleName FROM pelple WHERE PeopleID = '"+username+"'";
            SqlCommand com1= new SqlCommand(sqlstr,con);
            SqlDataAdapter sqldata = new SqlDataAdapter(com1);
            DataSet datset = new DataSet();
            sqldata.Fill(datset);
            this.label3.Text = datset.Tables[0].Rows[0][0].ToString();
            con.Close();
        }

    }
}
