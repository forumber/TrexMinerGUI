
using TrexMinerGUI.Properties;

namespace TrexMinerGUI.Forms
{
    partial class MainForm
    {
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
            this.components = new System.ComponentModel.Container();
            this.MinerStatusLabel = new System.Windows.Forms.Label();
            this.MinerStatusTextBox = new System.Windows.Forms.TextBox();
            this.DurationLabel = new System.Windows.Forms.Label();
            this.DurationTextBox = new System.Windows.Forms.TextBox();
            this.SpeedTextBox = new System.Windows.Forms.TextBox();
            this.PowerTextBox = new System.Windows.Forms.TextBox();
            this.FanSpeedTextBox = new System.Windows.Forms.TextBox();
            this.TempTextBox = new System.Windows.Forms.TextBox();
            this.SpeedLabel = new System.Windows.Forms.Label();
            this.PowerLabel = new System.Windows.Forms.Label();
            this.FanSpeedLabel = new System.Windows.Forms.Label();
            this.TempLabel = new System.Windows.Forms.Label();
            this.LastUpdatedLabel = new System.Windows.Forms.Label();
            this.LastUpdatedText = new System.Windows.Forms.Label();
            this.EfficiencyLabel = new System.Windows.Forms.Label();
            this.EfficiencyTextBox = new System.Windows.Forms.TextBox();
            this.StatisticsBox = new System.Windows.Forms.GroupBox();
            this.StartStopButton = new System.Windows.Forms.Button();
            this.TimerUpdateForm = new System.Windows.Forms.Timer(this.components);
            this.SettingsBox = new System.Windows.Forms.GroupBox();
            this.ProfileComboBox = new System.Windows.Forms.ComboBox();
            this.ActiveProfileLabel = new System.Windows.Forms.Label();
            this.ProfilesButton = new System.Windows.Forms.Button();
            this.GUISettingsButton = new System.Windows.Forms.Button();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.SessionGroupBox = new System.Windows.Forms.GroupBox();
            this.SharesWarningLinkLabel = new System.Windows.Forms.LinkLabel();
            this.InformationLogButton = new System.Windows.Forms.Button();
            this.SharesTextBox = new System.Windows.Forms.TextBox();
            this.SharesLabel = new System.Windows.Forms.Label();
            this.ErrorCountLinkLabel = new System.Windows.Forms.LinkLabel();
            this.WarnCountLinkLabel = new System.Windows.Forms.LinkLabel();
            this.SessionStartedAtTextBox = new System.Windows.Forms.TextBox();
            this.StartedAtLabel = new System.Windows.Forms.Label();
            this.ErrorCountTextBox = new System.Windows.Forms.TextBox();
            this.WarnCountTextBox = new System.Windows.Forms.TextBox();
            this.TrexVersionLabel = new System.Windows.Forms.Label();
            this.StatisticsBox.SuspendLayout();
            this.SettingsBox.SuspendLayout();
            this.SessionGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // MinerStatusLabel
            // 
            this.MinerStatusLabel.AutoSize = true;
            this.MinerStatusLabel.Location = new System.Drawing.Point(18, 17);
            this.MinerStatusLabel.Name = "MinerStatusLabel";
            this.MinerStatusLabel.Size = new System.Drawing.Size(41, 15);
            this.MinerStatusLabel.TabIndex = 0;
            this.MinerStatusLabel.Text = "Miner:";
            // 
            // MinerStatusTextBox
            // 
            this.MinerStatusTextBox.Enabled = false;
            this.MinerStatusTextBox.Location = new System.Drawing.Point(89, 14);
            this.MinerStatusTextBox.Name = "MinerStatusTextBox";
            this.MinerStatusTextBox.Size = new System.Drawing.Size(153, 23);
            this.MinerStatusTextBox.TabIndex = 1;
            // 
            // DurationLabel
            // 
            this.DurationLabel.AutoSize = true;
            this.DurationLabel.Location = new System.Drawing.Point(18, 46);
            this.DurationLabel.Name = "DurationLabel";
            this.DurationLabel.Size = new System.Drawing.Size(56, 15);
            this.DurationLabel.TabIndex = 2;
            this.DurationLabel.Text = "Duration:";
            // 
            // DurationTextBox
            // 
            this.DurationTextBox.Enabled = false;
            this.DurationTextBox.Location = new System.Drawing.Point(89, 43);
            this.DurationTextBox.Name = "DurationTextBox";
            this.DurationTextBox.Size = new System.Drawing.Size(153, 23);
            this.DurationTextBox.TabIndex = 3;
            // 
            // SpeedTextBox
            // 
            this.SpeedTextBox.Enabled = false;
            this.SpeedTextBox.Location = new System.Drawing.Point(77, 22);
            this.SpeedTextBox.Name = "SpeedTextBox";
            this.SpeedTextBox.Size = new System.Drawing.Size(153, 23);
            this.SpeedTextBox.TabIndex = 4;
            // 
            // PowerTextBox
            // 
            this.PowerTextBox.Enabled = false;
            this.PowerTextBox.Location = new System.Drawing.Point(77, 52);
            this.PowerTextBox.Name = "PowerTextBox";
            this.PowerTextBox.Size = new System.Drawing.Size(153, 23);
            this.PowerTextBox.TabIndex = 5;
            // 
            // FanSpeedTextBox
            // 
            this.FanSpeedTextBox.Enabled = false;
            this.FanSpeedTextBox.Location = new System.Drawing.Point(77, 111);
            this.FanSpeedTextBox.Name = "FanSpeedTextBox";
            this.FanSpeedTextBox.Size = new System.Drawing.Size(153, 23);
            this.FanSpeedTextBox.TabIndex = 6;
            // 
            // TempTextBox
            // 
            this.TempTextBox.Enabled = false;
            this.TempTextBox.Location = new System.Drawing.Point(77, 140);
            this.TempTextBox.Name = "TempTextBox";
            this.TempTextBox.Size = new System.Drawing.Size(153, 23);
            this.TempTextBox.TabIndex = 7;
            // 
            // SpeedLabel
            // 
            this.SpeedLabel.AutoSize = true;
            this.SpeedLabel.Location = new System.Drawing.Point(6, 25);
            this.SpeedLabel.Name = "SpeedLabel";
            this.SpeedLabel.Size = new System.Drawing.Size(42, 15);
            this.SpeedLabel.TabIndex = 8;
            this.SpeedLabel.Text = "Speed:";
            // 
            // PowerLabel
            // 
            this.PowerLabel.AutoSize = true;
            this.PowerLabel.Location = new System.Drawing.Point(6, 55);
            this.PowerLabel.Name = "PowerLabel";
            this.PowerLabel.Size = new System.Drawing.Size(43, 15);
            this.PowerLabel.TabIndex = 9;
            this.PowerLabel.Text = "Power:";
            // 
            // FanSpeedLabel
            // 
            this.FanSpeedLabel.AutoSize = true;
            this.FanSpeedLabel.Location = new System.Drawing.Point(8, 114);
            this.FanSpeedLabel.Name = "FanSpeedLabel";
            this.FanSpeedLabel.Size = new System.Drawing.Size(29, 15);
            this.FanSpeedLabel.TabIndex = 10;
            this.FanSpeedLabel.Text = "Fan:";
            // 
            // TempLabel
            // 
            this.TempLabel.AutoSize = true;
            this.TempLabel.Location = new System.Drawing.Point(8, 143);
            this.TempLabel.Name = "TempLabel";
            this.TempLabel.Size = new System.Drawing.Size(39, 15);
            this.TempLabel.TabIndex = 11;
            this.TempLabel.Text = "Temp:";
            // 
            // LastUpdatedLabel
            // 
            this.LastUpdatedLabel.AutoSize = true;
            this.LastUpdatedLabel.Location = new System.Drawing.Point(8, 176);
            this.LastUpdatedLabel.Name = "LastUpdatedLabel";
            this.LastUpdatedLabel.Size = new System.Drawing.Size(72, 15);
            this.LastUpdatedLabel.TabIndex = 16;
            this.LastUpdatedLabel.Text = "Updated on:";
            // 
            // LastUpdatedText
            // 
            this.LastUpdatedText.AutoSize = true;
            this.LastUpdatedText.Location = new System.Drawing.Point(77, 176);
            this.LastUpdatedText.Name = "LastUpdatedText";
            this.LastUpdatedText.Size = new System.Drawing.Size(94, 15);
            this.LastUpdatedText.TabIndex = 17;
            this.LastUpdatedText.Text = "LastUpdatedText";
            // 
            // EfficiencyLabel
            // 
            this.EfficiencyLabel.AutoSize = true;
            this.EfficiencyLabel.Location = new System.Drawing.Point(6, 85);
            this.EfficiencyLabel.Name = "EfficiencyLabel";
            this.EfficiencyLabel.Size = new System.Drawing.Size(61, 15);
            this.EfficiencyLabel.TabIndex = 18;
            this.EfficiencyLabel.Text = "Efficiency:";
            // 
            // EfficiencyTextBox
            // 
            this.EfficiencyTextBox.Enabled = false;
            this.EfficiencyTextBox.Location = new System.Drawing.Point(77, 82);
            this.EfficiencyTextBox.Name = "EfficiencyTextBox";
            this.EfficiencyTextBox.Size = new System.Drawing.Size(153, 23);
            this.EfficiencyTextBox.TabIndex = 19;
            // 
            // StatisticsBox
            // 
            this.StatisticsBox.Controls.Add(this.EfficiencyTextBox);
            this.StatisticsBox.Controls.Add(this.EfficiencyLabel);
            this.StatisticsBox.Controls.Add(this.LastUpdatedText);
            this.StatisticsBox.Controls.Add(this.LastUpdatedLabel);
            this.StatisticsBox.Controls.Add(this.SpeedTextBox);
            this.StatisticsBox.Controls.Add(this.PowerTextBox);
            this.StatisticsBox.Controls.Add(this.FanSpeedTextBox);
            this.StatisticsBox.Controls.Add(this.TempTextBox);
            this.StatisticsBox.Controls.Add(this.SpeedLabel);
            this.StatisticsBox.Controls.Add(this.TempLabel);
            this.StatisticsBox.Controls.Add(this.PowerLabel);
            this.StatisticsBox.Controls.Add(this.FanSpeedLabel);
            this.StatisticsBox.Location = new System.Drawing.Point(12, 72);
            this.StatisticsBox.Name = "StatisticsBox";
            this.StatisticsBox.Size = new System.Drawing.Size(246, 199);
            this.StatisticsBox.TabIndex = 20;
            this.StatisticsBox.TabStop = false;
            this.StatisticsBox.Text = "Statistics";
            // 
            // StartStopButton
            // 
            this.StartStopButton.BackgroundImage = global::TrexMinerGUI.Properties.Resources.Start_icon;
            this.StartStopButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.StartStopButton.Location = new System.Drawing.Point(12, 277);
            this.StartStopButton.Name = "StartStopButton";
            this.StartStopButton.Size = new System.Drawing.Size(33, 30);
            this.StartStopButton.TabIndex = 21;
            this.StartStopButton.UseVisualStyleBackColor = true;
            this.StartStopButton.Click += new System.EventHandler(this.StartStopButton_Click);
            // 
            // TimerUpdateForm
            // 
            this.TimerUpdateForm.Enabled = true;
            this.TimerUpdateForm.Tick += new System.EventHandler(this.UpdateForm);
            // 
            // SettingsBox
            // 
            this.SettingsBox.Controls.Add(this.ProfileComboBox);
            this.SettingsBox.Controls.Add(this.ActiveProfileLabel);
            this.SettingsBox.Controls.Add(this.ProfilesButton);
            this.SettingsBox.Controls.Add(this.GUISettingsButton);
            this.SettingsBox.Location = new System.Drawing.Point(264, 12);
            this.SettingsBox.Name = "SettingsBox";
            this.SettingsBox.Size = new System.Drawing.Size(392, 157);
            this.SettingsBox.TabIndex = 22;
            this.SettingsBox.TabStop = false;
            this.SettingsBox.Text = "Settings";
            // 
            // ProfileComboBox
            // 
            this.ProfileComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProfileComboBox.FormattingEnabled = true;
            this.ProfileComboBox.Location = new System.Drawing.Point(92, 16);
            this.ProfileComboBox.Name = "ProfileComboBox";
            this.ProfileComboBox.Size = new System.Drawing.Size(292, 23);
            this.ProfileComboBox.TabIndex = 4;
            this.ProfileComboBox.SelectedIndexChanged += new System.EventHandler(this.ProfileComboBox_SelectedIndexChanged);
            // 
            // ActiveProfileLabel
            // 
            this.ActiveProfileLabel.AutoSize = true;
            this.ActiveProfileLabel.Location = new System.Drawing.Point(6, 19);
            this.ActiveProfileLabel.Name = "ActiveProfileLabel";
            this.ActiveProfileLabel.Size = new System.Drawing.Size(80, 15);
            this.ActiveProfileLabel.TabIndex = 3;
            this.ActiveProfileLabel.Text = "Active Profile:";
            // 
            // ProfilesButton
            // 
            this.ProfilesButton.Location = new System.Drawing.Point(6, 60);
            this.ProfilesButton.Name = "ProfilesButton";
            this.ProfilesButton.Size = new System.Drawing.Size(378, 23);
            this.ProfilesButton.TabIndex = 1;
            this.ProfilesButton.Text = "Profiles";
            this.ProfilesButton.UseVisualStyleBackColor = true;
            this.ProfilesButton.Click += new System.EventHandler(this.ProfilesButton_Click);
            // 
            // GUISettingsButton
            // 
            this.GUISettingsButton.Location = new System.Drawing.Point(6, 89);
            this.GUISettingsButton.Name = "GUISettingsButton";
            this.GUISettingsButton.Size = new System.Drawing.Size(378, 23);
            this.GUISettingsButton.TabIndex = 0;
            this.GUISettingsButton.Text = "GUI Settings";
            this.GUISettingsButton.UseVisualStyleBackColor = true;
            this.GUISettingsButton.Click += new System.EventHandler(this.GUISettingsButton_Click);
            // 
            // VersionLabel
            // 
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.Location = new System.Drawing.Point(611, 292);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(45, 15);
            this.VersionLabel.TabIndex = 23;
            this.VersionLabel.Text = "Version";
            // 
            // SessionGroupBox
            // 
            this.SessionGroupBox.Controls.Add(this.SharesWarningLinkLabel);
            this.SessionGroupBox.Controls.Add(this.InformationLogButton);
            this.SessionGroupBox.Controls.Add(this.SharesTextBox);
            this.SessionGroupBox.Controls.Add(this.SharesLabel);
            this.SessionGroupBox.Controls.Add(this.ErrorCountLinkLabel);
            this.SessionGroupBox.Controls.Add(this.WarnCountLinkLabel);
            this.SessionGroupBox.Controls.Add(this.SessionStartedAtTextBox);
            this.SessionGroupBox.Controls.Add(this.StartedAtLabel);
            this.SessionGroupBox.Controls.Add(this.ErrorCountTextBox);
            this.SessionGroupBox.Controls.Add(this.WarnCountTextBox);
            this.SessionGroupBox.Location = new System.Drawing.Point(265, 175);
            this.SessionGroupBox.Name = "SessionGroupBox";
            this.SessionGroupBox.Size = new System.Drawing.Size(391, 114);
            this.SessionGroupBox.TabIndex = 24;
            this.SessionGroupBox.TabStop = false;
            this.SessionGroupBox.Text = "Session";
            // 
            // SharesWarningLinkLabel
            // 
            this.SharesWarningLinkLabel.AutoSize = true;
            this.SharesWarningLinkLabel.Location = new System.Drawing.Point(367, 23);
            this.SharesWarningLinkLabel.Name = "SharesWarningLinkLabel";
            this.SharesWarningLinkLabel.Size = new System.Drawing.Size(18, 15);
            this.SharesWarningLinkLabel.TabIndex = 27;
            this.SharesWarningLinkLabel.TabStop = true;
            this.SharesWarningLinkLabel.Text = "(!)";
            this.SharesWarningLinkLabel.Visible = false;
            this.SharesWarningLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SharesWarningLinkLabel_LinkClicked);
            // 
            // InformationLogButton
            // 
            this.InformationLogButton.Location = new System.Drawing.Point(207, 77);
            this.InformationLogButton.Name = "InformationLogButton";
            this.InformationLogButton.Size = new System.Drawing.Size(166, 23);
            this.InformationLogButton.TabIndex = 26;
            this.InformationLogButton.Text = "Information Log";
            this.InformationLogButton.UseVisualStyleBackColor = true;
            this.InformationLogButton.Click += new System.EventHandler(this.InformationLogButton_Click);
            // 
            // SharesTextBox
            // 
            this.SharesTextBox.Enabled = false;
            this.SharesTextBox.Location = new System.Drawing.Point(257, 20);
            this.SharesTextBox.Name = "SharesTextBox";
            this.SharesTextBox.Size = new System.Drawing.Size(104, 23);
            this.SharesTextBox.TabIndex = 25;
            // 
            // SharesLabel
            // 
            this.SharesLabel.AutoSize = true;
            this.SharesLabel.Location = new System.Drawing.Point(207, 23);
            this.SharesLabel.Name = "SharesLabel";
            this.SharesLabel.Size = new System.Drawing.Size(44, 15);
            this.SharesLabel.TabIndex = 24;
            this.SharesLabel.Text = "Shares:";
            // 
            // ErrorCountLinkLabel
            // 
            this.ErrorCountLinkLabel.AutoSize = true;
            this.ErrorCountLinkLabel.Location = new System.Drawing.Point(7, 81);
            this.ErrorCountLinkLabel.Name = "ErrorCountLinkLabel";
            this.ErrorCountLinkLabel.Size = new System.Drawing.Size(40, 15);
            this.ErrorCountLinkLabel.TabIndex = 23;
            this.ErrorCountLinkLabel.TabStop = true;
            this.ErrorCountLinkLabel.Text = "Errors:";
            this.ErrorCountLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ErrorCountLinkLabel_LinkClicked);
            // 
            // WarnCountLinkLabel
            // 
            this.WarnCountLinkLabel.AutoSize = true;
            this.WarnCountLinkLabel.Location = new System.Drawing.Point(7, 52);
            this.WarnCountLinkLabel.Name = "WarnCountLinkLabel";
            this.WarnCountLinkLabel.Size = new System.Drawing.Size(60, 15);
            this.WarnCountLinkLabel.TabIndex = 22;
            this.WarnCountLinkLabel.TabStop = true;
            this.WarnCountLinkLabel.Text = "Warnings:";
            this.WarnCountLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.WarningCountLinkLabel_LinkClicked);
            // 
            // SessionStartedAtTextBox
            // 
            this.SessionStartedAtTextBox.Enabled = false;
            this.SessionStartedAtTextBox.Location = new System.Drawing.Point(75, 20);
            this.SessionStartedAtTextBox.Name = "SessionStartedAtTextBox";
            this.SessionStartedAtTextBox.Size = new System.Drawing.Size(116, 23);
            this.SessionStartedAtTextBox.TabIndex = 21;
            // 
            // StartedAtLabel
            // 
            this.StartedAtLabel.AutoSize = true;
            this.StartedAtLabel.Location = new System.Drawing.Point(7, 23);
            this.StartedAtLabel.Name = "StartedAtLabel";
            this.StartedAtLabel.Size = new System.Drawing.Size(60, 15);
            this.StartedAtLabel.TabIndex = 20;
            this.StartedAtLabel.Text = "Started at:";
            // 
            // ErrorCountTextBox
            // 
            this.ErrorCountTextBox.Enabled = false;
            this.ErrorCountTextBox.Location = new System.Drawing.Point(75, 78);
            this.ErrorCountTextBox.Name = "ErrorCountTextBox";
            this.ErrorCountTextBox.Size = new System.Drawing.Size(116, 23);
            this.ErrorCountTextBox.TabIndex = 17;
            // 
            // WarnCountTextBox
            // 
            this.WarnCountTextBox.Enabled = false;
            this.WarnCountTextBox.Location = new System.Drawing.Point(75, 49);
            this.WarnCountTextBox.Name = "WarnCountTextBox";
            this.WarnCountTextBox.Size = new System.Drawing.Size(116, 23);
            this.WarnCountTextBox.TabIndex = 16;
            // 
            // TrexVersionLabel
            // 
            this.TrexVersionLabel.AutoSize = true;
            this.TrexVersionLabel.Location = new System.Drawing.Point(266, 292);
            this.TrexVersionLabel.Name = "TrexVersionLabel";
            this.TrexVersionLabel.Size = new System.Drawing.Size(66, 15);
            this.TrexVersionLabel.TabIndex = 25;
            this.TrexVersionLabel.Text = "TrexVersion";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 313);
            this.Controls.Add(this.TrexVersionLabel);
            this.Controls.Add(this.MinerStatusLabel);
            this.Controls.Add(this.SessionGroupBox);
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.MinerStatusTextBox);
            this.Controls.Add(this.SettingsBox);
            this.Controls.Add(this.StartStopButton);
            this.Controls.Add(this.DurationLabel);
            this.Controls.Add(this.StatisticsBox);
            this.Controls.Add(this.DurationTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TrexMinerGUI";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.StatisticsBox.ResumeLayout(false);
            this.StatisticsBox.PerformLayout();
            this.SettingsBox.ResumeLayout(false);
            this.SettingsBox.PerformLayout();
            this.SessionGroupBox.ResumeLayout(false);
            this.SessionGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MinerStatusLabel;
        private System.Windows.Forms.TextBox MinerStatusTextBox;
        private System.Windows.Forms.Label DurationLabel;
        private System.Windows.Forms.TextBox DurationTextBox;
        private System.Windows.Forms.TextBox SpeedTextBox;
        private System.Windows.Forms.TextBox PowerTextBox;
        private System.Windows.Forms.TextBox FanSpeedTextBox;
        private System.Windows.Forms.TextBox TempTextBox;
        private System.Windows.Forms.Label SpeedLabel;
        private System.Windows.Forms.Label PowerLabel;
        private System.Windows.Forms.Label FanSpeedLabel;
        private System.Windows.Forms.Label TempLabel;
        private System.Windows.Forms.Label LastUpdatedLabel;
        private System.Windows.Forms.Label LastUpdatedText;
        private System.Windows.Forms.Label EfficiencyLabel;
        private System.Windows.Forms.TextBox EfficiencyTextBox;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.GroupBox StatisticsBox;
        private System.Windows.Forms.Button StartStopButton;
        private System.Windows.Forms.Timer TimerUpdateForm;
        private System.Windows.Forms.GroupBox SettingsBox;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.GroupBox SessionGroupBox;
        private System.Windows.Forms.TextBox ErrorCountTextBox;
        private System.Windows.Forms.TextBox WarnCountTextBox;
        private System.Windows.Forms.TextBox SessionStartedAtTextBox;
        private System.Windows.Forms.Label StartedAtLabel;
        private System.Windows.Forms.LinkLabel ErrorCountLinkLabel;
        private System.Windows.Forms.LinkLabel WarnCountLinkLabel;
        private System.Windows.Forms.TextBox SharesTextBox;
        private System.Windows.Forms.Label SharesLabel;
        private System.Windows.Forms.Button InformationLogButton;
        private System.Windows.Forms.Button ProfilesButton;
        private System.Windows.Forms.Button GUISettingsButton;
        private System.Windows.Forms.LinkLabel SharesWarningLinkLabel;
        private System.Windows.Forms.Label TrexVersionLabel;
        private System.Windows.Forms.ComboBox ProfileComboBox;
        private System.Windows.Forms.Label ActiveProfileLabel;
    }
}