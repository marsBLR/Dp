using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Agency1
{
    static class Class1
    {
        [STAThread]
        static void Program()
        {
            /*var logger = LogManager.GetLogger("Program");
               logger.Info("Application started");

               Application.EnableVisualStyles();
               Application.SetCompatibleTextRenderingDefault(false);
               Application.Run(new MainCards());

               logger.Info("Application finished");*/
            var logger = LogManager.GetCurrentClassLogger();
            logger.Info("Application started");
            
            Application.Current.Run(new MainWindow());
            //Application. EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
          //  Application. Run(new MainWindow());

            logger.Info("Application finished");

        }
    }
}
