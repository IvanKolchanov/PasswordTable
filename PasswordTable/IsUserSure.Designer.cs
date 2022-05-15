
namespace PasswordTable
{
    partial class IsUserSure
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
            this.userMessage = new System.Windows.Forms.Label();
            this.acceptButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userMessage
            // 
            this.userMessage.AutoSize = true;
            this.userMessage.Location = new System.Drawing.Point(54, 31);
            this.userMessage.Name = "userMessage";
            this.userMessage.Size = new System.Drawing.Size(28, 13);
            this.userMessage.TabIndex = 0;
            this.userMessage.Text = "ABC";
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(118, 62);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(82, 30);
            this.acceptButton.TabIndex = 1;
            this.acceptButton.Text = "Да";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // IsUserSure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 108);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.userMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IsUserSure";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IsUserSure_FormClosing);
            this.Load += new System.EventHandler(this.IsUserSure_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label userMessage;
        private System.Windows.Forms.Button acceptButton;
    }
}