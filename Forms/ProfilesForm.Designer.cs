
namespace TrexMinerGUI.Forms
{
    partial class ProfilesForm
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
            this.MinerArgsLabel = new System.Windows.Forms.LinkLabel();
            this.MinerArgsTextBox = new System.Windows.Forms.TextBox();
            this.SelectedProfileGroupBox = new System.Windows.Forms.GroupBox();
            this.SaveCurrentProfileButton = new System.Windows.Forms.Button();
            this.EditMinerArgsButton = new System.Windows.Forms.Button();
            this.ProfileNameTextBox = new System.Windows.Forms.TextBox();
            this.ProfileNameLabel = new System.Windows.Forms.Label();
            this.ProfileToApplyOnMinerCloseComboBox = new System.Windows.Forms.ComboBox();
            this.ProfileToApplyOnMinerStartComboBox = new System.Windows.Forms.ComboBox();
            this.ApplyAfterburnerProfileOnMinerCloseCheckBox = new System.Windows.Forms.CheckBox();
            this.ApplyAfterburnerProfileOnMinerStartCheckBox = new System.Windows.Forms.CheckBox();
            this.ProfileComboBox = new System.Windows.Forms.ComboBox();
            this.ProfileLabel = new System.Windows.Forms.Label();
            this.CreateProfileButton = new System.Windows.Forms.Button();
            this.DeleteCurrentProfileButton = new System.Windows.Forms.Button();
            this.SelectedProfileGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // MinerArgsLabel
            // 
            this.MinerArgsLabel.AutoSize = true;
            this.MinerArgsLabel.Location = new System.Drawing.Point(6, 48);
            this.MinerArgsLabel.Name = "MinerArgsLabel";
            this.MinerArgsLabel.Size = new System.Drawing.Size(63, 15);
            this.MinerArgsLabel.TabIndex = 19;
            this.MinerArgsLabel.TabStop = true;
            this.MinerArgsLabel.Text = "Miner Arg:";
            this.MinerArgsLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.MinerArgsLabel_LinkClicked);
            // 
            // MinerArgsTextBox
            // 
            this.MinerArgsTextBox.Enabled = false;
            this.MinerArgsTextBox.Location = new System.Drawing.Point(76, 45);
            this.MinerArgsTextBox.Name = "MinerArgsTextBox";
            this.MinerArgsTextBox.Size = new System.Drawing.Size(260, 23);
            this.MinerArgsTextBox.TabIndex = 18;
            this.MinerArgsTextBox.TextChanged += new System.EventHandler(this.MinerArgsTextBox_TextChanged);
            // 
            // SelectedProfileGroupBox
            // 
            this.SelectedProfileGroupBox.Controls.Add(this.SaveCurrentProfileButton);
            this.SelectedProfileGroupBox.Controls.Add(this.EditMinerArgsButton);
            this.SelectedProfileGroupBox.Controls.Add(this.ProfileNameTextBox);
            this.SelectedProfileGroupBox.Controls.Add(this.ProfileNameLabel);
            this.SelectedProfileGroupBox.Controls.Add(this.ProfileToApplyOnMinerCloseComboBox);
            this.SelectedProfileGroupBox.Controls.Add(this.ProfileToApplyOnMinerStartComboBox);
            this.SelectedProfileGroupBox.Controls.Add(this.ApplyAfterburnerProfileOnMinerCloseCheckBox);
            this.SelectedProfileGroupBox.Controls.Add(this.ApplyAfterburnerProfileOnMinerStartCheckBox);
            this.SelectedProfileGroupBox.Controls.Add(this.MinerArgsLabel);
            this.SelectedProfileGroupBox.Controls.Add(this.MinerArgsTextBox);
            this.SelectedProfileGroupBox.Location = new System.Drawing.Point(12, 45);
            this.SelectedProfileGroupBox.Name = "SelectedProfileGroupBox";
            this.SelectedProfileGroupBox.Size = new System.Drawing.Size(381, 165);
            this.SelectedProfileGroupBox.TabIndex = 21;
            this.SelectedProfileGroupBox.TabStop = false;
            this.SelectedProfileGroupBox.Text = "Selected Profile";
            // 
            // SaveCurrentProfileButton
            // 
            this.SaveCurrentProfileButton.Location = new System.Drawing.Point(7, 136);
            this.SaveCurrentProfileButton.Name = "SaveCurrentProfileButton";
            this.SaveCurrentProfileButton.Size = new System.Drawing.Size(360, 23);
            this.SaveCurrentProfileButton.TabIndex = 27;
            this.SaveCurrentProfileButton.Text = "Save";
            this.SaveCurrentProfileButton.UseVisualStyleBackColor = true;
            this.SaveCurrentProfileButton.Click += new System.EventHandler(this.SaveCurrrentProfileButton_Click);
            // 
            // EditMinerArgsButton
            // 
            this.EditMinerArgsButton.Location = new System.Drawing.Point(342, 45);
            this.EditMinerArgsButton.Name = "EditMinerArgsButton";
            this.EditMinerArgsButton.Size = new System.Drawing.Size(25, 23);
            this.EditMinerArgsButton.TabIndex = 26;
            this.EditMinerArgsButton.Text = "...";
            this.EditMinerArgsButton.UseVisualStyleBackColor = true;
            this.EditMinerArgsButton.Click += new System.EventHandler(this.EditMinerArgsButton_Click);
            // 
            // ProfileNameTextBox
            // 
            this.ProfileNameTextBox.Location = new System.Drawing.Point(91, 16);
            this.ProfileNameTextBox.Name = "ProfileNameTextBox";
            this.ProfileNameTextBox.Size = new System.Drawing.Size(275, 23);
            this.ProfileNameTextBox.TabIndex = 25;
            this.ProfileNameTextBox.TextChanged += new System.EventHandler(this.ChangePropStatus);
            // 
            // ProfileNameLabel
            // 
            this.ProfileNameLabel.AutoSize = true;
            this.ProfileNameLabel.Location = new System.Drawing.Point(6, 19);
            this.ProfileNameLabel.Name = "ProfileNameLabel";
            this.ProfileNameLabel.Size = new System.Drawing.Size(79, 15);
            this.ProfileNameLabel.TabIndex = 24;
            this.ProfileNameLabel.Text = "Profile Name:";
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
            this.ProfileToApplyOnMinerCloseComboBox.Location = new System.Drawing.Point(285, 98);
            this.ProfileToApplyOnMinerCloseComboBox.Name = "ProfileToApplyOnMinerCloseComboBox";
            this.ProfileToApplyOnMinerCloseComboBox.Size = new System.Drawing.Size(82, 23);
            this.ProfileToApplyOnMinerCloseComboBox.TabIndex = 23;
            this.ProfileToApplyOnMinerCloseComboBox.SelectedIndexChanged += new System.EventHandler(this.ChangePropStatus);
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
            this.ProfileToApplyOnMinerStartComboBox.Location = new System.Drawing.Point(285, 72);
            this.ProfileToApplyOnMinerStartComboBox.Name = "ProfileToApplyOnMinerStartComboBox";
            this.ProfileToApplyOnMinerStartComboBox.Size = new System.Drawing.Size(82, 23);
            this.ProfileToApplyOnMinerStartComboBox.TabIndex = 22;
            this.ProfileToApplyOnMinerStartComboBox.SelectedIndexChanged += new System.EventHandler(this.ChangePropStatus);
            // 
            // ApplyAfterburnerProfileOnMinerCloseCheckBox
            // 
            this.ApplyAfterburnerProfileOnMinerCloseCheckBox.AutoSize = true;
            this.ApplyAfterburnerProfileOnMinerCloseCheckBox.Location = new System.Drawing.Point(7, 100);
            this.ApplyAfterburnerProfileOnMinerCloseCheckBox.Name = "ApplyAfterburnerProfileOnMinerCloseCheckBox";
            this.ApplyAfterburnerProfileOnMinerCloseCheckBox.Size = new System.Drawing.Size(258, 19);
            this.ApplyAfterburnerProfileOnMinerCloseCheckBox.TabIndex = 21;
            this.ApplyAfterburnerProfileOnMinerCloseCheckBox.Text = "Apply Afterburner profile when miner stops:";
            this.ApplyAfterburnerProfileOnMinerCloseCheckBox.UseVisualStyleBackColor = true;
            this.ApplyAfterburnerProfileOnMinerCloseCheckBox.CheckedChanged += new System.EventHandler(this.ApplyAfterburnerProfileOnMinerCloseCheckBox_CheckedChanged);
            // 
            // ApplyAfterburnerProfileOnMinerStartCheckBox
            // 
            this.ApplyAfterburnerProfileOnMinerStartCheckBox.AutoSize = true;
            this.ApplyAfterburnerProfileOnMinerStartCheckBox.Location = new System.Drawing.Point(7, 74);
            this.ApplyAfterburnerProfileOnMinerStartCheckBox.Name = "ApplyAfterburnerProfileOnMinerStartCheckBox";
            this.ApplyAfterburnerProfileOnMinerStartCheckBox.Size = new System.Drawing.Size(258, 19);
            this.ApplyAfterburnerProfileOnMinerStartCheckBox.TabIndex = 20;
            this.ApplyAfterburnerProfileOnMinerStartCheckBox.Text = "Apply Afterburner profile when miner starts:";
            this.ApplyAfterburnerProfileOnMinerStartCheckBox.UseVisualStyleBackColor = true;
            this.ApplyAfterburnerProfileOnMinerStartCheckBox.CheckedChanged += new System.EventHandler(this.ApplyAfterburnerProfileOnMinerStartCheckBox_CheckedChanged);
            // 
            // ProfileComboBox
            // 
            this.ProfileComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProfileComboBox.FormattingEnabled = true;
            this.ProfileComboBox.Location = new System.Drawing.Point(63, 12);
            this.ProfileComboBox.Name = "ProfileComboBox";
            this.ProfileComboBox.Size = new System.Drawing.Size(240, 23);
            this.ProfileComboBox.TabIndex = 23;
            this.ProfileComboBox.SelectedIndexChanged += new System.EventHandler(this.ProfileComboBox_SelectedIndexChanged);
            // 
            // ProfileLabel
            // 
            this.ProfileLabel.AutoSize = true;
            this.ProfileLabel.Location = new System.Drawing.Point(12, 15);
            this.ProfileLabel.Name = "ProfileLabel";
            this.ProfileLabel.Size = new System.Drawing.Size(44, 15);
            this.ProfileLabel.TabIndex = 22;
            this.ProfileLabel.Text = "Profile:";
            // 
            // CreateProfileButton
            // 
            this.CreateProfileButton.BackgroundImage = global::TrexMinerGUI.Properties.Resources.button_plus_green;
            this.CreateProfileButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CreateProfileButton.Location = new System.Drawing.Point(309, 6);
            this.CreateProfileButton.Name = "CreateProfileButton";
            this.CreateProfileButton.Size = new System.Drawing.Size(36, 33);
            this.CreateProfileButton.TabIndex = 24;
            this.CreateProfileButton.UseVisualStyleBackColor = true;
            this.CreateProfileButton.Click += new System.EventHandler(this.CreateProfileButton_Click);
            // 
            // DeleteCurrentProfileButton
            // 
            this.DeleteCurrentProfileButton.BackgroundImage = global::TrexMinerGUI.Properties.Resources.button_delete_red;
            this.DeleteCurrentProfileButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DeleteCurrentProfileButton.Location = new System.Drawing.Point(351, 6);
            this.DeleteCurrentProfileButton.Name = "DeleteCurrentProfileButton";
            this.DeleteCurrentProfileButton.Size = new System.Drawing.Size(39, 33);
            this.DeleteCurrentProfileButton.TabIndex = 25;
            this.DeleteCurrentProfileButton.UseVisualStyleBackColor = true;
            this.DeleteCurrentProfileButton.EnabledChanged += new System.EventHandler(this.DeleteCurrentProfileButton_EnabledChanged);
            this.DeleteCurrentProfileButton.Click += new System.EventHandler(this.DeleteCurrentProfileButton_Click);
            // 
            // TrexSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 224);
            this.Controls.Add(this.DeleteCurrentProfileButton);
            this.Controls.Add(this.CreateProfileButton);
            this.Controls.Add(this.ProfileComboBox);
            this.Controls.Add(this.ProfileLabel);
            this.Controls.Add(this.SelectedProfileGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "TrexSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Trex Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TrexSettingsForm_FormClosing);
            this.SelectedProfileGroupBox.ResumeLayout(false);
            this.SelectedProfileGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.LinkLabel MinerArgsLabel;
        private System.Windows.Forms.TextBox MinerArgsTextBox;
        private System.Windows.Forms.GroupBox SelectedProfileGroupBox;
        private System.Windows.Forms.ComboBox ProfileComboBox;
        private System.Windows.Forms.Label ProfileLabel;
        private System.Windows.Forms.TextBox ProfileNameTextBox;
        private System.Windows.Forms.Label ProfileNameLabel;
        private System.Windows.Forms.ComboBox ProfileToApplyOnMinerCloseComboBox;
        private System.Windows.Forms.ComboBox ProfileToApplyOnMinerStartComboBox;
        private System.Windows.Forms.CheckBox ApplyAfterburnerProfileOnMinerCloseCheckBox;
        private System.Windows.Forms.CheckBox ApplyAfterburnerProfileOnMinerStartCheckBox;
        private System.Windows.Forms.Button EditMinerArgsButton;
        private System.Windows.Forms.Button CreateProfileButton;
        private System.Windows.Forms.Button DeleteCurrentProfileButton;
        private System.Windows.Forms.Button SaveCurrentProfileButton;
    }
}