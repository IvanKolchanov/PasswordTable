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
    public partial class ImportCodeForm : Form
    {
        private string path;
        public ImportCodeForm()
        {
            InitializeComponent();
            AcceptButton = button1;
            MessageBox.Show("Выберите файл импорта");
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog1.FileName;
            }else
            {
                DialogResult = DialogResult.Abort;
                this.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ImportPasswordData.password = Convert.ToInt32(textBox1.Text);
                ImportPasswordData.path = path;
                textBox1.ReadOnly = true;
                if (ImportPasswordData.password.ToString().Length == 6)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }catch (InvalidCastException)
            {
                MessageBox.Show("Неправильно введён код");
            }
        }

        private void ImportCodeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                e.Cancel = false;
            }else
            {
                IsUserSure form = new IsUserSure("Вы уверены, что хотите отменить импорт?");
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
