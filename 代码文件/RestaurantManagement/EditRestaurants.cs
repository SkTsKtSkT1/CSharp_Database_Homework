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
    public partial class EditRestaurants : Form
    {
        //当前所选餐厅的ID
        public string restID = "";
        public string restName = "";
        //public string[] restIDs = new string[100] { };

        //public string RestID
        //{
        //    get
        //    {
        //        return restID;
        //    }
        //    set
        //    {
        //        restID = value;
        //    }
        //}

        public EditRestaurants()
        {
            InitializeComponent();
            //在选择餐厅combox中增加选项
            SqlConnection Myconn = new SqlConnection();
            SqlCommand Mycmd = new SqlCommand();
            string Mystr = @"Data Source=.;Initial Catalog=CanteenManagement;Integrated Security=True";
            Myconn.ConnectionString = Mystr;
            try
            {
                Myconn.Open();
                string Mysql = "SELECT * FROM canteens";
                Mycmd.CommandText = Mysql;
                Mycmd.Connection = Myconn;
                //mycmd.Parameters.Add("@xh",SqlDbType.Char);//添加参数,学号
                //mycmd.Parameters["@xh"].Value = textBox1.Text;//
                SqlDataReader Myreader = Mycmd.ExecuteReader();
               // int i = 0;
                while (Myreader.Read())
                {
                    //this.restIDs[i] = Myreader[1].ToString().Trim();//添加到餐厅ID数组
                    this.comboBox1.Items.Add(Myreader[1].ToString().Trim());
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
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            EditRestaurantNewR ERNR_1 = new EditRestaurantNewR();
            ERNR_1.Show();
        }

        private void EditRestaurants_Load(object sender, EventArgs e)
        {

        }

        private void Button7_Click(object sender, EventArgs e)
        {
            this.comboBox1.Items.Clear();
            SqlConnection Myconn = new SqlConnection();
            SqlCommand Mycmd = new SqlCommand();
            string Mystr = @"Data Source=.;Initial Catalog=CanteenManagement;Integrated Security=True";
            Myconn.ConnectionString = Mystr;
            try
            {
                Myconn.Open();
                string Mysql = "SELECT * FROM canteens";
                Mycmd.CommandText = Mysql;
                Mycmd.Connection = Myconn;

                SqlDataReader Myreader = Mycmd.ExecuteReader();
                while (Myreader.Read())
                {
                    this.comboBox1.Items.Add(Myreader[1].ToString().Trim());
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
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(this.restID);
            EditRestaurantNewD ERND_1 = new EditRestaurantNewD();
            ERND_1.RestID = this.restID;
            ERND_1.ShowDialog();
            
        }

        //修改餐品
        private void Button6_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count != 0)
            {
                string IDtoEdit = this.listView1.SelectedItems[0].Text;
                EditRestaurantEditD ERED_1 = new EditRestaurantEditD();
                ERED_1.DishID = IDtoEdit;
                ERED_1.Show();         
            }
            else
            {
                MessageBox.Show("未选择餐品!");
            }
               
        }

        //删除餐厅
        //删除相关所有菜品
        //删除所有菜品的消费信息
        private void Button4_Click(object sender, EventArgs e)
        {
            if (this.listView1.Items.Count != 0)
            {
                MessageBox.Show("请先删除餐品!");
            }
            else
            {
                string IDtoDelete = this.restID;
                DialogResult dr = MessageBox.Show("确定删除餐厅?", "提醒", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    SqlConnection myconn = new SqlConnection();

                    string mystr = @"Data Source=.;Initial Catalog=CanteenManagement;Integrated Security=True";
                    myconn.ConnectionString = mystr;

                    string sqlstr = "DELETE FROM canteens " +
                                     "WHERE CanteenID = '" + IDtoDelete + "' ";
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
            
        }

        //删除菜品
        //删除其消费信息
        private void Button2_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count != 0)
            {
                string IDtoDelete = this.listView1.SelectedItems[0].Text;
                DialogResult dr = MessageBox.Show("确定删除餐品?", "提醒", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    SqlConnection myconn = new SqlConnection();

                    string mystr = @"Data Source=.;Initial Catalog=CanteenManagement;Integrated Security=True";
                    myconn.ConnectionString = mystr;

                    string sqlstr = "ALTER TABLE consume NOCHECK CONSTRAINT ALL " +
                                     //"ALTER TABLE foods NOCHECK CONSTRAINT ALL " + 
                                     "DELETE FROM foods " +
                                     "WHERE FoodID = '" + IDtoDelete + "' " +
                                     "DELETE FROM consume " +
                                     "WHERE FoodID = '" + IDtoDelete + "' " +
                                     "ALTER TABLE consume CHECK CONSTRAINT ALL"; 
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

        //刷新当前选择餐厅
        private void ComboBox1_TextChanged(object sender, EventArgs e)
        {
            this.restName = comboBox1.Text.Trim();

            SqlConnection Myconn = new SqlConnection();
            SqlCommand Mycmd = new SqlCommand();
            string Mystr = @"Data Source=.;Initial Catalog=CanteenManagement;Integrated Security=True";
            Myconn.ConnectionString = Mystr;
            //this.restID = comboBox1.Text.Trim();
            //查询餐厅中所有餐点

            try
            {
                Myconn.Open();
                string Mysql = " SELECT foods.FoodID,FoodName,canteens.CanteenName,Foodtype,FoodPrice,FdcPrice FROM foods " +
                                 "LEFT JOIN canteens " +
                                 "ON canteens.CanteenID = foods.FoodCanteen " +
                                 "WHERE canteens.CanteenName = '" + comboBox1.Text.Trim() + "' ";
                Mycmd.CommandText = Mysql;
                Mycmd.Connection = Myconn;

                SqlDataReader myreader = Mycmd.ExecuteReader();
                //while (Myreader.Read())
                //{
                //    this.comboBox1.Items.Add(Myreader[1].ToString().Trim());
                //}
                //Myreader.Close();

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
                    this.listView1.Items.Add(lvi);
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
                Myconn.Close();
            }

            //SqlConnection Myconn = new SqlConnection();
            //SqlCommand Mycmd = new SqlCommand();
            //string Mystr = @"Data Source=.;Initial Catalog=CanteenManagement;Integrated Security=True";
            Myconn.ConnectionString = Mystr;
            try
            {
                Myconn.Open();
                string Mysql = "SELECT CanteenID FROM canteens WHERE CanteenName = '" + 
                     this.restName + "' ";
                Mycmd.CommandText = Mysql;
                Mycmd.Connection = Myconn;

                SqlDataReader Myreader = Mycmd.ExecuteReader();
                while (Myreader.Read())
                {
                    this.restID = (Myreader[0].ToString().Trim());
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
                //MessageBox.Show(this.restID);
            }
        }

        private void Button5_Click_1(object sender, EventArgs e)
        {
            this.restName = comboBox1.Text.Trim();

            SqlConnection Myconn = new SqlConnection();
            SqlCommand Mycmd = new SqlCommand();
            string Mystr = @"Data Source=.;Initial Catalog=CanteenManagement;Integrated Security=True";
            Myconn.ConnectionString = Mystr;
            //this.restID = comboBox1.Text.Trim();
            //查询餐厅中所有餐点

            try
            {
                Myconn.Open();
                string Mysql = " SELECT foods.FoodID,FoodName,canteens.CanteenName,Foodtype,FoodPrice,FdcPrice FROM foods " +
                                 "LEFT JOIN canteens " +
                                 "ON canteens.CanteenID = foods.FoodCanteen " +
                                 "WHERE canteens.CanteenName = '" + comboBox1.Text.Trim() + "' ";
                Mycmd.CommandText = Mysql;
                Mycmd.Connection = Myconn;

                SqlDataReader myreader = Mycmd.ExecuteReader();
                //while (Myreader.Read())
                //{
                //    this.comboBox1.Items.Add(Myreader[1].ToString().Trim());
                //}
                //Myreader.Close();

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
                    this.listView1.Items.Add(lvi);
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
                Myconn.Close();
            }
        }
    }
}
