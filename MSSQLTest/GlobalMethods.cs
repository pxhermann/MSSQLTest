using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace MSSQLTest
{
    public class GM
    {
#region Message boxes
        public static void ShowErrorMessageBox(IWin32Window wndOwner, String text, Exception ex = null)
        {
            if ( string.IsNullOrEmpty(text) )
                text = "Error occured!"; 
            if ( ex != null )
            { 
                text += string.Format("{0}{0}{1}", Environment.NewLine, ex.Message);
                for(Exception subEx = ex.InnerException; subEx != null;  subEx = subEx.InnerException)
                    text += string.Format("{0}{1}", Environment.NewLine, subEx.Message);

                text += string.Format("{0}{0}{1}", Environment.NewLine, ex.ToString());
            }

            MessageBox.Show(wndOwner, text, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        public static void ShowInfoMessageBox(IWin32Window wndOwner,String text)
        {
            MessageBox.Show(wndOwner, text, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult ShowQuestionMessageBox(IWin32Window wndOwner,String text)
        {
            return MessageBox.Show(wndOwner, text, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
#endregion

#region DES crypting
        private static byte[] desKey = Encoding.ASCII.GetBytes("123456789012345678901234");
        private static byte[] desIV = Encoding.ASCII.GetBytes("12345678");
        public static string DESEncrypt(string data)
        {
            if ( string.IsNullOrEmpty(data) )
                return "";

            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, TripleDES.Create().CreateEncryptor(desKey, desIV), CryptoStreamMode.Write))
                {
                    byte[] buf = Encoding.Unicode.GetBytes(data);
                    cs.Write(buf, 0, buf.Length);
                } // !!! call ms.ToArray() till after closing cs, otherwise cs could be unflushed and ms contained uncomplete data
                return Convert.ToBase64String(ms.ToArray());  // do not use Convert.ToString because ms buffer can contain unreadable characters
            }
        } 
        public static string DESDecrypt(string data)
        {
            if ( string.IsNullOrEmpty(data) )
                return "";

			using ( MemoryStream ms = new MemoryStream() )
            {
			    using ( CryptoStream cs = new CryptoStream(ms, TripleDES.Create().CreateDecryptor(desKey, desIV), CryptoStreamMode.Write) )
                {
    			    byte[] pwdBuf = Convert.FromBase64String(data);
                    cs.Write(pwdBuf, 0, pwdBuf.Length);
                } // !!! call ms.ToArray() till after closing cs, otherwise cs could be unflushed and ms contained uncomplete data
                return Encoding.Unicode.GetString(ms.ToArray());
            }
        } 
#endregion
#region DB value casting
        public static string ConvertToString(object value)
        {   
            return (value == null || value is System.DBNull) ? "": Convert.ToString(value);
        }
        public static DateTime ConvertToDateTime(object value)
        {   
            return (value == null || value is System.DBNull) ? DateTime.MinValue: Convert.ToDateTime(value);
        }
        public static decimal ConvertToDecimal(object value)
        {
            return (value == null || value is System.DBNull) ? 0m : Convert.ToDecimal(value);
        }
        public static int ConvertToInt(object value)
        {
            return (value == null || value is System.DBNull) ? 0 : Convert.ToInt32(value);
        }
        public static long ConvertToLong(object value)
        {
            return (value == null || value is System.DBNull) ? 0 : Convert.ToInt64(value);
        }
        public static bool ConvertToBool(object value)
        {
            return (value == null || value is System.DBNull) ? false : Convert.ToBoolean(value);
        }
        public static Guid ConvertToGuid(object value)
        {
            if ( value == null || value is System.DBNull )
                return Guid.Empty;
            string s=value.ToString();
            if ( string.IsNullOrEmpty(s) )
                return Guid.Empty;
            else 
                return new Guid(s);
        }
#endregion

#region string extension
        public static string LStr(int length, string src, char paddingChar = ' ')
		{
			if ( string.IsNullOrEmpty(src) )
				return new string(paddingChar, length);

			if (src.Length > length)
				return src.Substring(0, length);

			return src.PadRight(length, paddingChar);
		}
        public static string RStr(int length, string src, char paddingChar = ' ')
		{
			if ( string.IsNullOrEmpty(src) )
				return new string(paddingChar, length);

			if (src.Length > length)
				return src.Substring(0, length);

			return src.PadLeft(length, paddingChar);
		}
#endregion
    }
}
