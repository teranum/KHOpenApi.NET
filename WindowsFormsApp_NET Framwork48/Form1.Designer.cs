namespace WindowsFormsApp_NET_Framwork48
{
    partial class Form1
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
            this.button_login_KH = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button_login_KF = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_login_KH
            // 
            this.button_login_KH.Location = new System.Drawing.Point(45, 44);
            this.button_login_KH.Name = "button_login_KH";
            this.button_login_KH.Size = new System.Drawing.Size(75, 23);
            this.button_login_KH.TabIndex = 0;
            this.button_login_KH.Text = "국내로그인";
            this.button_login_KH.UseVisualStyleBackColor = true;
            this.button_login_KH.Click += new System.EventHandler(this.button_login_KH_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(45, 84);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(163, 21);
            this.textBox1.TabIndex = 1;
            // 
            // button_login_KF
            // 
            this.button_login_KF.Location = new System.Drawing.Point(258, 44);
            this.button_login_KF.Name = "button_login_KF";
            this.button_login_KF.Size = new System.Drawing.Size(75, 23);
            this.button_login_KF.TabIndex = 0;
            this.button_login_KF.Text = "해외로그인";
            this.button_login_KF.UseVisualStyleBackColor = true;
            this.button_login_KF.Click += new System.EventHandler(this.button_login_KF_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(258, 84);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(163, 21);
            this.textBox2.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 175);
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

        private System.Windows.Forms.Button button_login_KH;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button_login_KF;
        private System.Windows.Forms.TextBox textBox2;
    }
}

