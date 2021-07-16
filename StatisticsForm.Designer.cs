
using TrexMinerGUI.Properties;

namespace TrexMinerGUI
{
    partial class StatisticsForm
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
            this.TimerStatisticsUpdate = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // MinerStatusLabel
            // 
            this.MinerStatusLabel.AutoSize = true;
            this.MinerStatusLabel.Location = new System.Drawing.Point(12, 21);
            this.MinerStatusLabel.Name = "MinerStatusLabel";
            this.MinerStatusLabel.Size = new System.Drawing.Size(41, 15);
            this.MinerStatusLabel.TabIndex = 0;
            this.MinerStatusLabel.Text = "Miner:";
            // 
            // MinerStatusTextBox
            // 
            this.MinerStatusTextBox.Enabled = false;
            this.MinerStatusTextBox.Location = new System.Drawing.Point(83, 18);
            this.MinerStatusTextBox.Name = "MinerStatusTextBox";
            this.MinerStatusTextBox.Size = new System.Drawing.Size(153, 23);
            this.MinerStatusTextBox.TabIndex = 1;
            // 
            // DurationLabel
            // 
            this.DurationLabel.AutoSize = true;
            this.DurationLabel.Location = new System.Drawing.Point(12, 50);
            this.DurationLabel.Name = "DurationLabel";
            this.DurationLabel.Size = new System.Drawing.Size(36, 15);
            this.DurationLabel.TabIndex = 2;
            this.DurationLabel.Text = "Süre: ";
            // 
            // DurationTextBox
            // 
            this.DurationTextBox.Enabled = false;
            this.DurationTextBox.Location = new System.Drawing.Point(83, 47);
            this.DurationTextBox.Name = "DurationTextBox";
            this.DurationTextBox.Size = new System.Drawing.Size(153, 23);
            this.DurationTextBox.TabIndex = 3;
            // 
            // SpeedTextBox
            // 
            this.SpeedTextBox.Enabled = false;
            this.SpeedTextBox.Location = new System.Drawing.Point(83, 76);
            this.SpeedTextBox.Name = "SpeedTextBox";
            this.SpeedTextBox.Size = new System.Drawing.Size(153, 23);
            this.SpeedTextBox.TabIndex = 4;
            // 
            // PowerTextBox
            // 
            this.PowerTextBox.Enabled = false;
            this.PowerTextBox.Location = new System.Drawing.Point(83, 106);
            this.PowerTextBox.Name = "PowerTextBox";
            this.PowerTextBox.Size = new System.Drawing.Size(153, 23);
            this.PowerTextBox.TabIndex = 5;
            // 
            // FanSpeedTextBox
            // 
            this.FanSpeedTextBox.Enabled = false;
            this.FanSpeedTextBox.Location = new System.Drawing.Point(83, 165);
            this.FanSpeedTextBox.Name = "FanSpeedTextBox";
            this.FanSpeedTextBox.Size = new System.Drawing.Size(153, 23);
            this.FanSpeedTextBox.TabIndex = 6;
            // 
            // TempTextBox
            // 
            this.TempTextBox.Enabled = false;
            this.TempTextBox.Location = new System.Drawing.Point(83, 194);
            this.TempTextBox.Name = "TempTextBox";
            this.TempTextBox.Size = new System.Drawing.Size(153, 23);
            this.TempTextBox.TabIndex = 7;
            // 
            // SpeedLabel
            // 
            this.SpeedLabel.AutoSize = true;
            this.SpeedLabel.Location = new System.Drawing.Point(12, 79);
            this.SpeedLabel.Name = "SpeedLabel";
            this.SpeedLabel.Size = new System.Drawing.Size(27, 15);
            this.SpeedLabel.TabIndex = 8;
            this.SpeedLabel.Text = "Hız:";
            // 
            // PowerLabel
            // 
            this.PowerLabel.AutoSize = true;
            this.PowerLabel.Location = new System.Drawing.Point(12, 109);
            this.PowerLabel.Name = "PowerLabel";
            this.PowerLabel.Size = new System.Drawing.Size(31, 15);
            this.PowerLabel.TabIndex = 9;
            this.PowerLabel.Text = "Güç:";
            // 
            // FanSpeedLabel
            // 
            this.FanSpeedLabel.AutoSize = true;
            this.FanSpeedLabel.Location = new System.Drawing.Point(14, 168);
            this.FanSpeedLabel.Name = "FanSpeedLabel";
            this.FanSpeedLabel.Size = new System.Drawing.Size(29, 15);
            this.FanSpeedLabel.TabIndex = 10;
            this.FanSpeedLabel.Text = "Fan:";
            // 
            // TempLabel
            // 
            this.TempLabel.AutoSize = true;
            this.TempLabel.Location = new System.Drawing.Point(14, 197);
            this.TempLabel.Name = "TempLabel";
            this.TempLabel.Size = new System.Drawing.Size(49, 15);
            this.TempLabel.TabIndex = 11;
            this.TempLabel.Text = "Sıcaklık:";
            // 
            // WarnCountTextBox
            // 
            this.WarnCountTextBox.Enabled = false;
            this.WarnCountTextBox.Location = new System.Drawing.Point(83, 223);
            this.WarnCountTextBox.Name = "WarnCountTextBox";
            this.WarnCountTextBox.Size = new System.Drawing.Size(153, 23);
            this.WarnCountTextBox.TabIndex = 12;
            // 
            // ErrorCountTextBox
            // 
            this.ErrorCountTextBox.Enabled = false;
            this.ErrorCountTextBox.Location = new System.Drawing.Point(83, 252);
            this.ErrorCountTextBox.Name = "ErrorCountTextBox";
            this.ErrorCountTextBox.Size = new System.Drawing.Size(153, 23);
            this.ErrorCountTextBox.TabIndex = 13;
            // 
            // WarnCountLabel
            // 
            this.WarnCountLabel.AutoSize = true;
            this.WarnCountLabel.Location = new System.Drawing.Point(14, 226);
            this.WarnCountLabel.Name = "WarnCountLabel";
            this.WarnCountLabel.Size = new System.Drawing.Size(50, 15);
            this.WarnCountLabel.TabIndex = 14;
            this.WarnCountLabel.Text = "Uyarılar:";
            // 
            // ErrorCountLabel
            // 
            this.ErrorCountLabel.AutoSize = true;
            this.ErrorCountLabel.Location = new System.Drawing.Point(16, 255);
            this.ErrorCountLabel.Name = "ErrorCountLabel";
            this.ErrorCountLabel.Size = new System.Drawing.Size(48, 15);
            this.ErrorCountLabel.TabIndex = 15;
            this.ErrorCountLabel.Text = "Hatalar:";
            // 
            // LastUpdatedLabel
            // 
            this.LastUpdatedLabel.AutoSize = true;
            this.LastUpdatedLabel.Location = new System.Drawing.Point(16, 293);
            this.LastUpdatedLabel.Name = "LastUpdatedLabel";
            this.LastUpdatedLabel.Size = new System.Drawing.Size(95, 15);
            this.LastUpdatedLabel.TabIndex = 16;
            this.LastUpdatedLabel.Text = "Son güncelleme:";
            // 
            // LastUpdatedText
            // 
            this.LastUpdatedText.AutoSize = true;
            this.LastUpdatedText.Location = new System.Drawing.Point(117, 293);
            this.LastUpdatedText.Name = "LastUpdatedText";
            this.LastUpdatedText.Size = new System.Drawing.Size(95, 15);
            this.LastUpdatedText.TabIndex = 17;
            // 
            // EfficiencyLabel
            // 
            this.EfficiencyLabel.AutoSize = true;
            this.EfficiencyLabel.Location = new System.Drawing.Point(12, 139);
            this.EfficiencyLabel.Name = "EfficiencyLabel";
            this.EfficiencyLabel.Size = new System.Drawing.Size(58, 15);
            this.EfficiencyLabel.TabIndex = 18;
            this.EfficiencyLabel.Text = "Verimlilik:";
            // 
            // EfficiencyTextBox
            // 
            this.EfficiencyTextBox.Enabled = false;
            this.EfficiencyTextBox.Location = new System.Drawing.Point(83, 136);
            this.EfficiencyTextBox.Name = "EfficiencyTextBox";
            this.EfficiencyTextBox.Size = new System.Drawing.Size(153, 23);
            this.EfficiencyTextBox.TabIndex = 19;
            // 
            // 
            // TimerStatisticsUpdate
            // 
            this.TimerStatisticsUpdate.Enabled = true;
            this.TimerStatisticsUpdate.Interval = 1000;
            this.TimerStatisticsUpdate.Tick += new System.EventHandler(this.UpdateStatistics);
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 322);
            this.Controls.Add(this.EfficiencyTextBox);
            this.Controls.Add(this.EfficiencyLabel);
            this.Controls.Add(this.LastUpdatedText);
            this.Controls.Add(this.LastUpdatedLabel);
            this.Controls.Add(this.ErrorCountLabel);
            this.Controls.Add(this.WarnCountLabel);
            this.Controls.Add(this.ErrorCountTextBox);
            this.Controls.Add(this.WarnCountTextBox);
            this.Controls.Add(this.TempLabel);
            this.Controls.Add(this.FanSpeedLabel);
            this.Controls.Add(this.PowerLabel);
            this.Controls.Add(this.SpeedLabel);
            this.Controls.Add(this.TempTextBox);
            this.Controls.Add(this.FanSpeedTextBox);
            this.Controls.Add(this.PowerTextBox);
            this.Controls.Add(this.SpeedTextBox);
            this.Controls.Add(this.DurationTextBox);
            this.Controls.Add(this.DurationLabel);
            this.Controls.Add(this.MinerStatusTextBox);
            this.Controls.Add(this.MinerStatusLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "StatisticsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "İstatistikler";
            this.Shown += new System.EventHandler(this.UpdateStatistics);
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
        private System.Windows.Forms.Timer TimerStatisticsUpdate;
    }
}