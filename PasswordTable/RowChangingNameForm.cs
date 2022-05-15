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
    public partial class RowChangingNameForm : Form
    {
        private bool isButtonPressed = false;
        public RowChangingNameForm()
        {
            InitializeComponent();
            AcceptButton = button1;
            RowNameData.isEmpty = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void RowChangingNameForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((service.Text != "") && (login.Text != "") && (password.Text != "") && (rCode.Text != ""))
            {
                RowNameData.service = service.Text;
                RowNameData.login = login.Text;
                RowNameData.password = password.Text;
                RowNameData.rCode = rCode.Text;
                RowNameData.isEmpty = false;
                isButtonPressed = true;
                this.Close();
            }
        }

        private void RowChangingNameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            IsUserSure form = new IsUserSure("Вы уверены, что хотите отменить ввод строки?");
            if (!isButtonPressed)
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    e.Cancel = false;
                    this.DialogResult = DialogResult.Cancel;
                }else
                {
                    e.Cancel = true;
                }
            }else
            {
                this.DialogResult = DialogResult.OK;
            }
            
        }
    }
}
