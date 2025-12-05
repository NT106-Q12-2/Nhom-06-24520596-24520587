using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Bai04
{
    public partial class SeatSelectorForm : Form
    {
        private List<string> _selectedSeats = new List<string>();
        private int _requiredSeats;
        private List<CheckBox> _seatCheckboxes = new List<CheckBox>();

        public List<string> SelectedSeats => _selectedSeats;

        public SeatSelectorForm(int numberOfTickets)
        {
            InitializeComponent();
            _requiredSeats = numberOfTickets;
            InitializeSeats();
            UpdateSelectionCount();
        }

        private void InitializeSeats()
        {
            flp_Seats.Controls.Clear();
            _seatCheckboxes.Clear();
            for (char row = 'A'; row <= 'E'; row++)
            {
                var lblRow = new Label
                {
                    Text = $"Hàng {row}:",
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    Size = new Size(70, 30),
                    TextAlign = ContentAlignment.MiddleLeft
                };
                flp_Seats.Controls.Add(lblRow);

                for (int col = 1; col <= 10; col++)
                {
                    var seat = $"{row}{col}";
                    var chk = new CheckBox
                    {
                        Text = seat,
                        Tag = seat,
                        Size = new Size(50, 30),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Appearance = Appearance.Button,
                        FlatStyle = FlatStyle.Flat
                    };

                    chk.FlatAppearance.BorderColor = Color.Gray;
                    chk.FlatAppearance.BorderSize = 1;
                    chk.FlatAppearance.CheckedBackColor = Color.FromArgb(0, 120, 215);
                    chk.FlatAppearance.MouseDownBackColor = Color.LightBlue;
                    chk.FlatAppearance.MouseOverBackColor = Color.LightGray;

                    chk.CheckedChanged += SeatCheckbox_CheckedChanged;

                    flp_Seats.Controls.Add(chk);
                    _seatCheckboxes.Add(chk);
                }

                flp_Seats.SetFlowBreak(flp_Seats.Controls[flp_Seats.Controls.Count - 1], true);
            }
        }

        private void SeatCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            var chk = (CheckBox)sender;
            var seat = chk.Tag.ToString();

            if (chk.Checked)
            {
                if (_selectedSeats.Count >= _requiredSeats)
                {
                    chk.Checked = false;
                    MessageBox.Show($"Chỉ được chọn {_requiredSeats} ghế!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                _selectedSeats.Add(seat);
                chk.ForeColor = Color.White;
            }
            else
            {
                _selectedSeats.Remove(seat);
                chk.ForeColor = Color.Black;
            }

            UpdateSelectionCount();
        }

        private void UpdateSelectionCount()
        {
            lbl_SelectionCount.Text = $"Đã chọn: {_selectedSeats.Count}/{_requiredSeats}";
            btn_OK.Enabled = _selectedSeats.Count == _requiredSeats;
            btn_OK.BackColor = btn_OK.Enabled ?
                Color.FromArgb(0, 120, 215) : Color.Gray;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (_selectedSeats.Count == _requiredSeats)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show($"Vui lòng chọn đủ {_requiredSeats} ghế!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btn_AutoSelect_Click(object sender, EventArgs e)
        {
            AutoSelectSeats();
        }

        private void AutoSelectSeats()
        {
            foreach (var chk in _seatCheckboxes)
            {
                chk.Checked = false;
            }
            _selectedSeats.Clear();

            int selected = 0;
            foreach (var chk in _seatCheckboxes)
            {
                if (selected >= _requiredSeats) break;

                chk.Checked = true;
                selected++;
            }
        }
    }
}