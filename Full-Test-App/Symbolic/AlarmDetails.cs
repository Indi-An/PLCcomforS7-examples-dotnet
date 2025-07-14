using PLCcom;
using PLCcom.Core.S7Plus.Alarm;
using PLCcom.Enums.S7Plus;
using PLCCom_Full_Test_App.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLCCom_Full_Test_App.Symbolic
{
    public partial class AlarmDetails : Form
    {

        public AlarmDetails(AlarmNotification alarm, ResourceManager resources)
        {
            try
            {
                InitializeComponent();

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

                // Set the text of the form to the alarm text
                this.Text = $"Alarm Details {alarm.AlarmId.ToString()}";

                //get alarm details
                this.txtProducer.Text = alarm.AlarmProducer.ToString();
                this.txtAlarmId.Text = alarm.AlarmId.ToString();
                this.txtMessageType.Text = alarm.MessageType.ToString();
                this.txtState.Text = alarm.AlarmState.ToString();

                CultureInfo textCultureInfo = null;

                //get the alarm text with the right language
                if (alarm.TextCultureInfos.ContainsKey(Thread.CurrentThread.CurrentUICulture.LCID))
                    textCultureInfo = Thread.CurrentThread.CurrentUICulture;
                else
                    textCultureInfo = alarm.TextCultureInfos.FirstOrDefault().Value;


                //get Timestamps
                this.txtTSComing.Text = alarm.TimeStampComing?.ToString() ?? string.Empty;
                this.txtTSGoing.Text = alarm.TimeStampGoing?.ToString() ?? string.Empty;
                this.txtTSAck.Text = alarm.TimeStampAck?.ToString() ?? string.Empty;

                //gethmiinfo
                txtClassId.Text = alarm.AlarmClass.ToString();
                txtAlarmNo.Text = alarm.AlarmNumber.ToString();

                //Filter cultureinfo
                var entries = alarm.AlarmTextEntries.Where(a => a.Culture.LCID == textCultureInfo.LCID);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
