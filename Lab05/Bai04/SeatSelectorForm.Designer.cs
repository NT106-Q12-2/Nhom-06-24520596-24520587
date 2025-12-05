namespace Bai04
{
    partial class SeatSelectorForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.FlowLayoutPanel flp_Seats;
        private System.Windows.Forms.Label lbl_Instruction;
        private System.Windows.Forms.Label lbl_SelectionCount;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_AutoSelect;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_Screen;

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
            this.flp_Seats = new System.Windows.Forms.FlowLayoutPanel();
            this.lbl_Instruction = new System.Windows.Forms.Label();
            this.lbl_SelectionCount = new System.Windows.Forms.Label();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_AutoSelect = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_Screen = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flp_Seats
            // 
            this.flp_Seats.AutoScroll = true;
            this.flp_Seats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flp_Seats.Location = new System.Drawing.Point(20, 80);
            this.flp_Seats.Name = "flp_Seats";
            this.flp_Seats.Size = new System.Drawing.Size(650, 300);
            this.flp_Seats.TabIndex = 0;
            // 
            // lbl_Instruction
            // 
            this.lbl_Instruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Instruction.Location = new System.Drawing.Point(20, 20);
            this.lbl_Instruction.Name = "lbl_Instruction";
            this.lbl_Instruction.Size = new System.Drawing.Size(300, 30);
            this.lbl_Instruction.TabIndex = 1;
            this.lbl_Instruction.Text = "Chọn ghế:";
            // 
            // lbl_SelectionCount
            // 
            this.lbl_SelectionCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SelectionCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.lbl_SelectionCount.Location = new System.Drawing.Point(350, 20);
            this.lbl_SelectionCount.Name = "lbl_SelectionCount";
            this.lbl_SelectionCount.Size = new System.Drawing.Size(150, 30);
            this.lbl_SelectionCount.TabIndex = 2;
            this.lbl_SelectionCount.Text = "Đã chọn: 0/0";
            this.lbl_SelectionCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_OK
            // 
            this.btn_OK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btn_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_OK.ForeColor = System.Drawing.Color.White;
            this.btn_OK.Location = new System.Drawing.Point(375, 400);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(189, 35);
            this.btn_OK.TabIndex = 3;
            this.btn_OK.Text = "Xác nhận";
            this.btn_OK.UseVisualStyleBackColor = false;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.Location = new System.Drawing.Point(570, 400);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(100, 35);
            this.btn_Cancel.TabIndex = 4;
            this.btn_Cancel.Text = "Hủy";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_AutoSelect
            // 
            this.btn_AutoSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btn_AutoSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AutoSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AutoSelect.ForeColor = System.Drawing.Color.White;
            this.btn_AutoSelect.Location = new System.Drawing.Point(20, 400);
            this.btn_AutoSelect.Name = "btn_AutoSelect";
            this.btn_AutoSelect.Size = new System.Drawing.Size(207, 35);
            this.btn_AutoSelect.TabIndex = 5;
            this.btn_AutoSelect.Text = "Chọn ghế tự động";
            this.btn_AutoSelect.UseVisualStyleBackColor = false;
            this.btn_AutoSelect.Click += new System.EventHandler(this.btn_AutoSelect_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.lbl_Screen);
            this.panel1.Location = new System.Drawing.Point(20, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(650, 25);
            this.panel1.TabIndex = 6;
            // 
            // lbl_Screen
            // 
            this.lbl_Screen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Screen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Screen.ForeColor = System.Drawing.Color.White;
            this.lbl_Screen.Location = new System.Drawing.Point(0, 0);
            this.lbl_Screen.Name = "lbl_Screen";
            this.lbl_Screen.Size = new System.Drawing.Size(650, 25);
            this.lbl_Screen.TabIndex = 0;
            this.lbl_Screen.Text = " MÀN HÌNH ";
            this.lbl_Screen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SeatSelectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(700, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_AutoSelect);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.lbl_SelectionCount);
            this.Controls.Add(this.lbl_Instruction);
            this.Controls.Add(this.flp_Seats);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SeatSelectorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chọn ghế - Cinema++";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}