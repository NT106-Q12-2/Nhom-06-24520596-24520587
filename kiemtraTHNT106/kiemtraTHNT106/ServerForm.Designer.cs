using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Test
{
    partial class ServerForm : Form
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Label lb_status;
        private System.Windows.Forms.ListView lv_log;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btn_start = new Button();
            lb_status = new Label();
            lv_log = new ListView();
            SuspendLayout();
            // 
            // btn_start
            // 
            btn_start.Font = new Font("Segoe UI", 12F);
            btn_start.Location = new Point(40, 30);
            btn_start.Name = "btn_start";
            btn_start.Size = new Size(120, 40);
            btn_start.TabIndex = 0;
            btn_start.Text = "Start Server";
            btn_start.Click += btn_start_Click;
            // 
            // lb_status
            // 
            lb_status.BackColor = Color.Coral;
            lb_status.Font = new Font("Segoe UI", 10F);
            lb_status.Location = new Point(180, 40);
            lb_status.Name = "lb_status";
            lb_status.Size = new Size(300, 30);
            lb_status.TabIndex = 1;
            lb_status.Text = "Trạng thái: not connected";
            // 
            // lv_log
            // 
            lv_log.Location = new Point(40, 90);
            lv_log.Name = "lv_log";
            lv_log.Size = new Size(440, 250);
            lv_log.TabIndex = 2;
            lv_log.UseCompatibleStateImageBehavior = false;
            lv_log.View = View.List;
            lv_log.SelectedIndexChanged += ServerForm_Load;
            // 
            // ServerForm
            // 
            BackColor = Color.BlanchedAlmond;
            ClientSize = new Size(520, 360);
            Controls.Add(btn_start);
            Controls.Add(lb_status);
            Controls.Add(lv_log);
            Name = "ServerForm";
            Text = "Server - Hôm nay ăn gì";
            Load += ServerForm_Load;
            ResumeLayout(false);
        }
    }
}
