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
    public partial class ColumnChangingNameForm : Form
    {
        private bool isButtonPressed = false;
        public ColumnChangingNameForm()
        {
            InitializeComponent();
            AcceptButton = acceptButton;
            ColumnNameData.isEmpty = true;
        }

        private void ColumnChangingNameForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            if (columnNameBox.Text != "")
            {
                ColumnNameData.columnName = columnNameBox.Text;
                ColumnNameData.isEmpty = false;
                isButtonPressed = true;
                this.Close();
            }
        }

        private void ColumnChangingNameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            IsUserSure form = new IsUserSure("Вы уверены, что хотите отменить создание столбца?");
            if (!isButtonPressed)
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.Cancel;
                    e.Cancel = false;
                }else
                {
                    if (!isButtonPressed)
                    {
                        e.Cancel = true;
                    }
                }
            }else
            {
                this.DialogResult = DialogResult.OK;
            }
            
        }
    }
}
