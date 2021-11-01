
namespace TrexMinerGUI.Forms
{
    partial class TrexSettingsForm
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
            this.components = new System.ComponentModel.Container();
            this.SaveMinerArgButton = new System.Windows.Forms.Button();
            this.MinerArgsLabel = new System.Windows.Forms.LinkLabel();
            this.MinerArgsTextBox = new System.Windows.Forms.TextBox();
            this.TheToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // SaveMinerArgButton
            // 
            this.SaveMinerArgButton.BackgroundImage = global::TrexMinerGUI.Properties.Resources.save;
            this.SaveMinerArgButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SaveMinerArgButton.Enabled = false;
            this.SaveMinerArgButton.Location = new System.Drawing.Point(759, 6);
            this.SaveMinerArgButton.Name = "SaveMinerArgButton";
            this.SaveMinerArgButton.Size = new System.Drawing.Size(25, 23);
            this.SaveMinerArgButton.TabIndex = 20;
            this.SaveMinerArgButton.UseVisualStyleBackColor = true;
            this.SaveMinerArgButton.Click += new System.EventHandler(this.SaveMinerArgButton_Click);
            // 
            // MinerArgsLabel
            // 
            this.MinerArgsLabel.AutoSize = true;
            this.MinerArgsLabel.Location = new System.Drawing.Point(12, 9);
            this.MinerArgsLabel.Name = "MinerArgsLabel";
            this.MinerArgsLabel.Size = new System.Drawing.Size(63, 15);
            this.MinerArgsLabel.TabIndex = 19;
            this.MinerArgsLabel.TabStop = true;
            this.MinerArgsLabel.Text = "Miner Arg:";
            this.MinerArgsLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.MinerArgsLabel_LinkClicked);
            // 
            // MinerArgsTextBox
            // 
            this.MinerArgsTextBox.Location = new System.Drawing.Point(81, 6);
            this.MinerArgsTextBox.Name = "MinerArgsTextBox";
            this.MinerArgsTextBox.Size = new System.Drawing.Size(672, 23);
            this.MinerArgsTextBox.TabIndex = 18;
            this.MinerArgsTextBox.TextChanged += new System.EventHandler(this.MinerArgsTextBox_TextChanged);
            // 
            // TrexSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 39);
            this.Controls.Add(this.SaveMinerArgButton);
            this.Controls.Add(this.MinerArgsLabel);
            this.Controls.Add(this.MinerArgsTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "TrexSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Trex Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TrexSettingsForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveMinerArgButton;
        private System.Windows.Forms.LinkLabel MinerArgsLabel;
        private System.Windows.Forms.TextBox MinerArgsTextBox;
        private System.Windows.Forms.ToolTip TheToolTip;
    }
}