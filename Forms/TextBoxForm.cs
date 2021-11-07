using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TrexMinerGUI.Forms
{
    public partial class TextBoxForm : Form
    {
        public string ReturnValue { get; set; }

        public TextBoxForm(string Title, string Description, string Content)
        {
            InitializeComponent();

            this.Text = Title;
            this.DescriptionLabel.Text = Description;
            this.MainTextBox.Text = Content;
        }

        private void TextBoxForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.ReturnValue = this.MainTextBox.Text.Replace(Environment.NewLine, "");
            this.DialogResult = DialogResult.OK;
        }

        private void MainTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Close();
            }
        }
    }
}
