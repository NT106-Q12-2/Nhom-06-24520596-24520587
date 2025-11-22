using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bai03_
{
    public partial class SourceViewerForm : Form
    {
        public SourceViewerForm(string htmlSource)
        {
            InitializeComponent();
            rtb_source.Text = htmlSource;
        }

        private System.ComponentModel.IContainer components = null;
        private RichTextBox rtb_source;

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
            this.rtb_source = new RichTextBox();
            this.SuspendLayout();
            // 
            // rtb_source
            // 
            this.rtb_source.BackColor = Color.White;
            this.rtb_source.Dock = DockStyle.Fill;
            this.rtb_source.Font = new Font("Consolas", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.rtb_source.Location = new Point(0, 0);
            this.rtb_source.Name = "rtb_source";
            this.rtb_source.ReadOnly = true;
            this.rtb_source.Size = new Size(800, 450);
            this.rtb_source.TabIndex = 0;
            this.rtb_source.Text = "";
            this.rtb_source.WordWrap = false;
            // 
            // SourceViewerForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 450);
            this.Controls.Add(this.rtb_source);
            this.Name = "SourceViewerForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "View Source - HTML";
            this.ResumeLayout(false);
        }
    }
}