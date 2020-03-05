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
    public partial class EditRestaurantEditD : Form
    {

        public string dishID;

        public string DishID
        {
            get
            {
                return dishID;
            }
            set
            {
                dishID = value;
            }
        }

        public EditRestaurantEditD()
        {
            InitializeComponent();
            //MessageBox.Show(DishID);
            //textBox1.Text = this.dishID;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //this.textBox1.Text = this.dishID;
            
            string Mystr = @"Data Source=.;Initial Catalog=CanteenManagement;Integrated Security=True";
            SqlConnection con = new SqlConnection(Mystr);
            string newName = textBox2.Text;
            string newType = comboBox1.Text;
            string newPrice = textBox3.Text;
            string newzkj = textBox4.Text;
            string sqlStr = "UPDATE foods SET FoodName = '" + newName + "',Foodtype = '" +
                newType + "',FoodPrice = '" + newPrice + "',FdcPrice = '" + newzkj + "' " + 
                "WHERE FoodID = '" + dishID + "'";
            SqlCommand comm = new SqlCommand(sqlStr, con);
            try
            {
                con.Open();
                if(comm.ExecuteNonQuery()>0)
                {
                    MessageBox.Show("修改成功!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("修改失败!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        private void EditRestaurantEditD_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = this.dishID;
            SqlConnection Myconn = new SqlConnection();
            SqlCommand Mycmd = new SqlCommand();
            string Mystr = @"Data Source=.;Initial Catalog=CanteenManagement;Integrated Security=True";
            Myconn.ConnectionString = Mystr;
            //this.restID = comboBox1.Text.Trim();
            //查询餐厅中所有餐点

            try
            {
                Myconn.Open();
                string Mysql = " SELECT foods.FoodID,FoodName,Foodtype,FoodPrice,FdcPrice FROM foods " + 
                                 "WHERE foods.FoodID = '" + dishID + "' ";
                Mycmd.CommandText = Mysql;
                Mycmd.Connection = Myconn;

                SqlDataReader myreader = Mycmd.ExecuteReader();

                //myreader.Read();
                if(myreader.Read())
                {
                    this.textBox2.Text = myreader[1].ToString().Trim();
                    this.comboBox1.Text = myreader[2].ToString().Trim();
                    this.textBox3.Text = myreader[3].ToString().Trim();
                    this.textBox4.Text = myreader[4].ToString().Trim();
                }
  

                myreader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Myconn.Close();
            }
        }
    }
}
