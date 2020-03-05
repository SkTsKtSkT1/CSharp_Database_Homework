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
    public partial class EditUsers : Form
    {
        public EditUsers()
        {
            InitializeComponent();
            if (this.checkBox7.Checked)
            {
                this.textBox1.ReadOnly = false;
                this.groupBox1.Enabled = false;
                this.groupBox2.Enabled = false;
            }
            else
            {
                this.textBox1.ReadOnly = true;
                this.groupBox1.Enabled = true;
                this.groupBox2.Enabled = true;
            }
        }

        private void Buttonshuaxin_Click(object sender, EventArgs e)
        {
            if (this.checkBox7.Checked == true)
            {
                SqlConnection myconn = new SqlConnection();
                SqlCommand mycmd = new SqlCommand();
                string mystr = @"Data Source=.;Initial Catalog=CanteenManagement;Integrated Security=True";
                myconn.ConnectionString = mystr;

                    try
                    {
                        myconn.Open();
                        string mysql = "SELECT pelple.PeopleID,pelple.PeopleName,users.UsersCode," +
                        "USERTYPE = CASE WHEN users.userstype = 1 THEN '普通用户' ELSE '管理员' END" +
                        ",PEOPLETYPE = CASE " +
                        "WHEN pelple.PeopleType = 1 THEN '本科生' " +
                        "WHEN pelple.PeopleType = 2 THEN '研究生' " +
                        "WHEN pelple.PeopleType = 3 THEN '教职工' " +
                        "ELSE '校外人员' END " +
                        "FROM pelple " +
                        "LEFT JOIN users " +
                        "ON pelple.PeopleID = users.UsersID " +
                        "WHERE pelple.PeopleID = '" + textBox1.Text.Trim() +
                        "' ";

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
                            lvi.SubItems.Add(myreader[4].ToString().Trim());
                            this.listView1.Items.Add(lvi);

                            //myreader.Read();
                        }
                        this.listView1.EndUpdate();

                        myreader.Close();

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
            else
            {
                this.textBox1.Clear();
                SqlConnection myconn = new SqlConnection();
                SqlCommand mycmd = new SqlCommand();
                string mystr = @"Data Source=.;Initial Catalog=CanteenManagement;Integrated Security=True";
                myconn.ConnectionString = mystr;

                //初始化附加字符串
                string typeStr = "";//人员类型
                string userStr = "";//用户类型
                                    //
                int typeCheckedNum = 0;
                int userCheckedNum = 0;

                foreach (Control c in this.groupBox1.Controls)
                {
                    if (c is CheckBox)
                    {
                        CheckBox cc = c as CheckBox;
                        if (cc.Checked)//被选中,添加字符串
                        {
                            int userFlag = 1;
                            if (cc.Text == "普通用户")
                            {
                                userFlag = 1;
                            }
                            else
                            {
                                userFlag = 2;//管理员
                            }
                            if (userCheckedNum == 0)
                            {
                                userStr += " users.userstype = ";
                                userStr += userFlag.ToString();
                                userStr += " ";
                            }
                            else
                            {
                                userStr += " OR users.userstype = ";
                                userStr += userFlag.ToString();
                                userStr += " ";
                            }
                            userCheckedNum += 1;
                        }
                    }
                }

                foreach (Control c in this.groupBox2.Controls)
                {
                    if (c is CheckBox)
                    {
                        CheckBox cc = c as CheckBox;
                        if (cc.Checked)//被选中,添加字符串
                        {
                            int userFlag = 1;
                            if (cc.Text == "本科生")
                            {
                                userFlag = 1;
                            }
                            else if (cc.Text == "研究生")
                            {
                                userFlag = 2;
                            }
                            else if (cc.Text == "教职工")
                            {
                                userFlag = 3;
                            }
                            else
                            {
                                userFlag = 4;
                            }
                            if (typeCheckedNum == 0)
                            {
                                typeStr += " pelple.PeopleType = ";
                                typeStr += userFlag.ToString();
                                typeStr += " ";
                            }
                            else
                            {
                                typeStr += " OR pelple.PeopleType = ";
                                typeStr += userFlag.ToString();
                                typeStr += " ";
                            }
                            typeCheckedNum += 1;
                        }
                    }
                }

                if (userCheckedNum == 0)
                {
                    MessageBox.Show("未选择用户类型!");
                }
                else if (typeCheckedNum == 0)
                {
                    MessageBox.Show("未选择人员类型!");
                }
                else
                {
                    try
                    {
                        myconn.Open();
                        string mysql = "SELECT pelple.PeopleID,pelple.PeopleName,users.UsersCode," +
                        "USERTYPE = CASE WHEN users.userstype = 1 THEN '普通用户' ELSE '管理员' END" +
                        ",PEOPLETYPE = CASE " +
                        "WHEN pelple.PeopleType = 1 THEN '本科生' " +
                        "WHEN pelple.PeopleType = 2 THEN '研究生' " +
                        "WHEN pelple.PeopleType = 3 THEN '教职工' " +
                        "ELSE '校外人员' END " +
                        "FROM pelple " +
                        "LEFT JOIN users " +
                        "ON pelple.PeopleID = users.UsersID " +
                        "WHERE (" +
                        typeStr +
                        ") " +
                        " AND (" +
                        userStr +
                        ") ";

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
                            lvi.SubItems.Add(myreader[3].ToString().Trim());//////
                            lvi.SubItems.Add(myreader[4].ToString().Trim());
                            this.listView1.Items.Add(lvi);

                            //myreader.Read();
                        }
                        this.listView1.EndUpdate();

                        myreader.Close();

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

        private void Buttonjingquechaxun_Click(object sender, EventArgs e)
        {
            EditUsersPreciseQuery EUPQ_1 = new EditUsersPreciseQuery();
            EUPQ_1.Show();
        }

        //新增
        private void Buttonxinzeng_Click(object sender, EventArgs e)
        {
            EditUsersNewUser EUNU_1 = new EditUsersNewUser();
            EUNU_1.Show();
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CheckBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox7.Checked)
            {
                this.textBox1.ReadOnly = false;
                this.groupBox1.Enabled = false;
                this.groupBox2.Enabled = false;
            }
            else
            {
                this.textBox1.ReadOnly = true;
                this.groupBox1.Enabled = true;
                this.groupBox2.Enabled = true;
            }
        }

        //修改
        private void Button2_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count != 0)
            {
                string IDtoDelete = this.listView1.SelectedItems[0].Text;
                DialogResult dr = MessageBox.Show("确定删除此用户?", "提醒", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    SqlConnection myconn = new SqlConnection();

                    string mystr = @"Data Source=.;Initial Catalog=CanteenManagement;Integrated Security=True";
                    myconn.ConnectionString = mystr;

                    string sqlstr = "ALTER TABLE pelple NOCHECK CONSTRAINT ALL " +
                                    "ALTER TABLE consume NOCHECK CONSTRAINT ALL " +
                                     "DELETE FROM users " +
                                     "WHERE UsersID = '" + IDtoDelete + "' " + 
                                     "DELETE FROM pelple " +
                                     "WHERE PeopleID = '" + IDtoDelete + "' " +
                                     "DELETE FROM consume " +
                                     "WHERE PeopleID = '" + IDtoDelete + "' " +
                                     "ALTER TABLE pelple CHECK CONSTRAINT ALL " +
                                     "ALTER TABLE consume CHECK CONSTRAINT ALL";
                    SqlCommand comm = new SqlCommand(sqlstr, myconn);
                    try
                    {
                        myconn.Open();
                        if (comm.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("成功删除!");
                        }
                        else
                        {
                            MessageBox.Show("删除失败!");
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
            else
            {
                MessageBox.Show("您未选择任何行!");
            }
        }

        //修改
        private void Button1_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count != 0)
            {
                string IDtoEdit = this.listView1.SelectedItems[0].Text;
                
                EditUsersEditUser EUEU_1 = new EditUsersEditUser();
                EUEU_1.StuID = IDtoEdit;
                EUEU_1.Show();
            }
            else
            {
                MessageBox.Show("您未选择任一列!");
            }
        }

        private void EditUsers_Load(object sender, EventArgs e)
        {

        }
    }
}
