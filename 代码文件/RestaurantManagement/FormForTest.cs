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
    public partial class FormForTest : Form
    {
        public FormForTest()
        {
            InitializeComponent();
        }

        private void FormForTest_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“canteenManagementDataSet.pelple”中。您可以根据需要移动或删除它。
            this.pelpleTableAdapter.Fill(this.canteenManagementDataSet.pelple);
            // TODO: 这行代码将数据加载到表“canteenManagementDataSet.canteens”中。您可以根据需要移动或删除它。
            this.canteensTableAdapter.Fill(this.canteenManagementDataSet.canteens);

        }
    }
}
