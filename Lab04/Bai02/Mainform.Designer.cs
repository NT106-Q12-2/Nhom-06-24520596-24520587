namespace Bai02
{
    partial class MainForm : Form
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txt_url;
        private System.Windows.Forms.TextBox txt_save_path;
        private System.Windows.Forms.Button btn_download;
        private System.Windows.Forms.RichTextBox rtb_html;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txt_url = new TextBox();
            txt_save_path = new TextBox();
            btn_download = new Button();
            rtb_html = new RichTextBox();
            SuspendLayout();
            // 
            // txt_url
            // 
            txt_url.Location = new Point(10, 10);
            txt_url.Name = "txt_url";
            txt_url.Size = new Size(388, 27);
            txt_url.TabIndex = 0;
            // 
            // txt_save_path
            // 
            txt_save_path.Location = new Point(8, 37);
            txt_save_path.Name = "txt_save_path";
            txt_save_path.Size = new Size(490, 27);
            txt_save_path.TabIndex = 2;
            // 
            // btn_download
            // 
            btn_download.Location = new Point(404, 10);
            btn_download.Name = "btn_download";
            btn_download.Size = new Size(96, 27);
            btn_download.TabIndex = 1;
            btn_download.Text = "Download";
            btn_download.Click += btn_download_Click;
            // 
            // rtb_html
            // 
            rtb_html.Font = new Font("Consolas", 10F);
            rtb_html.Location = new Point(10, 70);
            rtb_html.Name = "rtb_html";
            rtb_html.ReadOnly = true;
            rtb_html.Size = new Size(490, 300);
            rtb_html.TabIndex = 3;
            rtb_html.Text = "";
            // 
            // MainForm
            // 
            BackColor = Color.SeaShell;
            ClientSize = new Size(510, 380);
            Controls.Add(txt_url);
            Controls.Add(btn_download);
            Controls.Add(txt_save_path);
            Controls.Add(rtb_html);
            ForeColor = Color.LightCoral;
            Name = "MainForm";
            Text = "Bai2";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
