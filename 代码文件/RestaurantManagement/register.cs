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
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string conStr = @"Data Source=.;Initial Catalog=CanteenManagement;Integrated Security=True";
            SqlConnection con = new SqlConnection(conStr);
            string userID = textBoxyhm.Text.Trim();
            string userPwd = textBoxmm.Text.Trim();
            string userPwd2 = textBoxqrmm.Text.Trim();
            string userName = textBoxxm.Text.Trim();
            string usersf = comboBoxsf.Text.Trim();
            int userSf;
            if (usersf == "本科生")
            {
                userSf = 1;
            }
            else if (usersf == "研究生")
            {
                userSf = 2;
            }
            else if (usersf == "教职工")
            {
                userSf = 3;
            }
            else
            {
                userSf = 4;
            }
            bool ismanager = checkBoxgly.Checked;
            if ((userID.Length == 4) && (userPwd.Length == 6) && (userPwd == userPwd2))//符合格式，四位ID，6位密码
            {
                //检查数据库是否以及有注册过
                string sqlStr_1 = "SELECT COUNT(*) FROM users WHERE UsersID = '" + userID + "'";
                SqlCommand comm = new SqlCommand(sqlStr_1,con);
                try
                {
                    con.Open();
                    int num = (int)comm.ExecuteScalar();
                    if (num != 0)//说明已经注册过
                    {
                        MessageBox.Show("账号已被注册！");
                    }
                    else//未被注册过，可以添加进数据库中
                    {
                        if (ismanager)//是管理员注册
                        {
                            string sqlStr_2 = "INSERT INTO users VALUES('" + userID + "','" + userPwd
                                + "',2)";//添加管理员
                            string sqlStr_3 = "INSERT INTO pelple VALUES('" + userID + "','" + userName
                                + "'," + userSf.ToString() + ")";
                            SqlCommand comm_1 = new SqlCommand(sqlStr_3,con);
                            SqlCommand comm_2 = new SqlCommand(sqlStr_2,con);
                            if ((comm_1.ExecuteNonQuery() > 0) && (comm_2.ExecuteNonQuery() > 0))
                            {
                                MessageBox.Show("注册为管理员成功！");
                                this.Close();
                            }
                            else
                                MessageBox.Show("注册失败！");
                        }
                        else
                        {
                            string sqlStr_2 = "INSERT INTO users VALUES('" + userID + "','" + userPwd
                                + "',1)";//添加普通用户
                            string sqlStr_3 = "INSERT INTO pelple VALUES('" + userID + "','" + userName
                                + "'," + userSf.ToString() + ")";
                            SqlCommand comm_1 = new SqlCommand(sqlStr_3, con);
                            SqlCommand comm_2 = new SqlCommand(sqlStr_2, con);
                            if ((comm_1.ExecuteNonQuery() > 0) && (comm_2.ExecuteNonQuery() > 0))
                            {
                                MessageBox.Show("注册为用户成功！");
                                this.Close();
                            }
                            else
                                MessageBox.Show("注册失败！");
                        }
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
                MessageBox.Show("注册失败：格式错误或确认密码不匹配");
            } 
        }
    }
}
