using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrexMinerGUI.Properties;

namespace TrexMinerGUI.Forms
{
    public partial class GUISettingsForm : Form
    {
        private bool IsInitialized { get; set; }

        public GUISettingsForm()
        {
            IsInitialized = false;

            InitializeComponent();

            InitValues();

            IsInitialized = true;
        }

        private void InitValues()
        {
            this.StartOnStartupCheckBox.Checked = TaskSchedulerOperations.IsItInTS();
            this.StartMiningOnAppStartCheckBox.Checked = Program.TheConfig.StartMiningOnAppStart;
            this.TryToCloseMSIAfterburnerIfItIsNotRunningAlreadyCheckBox.Checked = Program.TheConfig.TryToCloseMSIAfterburnerIfItIsNotRunningAlready;
            this.SendEmailOnErrorsCheckBox.Checked = Program.TheConfig.TheEmailSetting.SendMail;
            this.EmailHostTextBox.Text = Program.TheConfig.TheEmailSetting.Host;
            this.EmailPortTextBox.Text = Program.TheConfig.TheEmailSetting.Port.ToString();
            this.EmailUserNameTextBox.Text = Program.TheConfig.TheEmailSetting.UserName;
            this.EmailPasswordTextBox.Text = Program.TheConfig.TheEmailSetting.Password;
            this.EmailSendFromTextBox.Text = Program.TheConfig.TheEmailSetting.SendFrom;
            this.EmailSendToTextBox.Text = Program.TheConfig.TheEmailSetting.SendTo;
            this.EmailSubjectTextBox.Text = Program.TheConfig.TheEmailSetting.Subject;

            EmailSettingsGroupBox.Enabled = Program.TheConfig.TheEmailSetting.SendMail;
        }

        private void StartOnStartupCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!IsInitialized)
                return;

            if (((CheckBox)sender).Checked)
            {
                TaskSchedulerOperations.AddToTS();
            }
            else
            {
                TaskSchedulerOperations.RemoveFromTS();
            }
        }

        private void StartMiningOnAppStartCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!IsInitialized)
                return;

            Program.TheConfig.StartMiningOnAppStart = ((CheckBox)sender).Checked;
            Program.TheConfig.SaveConfigToFile();
        }

        private void TryToCloseMSIAfterburnerIfItIsNotRunningAlreadyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!IsInitialized)
                return;

            Program.TheConfig.TryToCloseMSIAfterburnerIfItIsNotRunningAlready = ((CheckBox)sender).Checked;
            Program.TheConfig.SaveConfigToFile();
        }

        private void SendEmailOnErrorsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!IsInitialized)
                return;

            Program.TheConfig.TheEmailSetting.SendMail = ((CheckBox)sender).Checked;
            EmailSettingsGroupBox.Enabled = Program.TheConfig.TheEmailSetting.SendMail;
            Program.TheConfig.SaveConfigToFile();
        }

        private void GUISettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveEmailSettings();
        }

        private void SendTestEmailButton_Click(object sender, EventArgs e)
        {
            SaveEmailSettings();

            try
            {
                using (var smtpClient = new System.Net.Mail.SmtpClient(host: Program.TheConfig.TheEmailSetting.Host, port: Program.TheConfig.TheEmailSetting.Port))
                {
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new System.Net.NetworkCredential(Program.TheConfig.TheEmailSetting.UserName, Program.TheConfig.TheEmailSetting.Password);
                    smtpClient.EnableSsl = true;

                    smtpClient.Send(from: Program.TheConfig.TheEmailSetting.SendFrom,
                        recipients: Program.TheConfig.TheEmailSetting.SendTo,
                        subject: Program.TheConfig.TheEmailSetting.Subject,
                        body: "This is a test mail.");
                }

                MessageBox.Show("The email has been sent successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (Exception ex)
            {
                Program.ShowExceptionMessage(ex);
            }
        }

        private void SaveEmailSettings()
        {
            Program.TheConfig.TheEmailSetting.Port = int.Parse(this.EmailPortTextBox.Text);
            Program.TheConfig.TheEmailSetting.Host = this.EmailHostTextBox.Text;   
            Program.TheConfig.TheEmailSetting.UserName = this.EmailUserNameTextBox.Text;
            Program.TheConfig.TheEmailSetting.Password = this.EmailPasswordTextBox.Text;
            Program.TheConfig.TheEmailSetting.SendFrom = this.EmailSendFromTextBox.Text;
            Program.TheConfig.TheEmailSetting.SendTo = this.EmailSendToTextBox.Text;
            Program.TheConfig.TheEmailSetting.Subject = this.EmailSubjectTextBox.Text;

            Program.TheConfig.SaveConfigToFile();
        }
    }
}
