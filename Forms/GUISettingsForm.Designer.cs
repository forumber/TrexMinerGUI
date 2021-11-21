
namespace TrexMinerGUI.Forms
{
    partial class GUISettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.StartMiningOnAppStartCheckBox = new System.Windows.Forms.CheckBox();
            this.StartOnStartupCheckBox = new System.Windows.Forms.CheckBox();
            this.TryToCloseMSIAfterburnerIfItIsNotRunningAlreadyCheckBox = new System.Windows.Forms.CheckBox();
            this.SendEmailOnErrorsCheckBox = new System.Windows.Forms.CheckBox();
            this.EmailSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.SendTestEmailButton = new System.Windows.Forms.Button();
            this.EmailSubjectLabel = new System.Windows.Forms.Label();
            this.EmailSubjectTextBox = new System.Windows.Forms.TextBox();
            this.EmailSendToLabel = new System.Windows.Forms.Label();
            this.EmailSendToTextBox = new System.Windows.Forms.TextBox();
            this.EmailSendFromLabel = new System.Windows.Forms.Label();
            this.EmailSendFromTextBox = new System.Windows.Forms.TextBox();
            this.EmailPasswordLabel = new System.Windows.Forms.Label();
            this.EmailPasswordTextBox = new System.Windows.Forms.TextBox();
            this.EmailUserNameLabel = new System.Windows.Forms.Label();
            this.EmailUserNameTextBox = new System.Windows.Forms.TextBox();
            this.EmailPortLabel = new System.Windows.Forms.Label();
            this.EmailPortTextBox = new System.Windows.Forms.TextBox();
            this.EmailHostTextBox = new System.Windows.Forms.TextBox();
            this.EmailHostLabel = new System.Windows.Forms.Label();
            this.EmailSettingsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartMiningOnAppStartCheckBox
            // 
            this.StartMiningOnAppStartCheckBox.AutoSize = true;
            this.StartMiningOnAppStartCheckBox.Location = new System.Drawing.Point(12, 37);
            this.StartMiningOnAppStartCheckBox.Name = "StartMiningOnAppStartCheckBox";
            this.StartMiningOnAppStartCheckBox.Size = new System.Drawing.Size(186, 19);
            this.StartMiningOnAppStartCheckBox.TabIndex = 12;
            this.StartMiningOnAppStartCheckBox.Text = "Start miner at program startup";
            this.StartMiningOnAppStartCheckBox.UseVisualStyleBackColor = true;
            this.StartMiningOnAppStartCheckBox.CheckedChanged += new System.EventHandler(this.StartMiningOnAppStartCheckBox_CheckedChanged);
            // 
            // StartOnStartupCheckBox
            // 
            this.StartOnStartupCheckBox.AutoSize = true;
            this.StartOnStartupCheckBox.Location = new System.Drawing.Point(12, 12);
            this.StartOnStartupCheckBox.Name = "StartOnStartupCheckBox";
            this.StartOnStartupCheckBox.Size = new System.Drawing.Size(229, 19);
            this.StartOnStartupCheckBox.TabIndex = 11;
            this.StartOnStartupCheckBox.Text = "Open the program at Windows startup";
            this.StartOnStartupCheckBox.UseVisualStyleBackColor = true;
            this.StartOnStartupCheckBox.CheckedChanged += new System.EventHandler(this.StartOnStartupCheckBox_CheckedChanged);
            // 
            // TryToCloseMSIAfterburnerIfItIsNotRunningAlreadyCheckBox
            // 
            this.TryToCloseMSIAfterburnerIfItIsNotRunningAlreadyCheckBox.Location = new System.Drawing.Point(12, 62);
            this.TryToCloseMSIAfterburnerIfItIsNotRunningAlreadyCheckBox.Name = "TryToCloseMSIAfterburnerIfItIsNotRunningAlreadyCheckBox";
            this.TryToCloseMSIAfterburnerIfItIsNotRunningAlreadyCheckBox.Size = new System.Drawing.Size(226, 52);
            this.TryToCloseMSIAfterburnerIfItIsNotRunningAlreadyCheckBox.TabIndex = 20;
            this.TryToCloseMSIAfterburnerIfItIsNotRunningAlreadyCheckBox.Text = "If the MSI Afterburner is not already running before applying profile, try to clo" +
    "se it after applying profile";
            this.TryToCloseMSIAfterburnerIfItIsNotRunningAlreadyCheckBox.UseVisualStyleBackColor = true;
            this.TryToCloseMSIAfterburnerIfItIsNotRunningAlreadyCheckBox.CheckedChanged += new System.EventHandler(this.TryToCloseMSIAfterburnerIfItIsNotRunningAlreadyCheckBox_CheckedChanged);
            // 
            // SendEmailOnErrorsCheckBox
            // 
            this.SendEmailOnErrorsCheckBox.AutoSize = true;
            this.SendEmailOnErrorsCheckBox.Location = new System.Drawing.Point(12, 120);
            this.SendEmailOnErrorsCheckBox.Name = "SendEmailOnErrorsCheckBox";
            this.SendEmailOnErrorsCheckBox.Size = new System.Drawing.Size(182, 19);
            this.SendEmailOnErrorsCheckBox.TabIndex = 21;
            this.SendEmailOnErrorsCheckBox.Text = "Send email when error occurs";
            this.SendEmailOnErrorsCheckBox.UseVisualStyleBackColor = true;
            this.SendEmailOnErrorsCheckBox.CheckedChanged += new System.EventHandler(this.SendEmailOnErrorsCheckBox_CheckedChanged);
            // 
            // EmailSettingsGroupBox
            // 
            this.EmailSettingsGroupBox.Controls.Add(this.SendTestEmailButton);
            this.EmailSettingsGroupBox.Controls.Add(this.EmailSubjectLabel);
            this.EmailSettingsGroupBox.Controls.Add(this.EmailSubjectTextBox);
            this.EmailSettingsGroupBox.Controls.Add(this.EmailSendToLabel);
            this.EmailSettingsGroupBox.Controls.Add(this.EmailSendToTextBox);
            this.EmailSettingsGroupBox.Controls.Add(this.EmailSendFromLabel);
            this.EmailSettingsGroupBox.Controls.Add(this.EmailSendFromTextBox);
            this.EmailSettingsGroupBox.Controls.Add(this.EmailPasswordLabel);
            this.EmailSettingsGroupBox.Controls.Add(this.EmailPasswordTextBox);
            this.EmailSettingsGroupBox.Controls.Add(this.EmailUserNameLabel);
            this.EmailSettingsGroupBox.Controls.Add(this.EmailUserNameTextBox);
            this.EmailSettingsGroupBox.Controls.Add(this.EmailPortLabel);
            this.EmailSettingsGroupBox.Controls.Add(this.EmailPortTextBox);
            this.EmailSettingsGroupBox.Controls.Add(this.EmailHostTextBox);
            this.EmailSettingsGroupBox.Controls.Add(this.EmailHostLabel);
            this.EmailSettingsGroupBox.Location = new System.Drawing.Point(12, 145);
            this.EmailSettingsGroupBox.Name = "EmailSettingsGroupBox";
            this.EmailSettingsGroupBox.Size = new System.Drawing.Size(229, 262);
            this.EmailSettingsGroupBox.TabIndex = 22;
            this.EmailSettingsGroupBox.TabStop = false;
            this.EmailSettingsGroupBox.Text = "Email Settings";
            // 
            // SendTestEmailButton
            // 
            this.SendTestEmailButton.Location = new System.Drawing.Point(6, 233);
            this.SendTestEmailButton.Name = "SendTestEmailButton";
            this.SendTestEmailButton.Size = new System.Drawing.Size(217, 23);
            this.SendTestEmailButton.TabIndex = 14;
            this.SendTestEmailButton.Text = "Send test mail";
            this.SendTestEmailButton.UseVisualStyleBackColor = true;
            this.SendTestEmailButton.Click += new System.EventHandler(this.SendTestEmailButton_Click);
            // 
            // EmailSubjectLabel
            // 
            this.EmailSubjectLabel.AutoSize = true;
            this.EmailSubjectLabel.Location = new System.Drawing.Point(6, 199);
            this.EmailSubjectLabel.Name = "EmailSubjectLabel";
            this.EmailSubjectLabel.Size = new System.Drawing.Size(49, 15);
            this.EmailSubjectLabel.TabIndex = 13;
            this.EmailSubjectLabel.Text = "Subject:";
            // 
            // EmailSubjectTextBox
            // 
            this.EmailSubjectTextBox.Location = new System.Drawing.Point(77, 196);
            this.EmailSubjectTextBox.Name = "EmailSubjectTextBox";
            this.EmailSubjectTextBox.Size = new System.Drawing.Size(146, 23);
            this.EmailSubjectTextBox.TabIndex = 12;
            // 
            // EmailSendToLabel
            // 
            this.EmailSendToLabel.AutoSize = true;
            this.EmailSendToLabel.Location = new System.Drawing.Point(6, 170);
            this.EmailSendToLabel.Name = "EmailSendToLabel";
            this.EmailSendToLabel.Size = new System.Drawing.Size(48, 15);
            this.EmailSendToLabel.TabIndex = 11;
            this.EmailSendToLabel.Text = "SendTo:";
            // 
            // EmailSendToTextBox
            // 
            this.EmailSendToTextBox.Location = new System.Drawing.Point(77, 167);
            this.EmailSendToTextBox.Name = "EmailSendToTextBox";
            this.EmailSendToTextBox.Size = new System.Drawing.Size(146, 23);
            this.EmailSendToTextBox.TabIndex = 10;
            // 
            // EmailSendFromLabel
            // 
            this.EmailSendFromLabel.AutoSize = true;
            this.EmailSendFromLabel.Location = new System.Drawing.Point(6, 141);
            this.EmailSendFromLabel.Name = "EmailSendFromLabel";
            this.EmailSendFromLabel.Size = new System.Drawing.Size(64, 15);
            this.EmailSendFromLabel.TabIndex = 9;
            this.EmailSendFromLabel.Text = "SendFrom:";
            // 
            // EmailSendFromTextBox
            // 
            this.EmailSendFromTextBox.Location = new System.Drawing.Point(77, 138);
            this.EmailSendFromTextBox.Name = "EmailSendFromTextBox";
            this.EmailSendFromTextBox.Size = new System.Drawing.Size(146, 23);
            this.EmailSendFromTextBox.TabIndex = 8;
            // 
            // EmailPasswordLabel
            // 
            this.EmailPasswordLabel.AutoSize = true;
            this.EmailPasswordLabel.Location = new System.Drawing.Point(6, 112);
            this.EmailPasswordLabel.Name = "EmailPasswordLabel";
            this.EmailPasswordLabel.Size = new System.Drawing.Size(60, 15);
            this.EmailPasswordLabel.TabIndex = 7;
            this.EmailPasswordLabel.Text = "Password:";
            // 
            // EmailPasswordTextBox
            // 
            this.EmailPasswordTextBox.Location = new System.Drawing.Point(77, 109);
            this.EmailPasswordTextBox.Name = "EmailPasswordTextBox";
            this.EmailPasswordTextBox.Size = new System.Drawing.Size(146, 23);
            this.EmailPasswordTextBox.TabIndex = 6;
            // 
            // EmailUserNameLabel
            // 
            this.EmailUserNameLabel.AutoSize = true;
            this.EmailUserNameLabel.Location = new System.Drawing.Point(6, 83);
            this.EmailUserNameLabel.Name = "EmailUserNameLabel";
            this.EmailUserNameLabel.Size = new System.Drawing.Size(65, 15);
            this.EmailUserNameLabel.TabIndex = 5;
            this.EmailUserNameLabel.Text = "UserName:";
            // 
            // EmailUserNameTextBox
            // 
            this.EmailUserNameTextBox.Location = new System.Drawing.Point(77, 80);
            this.EmailUserNameTextBox.Name = "EmailUserNameTextBox";
            this.EmailUserNameTextBox.Size = new System.Drawing.Size(146, 23);
            this.EmailUserNameTextBox.TabIndex = 4;
            // 
            // EmailPortLabel
            // 
            this.EmailPortLabel.AutoSize = true;
            this.EmailPortLabel.Location = new System.Drawing.Point(6, 54);
            this.EmailPortLabel.Name = "EmailPortLabel";
            this.EmailPortLabel.Size = new System.Drawing.Size(32, 15);
            this.EmailPortLabel.TabIndex = 3;
            this.EmailPortLabel.Text = "Port:";
            // 
            // EmailPortTextBox
            // 
            this.EmailPortTextBox.Location = new System.Drawing.Point(77, 51);
            this.EmailPortTextBox.Name = "EmailPortTextBox";
            this.EmailPortTextBox.Size = new System.Drawing.Size(146, 23);
            this.EmailPortTextBox.TabIndex = 2;
            // 
            // EmailHostTextBox
            // 
            this.EmailHostTextBox.Location = new System.Drawing.Point(77, 22);
            this.EmailHostTextBox.Name = "EmailHostTextBox";
            this.EmailHostTextBox.Size = new System.Drawing.Size(146, 23);
            this.EmailHostTextBox.TabIndex = 1;
            // 
            // EmailHostLabel
            // 
            this.EmailHostLabel.AutoSize = true;
            this.EmailHostLabel.Location = new System.Drawing.Point(6, 25);
            this.EmailHostLabel.Name = "EmailHostLabel";
            this.EmailHostLabel.Size = new System.Drawing.Size(35, 15);
            this.EmailHostLabel.TabIndex = 0;
            this.EmailHostLabel.Text = "Host:";
            // 
            // GUISettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 419);
            this.Controls.Add(this.EmailSettingsGroupBox);
            this.Controls.Add(this.SendEmailOnErrorsCheckBox);
            this.Controls.Add(this.TryToCloseMSIAfterburnerIfItIsNotRunningAlreadyCheckBox);
            this.Controls.Add(this.StartMiningOnAppStartCheckBox);
            this.Controls.Add(this.StartOnStartupCheckBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "GUISettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GUI Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GUISettingsForm_FormClosing);
            this.EmailSettingsGroupBox.ResumeLayout(false);
            this.EmailSettingsGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox StartMiningOnAppStartCheckBox;
        private System.Windows.Forms.CheckBox StartOnStartupCheckBox;
        private System.Windows.Forms.CheckBox TryToCloseMSIAfterburnerIfItIsNotRunningAlreadyCheckBox;
        private System.Windows.Forms.CheckBox SendEmailOnErrorsCheckBox;
        private System.Windows.Forms.GroupBox EmailSettingsGroupBox;
        private System.Windows.Forms.Label EmailHostLabel;
        private System.Windows.Forms.TextBox EmailHostTextBox;
        private System.Windows.Forms.TextBox EmailPortTextBox;
        private System.Windows.Forms.Label EmailUserNameLabel;
        private System.Windows.Forms.TextBox EmailUserNameTextBox;
        private System.Windows.Forms.Label EmailPortLabel;
        private System.Windows.Forms.Label EmailPasswordLabel;
        private System.Windows.Forms.TextBox EmailPasswordTextBox;
        private System.Windows.Forms.TextBox EmailSendFromTextBox;
        private System.Windows.Forms.Label EmailSendToLabel;
        private System.Windows.Forms.TextBox EmailSendToTextBox;
        private System.Windows.Forms.Label EmailSendFromLabel;
        private System.Windows.Forms.Button SendTestEmailButton;
        private System.Windows.Forms.Label EmailSubjectLabel;
        private System.Windows.Forms.TextBox EmailSubjectTextBox;
    }
}