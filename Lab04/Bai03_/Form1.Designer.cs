using System.Drawing;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;

namespace Bai03_
{
    partial class Form1 : Form 
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panel_top;
        private Button btn_load;
        private TextBox tb_url;
        private Button btn_reload;
        private Button btn_down_files;
        private Button btn_down_resources;
        private WebView2 webView2_browser;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem viewSourceToolStripMenuItem;
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
            this.panel_top = new System.Windows.Forms.Panel();
            this.btn_load = new System.Windows.Forms.Button();
            this.tb_url = new System.Windows.Forms.TextBox();
            this.btn_reload = new System.Windows.Forms.Button();
            this.btn_down_files = new System.Windows.Forms.Button();
            this.btn_down_resources = new System.Windows.Forms.Button();
            this.webView2_browser = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webView2_browser)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_top
            // 
            this.panel_top.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel_top.Controls.Add(this.btn_load);
            this.panel_top.Controls.Add(this.tb_url);
            this.panel_top.Controls.Add(this.btn_reload);
            this.panel_top.Controls.Add(this.btn_down_files);
            this.panel_top.Controls.Add(this.btn_down_resources);
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_top.Location = new System.Drawing.Point(0, 28);
            this.panel_top.Name = "panel_top";
            this.panel_top.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panel_top.Size = new System.Drawing.Size(914, 53);
            this.panel_top.TabIndex = 1;
            // 
            // btn_load
            // 
            this.btn_load.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btn_load.Location = new System.Drawing.Point(9, 11);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(80, 32);
            this.btn_load.TabIndex = 0;
            this.btn_load.Text = "Load";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // tb_url
            // 
            this.tb_url.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tb_url.Location = new System.Drawing.Point(96, 13);
            this.tb_url.Name = "tb_url";
            this.tb_url.Size = new System.Drawing.Size(457, 30);
            this.tb_url.TabIndex = 1;
            this.tb_url.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_url_KeyDown);
            // 
            // btn_reload
            // 
            this.btn_reload.Location = new System.Drawing.Point(560, 11);
            this.btn_reload.Name = "btn_reload";
            this.btn_reload.Size = new System.Drawing.Size(80, 32);
            this.btn_reload.TabIndex = 2;
            this.btn_reload.Text = "reload";
            this.btn_reload.UseVisualStyleBackColor = true;
            this.btn_reload.Click += new System.EventHandler(this.btn_reload_Click);
            // 
            // btn_down_files
            // 
            this.btn_down_files.Location = new System.Drawing.Point(647, 11);
            this.btn_down_files.Name = "btn_down_files";
            this.btn_down_files.Size = new System.Drawing.Size(114, 32);
            this.btn_down_files.TabIndex = 3;
            this.btn_down_files.Text = "Down Files";
            this.btn_down_files.UseVisualStyleBackColor = true;
            this.btn_down_files.Click += new System.EventHandler(this.btn_down_files_Click);
            // 
            // btn_down_resources
            // 
            this.btn_down_resources.Location = new System.Drawing.Point(768, 11);
            this.btn_down_resources.Name = "btn_down_resources";
            this.btn_down_resources.Size = new System.Drawing.Size(137, 32);
            this.btn_down_resources.TabIndex = 4;
            this.btn_down_resources.Text = "Down Resources";
            this.btn_down_resources.UseVisualStyleBackColor = true;
            this.btn_down_resources.Click += new System.EventHandler(this.btn_down_resources_Click);
            // 
            // webView2_browser
            // 
            this.webView2_browser.AllowExternalDrop = true;
            this.webView2_browser.CreationProperties = null;
            this.webView2_browser.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView2_browser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webView2_browser.Location = new System.Drawing.Point(0, 81);
            this.webView2_browser.Name = "webView2_browser";
            this.webView2_browser.Size = new System.Drawing.Size(914, 399);
            this.webView2_browser.TabIndex = 2;
            this.webView2_browser.ZoomFactor = 1D;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(914, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewSourceToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // viewSourceToolStripMenuItem
            // 
            this.viewSourceToolStripMenuItem.Name = "viewSourceToolStripMenuItem";
            this.viewSourceToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.viewSourceToolStripMenuItem.Text = "View Source";
            this.viewSourceToolStripMenuItem.Click += new System.EventHandler(this.viewSourceToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 480);
            this.Controls.Add(this.webView2_browser);
            this.Controls.Add(this.panel_top);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bai3 - Web Browser";
            this.panel_top.ResumeLayout(false);
            this.panel_top.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webView2_browser)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}