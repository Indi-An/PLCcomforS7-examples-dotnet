using System;
using System.Drawing;
using System.Windows.Forms;
using PLCcom;
using System.Text;
using System.IO;
using PLCcom.Results.S7Plus;
using PLCcom.Requests.S7Plus;
using System.Globalization;
using PLCcom.Core.S7Plus.Alarm;
using System.Security.Claims;
using System.Linq;
using System.Threading;
using PLCcom.Enums.S7Plus;
using PLCCom_Full_Test_App.Symbolic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Collections.Generic;

namespace PLCCom_Full_Test_App.Symbolic
{
    /// <summary>
    /// WinForms form to display, subscribe, and acknowledge PLC alarms using the PLCcom library.
    /// </summary>
    public partial class AlarmFunctions : Form
    {
        /// <summary>
        /// Initializes a new instance of the AlarmFunctions form.
        /// </summary>
        /// <param name="Device">The SymbolicDevice to operate with.</param>
        public AlarmFunctions(SymbolicDevice Device)
        {
            InitializeComponent();
            this.device = Device;
        }

        #region Private Member
        // Reference to the symbolic device for alarm operations.
        SymbolicDevice device;
        // Resource manager for UI localization.
        System.Resources.ResourceManager resources;
        #endregion

        /// <summary>
        /// Handles form load. Initializes UI resources, labels, and subscribes to alarms.
        /// </summary>
        private void AlarmFunctions_Load(object sender, EventArgs e)
        {
            try
            {
                // Show device type in the UI
                lblDeviceType.Text = "DeviceType: " + device.GetType().ToString();

                // Load UI strings from resources for localization
                resources = new System.Resources.ResourceManager("PLCCom_Example_CSharp.Properties.Resources", this.GetType().Assembly);

                this.btnClose.Text = resources.GetString("btnClose_Text");
                this.btnAcknowledge.Text = resources.GetString("btnAcknowledge_Text");
                this.grbAlarms.Text = resources.GetString("grbAction_Text");
                this.grbInformations.Text = resources.GetString("grbInformations_Text");
                this.txtInfoAlarms.Text = resources.GetString("txtInfoAlarms_Text");
                this.colMessageType.Text = resources.GetString("colMessageType_Text");
                this.colTimestamp.Text = resources.GetString("colTimestamp_Text");
                this.colAlarmText.Text = resources.GetString("colAlarmText_Text");
                this.colInfoMessageType.Text = resources.GetString("colMessageType_Text");
                this.colInfoTimestamp.Text = resources.GetString("colTimestamp_Text");
                this.colInfoAlarmText.Text = resources.GetString("colAlarmText_Text");

                // Load current active alarms into the list view
                LoadAlarms();
                // Subscribe to alarm notification events from the device
                SubscribeAlarms();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        /// <summary>
        /// Loads currently active alarms from the device and adds them to the list view.
        /// </summary>
        private void LoadAlarms()
        {
            try
            {
                // Create request for browsing alarms, using current culture
                BrowseAlarmsRequest browseAlarmsRequest = new BrowseAlarmsRequest(CultureInfo.CurrentCulture);

                BrowseAlarmsResult result = device.BrowseActiveAlarms(browseAlarmsRequest);

                if (result.IsQualityGood())
                {
                    // Sort alarms by priority and add to the ListView
                    foreach (AlarmNotification alarm in result.getAlarms().OrderBy(a => a.AlarmPriority))
                    {
                        ListViewItem lvi = new ListViewItem(alarm.AlarmId.ToString());
                        lvi.Tag = alarm;

                        // Add message type as a subitem
                        lvi.SubItems.Add(alarm.MessageType.ToString());
                        // Add state as a subitem
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, alarm.AlarmState.ToString()));
                        // Add alarm number as a subitem
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, alarm.AlarmNumber.ToString()));
                        // Add timestamp as a subitem (converted to local time)
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, alarm.TimeStampComing.GetDateTime().ToLocalTime().ToString()));

                        CultureInfo textCultureInfo = null;

                        // Determine correct language for the alarm text
                        if (alarm.TextCultureInfos.ContainsKey(Thread.CurrentThread.CurrentUICulture.LCID))
                            textCultureInfo = Thread.CurrentThread.CurrentUICulture;
                        else
                            textCultureInfo = alarm.TextCultureInfos.FirstOrDefault().Value;

                        // Get alarm text in selected language
                        var text = alarm.AlarmTextEntries.Where(a => a.Culture.LCID == textCultureInfo.LCID);
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, text.Where(t => t.AlarmTextType == eAlarmTextType.AlarmText).First().Text));

                        // Add the fully populated ListViewItem to the alarms list view
                        lvAlarms.Items.Add(lvi);
                    }
                }
                else
                {
                    // Show error if alarms could not be loaded
                    MessageBox.Show(resources.GetString("error_browsing_alarms") + Environment.NewLine + result.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        /// <summary>
        /// Subscribes to device alarm notification events.
        /// </summary>
        private void SubscribeAlarms()
        {
            try
            {
                // Attach event handler for real-time alarm notifications
                device.AlarmNotification += Device_AlarmNotification;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        /// <summary>
        /// Event handler for receiving real-time alarm notifications from the device.
        /// Handles alarm list view updates and removal.
        /// </summary>
        private void Device_AlarmNotification(object sender, AlarmNotificationEventArgs e)
        {
            AlarmNotification alarmNotification = e.Alarm;
            if (alarmNotification != null)
            {
                switch (alarmNotification.MessageType)
                {
                    case eAlarmMessageType.AcknowledgeableAlarm:
                    case eAlarmMessageType.NonAcknowledgeableAlarm:
                        {
                            // Remove alarm from list if it is no longer active or has been canceled
                            if (alarmNotification.AlarmState == eAlarmState.NotActive ||
                                alarmNotification.AlarmState == eAlarmState.Canceled)
                            {
                                bool gotRemoved = lvAlarms.RemoveItemSafe(item => item.Text == alarmNotification.AlarmId.ToString());
                            }
                            else
                            {
                                // Find existing alarm item(s) to update in the list view
                                List<ListViewItem> foundItems = lvAlarms.FindItemsSafe(item => (string)item.Text == alarmNotification.AlarmId.ToString());

                                if (foundItems.Count > 0)
                                {
                                    // Update listview item for existing alarm
                                    foreach (ListViewItem lvi in foundItems)
                                    {
                                        bool success = lvAlarms.UpdateItemSafe(
                                            item => item.Text == alarmNotification.AlarmId.ToString(),
                                            old =>
                                            {
                                                var lvi = new ListViewItem(alarmNotification.AlarmId.ToString());
                                                lvi.Tag = alarmNotification;
                                                lvi.SubItems.Add(alarmNotification.MessageType.ToString());
                                                lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, alarmNotification.AlarmState.ToString()));
                                                lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, alarmNotification.AlarmNumber.ToString()));
                                                lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, alarmNotification.TimeStampComing?.GetDateTime().ToLocalTime().ToString() ?? String.Empty));

                                                CultureInfo textCultureInfo = null;
                                                if (alarmNotification.TextCultureInfos.ContainsKey(Thread.CurrentThread.CurrentUICulture.LCID))
                                                    textCultureInfo = Thread.CurrentThread.CurrentUICulture;
                                                else
                                                    textCultureInfo = alarmNotification.TextCultureInfos.FirstOrDefault().Value;

                                                var newAlarmtext = alarmNotification.AlarmTextEntries.Where(a => a.Culture.LCID == textCultureInfo.LCID);

                                                if (newAlarmtext.Any())
                                                    lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, newAlarmtext.Where(t => t.AlarmTextType == eAlarmTextType.AlarmText).First().Text));

                                                return lvi;
                                            }
                                        );
                                    }
                                }
                                else
                                {
                                    // No matching alarm item, add new alarm to the list view
                                    ListViewItem lvi = new ListViewItem(alarmNotification.AlarmId.ToString());
                                    lvi.Tag = alarmNotification;

                                    lvi.SubItems.Add(alarmNotification.MessageType.ToString());
                                    lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, alarmNotification.AlarmState.ToString()));
                                    lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, alarmNotification.AlarmNumber.ToString()));
                                    lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, alarmNotification.TimeStampComing.GetDateTime().ToLocalTime().ToString()));

                                    CultureInfo textCultureInfo = null;
                                    if (alarmNotification.TextCultureInfos.ContainsKey(Thread.CurrentThread.CurrentUICulture.LCID))
                                        textCultureInfo = Thread.CurrentThread.CurrentUICulture;
                                    else
                                        textCultureInfo = alarmNotification.TextCultureInfos.FirstOrDefault().Value;

                                    var text = alarmNotification.AlarmTextEntries.Where(a => a.Culture.LCID == textCultureInfo.LCID);
                                    lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, text.Where(t => t.AlarmTextType == eAlarmTextType.AlarmText).First().Text));

                                    lvAlarms.AddItemSafe(lvi);
                                }
                            }
                        }
                        break;
                    case eAlarmMessageType.InformationNotification:
                        {
                            // Add information notification to the informations list view
                            ListViewItem lvi = new ListViewItem(alarmNotification.AlarmId.ToString());
                            lvi.Tag = alarmNotification;

                            lvi.SubItems.Add(alarmNotification.MessageType.ToString());
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, alarmNotification.TimeStampComing.GetDateTime().ToLocalTime().ToString()));

                            CultureInfo textCultureInfo = null;
                            if (alarmNotification.TextCultureInfos.ContainsKey(Thread.CurrentThread.CurrentUICulture.LCID))
                                textCultureInfo = Thread.CurrentThread.CurrentUICulture;
                            else
                                textCultureInfo = alarmNotification.TextCultureInfos.FirstOrDefault().Value;

                            var text = alarmNotification.AlarmTextEntries.Where(a => a.Culture.LCID == textCultureInfo.LCID);
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, text.Where(t => t.AlarmTextType == eAlarmTextType.AlarmText).First().Text));

                            lvInformations.AddItemSafe(lvi);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Handles Close button click event. Unsubscribes alarm event handler and closes the form.
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            device.AlarmNotification -= Device_AlarmNotification;
            this.Close();
        }

        /// <summary>
        /// Handles the FormClosing event by decrementing the open dialog counter in the main form.
        /// </summary>
        private void AlarmFunctions_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main.CountOpenDialogs--;
        }

        /// <summary>
        /// Handles double-click events on the alarms list view. Opens details for the clicked alarm.
        /// </summary>
        private void lvAlarms_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                // Get the item under the mouse pointer
                var hit = lvAlarms.HitTest(e.Location);
                if (hit.Item != null)
                {
                    AlarmNotification alarm = (AlarmNotification)hit.Item.Tag;
                    AlarmDetails alarmDetails = new AlarmDetails(alarm, this.resources);
                    alarmDetails.Show(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        /// <summary>
        /// Handles double-click events on the informations list view. Opens details for the clicked information notification.
        /// </summary>
        private void lvInformations_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                // Get the item under the mouse pointer
                var hit = lvInformations.HitTest(e.Location);
                if (hit.Item != null)
                {
                    AlarmNotification alarm = (AlarmNotification)hit.Item.Tag;
                    AlarmDetails alarmDetails = new AlarmDetails(alarm, this.resources);
                    alarmDetails.Show(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        /// <summary>
        /// Handles the Acknowledge button click event. Acknowledges all selected alarms.
        /// </summary>
        private void btnAcknowledge_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvAlarms.SelectedItems.Count > 0)
                {
                    var items = lvAlarms.SelectedItems;
                    if (items.Count > 0)
                    {
                        foreach (ListViewItem item in items)
                        {
                            AlarmNotification alarm = (AlarmNotification)item.Tag;
                            OperationResult res = device.AckAlarm(alarm.AlarmId);

                            if (res.IsQualityBad())
                            {
                                MessageBox.Show($"Operation not successful Quality: {res.Quality} Message: {res.Message}", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        /// <summary>
        /// Handles selection changes in the alarms list view.
        /// Enables or disables the acknowledge button depending on selection.
        /// </summary>
        private void lvAlarms_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.ListView listView = (System.Windows.Forms.ListView)sender;
                var selectedItems = listView.SelectedItems;

                // Enable the acknowledge button only if any selected alarm is acknowledgeable
                if (selectedItems.Cast<ListViewItem>().Select(l => (l.Tag as AlarmNotification)).Where(l => l.MessageType == eAlarmMessageType.AcknowledgeableAlarm).Any())
                    btnAcknowledge.Enabled = true;
                else
                    btnAcknowledge.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
    }
}
