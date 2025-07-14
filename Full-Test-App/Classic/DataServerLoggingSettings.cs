using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;
using PLCcom;
using PLCcom.PLCComDataServer;

namespace PLCCom_Full_Test_App.Classic
{
    public partial class DataServerLoggingSettings : Form
    {

        public DataServerLoggingSettings()
        {
            InitializeComponent();
        }

        #region private member

        private System.Resources.ResourceManager resources = null;
        PLCComDataServer myDataServer;
        #endregion

        private enum eTypeOfConnector
        {
            Filesystem_Connector,
            MSSQL_DB_Connector
        }

        internal PLCComDataServer ShowSettings(PLCComDataServer DataServer)
        {
            try
            {
                myDataServer = DataServer;
                this.ShowDialog();
            }
            catch (Exception)
            {

            }
            return myDataServer;
        }

        private void DataServerLoggingSettings_Load(object sender, EventArgs e)
        {
            //init controls
            resources = new System.Resources.ResourceManager("PLCCom_Full_Test_App.Properties.Resources", this.GetType().Assembly);

            cmbConnectorType.DataSource = Enum.GetValues(typeof(eTypeOfConnector));
            cmbImageOutputFormat.DataSource = Enum.GetValues(typeof(PLCcom.ExternalLogging.eImageOutputFormat));

            this.txtFolderName.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PLCcom", "ForS7");

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
            this.txtInfoDocu.Text  = resources.GetString("txtInfoDocu_Text_file");

            // search unused Connector name
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

            //fill connector listview
            fillConnectorListView();

            btnAddConnector.Focus();
        }

        private void cmbConnectorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch ((eTypeOfConnector)cmbConnectorType.SelectedItem)
                {
                    case eTypeOfConnector.Filesystem_Connector:
                        grbDatabaseConnectorSettings.Visible = false;
                        grbFilesystemConnectorSettings.Visible = true;
                        txtInfoDocu.Text  = resources.GetString("txtInfoDocu_Text_file");
                        break;
                    case eTypeOfConnector.MSSQL_DB_Connector:
                        grbDatabaseConnectorSettings.Visible = true;
                        grbFilesystemConnectorSettings.Visible = false;
                        txtInfoDocu.Text = resources.GetString("txtInfoDocu_Text_DB");
                        break;
                }
                // search unused Connector name
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

        private void btnFolderName_Click(object sender, EventArgs e)
        {
            try
            {

                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PLCcom", "ForS7");

                // Check if the directory exists, if not, create it
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

        private void chkIsWriteLogActive_CheckedChanged(object sender, EventArgs e)
        {
            txtMaxAgeHours.Enabled = chkIsWriteLogActive.Checked;
            txtMaxFileSizeMB.Enabled = chkIsWriteLogActive.Checked;
            txtMaxNumberOfLogFiles.Enabled = chkIsWriteLogActive.Checked;
        }

        private void chkIsWriteImageActive_CheckedChanged(object sender, EventArgs e)
        {
            cmbImageOutputFormat.Enabled = chkIsWriteImageActive.Checked;
        }

        private void btnAddConnector_Click(object sender, EventArgs e)
        {
            try
            {
                btnAddConnector.Enabled = false;
                // search unused Connector name
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                // search unused Connector name
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

                        //parse inputs before execute
                        MaxNumberOfLogFiles = int.Parse(txtMaxNumberOfLogFiles.Text);
                        MaxAgeHours = int.Parse(txtMaxAgeHours.Text);
                        MaxFileSizeMB = int.Parse(txtMaxFileSizeMB.Text);

                        //create new FileSystemConnector instance
                        con = new PLCcom.ExternalLogging.FileSystemConnector(txtFolderName.Text,                //Target folder
                                                                            txtConnectorName.Text,              //unique connector name
                                                                            ';',                                //text separator recommendation ';'
                                                                            chkIsWriteLogActive.Checked,        //activate progressive logging
                                                                            chkIsWriteImageActive.Checked,      //activate immage writing
                                                                            (PLCcom.ExternalLogging.eImageOutputFormat)
                                                                            cmbImageOutputFormat.SelectedItem,  //output format .dat or .xml
                                                                            MaxNumberOfLogFiles,                //restrict the maximum number of files. When the value is exceeded the old files are automatically deleted. -1 = Disabled.
                                                                            MaxAgeHours,                        //restrict the maximum age of files. When the value is exceeded the old files are automatically deleted. -1 = Disabled.
                                                                            MaxFileSizeMB,                      //You can restrict the maximum size of files. When the value is exceeded the old files are automatically deleted. -1 = Disabled.
                                                                            txtEncryptionPassword.Text);        //If you enter an encryption password, the data is stored in encrypted form. You can read the data using the supplied decryption tool again.


                        break;
                    case eTypeOfConnector.MSSQL_DB_Connector:

                        if (string.IsNullOrEmpty(txtSQLConnectionString.Text)) throw new Exception("Connectionstring is null or empty");

                        //Create two valid MS SQL Connections and refer it to new database connector
                        System.Data.SqlClient.SqlConnection SQLConLogArchive = new System.Data.SqlClient.SqlConnection(txtSQLConnectionString.Text);
                        System.Data.SqlClient.SqlConnection SQLConImageArchive = new System.Data.SqlClient.SqlConnection(txtSQLConnectionString.Text);
                        con = new PLCcom.ExternalLogging.DataBaseConnector(SQLConLogArchive,                      //A valid database connection for writing 'Log-Archive' based of a DbConnection object. If the value is null, the flag 'isWriteLogActive' will be disabled
                                                                           SQLConImageArchive,                    //A valid database connection for writing 'Image-Archive' based of a DbConnection object. If the value is null, the flag 'isWriteImageActive' will be disabled
                                                                           txtConnectorNameDB.Text,               //unique connector name
                                                                           chkIsWriteLogActiveDB.Checked,         //activate progressive logging
                                                                           chkIsWriteImageActiveDB.Checked);      //activate immage writing
                        break;
                }

                //Add Connector to PLCcom data server
                myDataServer.AddOrReplaceLoggingConnector(con);

                // search unused Connector name
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

        private void fillConnectorListView()
        {
            //clear ListView initial
            lvConnectors.Items.Clear();

            //fill ListView with current ReadRequests
            foreach (PLCcom.ExternalLogging.LoggingConnector lc in myDataServer.GetLoggingConnectors())
            {
                ListViewItem lvi = new ListViewItem(lc.GetConnectorName());
                lvi.SubItems.Add(lc.ToString());
                lvConnectors.Items.Add(lvi);
            }
        }

        private void btnRemoveConnector_Click(object sender, EventArgs e)
        {
            //remove request from request collection
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

                // search unused Connector name
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

        private void lvConnectors_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemoveConnector.Enabled = lvConnectors.SelectedItems != null && lvConnectors.SelectedItems.Count > 0;
        }

    }
}
