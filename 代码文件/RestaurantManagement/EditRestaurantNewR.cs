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
    public partial class EditRestaurantNewR : Form
    {
        public EditRestaurantNewR()
        {
            InitializeComponent();
            //MessageBox.Show(restID);
        }

        //public string restID;

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

        private void EditRestaurantNewR_Load(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //检查餐厅有无重名
            //插入数据库表

            string conStr = @"Data Source=.;Initial Catalog=CanteenManagement;Integrated Security=True";
            SqlConnection con = new SqlConnection(conStr);

            string newName = textBox1.Text.Trim();
            string newID = textBox2.Text.Trim();
            //string newID = RestID;
            string sqlStr_1 = "SELECT COUNT(*) FROM canteens WHERE CanteenID = '" + newID + "' " + 
                "OR CanteenName = '" + newName + "'";
            SqlCommand comm = new SqlCommand(sqlStr_1, con);
            try
            {
                con.Open();
                int num = (int)comm.ExecuteScalar();
                if (num != 0)//说明已经注册过
                {
                    MessageBox.Show("重复建立！");
                }
                else//未被注册过，可以添加进数据库中
                {
                    string sqlStr_2 = "INSERT INTO canteens VALUES('" + newID + "','" + newName
                                + "')";//添加餐厅
                    SqlCommand comm_1 = new SqlCommand(sqlStr_2, con);
                    if ((comm_1.ExecuteNonQuery() > 0))
                    {
                        MessageBox.Show("新建成功！");
                        this.Close();

                    }
                    else
                        MessageBox.Show("新建失败！");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }


        }
    }
}
