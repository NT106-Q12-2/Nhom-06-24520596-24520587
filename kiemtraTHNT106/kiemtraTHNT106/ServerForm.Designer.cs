using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Test
{
    partial class ServerForm : Form
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Label lb_status;
        private System.Windows.Forms.ListView lv_log;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btn_start = new System.Windows.Forms.Button();
            this.lb_status = new System.Windows.Forms.Label();
            this.lv_log = new System.Windows.Forms.ListView();
            this.dgv_quanly = new System.Windows.Forms.DataGridView();
            this.btn_charge = new System.Windows.Forms.Button();
            this.tb_table = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_tongtien = new System.Windows.Forms.TextBox();
            this.Table = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_quanly)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btn_start.Location = new System.Drawing.Point(40, 30);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(120, 40);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "Start Server";
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // lb_status
            // 
            this.lb_status.BackColor = System.Drawing.Color.PaleGreen;
            this.lb_status.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lb_status.Location = new System.Drawing.Point(180, 40);
            this.lb_status.Name = "lb_status";
            this.lb_status.Size = new System.Drawing.Size(300, 30);
            this.lb_status.TabIndex = 1;
            this.lb_status.Text = "Trạng thái: not connected";
            // 
            // lv_log
            // 
            this.lv_log.HideSelection = false;
            this.lv_log.Location = new System.Drawing.Point(27, 459);
            this.lv_log.Name = "lv_log";
            this.lv_log.Size = new System.Drawing.Size(1033, 202);
            this.lv_log.TabIndex = 2;
            this.lv_log.UseCompatibleStateImageBehavior = false;
            this.lv_log.View = System.Windows.Forms.View.List;
            // 
            // dgv_quanly
            // 
            this.dgv_quanly.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_quanly.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Table});
            this.dgv_quanly.Location = new System.Drawing.Point(27, 120);
            this.dgv_quanly.Name = "dgv_quanly";
            this.dgv_quanly.RowHeadersWidth = 51;
            this.dgv_quanly.RowTemplate.Height = 24;
            this.dgv_quanly.Size = new System.Drawing.Size(830, 319);
            this.dgv_quanly.TabIndex = 3;
            // 
            // btn_charge
            // 
            this.btn_charge.Location = new System.Drawing.Point(917, 255);
            this.btn_charge.Name = "btn_charge";
            this.btn_charge.Size = new System.Drawing.Size(101, 34);
            this.btn_charge.TabIndex = 4;
            this.btn_charge.Text = "charge";
            this.btn_charge.UseVisualStyleBackColor = true;
            this.btn_charge.Click += new System.EventHandler(this.btn_charge_Click);
            // 
            // tb_table
            // 
            this.tb_table.Location = new System.Drawing.Point(906, 227);
            this.tb_table.Name = "tb_table";
            this.tb_table.Size = new System.Drawing.Size(124, 22);
            this.tb_table.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(930, 208);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Enter Table";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(946, 305);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Amount";
            // 
            // tb_tongtien
            // 
            this.tb_tongtien.Location = new System.Drawing.Point(917, 324);
            this.tb_tongtien.Name = "tb_tongtien";
            this.tb_tongtien.Size = new System.Drawing.Size(100, 22);
            this.tb_tongtien.TabIndex = 8;
            // 
            // Table
            // 
            this.Table.HeaderText = "Table";
            this.Table.MinimumWidth = 6;
            this.Table.Name = "Table";
            this.Table.Width = 125;
            // 
            // ServerForm
            // 
            this.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ClientSize = new System.Drawing.Size(1072, 673);
            this.Controls.Add(this.tb_tongtien);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_table);
            this.Controls.Add(this.btn_charge);
            this.Controls.Add(this.dgv_quanly);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.lb_status);
            this.Controls.Add(this.lv_log);
            this.Name = "ServerForm";
            this.Text = "Server - Gọi món nhà hàng";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_quanly)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private DataGridView dgv_quanly;
        private Button btn_charge;
        private TextBox tb_table;
        private Label label1;
        private Label label2;
        private TextBox tb_tongtien;
        private DataGridViewTextBoxColumn Table;
    }
}
