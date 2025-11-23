namespace Bai05_
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

        private void InitializeComponent()
        {
            this.lb_taikhoan = new System.Windows.Forms.Label();
            this.tb_taikhoan = new System.Windows.Forms.TextBox();
            this.lb_matkhau = new System.Windows.Forms.Label();
            this.tb_matkhau = new System.Windows.Forms.TextBox();
            this.btn_dangnhap = new System.Windows.Forms.Button();
            this.tb_ketqua = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();

            this.lb_taikhoan.AutoSize = true;
            this.lb_taikhoan.Location = new System.Drawing.Point(25, 25);
            this.lb_taikhoan.Name = "lb_taikhoan";
            this.lb_taikhoan.Size = new System.Drawing.Size(70, 15);
            this.lb_taikhoan.TabIndex = 0;
            this.lb_taikhoan.Text = "Tài khoản:";

            this.tb_taikhoan.Location = new System.Drawing.Point(101, 22);
            this.tb_taikhoan.Name = "tb_taikhoan";
            this.tb_taikhoan.Size = new System.Drawing.Size(250, 21);
            this.tb_taikhoan.TabIndex = 1;

            this.lb_matkhau.AutoSize = true;
            this.lb_matkhau.Location = new System.Drawing.Point(25, 60);
            this.lb_matkhau.Name = "lb_matkhau";
            this.lb_matkhau.Size = new System.Drawing.Size(64, 15);
            this.lb_matkhau.TabIndex = 2;
            this.lb_matkhau.Text = "Mật khẩu:";

            this.tb_matkhau.Location = new System.Drawing.Point(101, 57);
            this.tb_matkhau.Name = "tb_matkhau";
            this.tb_matkhau.PasswordChar = '*';
            this.tb_matkhau.Size = new System.Drawing.Size(250, 21);
            this.tb_matkhau.TabIndex = 3;

            this.btn_dangnhap.BackColor = System.Drawing.Color.SteelBlue;
            this.btn_dangnhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_dangnhap.ForeColor = System.Drawing.Color.White;
            this.btn_dangnhap.Location = new System.Drawing.Point(28, 95);
            this.btn_dangnhap.Name = "btn_dangnhap";
            this.btn_dangnhap.Size = new System.Drawing.Size(323, 35);
            this.btn_dangnhap.TabIndex = 4;
            this.btn_dangnhap.Text = "ĐĂNG NHẬP";
            this.btn_dangnhap.UseVisualStyleBackColor = false;
            this.btn_dangnhap.Click += new System.EventHandler(this.btn_dangnhap_Click);

            this.tb_ketqua.Location = new System.Drawing.Point(28, 145);
            this.tb_ketqua.Name = "tb_ketqua";
            this.tb_ketqua.ReadOnly = true;
            this.tb_ketqua.Size = new System.Drawing.Size(323, 195);
            this.tb_ketqua.TabIndex = 5;
            this.tb_ketqua.Text = "Nhập thông tin và click ĐĂNG NHẬP...";

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.tb_ketqua);
            this.Controls.Add(this.btn_dangnhap);
            this.Controls.Add(this.tb_matkhau);
            this.Controls.Add(this.lb_matkhau);
            this.Controls.Add(this.tb_taikhoan);
            this.Controls.Add(this.lb_taikhoan);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bài 5 - Đăng nhập API";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lb_taikhoan;
        private System.Windows.Forms.TextBox tb_taikhoan;
        private System.Windows.Forms.Label lb_matkhau;
        private System.Windows.Forms.TextBox tb_matkhau;
        private System.Windows.Forms.Button btn_dangnhap;
        private System.Windows.Forms.RichTextBox tb_ketqua;
    }
}