namespace EmailClientApp
{
    partial class FormSendMail
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tb_From = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_Name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_To = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_Subject = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rtb_Body = new System.Windows.Forms.RichTextBox();
            this.cb_HTML = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_Attachment = new System.Windows.Forms.TextBox();
            this.btn_Browse = new System.Windows.Forms.Button();
            this.btn_SendMail = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_ClearAttachment = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(20, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "From:";
            // 
            // tb_From
            // 
            this.tb_From.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tb_From.Location = new System.Drawing.Point(120, 22);
            this.tb_From.Name = "tb_From";
            this.tb_From.ReadOnly = true;
            this.tb_From.Size = new System.Drawing.Size(350, 23);
            this.tb_From.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(20, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name:";
            // 
            // tb_Name
            // 
            this.tb_Name.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tb_Name.Location = new System.Drawing.Point(120, 57);
            this.tb_Name.Name = "tb_Name";
            this.tb_Name.Size = new System.Drawing.Size(350, 23);
            this.tb_Name.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(20, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "To:";
            // 
            // tb_To
            // 
            this.tb_To.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tb_To.Location = new System.Drawing.Point(120, 92);
            this.tb_To.Name = "tb_To";
            this.tb_To.Size = new System.Drawing.Size(350, 23);
            this.tb_To.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(20, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Subject:";
            // 
            // tb_Subject
            // 
            this.tb_Subject.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tb_Subject.Location = new System.Drawing.Point(120, 127);
            this.tb_Subject.Name = "tb_Subject";
            this.tb_Subject.Size = new System.Drawing.Size(560, 23);
            this.tb_Subject.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(20, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Body:";
            // 
            // rtb_Body
            // 
            this.rtb_Body.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rtb_Body.Location = new System.Drawing.Point(20, 190);
            this.rtb_Body.Name = "rtb_Body";
            this.rtb_Body.Size = new System.Drawing.Size(660, 200);
            this.rtb_Body.TabIndex = 9;
            this.rtb_Body.Text = "";
            // 
            // cb_HTML
            // 
            this.cb_HTML.AutoSize = true;
            this.cb_HTML.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cb_HTML.Location = new System.Drawing.Point(20, 405);
            this.cb_HTML.Name = "cb_HTML";
            this.cb_HTML.Size = new System.Drawing.Size(141, 19);
            this.cb_HTML.TabIndex = 10;
            this.cb_HTML.Text = "Gửi dưới dạng HTML";
            this.cb_HTML.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(20, 440);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Attachment:";
            // 
            // tb_Attachment
            // 
            this.tb_Attachment.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tb_Attachment.Location = new System.Drawing.Point(120, 437);
            this.tb_Attachment.Name = "tb_Attachment";
            this.tb_Attachment.ReadOnly = true;
            this.tb_Attachment.Size = new System.Drawing.Size(350, 23);
            this.tb_Attachment.TabIndex = 12;
            // 
            // btn_Browse
            // 
            this.btn_Browse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this.btn_Browse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Browse.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btn_Browse.ForeColor = System.Drawing.Color.White;
            this.btn_Browse.Location = new System.Drawing.Point(490, 432);
            this.btn_Browse.Name = "btn_Browse";
            this.btn_Browse.Size = new System.Drawing.Size(90, 30);
            this.btn_Browse.TabIndex = 13;
            this.btn_Browse.Text = "Browse...";
            this.btn_Browse.UseVisualStyleBackColor = false;
            this.btn_Browse.Click += new System.EventHandler(this.btn_Browse_Click);
            // 
            // btn_SendMail
            // 
            this.btn_SendMail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btn_SendMail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SendMail.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btn_SendMail.ForeColor = System.Drawing.Color.White;
            this.btn_SendMail.Location = new System.Drawing.Point(20, 490);
            this.btn_SendMail.Name = "btn_SendMail";
            this.btn_SendMail.Size = new System.Drawing.Size(120, 40);
            this.btn_SendMail.TabIndex = 14;
            this.btn_SendMail.Text = "Gửi mail";
            this.btn_SendMail.UseVisualStyleBackColor = false;
            this.btn_SendMail.Click += new System.EventHandler(this.btn_SendMail_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.Gray;
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btn_Cancel.ForeColor = System.Drawing.Color.White;
            this.btn_Cancel.Location = new System.Drawing.Point(560, 490);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(120, 40);
            this.btn_Cancel.TabIndex = 15;
            this.btn_Cancel.Text = "Hủy";
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_ClearAttachment
            // 
            this.btn_ClearAttachment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btn_ClearAttachment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ClearAttachment.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btn_ClearAttachment.ForeColor = System.Drawing.Color.White;
            this.btn_ClearAttachment.Location = new System.Drawing.Point(590, 432);
            this.btn_ClearAttachment.Name = "btn_ClearAttachment";
            this.btn_ClearAttachment.Size = new System.Drawing.Size(90, 30);
            this.btn_ClearAttachment.TabIndex = 16;
            this.btn_ClearAttachment.Text = "Clear";
            this.btn_ClearAttachment.UseVisualStyleBackColor = false;
            this.btn_ClearAttachment.Click += new System.EventHandler(this.btn_ClearAttachment_Click);
            // 
            // FormSendMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 551);
            this.Controls.Add(this.btn_ClearAttachment);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_SendMail);
            this.Controls.Add(this.btn_Browse);
            this.Controls.Add(this.tb_Attachment);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cb_HTML);
            this.Controls.Add(this.rtb_Body);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_Subject);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_To);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_Name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_From);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormSendMail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gửi Email";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_From;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_Name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_To;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_Subject;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox rtb_Body;
        private System.Windows.Forms.CheckBox cb_HTML;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_Attachment;
        private System.Windows.Forms.Button btn_Browse;
        private System.Windows.Forms.Button btn_SendMail;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_ClearAttachment;
    }
}