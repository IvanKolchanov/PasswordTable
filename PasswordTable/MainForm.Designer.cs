
namespace PasswordTable
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.импортироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.разрешитьДобавлениеСтрокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.разрешитьИзменениеРазмеровСтрокиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.разрешитьИзменениеРазмеровСтолбцаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.включитьЗаполнениеСтрокиВОкнеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.включитьУказательСтрокиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.таблицаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьСтрокуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьСтолбецToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьСтолбецToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вернутьТаблицуВИсходноеСостояниеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Service = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Login = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Extra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.таблицаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(803, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьToolStripMenuItem,
            this.импортироватьToolStripMenuItem,
            this.настройкиToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.файлToolStripMenuItem.Text = "Общее";
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить для импорта";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // импортироватьToolStripMenuItem
            // 
            this.импортироватьToolStripMenuItem.Name = "импортироватьToolStripMenuItem";
            this.импортироватьToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.импортироватьToolStripMenuItem.Text = "Импортировать";
            this.импортироватьToolStripMenuItem.Click += new System.EventHandler(this.импортироватьToolStripMenuItem_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.разрешитьДобавлениеСтрокToolStripMenuItem,
            this.разрешитьИзменениеРазмеровСтрокиToolStripMenuItem,
            this.разрешитьИзменениеРазмеровСтолбцаToolStripMenuItem,
            this.hfToolStripMenuItem,
            this.включитьЗаполнениеСтрокиВОкнеToolStripMenuItem,
            this.включитьУказательСтрокиToolStripMenuItem});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // разрешитьДобавлениеСтрокToolStripMenuItem
            // 
            this.разрешитьДобавлениеСтрокToolStripMenuItem.Checked = true;
            this.разрешитьДобавлениеСтрокToolStripMenuItem.CheckOnClick = true;
            this.разрешитьДобавлениеСтрокToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.разрешитьДобавлениеСтрокToolStripMenuItem.Name = "разрешитьДобавлениеСтрокToolStripMenuItem";
            this.разрешитьДобавлениеСтрокToolStripMenuItem.Size = new System.Drawing.Size(350, 22);
            this.разрешитьДобавлениеСтрокToolStripMenuItem.Tag = "addStringsStrip";
            this.разрешитьДобавлениеСтрокToolStripMenuItem.Text = "Разрешить добавление строк";
            this.разрешитьДобавлениеСтрокToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.разрешитьДобавлениеСтрокToolStripMenuItem_CheckStateChanged);
            // 
            // разрешитьИзменениеРазмеровСтрокиToolStripMenuItem
            // 
            this.разрешитьИзменениеРазмеровСтрокиToolStripMenuItem.CheckOnClick = true;
            this.разрешитьИзменениеРазмеровСтрокиToolStripMenuItem.Name = "разрешитьИзменениеРазмеровСтрокиToolStripMenuItem";
            this.разрешитьИзменениеРазмеровСтрокиToolStripMenuItem.Size = new System.Drawing.Size(350, 22);
            this.разрешитьИзменениеРазмеровСтрокиToolStripMenuItem.Text = "Разрешить изменение размеров строк";
            this.разрешитьИзменениеРазмеровСтрокиToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.разрешитьИзменениеРазмеровСтрокиToolStripMenuItem_CheckStateChanged);
            // 
            // разрешитьИзменениеРазмеровСтолбцаToolStripMenuItem
            // 
            this.разрешитьИзменениеРазмеровСтолбцаToolStripMenuItem.CheckOnClick = true;
            this.разрешитьИзменениеРазмеровСтолбцаToolStripMenuItem.Name = "разрешитьИзменениеРазмеровСтолбцаToolStripMenuItem";
            this.разрешитьИзменениеРазмеровСтолбцаToolStripMenuItem.Size = new System.Drawing.Size(350, 22);
            this.разрешитьИзменениеРазмеровСтолбцаToolStripMenuItem.Text = "Разрешить изменение размеров столбцов";
            this.разрешитьИзменениеРазмеровСтолбцаToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.разрешитьИзменениеРазмеровСтолбцаToolStripMenuItem_CheckStateChanged_1);
            this.разрешитьИзменениеРазмеровСтолбцаToolStripMenuItem.Click += new System.EventHandler(this.разрешитьИзменениеРазмеровСтолбцаToolStripMenuItem_Click);
            // 
            // hfToolStripMenuItem
            // 
            this.hfToolStripMenuItem.CheckOnClick = true;
            this.hfToolStripMenuItem.Name = "hfToolStripMenuItem";
            this.hfToolStripMenuItem.Size = new System.Drawing.Size(350, 22);
            this.hfToolStripMenuItem.Text = "Разрешить изменение размеров указателя строки";
            this.hfToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.hfToolStripMenuItem_CheckStateChanged);
            // 
            // включитьЗаполнениеСтрокиВОкнеToolStripMenuItem
            // 
            this.включитьЗаполнениеСтрокиВОкнеToolStripMenuItem.CheckOnClick = true;
            this.включитьЗаполнениеСтрокиВОкнеToolStripMenuItem.Name = "включитьЗаполнениеСтрокиВОкнеToolStripMenuItem";
            this.включитьЗаполнениеСтрокиВОкнеToolStripMenuItem.Size = new System.Drawing.Size(350, 22);
            this.включитьЗаполнениеСтрокиВОкнеToolStripMenuItem.Text = "Включить заполнение строки в окне";
            this.включитьЗаполнениеСтрокиВОкнеToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.включитьЗаполнениеСтрокиВОкнеToolStripMenuItem_CheckStateChanged);
            // 
            // включитьУказательСтрокиToolStripMenuItem
            // 
            this.включитьУказательСтрокиToolStripMenuItem.Checked = true;
            this.включитьУказательСтрокиToolStripMenuItem.CheckOnClick = true;
            this.включитьУказательСтрокиToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.включитьУказательСтрокиToolStripMenuItem.Name = "включитьУказательСтрокиToolStripMenuItem";
            this.включитьУказательСтрокиToolStripMenuItem.Size = new System.Drawing.Size(350, 22);
            this.включитьУказательСтрокиToolStripMenuItem.Text = "Включить указатель строки";
            this.включитьУказательСтрокиToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.включитьУказательСтрокиToolStripMenuItem_CheckStateChanged);
            // 
            // таблицаToolStripMenuItem
            // 
            this.таблицаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьСтрокуToolStripMenuItem,
            this.добавитьСтолбецToolStripMenuItem,
            this.удалитьСтолбецToolStripMenuItem,
            this.вернутьТаблицуВИсходноеСостояниеToolStripMenuItem});
            this.таблицаToolStripMenuItem.Name = "таблицаToolStripMenuItem";
            this.таблицаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.таблицаToolStripMenuItem.Text = "Таблица";
            // 
            // добавитьСтрокуToolStripMenuItem
            // 
            this.добавитьСтрокуToolStripMenuItem.Name = "добавитьСтрокуToolStripMenuItem";
            this.добавитьСтрокуToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.добавитьСтрокуToolStripMenuItem.Text = "Добавить строку";
            this.добавитьСтрокуToolStripMenuItem.Click += new System.EventHandler(this.добавитьСтрокуToolStripMenuItem_Click);
            // 
            // добавитьСтолбецToolStripMenuItem
            // 
            this.добавитьСтолбецToolStripMenuItem.Name = "добавитьСтолбецToolStripMenuItem";
            this.добавитьСтолбецToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.добавитьСтолбецToolStripMenuItem.Text = "Добавить столбец";
            this.добавитьСтолбецToolStripMenuItem.Click += new System.EventHandler(this.добавитьСтолбецToolStripMenuItem_Click);
            // 
            // удалитьСтолбецToolStripMenuItem
            // 
            this.удалитьСтолбецToolStripMenuItem.Name = "удалитьСтолбецToolStripMenuItem";
            this.удалитьСтолбецToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.удалитьСтолбецToolStripMenuItem.Text = "Удалить столбец";
            this.удалитьСтолбецToolStripMenuItem.Click += new System.EventHandler(this.удалитьСтолбецToolStripMenuItem_Click);
            // 
            // вернутьТаблицуВИсходноеСостояниеToolStripMenuItem
            // 
            this.вернутьТаблицуВИсходноеСостояниеToolStripMenuItem.Name = "вернутьТаблицуВИсходноеСостояниеToolStripMenuItem";
            this.вернутьТаблицуВИсходноеСостояниеToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.вернутьТаблицуВИсходноеСостояниеToolStripMenuItem.Text = "Вернуть таблицу в исходное состояние";
            this.вернутьТаблицуВИсходноеСостояниеToolStripMenuItem.Click += new System.EventHandler(this.вернутьТаблицуВИсходноеСостояниеToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Service,
            this.Login,
            this.Password,
            this.Rcode,
            this.Extra});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.Size = new System.Drawing.Size(803, 426);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridView1_RowsRemoved);
            // 
            // Service
            // 
            this.Service.HeaderText = "Service";
            this.Service.Name = "Service";
            this.Service.Width = 152;
            // 
            // Login
            // 
            this.Login.HeaderText = "Login";
            this.Login.Name = "Login";
            this.Login.Width = 152;
            // 
            // Password
            // 
            this.Password.HeaderText = "Password";
            this.Password.Name = "Password";
            this.Password.Width = 152;
            // 
            // Rcode
            // 
            this.Rcode.HeaderText = "Rcode";
            this.Rcode.Name = "Rcode";
            this.Rcode.Width = 152;
            // 
            // Extra
            // 
            this.Extra.HeaderText = "Extra";
            this.Extra.Name = "Extra";
            this.Extra.Width = 152;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Account password keeper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem импортироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem таблицаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьСтрокуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьСтолбецToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Service;
        private System.Windows.Forms.DataGridViewTextBoxColumn Login;
        private System.Windows.Forms.DataGridViewTextBoxColumn Password;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Extra;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem разрешитьДобавлениеСтрокToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem разрешитьИзменениеРазмеровСтрокиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem разрешитьИзменениеРазмеровСтолбцаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem включитьЗаполнениеСтрокиВОкнеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вернутьТаблицуВИсходноеСостояниеToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem hfToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem включитьУказательСтрокиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьСтолбецToolStripMenuItem;
    }
}