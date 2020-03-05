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
    public partial class EditUsersEditUser : Form
    {

        public string stuID;

        public string StuID
        {
            get
            {
                return stuID;
            }
            set
            {
                stuID = value;
            }
        }

        public EditUsersEditUser()
        {
            InitializeComponent();
            //显示选中信息
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //确认修改
        private void Button1_Click(object sender, EventArgs e)
        {
            string Mystr = @"Data Source=.;Initial Catalog=CanteenManagement;Integrated Security=True";
            SqlConnection con = new SqlConnection(Mystr);

            string peopleID = this.textBox3.Text;
            string newUserType = this.comboBox2.Text;
            string newPeopleType = this.comboBox1.Text;
            string newName = this.textBox4.Text;
            string newPwd = this.textBox5.Text;

            int peopletypeflag;
            if (newPeopleType == "本科生")
            {
                peopletypeflag = 1;
            }
            else if (newPeopleType == "研究生")
            {
                peopletypeflag = 2;
            }
            else if (newPeopleType == "教职工")
            {
                peopletypeflag = 3;
            }
            else
            {
                peopletypeflag = 4;
            }

            int usertypeFlag = 1;
            if (newUserType == "普通用户")
            {
                usertypeFlag = 1;
            }
            else
            {
                usertypeFlag = 2;//管理员
            }

            string sqlStr = "UPDATE pelple SET PeopleName = '" + newName + "',PeopleType = '" +
                peopletypeflag + "' WHERE pelple.PeopleID = '" + peopleID + "'  " + 
                "UPDATE users SET UsersCode = '" + newPwd + "', userstype = '" + usertypeFlag + "' " + 
                "WHERE UsersID = '" + peopleID + "'";
            SqlCommand comm = new SqlCommand(sqlStr, con);
            try
            {
                con.Open();
                if (comm.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("修改成功!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("修改失败!");
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

        //窗口初始化时显示原有信息
        private void EditUsersEditUser_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(this.stuID);

            SqlConnection Myconn = new SqlConnection();
            SqlCommand Mycmd = new SqlCommand();
            string Mystr = @"Data Source=.;Initial Catalog=CanteenManagement;Integrated Security=True";
            Myconn.ConnectionString = Mystr;

            try
            {
                Myconn.Open();
                string Mysql = "SELECT pelple.PeopleID,pelple.PeopleName,users.UsersCode," +
                        "USERTYPE = CASE WHEN users.userstype = 1 THEN '普通用户' ELSE '管理员' END" +
                        ",PEOPLETYPE = CASE " +
                        "WHEN pelple.PeopleType = 1 THEN '本科生' " +
                        "WHEN pelple.PeopleType = 2 THEN '研究生' " +
                        "WHEN pelple.PeopleType = 3 THEN '教职工' " +
                        "ELSE '校外人员' END " +
                        "FROM pelple " +
                        "LEFT JOIN users " +
                        "ON pelple.PeopleID = users.UsersID " +
                        "WHERE pelple.PeopleID = '" + this.stuID +
                        "' "; ;
                Mycmd.CommandText = Mysql;
                Mycmd.Connection = Myconn;

                SqlDataReader myreader = Mycmd.ExecuteReader();

                //myreader.Read();
                if(myreader.Read())
                {
                    this.textBox3.Text = myreader[0].ToString().Trim();
                    this.textBox4.Text = myreader[1].ToString().Trim();
                    this.textBox5.Text = myreader[2].ToString().Trim();
                    this.comboBox2.Text = myreader[3].ToString().Trim();
                    this.comboBox1.Text = myreader[4].ToString().Trim();
                    
                    
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
