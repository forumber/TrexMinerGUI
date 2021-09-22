
namespace TrexMinerGUI.Forms
{
    partial class GPUTuningForm
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
            this.ProfileToApplyOnMinerCloseComboBox = new System.Windows.Forms.ComboBox();
            this.ProfileToApplyOnMinerStartComboBox = new System.Windows.Forms.ComboBox();
            this.ApplyAfterburnerProfileOnMinerCloseCheckBox = new System.Windows.Forms.CheckBox();
            this.ApplyAfterburnerProfileOnMinerStartCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
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
            this.ProfileToApplyOnMinerCloseComboBox.Location = new System.Drawing.Point(290, 36);
            this.ProfileToApplyOnMinerCloseComboBox.Name = "ProfileToApplyOnMinerCloseComboBox";
            this.ProfileToApplyOnMinerCloseComboBox.Size = new System.Drawing.Size(82, 23);
            this.ProfileToApplyOnMinerCloseComboBox.TabIndex = 18;
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
            this.ProfileToApplyOnMinerStartComboBox.Location = new System.Drawing.Point(290, 10);
            this.ProfileToApplyOnMinerStartComboBox.Name = "ProfileToApplyOnMinerStartComboBox";
            this.ProfileToApplyOnMinerStartComboBox.Size = new System.Drawing.Size(82, 23);
            this.ProfileToApplyOnMinerStartComboBox.TabIndex = 17;
            this.ProfileToApplyOnMinerStartComboBox.TextChanged += new System.EventHandler(this.ProfileToApplyOnMinerStartComboBox_TextChanged);
            // 
            // ApplyAfterburnerProfileOnMinerCloseCheckBox
            // 
            this.ApplyAfterburnerProfileOnMinerCloseCheckBox.AutoSize = true;
            this.ApplyAfterburnerProfileOnMinerCloseCheckBox.Location = new System.Drawing.Point(12, 38);
            this.ApplyAfterburnerProfileOnMinerCloseCheckBox.Name = "ApplyAfterburnerProfileOnMinerCloseCheckBox";
            this.ApplyAfterburnerProfileOnMinerCloseCheckBox.Size = new System.Drawing.Size(258, 19);
            this.ApplyAfterburnerProfileOnMinerCloseCheckBox.TabIndex = 16;
            this.ApplyAfterburnerProfileOnMinerCloseCheckBox.Text = "Apply Afterburner profile when miner stops:";
            this.ApplyAfterburnerProfileOnMinerCloseCheckBox.UseVisualStyleBackColor = true;
            this.ApplyAfterburnerProfileOnMinerCloseCheckBox.CheckedChanged += new System.EventHandler(this.ApplyAfterburnerProfileOnMinerCloseCheckBox_CheckedChanged);
            // 
            // ApplyAfterburnerProfileOnMinerStartCheckBox
            // 
            this.ApplyAfterburnerProfileOnMinerStartCheckBox.AutoSize = true;
            this.ApplyAfterburnerProfileOnMinerStartCheckBox.Location = new System.Drawing.Point(12, 12);
            this.ApplyAfterburnerProfileOnMinerStartCheckBox.Name = "ApplyAfterburnerProfileOnMinerStartCheckBox";
            this.ApplyAfterburnerProfileOnMinerStartCheckBox.Size = new System.Drawing.Size(258, 19);
            this.ApplyAfterburnerProfileOnMinerStartCheckBox.TabIndex = 15;
            this.ApplyAfterburnerProfileOnMinerStartCheckBox.Text = "Apply Afterburner profile when miner starts:";
            this.ApplyAfterburnerProfileOnMinerStartCheckBox.UseVisualStyleBackColor = true;
            this.ApplyAfterburnerProfileOnMinerStartCheckBox.CheckedChanged += new System.EventHandler(this.ApplyAfterburnerProfileOnMinerStartCheckBox_CheckedChanged);
            // 
            // GPUTuningForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 68);
            this.Controls.Add(this.ProfileToApplyOnMinerCloseComboBox);
            this.Controls.Add(this.ProfileToApplyOnMinerStartComboBox);
            this.Controls.Add(this.ApplyAfterburnerProfileOnMinerCloseCheckBox);
            this.Controls.Add(this.ApplyAfterburnerProfileOnMinerStartCheckBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "GPUTuningForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GPU Tuning Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ProfileToApplyOnMinerCloseComboBox;
        private System.Windows.Forms.ComboBox ProfileToApplyOnMinerStartComboBox;
        private System.Windows.Forms.CheckBox ApplyAfterburnerProfileOnMinerCloseCheckBox;
        private System.Windows.Forms.CheckBox ApplyAfterburnerProfileOnMinerStartCheckBox;
    }
}