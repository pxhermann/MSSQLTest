using System;
using System.Text;
using System.Data;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using System.Data.SqlClient;

namespace MSSQLTest
{
	public class SqlConnData
	{
		public string Server;
		public bool AuthSQL;
		public string User;
		public string Pwd;
		public string Database;
        [XmlIgnore]
        public string PwdDecrypted
        {
            get { return GM.DESDecrypt(Pwd); }
            set { Pwd = GM.DESEncrypt(value); } 
        }

        public bool IsValid()
        {
            return (!String.IsNullOrEmpty(Server) && !String.IsNullOrEmpty(Database) && (!AuthSQL || !String.IsNullOrEmpty(User)) );
        }
        public SqlConnData()
        {
            Reset();
        }
		public SqlConnData(string server, string database, string user, string pwd, bool authSQL)
		{
			this.Server = server;
			this.Database = database;
			this.User = user;
			this.Pwd = pwd;
			this.AuthSQL = authSQL;
		}
        public void CopyFrom(SqlConnData src)
        {
            Server = src.Server;
            AuthSQL = src.AuthSQL;
            User = src.User;
            Pwd = src.Pwd;
            Database = src.Database;
        }
		public void Reset()
		{
			Server	= "."; // "(local)";
			AuthSQL	= true;
			User	= "";
			Pwd		= "";
            Database = "";
		}
        public string GetConnectionString(bool inclDB = true)
        {
            String connStr = "Data Source=" + Server + ";";
            if ( AuthSQL)
                connStr += "User ID=" + User + ";Password=" + PwdDecrypted + ";";
            else
                connStr += "Integrated Security=SSPI;";

            if ( inclDB )
                connStr += "Initial Catalog=" + Database + ";";
            return connStr;
        }
    }

	public class DB
	{
        public static int INVALID_ID = -1;
        public static int ALL_ID = -2;

		public static SqlConnData ConnData = new SqlConnData();

        public static SqlConnection OpenConnection(bool inclDB = true)
        {
            SqlConnection conn = new SqlConnection(ConnData.GetConnectionString(inclDB));;
            conn.Open();

            return conn;
        }
        public static String GetVersionInfo()
        {
            string retVal = "";
            using ( SqlConnection conn = OpenConnection() )
            {
                SqlDataAdapter da = new SqlDataAdapter("", conn);
                DataTable tbl = new DataTable();

                // server version
                da.SelectCommand.CommandText = "SELECT"+
                        " CASE"+
                        " WHEN CONVERT(VARCHAR(128), SERVERPROPERTY ('productversion')) like '8%' THEN 'SQL2000'"+
                        " WHEN CONVERT(VARCHAR(128), SERVERPROPERTY ('productversion')) like '9%' THEN 'SQL2005'"+
                        " WHEN CONVERT(VARCHAR(128), SERVERPROPERTY ('productversion')) like '10.0%' THEN 'SQL2008'"+
                        " WHEN CONVERT(VARCHAR(128), SERVERPROPERTY ('productversion')) like '10.5%' THEN 'SQL2008 R2'"+
                        " WHEN CONVERT(VARCHAR(128), SERVERPROPERTY ('productversion')) like '11%' THEN 'SQL2012'"+
                        " WHEN CONVERT(VARCHAR(128), SERVERPROPERTY ('productversion')) like '12%' THEN 'SQL2014'" +
                        " WHEN CONVERT(VARCHAR(128), SERVERPROPERTY ('productversion')) like '13%' THEN 'SQL2016'" +
                        " WHEN CONVERT(VARCHAR(128), SERVERPROPERTY ('productversion')) like '14%' THEN 'SQL2017'" +
                        " WHEN CONVERT(VARCHAR(128), SERVERPROPERTY ('productversion')) like '15%' THEN 'SQL2019'" +
                        " ELSE 'unknown SQL version'" +
                        " END AS MajorVersion," +
                        " SERVERPROPERTY('ProductLevel') AS ProductLevel," +
                        " SERVERPROPERTY('Edition') AS Edition," +
                        " SERVERPROPERTY('ProductVersion') AS ProductVersion";
                da.Fill(tbl);
                if ( tbl.Rows.Count > 0 )
                    retVal = String.Format("{0} {1} {2}", GM.ConvertToString(tbl.Rows[0]["MajorVersion"]), GM.ConvertToString(tbl.Rows[0]["ProductVersion"]), GM.ConvertToString(tbl.Rows[0]["Edition"]));
                // login user
                tbl = new DataTable();
                da.SelectCommand.CommandText = "SELECT ORIGINAL_LOGIN()";
                da.Fill(tbl);
                if ( tbl.Rows.Count > 0 )
                    retVal += String.Format(" - {0}", GM.ConvertToString(tbl.Rows[0][0]));
            }

            return retVal;
        }
        // helper method - requires closing connection after usage. For safety reasons keep it private!!!
        private static SqlCommand CreateCommand(string cmdText = "", SqlTransaction trn = null)
        {
            SqlCommand cmd = new SqlCommand(cmdText, null);
            if ( trn == null )
                cmd.Connection = DB.OpenConnection();
            else
            { 
                cmd.Connection = trn.Connection;
                cmd.Transaction = trn;
            }
            if ( cmd.Connection.State != ConnectionState.Open )
                cmd.Connection.Open();

            return cmd;
        }

        public static DataTable GetDataTable(string selectCmd)
        {
            return GetDataTable("", selectCmd);
        }
        public static DataTable GetDataTable(string tblName, string selectCmd)
        {
            DataTable tbl = new DataTable(tblName);
            using (SqlConnection conn = OpenConnection() )
                (new SqlDataAdapter(selectCmd, conn)).Fill(tbl);
            return tbl;
        }
        public static void ExecuteNoQuery(string cmdText, params object[] paramList)
        {
            ExecuteNoQuery(null, cmdText, paramList);
        }
        public static void ExecuteNoQuery(SqlTransaction trn, string cmdText, params object[] paramList)
        {
            using ( SqlCommand cmd = CreateCommand(cmdText, trn) )
                try
                {
                    if ( paramList != null )
                        for (int i = 0; i+1<paramList.Length; i+=2 )
                            cmd.Parameters.AddWithValue((string)paramList[i], paramList[i+1]);

                    if ( cmd.Connection.State != ConnectionState.Open )
                        cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
                finally { if (trn == null) { cmd.Connection.Dispose(); cmd.Connection = null;} }
        }
        public static object ExecuteScalar(string cmdText, params object[] paramList)
        {
            return ExecuteScalar(null, cmdText, paramList);
        }
        public static object ExecuteScalar(SqlTransaction trn, string cmdText, params object[] paramList)
        {
            using ( SqlCommand cmd = CreateCommand(cmdText, trn) )
                try
                {
                    for (int i = 0; i+1<paramList.Length; i+=2 )
                        cmd.Parameters.AddWithValue((string)paramList[i], paramList[i+1]);

                    if ( cmd.Connection.State != ConnectionState.Open )
                        cmd.Connection.Open();
                    return cmd.ExecuteScalar();
                }
                finally { if (trn == null) { cmd.Connection.Dispose(); cmd.Connection = null;} }
        }
        public static Object UpdateOrInsert(string tableName, string columnID, int ID, params object[] paramList)
        {
            return UpdateOrInsert(null, tableName, columnID, ID, paramList);
        }

        public static Object UpdateOrInsert(SqlTransaction trn, string tableName, string columnID, int ID, params object[] paramList)
        {
            StringBuilder sb = new StringBuilder();
            String paramName;

            SqlParameter retParam;
            using ( SqlCommand cmd = CreateCommand("", trn) )
                try
                {
                    cmd.Parameters.AddWithValue("@ID", ID);
                    retParam = cmd.Parameters["@ID"];

                    if ( ID == INVALID_ID ) // add new record
                    {
                        StringBuilder sbValues = new StringBuilder();
                        sb.AppendFormat("INSERT INTO [{0}] (", tableName);
                        for (int i = 0; i+1<paramList.Length; i+=2 )
                        {
                            if ( paramList[i+1]==null )
                                paramName = "NULL"; // use this way as AddWithValue(..., DBNull.Value) throws exception e.g. for blob (varbinary(max))
                            else
                            { 
                                paramName = String.Format("@p{0}", i/2);
                                cmd.Parameters.AddWithValue(paramName, (paramList[i+1]==null)?DBNull.Value:paramList[i+1]);
                            }

                            if ( i > 0 )
                            { 
                                sb.Append(',');
                                sbValues.Append(',');
                            }
                            sb.AppendFormat("[{0}]", (string)paramList[i]);
                            sbValues.AppendFormat(paramName);
                        }
                        sb.AppendFormat(") VALUES ({0})"+
                                        ";SELECT @ID = @@IDENTITY",
                                        sbValues.ToString());

                        retParam.Direction = ParameterDirection.Output;
				        retParam.SourceColumn = columnID;
                    }
                    else                    // update existing
                    { 
                        sb.AppendFormat("UPDATE [{0}] SET ", tableName);
                        for (int i = 0; i+1<paramList.Length; i+=2 )
                        {
                            if ( paramList[i+1]==null )
                                paramName = "NULL"; // use this way as AddWithValue(..., DBNull.Value) throws exception e.g. for blob (varbinary(max))
                            else
                            { 
                                paramName = String.Format("@p{0}", i/2);
                                cmd.Parameters.AddWithValue(paramName, paramList[i+1]); //(paramList[i+1]==null)?DBNull.Value:paramList[i+1]);
                            }

                            if ( i > 0 )
                                sb.Append(',');
                            sb.AppendFormat("[{0}]={1}", (string)paramList[i], paramName);
                        }

                        sb.AppendFormat(" WHERE [{0}]=@ID", columnID);
                    }

                    // execute
                    cmd.CommandText = sb.ToString();
                    if ( cmd.Connection.State != ConnectionState.Open )
                        cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
                finally { if (trn == null) { cmd.Connection.Dispose(); cmd.Connection = null;} }

            return retParam.Value;
        }
	}
}
