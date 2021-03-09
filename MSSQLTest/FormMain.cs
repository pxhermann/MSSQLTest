//using Microsoft.SqlServer.XEvent.Linq;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace MSSQLTest
{
    public partial class FormMain : Form
    {
        private AppSetting appCfg;

        private SqlConnection sqlDepConnection = null;
        private SqlCommand sqlDepCommand = null;
        private SqlDependency sqlDependency = null;

        public FormMain()
        {
            InitializeComponent();
        }
        protected override bool ProcessCmdKey(ref Message msg,Keys keyData)
        {
            switch ( keyData )
			{
            case (Keys.Control | Keys.O):
                tsbScriptOpen.PerformClick();
                return true;
            case (Keys.Control | Keys.S):
                tsbScriptSave.PerformClick();
                return true;
            case Keys.F5:
                tsbScriptExecute.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
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

//            StopExEventMonitor();

            // save window position
            appCfg.WindowPosition = (WindowState == FormWindowState.Normal) ? DesktopBounds : RestoreBounds;
            appCfg.WindowState = WindowState;
            appCfg.AlwaysOnTop = siOnTop.Checked;

            appCfg.Save();
        }
        private void cbTable_DropDown(object sender, EventArgs e)
        {
            if ( !DB.ConnData.IsValid() )
                return;

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                cbSqlDepTable.Items.Clear();

                DataTable tbl = DB.GetDataTable("SELECT [name] FROM sys.tables ORDER by name");
                if ( tbl != null && tbl.Rows.Count > 0 )
                    foreach(DataRow r in tbl.Rows)
                        cbSqlDepTable.Items.Add(GM.ConvertToString(r[0]));
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
        private void cbSqlDepTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ( String.IsNullOrEmpty(cbSqlDepTable.Text) )
                return;

            try
            { 
                StringBuilder sbInsert = new StringBuilder();
                StringBuilder sbInsertVal = new StringBuilder();
                StringBuilder sbUpdate = new StringBuilder();
                String colPKName = "", colPKValue = "";

                using (SqlConnection conn = DB.OpenConnection())
                {
                    // open recordset with databases
                    using (SqlCommand cmd = new SqlCommand("", conn))
                    {
                    // get primary key
                        cmd.CommandText = String.Format("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE"+Environment.NewLine+
                                                        "WHERE TABLE_NAME LIKE 'Product' AND CONSTRAINT_NAME LIKE 'PK%'",
                                                        cbSqlDepTable.Text);
                        colPKName = GM.ConvertToString(cmd.ExecuteScalar());
                    // read columns
                        cmd.CommandText = String.Format("SELECT column_name, data_type FROM information_schema.COLUMNS"+Environment.NewLine+
                                                        "WHERE table_name = '{0}'", 
                                                        cbSqlDepTable.Text);
                        using (SqlDataReader r = cmd.ExecuteReader())
                            while (r.Read())
                            {
                                String colName = r.GetString(0);

                                String colValue = "'test'";
                                switch ( Convert.ToString(r["data_type"]).ToLower() )
                                {
                                case "bit":      colValue = "1"; break;
                                case "datetime": colValue = "GetDate()"; break;
                                case "decimal":  
                                case "smallint": 
                                case "int":      colValue = "100"; break;
                                }

                                if ( String.IsNullOrEmpty(colPKName) )
                                    colPKName = colName;

                                if ( colName.Equals(colPKName, StringComparison.OrdinalIgnoreCase) )
                                    colPKValue = colValue;
                                else
                                {
                                    if ( sbInsert.Length > 0 )    sbInsert.Append(',');
                                    if ( sbInsertVal.Length > 0 ) sbInsertVal.Append(',');
                                    if ( sbUpdate.Length > 0 )    sbUpdate.Append(',');

                                    sbInsert.AppendFormat("[{0}]", colName);
                                    sbInsertVal.Append(colValue);
                                    sbUpdate.AppendFormat("[{0}] = {1}", colName, colValue);
                                }
                            }
                    }
                }
                String s = String.Format("SELECT * FROM {0}", cbSqlDepTable.Text);
                int selLen = s.Length;
                s += String.Format("{0}{0}-- INSERT INTO {1} ({2}) VALUES ({3})", Environment.NewLine, cbSqlDepTable.Text, sbInsert.ToString(), sbInsertVal.ToString());
                s += String.Format("{0}{0}-- UPDATE {1} SET {2} WHERE {3} = {4}", Environment.NewLine, cbSqlDepTable.Text, sbUpdate.ToString(), colPKName, colPKValue);
                s += String.Format("{0}{0}-- DELETE FROM {1} WHERE {2} = {3}{0}", Environment.NewLine, cbSqlDepTable.Text, colPKName, colPKValue);

                tbScript.Text = s + tbScript.Text;
                tbScript.Select(0, selLen);
            }
            catch(Exception ex)
            {
                GM.ShowErrorMessageBox(this, "Error occured when reading table structure '{0}'!", ex);
            }
        }
        private void miAction_Click(object sender, EventArgs e)
        {
            if (sender == miAppExit)
                Application.Exit();
            else if (sender == miDBConnect || sender == tsbDBConnect )
                DbConnect();
            else if (sender == miDBDisconnect || sender == tsbDBDisconnect )
                DbDisconnect();
            else if (sender == miHelpAbout)
            {
                using (DlgAbout dlg = new DlgAbout())
                    dlg.ShowDialog(this);
            }
        }

        private void siSQLServer_DoubleClick(object sender, EventArgs e)
        {
            tsbDBConnect.PerformClick();
        }
        private void siOnTop_CheckedChanged(object sender, EventArgs e)
        {
 			TopMost = siOnTop.Checked;
        }
#endregion

#region dependency
        private void chbSqlDepCaptureChange_CheckedChanged(object sender, EventArgs e)
        {
            try
            { 
                StopSqlDepenedency();
                if ( chbSqlDepCaptureChange.Checked )
                    StartSqlDependency();

                cbSqlDepTable.Enabled = !chbSqlDepCaptureChange.Checked;
            }
            catch (Exception ex) 
            { 
                StopSqlDepenedency();
                GM.ShowErrorMessageBox(this, "Error occured", ex); 
            }
        }
        private void StartSqlDependency()
        {
            try
            {
                if ( sqlDepConnection == null )
                {
                    if ( String.IsNullOrEmpty(cbSqlDepTable.Text) )
                    {
                        GM.ShowErrorMessageBox(this, "Select table!");
                        cbSqlDepTable.Focus();
                        return;
                    }

                    // check permissions
                    try
                    { 
                        SqlClientPermission perm = new SqlClientPermission(System.Security.Permissions.PermissionState.Unrestricted);
                        perm.Demand();
                    }
                    catch(Exception ex)
                    {
                        GM.ShowErrorMessageBox(this, "User needs unrestricted permissions to receive notifications!", ex);
                        return;
                    }
                    
                    lvSqlDepChanges.Items.Clear();

                    // 1. Initiate a SqlDependency connection to the server.
                    SqlDependency.Start(DB.ConnData.GetConnectionString());  //sqlConnDependency.ConnectionString);

                    // 2. create dependency connection
                    sqlDepConnection = DB.OpenConnection();

                    // ensure broker service 
                    String s = String.Format("SELECT is_broker_enabled FROM sys.databases WHERE name = '{0}'", DB.ConnData.Database);
                    DataTable tbl = new DataTable();
                    (new SqlDataAdapter(s, sqlDepConnection)).Fill(tbl);
                    if ( tbl != null && tbl.Rows.Count>0 && !((bool)tbl.Rows[0][0]) )
                    {
                        if ( GM.ShowQuestionMessageBox(this, String.Format("Database '{0}' has not broker enabled. Enable it?", DB.ConnData.Database)) != DialogResult.Yes )
                            return;

                        s = String.Format("ALTER DATABASE {0} SET ENABLE_BROKER WITH ROLLBACK IMMEDIATE", DB.ConnData.Database);
                        using ( SqlCommand cmd = new SqlCommand(s, sqlDepConnection) )
                            cmd.ExecuteNonQuery();
                    }
                    // ?? For the query notification samples to run correctly, the following Transact-SQL statements must be executed on the database server.
                    // string queue = cbSqlDepTable.Text+"ChangeMessages";
                    // string service = cbSqlDepTable.Text+"ChangeService";
                    // DB.ExecuteNoQuery(string.format("CREATE QUEUE {0}", queue);
                    // DB.ExecuteNoQuery(string.format("CREATE SERVICE {0} ON QUEUE {1}", service, queue);

                    // 3. create command 
                    // - !!! must use two part names for tables FROM dbo.Table rather than FROM Table
                    // - cannot use *, fields must be designated
                    StringBuilder sb = new StringBuilder();
                    tbl = new DataTable();
                    s = string.Format("SELECT column_name FROM information_schema.COLUMNS"+
                                        " WHERE table_name LIKE '{0}'", 
                                        cbSqlDepTable.Text);
                    using (SqlCommand cmd = new SqlCommand(s, sqlDepConnection) )
                        using ( SqlDataReader r = cmd.ExecuteReader() )
                            while(r.Read())
                            {
                                sb.Append((sb.Length == 0)?"SELECT ":",");
                                sb.Append(r.GetString(0));
                            }
                    sb.AppendFormat(" FROM dbo.{0}", cbSqlDepTable.Text);

                    sqlDepCommand = new SqlCommand(sb.ToString(), sqlDepConnection);

                }
                sqlDepCommand.Notification = null;

                // 4. create SqlDependency object and bind it to SqlCommand object - Internally, this creates a SqlNotificationRequest object and binds it to the command object as needed. 
                // This notification request contains an internal identifier that uniquely identifies this SqlDependency object. It also starts the client listener if it is not already active.
                // You must associate the SqlDependency with the command before you execute the command
                // !!! create new one SqlDependency for each single notification, see. SqlDependency_OnChange
                sqlDependency = new SqlDependency(sqlDepCommand);

                // 5. subscibe an event handler
                sqlDependency.OnChange += SqlDependency_OnChange;

                // !!! execute sqlDepCommand - without it no onChange is fired
                // execute the command using any of the Execute methods of the SqlCommand object. 
                // Because the command is bound to the notification object, the server recognizes that it must generate a notification, and the queue information will point to the dependencies queue.
                if( sqlDepConnection.State == ConnectionState.Closed )
                    sqlDepConnection.Open();
                (new DataTable()).Load(sqlDepCommand.ExecuteReader(CommandBehavior.CloseConnection));
            }
            catch(Exception ex)
            {

                GM.ShowErrorMessageBox(this, "Starting capture changes failed", ex);

                chbSqlDepCaptureChange.Checked = false;
                StopSqlDepenedency();
            }
        }
        private void StopSqlDepenedency()
        { 
            try
            { 
                if ( sqlDependency != null )
                {
                    sqlDependency.OnChange -= SqlDependency_OnChange;
                    sqlDependency = null;
                }
                if ( sqlDepCommand != null )
                {
                    sqlDepCommand.Dispose();
                    sqlDepCommand = null;
                }
                if ( sqlDepConnection != null )
                {
                    sqlDepConnection.Dispose();
                    sqlDepConnection = null;

                    SqlDependency.Stop(DB.ConnData.GetConnectionString()); //  Remove any existing dependency connection 
                }
            }
            catch(Exception ex)
            {
                GM.ShowErrorMessageBox(this, "Error occured when stopping SQL dependency", ex);
            }
        }

        delegate void DelgSqlDependency_OnChange(object sender, SqlNotificationEventArgs e);
        private void SqlDependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if ( InvokeRequired )
            {
                Invoke(new DelgSqlDependency_OnChange(SqlDependency_OnChange), new object[] {sender, e} );
                return;
            }

            lvSqlDepChanges.Items.Insert(0, new ListViewItem(new string [] {DateTime.Now.ToLongTimeString(), e.Source.ToString(), e.Info.ToString()}));

            SqlDependency dependency = sender as SqlDependency;
            if ( dependency != null )   // onChange event is fired only once !!! so remove the existing one so a new one can be added in StartSqlDependecy
                dependency.OnChange -= SqlDependency_OnChange;

            StartSqlDependency();
        }
        #endregion

#region DB
        private void DbConnect()
        { 
            if (!DbSetup())
                return;

            if (DB.ConnData.IsValid())
                try
                {
                    using (SqlConnection conn = DB.OpenConnection())
                        ;
                }
                catch (Exception ex) 
                { 
                    GM.ShowErrorMessageBox(this, "Connecting to SQL failed!", ex);
                    DB.ConnData.Reset();
                }
                finally { Cursor = Cursors.Default; }

            UpdateControls();

        }
        private void DbDisconnect()
        {
            DB.ConnData.Reset();
            UpdateControls();
        }
        private bool DbSetup()
        {
            using (DlgSetupDB dlg = new DlgSetupDB())
            {
                dlg.data.CopyFrom(appCfg.Sql);
                if (dlg.ShowDialog(this) != DialogResult.OK)
                    return false;

                try
                {
                    if (dlg.data.GetConnectionString() != DB.ConnData.GetConnectionString())
                    {
                        StopSqlDepenedency();
                        chbSqlDepCaptureChange.Checked = false;
                    }
                    DB.ConnData.CopyFrom(dlg.data);
                    appCfg.Sql.CopyFrom(dlg.data);
                    return true;
                }
                catch (Exception ex) { GM.ShowErrorMessageBox(this, "Saving database setup failed!", ex); }
            }

            return false;
        }
#endregion

#region SQL script operation
        private void scriptOpen_Click(object sender, EventArgs e)
        {
            String fileName = "";
            using (OpenFileDialog dlg = new OpenFileDialog())
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
        private void scriptSave_Click(object sender, EventArgs e)
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
            using (SaveFileDialog dlg = new SaveFileDialog())
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
        private void scriptExecute_Click(object sender, EventArgs e)
        {
            dgScriptResult.DataSource = null;
            dgScriptResult.Rows.Clear();
            dgScriptResult.Columns.Clear();

            // parse script commands
            ArrayList arrCmd = new ArrayList();
            ParseScriptCommands(String.IsNullOrEmpty(tbScript.SelectedText)?tbScript.Text:tbScript.SelectedText, arrCmd);
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
                using (SqlConnection conn = DB.OpenConnection())
                using (SqlCommand cmd = new SqlCommand("", conn))
                {
                    cmd.CommandTimeout = 0; // wait indefinitely until the execution is complete
                                            // default value is 30 s, what may cause timeexpiration error, if too many records are affected by the command
                                            // execute all commands from the script
                    foreach (string strCmd in arrCmd)
                    {
                        cmd.CommandText = strCmd;
                        try
                        {
                            if (strCmd.ToLower().Trim().StartsWith("select"))
                            {
                                DataTable tbl = new DataTable();
                                tbl.Load(cmd.ExecuteReader());
                                dgScriptResult.AutoGenerateColumns = true;
                                dgScriptResult.DataSource = new DataView(tbl);
                            }
                            else
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
                if (dgScriptResult.DataSource == null)    // if query has no displayed result, show info message box
                    GM.ShowInfoMessageBox(this, "Script executed successfully.");
            }
            catch (Exception ex)
            {
                GM.ShowErrorMessageBox(this, "Executing script failed!", ex);
            }
            finally
            {
                Cursor.Current = prevCur;
            }
        }
#endregion    

#region SQL transaction
        private SqlTransaction sqlTrn = null;

        private void trnBegin_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlTrn != null)
                {
                    GM.ShowErrorMessageBox(this, "Transaction already opened!");
                    return;
                }

                SqlConnection conn = DB.OpenConnection();
                sqlTrn = conn.BeginTransaction();

                //                StartExEventMonitor(OnTransactionFinished);
            }
            catch (Exception ex)
            {
                GM.ShowErrorMessageBox(this, "Error occured when beginning transaction!", ex);
            }
            finally
            {
                UpdateControls();
            }
        }

        private void trnEnd_Click(object sender, EventArgs e)
        {
            try
            {
                if ( sqlTrn == null )
                { 
                    GM.ShowErrorMessageBox(this, "Transaction already finished!");
                    return;
                }

                if ( sender == tsbTrnCommit )
                    sqlTrn.Commit();
                else if ( sender == tsbTrnRollback )
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
#endregion

/*
#region Extended events - used here to catch end of transaction.
        private Dictionary<Thread, QueryableXEventData> mapThreads = new Dictionary<Thread, QueryableXEventData>();
        delegate void TransactionFinished(bool commited, long trnID);
        private void OnTransactionFinished(bool commited, long trnID)
        {
            if ( InvokeRequired )
            {
                Invoke(new TransactionFinished(OnTransactionFinished), new object[] {commited, trnID} );
                return;
            }

            GM.ShowErrorMessageBox(this, String.Format("Transaction (id: {0}) finished with result: {1}", trnID, commited?"COMMIT":"ROLLBACK"));
        }

        private void StartExEventMonitor(TransactionFinished onTrnFinished)
        {
            Thread t = new Thread(ThreadProc);
            t.Start(new object[] {onTrnFinished, sqlTrn} );
        }
        private void StopExEventMonitor()
        {
            List<Thread> arrThread = new List<Thread>();
            List<QueryableXEventData> arrExEvent = new List<QueryableXEventData>();
            // mapThreads is used from threads, so lock it and read its content to temporary arrays
            lock ( mapThreads ) 
                foreach(Thread exEventThread in mapThreads.Keys)
                {
                    arrThread.Add(exEventThread);
                    arrExEvent.Add(mapThreads[exEventThread]);
                }
            // stop extended event monitors
            foreach(QueryableXEventData exEvents in arrExEvent)
                if ( exEvents != null )
                    try { exEvents.Dispose(); }
                    catch(Exception ex) { GM.ShowErrorMessageBox(this, "Error occured when stopping SQL Extended event monitor", ex); }
            // kill corresponding threads
            foreach(Thread exEventThread in arrThread)
                try
                { 
                    exEventThread.Join(2000);  // wait 2 second

                    if (exEventThread.IsAlive ) // if thread is still alive, kill it
				        exEventThread.Abort();
                }
                catch(Exception ex) { GM.ShowErrorMessageBox(this, "Error occured when stopping SQL Extended event monitor thread", ex); }
            lock ( mapThreads )
                mapThreads.Clear();
        }
        private void ThreadProc(object procParam)
        {
            object[] arrParam = (object[])procParam;
            if ( arrParam == null || arrParam.Length < 2 ||
                 !(arrParam[0] is TransactionFinished) ||
                 !(arrParam[1] is SqlTransaction) )
                return;
            TransactionFinished onTrnFinished = (TransactionFinished)arrParam[0];

            String sessionName = "";
            QueryableXEventData exEvents = null;
            try
            {
                long dbID, trnID;
                SqlTransaction trn = (SqlTransaction)arrParam[1];
                using ( SqlCommand cmd = new SqlCommand("", trn.Connection, trn) )
                {
                    if (cmd.Connection.State != ConnectionState.Open)
                        cmd.Connection.Open();

                    // get database ID
                    cmd.CommandText = "SELECT DB_ID()";
                    dbID = GM.ConvertToLong(cmd.ExecuteScalar());
                    // get current transaction ID
                    cmd.CommandText = "SELECT transaction_id FROM sys.dm_tran_current_transaction";
                    trnID = GM.ConvertToLong(cmd.ExecuteScalar());
                }

                using ( SqlConnection conn = DB.OpenConnection() )
                using ( SqlCommand cmd = new SqlCommand("", conn) )
                {
                    sessionName = String.Format("MSSQLTEST_TRNANSACTIONFINISHED_{0}", trnID);
                    // check session, drop if exists
                    cmd.CommandText = String.Format("IF EXISTS (SELECT * FROM sys.server_event_sessions WHERE name = '{0}')"+Environment.NewLine+
                                                    "BEGIN"+Environment.NewLine+
                                                    "DROP EVENT SESSION {0} ON SERVER;"+Environment.NewLine+
                                                    "END",
                                                    sessionName);
                    cmd.ExecuteNonQuery();

                    // create sesstion
                    cmd.CommandText = String.Format("CREATE EVENT SESSION {0}"+Environment.NewLine+
                                                    "ON SERVER"+Environment.NewLine+
                                                    "ADD EVENT sqlserver.sql_transaction"+Environment.NewLine+
                                                    " ("+Environment.NewLine+
                                                    " ACTION (sqlserver.session_id,sqlserver.database_id,sqlserver.sql_text)"+Environment.NewLine+   // Could add more actions
                                                    " WHERE sqlserver.database_id = {1}"+Environment.NewLine+ // Just this one database 
                                                    " AND transaction_id = {2}"+Environment.NewLine+
                                                    " AND transaction_state > 0"+Environment.NewLine+ // 0-Begin, 1-Commit, 2-Rollback 
                                                    " AND transaction_type = 1"+Environment.NewLine+  // 0-system, 1-user
                                                    " )"+Environment.NewLine+
                                                    "ADD TARGET package0.ring_buffer;",
                                                    sessionName, dbID, trnID);
                    cmd.ExecuteNonQuery();

                    // start the sesssion - after creating, default is for it to not start running automatically
                    cmd.CommandText = String.Format("ALTER EVENT SESSION {0} ON SERVER STATE=START",
                                                    sessionName);
                    cmd.ExecuteNonQuery();
                }

                // read events
                // SELECT
                //  event.value('(event/@name)[1]','varchar(50)') AS event,
                //  DATEADD(hh,DATEDIFF(hh,GETUTCDATE(),CURRENT_TIMESTAMP),event.value('(event/@timestamp)[1]','datetime2')) AS [timestamp],
                //  event.value('(event/action[@name="session_id"])[1]','int') AS session_id,
                //  event.value('(event/action[@name="database_id"])[1]','int') AS database_id,
                //  event.value('(event/data[@name="duration"])[1]','bigint') AS duration_microseconds,
                //  event.value('(event/data[@name="transaction_id"])[1]','bigint') AS transaction_id,
                //  event.value('(event/data[@name="transaction_state"]/text)[1]','nvarchar(max)') AS transaction_state,
                //  event.value('(event/data[@name="transaction_type"]/text)[1]','nvarchar(max)') AS transaction_type,
                //  event.value('(event/action[@name="sql_text"])[1]','nvarchar(max)') AS sql_text
                //FROM
                //(
                //  SELECT n.query('.') AS event
                //  FROM
                //  (
                //    SELECT CAST(target_data as XML) AS target_data
                //    FROM sys.dm_xe_sessions AS s
                //    JOIN sys.dm_xe_session_targets AS t
                //    ON s.address = t.event_session_address
                //    WHERE s.name = 'evstTrnFinishMySession'
                //    AND t.target_name = 'ring_buffer'
                //  ) AS s
                //CROSS APPLY target_data.nodes('RingBufferTarget/event') AS q(n)
                //) AS t;

                exEvents = new QueryableXEventData(DB.ConnData.GetConnectionString(), sessionName, EventStreamSourceOptions.EventStream, EventStreamCacheOptions.DoNotCache);
                lock( mapThreads )
                    mapThreads[Thread.CurrentThread] = exEvents;
                foreach (PublishedEvent exEvent in exEvents)
                {
//                    PublishedEventField field;
//                    if ( exEvent.Fields.TryGetValue("transaction_id", out field) && GM.DBValueToLong(field.Value) == trnID )
//                    if (GM.ConvertToLong(exEvent.Fields["transaction_id"].Value) == trnID)

                    { 
                        bool commited = false;

                        if ( exEvent.Fields["transaction_state"].Value.ToString() == "Commit" )
                            commited = true;

                        onTrnFinished(commited, trnID);
//                        exEvents.Dispose(); // misto toho break a exEvents.Dispose zavolam ve finally
                        break;
                    }
                }
            }
            catch(Exception ex) 
            {
                int i = 0;
            }
            finally
            {
                if ( !String.IsNullOrEmpty(sessionName) )
                    try
                    { 
                        using ( SqlConnection conn = DB.OpenConnection() )
                        using ( SqlCommand cmd = new SqlCommand("", conn) )
                        {
    //                        cmd.CommandText = string.Format("ALTER EVENT SESSION {0} ON SERVER DROP EVENT sqlserver.sql_transaction", sessionName);
    //                        cmd.ExecuteNonQuery();
                            //
                            cmd.CommandText = string.Format("DROP EVENT SESSION {0} ON SERVER", sessionName);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch {}

                try 
                { 
                    if ( exEvents != null )
                        exEvents.Dispose(); 
                    lock( mapThreads )
                        mapThreads.Remove(Thread.CurrentThread);
                } 
                catch {}
            }
        }
#endregion
*/

#region helper functions
        private void UpdateControls()
        {
            bool dbValid = DB.ConnData.IsValid();

            siSQLServer.Text = dbValid?DB.GetVersionInfo():" - -";

            miDBConnect.Enabled = tsbDBConnect.Enabled = !dbValid;
            miDBDisconnect.Enabled = tsbDBDisconnect.Enabled = dbValid;

            tsbScriptExecute.Enabled = dbValid;

            tsbTrnBegin.Enabled = (dbValid && sqlTrn == null);
            tsbTrnCommit.Enabled = tsbTrnRollback.Enabled = (dbValid && sqlTrn != null);

            cbSqlDepTable.Enabled = dbValid;
            chbSqlDepCaptureChange.Enabled = dbValid;

            if ( !dbValid )
            { 
                dgScriptResult.DataSource = null;
                cbSqlDepTable.Items.Clear();
                chbSqlDepCaptureChange.Checked = dbValid;
            }
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
		#endregion
	}
}
