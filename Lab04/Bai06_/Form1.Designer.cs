namespace Bai06_
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblToken;
        private System.Windows.Forms.TextBox tb_token;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.RichTextBox rtb_result;

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
            this.lblToken = new System.Windows.Forms.Label();
            this.tb_token = new System.Windows.Forms.TextBox();
            this.btnGet = new System.Windows.Forms.Button();
            this.rtb_result = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lblToken
            // 
            this.lblToken.AutoSize = true;
            this.lblToken.Location = new System.Drawing.Point(30, 31);
            this.lblToken.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblToken.Name = "lblToken";
            this.lblToken.Size = new System.Drawing.Size(109, 20);
            this.lblToken.TabIndex = 0;
            this.lblToken.Text = "Bearer Token:";
            // 
            // tb_token
            // 
            this.tb_token.Location = new System.Drawing.Point(30, 62);
            this.tb_token.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_token.Name = "tb_token";
            this.tb_token.Size = new System.Drawing.Size(973, 26);
            this.tb_token.TabIndex = 1;
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(1020, 58);
            this.btnGet.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(150, 37);
            this.btnGet.TabIndex = 2;
            this.btnGet.Text = "GET";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // rtb_result
            // 
            this.rtb_result.Location = new System.Drawing.Point(30, 123);
            this.rtb_result.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rtb_result.Name = "rtb_result";
            this.rtb_result.Size = new System.Drawing.Size(1138, 536);
            this.rtb_result.TabIndex = 3;
            this.rtb_result.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.rtb_result);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.tb_token);
            this.Controls.Add(this.lblToken);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Bài 6 - HTTP GET";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}