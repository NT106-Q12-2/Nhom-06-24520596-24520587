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
            btn_OpenServer = new Button();
            btn_OpenClient = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // btn_OpenServer
            // 
            btn_OpenServer.BackColor = Color.Cornsilk;
            btn_OpenServer.Font = new Font("Segoe UI", 12F);
            btn_OpenServer.Location = new Point(70, 100);
            btn_OpenServer.Name = "btn_OpenServer";
            btn_OpenServer.Size = new Size(250, 50);
            btn_OpenServer.TabIndex = 1;
            btn_OpenServer.Text = "Open Server";
            btn_OpenServer.UseVisualStyleBackColor = false;
            btn_OpenServer.Click += btn_OpenServer_Click;
            // 
            // btn_OpenClient
            // 
            btn_OpenClient.BackColor = Color.DarkKhaki;
            btn_OpenClient.Font = new Font("Segoe UI", 12F);
            btn_OpenClient.Location = new Point(70, 170);
            btn_OpenClient.Name = "btn_OpenClient";
            btn_OpenClient.Size = new Size(250, 50);
            btn_OpenClient.TabIndex = 2;
            btn_OpenClient.Text = "Open Client";
            btn_OpenClient.UseVisualStyleBackColor = false;
            btn_OpenClient.Click += btn_OpenClient_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Control;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.ForeColor = Color.DarkSeaGreen;
            label1.Location = new Point(4, 9);
            label1.Name = "label1";
            label1.Size = new Size(398, 37);
            label1.TabIndex = 0;
            label1.Text = "HÔM NAY ĂN GÌ? ( Version 3 )";
            // 
            // Dashboard
            // 
            ClientSize = new Size(400, 260);
            Controls.Add(label1);
            Controls.Add(btn_OpenServer);
            Controls.Add(btn_OpenClient);
            Name = "Dashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard - Hôm Nay Ăn Gì?";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
