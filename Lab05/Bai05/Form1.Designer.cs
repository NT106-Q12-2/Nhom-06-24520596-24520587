namespace Bai05
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddFood = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvFoodList = new System.Windows.Forms.DataGridView();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFoodName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContributor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnPickRandom = new System.Windows.Forms.Button();
            this.pictureBoxFood = new System.Windows.Forms.PictureBox();
            this.lblFoodContributor = new System.Windows.Forms.Label();
            this.lblFoodName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFoodList)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFood)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.btnAddFood);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1390, 108);
            this.panel1.TabIndex = 0;
            // 
            // btnAddFood
            // 
            this.btnAddFood.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnAddFood.FlatAppearance.BorderSize = 0;
            this.btnAddFood.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFood.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddFood.ForeColor = System.Drawing.Color.White;
            this.btnAddFood.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddFood.Location = new System.Drawing.Point(998, 29);
            this.btnAddFood.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddFood.Name = "btnAddFood";
            this.btnAddFood.Size = new System.Drawing.Size(240, 54);
            this.btnAddFood.TabIndex = 1;
            this.btnAddFood.Text = "   Thêm món ăn";
            this.btnAddFood.UseVisualStyleBackColor = false;
            this.btnAddFood.Click += new System.EventHandler(this.btnAddFood_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(30, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(336, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = " HÔM NAY ĂN GÌ?";
            // 
            // dgvFoodList
            // 
            this.dgvFoodList.AllowUserToAddRows = false;
            this.dgvFoodList.AllowUserToDeleteRows = false;
            this.dgvFoodList.AllowUserToResizeRows = false;
            this.dgvFoodList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFoodList.BackgroundColor = System.Drawing.Color.White;
            this.dgvFoodList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvFoodList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle34.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle34.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle34.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle34.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle34.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle34.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFoodList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle34;
            this.dgvFoodList.ColumnHeadersHeight = 40;
            this.dgvFoodList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSTT,
            this.colFoodName,
            this.colContributor,
            this.colDate});
            dataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle35.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle35.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle35.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle35.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle35.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle35.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle35.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFoodList.DefaultCellStyle = dataGridViewCellStyle35;
            this.dgvFoodList.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvFoodList.EnableHeadersVisualStyles = false;
            this.dgvFoodList.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvFoodList.Location = new System.Drawing.Point(0, 108);
            this.dgvFoodList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvFoodList.Name = "dgvFoodList";
            this.dgvFoodList.ReadOnly = true;
            dataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle36.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle36.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle36.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle36.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle36.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFoodList.RowHeadersDefaultCellStyle = dataGridViewCellStyle36;
            this.dgvFoodList.RowHeadersVisible = false;
            this.dgvFoodList.RowHeadersWidth = 62;
            this.dgvFoodList.RowTemplate.Height = 35;
            this.dgvFoodList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFoodList.Size = new System.Drawing.Size(825, 815);
            this.dgvFoodList.TabIndex = 1;
            this.dgvFoodList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFoodList_CellClick);
            // 
            // colSTT
            // 
            this.colSTT.FillWeight = 15F;
            this.colSTT.HeaderText = "STT";
            this.colSTT.MinimumWidth = 8;
            this.colSTT.Name = "colSTT";
            this.colSTT.ReadOnly = true;
            // 
            // colFoodName
            // 
            this.colFoodName.FillWeight = 40F;
            this.colFoodName.HeaderText = "Món ăn";
            this.colFoodName.MinimumWidth = 8;
            this.colFoodName.Name = "colFoodName";
            this.colFoodName.ReadOnly = true;
            // 
            // colContributor
            // 
            this.colContributor.FillWeight = 25F;
            this.colContributor.HeaderText = "Người đóng góp";
            this.colContributor.MinimumWidth = 8;
            this.colContributor.Name = "colContributor";
            this.colContributor.ReadOnly = true;
            // 
            // colDate
            // 
            this.colDate.FillWeight = 20F;
            this.colDate.HeaderText = "Ngày thêm";
            this.colDate.MinimumWidth = 8;
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lblResult);
            this.panel2.Controls.Add(this.btnPickRandom);
            this.panel2.Controls.Add(this.pictureBoxFood);
            this.panel2.Controls.Add(this.lblFoodContributor);
            this.panel2.Controls.Add(this.lblFoodName);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(825, 108);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(565, 815);
            this.panel2.TabIndex = 2;
            // 
            // lblResult
            // 
            this.lblResult.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.lblResult.Location = new System.Drawing.Point(55, 512);
            this.lblResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(406, 92);
            this.lblResult.TabIndex = 7;
            this.lblResult.Text = "Chưa chọn món ăn";
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPickRandom
            // 
            this.btnPickRandom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(39)))), ((int)(((byte)(176)))));
            this.btnPickRandom.FlatAppearance.BorderSize = 0;
            this.btnPickRandom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPickRandom.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPickRandom.ForeColor = System.Drawing.Color.White;
            this.btnPickRandom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPickRandom.Location = new System.Drawing.Point(211, 426);
            this.btnPickRandom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPickRandom.Name = "btnPickRandom";
            this.btnPickRandom.Size = new System.Drawing.Size(202, 81);
            this.btnPickRandom.TabIndex = 6;
            this.btnPickRandom.Text = "CHỌN MÓN NGẪU NHIÊN";
            this.btnPickRandom.UseVisualStyleBackColor = false;
            this.btnPickRandom.Click += new System.EventHandler(this.btnPickRandom_Click);
            // 
            // pictureBoxFood
            // 
            this.pictureBoxFood.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureBoxFood.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxFood.Location = new System.Drawing.Point(173, 165);
            this.pictureBoxFood.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBoxFood.Name = "pictureBoxFood";
            this.pictureBoxFood.Size = new System.Drawing.Size(277, 235);
            this.pictureBoxFood.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxFood.TabIndex = 5;
            this.pictureBoxFood.TabStop = false;
            // 
            // lblFoodContributor
            // 
            this.lblFoodContributor.AutoSize = true;
            this.lblFoodContributor.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFoodContributor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.lblFoodContributor.Location = new System.Drawing.Point(206, 107);
            this.lblFoodContributor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFoodContributor.Name = "lblFoodContributor";
            this.lblFoodContributor.Size = new System.Drawing.Size(0, 26);
            this.lblFoodContributor.TabIndex = 4;
            // 
            // lblFoodName
            // 
            this.lblFoodName.AutoSize = true;
            this.lblFoodName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFoodName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.lblFoodName.Location = new System.Drawing.Point(127, 35);
            this.lblFoodName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFoodName.Name = "lblFoodName";
            this.lblFoodName.Size = new System.Drawing.Size(0, 26);
            this.lblFoodName.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label4.Location = new System.Drawing.Point(45, 178);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "Hình ảnh:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label3.Location = new System.Drawing.Point(45, 108);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Người đóng góp:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label2.Location = new System.Drawing.Point(45, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Món ăn:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1390, 923);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvFoodList);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hôm nay ăn gì? - Bài 5";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFoodList)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFood)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAddFood;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvFoodList;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnPickRandom;
        private System.Windows.Forms.PictureBox pictureBoxFood;
        private System.Windows.Forms.Label lblFoodContributor;
        private System.Windows.Forms.Label lblFoodName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFoodName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContributor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
    }
}