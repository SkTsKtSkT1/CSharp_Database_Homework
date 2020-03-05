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
    public partial class manage1 : Form
    {
        public manage1()
        {
            InitializeComponent();
            float zongji = 0;
            SqlConnection Myconn = new SqlConnection();
            SqlCommand Mycmd = new SqlCommand();
            string Mystr = @"Data Source=.;Initial Catalog=CanteenManagement;Integrated Security=True";
            Myconn.ConnectionString = Mystr;
            try
            {
                Myconn.Open();
                string Mysql = "SELECT * FROM foods";
                Mycmd.CommandText = Mysql;
                Mycmd.Connection = Myconn;
                    //mycmd.Parameters.Add("@xh",SqlDbType.Char);//添加参数,学号
                    //mycmd.Parameters["@xh"].Value = textBox1.Text;//
                SqlDataReader Myreader = Mycmd.ExecuteReader();
                while(Myreader.Read())
                {
                    this.comboBox3.Items.Add(Myreader[1].ToString().Trim());
                }
                Myreader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Myconn.Close();
            }
            this.total.Text = zongji.ToString();
        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Manage1_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“canteenManagementDataSet.consume”中。您可以根据需要移动或删除它。
            this.consumeTableAdapter.Fill(this.canteenManagementDataSet.consume);

        }

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label10_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        //单击查询
        private void Button3_Click(object sender, EventArgs e)
        {
            float zongji = 0;
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
                    while(myreader.Read())
                    {
                        ListViewItem lvi = new ListViewItem();//构造一行的对象
                        //添加此行的列信息
                        lvi.Text = myreader[0].ToString().Trim();
                        lvi.SubItems.Add(myreader[1].ToString().Trim());
                        lvi.SubItems.Add(myreader[2].ToString().Trim());
                        lvi.SubItems.Add(myreader[3].ToString().Trim());
                        this.listView1.Items.Add(lvi);
                        textBox4.Text = myreader[4].ToString().Trim();
                        textBox5.Text = myreader[5].ToString().Trim();
                        zongji += (float)myreader[3];
                        //myreader.Read();
                    }
                    this.listView1.EndUpdate();
                    this.total.Text = zongji.ToString();
                    myreader.Close();
                }
                if (comboBox1.Text == "姓名")
                {
                    string mysql = "SELECT consume.ConsumeDate,foods.FoodName,canteens.CanteenName,consume.FdcPrice,pelple.PeopleID,pelple.PeopleName FROM consume " +
                                    "LEFT JOIN foods " +
                                    "ON consume.FoodID = foods.FoodID " +
                                    "LEFT JOIN canteens " +
                                    "ON consume.CanteenID = canteens.CanteenID " +
                                    "LEFT JOIN pelple " +
                                    "ON pelple.PeopleID = consume.PeopleID " + 
                                    "WHERE pelple.PeopleName = '" + textBox1.Text.Trim() + "'";
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
                        textBox5.Text = myreader[5].ToString().Trim();
                        //myreader.Read();
                        zongji += (float)myreader[3];
                    }
                    this.listView1.EndUpdate();
                    this.total.Text = zongji.ToString();
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
                
            
            //string mysql = "SELECT ";
        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            float zongji = 0;
            SqlConnection myconn = new SqlConnection();
            SqlCommand mycmd = new SqlCommand();
            string mystr = @"Data Source=.;Initial Catalog=CanteenManagement;Integrated Security=True";
            myconn.ConnectionString = mystr;
            try
            {
                myconn.Open();
                int flag;
                string mysql;
                if(comboBox2.Text == "不限")
                {
                    if (comboBox3.Text == "不限")
                    {
                        flag = 0;
                    }
                    else
                    {
                        flag = 1;
                    }
                }
                else
                {
                    if(comboBox3.Text == "不限")
                    {
                        flag = 2;
                    }
                    else
                    {
                        flag = 3;
                    }
                }
                if (comboBox1.Text == "学号")
                {
                    switch(flag)
                    {
                        case 0:
                            mysql = "SELECT consume.ConsumeDate,foods.FoodName,canteens.CanteenName,consume.FdcPrice,pelple.PeopleID,pelple.PeopleName FROM consume " +
                            "LEFT JOIN foods " +
                            "ON consume.FoodID = foods.FoodID " +
                            "LEFT JOIN canteens " +
                            "ON consume.CanteenID = canteens.CanteenID " +
                            "LEFT JOIN pelple " +
                            "ON pelple.PeopleID = consume.PeopleID " +
                            "WHERE consume.PeopleID = '" + textBox1.Text.Trim() + "' " +
                            "AND consume.ConsumeDate >= '" + textBox2.Text.Trim() + "' " +
                            "AND consume.ConsumeDate <= '" + textBox3.Text.Trim() + "'";
                            break;
                        case 1:
                            mysql = "SELECT consume.ConsumeDate,foods.FoodName,canteens.CanteenName,consume.FdcPrice,pelple.PeopleID,pelple.PeopleName FROM consume " +
                            "LEFT JOIN foods " +
                            "ON consume.FoodID = foods.FoodID " +
                            "LEFT JOIN canteens " +
                            "ON consume.CanteenID = canteens.CanteenID " +
                            "LEFT JOIN pelple " +
                            "ON pelple.PeopleID = consume.PeopleID " +
                            "WHERE consume.PeopleID = '" + textBox1.Text.Trim() + "' " +
                            "AND consume.ConsumeDate >= '" + textBox2.Text.Trim() + "' " +
                            "AND consume.ConsumeDate <= '" + textBox3.Text.Trim() + "' " +
                            "AND foods.FoodName = '" + comboBox3.Text.Trim() + "'";
                            break;
                        case 2:
                            mysql = "SELECT consume.ConsumeDate,foods.FoodName,canteens.CanteenName,consume.FdcPrice,pelple.PeopleID,pelple.PeopleName FROM consume " +
                            "LEFT JOIN foods " +
                            "ON consume.FoodID = foods.FoodID " +
                            "LEFT JOIN canteens " +
                            "ON consume.CanteenID = canteens.CanteenID " +
                            "LEFT JOIN pelple " +
                            "ON pelple.PeopleID = consume.PeopleID " +
                            "WHERE consume.PeopleID = '" + textBox1.Text.Trim() + "' " +
                            "AND consume.ConsumeDate >= '" + textBox2.Text.Trim() + "' " +
                            "AND consume.ConsumeDate <= '" + textBox3.Text.Trim() + "' " +
                            "AND canteens.CanteenName = '" + comboBox2.Text.Trim() + "'";
                            break;
                        case 3:
                            mysql = "SELECT consume.ConsumeDate,foods.FoodName,canteens.CanteenName,consume.FdcPrice,pelple.PeopleID,pelple.PeopleName FROM consume " +
                            "LEFT JOIN foods " +
                            "ON consume.FoodID = foods.FoodID " +
                            "LEFT JOIN canteens " +
                            "ON consume.CanteenID = canteens.CanteenID " +
                            "LEFT JOIN pelple " +
                            "ON pelple.PeopleID = consume.PeopleID " +
                            "WHERE consume.PeopleID = '" + textBox1.Text.Trim() + "' " +
                            "AND consume.ConsumeDate >= '" + textBox2.Text.Trim() + "' " +
                            "AND consume.ConsumeDate <= '" + textBox3.Text.Trim() + "' " +
                            "AND foods.FoodName = '" + comboBox3.Text.Trim() + "' " +
                            "AND canteens.CanteenName = '" + comboBox2.Text.Trim() + "'";
                            break;
                        default:
                            mysql = "SELECT consume.ConsumeDate,foods.FoodName,canteens.CanteenName,consume.FdcPrice,pelple.PeopleID,pelple.PeopleName FROM consume " +
                            "LEFT JOIN foods " +
                            "ON consume.FoodID = foods.FoodID " +
                            "LEFT JOIN canteens " +
                            "ON consume.CanteenID = canteens.CanteenID " +
                            "LEFT JOIN pelple " +
                            "ON pelple.PeopleID = consume.PeopleID " +
                            "WHERE consume.PeopleID = '" + textBox1.Text.Trim() + "' " +
                            "AND consume.ConsumeDate >= '" + textBox2.Text.Trim() + "' " +
                            "AND consume.ConsumeDate <= '" + textBox3.Text.Trim() + "' " +
                            "AND foods.FoodName = '" + comboBox3.Text.Trim() + "' " +
                            "AND canteens.CanteenName = '" + comboBox2.Text.Trim() + "'";
                            break;
                    }
                        //mysql = "SELECT consume.ConsumeDate,foods.FoodName,canteens.CanteenName,consume.FdcPrice,pelple.PeopleID,pelple.PeopleName FROM consume " +
                        //                "LEFT JOIN foods " +
                        //                "ON consume.FoodID = foods.FoodID " +
                        //                "LEFT JOIN canteens " +
                        //                "ON consume.CanteenID = canteens.CanteenID " +
                        //                "LEFT JOIN pelple " +
                        //                "ON pelple.PeopleID = consume.PeopleID " +
                        //                "WHERE consume.PeopleID = '" + textBox1.Text.Trim() + "' " +
                        //                "AND consume.ConsumeDate >= '" + textBox2.Text.Trim() + "' " +
                        //                "AND consume.ConsumeDate <= '" + textBox3.Text.Trim() + "' " +
                        //                "AND foods.FoodName = '" + comboBox3.Text.Trim() + "' " +
                        //                "AND canteens.CanteenName = '" + comboBox2.Text.Trim() + "'";
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
                            textBox5.Text = myreader[5].ToString().Trim();
                            //myreader.Read();
                            zongji += (float)myreader[3];
                        }
                        this.listView1.EndUpdate();
                        this.total.Text = zongji.ToString();
                        myreader.Close();

                }
                if (comboBox1.Text == "姓名")
                {
                    switch (flag)
                    {
                        case 0:
                            mysql = "SELECT consume.ConsumeDate,foods.FoodName,canteens.CanteenName,consume.FdcPrice,pelple.PeopleID,pelple.PeopleName FROM consume " +
                            "LEFT JOIN foods " +
                            "ON consume.FoodID = foods.FoodID " +
                            "LEFT JOIN canteens " +
                            "ON consume.CanteenID = canteens.CanteenID " +
                            "LEFT JOIN pelple " +
                            "ON pelple.PeopleID = consume.PeopleID " +
                            "WHERE pelple.PeopleName = '" + textBox1.Text.Trim() + "' " +
                            "AND consume.ConsumeDate >= '" + textBox2.Text.Trim() + "' " +
                            "AND consume.ConsumeDate <= '" + textBox3.Text.Trim() + "'";
                            break;
                        case 1:
                            mysql = "SELECT consume.ConsumeDate,foods.FoodName,canteens.CanteenName,consume.FdcPrice,pelple.PeopleID,pelple.PeopleName FROM consume " +
                            "LEFT JOIN foods " +
                            "ON consume.FoodID = foods.FoodID " +
                            "LEFT JOIN canteens " +
                            "ON consume.CanteenID = canteens.CanteenID " +
                            "LEFT JOIN pelple " +
                            "ON pelple.PeopleID = consume.PeopleID " +
                            "WHERE pelple.PeopleName = '" + textBox1.Text.Trim() + "' " +
                            "AND consume.ConsumeDate >= '" + textBox2.Text.Trim() + "' " +
                            "AND consume.ConsumeDate <= '" + textBox3.Text.Trim() + "' " +
                            "AND foods.FoodName = '" + comboBox3.Text.Trim() + "'";
                            break;
                        case 2:
                            mysql = "SELECT consume.ConsumeDate,foods.FoodName,canteens.CanteenName,consume.FdcPrice,pelple.PeopleID,pelple.PeopleName FROM consume " +
                            "LEFT JOIN foods " +
                            "ON consume.FoodID = foods.FoodID " +
                            "LEFT JOIN canteens " +
                            "ON consume.CanteenID = canteens.CanteenID " +
                            "LEFT JOIN pelple " +
                            "ON pelple.PeopleID = consume.PeopleID " +
                            "WHERE pelple.PeopleName = '" + textBox1.Text.Trim() + "' " +
                            "AND consume.ConsumeDate >= '" + textBox2.Text.Trim() + "' " +
                            "AND consume.ConsumeDate <= '" + textBox3.Text.Trim() + "' " +
                            "AND canteens.CanteenName = '" + comboBox2.Text.Trim() + "'";
                            break;
                        case 3:
                            mysql = "SELECT consume.ConsumeDate,foods.FoodName,canteens.CanteenName,consume.FdcPrice,pelple.PeopleID,pelple.PeopleName FROM consume " +
                            "LEFT JOIN foods " +
                            "ON consume.FoodID = foods.FoodID " +
                            "LEFT JOIN canteens " +
                            "ON consume.CanteenID = canteens.CanteenID " +
                            "LEFT JOIN pelple " +
                            "ON pelple.PeopleID = consume.PeopleID " +
                            "WHERE pelple.PeopleName = '" + textBox1.Text.Trim() + "' " +
                            "AND consume.ConsumeDate >= '" + textBox2.Text.Trim() + "' " +
                            "AND consume.ConsumeDate <= '" + textBox3.Text.Trim() + "' " +
                            "AND foods.FoodName = '" + comboBox3.Text.Trim() + "' " +
                            "AND canteens.CanteenName = '" + comboBox2.Text.Trim() + "'";
                            break;
                        default:
                            mysql = "SELECT consume.ConsumeDate,foods.FoodName,canteens.CanteenName,consume.FdcPrice,pelple.PeopleID,pelple.PeopleName FROM consume " +
                            "LEFT JOIN foods " +
                            "ON consume.FoodID = foods.FoodID " +
                            "LEFT JOIN canteens " +
                            "ON consume.CanteenID = canteens.CanteenID " +
                            "LEFT JOIN pelple " +
                            "ON pelple.PeopleID = consume.PeopleID " +
                            "WHERE pelplen.PeopleName = '" + textBox1.Text.Trim() + "' " +
                            "AND consume.ConsumeDate >= '" + textBox2.Text.Trim() + "' " +
                            "AND consume.ConsumeDate <= '" + textBox3.Text.Trim() + "' " +
                            "AND foods.FoodName = '" + comboBox3.Text.Trim() + "' " +
                            "AND canteens.CanteenName = '" + comboBox2.Text.Trim() + "'";
                            break;
                    }
                    //mysql = "SELECT consume.ConsumeDate,foods.FoodName,canteens.CanteenName,consume.FdcPrice,pelple.PeopleID,pelple.PeopleName FROM consume " +
                    //                "LEFT JOIN foods " +
                    //                "ON consume.FoodID = foods.FoodID " +
                    //                "LEFT JOIN canteens " +
                    //                "ON consume.CanteenID = canteens.CanteenID " +
                    //                "LEFT JOIN pelple " +
                    //                "ON pelple.PeopleID = consume.PeopleID " +
                    //                "WHERE pelple.PeopleName = '" + textBox1.Text.Trim() + "' " + 
                    //                "AND consume.ConsumeDate >= '" + textBox2.Text.Trim() + "' " +
                    //                "AND consume.ConsumeDate <= '" + textBox3.Text.Trim() + "' " +
                    //                "AND foods.FoodName = '" + comboBox3.Text.Trim() + "' " +
                    //                "AND canteens.CanteenName = '" + comboBox2.Text.Trim() + "'";
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
                        textBox5.Text = myreader[5].ToString().Trim();
                        //myreader.Read();
                        zongji += (float)myreader[3];
                    }
                    this.listView1.EndUpdate();
                    this.total.Text = zongji.ToString();
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

        private void ListView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            this.listView1.BeginUpdate();
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.EndUpdate();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            this.listView1.BeginUpdate();
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.listView1.EndUpdate();
        }

        //增加消费记录
        private void Button5_Click(object sender, EventArgs e)
        {

        }

        //删除选中消费记录
        private void Button2_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count != 0)
            {
                string timeIDtoDelete = this.listView1.SelectedItems[0].Text;
                DialogResult dr = MessageBox.Show("确定删除?", "提醒", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    SqlConnection myconn = new SqlConnection();

                    string mystr = @"Data Source=.;Initial Catalog=CanteenManagement;Integrated Security=True";
                    myconn.ConnectionString = mystr;

                    string sqlstr = "DELETE FROM consume " +
                                     "WHERE ConsumeDate = '" + timeIDtoDelete + "' ";
                                     
                    // "ALTER TABLE foods CHECK CONSTRAINT ALL " ;
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
    }
}
