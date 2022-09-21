namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_login_KH = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button_login_KF = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_login_KH
            // 
            this.button_login_KH.Location = new System.Drawing.Point(21, 35);
            this.button_login_KH.Name = "button_login_KH";
            this.button_login_KH.Size = new System.Drawing.Size(75, 23);
            this.button_login_KH.TabIndex = 0;
            this.button_login_KH.Text = "국내로그인";
            this.button_login_KH.UseVisualStyleBackColor = true;
            this.button_login_KH.Click += new System.EventHandler(this.button_login_KH_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(21, 64);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(114, 23);
            this.textBox1.TabIndex = 1;
            // 
            // button_login_KF
            // 
            this.button_login_KF.Location = new System.Drawing.Point(187, 35);
            this.button_login_KF.Name = "button_login_KF";
            this.button_login_KF.Size = new System.Drawing.Size(75, 23);
            this.button_login_KF.TabIndex = 0;
            this.button_login_KF.Text = "해외로그인";
            this.button_login_KF.UseVisualStyleBackColor = true;
            this.button_login_KF.Click += new System.EventHandler(this.button_login_KF_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(187, 64);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(114, 23);
            this.textBox2.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 137);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button_login_KF);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button_login_KH);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button_login_KH;
        private TextBox textBox1;
        private Button button_login_KF;
        private TextBox textBox2;
    }
}