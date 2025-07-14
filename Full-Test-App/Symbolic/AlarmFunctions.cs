﻿using System;
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
    public partial class AlarmFunctions : Form
    {

        public AlarmFunctions(SymbolicDevice Device)
        {
            InitializeComponent();
            this.device = Device;
        }

        #region Private Member
        SymbolicDevice device;
        System.Resources.ResourceManager resources;
        #endregion


        private void AlarmFunctions_Load(object sender, EventArgs e)
        {
            try
            {
                lblDeviceType.Text = "DeviceType: " + device.GetType().ToString();

                resources = new System.Resources.ResourceManager("PLCCom_Full_Test_App.Properties.Resources", this.GetType().Assembly);

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

                LoadAlarms();
                SubscribeAlarms();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void LoadAlarms()
        {
            try
            {


                BrowseAlarmsRequest browseAlarmsRequest = new BrowseAlarmsRequest(CultureInfo.CurrentCulture);

                BrowseAlarmsResult result = device.BrowseActiveAlarms(browseAlarmsRequest);

                if (result.IsQualityGood())
                {

                    foreach (AlarmNotification alarm in result.getAlarms().OrderBy(a => a.AlarmPriority))
                    {

                        ListViewItem lvi = new ListViewItem(alarm.AlarmId.ToString());
                        lvi.Tag = alarm;

                        //MessageType
                        lvi.SubItems.Add(alarm.MessageType.ToString());

                        //State
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, alarm.AlarmState.ToString()));

                        //AlarmId
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, alarm.AlarmNumber.ToString()));

                        //Coming Timestamp
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, alarm.TimeStampComing.GetDateTime().ToLocalTime().ToString()));

                        CultureInfo textCultureInfo = null;

                        //get the alarm text with the right language
                        if (alarm.TextCultureInfos.ContainsKey(Thread.CurrentThread.CurrentUICulture.LCID))
                            textCultureInfo = Thread.CurrentThread.CurrentUICulture;
                        else
                            textCultureInfo = alarm.TextCultureInfos.FirstOrDefault().Value;

                        //Alarmtext
                        var text = alarm.AlarmTextEntries.Where(a => a.Culture.LCID == textCultureInfo.LCID);
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, text.Where(t => t.AlarmTextType == eAlarmTextType.AlarmText).First().Text));


                        lvAlarms.Items.Add(lvi);
                    }
                }
                else
                {
                    MessageBox.Show(resources.GetString("error_browsing_alarms") + Environment.NewLine + result.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void SubscribeAlarms()
        {
            try
            {
                device.AlarmNotification += Device_AlarmNotification;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

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
                            if (alarmNotification.AlarmState == eAlarmState.NotActive ||
                                alarmNotification.AlarmState == eAlarmState.Canceled)
                            {
                                //remove the alarm from the list
                                bool gotRemoved = lvAlarms.RemoveItemSafe(item => item.Text == alarmNotification.AlarmId.ToString());
                            }
                            else
                            {

                                // is there an Item to update?
                                List<ListViewItem> foundItems = lvAlarms.FindItemsSafe(item => (string)item.Text == alarmNotification.AlarmId.ToString());

                                if (foundItems.Count > 0)
                                {
                                    //Update listview item
                                    foreach (ListViewItem lvi in foundItems)
                                    {

                                        bool success = lvAlarms.UpdateItemSafe(
                                            item => item.Text == alarmNotification.AlarmId.ToString(),
                                            old =>
                                            {
                                                var lvi = new ListViewItem(alarmNotification.AlarmId.ToString());
                                                lvi.Tag = alarmNotification;
                                                //MessageType
                                                lvi.SubItems.Add(alarmNotification.MessageType.ToString());

                                                //State
                                                lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, alarmNotification.AlarmState.ToString()));

                                                //AlarmId
                                                lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, alarmNotification.AlarmNumber.ToString()));

                                                //Coming Timestamp
                                                lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, alarmNotification.TimeStampComing?.GetDateTime().ToLocalTime().ToString() ?? String.Empty));

                                                CultureInfo textCultureInfo = null;

                                                //get the alarm text with the right language
                                                if (alarmNotification.TextCultureInfos.ContainsKey(Thread.CurrentThread.CurrentUICulture.LCID))
                                                    textCultureInfo = Thread.CurrentThread.CurrentUICulture;
                                                else
                                                    textCultureInfo = alarmNotification.TextCultureInfos.FirstOrDefault().Value;

                                                //Alarmtext
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

                                    ListViewItem lvi = new ListViewItem(alarmNotification.AlarmId.ToString());
                                    lvi.Tag = alarmNotification;

                                    //MessageType
                                    lvi.SubItems.Add(alarmNotification.MessageType.ToString());

                                    //State
                                    lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, alarmNotification.AlarmState.ToString()));

                                    //AlarmId
                                    lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, alarmNotification.AlarmNumber.ToString()));

                                    //Coming Timestamp
                                    lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, alarmNotification.TimeStampComing.GetDateTime().ToLocalTime().ToString()));

                                    CultureInfo textCultureInfo = null;

                                    //get the alarm text with the right language
                                    if (alarmNotification.TextCultureInfos.ContainsKey(Thread.CurrentThread.CurrentUICulture.LCID))
                                        textCultureInfo = Thread.CurrentThread.CurrentUICulture;
                                    else
                                        textCultureInfo = alarmNotification.TextCultureInfos.FirstOrDefault().Value;

                                    //Alarmtext
                                    var text = alarmNotification.AlarmTextEntries.Where(a => a.Culture.LCID == textCultureInfo.LCID);
                                    lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, text.Where(t => t.AlarmTextType == eAlarmTextType.AlarmText).First().Text));


                                    lvAlarms.AddItemSafe(lvi);
                                }
                            }
                        }
                        break;
                    case eAlarmMessageType.InformationNotification:
                        {
                            ListViewItem lvi = new ListViewItem(alarmNotification.AlarmId.ToString());
                            lvi.Tag = alarmNotification;

                            //MessageType
                            lvi.SubItems.Add(alarmNotification.MessageType.ToString());

                            //Coming Timestamp
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, alarmNotification.TimeStampComing.GetDateTime().ToLocalTime().ToString()));

                            CultureInfo textCultureInfo = null;

                            //get the alarm text with the right language
                            if (alarmNotification.TextCultureInfos.ContainsKey(Thread.CurrentThread.CurrentUICulture.LCID))
                                textCultureInfo = Thread.CurrentThread.CurrentUICulture;
                            else
                                textCultureInfo = alarmNotification.TextCultureInfos.FirstOrDefault().Value;

                            //Alarmtext
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



        private void btnClose_Click(object sender, EventArgs e)
        {
            device.AlarmNotification -= Device_AlarmNotification;
            this.Close();
        }



        private void AlarmFunctions_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main.CountOpenDialogs--;
        }

        private void lvAlarms_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                // Determines the ListViewItem under the click point
                var hit = lvAlarms.HitTest(e.Location);
                if (hit.Item != null)
                {
                    // Here you have the clicked item, even if it was already selected
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


        private void lvInformations_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                // Determines the ListViewItem under the click point
                var hit = lvInformations.HitTest(e.Location);
                if (hit.Item != null)
                {
                    // Here you have the clicked item, even if it was already selected
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
                            // Here you have the clicked item, even if it was already selected
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

        private void lvAlarms_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                System.Windows.Forms.ListView listView = (System.Windows.Forms.ListView)sender;
                var selectedItems = listView.SelectedItems;

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
