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
using RestaurantManagement;

namespace RestaurantManagement
{
    public partial class Change : Form
    {
        public Change()
        {
            InitializeComponent();
        }


       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string conStr = @"Data Source=.;Initial Catalog=CanteenManagement;Integrated Security=True";
            SqlConnection con = new SqlConnection(conStr);
            string userID = textBox2.Text.Trim();
            string usernewPwd = textBox1.Text.Trim();
            string useroldPwd = textBox3.Text.Trim();
            string sqlStr = "SELECT COUNT(*) FROM users WHERE UsersID ='" + userID + "'AND UsersCode = '" + useroldPwd + "' AND userstype = 1";
            string sqlStr1 = "UPDATE users SET UsersCode= '" + usernewPwd + "'WHERE UsersID = '" + userID + "'";
            SqlCommand comm = new SqlCommand(sqlStr, con);
            try
            {
                con.Open();
                int flag = (int)comm.ExecuteScalar();
                if (flag == 1)
                {
                    SqlCommand comm1 = new SqlCommand(sqlStr1, con);

                    int i = (int)comm1.ExecuteNonQuery();//返回第一行的第一列，由此来判断
                    MessageBox.Show("修改成功!");
                    this.Close();  //修改完成后自动关闭
                }
                else
                {
                    MessageBox.Show("错误的用户或密码!", "提示");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                con.Close();
                
            }
        }
    }
}
