namespace EmailClientApp
{
    partial class FormReadMail
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
            this.tb_To = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_Subject = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.wb_Body = new System.Windows.Forms.WebBrowser();
            this.btn_Reply = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
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
            this.tb_From.Location = new System.Drawing.Point(80, 22);
            this.tb_From.Name = "tb_From";
            this.tb_From.ReadOnly = true;
            this.tb_From.Size = new System.Drawing.Size(640, 23);
            this.tb_From.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(20, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "To:";
            // 
            // tb_To
            // 
            this.tb_To.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tb_To.Location = new System.Drawing.Point(80, 57);
            this.tb_To.Name = "tb_To";
            this.tb_To.ReadOnly = true;
            this.tb_To.Size = new System.Drawing.Size(640, 23);
            this.tb_To.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(20, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Subject:";
            // 
            // tb_Subject
            // 
            this.tb_Subject.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tb_Subject.Location = new System.Drawing.Point(80, 92);
            this.tb_Subject.Name = "tb_Subject";
            this.tb_Subject.ReadOnly = true;
            this.tb_Subject.Size = new System.Drawing.Size(640, 23);
            this.tb_Subject.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(20, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Body:";
            // 
            // wb_Body
            // 
            this.wb_Body.Location = new System.Drawing.Point(20, 155);
            this.wb_Body.MinimumSize = new System.Drawing.Size(20, 20);
            this.wb_Body.Name = "wb_Body";
            this.wb_Body.Size = new System.Drawing.Size(700, 350);
            this.wb_Body.TabIndex = 7;
            // 
            // btn_Reply
            // 
            this.btn_Reply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btn_Reply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Reply.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btn_Reply.ForeColor = System.Drawing.Color.White;
            this.btn_Reply.Location = new System.Drawing.Point(20, 520);
            this.btn_Reply.Name = "btn_Reply";
            this.btn_Reply.Size = new System.Drawing.Size(100, 35);
            this.btn_Reply.TabIndex = 8;
            this.btn_Reply.Text = "Reply";
            this.btn_Reply.UseVisualStyleBackColor = false;
            this.btn_Reply.Click += new System.EventHandler(this.btn_Reply_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.Gray;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btn_Close.ForeColor = System.Drawing.Color.White;
            this.btn_Close.Location = new System.Drawing.Point(620, 520);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(100, 35);
            this.btn_Close.TabIndex = 9;
            this.btn_Close.Text = "Đóng";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // FormReadMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 571);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Reply);
            this.Controls.Add(this.wb_Body);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_Subject);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_To);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_From);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormReadMail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đọc Email";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_From;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_To;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_Subject;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.WebBrowser wb_Body;
        private System.Windows.Forms.Button btn_Reply;
        private System.Windows.Forms.Button btn_Close;
    }
}