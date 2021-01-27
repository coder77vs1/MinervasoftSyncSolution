using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace ScanLauncher
{
    public static class CommonExtentions
    {
        /// <summary>
        /// Null 값인 경우 안전한 Trim
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToSafeTrim(this string value)
        {
            return (value ?? string.Empty).Trim();
        }

        /// <summary>
        /// 메시지 박스 (알림) 표시 
        /// </summary>
        /// <param name="message"></param>
        public static void ShowInfoMessageBox(this string message)
        {
            System.Windows.Forms.MessageBox.Show(message, "알림", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
        }

        /// <summary>
        /// 메시지와 Excption 으로 에러 메시지를 만든다.
        /// </summary>
        /// <param name="message">기본 에러메시지</param>
        /// <param name="ex">Exception</param>
        /// <returns></returns>
        public static string BuildErrorMessage(this string message, Exception ex)
        {
            StringBuilder builder = new StringBuilder();

            if (!string.IsNullOrEmpty(message))
            {
                builder.AppendLine(message);
            }

            if (ex != null && !string.IsNullOrEmpty(ex.Message))
            {
                if (ex.InnerException != null)
                {
                    Exception innerEx = ex.InnerException;
                    builder.AppendLine($"{innerEx.Message} [{innerEx.HResult}]");
                }
                else
                {
                    builder.AppendLine($"{ex.Message} [{ex.HResult}]");
                }
            }

            return builder.ToString();
        }


        /// <summary>
        /// Invoke 가 필요한 경우 처리
        /// </summary>
        /// <param name="control"></param>
        /// <param name="action"></param>
        public static void InvokeIfRequired(this Control control, MethodInvoker action)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(action);
            }
            else
            {
                action();
            }
        }

        /// <summary>
        /// Enum 의 디스크립션 반환
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string GetEnumDescription(this Enum enumValue)
        {
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

            var descriptionAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return descriptionAttributes.Length > 0 ? descriptionAttributes[0].Description : enumValue.ToString();
        }

        /// <summary>
        /// Wait cursor 설정
        /// </summary>
        public class WaitCursor : IDisposable
        {
            public WaitCursor()
            {
                Application.UseWaitCursor = true;
            }

            public void Dispose()
            {
                Application.UseWaitCursor = false;
            }
        }
    }
}
