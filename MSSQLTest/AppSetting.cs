using System;
using System.IO;
using System.Xml.Serialization;

namespace MSSQLTest
{
	public class AppSetting
	{
        public SqlConnData Sql= new SqlConnData();

        public System.Windows.Forms.FormWindowState WindowState = System.Windows.Forms.FormWindowState.Normal;
        public System.Drawing.Rectangle WindowPosition = System.Drawing.Rectangle.Empty;
		public bool AlwaysOnTop = false;

		public AppSetting()
		{
			Reset();
		}
        private static string cfgFileName
        {
            get { return Path.ChangeExtension(System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName, ".cfg"); }
        }
		public void Reset()
		{
            Sql.Reset();
		}
		public static AppSetting Load()
		{
			AppSetting data = null;

			string cfgFile = cfgFileName;
            if ( File.Exists(cfgFile) )
                try
                { 
			        using ( StreamReader sm = new StreamReader(cfgFile) )
			        {
				        XmlSerializer x = new XmlSerializer(typeof(AppSetting));
				        data = (AppSetting)x.Deserialize(sm);
			        }
                }
				catch(Exception ex)
				{
#if DEBUG
					GM.ShowErrorMessageBox(null, "Nepodařilo se načíst nastavení aplikace!", ex);
#endif
				}

            if ( data == null )
                data = new AppSetting();
			return data;
		}
		public void Save()
		{
			try
			{
			    using (StreamWriter sw = new StreamWriter(cfgFileName))
			    {
				    XmlSerializer x = new XmlSerializer(typeof(AppSetting));
				    x.Serialize(sw, this);
			    }
            }
			catch(Exception ex)
			{
#if DEBUG
                GM.ShowErrorMessageBox(null, "Nepodařilo se uložit nastavení aplikace!", ex);
#endif
            }
		}
	}
}
