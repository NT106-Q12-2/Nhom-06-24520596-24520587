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
        private Button btn_placeorder;
        private ListView lv_monan;
        private Label lb_status;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btn_connect = new System.Windows.Forms.Button();
            this.btn_placeorder = new System.Windows.Forms.Button();
            this.lv_monan = new System.Windows.Forms.ListView();
            this.lb_status = new System.Windows.Forms.Label();
            this.btn_quit = new System.Windows.Forms.Button();
            this.lb_table = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_connect
            // 
            this.btn_connect.BackColor = System.Drawing.Color.DarkGreen;
            this.btn_connect.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btn_connect.Location = new System.Drawing.Point(30, 24);
            this.btn_connect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(120, 38);
            this.btn_connect.TabIndex = 0;
            this.btn_connect.Text = "Connect";
            this.btn_connect.UseVisualStyleBackColor = false;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // btn_placeorder
            // 
            this.btn_placeorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_placeorder.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_placeorder.Location = new System.Drawing.Point(241, 332);
            this.btn_placeorder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_placeorder.Name = "btn_placeorder";
            this.btn_placeorder.Size = new System.Drawing.Size(200, 36);
            this.btn_placeorder.TabIndex = 12;
            this.btn_placeorder.Text = "Place Order";
            this.btn_placeorder.UseVisualStyleBackColor = false;
            // 
            // lv_monan
            // 
            this.lv_monan.HideSelection = false;
            this.lv_monan.Location = new System.Drawing.Point(11, 67);
            this.lv_monan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lv_monan.Name = "lv_monan";
            this.lv_monan.Size = new System.Drawing.Size(699, 262);
            this.lv_monan.TabIndex = 5;
            this.lv_monan.UseCompatibleStateImageBehavior = false;
            this.lv_monan.View = System.Windows.Forms.View.List;
            // 
            // lb_status
            // 
            this.lb_status.Location = new System.Drawing.Point(164, 32);
            this.lb_status.Name = "lb_status";
            this.lb_status.Size = new System.Drawing.Size(257, 30);
            this.lb_status.TabIndex = 7;
            this.lb_status.Text = "Trạng thái: chưa kết nối";
            // 
            // btn_quit
            // 
            this.btn_quit.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_quit.Location = new System.Drawing.Point(556, 334);
            this.btn_quit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_quit.Name = "btn_quit";
            this.btn_quit.Size = new System.Drawing.Size(104, 33);
            this.btn_quit.TabIndex = 13;
            this.btn_quit.Text = "Quit";
            this.btn_quit.UseVisualStyleBackColor = true;
            // 
            // lb_table
            // 
            this.lb_table.AutoSize = true;
            this.lb_table.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_table.Location = new System.Drawing.Point(27, 341);
            this.lb_table.Name = "lb_table";
            this.lb_table.Size = new System.Drawing.Size(48, 19);
            this.lb_table.TabIndex = 14;
            this.lb_table.Text = "Table";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(82, 340);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(115, 22);
            this.textBox1.TabIndex = 15;
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 384);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lb_table);
            this.Controls.Add(this.btn_quit);
            this.Controls.Add(this.btn_connect);
            this.Controls.Add(this.lv_monan);
            this.Controls.Add(this.lb_status);
            this.Controls.Add(this.btn_placeorder);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ClientForm";
            this.Text = "Đặt món";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Button btn_quit;
        private Label lb_table;
        private TextBox textBox1;
    }
}
