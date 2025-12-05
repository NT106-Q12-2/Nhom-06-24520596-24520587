namespace Bai04.Controls
{
    partial class MovieCard
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox pic_Poster;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.Button btn_ViewDetails;

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
            this.pic_Poster = new System.Windows.Forms.PictureBox();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.btn_ViewDetails = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Poster)).BeginInit();
            this.SuspendLayout();

            // pic_Poster
            this.pic_Poster.Location = new System.Drawing.Point(10, 10);
            this.pic_Poster.Name = "pic_Poster";
            this.pic_Poster.Size = new System.Drawing.Size(160, 220);
            this.pic_Poster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_Poster.TabIndex = 0;
            this.pic_Poster.TabStop = false;
            this.pic_Poster.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_Poster.Click += new System.EventHandler(this.HandleClick);

            // lbl_Title
            this.lbl_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Title.Location = new System.Drawing.Point(10, 240);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(160, 30);
            this.lbl_Title.TabIndex = 1;
            this.lbl_Title.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbl_Title.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Title.Click += new System.EventHandler(this.HandleClick);

            // btn_ViewDetails
            this.btn_ViewDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btn_ViewDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ViewDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ViewDetails.ForeColor = System.Drawing.Color.White;
            this.btn_ViewDetails.Location = new System.Drawing.Point(10, 275);
            this.btn_ViewDetails.Name = "btn_ViewDetails";
            this.btn_ViewDetails.Size = new System.Drawing.Size(160, 25);
            this.btn_ViewDetails.TabIndex = 2;
            this.btn_ViewDetails.Text = "Xem Chi Tiết";
            this.btn_ViewDetails.UseVisualStyleBackColor = false;
            this.btn_ViewDetails.Click += new System.EventHandler(this.btn_ViewDetails_Click);

            // MovieCard
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btn_ViewDetails);
            this.Controls.Add(this.lbl_Title);
            this.Controls.Add(this.pic_Poster);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Margin = new System.Windows.Forms.Padding(10);
            this.Name = "MovieCard";
            this.Size = new System.Drawing.Size(180, 310);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Poster)).EndInit();
            this.ResumeLayout(false);
        }
    }
}