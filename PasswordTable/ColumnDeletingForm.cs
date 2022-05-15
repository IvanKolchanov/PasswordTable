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
    public partial class ColumnDeletingForm : Form
    {
        public ColumnDeletingForm(DataGridViewColumnCollection columns)
        {
            InitializeComponent();
            for (int i = 0; i < columns.Count; i++)
            {
                listBox1.Items.Add(columns[i].HeaderText);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (listBox1.SelectedIndex != -1)
            {
                this.DialogResult = DialogResult.OK;
                ColumnDeletingData.idOfTheColumn = listBox1.SelectedIndex;
                this.Close();
            }
        }

        private void ColumnDeletingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {
                IsUserSure form = new IsUserSure("Вы уверены, что хотите отменить удаление стобца?");
                if (form.ShowDialog() == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.Cancel;
                    e.Cancel = false;
                }else
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
