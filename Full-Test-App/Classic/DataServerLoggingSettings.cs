using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;
using PLCcom;
using PLCcom.PLCComDataServer;

namespace PLCCom_Full_Test_App.Classic
{
    /// <summary>
    /// Form for configuring logging connectors for the PLCcom DataServer.
    /// Supports filesystem and MSSQL database connectors.
    /// </summary>
    public partial class DataServerLoggingSettings : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataServerLoggingSettings"/> class.
        /// </summary>
        public DataServerLoggingSettings()
        {
            InitializeComponent();
        }

        #region private member

        /// <summary>
        /// Resource manager for UI string localization.
        /// </summary>
        private System.Resources.ResourceManager resources = null;

        /// <summary>
        /// Reference to the PLCComDataServer instance for connector management.
        /// </summary>
        PLCComDataServer myDataServer;
        #endregion

        /// <summary>
        /// Enum for possible connector types.
        /// </summary>
        private enum eTypeOfConnector
        {
            Filesystem_Connector,
            MSSQL_DB_Connector
        }

        /// <summary>
        /// Shows the settings dialog and returns the possibly modified DataServer instance.
        /// </summary>
        /// <param name="DataServer">The DataServer instance to configure.</param>
        /// <returns>The modified DataServer instance.</returns>
        internal PLCComDataServer ShowSettings(PLCComDataServer DataServer)
        {
            try
            {
                myDataServer = DataServer;
                this.ShowDialog();
            }
            catch (Exception)
            {
                // Suppress any exceptions during showing the dialog
            }
            return myDataServer;
        }

        /// <summary>
        /// Initializes all controls, populates combos, and fills connector list on load.
        /// </summary>
        private void DataServerLoggingSettings_Load(object sender, EventArgs e)
        {
            // Init controls and load UI text from resources
            resources = new System.Resources.ResourceManager("PLCCom_Example_CSharp.Properties.Resources", this.GetType().Assembly);

            cmbConnectorType.DataSource = Enum.GetValues(typeof(eTypeOfConnector));
            cmbImageOutputFormat.DataSource = Enum.GetValues(typeof(PLCcom.ExternalLogging.eImageOutputFormat));

            this.txtFolderName.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PLCcom", "ForS7");

            // Set localized UI texts
            this.btnClose.Text = resources.GetString("btnClose_Text");
            this.btnAccept.Text = resources.GetString("btnAccept_Text");
            this.btnReject.Text = resources.GetString("btnReject_Text");
            this.lblInfoIsWriteLogActiveDB.Text = resources.GetString("lblInfoIsWriteLogActiveDB_Text");
            this.lblIsWriteImageActiveDB.Text = resources.GetString("lblIsWriteImageActiveDB_Text");
            this.lblInfoIsWriteLogActive.Text = resources.GetString("lblInfoIsWriteLogActive_Text");
            this.lblInfoIsWriteImageActive.Text = resources.GetString("lblInfoIsWriteImageActive_Text");
            this.lblInfoEncryptionPassword.Text = resources.GetString("lblInfoEncryptionPassword_Text");
            this.lblInfoMaxNumberOfLogFiles.Text = resources.GetString("lblInfoMaxNumberOfLogFiles_Text");
            this.lblInfoMaxAgeHours.Text = resources.GetString("lblInfoMaxAgeHours_Text");
            this.lblInfoMaxFileSizeMB.Text = resources.GetString("lblInfoMaxFileSizeMB_Text");
            this.lblInfoImageOutputFormat.Text = resources.GetString("lblInfoImageOutputFormat_Text");
            this.lblConnectorName.Text = resources.GetString("lblConnectorName_Text");
            this.lblConnectorNameDB.Text = resources.GetString("lblConnectorName_Text");
            this.lblConnectorType.Text = resources.GetString("lblConnectorType_Text");
            this.lblConnectionString.Text = resources.GetString("lblConnectionString_Text");
            this.lblInfoConnectionString.Text = resources.GetString("lblInfoConnectionString_Text");
            this.lblInfoConnectorName.Text = resources.GetString("lblInfoConnectorName_Text");
            this.lblInfoConnectorNameDB.Text = resources.GetString("lblInfoConnectorName_Text");
            this.txtInfoCreateListener.Text = resources.GetString("lblInfoCreateListener_Text");
            this.grbFilesystemConnectorSettings.Text = resources.GetString("grbFilesystemConnectorSettings_Text");
            this.grbDatabaseConnectorSettings.Text = resources.GetString("grbDatabaseConnectorSettings_Text");
            this.lblFolderName.Text = resources.GetString("lblFolderName_Text");
            this.chkIsWriteLogActiveDB.Text = resources.GetString("chkIsWriteLogActive_Text");
            this.chkIsWriteImageActiveDB.Text = resources.GetString("chkIsWriteImageActive_Text");
            this.chkIsWriteLogActive.Text = resources.GetString("chkIsWriteLogActive_Text");
            this.chkIsWriteImageActive.Text = resources.GetString("chkIsWriteImageActive_Text");
            this.lblEncryptionPassword.Text = resources.GetString("lblEncryptionPassword_Text");
            this.lblMaxNumberOfLogFiles.Text = resources.GetString("lblMaxNumberOfLogFiles_Text");
            this.lblMaxAgeHours.Text = resources.GetString("lblMaxAgeHours_Text");
            this.lblMaxFileSizeMB.Text = resources.GetString("lblMaxFileSizeMB_Text");
            this.lblImageOutputFormat.Text = resources.GetString("lblImageOutputFormat_Text");
            this.lblConnectionMessage.Text = resources.GetString("lblConnectionMessage_Text");
            this.btnAddConnector.Text = resources.GetString("btnAddConnector_Text");
            this.btnRemoveConnector.Text = resources.GetString("btnRemoveConnector_Text");
            this.txtInfoDocu.Text = resources.GetString("txtInfoDocu_Text_file");

            // Search for an unused connector name
            int counter = 1;
            String RequestName = (((eTypeOfConnector)cmbConnectorType.SelectedItem).Equals(eTypeOfConnector.Filesystem_Connector) ? "Filesystem" : "Database") + "Connector_";
            do
            {
                if (myDataServer.GetLoggingConnectorPerName(RequestName + counter.ToString("000")) == null)
                {
                    txtConnectorName.Text = RequestName + counter.ToString("000");
                    break;
                }
                else
                {
                    counter++;
                }
            } while (true);

            txtConnectorNameDB.Text = txtConnectorName.Text;

            // Fill connector listview with all connectors
            fillConnectorListView();

            btnAddConnector.Focus();
        }

        /// <summary>
        /// Handles change of connector type (filesystem/MSSQL). Updates UI and default names.
        /// </summary>
        private void cmbConnectorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch ((eTypeOfConnector)cmbConnectorType.SelectedItem)
                {
                    case eTypeOfConnector.Filesystem_Connector:
                        grbDatabaseConnectorSettings.Visible = false;
                        grbFilesystemConnectorSettings.Visible = true;
                        txtInfoDocu.Text = resources.GetString("txtInfoDocu_Text_file");
                        break;
                    case eTypeOfConnector.MSSQL_DB_Connector:
                        grbDatabaseConnectorSettings.Visible = true;
                        grbFilesystemConnectorSettings.Visible = false;
                        txtInfoDocu.Text = resources.GetString("txtInfoDocu_Text_DB");
                        break;
                }
                // Search unused connector name again when switching type
                int counter = 1;
                String RequestName = (((eTypeOfConnector)cmbConnectorType.SelectedItem).Equals(eTypeOfConnector.Filesystem_Connector) ? "Filesystem" : "Database") + "Connector_";
                do
                {
                    if (myDataServer.GetLoggingConnectorPerName(RequestName + counter.ToString("000")) == null)
                    {
                        txtConnectorName.Text = RequestName + counter.ToString("000");
                        break;
                    }
                    else
                    {
                        counter++;
                    }
                } while (true);

                txtConnectorNameDB.Text = txtConnectorName.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Opens a folder browser dialog to select the target log folder.
        /// </summary>
        private void btnFolderName_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PLCcom", "ForS7");

                // Ensure the default folder exists
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                FolderBrowserDialog myFolderBrowserDialog = new FolderBrowserDialog();
                myFolderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
                myFolderBrowserDialog.SelectedPath = path;
                myFolderBrowserDialog.Description = "Select Folder";

                if (myFolderBrowserDialog.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(myFolderBrowserDialog.SelectedPath))
                {
                    txtFolderName.Text = myFolderBrowserDialog.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Enables or disables log file settings when the log writing checkbox changes.
        /// </summary>
        private void chkIsWriteLogActive_CheckedChanged(object sender, EventArgs e)
        {
            txtMaxAgeHours.Enabled = chkIsWriteLogActive.Checked;
            txtMaxFileSizeMB.Enabled = chkIsWriteLogActive.Checked;
            txtMaxNumberOfLogFiles.Enabled = chkIsWriteLogActive.Checked;
        }

        /// <summary>
        /// Enables or disables image format selection when the image writing checkbox changes.
        /// </summary>
        private void chkIsWriteImageActive_CheckedChanged(object sender, EventArgs e)
        {
            cmbImageOutputFormat.Enabled = chkIsWriteImageActive.Checked;
        }

        /// <summary>
        /// Handles Add Connector button. Initializes form for entering a new connector.
        /// </summary>
        private void btnAddConnector_Click(object sender, EventArgs e)
        {
            try
            {
                btnAddConnector.Enabled = false;
                // Search for unused connector name
                int counter = 1;
                String RequestName = (((eTypeOfConnector)cmbConnectorType.SelectedItem).Equals(eTypeOfConnector.Filesystem_Connector) ? "Filesystem" : "Database") + "Connector_";
                do
                {
                    if (myDataServer.GetLoggingConnectorPerName(RequestName + counter.ToString("000")) == null)
                    {
                        txtConnectorName.Text = RequestName + counter.ToString("000");
                        break;
                    }
                    else
                    {
                        counter++;
                    }
                } while (true);

                txtConnectorNameDB.Text = txtConnectorName.Text;
                grbNewConnector.Enabled = true;
                btnRemoveConnector.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Closes the settings dialog.
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Cancels the addition or editing of a connector and resets form state.
        /// </summary>
        private void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                // Search for unused connector name again
                int counter = 1;
                String RequestName = (((eTypeOfConnector)cmbConnectorType.SelectedItem).Equals(eTypeOfConnector.Filesystem_Connector) ? "Filesystem" : "Database") + "Connector_";
                do
                {
                    if (myDataServer.GetLoggingConnectorPerName(RequestName + counter.ToString("000")) == null)
                    {
                        txtConnectorName.Text = RequestName + counter.ToString("000");
                        break;
                    }
                    else
                    {
                        counter++;
                    }
                } while (true);

                txtConnectorNameDB.Text = txtConnectorName.Text;
                grbNewConnector.Enabled = false;
                btnRemoveConnector.Enabled = lvConnectors.SelectedItems != null && lvConnectors.SelectedItems.Count > 0;
                btnAddConnector.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Accepts and saves the new or edited connector to the DataServer.
        /// </summary>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                PLCcom.ExternalLogging.LoggingConnector con = null;
                switch ((eTypeOfConnector)cmbConnectorType.SelectedItem)
                {
                    case eTypeOfConnector.Filesystem_Connector:
                        int MaxNumberOfLogFiles;
                        int MaxAgeHours;
                        int MaxFileSizeMB;

                        // Parse numeric inputs before creating connector
                        MaxNumberOfLogFiles = int.Parse(txtMaxNumberOfLogFiles.Text);
                        MaxAgeHours = int.Parse(txtMaxAgeHours.Text);
                        MaxFileSizeMB = int.Parse(txtMaxFileSizeMB.Text);

                        // Create new FileSystemConnector instance
                        con = new PLCcom.ExternalLogging.FileSystemConnector(
                            txtFolderName.Text,                              // Target folder
                            txtConnectorName.Text,                          // Unique connector name
                            ';',                                            // Field separator
                            chkIsWriteLogActive.Checked,                    // Enable progressive logging
                            chkIsWriteImageActive.Checked,                  // Enable image writing
                            (PLCcom.ExternalLogging.eImageOutputFormat)
                                cmbImageOutputFormat.SelectedItem,          // Output format (.dat or .xml)
                            MaxNumberOfLogFiles,                            // Max files, -1 disables limit
                            MaxAgeHours,                                    // Max file age, -1 disables limit
                            MaxFileSizeMB,                                  // Max file size, -1 disables limit
                            txtEncryptionPassword.Text                      // Optional encryption password
                        );
                        break;
                    case eTypeOfConnector.MSSQL_DB_Connector:

                        if (string.IsNullOrEmpty(txtSQLConnectionString.Text)) throw new Exception("Connectionstring is null or empty");

                        // Create MS SQL database connections for log and image archive
                        System.Data.SqlClient.SqlConnection SQLConLogArchive = new System.Data.SqlClient.SqlConnection(txtSQLConnectionString.Text);
                        System.Data.SqlClient.SqlConnection SQLConImageArchive = new System.Data.SqlClient.SqlConnection(txtSQLConnectionString.Text);
                        con = new PLCcom.ExternalLogging.DataBaseConnector(
                            SQLConLogArchive,                              // Connection for log archive
                            SQLConImageArchive,                            // Connection for image archive
                            txtConnectorNameDB.Text,                       // Unique connector name
                            chkIsWriteLogActiveDB.Checked,                 // Enable logging
                            chkIsWriteImageActiveDB.Checked                // Enable image writing
                        );
                        break;
                }

                // Add or replace connector in the DataServer
                myDataServer.AddOrReplaceLoggingConnector(con);

                // Search unused connector name after add
                int counter = 1;
                String RequestName = (((eTypeOfConnector)cmbConnectorType.SelectedItem).Equals(eTypeOfConnector.Filesystem_Connector) ? "Filesystem" : "Database") + "Connector_";
                do
                {
                    if (myDataServer.GetLoggingConnectorPerName(RequestName + counter.ToString("000")) == null)
                    {
                        txtConnectorName.Text = RequestName + counter.ToString("000");
                        break;
                    }
                    else
                    {
                        counter++;
                    }
                } while (true);

                txtConnectorNameDB.Text = txtConnectorName.Text;
                grbNewConnector.Enabled = false;
                btnRemoveConnector.Enabled = lvConnectors.SelectedItems != null && lvConnectors.SelectedItems.Count > 0;
                btnAddConnector.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fillConnectorListView();
            }
        }

        /// <summary>
        /// Populates the connectors ListView with all connectors from the DataServer.
        /// </summary>
        private void fillConnectorListView()
        {
            // Clear ListView before repopulating
            lvConnectors.Items.Clear();

            // Add all current logging connectors to the ListView
            foreach (PLCcom.ExternalLogging.LoggingConnector lc in myDataServer.GetLoggingConnectors())
            {
                ListViewItem lvi = new ListViewItem(lc.GetConnectorName());
                lvi.SubItems.Add(lc.ToString());
                lvConnectors.Items.Add(lvi);
            }
        }

        /// <summary>
        /// Removes the selected connector from the DataServer and refreshes the ListView.
        /// </summary>
        private void btnRemoveConnector_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvConnectors.SelectedItems.Count != 0)
                {
                    myDataServer.RemoveLoggingConnector(lvConnectors.SelectedItems[0].Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                fillConnectorListView();

                // Search unused connector name after remove
                int counter = 1;
                String RequestName = (((eTypeOfConnector)cmbConnectorType.SelectedItem).Equals(eTypeOfConnector.Filesystem_Connector) ? "Filesystem" : "Database") + "Connector_";
                do
                {
                    if (myDataServer.GetLoggingConnectorPerName(RequestName + counter.ToString("000")) == null)
                    {
                        txtConnectorName.Text = RequestName + counter.ToString("000");
                        break;
                    }
                    else
                    {
                        counter++;
                    }
                } while (true);
            }
        }

        /// <summary>
        /// Enables or disables the Remove Connector button depending on selection.
        /// </summary>
        private void lvConnectors_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemoveConnector.Enabled = lvConnectors.SelectedItems != null && lvConnectors.SelectedItems.Count > 0;
        }
    }
}
