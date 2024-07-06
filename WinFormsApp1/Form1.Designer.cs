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
            this.button_login_KF = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_KH_code = new System.Windows.Forms.TextBox();
            this.button_KH_info = new System.Windows.Forms.Button();
            this.log_list = new System.Windows.Forms.ListBox();
            this.button_KH_chart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_login_KH
            // 
            this.button_login_KH.Location = new System.Drawing.Point(21, 28);
            this.button_login_KH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_login_KH.Name = "button_login_KH";
            this.button_login_KH.Size = new System.Drawing.Size(75, 20);
            this.button_login_KH.TabIndex = 0;
            this.button_login_KH.Text = "국내로그인";
            this.button_login_KH.UseVisualStyleBackColor = true;
            this.button_login_KH.Click += new System.EventHandler(this.button_login_KH_Click);
            // 
            // button_login_KF
            // 
            this.button_login_KF.Location = new System.Drawing.Point(443, 28);
            this.button_login_KF.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_login_KF.Name = "button_login_KF";
            this.button_login_KF.Size = new System.Drawing.Size(75, 20);
            this.button_login_KF.TabIndex = 0;
            this.button_login_KF.Text = "해외로그인";
            this.button_login_KF.UseVisualStyleBackColor = true;
            this.button_login_KF.Click += new System.EventHandler(this.button_login_KF_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(443, 51);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(114, 21);
            this.textBox2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "종목코드";
            // 
            // textBox_KH_code
            // 
            this.textBox_KH_code.Location = new System.Drawing.Point(70, 65);
            this.textBox_KH_code.Name = "textBox_KH_code";
            this.textBox_KH_code.Size = new System.Drawing.Size(100, 21);
            this.textBox_KH_code.TabIndex = 3;
            this.textBox_KH_code.Text = "005930";
            // 
            // button_KH_info
            // 
            this.button_KH_info.Location = new System.Drawing.Point(17, 98);
            this.button_KH_info.Name = "button_KH_info";
            this.button_KH_info.Size = new System.Drawing.Size(89, 23);
            this.button_KH_info.TabIndex = 4;
            this.button_KH_info.Text = "종목정보요청";
            this.button_KH_info.UseVisualStyleBackColor = true;
            this.button_KH_info.Click += new System.EventHandler(this.button_KH_info_Click);
            // 
            // log_list
            // 
            this.log_list.FormattingEnabled = true;
            this.log_list.ItemHeight = 12;
            this.log_list.Location = new System.Drawing.Point(12, 163);
            this.log_list.Name = "log_list";
            this.log_list.Size = new System.Drawing.Size(658, 208);
            this.log_list.TabIndex = 5;
            // 
            // button_KH_chart
            // 
            this.button_KH_chart.Location = new System.Drawing.Point(122, 98);
            this.button_KH_chart.Name = "button_KH_chart";
            this.button_KH_chart.Size = new System.Drawing.Size(89, 23);
            this.button_KH_chart.TabIndex = 4;
            this.button_KH_chart.Text = "일봉차트요청";
            this.button_KH_chart.UseVisualStyleBackColor = true;
            this.button_KH_chart.Click += new System.EventHandler(this.button_KH_chart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 386);
            this.Controls.Add(this.log_list);
            this.Controls.Add(this.button_KH_chart);
            this.Controls.Add(this.button_KH_info);
            this.Controls.Add(this.textBox_KH_code);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button_login_KF);
            this.Controls.Add(this.button_login_KH);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button_login_KH;
        private Button button_login_KF;
        private TextBox textBox2;
        private Label label1;
        private TextBox textBox_KH_code;
        private Button button_KH_info;
        private ListBox log_list;
        private Button button_KH_chart;
    }
}