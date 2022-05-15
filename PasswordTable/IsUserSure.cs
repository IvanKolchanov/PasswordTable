using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordTable
{
    public partial class IsUserSure : Form
    {
        public IsUserSure(string userQuestion)
        {
            InitializeComponent();
            userMessage.Text = userQuestion;
            this.Width = 54 + userMessage.Width + 54;
            userMessage.Left = (this.Width - userMessage.Width) / 2 - 9;
            acceptButton.Left = (this.Width - acceptButton.Width) / 2 - 8;
            this.DialogResult = DialogResult.Abort;
            AcceptButton = acceptButton;
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void IsUserSure_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void IsUserSure_Load(object sender, EventArgs e)
        {

        }
    }
}
