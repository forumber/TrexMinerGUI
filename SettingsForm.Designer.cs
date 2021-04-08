
using TrexMinerGUI.Properties;

namespace TrexMinerGUI
{
    partial class SettingsForm
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
            this.StartOnStartupCheckBox = new System.Windows.Forms.CheckBox();
            this.StartMiningOnAppStartCheckBox = new System.Windows.Forms.CheckBox();
            this.ApplyAfterburnerProfileOnMinerStartCheckBox = new System.Windows.Forms.CheckBox();
            this.ApplyAfterburnerProfileOnMinerCloseCheckBox = new System.Windows.Forms.CheckBox();
            this.ProfileToApplyOnMinerStartComboBox = new System.Windows.Forms.ComboBox();
            this.ProfileToApplyOnMinerCloseComboBox = new System.Windows.Forms.ComboBox();
            this.MinerArgsTextBox = new System.Windows.Forms.TextBox();
            this.MinerArgsLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // StartOnStartupCheckBox
            // 
            this.StartOnStartupCheckBox.AutoSize = true;
            this.StartOnStartupCheckBox.Location = new System.Drawing.Point(12, 12);
            this.StartOnStartupCheckBox.Name = "StartOnStartupCheckBox";
            this.StartOnStartupCheckBox.Size = new System.Drawing.Size(218, 19);
            this.StartOnStartupCheckBox.TabIndex = 0;
            this.StartOnStartupCheckBox.Text = "Windows başlangıcında programı aç";
            this.StartOnStartupCheckBox.UseVisualStyleBackColor = true;
            // 
            // StartMiningOnAppStartCheckBox
            // 
            this.StartMiningOnAppStartCheckBox.AutoSize = true;
            this.StartMiningOnAppStartCheckBox.Location = new System.Drawing.Point(12, 37);
            this.StartMiningOnAppStartCheckBox.Name = "StartMiningOnAppStartCheckBox";
            this.StartMiningOnAppStartCheckBox.Size = new System.Drawing.Size(225, 19);
            this.StartMiningOnAppStartCheckBox.TabIndex = 1;
            this.StartMiningOnAppStartCheckBox.Text = "Program başlangıcında miner\'ı çalıştır";
            this.StartMiningOnAppStartCheckBox.UseVisualStyleBackColor = true;
            // 
            // ApplyAfterburnerProfileOnMinerStartCheckBox
            // 
            this.ApplyAfterburnerProfileOnMinerStartCheckBox.AutoSize = true;
            this.ApplyAfterburnerProfileOnMinerStartCheckBox.Location = new System.Drawing.Point(12, 64);
            this.ApplyAfterburnerProfileOnMinerStartCheckBox.Name = "ApplyAfterburnerProfileOnMinerStartCheckBox";
            this.ApplyAfterburnerProfileOnMinerStartCheckBox.Size = new System.Drawing.Size(258, 19);
            this.ApplyAfterburnerProfileOnMinerStartCheckBox.TabIndex = 2;
            this.ApplyAfterburnerProfileOnMinerStartCheckBox.Text = "Miner açıldığında Afterburner profili uygula:";
            this.ApplyAfterburnerProfileOnMinerStartCheckBox.UseVisualStyleBackColor = true;
            // 
            // ApplyAfterburnerProfileOnMinerCloseCheckBox
            // 
            this.ApplyAfterburnerProfileOnMinerCloseCheckBox.AutoSize = true;
            this.ApplyAfterburnerProfileOnMinerCloseCheckBox.Location = new System.Drawing.Point(12, 90);
            this.ApplyAfterburnerProfileOnMinerCloseCheckBox.Name = "ApplyAfterburnerProfileOnMinerCloseCheckBox";
            this.ApplyAfterburnerProfileOnMinerCloseCheckBox.Size = new System.Drawing.Size(272, 19);
            this.ApplyAfterburnerProfileOnMinerCloseCheckBox.TabIndex = 3;
            this.ApplyAfterburnerProfileOnMinerCloseCheckBox.Text = "Miner kapandığında Afterburner profili uygula:";
            this.ApplyAfterburnerProfileOnMinerCloseCheckBox.UseVisualStyleBackColor = true;
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
            this.ProfileToApplyOnMinerStartComboBox.Location = new System.Drawing.Point(277, 62);
            this.ProfileToApplyOnMinerStartComboBox.Name = "ProfileToApplyOnMinerStartComboBox";
            this.ProfileToApplyOnMinerStartComboBox.Size = new System.Drawing.Size(82, 23);
            this.ProfileToApplyOnMinerStartComboBox.TabIndex = 4;
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
            this.ProfileToApplyOnMinerCloseComboBox.Location = new System.Drawing.Point(290, 88);
            this.ProfileToApplyOnMinerCloseComboBox.Name = "ProfileToApplyOnMinerCloseComboBox";
            this.ProfileToApplyOnMinerCloseComboBox.Size = new System.Drawing.Size(82, 23);
            this.ProfileToApplyOnMinerCloseComboBox.TabIndex = 5;
            // 
            // MinerArgsTextBox
            // 
            this.MinerArgsTextBox.Location = new System.Drawing.Point(76, 117);
            this.MinerArgsTextBox.Name = "MinerArgsTextBox";
            this.MinerArgsTextBox.Size = new System.Drawing.Size(308, 23);
            this.MinerArgsTextBox.TabIndex = 7;
            // 
            // MinerArgsLabel
            // 
            this.MinerArgsLabel.AutoSize = true;
            this.MinerArgsLabel.Location = new System.Drawing.Point(7, 120);
            this.MinerArgsLabel.Name = "MinerArgsLabel";
            this.MinerArgsLabel.Size = new System.Drawing.Size(63, 15);
            this.MinerArgsLabel.TabIndex = 8;
            this.MinerArgsLabel.TabStop = true;
            this.MinerArgsLabel.Text = "Miner Arg:";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 151);
            this.Controls.Add(this.MinerArgsLabel);
            this.Controls.Add(this.MinerArgsTextBox);
            this.Controls.Add(this.ProfileToApplyOnMinerCloseComboBox);
            this.Controls.Add(this.ProfileToApplyOnMinerStartComboBox);
            this.Controls.Add(this.ApplyAfterburnerProfileOnMinerCloseCheckBox);
            this.Controls.Add(this.ApplyAfterburnerProfileOnMinerStartCheckBox);
            this.Controls.Add(this.StartMiningOnAppStartCheckBox);
            this.Controls.Add(this.StartOnStartupCheckBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ayarlar";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.CheckBox StartOnStartupCheckBox;
        private System.Windows.Forms.CheckBox StartMiningOnAppStartCheckBox;
        private System.Windows.Forms.CheckBox ApplyAfterburnerProfileOnMinerStartCheckBox;
        private System.Windows.Forms.CheckBox ApplyAfterburnerProfileOnMinerCloseCheckBox;
        private System.Windows.Forms.ComboBox ProfileToApplyOnMinerStartComboBox;
        private System.Windows.Forms.ComboBox ProfileToApplyOnMinerCloseComboBox;
        private System.Windows.Forms.TextBox MinerArgsTextBox;
        private System.Windows.Forms.LinkLabel MinerArgsLabel;
    }
}