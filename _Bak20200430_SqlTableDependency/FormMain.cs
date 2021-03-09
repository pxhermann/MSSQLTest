using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base;

namespace MSSQLTest
{
    public partial class FormMain : Form
    {
        private AppSetting appCfg;
        private SqlTransaction sqlTrn = null;
        private SqlDependency sqlDependency = null;
        private SqlConnection sqlConnDependency = null;
        private SqlCommand sqlCmdDependency = null;

        private SqlTableDependency<Product> sqlTableDep = null;

        public FormMain()
        {
            InitializeComponent();
        }
#region event handlers
        private void FormMain_Load(object sender, EventArgs e)
        {
            siComputer.Text = System.Environment.MachineName;
            siUser.Text = System.Environment.UserName; //= System.Environment.GetEnvironmentVariable("USERNAME");
//          siUser.Text = System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString();   // computername/username

            ToolStripControlHost tsiOnTop = new ToolStripControlHost(siOnTop);
            tsiOnTop.Margin = new Padding(10, 0, 0, 0);
            statusMain.Items.Insert(0, tsiOnTop);

            try { appCfg = AppSetting.Load(); }
            catch (Exception ex) { GM.ShowErrorMessageBox(this, "Reading application setup failed!", ex); }

            // restore window position
            if (appCfg.WindowPosition != Rectangle.Empty)
            {
                DesktopBounds = appCfg.WindowPosition;
                if (appCfg.WindowState == FormWindowState.Maximized)
                    WindowState = FormWindowState.Maximized;
                else
                    WindowState = FormWindowState.Normal;
            }

            siOnTop.Checked = appCfg.AlwaysOnTop;

            UpdateControls();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ( sqlTrn != null )
                try
                { 
                    sqlTrn.Rollback();
                    sqlTrn.Dispose();
                } catch { };

            StopSqlDepenedency();

            // save window position
            appCfg.WindowPosition = (WindowState == FormWindowState.Normal) ? DesktopBounds : RestoreBounds;
            appCfg.WindowState = WindowState;
            appCfg.AlwaysOnTop = siOnTop.Checked;

            appCfg.Save();
        }
        private void FormMain_Shown(object sender, EventArgs e)
        {
            DB.ConnData = appCfg.Sql;
            while (true)
            {
                Cursor = Cursors.WaitCursor;
                try
                {
                    if (DB.ConnData.IsValid())
                        using (SqlConnection conn = new SqlConnection(DB.ConnData.GetConnectionString()))
                        {
                            conn.Open();
                            siSQLServer.Text = DB.GetVersionInfo();
                            break;
                        }
                }
                catch (Exception ex) { GM.ShowErrorMessageBox(this, "Connecting to SQL failed!", ex); }
                finally { Cursor = Cursors.Default; }

                if ( !SetupDB() && GM.ShowQuestionMessageBox(this, "SQL setup required. Really to exit?") == DialogResult.Yes)
                {
                    Close();
                    return;
                }
            }
        }

        private void cbTable_DropDown(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                cbTable.Items.Clear();

                DataTable tbl = DB.GetDataTable("SELECT [name] FROM sys.tables ORDER by name");
                if ( tbl != null && tbl.Rows.Count > 0 )
                    foreach(DataRow r in tbl.Rows)
                        cbTable.Items.Add(GM.ConvertToString(r[0]));
            }
            catch (Exception ex)
            {
                GM.ShowErrorMessageBox(this, "Reading database list failed!", ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        class Product
        {
            public int prod_ID  { get; set; }
            public string prod_Code  { get; set; }
            public string prod_Name  { get; set; }
        }


        private void chbCaptureDataChange_CheckedChanged(object sender, EventArgs e)
        {
            try
            { 
                StopSqlDepenedency();

                if ( chbCaptureDataChange.Checked )
                {
                    try
                    { 
                        SqlClientPermission perm = new SqlClientPermission(System.Security.Permissions.PermissionState.Unrestricted);
                        perm.Demand();
                    }
                    catch(Exception ex)
                    {
                        GM.ShowErrorMessageBox(this, "User needs unrestricted permissions to receive notifications", ex);
                        return;
                    }
/*                    var mapper = new ModelToTableMapper<Product>();
                    mapper.AddMapping(c => c.prod_ID, "prod_id");
                    mapper.AddMapping(c => c.prod_Code, "prod_code");
                    mapper.AddMapping(c => c.prod_Name, "prod_name");

                    sqlTableDep = new SqlTableDependency<Product>(DB.ConnData.GetConnectionString(), "Product", mapper: mapper);
                    sqlTableDep.OnChanged += Dep_OnChanged;
                    sqlTableDep.Start();
*/
                    if ( String.IsNullOrEmpty(cbTable.Text) )
                    {
                        GM.ShowErrorMessageBox(this, "Select table!");
                        cbTable.Focus();
                        return;
                    }
                    // ensure broke service 
                    using ( SqlConnection conn = DB.CreateConnection() )
                    {
                        conn.Open();

                        String s = String.Format("SELECT is_broker_enabled FROM sys.databases WHERE name = '{0}'", DB.ConnData.Database);
                        DataTable tbl = new DataTable();
                        (new SqlDataAdapter(s, conn)).Fill(tbl);
                        if ( tbl != null && tbl.Rows.Count>0 && !((bool)tbl.Rows[0][0]) )
                        {
                            if ( GM.ShowQuestionMessageBox(this, String.Format("Database '{0}' has not brooker enabled. Enable it?", DB.ConnData.Database)) != DialogResult.Yes )
                                return;

                            s = String.Format("ALTER DATABASE {0} SET ENABLE_BROKER WITH ROLLBACK IMMEDIATE", DB.ConnData.Database);
                            using ( SqlCommand cmd = new SqlCommand(s, conn) )
                                cmd.ExecuteNonQuery();
                        }
                    }

                    // create dependency connection
                    SqlDependency.Start(DB.ConnData.GetConnectionString()); ///sqlConnDependency.ConnectionString);
                    // open connection
                    sqlConnDependency = DB.CreateConnection();
                    // start monitoring
                    string sql = "SELECT * FROM "+cbTable.Text;
                    sqlCmdDependency = new SqlCommand(sql, sqlConnDependency);

                    sqlDependency = new SqlDependency(sqlCmdDependency);
                    sqlDependency.OnChange += SqlDependency_OnChange;

                    DataTable tblDep = new DataTable();
                    (new SqlDataAdapter(sqlCmdDependency)).Fill(tblDep);
                    dgCaptureChange.AutoGenerateColumns = true;
                    dgCaptureChange.DataSource = new DataView(tblDep);
                }
            }
            catch (Exception ex) 
            { 
                StopSqlDepenedency();
                GM.ShowErrorMessageBox(this, "Error occured", ex); 
            }
        }

        private void Dep_OnChanged(object sender, TableDependency.SqlClient.Base.EventArgs.RecordChangedEventArgs<Product> e)
        {

            Console.WriteLine(Environment.NewLine);

            var changedEntity = e.Entity;
            Console.WriteLine(@"DML operation: " + e.ChangeType);
            Console.WriteLine(@"ProdID:    " + e.Entity.prod_ID);
            Console.WriteLine(@"Name:      " + e.Entity.prod_Name);
        }

        delegate void DelgSqlDependency_OnChange(object sender, SqlNotificationEventArgs e);
        private void SqlDependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if ( InvokeRequired )
            {
                Invoke(new DelgSqlDependency_OnChange(SqlDependency_OnChange), new object[] {sender, e} );
                return;
            }
            GM.ShowInfoMessageBox(this, String.Format("SQL change appeared.{0}{0}Info: {1}{0}Source: {2}{0}Type: {3}", Environment.NewLine, e.Info.ToString(), e.Source.ToString(), e.Type.ToString()));
        }

        private void miAction_Click(object sender, EventArgs e)
        {
            if (sender == miAppExit)
                Application.Exit();
            else if (sender == miAppSetupDB)
                SetupDB();
            else if (sender == miHelpAbout)
            {
                using (DlgAbout dlg = new DlgAbout())
                    dlg.ShowDialog(this);
            }

        }

        private void siSQLServer_DoubleClick(object sender, EventArgs e)
        {
            SetupDB();
        }
        private void siOnTop_CheckedChanged(object sender, EventArgs e)
        {
 			TopMost = siOnTop.Checked;
        }
#endregion

#region helper functions
        private bool SetupDB()
        {
            using (DlgSetupDB dlg = new DlgSetupDB())
            {
                dlg.data.CopyFrom(DB.ConnData);
                if (dlg.ShowDialog(this) != DialogResult.OK)
                    return false;

                try
                {
                    DB.ConnData.CopyFrom(dlg.data);
                    siSQLServer.Text = DB.GetVersionInfo();

                    appCfg.Save();       // DB.ConnData == setupData.Sql, see. above
                    return true;
                }
                catch (Exception ex) { GM.ShowErrorMessageBox(this, "Saving database setup failed!", ex); }
            }

            return false;
        }
        private void UpdateControls()
        {
            btnTrnBegin.Enabled = (sqlTrn == null);
            btnTrnCommit.Enabled = btnTrnRollback.Enabled = (sqlTrn != null);
        }
        private void ParseScriptCommands(string strScript, ArrayList arrCmd)
        {
            arrCmd.Clear();		// reset first

            string strHlp;
            string strNoCase = strScript.ToUpper();		// avoid case sensitivity

            int nStart = 0;
            int nEnd = -2;
            do
            {
                nEnd = strNoCase.IndexOf("GO", nEnd + 2);	// avoid case sensitivity when searching GO

                // find word GO in s (not sNoCase)      ~  but keep original case for extracted commands
                if (nEnd > 0 && Char.IsWhiteSpace(strScript, nEnd - 1) &&						// white space from the left
                    (nEnd >= strScript.Length - 2 || Char.IsWhiteSpace(strScript, nEnd + 2)))	// white space from the right 
                {
                    strHlp = strScript.Substring(nStart, nEnd - nStart).Trim();
                    if (strHlp.Length > 0)
                        arrCmd.Add(strHlp);

                    nStart = nEnd + 2;
                }
            }
            while (nEnd >= 0);

            // add element after last separator
            if (strScript.Length > nStart)
            {
                strHlp = strScript.Substring(nStart).Trim();
                if (strHlp.Length > 0)
                    arrCmd.Add(strHlp);
            }
        }
        private void StopSqlDepenedency()
        { 
            dgCaptureChange.DataSource = null;
            dgCaptureChange.Rows.Clear();
            dgCaptureChange.Columns.Clear();

            if ( sqlDependency != null )
            { 
                if ( sqlConnDependency != null )
                    SqlDependency.Stop(sqlConnDependency.ConnectionString);
                sqlDependency = null;
            }
            if ( sqlCmdDependency != null )
            {
                sqlCmdDependency.Dispose();
                sqlCmdDependency = null;
            }
            if ( sqlConnDependency != null )
            {
                sqlConnDependency.Dispose();
                sqlConnDependency = null;
            }

            if ( sqlTableDep != null )
                sqlTableDep.Dispose();
        }
#endregion

        private void btnTrnBegin_Click(object sender, EventArgs e)
        {
            try
            {
                if ( sqlTrn != null )
                { 
                    GM.ShowErrorMessageBox(this, "Transaction already opened!");
                    return;
                }

                SqlConnection conn = DB.CreateConnection();
                conn.Open();
                sqlTrn = conn.BeginTransaction();
                sqlTrn.InitializeLifetimeService();
            }
            catch(Exception ex)
            {
                GM.ShowErrorMessageBox(this, "Error occured when beginning transaction!", ex);
            }
            finally
            {
                UpdateControls();
            }
        }
        private void btnTrnEnd_Click(object sender, EventArgs e)
        {
            try
            {
                if ( sqlTrn == null )
                { 
                    GM.ShowErrorMessageBox(this, "Transaction already finished!");
                    return;
                }

                if ( sender == btnTrnCommit )
                    sqlTrn.Commit();
                else if ( sender == btnTrnRollback )
                    sqlTrn.Rollback();
            }
            catch(Exception ex)
            {
                GM.ShowErrorMessageBox(this, "Error occured when ending transaction!", ex);
            }
            finally
            {
                if ( sqlTrn != null )
                    try { sqlTrn.Dispose(); } catch { };
                sqlTrn = null;
                UpdateControls();
            }
        }
        private void btnScriptOpen_Click(object sender, EventArgs e)
        {
            String fileName = "";
            using ( OpenFileDialog dlg = new OpenFileDialog() )
            {
                dlg.Filter = "Sql script files (*.sql)|*.sql|All files (*.*) |*.*";
                dlg.FilterIndex = 1;
                dlg.DefaultExt = "srt";
				dlg.Multiselect = false;
                dlg.CheckFileExists = true;
                dlg.RestoreDirectory = true;

                if (dlg.ShowDialog(this) != DialogResult.OK)
                    return;
                fileName = dlg.FileName;
            }
            // read file content
            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                    tbScript.Text = sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                GM.ShowErrorMessageBox(this, String.Format("Reading file '{0}' failed!", fileName), ex);
            }
        }
        private void btnScriptSave_Click(object sender, EventArgs e)
        {
            // check script
            string strScript = tbScript.Text.Trim();
            if (strScript.Length < 1)
            {
                MessageBox.Show(this, "No script specified!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbScript.SelectAll();
                tbScript.Focus();
                return;
            }
            // save script to file
            String fileName = "";
            using ( SaveFileDialog dlg = new SaveFileDialog() )
            { 
                dlg.Filter = "Sql script files (*.sql)|*.sql";
                dlg.FilterIndex = 0;
                dlg.DefaultExt = "srt";
                dlg.OverwritePrompt = true;
                dlg.AddExtension = true;
                dlg.RestoreDirectory = true;

                if (dlg.ShowDialog(this) != DialogResult.OK)
                    return;
                fileName = dlg.FileName;
            }
            // read file content
            try
            {
                using (StreamWriter sr = new StreamWriter(fileName))
                    sr.Write(tbScript.Text);
            }
            catch (Exception ex)
            {
                GM.ShowErrorMessageBox(this, String.Format("Writing script to file '{0}' failed!", fileName), ex);
                return;
            }
            GM.ShowInfoMessageBox(this, String.Format("Script was saved to file '{0}'.", fileName));
        }
        private void btnScriptExecute_Click(object sender, EventArgs e)
        {
            // parse script commands
            ArrayList arrCmd = new ArrayList();
            ParseScriptCommands(tbScript.Text, arrCmd);
            if (arrCmd.Count < 1)
            {
                GM.ShowErrorMessageBox(this, "No script specified!");
                tbScript.SelectAll();
                tbScript.Focus();
                return;
            }

            Cursor prevCur = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
			try
			{
                using ( SqlCommand cmd = DB.CreateCommand("", sqlTrn) )
                {
                    cmd.CommandTimeout = 0; // wait indefinitely until the execution is complete
                                            // default value is 30 s, what may cause timeexpiration error, if too many records are affected by the command
                    // execute all commands from the script
                    foreach (string strCmd in arrCmd)
                    {
                        cmd.CommandText = strCmd;
                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (SqlException ex)
                        {
                            int idx = tbScript.Text.IndexOf(strCmd);
                            if (idx >= 0)
                            {
                                tbScript.Select(idx, strCmd.Length);
                                tbScript.ScrollToCaret();
                                tbScript.Focus();
                            }
                            // display error message
                            GM.ShowErrorMessageBox(this, string.Format("Error occured when processing command!{0}'{1}'", Environment.NewLine, strCmd), ex);
                            return;
                        }
                    }
                }
                GM.ShowInfoMessageBox(this, "Script executed successfully.");
			}
			catch(Exception ex)
			{
				GM.ShowErrorMessageBox(this, "Executing script failed!", ex);
			}
			finally
			{
                Cursor.Current = prevCur;
			}
        }
    }
}
