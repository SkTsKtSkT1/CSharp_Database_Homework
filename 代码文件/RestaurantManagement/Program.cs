using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantManagement
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ///////////////////////////////////////////////////
            Application.Run(new Login());

            //Application.Run(new EditUsers());

            //Application.Run(new EditRestaurants());
            //Application.Run(new EditUsers());

        }
    }
}
