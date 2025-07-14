using PLCcom;
using PLCcom.Core;
using PLCcom.Core.S7Plus;
using PLCcom.Core.S7Plus.AddressSpace;
using System.Text;

namespace BrowseAddressSpace
{
    public partial class MainForm : Form
    {
        #region private member 
        //create a device object for the modern tls access (TIA Version 17 or higher)
        Tls13Device? mySymbolicDevice = null;
        //or if you want to use the legacy access for older TIA or firmware versions
        //LegacySymbolicDevice? mySymbolicDevice = null;
        #endregion


        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {

            try
            {

                authentication.Serial = txtSerial.Text;
                authentication.User = txtUser.Text;

                if (mySymbolicDevice != null)
                {
                    mySymbolicDevice.DisConnect();
                }

                ConnectResult connectResult;
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    //connect
                    mySymbolicDevice = new Tls13Device(txtIpAddress.Text);
                    connectResult = mySymbolicDevice.Connect();

                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }

                //get connect result
                if (connectResult.Quality != OperationResult.eQuality.GOOD)
                {
                    //connect not successfull
                    MessageBox.Show($"Cannot connect to plc {txtIpAddress.Text}. Result {connectResult.Quality.ToString()} Message: {connectResult.Message}");
                    return;
                }

                //get complette addressspace from plc
                var globalAddressTree = mySymbolicDevice.GetAddressNodeTree();

                //create noed tree
                treePlcInventory.Nodes.Clear();

                foreach (var addressTreeNode in globalAddressTree)
                {
                    var rootNode = new TreeNode(addressTreeNode.NodeDetails.NodeName);
                    rootNode.Tag = addressTreeNode.NodeDetails;
                    AddChildNodes(rootNode, addressTreeNode);
                    treePlcInventory.Nodes.Add(rootNode);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddChildNodes(TreeNode parentTreeNode, AddressNode addressNode)
        {
            foreach (var childnode in addressNode.GetChildNodes())
            {
                var childTreeNode = new TreeNode(childnode.NodeDetails.NodeName);
                childTreeNode.Tag = childnode.NodeDetails;
                parentTreeNode.Nodes.Add(childTreeNode);
                AddChildNodes(childTreeNode, childnode);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (mySymbolicDevice != null)
                mySymbolicDevice.DisConnect();

            this.Close();
        }

        private void treePlcInventory_AfterSelect(object sender, TreeViewEventArgs e)
        {

            if (e.Node != null && e.Node.Tag is VariableDetails nodeDetails)
            {
                StringBuilder sb = new StringBuilder();

                sb.Append($"FullVariableName: {nodeDetails.FullVariableName} ");
                sb.Append(Environment.NewLine);
                sb.Append($"VariableDataType: {nodeDetails.VariableDataType.ToString()} ");
                sb.Append(Environment.NewLine);
                sb.Append($"IsReadable: {nodeDetails.IsReadable.ToString()} ");
                sb.Append(Environment.NewLine);
                sb.Append($"IsWritable: {nodeDetails.IsWritable.ToString()} ");
                sb.Append(Environment.NewLine);
                sb.Append($"IsArray: {nodeDetails.IsArray.ToString()} ");
                sb.Append(Environment.NewLine);
                sb.Append($"IsStruct: {nodeDetails.IsStruct.ToString()} ");
                sb.Append(Environment.NewLine);

                MessageBox.Show(sb.ToString());
            }

        }
    }
}
