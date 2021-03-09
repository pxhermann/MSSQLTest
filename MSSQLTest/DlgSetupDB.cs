using Microsoft.Win32;
using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MSSQLTest
{
    public partial class DlgSetupDB : Form
    {
        public SqlConnData data = new SqlConnData();
        public DlgSetupDB()
        {
            InitializeComponent();
        }
        private void DlgSetupDB_Load(object sender,EventArgs e)
        {
            // SQL server
            cbSqlServer.Text = data.Server;
            tbSqlUser.Text = data.User;
            tbSqlPwd.Text  = data.PwdDecrypted;

            radioAuthSQL.Checked = data.AuthSQL;
            radioAuthWin.Checked = !data.AuthSQL;
            radioAuthSQL_CheckedChanged(null, null);

            cbSqlDB.Text = data.Database;
        }
        private void DlgSetupDB_FormClosing(object sender,FormClosingEventArgs e)
        {
            if ( DialogResult == DialogResult.OK )
                e.Cancel = !SaveData(true);
        }
        private void cbSqlServer_DropDown(object sender,EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            cbSqlServer.BeginUpdate();
            try
            {
                cbSqlServer.Items.Clear();
                foreach (DataRow row in SqlDataSourceEnumerator.Instance.GetDataSources().Rows)
                    cbSqlServer.Items.Add(row[0]);

                //var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
                //var key = baseKey.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL");
                //foreach (string sqlserver in key.GetValueNames())
                //    cbSqlServer.Items.Add(string.Format("{0}\\{1}", Environment.MachineName, sqlserver));
            }
            catch(Exception ex) { GM.ShowErrorMessageBox(this, "Error occured when reading SQL server list!", ex); }
            finally
            {
                cbSqlServer.EndUpdate();
                Cursor = Cursors.Default;
            }
        }
        private void cbSqlDB_DropDown(object sender,EventArgs e)
        {
            if ( !SaveData(false) )
                return;

            Cursor = Cursors.WaitCursor;
            cbSqlDB.BeginUpdate();
            try
            {
                cbSqlDB.Items.Clear();
                using (SqlConnection conn = new SqlConnection(data.GetConnectionString(false)))
                {
                    conn.Open();

                    // open recordset with databases
                    using (SqlCommand cmd = new SqlCommand("SELECT name FROM sys.databases ORDER BY name ASC", conn)) // SELECT name FROM master..sysdatabases WHERE name LIKE '%system%' ORDER BY name ASC", conn); 
                    using (SqlDataReader reader = cmd.ExecuteReader())
                        while (reader.Read())
                            cbSqlDB.Items.Add(reader[0]);
                }
            }
            catch (Exception ex) { GM.ShowErrorMessageBox(this, "Error occured when reading database list!", ex);}
            finally
            {
                cbSqlDB.EndUpdate();
                Cursor = Cursors.Default;
            }
        }
        private void radioAuthSQL_CheckedChanged(object sender,EventArgs e)
        {
            tbSqlUser.Enabled = radioAuthSQL.Checked;
            tbSqlPwd.Enabled = radioAuthSQL.Checked;
        }
        private void btnSqlTestConn_Click(object sender,EventArgs e)
        {
            if ( !SaveData(false) )
                return;

            Cursor = Cursors.WaitCursor;
            try
            {
                using (SqlConnection conn = new SqlConnection(data.GetConnectionString(false)))
                    conn.Open();

                GM.ShowInfoMessageBox(this, "Connection to SQL server succeeded!");
            }
            catch (Exception ex) { GM.ShowErrorMessageBox(this, "Connection to SQL server failed!", ex); }
            finally { Cursor = Cursors.Default; }
        }

        private bool SaveData(bool inclDB)
        {
            // server
            data.Server = cbSqlServer.Text.Trim();
            if ( string.IsNullOrEmpty(data.Server) )
            {
                GM.ShowErrorMessageBox(this, "Enter server name!");
                cbSqlServer.Focus();
                return false;
            }
            // authentication
            data.AuthSQL = radioAuthSQL.Checked;
            if ( data.AuthSQL )
            {
                // SQL user
                data.User = tbSqlUser.Text.Trim();
                if ( string.IsNullOrEmpty(data.User) )
                {
                    GM.ShowErrorMessageBox(this, "Enter user!");
                    tbSqlUser.SelectAll();
                    tbSqlUser.Focus();
                    return false;
                }
                // SQL pwd
                data.PwdDecrypted = tbSqlPwd.Text;
            }

            // database
            if ( inclDB )
            { 
                data.Database = cbSqlDB.Text.Trim();
                if ( string.IsNullOrEmpty(data.Database) )
                {
                    GM.ShowErrorMessageBox(this, "Enter database!");
                    cbSqlDB.Focus();
                    return false;
                }
            }

            return true;
        }
    }
}
