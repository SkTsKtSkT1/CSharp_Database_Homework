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
    public partial class Sales2 : Form
    {
        public Sales2()
        {
            InitializeComponent();
            time1.ReadOnly = true;
            time2.ReadOnly = true;
            price1.ReadOnly = true;
            price2.ReadOnly = true;
        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void CheckBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            float zongji = 0;
            //初始化附加字符串
            string canteenStr = "";
            string typeStr = "";
            string userStr = "";
            //检查groupbox1 餐厅中被选中状况来确定字符串
            int canteenCheckedNum = 0;
            int typeCheckedNum = 0;
            int userCheckedNum = 0;

            foreach(Control c in this.groupBox1.Controls)
            {
                if(c is CheckBox)
                {
                    CheckBox cc = c as CheckBox;
                    if(cc.Checked)//被选中,添加字符串
                    {
                        if(canteenCheckedNum == 0)
                        {
                            canteenStr += " canteens.CanteenName = '";
                            canteenStr += cc.Text.Trim();
                            canteenStr += "' ";
                        }
                        else
                        {
                            canteenStr += "OR canteens.CanteenName = '";
                            canteenStr += cc.Text.Trim();
                            canteenStr += "' ";
                        }
                        canteenCheckedNum += 1;
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
                        if (typeCheckedNum == 0)
                        {
                            typeStr += " foods.Foodtype = '";
                            typeStr += cc.Text.Trim();
                            typeStr += "' ";
                        }
                        else
                        {
                            typeStr += " OR foods.Foodtype = '";
                            typeStr += cc.Text.Trim();
                            typeStr += "' ";
                        }
                        typeCheckedNum += 1;
                    }
                }
            }

            foreach (Control c in this.groupBox3.Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox cc = c as CheckBox;
                    if (cc.Checked)//被选中,添加字符串
                    {
                        int userFlag = 1;
                        if(cc.Text == "本科生")
                        {
                            userFlag = 1;
                        }
                        else if(cc.Text == "研究生")
                        {
                            userFlag = 3;
                        }
                        else if(cc.Text == "教职工")
                        {
                            userFlag = 2;
                        }
                        else
                        {
                            userFlag = 4;
                        }
                        if (userCheckedNum == 0)
                        {
                            userStr += " pelple.PeopleType = ";
                            userStr += userFlag.ToString();
                            userStr += " ";
                        }
                        else
                        {
                            userStr += " OR pelple.PeopleType = ";
                            userStr += userFlag.ToString();
                            userStr += " ";
                        }
                        userCheckedNum += 1;
                    }
                }
            }

            if (canteenCheckedNum == 0)
            {
                MessageBox.Show("未选择餐厅!");
            }
            if(typeCheckedNum == 0)
            {
                MessageBox.Show("未选择餐品类型!");
            }
            if(userCheckedNum == 0)
            {
                MessageBox.Show("未选择顾客类型!");
            }
            else
            {
                SqlConnection myconn = new SqlConnection();
                SqlCommand mycmd = new SqlCommand();
                string mystring = @"Data Source=.;Initial Catalog=CanteenManagement;Integrated Security=True";
                myconn.ConnectionString = mystring;
                try
                {
                    myconn.Open();
                    string mysql = "SELECT consume.FoodID,foods.FoodName,canteens.CanteenName,foods.Foodtype,consume.ConsumeDate,consume.PeopleID,consume.FdcPrice FROM consume " +
                    "LEFT JOIN canteens " +
                    "ON canteens.CanteenID = consume.CanteenID " +
                    "LEFT JOIN foods " +
                    "ON foods.FoodID = consume.FoodID " +
                    "LEFT JOIN pelple " +
                    "ON consume.PeopleID = pelple.PeopleID " +
                    "WHERE (" +
                    canteenStr +
                    ") " +
                    " AND (" +
                    typeStr +
                    ") " +
                    " AND (" +
                    userStr +
                    ") ";
                    if(this.checkBox1.Checked)//开启时间筛选
                    {
                        mysql += " AND consume.ConsumeDate >= '" + time1.Text.Trim() + "' " +
                            "AND consume.ConsumeDate <= '" + time2.Text.Trim() + "' ";
                    }
                    if(this.checkBox2.Checked)//开启价格筛选
                    {
                        mysql += " AND consume.FdcPrice >= '" + price1.Text.Trim() + "' " +
                            "AND consume.FdcPrice <= '" + price2.Text.Trim() + "' ";
                    }
                    mycmd.CommandText = mysql;
                    mycmd.Connection = myconn;
                    SqlDataReader myreader = mycmd.ExecuteReader();

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
                        lvi.SubItems.Add(myreader[5].ToString().Trim());
                        lvi.SubItems.Add(myreader[6].ToString().Trim());
                        zongji += (float)myreader[6];
                        this.listView1.Items.Add(lvi);
                    }
                    this.listView1.EndUpdate();
                    this.label6.Text = zongji.ToString();
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

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked == true)
            {
                this.time1.ReadOnly = false;
                this.time2.ReadOnly = false;
            }
            else
            {
                this.time1.Clear();
                this.time1.ReadOnly = true;
                this.time2.Clear();
                this.time2.ReadOnly = true;
            }
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox2.Checked == true)
            {
                this.price1.ReadOnly = false;
                this.price2.ReadOnly = false;
            }
            else
            {
                this.price1.Clear();
                this.price1.ReadOnly = true;
                this.price2.Clear();
                this.price2.ReadOnly = true;
            }
        }

        //private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        //{
        //    if(this.radioButton1.Checked == true)
        //    {
        //        this.time1.ReadOnly = false;
        //        this.time2.ReadOnly = false;
        //    }
        //    else
        //    {
        //        this.time1.Clear();
        //        this.time1.ReadOnly = true;
        //        this.time2.Clear();
        //        this.time2.ReadOnly = true;
        //    }
        //}
    }
}
