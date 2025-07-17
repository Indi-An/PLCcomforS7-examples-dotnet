using PLCcom.Core.S7Plus.Alarm;
using PLCcom.Enums.S7Plus;
using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Threading;
using System.Windows.Forms;

namespace PLCCom_Full_Test_App.Symbolic
{
    /// <summary>
    /// A WinForms dialog to display detailed information about a specific PLC alarm.
    /// </summary>
    public partial class AlarmDetails : Form
    {
        /// <summary>
        /// Initializes the AlarmDetails form with all fields from the given AlarmNotification.
        /// </summary>
        /// <param name="alarm">The alarm notification containing all alarm details.</param>
        /// <param name="resources">Resource manager for localized UI texts.</param>
        public AlarmDetails(AlarmNotification alarm, ResourceManager resources)
        {
            try
            {
                InitializeComponent();

                // Set localized button and label texts using resources
                this.btnClose.Text = resources.GetString("btnClose_Text");
                this.lblProducer.Text = resources.GetString("lblProducer_Text");
                this.lblMessageType.Text = resources.GetString("lblMessageType_Text");
                this.lblState.Text = resources.GetString("lblState_Text");
                this.lblAlarmClassId.Text = resources.GetString("lblAlarmClassId_Text");
                this.lblAlarmId.Text = resources.GetString("lblAlarmId_Text");
                this.lblAlarmNo.Text = resources.GetString("lblAlarmNo_Text");
                this.lblTSComing.Text = resources.GetString("lblTSComing_Text");
                this.lblTsGoing.Text = resources.GetString("lblTsGoing_Text");
                this.lblTSAck.Text = resources.GetString("lblTSAck_Text");
                this.lblInfoText.Text = resources.GetString("lblInfoText_Text");
                this.lblAlarmText.Text = resources.GetString("lblAlarmText_Text");
                this.lblAdditionalText1.Text = resources.GetString("lblAdditionalText1_Text");
                this.lblAdditionalText2.Text = resources.GetString("lblAdditionalText2_Text");
                this.lblAdditionalText3.Text = resources.GetString("lblAdditionalText3_Text");
                this.lblAdditionalText4.Text = resources.GetString("lblAdditionalText4_Text");
                this.lblAdditionalText5.Text = resources.GetString("lblAdditionalText5_Text");
                this.lblAdditionalText6.Text = resources.GetString("lblAdditionalText6_Text");
                this.lblAdditionalText7.Text = resources.GetString("lblAdditionalText7_Text");
                this.lblAdditionalText8.Text = resources.GetString("lblAdditionalText8_Text");
                this.lblAdditionalText9.Text = resources.GetString("lblAdditionalText9_Text");

                // Set the window title to include the alarm ID
                this.Text = $"Alarm Details {alarm.AlarmId.ToString()}";

                // Fill in alarm details in the corresponding fields
                this.txtProducer.Text = alarm.AlarmProducer.ToString();
                this.txtAlarmId.Text = alarm.AlarmId.ToString();
                this.txtMessageType.Text = alarm.MessageType.ToString();
                this.txtState.Text = alarm.AlarmState.ToString();

                CultureInfo textCultureInfo = null;

                // Choose the best matching culture for alarm text
                if (alarm.TextCultureInfos.ContainsKey(Thread.CurrentThread.CurrentUICulture.LCID))
                    textCultureInfo = Thread.CurrentThread.CurrentUICulture;
                else
                    textCultureInfo = alarm.TextCultureInfos.FirstOrDefault().Value;

                // Display alarm timestamps (may be empty)
                this.txtTSComing.Text = alarm.TimeStampComing?.ToString() ?? string.Empty;
                this.txtTSGoing.Text = alarm.TimeStampGoing?.ToString() ?? string.Empty;
                this.txtTSAck.Text = alarm.TimeStampAck?.ToString() ?? string.Empty;

                // Display class ID and alarm number
                txtClassId.Text = alarm.AlarmClass.ToString();
                txtAlarmNo.Text = alarm.AlarmNumber.ToString();

                // Filter alarm text entries by selected culture
                var entries = alarm.AlarmTextEntries.Where(a => a.Culture.LCID == textCultureInfo.LCID);

                // Fill each UI field with the corresponding alarm text (or empty if not available)
                this.txtInfoText.Text = entries.FirstOrDefault(a => a.AlarmTextType == eAlarmTextType.InfoText)?.Text ?? string.Empty;
                this.txtAlarmText.Text = entries.FirstOrDefault(a => a.AlarmTextType == eAlarmTextType.AlarmText)?.Text ?? string.Empty;
                this.txtAdditionalText1.Text = entries.FirstOrDefault(a => a.AlarmTextType == eAlarmTextType.AdditionalText1)?.Text ?? string.Empty;
                this.txtAdditionalText2.Text = entries.FirstOrDefault(a => a.AlarmTextType == eAlarmTextType.AdditionalText2)?.Text ?? string.Empty;
                this.txtAdditionalText3.Text = entries.FirstOrDefault(a => a.AlarmTextType == eAlarmTextType.AdditionalText3)?.Text ?? string.Empty;
                this.txtAdditionalText4.Text = entries.FirstOrDefault(a => a.AlarmTextType == eAlarmTextType.AdditionalText4)?.Text ?? string.Empty;
                this.txtAdditionalText5.Text = entries.FirstOrDefault(a => a.AlarmTextType == eAlarmTextType.AdditionalText5)?.Text ?? string.Empty;
                this.txtAdditionalText6.Text = entries.FirstOrDefault(a => a.AlarmTextType == eAlarmTextType.AdditionalText6)?.Text ?? string.Empty;
                this.txtAdditionalText7.Text = entries.FirstOrDefault(a => a.AlarmTextType == eAlarmTextType.AdditionalText7)?.Text ?? string.Empty;
                this.txtAdditionalText8.Text = entries.FirstOrDefault(a => a.AlarmTextType == eAlarmTextType.AdditionalText8)?.Text ?? string.Empty;
                this.txtAdditionalText9.Text = entries.FirstOrDefault(a => a.AlarmTextType == eAlarmTextType.AdditionalText9)?.Text ?? string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while creating alarm details form " + ex.Message);
            }
        }

        /// <summary>
        /// Handles the Close button click event for the dialog.
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
