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
    public partial class CheckCost : Form
    {
        public CheckCost()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private string user;
       
        public string User
        {
            get { return user; }
            set { user = value; }
        }

        private void CheckCost_Load(object sender, EventArgs e)
        {
            this.label2.Text = user;
            string conStr = @"Data Source=.;Initial Catalog=CanteenManagement;Integrated Security=True";
            SqlConnection con = new SqlConnection(conStr);
            string sqlstr = "SELECT PeopleName FROM pelple WHERE PeopleID = '" + user + "'";
            con.Open();
                SqlCommand com1 = new SqlCommand(sqlstr, con);
                SqlDataAdapter sqldata = new SqlDataAdapter(com1);
                DataSet datset = new DataSet();
                sqldata.Fill(datset);
                this.label4.Text = datset.Tables[0].Rows[0][0].ToString(); //完成显示界面的个人信息显示
                
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
          float Num = 0,Num_dec=0;
          string conStr = @"Data Source=.;Initial Catalog=CanteenManagement;Integrated Security=True";
            SqlConnection con = new SqlConnection(conStr);
            string sqlstr = "SELECT PeopleName FROM pelple WHERE PeopleID = '" + user + "'";
            string sqlstr1 = "SELECT * FROM Consume WHERE PeopleID='" + user + "'";
            try
            {
                con.Open();
                SqlCommand com1 = new SqlCommand(sqlstr, con);
                SqlCommand com2 = new SqlCommand(sqlstr1, con);

                SqlDataAdapter sqldata = new SqlDataAdapter(com1);
                DataSet datset = new DataSet();
                sqldata.Fill(datset);
                this.label4.Text = datset.Tables[0].Rows[0][0].ToString(); //完成显示界面的个人信息显示
                
                SqlDataReader datareadr = com2.ExecuteReader();
                this.listView1.BeginUpdate();
                this.listView1.Items.Clear();

                
                while (datareadr.Read())
                {
                    ListViewItem lvi = new ListViewItem(); //构造一行的对象
                    //添加此行的列信息
                    lvi.Text = datareadr[0].ToString().Trim();
                    lvi.SubItems.Add(datareadr[1].ToString().Trim());
                    lvi.SubItems.Add(datareadr[2].ToString().Trim());
                    lvi.SubItems.Add(datareadr[3].ToString().Trim());
                    lvi.SubItems.Add(datareadr[4].ToString().Trim());
                    lvi.SubItems.Add(datareadr[5].ToString().Trim());
                    Num += (float) datareadr[4];
                    Num_dec += (float)datareadr[5];
                    this.listView1.Items.Add(lvi);
                }
                this.listView1.EndUpdate();
                this.label8.Text = Num.ToString();
                this.label9.Text = Num_dec.ToString();
                this.label10.Text = (((Num - Num_dec) / Num )*100)+"%".ToString();
                datareadr.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

    }
   



}
