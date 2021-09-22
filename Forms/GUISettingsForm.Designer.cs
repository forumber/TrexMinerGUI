
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
            // GUISettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 69);
            this.Controls.Add(this.StartMiningOnAppStartCheckBox);
            this.Controls.Add(this.StartOnStartupCheckBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "GUISettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GUI Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox StartMiningOnAppStartCheckBox;
        private System.Windows.Forms.CheckBox StartOnStartupCheckBox;
    }
}