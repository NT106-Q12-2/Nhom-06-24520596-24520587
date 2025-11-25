using System.Drawing;
using System.Windows.Forms;

namespace Bai04_
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btn_LoadMovies;
        private System.Windows.Forms.Button btn_RefreshFromWeb;
        private System.Windows.Forms.FlowLayoutPanel flp_Movies;
        private System.Windows.Forms.Label lbl_Status;
        private System.Windows.Forms.ProgressBar pb_Loading;
        private System.Windows.Forms.TextBox tb_CustomerName;
        private System.Windows.Forms.TextBox tb_PhoneNumber;
        private System.Windows.Forms.NumericUpDown nud_Tickets;
        private System.Windows.Forms.NumericUpDown nud_PricePerTicket;
        private System.Windows.Forms.Label lbl_TotalValue;
        private System.Windows.Forms.Button btn_BookTicket;
        private System.Windows.Forms.Label lbl_CustomerName;
        private System.Windows.Forms.Label lbl_PhoneNumber;
        private System.Windows.Forms.Label lbl_Tickets;
        private System.Windows.Forms.Label lbl_PricePerTicket;
        private System.Windows.Forms.Label lbl_Total;

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
            this.btn_LoadMovies = new System.Windows.Forms.Button();
            this.btn_RefreshFromWeb = new System.Windows.Forms.Button();
            this.flp_Movies = new System.Windows.Forms.FlowLayoutPanel();
            this.lbl_Status = new System.Windows.Forms.Label();
            this.pb_Loading = new System.Windows.Forms.ProgressBar();
            this.tb_CustomerName = new System.Windows.Forms.TextBox();
            this.tb_PhoneNumber = new System.Windows.Forms.TextBox();
            this.nud_Tickets = new System.Windows.Forms.NumericUpDown();
            this.nud_PricePerTicket = new System.Windows.Forms.NumericUpDown();
            this.lbl_TotalValue = new System.Windows.Forms.Label();
            this.btn_BookTicket = new System.Windows.Forms.Button();
            this.lbl_CustomerName = new System.Windows.Forms.Label();
            this.lbl_PhoneNumber = new System.Windows.Forms.Label();
            this.lbl_Tickets = new System.Windows.Forms.Label();
            this.lbl_PricePerTicket = new System.Windows.Forms.Label();
            this.lbl_Total = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Tickets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_PricePerTicket)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_LoadMovies
            // 
            this.btn_LoadMovies.Location = new System.Drawing.Point(20, 20);
            this.btn_LoadMovies.Name = "btn_LoadMovies";
            this.btn_LoadMovies.Size = new System.Drawing.Size(150, 40);
            this.btn_LoadMovies.TabIndex = 0;
            this.btn_LoadMovies.Text = "Tải từ Cache";
            this.btn_LoadMovies.UseVisualStyleBackColor = true;
            this.btn_LoadMovies.Click += new System.EventHandler(this.btn_LoadMovies_Click);
            // 
            // btn_RefreshFromWeb
            // 
            this.btn_RefreshFromWeb.Location = new System.Drawing.Point(180, 20);
            this.btn_RefreshFromWeb.Name = "btn_RefreshFromWeb";
            this.btn_RefreshFromWeb.Size = new System.Drawing.Size(150, 40);
            this.btn_RefreshFromWeb.TabIndex = 1;
            this.btn_RefreshFromWeb.Text = "Cập nhật từ Web";
            this.btn_RefreshFromWeb.UseVisualStyleBackColor = true;
            this.btn_RefreshFromWeb.Click += new System.EventHandler(this.btn_RefreshFromWeb_Click);
            // 
            // flp_Movies
            // 
            this.flp_Movies.AutoScroll = true;
            this.flp_Movies.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flp_Movies.Location = new System.Drawing.Point(20, 80);
            this.flp_Movies.Name = "flp_Movies";
            this.flp_Movies.Size = new System.Drawing.Size(900, 400);
            this.flp_Movies.TabIndex = 2;
            // 
            // lbl_Status
            // 
            this.lbl_Status.Location = new System.Drawing.Point(350, 20);
            this.lbl_Status.Name = "lbl_Status";
            this.lbl_Status.Size = new System.Drawing.Size(400, 40);
            this.lbl_Status.TabIndex = 3;
            this.lbl_Status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pb_Loading
            // 
            this.pb_Loading.Location = new System.Drawing.Point(760, 20);
            this.pb_Loading.Name = "pb_Loading";
            this.pb_Loading.Size = new System.Drawing.Size(160, 40);
            this.pb_Loading.TabIndex = 4;
            this.pb_Loading.Visible = false;
            // 
            // tb_CustomerName
            // 
            this.tb_CustomerName.Location = new System.Drawing.Point(130, 500);
            this.tb_CustomerName.Name = "tb_CustomerName";
            this.tb_CustomerName.Size = new System.Drawing.Size(200, 22);
            this.tb_CustomerName.TabIndex = 5;
            // 
            // tb_PhoneNumber
            // 
            this.tb_PhoneNumber.Location = new System.Drawing.Point(130, 540);
            this.tb_PhoneNumber.Name = "tb_PhoneNumber";
            this.tb_PhoneNumber.Size = new System.Drawing.Size(200, 22);
            this.tb_PhoneNumber.TabIndex = 6;
            // 
            // nud_Tickets
            // 
            this.nud_Tickets.Location = new System.Drawing.Point(130, 580);
            this.nud_Tickets.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_Tickets.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_Tickets.Name = "nud_Tickets";
            this.nud_Tickets.Size = new System.Drawing.Size(100, 22);
            this.nud_Tickets.TabIndex = 7;
            this.nud_Tickets.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_Tickets.ValueChanged += new System.EventHandler(this.nud_Tickets_ValueChanged);
            // 
            // nud_PricePerTicket
            // 
            this.nud_PricePerTicket.Location = new System.Drawing.Point(330, 580);
            this.nud_PricePerTicket.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nud_PricePerTicket.Name = "nud_PricePerTicket";
            this.nud_PricePerTicket.Size = new System.Drawing.Size(100, 22);
            this.nud_PricePerTicket.TabIndex = 8;
            this.nud_PricePerTicket.Value = new decimal(new int[] {
            80000,
            0,
            0,
            0});
            this.nud_PricePerTicket.ValueChanged += new System.EventHandler(this.nud_PricePerTicket_ValueChanged);
            // 
            // lbl_TotalValue
            // 
            this.lbl_TotalValue.Location = new System.Drawing.Point(130, 620);
            this.lbl_TotalValue.Name = "lbl_TotalValue";
            this.lbl_TotalValue.Size = new System.Drawing.Size(200, 20);
            this.lbl_TotalValue.TabIndex = 9;
            this.lbl_TotalValue.Text = "0 VNĐ";
            // 
            // btn_BookTicket
            // 
            this.btn_BookTicket.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btn_BookTicket.Enabled = true;
            this.btn_BookTicket.ForeColor = System.Drawing.Color.White;
            this.btn_BookTicket.Location = new System.Drawing.Point(350, 620);
            this.btn_BookTicket.Name = "btn_BookTicket";
            this.btn_BookTicket.Size = new System.Drawing.Size(120, 40);
            this.btn_BookTicket.TabIndex = 10;
            this.btn_BookTicket.Text = "Đặt Vé";
            this.btn_BookTicket.UseVisualStyleBackColor = false;
            this.btn_BookTicket.Click += new System.EventHandler(this.btn_BookTicket_Click);
            // 
            // lbl_CustomerName
            // 
            this.lbl_CustomerName.Location = new System.Drawing.Point(20, 500);
            this.lbl_CustomerName.Name = "lbl_CustomerName";
            this.lbl_CustomerName.Size = new System.Drawing.Size(100, 20);
            this.lbl_CustomerName.TabIndex = 11;
            this.lbl_CustomerName.Text = "Tên khách hàng:";
            // 
            // lbl_PhoneNumber
            // 
            this.lbl_PhoneNumber.Location = new System.Drawing.Point(20, 540);
            this.lbl_PhoneNumber.Name = "lbl_PhoneNumber";
            this.lbl_PhoneNumber.Size = new System.Drawing.Size(100, 20);
            this.lbl_PhoneNumber.TabIndex = 12;
            this.lbl_PhoneNumber.Text = "Số điện thoại:";
            // 
            // lbl_Tickets
            // 
            this.lbl_Tickets.Location = new System.Drawing.Point(20, 580);
            this.lbl_Tickets.Name = "lbl_Tickets";
            this.lbl_Tickets.Size = new System.Drawing.Size(100, 20);
            this.lbl_Tickets.TabIndex = 13;
            this.lbl_Tickets.Text = "Số lượng vé:";
            // 
            // lbl_PricePerTicket
            // 
            this.lbl_PricePerTicket.Location = new System.Drawing.Point(250, 580);
            this.lbl_PricePerTicket.Name = "lbl_PricePerTicket";
            this.lbl_PricePerTicket.Size = new System.Drawing.Size(80, 20);
            this.lbl_PricePerTicket.TabIndex = 14;
            this.lbl_PricePerTicket.Text = "Giá/vé:";
            // 
            // lbl_Total
            // 
            this.lbl_Total.Location = new System.Drawing.Point(20, 620);
            this.lbl_Total.Name = "lbl_Total";
            this.lbl_Total.Size = new System.Drawing.Size(100, 20);
            this.lbl_Total.TabIndex = 15;
            this.lbl_Total.Text = "Tổng tiền:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.Controls.Add(this.btn_LoadMovies);
            this.Controls.Add(this.btn_RefreshFromWeb);
            this.Controls.Add(this.flp_Movies);
            this.Controls.Add(this.lbl_Status);
            this.Controls.Add(this.pb_Loading);
            this.Controls.Add(this.tb_CustomerName);
            this.Controls.Add(this.tb_PhoneNumber);
            this.Controls.Add(this.nud_Tickets);
            this.Controls.Add(this.nud_PricePerTicket);
            this.Controls.Add(this.lbl_TotalValue);
            this.Controls.Add(this.btn_BookTicket);
            this.Controls.Add(this.lbl_CustomerName);
            this.Controls.Add(this.lbl_PhoneNumber);
            this.Controls.Add(this.lbl_Tickets);
            this.Controls.Add(this.lbl_PricePerTicket);
            this.Controls.Add(this.lbl_Total);
            this.Name = "Form1";
            this.Text = "Beta Cinemas - Quản lý phòng vé";
            ((System.ComponentModel.ISupportInitialize)(this.nud_Tickets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_PricePerTicket)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}