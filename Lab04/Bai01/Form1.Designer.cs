namespace Bai01
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_url = new System.Windows.Forms.TextBox();
            this.btn_get = new System.Windows.Forms.Button();
            this.txt_html = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_url
            // 
            this.txt_url.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_url.Location = new System.Drawing.Point(12, 12);
            this.txt_url.Multiline = true;
            this.txt_url.Name = "txt_url";
            this.txt_url.Size = new System.Drawing.Size(621, 33);
            this.txt_url.TabIndex = 0;
            // 
            // btn_get
            // 
            this.btn_get.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_get.Location = new System.Drawing.Point(659, 12);
            this.btn_get.Name = "btn_get";
            this.btn_get.Size = new System.Drawing.Size(129, 37);
            this.btn_get.TabIndex = 1;
            this.btn_get.Text = "Get";
            this.btn_get.UseVisualStyleBackColor = true;
            this.btn_get.Click += new System.EventHandler(this.btn_get_Click);
            // 
            // txt_html
            // 
            this.txt_html.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_html.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_html.Location = new System.Drawing.Point(13, 78);
            this.txt_html.Multiline = true;
            this.txt_html.Name = "txt_html";
            this.txt_html.ReadOnly = true;
            this.txt_html.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_html.Size = new System.Drawing.Size(775, 360);
            this.txt_html.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_html);
            this.Controls.Add(this.btn_get);
            this.Controls.Add(this.txt_url);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_url;
        private System.Windows.Forms.Button btn_get;
        private System.Windows.Forms.TextBox txt_html;
    }
}

