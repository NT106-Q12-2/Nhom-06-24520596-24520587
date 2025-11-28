namespace Lab05_Bai01
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lbl_from;
        private System.Windows.Forms.TextBox tb_from;
        private System.Windows.Forms.Label lbl_to;
        private System.Windows.Forms.TextBox tb_to;
        private System.Windows.Forms.Label lbl_subject;
        private System.Windows.Forms.TextBox tb_subject;
        private System.Windows.Forms.Label lbl_body;
        private System.Windows.Forms.RichTextBox rtb_body;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Label lbl_status;

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
            this.lbl_from = new System.Windows.Forms.Label();
            this.tb_from = new System.Windows.Forms.TextBox();
            this.lbl_to = new System.Windows.Forms.Label();
            this.tb_to = new System.Windows.Forms.TextBox();
            this.lbl_subject = new System.Windows.Forms.Label();
            this.tb_subject = new System.Windows.Forms.TextBox();
            this.lbl_body = new System.Windows.Forms.Label();
            this.rtb_body = new System.Windows.Forms.RichTextBox();
            this.btn_send = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.lbl_status = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_from
            // 
            this.lbl_from.AutoSize = true;
            this.lbl_from.Location = new System.Drawing.Point(27, 25);
            this.lbl_from.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_from.Name = "lbl_from";
            this.lbl_from.Size = new System.Drawing.Size(41, 16);
            this.lbl_from.TabIndex = 0;
            this.lbl_from.Text = "From:";
            // 
            // tb_from
            // 
            this.tb_from.Location = new System.Drawing.Point(107, 21);
            this.tb_from.Margin = new System.Windows.Forms.Padding(4);
            this.tb_from.Name = "tb_from";
            this.tb_from.Size = new System.Drawing.Size(399, 22);
            this.tb_from.TabIndex = 1;
            // 
            // lbl_to
            // 
            this.lbl_to.AutoSize = true;
            this.lbl_to.Location = new System.Drawing.Point(27, 68);
            this.lbl_to.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_to.Name = "lbl_to";
            this.lbl_to.Size = new System.Drawing.Size(27, 16);
            this.lbl_to.TabIndex = 4;
            this.lbl_to.Text = "To:";
            // 
            // tb_to
            // 
            this.tb_to.Location = new System.Drawing.Point(107, 68);
            this.tb_to.Margin = new System.Windows.Forms.Padding(4);
            this.tb_to.Name = "tb_to";
            this.tb_to.Size = new System.Drawing.Size(399, 22);
            this.tb_to.TabIndex = 5;
            // 
            // lbl_subject
            // 
            this.lbl_subject.AutoSize = true;
            this.lbl_subject.Location = new System.Drawing.Point(27, 120);
            this.lbl_subject.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_subject.Name = "lbl_subject";
            this.lbl_subject.Size = new System.Drawing.Size(55, 16);
            this.lbl_subject.TabIndex = 6;
            this.lbl_subject.Text = "Subject:";
            // 
            // tb_subject
            // 
            this.tb_subject.Location = new System.Drawing.Point(107, 120);
            this.tb_subject.Margin = new System.Windows.Forms.Padding(4);
            this.tb_subject.Name = "tb_subject";
            this.tb_subject.Size = new System.Drawing.Size(399, 22);
            this.tb_subject.TabIndex = 7;
            // 
            // lbl_body
            // 
            this.lbl_body.AutoSize = true;
            this.lbl_body.Location = new System.Drawing.Point(27, 172);
            this.lbl_body.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_body.Name = "lbl_body";
            this.lbl_body.Size = new System.Drawing.Size(42, 16);
            this.lbl_body.TabIndex = 8;
            this.lbl_body.Text = "Body:";
            // 
            // rtb_body
            // 
            this.rtb_body.Location = new System.Drawing.Point(107, 169);
            this.rtb_body.Margin = new System.Windows.Forms.Padding(4);
            this.rtb_body.Name = "rtb_body";
            this.rtb_body.Size = new System.Drawing.Size(532, 184);
            this.rtb_body.TabIndex = 9;
            this.rtb_body.Text = "Hello,\nTest email.\nBest regard!";
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(107, 369);
            this.btn_send.Margin = new System.Windows.Forms.Padding(4);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(100, 28);
            this.btn_send.TabIndex = 10;
            this.btn_send.Text = "Send";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(227, 369);
            this.btn_clear.Margin = new System.Windows.Forms.Padding(4);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(100, 28);
            this.btn_clear.TabIndex = 11;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.Location = new System.Drawing.Point(50, 408);
            this.lbl_status.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(47, 16);
            this.lbl_status.TabIndex = 12;
            this.lbl_status.Text = "Status:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 443);
            this.Controls.Add(this.lbl_status);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.rtb_body);
            this.Controls.Add(this.lbl_body);
            this.Controls.Add(this.tb_subject);
            this.Controls.Add(this.lbl_subject);
            this.Controls.Add(this.tb_to);
            this.Controls.Add(this.lbl_to);
            this.Controls.Add(this.tb_from);
            this.Controls.Add(this.lbl_from);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "SMTP Email Client - Lab05";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}