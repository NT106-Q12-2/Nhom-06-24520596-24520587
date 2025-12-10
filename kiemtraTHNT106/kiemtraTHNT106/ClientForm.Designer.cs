using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Test
{
    partial class ClientForm
    {
        private System.ComponentModel.IContainer components = null;

        private Button btn_connect;
        private Button btn_them;
        private Button btn_getAll;
        private Button btn_chon;
        private TextBox tb_mon;
        private TextBox tb_hinh;
        private ListView lv_monan;
        private Label lb_ten;
        private Label lb_status;
        private Label lblTenMon;
        private PictureBox pictureBox1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btn_connect = new Button();
            btn_them = new Button();
            btn_getAll = new Button();
            btn_chon = new Button();
            tb_mon = new TextBox();
            tb_hinh = new TextBox();
            lv_monan = new ListView();
            lb_ten = new Label();
            lb_status = new Label();
            lblTenMon = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btn_connect
            // 
            btn_connect.BackColor = Color.DarkGreen;
            btn_connect.ForeColor = SystemColors.ControlLight;
            btn_connect.Location = new Point(30, 30);
            btn_connect.Name = "btn_connect";
            btn_connect.Size = new Size(120, 35);
            btn_connect.TabIndex = 0;
            btn_connect.Text = "Connect";
            btn_connect.UseVisualStyleBackColor = false;
            btn_connect.Click += btn_connect_Click;
            // 
            // btn_them
            // 
            btn_them.Location = new Point(470, 110);
            btn_them.Name = "btn_them";
            btn_them.Size = new Size(100, 34);
            btn_them.TabIndex = 1;
            btn_them.Text = "Thêm";
            btn_them.UseVisualStyleBackColor = true;
            btn_them.Click += btn_them_Click;
            // 
            // btn_getAll
            // 
            btn_getAll.Location = new Point(590, 110);
            btn_getAll.Name = "btn_getAll";
            btn_getAll.Size = new Size(100, 34);
            btn_getAll.TabIndex = 2;
            btn_getAll.Text = "Lấy toàn bộ";
            btn_getAll.UseVisualStyleBackColor = true;
            btn_getAll.Click += btn_getAll_Click;
            // 
            // btn_chon
            // 
            btn_chon.BackColor = Color.FromArgb(255, 192, 192);
            btn_chon.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn_chon.Location = new Point(480, 300);
            btn_chon.Name = "btn_chon";
            btn_chon.Size = new Size(200, 40);
            btn_chon.TabIndex = 12;
            btn_chon.Text = "Hôm nay ăn gì ";
            btn_chon.UseVisualStyleBackColor = false;
            btn_chon.Click += btn_chon_Click;
            // 
            // lv_monan
            // 
            lv_monan.Location = new Point(30, 150);
            lv_monan.Name = "lv_monan";
            lv_monan.Size = new Size(660, 130);
            lv_monan.TabIndex = 5;
            lv_monan.UseCompatibleStateImageBehavior = false;
            lv_monan.View = View.List;
            // 
            // lb_ten
            // 
            lb_ten.Location = new Point(30, 70);
            lb_ten.Name = "lb_ten";
            lb_ten.Size = new Size(300, 25);
            lb_ten.TabIndex = 6;
            lb_ten.Text = "Tên người dùng:";
            // 
            // lb_status
            // 
            lb_status.Location = new Point(170, 35);
            lb_status.Name = "lb_status";
            lb_status.Size = new Size(250, 25);
            lb_status.TabIndex = 7;
            lb_status.Text = "Trạng thái: chưa kết nối";
            // 
            // lblTenMon
            // 
            lblTenMon.AutoSize = true;
            lblTenMon.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTenMon.Location = new Point(30, 300);
            lblTenMon.Name = "lblTenMon";
            lblTenMon.Size = new Size(104, 28);
            lblTenMon.TabIndex = 10;
            lblTenMon.Text = "Tên món: ";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(250, 300);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(200, 150);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // ClientForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(720, 480);
            Controls.Add(btn_connect);
            Controls.Add(btn_them);
            Controls.Add(btn_getAll);
            Controls.Add(tb_mon);
            Controls.Add(tb_hinh);
            Controls.Add(lv_monan);
            Controls.Add(lb_ten);
            Controls.Add(lb_status);
            Controls.Add(lblTenMon);
            Controls.Add(pictureBox1);
            Controls.Add(btn_chon);
            Name = "ClientForm";
            Text = "Client - Hôm nay ăn gì";
            Load += ClientForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
