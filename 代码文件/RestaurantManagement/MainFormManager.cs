using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantManagement
{
    public partial class MainFormManager : Form
    {
        public MainFormManager()
        {
            InitializeComponent();
        }



        private void 用户信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            manage1 mg1_1 = new manage1();
            mg1_1.Show();
        }

        private void 菜单信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sales ss_1 = new Sales();
            ss_1.Show();
        }

        private void 销售额查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sales2 ss2_1 = new Sales2();
            ss2_1.Show();
        }

        //按键TEXT改为修改管理用户信息
        private void 更改个人信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditUsers eusers_1 = new EditUsers();
            eusers_1.Show();
        }

        private void 更改消费记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditRestaurants ER_1 = new EditRestaurants();
            ER_1.Show();
        }

        private void 餐品信息查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sales ss_1 = new Sales();
            ss_1.Show();
        }
    }
}
