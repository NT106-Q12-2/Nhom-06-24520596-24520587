using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Test
{
    partial class Dashboard : Form
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btn_OpenServer;
        private System.Windows.Forms.Button btn_OpenClient;
        private System.Windows.Forms.Label label1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btn_OpenServer = new System.Windows.Forms.Button();
            this.btn_OpenClient = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_OpenServer
            // 
            this.btn_OpenServer.BackColor = System.Drawing.Color.Cornsilk;
            this.btn_OpenServer.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btn_OpenServer.Location = new System.Drawing.Point(70, 100);
            this.btn_OpenServer.Name = "btn_OpenServer";
            this.btn_OpenServer.Size = new System.Drawing.Size(250, 50);
            this.btn_OpenServer.TabIndex = 1;
            this.btn_OpenServer.Text = "Open Server";
            this.btn_OpenServer.UseVisualStyleBackColor = false;
            this.btn_OpenServer.Click += new System.EventHandler(this.btn_OpenServer_Click);
            // 
            // btn_OpenClient
            // 
            this.btn_OpenClient.BackColor = System.Drawing.Color.DarkKhaki;
            this.btn_OpenClient.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btn_OpenClient.Location = new System.Drawing.Point(70, 170);
            this.btn_OpenClient.Name = "btn_OpenClient";
            this.btn_OpenClient.Size = new System.Drawing.Size(250, 50);
            this.btn_OpenClient.TabIndex = 2;
            this.btn_OpenClient.Text = "Open Client";
            this.btn_OpenClient.UseVisualStyleBackColor = false;
            this.btn_OpenClient.Click += new System.EventHandler(this.btn_OpenClient_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.label1.Location = new System.Drawing.Point(63, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đặt Món Nhà Hàng";
            // 
            // Dashboard
            // 
            this.ClientSize = new System.Drawing.Size(400, 260);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_OpenServer);
            this.Controls.Add(this.btn_OpenClient);
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard - Hôm Nay Ăn Gì?";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
