using System.Windows.Forms;

namespace ScanLauncher.Core
{
    public class MessageHelper
    {
        private static string title = AssemblyHelper.AssemblyTitle;
        /// <summary>
        /// 메세지
        /// </summary>
        /// <param name="message"></param>
        /// <param name="type">1:Information 2:Warning 3:Error 4:Question</param>
        /// <param name="isExit"></param>
        /// <returns></returns>
        public static DialogResult MessageShow(string message, int type, bool isExit = false)
        {
            DialogResult result = DialogResult.None;

            switch (type)
            {
                case 1:
                    result = MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information); break;
                case 2:
                    result = MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning); break;
                case 3:
                    result = MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error); break;
                case 4:
                    result = MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Question); break;
                default:
                    break;
            }

            if (isExit)
                Application.ExitThread();

            return result;
        }

        public static void WarningMessage(string message)
        {   
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static string HttpResponseMessage(string bodyContext)
        {
            string html = @"<html>" + bodyContext + "</html>";
            return html;
        }
    }
}