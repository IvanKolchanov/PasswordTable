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
    public partial class EncryptingPasswordForm : Form
    {
        private int secondCount = 0;
        private bool isTime = false;

        public EncryptingPasswordForm(int password)
        {
            InitializeComponent();
            textBox1.ReadOnly = true;
            textBox1.Text = password.ToString();
            timer1.Interval = 1000;
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isTime)
            {
                this.Close();
            }
        }

        private void EncryptingPasswordForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isTime)
            {
                e.Cancel = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            secondCount++;
            if (secondCount < 10)
            {
                label2.Text = "До разблокировки закрытия формы: " + (10 - secondCount).ToString();
            }
            if(secondCount == 10)
            {
                isTime = true;
                Point point = new Point();
                point.X = label2.Location.X + 7;
                point.Y = label2.Location.Y;
                label2.Location = point;
            }
            if (secondCount >= 10)
            {
                label2.Text = "Закрытие формы разблокированно";
            }
        }
    }
}
