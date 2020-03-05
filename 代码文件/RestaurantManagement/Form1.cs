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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        public static string userID;

        private void Label3_Click(object sender, EventArgs e)
        {
                        

        }

        private void Label2_Click(object sender, EventArgs e)
        {
            

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string conStr = @"Data Source=.;Initial Catalog=CanteenManagement;Integrated Security=True";
            SqlConnection con = new SqlConnection(conStr);
            string userID = textBoxyhm.Text.Trim();
            string userPwd = textBoxmm.Text.Trim();
            
            if (ManageCheckBox.Checked == false)//普通用户登录
            {
                string sqlStr = "SELECT COUNT(*) FROM users WHERE UsersID = '" + userID
                    + "' AND UsersCode = '" + userPwd + "' AND userstype = 1";
                SqlCommand comm = new SqlCommand(sqlStr,con);
                try
                {
                    con.Open();
                    int flag = (int)comm.ExecuteScalar();
                    if (flag == 1)
                    {
                        Mainform mf_1 = new Mainform();
                        mf_1.Username = userID;
                        mf_1.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("密码或用户名错误！请重新输入", "警告", MessageBoxButtons.OKCancel);
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
            else
            {
                string sqlStr = "SELECT COUNT(*) FROM users WHERE UsersID = '" + userID
                    + "' AND UsersCode = '" + userPwd + "' AND userstype = 2";
                SqlCommand comm = new SqlCommand(sqlStr, con);
                try
                {
                    con.Open();
                    int flag = (int)comm.ExecuteScalar();
                    if (flag == 1)
                    {
                        MainFormManager mfm_1 = new MainFormManager();
                        mfm_1.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("密码或用户名错误！请重新输入", "警告", MessageBoxButtons.OKCancel);
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

        private void Button2_Click(object sender, EventArgs e)
        {   
             register rg_1 = new register();
             rg_1.ShowDialog();          
        }
    }
}


