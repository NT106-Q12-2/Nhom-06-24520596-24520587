namespace EmailClientApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_MatKhau = new System.Windows.Forms.TextBox();
            this.tb_TaiKhoan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_DangNhap = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tb_SMTPPort = new System.Windows.Forms.TextBox();
            this.tb_IMAPPort = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_SMTP = new System.Windows.Forms.ComboBox();
            this.cb_IMAP = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_GuiMail = new System.Windows.Forms.Button();
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.btn_DangXuat = new System.Windows.Forms.Button();
            this.dgv_EmailList = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_EmailList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_MatKhau);
            this.groupBox1.Controls.Add(this.tb_TaiKhoan);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btn_DangNhap);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(380, 150);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Đăng nhập";
            // 
            // tb_MatKhau
            // 
            this.tb_MatKhau.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tb_MatKhau.Location = new System.Drawing.Point(110, 65);
            this.tb_MatKhau.Name = "tb_MatKhau";
            this.tb_MatKhau.PasswordChar = '●';
            this.tb_MatKhau.Size = new System.Drawing.Size(250, 23);
            this.tb_MatKhau.TabIndex = 4;
            // 
            // tb_TaiKhoan
            // 
            this.tb_TaiKhoan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tb_TaiKhoan.Location = new System.Drawing.Point(110, 30);
            this.tb_TaiKhoan.Name = "tb_TaiKhoan";
            this.tb_TaiKhoan.Size = new System.Drawing.Size(250, 23);
            this.tb_TaiKhoan.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.Location = new System.Drawing.Point(20, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mật khẩu:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.Location = new System.Drawing.Point(20, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tài khoản:";
            // 
            // btn_DangNhap
            // 
            this.btn_DangNhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btn_DangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DangNhap.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btn_DangNhap.ForeColor = System.Drawing.Color.White;
            this.btn_DangNhap.Location = new System.Drawing.Point(110, 105);
            this.btn_DangNhap.Name = "btn_DangNhap";
            this.btn_DangNhap.Size = new System.Drawing.Size(100, 30);
            this.btn_DangNhap.TabIndex = 0;
            this.btn_DangNhap.Text = "Đăng nhập";
            this.btn_DangNhap.UseVisualStyleBackColor = false;
            this.btn_DangNhap.Click += new System.EventHandler(this.btn_DangNhap_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tb_SMTPPort);
            this.groupBox2.Controls.Add(this.tb_IMAPPort);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cb_SMTP);
            this.groupBox2.Controls.Add(this.cb_IMAP);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(410, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(520, 150);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cài đặt";
            // 
            // tb_SMTPPort
            // 
            this.tb_SMTPPort.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tb_SMTPPort.Location = new System.Drawing.Point(430, 100);
            this.tb_SMTPPort.Name = "tb_SMTPPort";
            this.tb_SMTPPort.Size = new System.Drawing.Size(70, 23);
            this.tb_SMTPPort.TabIndex = 7;
            this.tb_SMTPPort.Text = "465";
            // 
            // tb_IMAPPort
            // 
            this.tb_IMAPPort.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tb_IMAPPort.Location = new System.Drawing.Point(430, 60);
            this.tb_IMAPPort.Name = "tb_IMAPPort";
            this.tb_IMAPPort.Size = new System.Drawing.Size(70, 23);
            this.tb_IMAPPort.TabIndex = 6;
            this.tb_IMAPPort.Text = "993";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label6.Location = new System.Drawing.Point(380, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Port:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label5.Location = new System.Drawing.Point(380, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Port:";
            // 
            // cb_SMTP
            // 
            this.cb_SMTP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_SMTP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cb_SMTP.FormattingEnabled = true;
            this.cb_SMTP.Location = new System.Drawing.Point(110, 100);
            this.cb_SMTP.Name = "cb_SMTP";
            this.cb_SMTP.Size = new System.Drawing.Size(250, 23);
            this.cb_SMTP.TabIndex = 3;
            // 
            // cb_IMAP
            // 
            this.cb_IMAP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_IMAP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cb_IMAP.FormattingEnabled = true;
            this.cb_IMAP.Location = new System.Drawing.Point(110, 60);
            this.cb_IMAP.Name = "cb_IMAP";
            this.cb_IMAP.Size = new System.Drawing.Size(250, 23);
            this.cb_IMAP.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.Location = new System.Drawing.Point(20, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "SMTP Server:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.Location = new System.Drawing.Point(20, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "IMAP Server:";
            // 
            // btn_GuiMail
            // 
            this.btn_GuiMail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btn_GuiMail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_GuiMail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btn_GuiMail.ForeColor = System.Drawing.Color.White;
            this.btn_GuiMail.Location = new System.Drawing.Point(12, 180);
            this.btn_GuiMail.Name = "btn_GuiMail";
            this.btn_GuiMail.Size = new System.Drawing.Size(100, 35);
            this.btn_GuiMail.TabIndex = 2;
            this.btn_GuiMail.Text = "Gửi mail";
            this.btn_GuiMail.UseVisualStyleBackColor = false;
            this.btn_GuiMail.Click += new System.EventHandler(this.btn_GuiMail_Click);
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this.btn_Refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Refresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btn_Refresh.ForeColor = System.Drawing.Color.White;
            this.btn_Refresh.Location = new System.Drawing.Point(130, 180);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(100, 35);
            this.btn_Refresh.TabIndex = 3;
            this.btn_Refresh.Text = "Refresh";
            this.btn_Refresh.UseVisualStyleBackColor = false;
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // btn_DangXuat
            // 
            this.btn_DangXuat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btn_DangXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DangXuat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btn_DangXuat.ForeColor = System.Drawing.Color.White;
            this.btn_DangXuat.Location = new System.Drawing.Point(250, 180);
            this.btn_DangXuat.Name = "btn_DangXuat";
            this.btn_DangXuat.Size = new System.Drawing.Size(100, 35);
            this.btn_DangXuat.TabIndex = 4;
            this.btn_DangXuat.Text = "Đăng xuất";
            this.btn_DangXuat.UseVisualStyleBackColor = false;
            this.btn_DangXuat.Click += new System.EventHandler(this.btn_DangXuat_Click);
            // 
            // dgv_EmailList
            // 
            this.dgv_EmailList.AllowUserToAddRows = false;
            this.dgv_EmailList.AllowUserToDeleteRows = false;
            this.dgv_EmailList.BackgroundColor = System.Drawing.Color.White;
            this.dgv_EmailList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_EmailList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgv_EmailList.Location = new System.Drawing.Point(12, 230);
            this.dgv_EmailList.Name = "dgv_EmailList";
            this.dgv_EmailList.ReadOnly = true;
            this.dgv_EmailList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_EmailList.Size = new System.Drawing.Size(918, 350);
            this.dgv_EmailList.TabIndex = 5;
            this.dgv_EmailList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_EmailList_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "#";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 50;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "From";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 250;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Subject";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 400;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Datetime";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 150;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 601);
            this.Controls.Add(this.dgv_EmailList);
            this.Controls.Add(this.btn_DangXuat);
            this.Controls.Add(this.btn_Refresh);
            this.Controls.Add(this.btn_GuiMail);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Email Client - Đăng nhập và Danh sách Email";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_EmailList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_DangNhap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_MatKhau;
        private System.Windows.Forms.TextBox tb_TaiKhoan;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cb_SMTP;
        private System.Windows.Forms.ComboBox cb_IMAP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_SMTPPort;
        private System.Windows.Forms.TextBox tb_IMAPPort;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_GuiMail;
        private System.Windows.Forms.Button btn_Refresh;
        private System.Windows.Forms.Button btn_DangXuat;
        private System.Windows.Forms.DataGridView dgv_EmailList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}