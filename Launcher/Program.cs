using ScanLauncher.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScanLauncher
{
    static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args != null && args.Length > 0)
            {
                InteropHelper.SetRegData(args[0]);
                Application.Exit();
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                using (Mutex m = new Mutex(true, Application.ProductName, out bool isCreateNew))
                {
                    if (isCreateNew)
                        Application.Run(new View.frmLauncher());
                    else
                    {
                        MessageBox.Show("이미 실행 중 입니다. 프로그램을 종료 합니다.");
                        Application.ExitThread();
                    }
                }
            }
        }
    }
}