
using TrexMinerGUI.Properties;

namespace TrexMinerGUI
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
            this.WarnCountTextBox = new System.Windows.Forms.TextBox();
            this.ErrorCountTextBox = new System.Windows.Forms.TextBox();
            this.WarnCountLabel = new System.Windows.Forms.Label();
            this.ErrorCountLabel = new System.Windows.Forms.Label();
            this.LastUpdatedLabel = new System.Windows.Forms.Label();
            this.LastUpdatedText = new System.Windows.Forms.Label();
            this.EfficiencyLabel = new System.Windows.Forms.Label();
            this.EfficiencyTextBox = new System.Windows.Forms.TextBox();
            this.StatisticsBox = new System.Windows.Forms.GroupBox();
            this.StartStopButton = new System.Windows.Forms.Button();
            this.TimerStatisticsUpdate = new System.Windows.Forms.Timer(this.components);
            this.TimerStartStopButton = new System.Windows.Forms.Timer(this.components);
            this.SettingsBox = new System.Windows.Forms.GroupBox();
            this.SaveMinerArgButton = new System.Windows.Forms.Button();
            this.MinerArgsLabel = new System.Windows.Forms.LinkLabel();
            this.MinerArgsTextBox = new System.Windows.Forms.TextBox();
            this.ProfileToApplyOnMinerCloseComboBox = new System.Windows.Forms.ComboBox();
            this.ProfileToApplyOnMinerStartComboBox = new System.Windows.Forms.ComboBox();
            this.ApplyAfterburnerProfileOnMinerCloseCheckBox = new System.Windows.Forms.CheckBox();
            this.ApplyAfterburnerProfileOnMinerStartCheckBox = new System.Windows.Forms.CheckBox();
            this.StartMiningOnAppStartCheckBox = new System.Windows.Forms.CheckBox();
            this.StartOnStartupCheckBox = new System.Windows.Forms.CheckBox();
            this.TheToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.VersionLabel = new System.Windows.Forms.Label();
            this.StatisticsBox.SuspendLayout();
            this.SettingsBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // MinerStatusLabel
            // 
            this.MinerStatusLabel.AutoSize = true;
            this.MinerStatusLabel.Location = new System.Drawing.Point(6, 19);
            this.MinerStatusLabel.Name = "MinerStatusLabel";
            this.MinerStatusLabel.Size = new System.Drawing.Size(41, 15);
            this.MinerStatusLabel.TabIndex = 0;
            this.MinerStatusLabel.Text = "Miner:";
            // 
            // MinerStatusTextBox
            // 
            this.MinerStatusTextBox.Enabled = false;
            this.MinerStatusTextBox.Location = new System.Drawing.Point(77, 16);
            this.MinerStatusTextBox.Name = "MinerStatusTextBox";
            this.MinerStatusTextBox.Size = new System.Drawing.Size(153, 23);
            this.MinerStatusTextBox.TabIndex = 1;
            // 
            // DurationLabel
            // 
            this.DurationLabel.AutoSize = true;
            this.DurationLabel.Location = new System.Drawing.Point(6, 48);
            this.DurationLabel.Name = "DurationLabel";
            this.DurationLabel.Size = new System.Drawing.Size(36, 15);
            this.DurationLabel.TabIndex = 2;
            this.DurationLabel.Text = "Süre: ";
            // 
            // DurationTextBox
            // 
            this.DurationTextBox.Enabled = false;
            this.DurationTextBox.Location = new System.Drawing.Point(77, 45);
            this.DurationTextBox.Name = "DurationTextBox";
            this.DurationTextBox.Size = new System.Drawing.Size(153, 23);
            this.DurationTextBox.TabIndex = 3;
            // 
            // SpeedTextBox
            // 
            this.SpeedTextBox.Enabled = false;
            this.SpeedTextBox.Location = new System.Drawing.Point(77, 74);
            this.SpeedTextBox.Name = "SpeedTextBox";
            this.SpeedTextBox.Size = new System.Drawing.Size(153, 23);
            this.SpeedTextBox.TabIndex = 4;
            // 
            // PowerTextBox
            // 
            this.PowerTextBox.Enabled = false;
            this.PowerTextBox.Location = new System.Drawing.Point(77, 104);
            this.PowerTextBox.Name = "PowerTextBox";
            this.PowerTextBox.Size = new System.Drawing.Size(153, 23);
            this.PowerTextBox.TabIndex = 5;
            // 
            // FanSpeedTextBox
            // 
            this.FanSpeedTextBox.Enabled = false;
            this.FanSpeedTextBox.Location = new System.Drawing.Point(77, 163);
            this.FanSpeedTextBox.Name = "FanSpeedTextBox";
            this.FanSpeedTextBox.Size = new System.Drawing.Size(153, 23);
            this.FanSpeedTextBox.TabIndex = 6;
            // 
            // TempTextBox
            // 
            this.TempTextBox.Enabled = false;
            this.TempTextBox.Location = new System.Drawing.Point(77, 192);
            this.TempTextBox.Name = "TempTextBox";
            this.TempTextBox.Size = new System.Drawing.Size(153, 23);
            this.TempTextBox.TabIndex = 7;
            // 
            // SpeedLabel
            // 
            this.SpeedLabel.AutoSize = true;
            this.SpeedLabel.Location = new System.Drawing.Point(6, 77);
            this.SpeedLabel.Name = "SpeedLabel";
            this.SpeedLabel.Size = new System.Drawing.Size(27, 15);
            this.SpeedLabel.TabIndex = 8;
            this.SpeedLabel.Text = "Hız:";
            // 
            // PowerLabel
            // 
            this.PowerLabel.AutoSize = true;
            this.PowerLabel.Location = new System.Drawing.Point(6, 107);
            this.PowerLabel.Name = "PowerLabel";
            this.PowerLabel.Size = new System.Drawing.Size(31, 15);
            this.PowerLabel.TabIndex = 9;
            this.PowerLabel.Text = "Güç:";
            // 
            // FanSpeedLabel
            // 
            this.FanSpeedLabel.AutoSize = true;
            this.FanSpeedLabel.Location = new System.Drawing.Point(8, 166);
            this.FanSpeedLabel.Name = "FanSpeedLabel";
            this.FanSpeedLabel.Size = new System.Drawing.Size(29, 15);
            this.FanSpeedLabel.TabIndex = 10;
            this.FanSpeedLabel.Text = "Fan:";
            // 
            // TempLabel
            // 
            this.TempLabel.AutoSize = true;
            this.TempLabel.Location = new System.Drawing.Point(8, 195);
            this.TempLabel.Name = "TempLabel";
            this.TempLabel.Size = new System.Drawing.Size(49, 15);
            this.TempLabel.TabIndex = 11;
            this.TempLabel.Text = "Sıcaklık:";
            // 
            // WarnCountTextBox
            // 
            this.WarnCountTextBox.Enabled = false;
            this.WarnCountTextBox.Location = new System.Drawing.Point(77, 221);
            this.WarnCountTextBox.Name = "WarnCountTextBox";
            this.WarnCountTextBox.Size = new System.Drawing.Size(153, 23);
            this.WarnCountTextBox.TabIndex = 12;
            // 
            // ErrorCountTextBox
            // 
            this.ErrorCountTextBox.Enabled = false;
            this.ErrorCountTextBox.Location = new System.Drawing.Point(77, 250);
            this.ErrorCountTextBox.Name = "ErrorCountTextBox";
            this.ErrorCountTextBox.Size = new System.Drawing.Size(153, 23);
            this.ErrorCountTextBox.TabIndex = 13;
            // 
            // WarnCountLabel
            // 
            this.WarnCountLabel.AutoSize = true;
            this.WarnCountLabel.Location = new System.Drawing.Point(8, 224);
            this.WarnCountLabel.Name = "WarnCountLabel";
            this.WarnCountLabel.Size = new System.Drawing.Size(50, 15);
            this.WarnCountLabel.TabIndex = 14;
            this.WarnCountLabel.Text = "Uyarılar:";
            // 
            // ErrorCountLabel
            // 
            this.ErrorCountLabel.AutoSize = true;
            this.ErrorCountLabel.Location = new System.Drawing.Point(10, 253);
            this.ErrorCountLabel.Name = "ErrorCountLabel";
            this.ErrorCountLabel.Size = new System.Drawing.Size(48, 15);
            this.ErrorCountLabel.TabIndex = 15;
            this.ErrorCountLabel.Text = "Hatalar:";
            // 
            // LastUpdatedLabel
            // 
            this.LastUpdatedLabel.AutoSize = true;
            this.LastUpdatedLabel.Location = new System.Drawing.Point(10, 291);
            this.LastUpdatedLabel.Name = "LastUpdatedLabel";
            this.LastUpdatedLabel.Size = new System.Drawing.Size(95, 15);
            this.LastUpdatedLabel.TabIndex = 16;
            this.LastUpdatedLabel.Text = "Son güncelleme:";
            // 
            // LastUpdatedText
            // 
            this.LastUpdatedText.AutoSize = true;
            this.LastUpdatedText.Location = new System.Drawing.Point(111, 291);
            this.LastUpdatedText.Name = "LastUpdatedText";
            this.LastUpdatedText.Size = new System.Drawing.Size(0, 15);
            this.LastUpdatedText.TabIndex = 17;
            // 
            // EfficiencyLabel
            // 
            this.EfficiencyLabel.AutoSize = true;
            this.EfficiencyLabel.Location = new System.Drawing.Point(6, 137);
            this.EfficiencyLabel.Name = "EfficiencyLabel";
            this.EfficiencyLabel.Size = new System.Drawing.Size(58, 15);
            this.EfficiencyLabel.TabIndex = 18;
            this.EfficiencyLabel.Text = "Verimlilik:";
            // 
            // EfficiencyTextBox
            // 
            this.EfficiencyTextBox.Enabled = false;
            this.EfficiencyTextBox.Location = new System.Drawing.Point(77, 134);
            this.EfficiencyTextBox.Name = "EfficiencyTextBox";
            this.EfficiencyTextBox.Size = new System.Drawing.Size(153, 23);
            this.EfficiencyTextBox.TabIndex = 19;
            // 
            // StatisticsBox
            // 
            this.StatisticsBox.Controls.Add(this.MinerStatusLabel);
            this.StatisticsBox.Controls.Add(this.EfficiencyTextBox);
            this.StatisticsBox.Controls.Add(this.MinerStatusTextBox);
            this.StatisticsBox.Controls.Add(this.EfficiencyLabel);
            this.StatisticsBox.Controls.Add(this.DurationLabel);
            this.StatisticsBox.Controls.Add(this.LastUpdatedText);
            this.StatisticsBox.Controls.Add(this.DurationTextBox);
            this.StatisticsBox.Controls.Add(this.LastUpdatedLabel);
            this.StatisticsBox.Controls.Add(this.SpeedTextBox);
            this.StatisticsBox.Controls.Add(this.ErrorCountLabel);
            this.StatisticsBox.Controls.Add(this.PowerTextBox);
            this.StatisticsBox.Controls.Add(this.WarnCountLabel);
            this.StatisticsBox.Controls.Add(this.FanSpeedTextBox);
            this.StatisticsBox.Controls.Add(this.ErrorCountTextBox);
            this.StatisticsBox.Controls.Add(this.TempTextBox);
            this.StatisticsBox.Controls.Add(this.WarnCountTextBox);
            this.StatisticsBox.Controls.Add(this.SpeedLabel);
            this.StatisticsBox.Controls.Add(this.TempLabel);
            this.StatisticsBox.Controls.Add(this.PowerLabel);
            this.StatisticsBox.Controls.Add(this.FanSpeedLabel);
            this.StatisticsBox.Location = new System.Drawing.Point(12, 12);
            this.StatisticsBox.Name = "StatisticsBox";
            this.StatisticsBox.Size = new System.Drawing.Size(246, 316);
            this.StatisticsBox.TabIndex = 20;
            this.StatisticsBox.TabStop = false;
            this.StatisticsBox.Text = "İstatistikler";
            // 
            // StartStopButton
            // 
            this.StartStopButton.BackgroundImage = global::TrexMinerGUI.Properties.Resources.Start_icon;
            this.StartStopButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.StartStopButton.Location = new System.Drawing.Point(265, 175);
            this.StartStopButton.Name = "StartStopButton";
            this.StartStopButton.Size = new System.Drawing.Size(33, 30);
            this.StartStopButton.TabIndex = 21;
            this.StartStopButton.UseVisualStyleBackColor = true;
            this.StartStopButton.Click += new System.EventHandler(this.StartStopButton_Click);
            // 
            // TimerStatisticsUpdate
            // 
            this.TimerStatisticsUpdate.Enabled = true;
            this.TimerStatisticsUpdate.Interval = 1000;
            this.TimerStatisticsUpdate.Tick += new System.EventHandler(this.UpdateStatistics);
            // 
            // TimerStartStopButton
            // 
            this.TimerStartStopButton.Enabled = true;
            this.TimerStartStopButton.Tick += new System.EventHandler(this.TimerStartStopButton_Tick);
            // 
            // SettingsBox
            // 
            this.SettingsBox.Controls.Add(this.SaveMinerArgButton);
            this.SettingsBox.Controls.Add(this.MinerArgsLabel);
            this.SettingsBox.Controls.Add(this.MinerArgsTextBox);
            this.SettingsBox.Controls.Add(this.ProfileToApplyOnMinerCloseComboBox);
            this.SettingsBox.Controls.Add(this.ProfileToApplyOnMinerStartComboBox);
            this.SettingsBox.Controls.Add(this.ApplyAfterburnerProfileOnMinerCloseCheckBox);
            this.SettingsBox.Controls.Add(this.ApplyAfterburnerProfileOnMinerStartCheckBox);
            this.SettingsBox.Controls.Add(this.StartMiningOnAppStartCheckBox);
            this.SettingsBox.Controls.Add(this.StartOnStartupCheckBox);
            this.SettingsBox.Location = new System.Drawing.Point(264, 12);
            this.SettingsBox.Name = "SettingsBox";
            this.SettingsBox.Size = new System.Drawing.Size(392, 157);
            this.SettingsBox.TabIndex = 22;
            this.SettingsBox.TabStop = false;
            this.SettingsBox.Text = "Ayarlar";
            // 
            // SaveMinerArgButton
            // 
            this.SaveMinerArgButton.BackgroundImage = global::TrexMinerGUI.Properties.Resources.save;
            this.SaveMinerArgButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SaveMinerArgButton.Location = new System.Drawing.Point(361, 123);
            this.SaveMinerArgButton.Name = "SaveMinerArgButton";
            this.SaveMinerArgButton.Size = new System.Drawing.Size(25, 23);
            this.SaveMinerArgButton.TabIndex = 17;
            this.SaveMinerArgButton.UseVisualStyleBackColor = true;
            this.SaveMinerArgButton.Click += new System.EventHandler(this.SaveMinerArg);
            // 
            // MinerArgsLabel
            // 
            this.MinerArgsLabel.AutoSize = true;
            this.MinerArgsLabel.Location = new System.Drawing.Point(1, 126);
            this.MinerArgsLabel.Name = "MinerArgsLabel";
            this.MinerArgsLabel.Size = new System.Drawing.Size(63, 15);
            this.MinerArgsLabel.TabIndex = 16;
            this.MinerArgsLabel.TabStop = true;
            this.MinerArgsLabel.Text = "Miner Arg:";
            this.MinerArgsLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.MinerArgsLabel_LinkClicked);
            // 
            // MinerArgsTextBox
            // 
            this.MinerArgsTextBox.Location = new System.Drawing.Point(70, 123);
            this.MinerArgsTextBox.Name = "MinerArgsTextBox";
            this.MinerArgsTextBox.Size = new System.Drawing.Size(285, 23);
            this.MinerArgsTextBox.TabIndex = 15;
            this.MinerArgsTextBox.TextChanged += new System.EventHandler(this.MinerArgsTextBox_TextChanged);
            // 
            // ProfileToApplyOnMinerCloseComboBox
            // 
            this.ProfileToApplyOnMinerCloseComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProfileToApplyOnMinerCloseComboBox.FormattingEnabled = true;
            this.ProfileToApplyOnMinerCloseComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.ProfileToApplyOnMinerCloseComboBox.Location = new System.Drawing.Point(284, 94);
            this.ProfileToApplyOnMinerCloseComboBox.Name = "ProfileToApplyOnMinerCloseComboBox";
            this.ProfileToApplyOnMinerCloseComboBox.Size = new System.Drawing.Size(82, 23);
            this.ProfileToApplyOnMinerCloseComboBox.TabIndex = 14;
            this.ProfileToApplyOnMinerCloseComboBox.TextChanged += new System.EventHandler(this.ProfileToApplyOnMinerCloseComboBox_TextChanged);
            // 
            // ProfileToApplyOnMinerStartComboBox
            // 
            this.ProfileToApplyOnMinerStartComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProfileToApplyOnMinerStartComboBox.FormattingEnabled = true;
            this.ProfileToApplyOnMinerStartComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.ProfileToApplyOnMinerStartComboBox.Location = new System.Drawing.Point(271, 68);
            this.ProfileToApplyOnMinerStartComboBox.Name = "ProfileToApplyOnMinerStartComboBox";
            this.ProfileToApplyOnMinerStartComboBox.Size = new System.Drawing.Size(82, 23);
            this.ProfileToApplyOnMinerStartComboBox.TabIndex = 13;
            this.ProfileToApplyOnMinerStartComboBox.TextChanged += new System.EventHandler(this.ProfileToApplyOnMinerStartComboBox_TextChanged);
            // 
            // ApplyAfterburnerProfileOnMinerCloseCheckBox
            // 
            this.ApplyAfterburnerProfileOnMinerCloseCheckBox.AutoSize = true;
            this.ApplyAfterburnerProfileOnMinerCloseCheckBox.Location = new System.Drawing.Point(6, 96);
            this.ApplyAfterburnerProfileOnMinerCloseCheckBox.Name = "ApplyAfterburnerProfileOnMinerCloseCheckBox";
            this.ApplyAfterburnerProfileOnMinerCloseCheckBox.Size = new System.Drawing.Size(272, 19);
            this.ApplyAfterburnerProfileOnMinerCloseCheckBox.TabIndex = 12;
            this.ApplyAfterburnerProfileOnMinerCloseCheckBox.Text = "Miner kapandığında Afterburner profili uygula:";
            this.ApplyAfterburnerProfileOnMinerCloseCheckBox.UseVisualStyleBackColor = true;
            this.ApplyAfterburnerProfileOnMinerCloseCheckBox.CheckedChanged += new System.EventHandler(this.ApplyAfterburnerProfileOnMinerCloseCheckBox_CheckedChanged);
            // 
            // ApplyAfterburnerProfileOnMinerStartCheckBox
            // 
            this.ApplyAfterburnerProfileOnMinerStartCheckBox.AutoSize = true;
            this.ApplyAfterburnerProfileOnMinerStartCheckBox.Location = new System.Drawing.Point(6, 70);
            this.ApplyAfterburnerProfileOnMinerStartCheckBox.Name = "ApplyAfterburnerProfileOnMinerStartCheckBox";
            this.ApplyAfterburnerProfileOnMinerStartCheckBox.Size = new System.Drawing.Size(258, 19);
            this.ApplyAfterburnerProfileOnMinerStartCheckBox.TabIndex = 11;
            this.ApplyAfterburnerProfileOnMinerStartCheckBox.Text = "Miner açıldığında Afterburner profili uygula:";
            this.ApplyAfterburnerProfileOnMinerStartCheckBox.UseVisualStyleBackColor = true;
            this.ApplyAfterburnerProfileOnMinerStartCheckBox.CheckedChanged += new System.EventHandler(this.ApplyAfterburnerProfileOnMinerStartCheckBox_CheckedChanged);
            // 
            // StartMiningOnAppStartCheckBox
            // 
            this.StartMiningOnAppStartCheckBox.AutoSize = true;
            this.StartMiningOnAppStartCheckBox.Location = new System.Drawing.Point(6, 43);
            this.StartMiningOnAppStartCheckBox.Name = "StartMiningOnAppStartCheckBox";
            this.StartMiningOnAppStartCheckBox.Size = new System.Drawing.Size(225, 19);
            this.StartMiningOnAppStartCheckBox.TabIndex = 10;
            this.StartMiningOnAppStartCheckBox.Text = "Program başlangıcında miner\'ı çalıştır";
            this.StartMiningOnAppStartCheckBox.UseVisualStyleBackColor = true;
            this.StartMiningOnAppStartCheckBox.CheckedChanged += new System.EventHandler(this.StartMiningOnAppStart_CheckedChanged);
            // 
            // StartOnStartupCheckBox
            // 
            this.StartOnStartupCheckBox.AutoSize = true;
            this.StartOnStartupCheckBox.Location = new System.Drawing.Point(6, 18);
            this.StartOnStartupCheckBox.Name = "StartOnStartupCheckBox";
            this.StartOnStartupCheckBox.Size = new System.Drawing.Size(218, 19);
            this.StartOnStartupCheckBox.TabIndex = 9;
            this.StartOnStartupCheckBox.Text = "Windows başlangıcında programı aç";
            this.StartOnStartupCheckBox.UseVisualStyleBackColor = true;
            this.StartOnStartupCheckBox.CheckedChanged += new System.EventHandler(this.StartOnStartupCheckBox_CheckedChanged);
            // 
            // VersionLabel
            // 
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.Location = new System.Drawing.Point(617, 314);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(45, 15);
            this.VersionLabel.TabIndex = 23;
            this.VersionLabel.Text = "Version";
            // 
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 341);
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.SettingsBox);
            this.Controls.Add(this.StartStopButton);
            this.Controls.Add(this.StatisticsBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "StatisticsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TrexMinerGUI";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Shown += new System.EventHandler(this.UpdateStatistics);
            this.StatisticsBox.ResumeLayout(false);
            this.StatisticsBox.PerformLayout();
            this.SettingsBox.ResumeLayout(false);
            this.SettingsBox.PerformLayout();
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
        private System.Windows.Forms.TextBox WarnCountTextBox;
        private System.Windows.Forms.TextBox ErrorCountTextBox;
        private System.Windows.Forms.Label WarnCountLabel;
        private System.Windows.Forms.Label ErrorCountLabel;
        private System.Windows.Forms.Label LastUpdatedLabel;
        private System.Windows.Forms.Label LastUpdatedText;
        private System.Windows.Forms.Label EfficiencyLabel;
        private System.Windows.Forms.TextBox EfficiencyTextBox;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.GroupBox StatisticsBox;
        private System.Windows.Forms.Button StartStopButton;
        private System.Windows.Forms.Timer TimerStatisticsUpdate;
        private System.Windows.Forms.Timer TimerStartStopButton;
        private System.Windows.Forms.GroupBox SettingsBox;
        private System.Windows.Forms.LinkLabel MinerArgsLabel;
        private System.Windows.Forms.TextBox MinerArgsTextBox;
        private System.Windows.Forms.ComboBox ProfileToApplyOnMinerCloseComboBox;
        private System.Windows.Forms.ComboBox ProfileToApplyOnMinerStartComboBox;
        private System.Windows.Forms.CheckBox ApplyAfterburnerProfileOnMinerCloseCheckBox;
        private System.Windows.Forms.CheckBox ApplyAfterburnerProfileOnMinerStartCheckBox;
        private System.Windows.Forms.CheckBox StartMiningOnAppStartCheckBox;
        private System.Windows.Forms.CheckBox StartOnStartupCheckBox;
        private System.Windows.Forms.Button SaveMinerArgButton;
        private System.Windows.Forms.ToolTip TheToolTip;
        private System.Windows.Forms.Label VersionLabel;
    }
}