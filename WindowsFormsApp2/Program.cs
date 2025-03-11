using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCKDS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // bilal 
            Application.Run(new KDSStartup());
            //Application.Run(new PizzaStation());
            // -------------------------------------

           // Application.Run(new PizzaStation());
            //Application.Run(new OrderGridForm("Front of House (FOH)"));
        }
    }
}
