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
    public partial class EditRestaurantNewD : Form
    {
        public EditRestaurantNewD()
        {
            InitializeComponent();
            //MessageBox.Show(this.restID);

        }

        public string restID;

        public string RestID
        {
            get
            {
                return restID;
            }
            set
            {
                restID = value;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            //MessageBox.Show(this.restID);
            string conStr = @"Data Source=.;Initial Catalog=CanteenManagement;Integrated Security=True";
            SqlConnection con = new SqlConnection(conStr);
            string dishID = textBoxbh.Text.Trim();
            string dishName = textBoxID.Text.Trim();
            string dishType = comboBoxtype.Text.Trim();
            string dishOriginPrice = textBoxyj.Text.Trim();
            string dishPrice = textBoxzkj.Text.Trim();

            string dishCanteen = restID;

            if ((dishID.Length == 4))//符合格式，四位ID
            {
                //检查数据库是否注册过
                string sqlStr_1 = "SELECT COUNT(*) FROM foods WHERE FoodID = '" + dishID + "' " + 
                    "OR FoodName = '" + dishName + "'";

                SqlCommand comm = new SqlCommand(sqlStr_1, con);
                try
                {
                    con.Open();
                    int num = (int)comm.ExecuteScalar();
                    if (num != 0)//说明已经注册过
                    {
                        MessageBox.Show("重复创建！");
                    }
                    else//未被注册过，可以添加进数据库中
                    {
                            string sqlStr_2 = "INSERT INTO foods VALUES('" + dishID + "','" + dishName + "','" + dishCanteen +
                            "','" + dishOriginPrice + "','" + dishType + "','" + dishPrice 
                                + "')";//添加管理员

                            SqlCommand comm_2 = new SqlCommand(sqlStr_2, con);
                            if ((comm_2.ExecuteNonQuery() > 0))
                            {
                                MessageBox.Show("新增餐品成功！");
                                this.Close();
                            }
                            else
                                MessageBox.Show("新增失败！");
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
                MessageBox.Show("新增失败：编号为4位");
            }
        }
    }
}
