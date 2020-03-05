using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace RestaurantManagement
{
    public partial class Sales : Form
    {
        public Sales()
        {
            InitializeComponent();
        }

        private void GroupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            string uid = Login.userID;
        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection myconn = new SqlConnection();
            SqlCommand mycmd = new SqlCommand();
            string mystr = @"Data Source=.;Initial Catalog=CanteenManagement;Integrated Security=True";
            myconn.ConnectionString = mystr;


            try
            {
                myconn.Open();
                if (comboBox1.Text == "学号")
                {
                    string mysql = "SELECT consume.ConsumeDate,foods.FoodName,canteens.CanteenName,consume.FdcPrice,pelple.PeopleID,pelple.PeopleName FROM consume " +
                                    "LEFT JOIN foods " +
                                    "ON consume.FoodID = foods.FoodID " +
                                    "LEFT JOIN canteens " +
                                    "ON consume.CanteenID = canteens.CanteenID " +
                                    "LEFT JOIN pelple " +
                                    "ON pelple.PeopleID = consume.PeopleID " +
                                    "WHERE consume.PeopleID = '" + textBox1.Text.Trim() + "'";
                    mycmd.CommandText = mysql;
                    mycmd.Connection = myconn;
                    //mycmd.Parameters.Add("@xh",SqlDbType.Char);//添加参数,学号
                    //mycmd.Parameters["@xh"].Value = textBox1.Text;//
                    SqlDataReader myreader = mycmd.ExecuteReader();
                    //开时数据更新
                    this.listView1.BeginUpdate();
                    this.listView1.Items.Clear();
                    //myreader.Read();
                    while (myreader.Read())
                    {
                        ListViewItem lvi = new ListViewItem();//构造一行的对象
                        //添加此行的列信息
                        lvi.Text = myreader[0].ToString().Trim();
                        lvi.SubItems.Add(myreader[1].ToString().Trim());
                        lvi.SubItems.Add(myreader[2].ToString().Trim());
                        lvi.SubItems.Add(myreader[3].ToString().Trim());
                        this.listView1.Items.Add(lvi);
                        textBox4.Text = myreader[4].ToString().Trim();

                        //myreader.Read();
                    }
                    this.listView1.EndUpdate();

                    myreader.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                myconn.Close();
            }
        }
    }
}

