using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Bai05
{
    public partial class Form1 : Form
    {
        private List<FoodItem> foodList = new List<FoodItem>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSampleData();
            ClearSelection();
        }

        private void LoadSampleData()
        {
            try
            {
                AddFoodToList("Phở Bò Hà Nội",
                    "https://static.vinwonders.com/production/pho-bo-ha-noi.jpeg",
                    "Lê Tiến Hưng",
                    "nguyenvana@gmail.com");

                AddFoodToList("Bánh Mì Sài Gòn",
                    "https://static.vinwonders.com/production/banh-mi-sai-gon-banner.jpg",
                    "Hoàng Phi Hùng",
                    "tranthib@gmail.com");

                AddFoodToList("Cơm Tấm Sườn Nướng",
                    "https://cdn.tgdd.vn/Files/2021/08/16/1375565/cach-nau-com-tam-suon-bi-cha-tai-nha-ngon-nhu-ngoai-tiem-202108162216045436.jpg",
                    "Lee Min Hoo",
                    "levanc@gmail.com");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu mẫu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            AddFoodForm addForm = new AddFoodForm();
            addForm.FoodAdded += AddForm_FoodAdded;
            addForm.ShowDialog();
        }

        private void AddForm_FoodAdded(object sender, FoodItem foodItem)
        {
            AddFoodToList(foodItem.FoodName, foodItem.ImagePath, foodItem.Contributor, foodItem.ContributorEmail);

            MessageBox.Show($"Đã thêm món '{foodItem.FoodName}' vào danh sách!",
                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AddFoodToList(string foodName, string imagePath, string contributor, string contributorEmail)
        {
            try
            {
                FoodItem newFood = new FoodItem
                {
                    FoodName = foodName,
                    ImagePath = imagePath, 
                    Contributor = contributor,
                    ContributorEmail = contributorEmail,
                    AddedDate = DateTime.Now
                };

                foodList.Add(newFood);
                UpdateDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thêm món ăn: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateDataGridView()
        {
            try
            {
                dgvFoodList.Rows.Clear();

                for (int i = 0; i < foodList.Count; i++)
                {
                    int rowIndex = dgvFoodList.Rows.Add();
                    DataGridViewRow row = dgvFoodList.Rows[rowIndex];

                    row.Cells["colSTT"].Value = i + 1;
                    row.Cells["colFoodName"].Value = foodList[i].FoodName;
                    row.Cells["colContributor"].Value = foodList[i].Contributor;
                    row.Cells["colDate"].Value = foodList[i].AddedDate.ToString("dd/MM/yyyy HH:mm");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi hiển thị dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPickRandom_Click(object sender, EventArgs e)
        {
            if (foodList.Count == 0)
            {
                MessageBox.Show("Chưa có món ăn nào trong danh sách!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Random rnd = new Random();
                FoodItem selected = foodList[rnd.Next(foodList.Count)];

                DisplayFoodItem(selected);
                HighlightSelectedFood(foodList.IndexOf(selected) + 1);

                lblResult.Text = $" Đã chọn: {selected.FoodName}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi chọn món: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvFoodList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvFoodList.Rows.Count)
            {
                int index = e.RowIndex;

                if (index < foodList.Count)
                {
                    FoodItem selected = foodList[index];
                    DisplayFoodItem(selected);
                    lblResult.Text = $" Bạn đã chọn: {selected.FoodName}";
                }
            }
        }

        private void DisplayFoodItem(FoodItem item)
        {
            try
            {
                lblFoodName.Text = item.FoodName;
                lblFoodContributor.Text = item.Contributor;

                if (!string.IsNullOrEmpty(item.ImagePath))
                {
                    try
                    {
                        if (File.Exists(item.ImagePath))
                        {
                            pictureBoxFood.Image = Image.FromFile(item.ImagePath);
                        }
                        else if (item.ImagePath.StartsWith("http", StringComparison.OrdinalIgnoreCase))
                        {
                            using (System.Net.WebClient webClient = new System.Net.WebClient())
                            {
                                byte[] imageData = webClient.DownloadData(item.ImagePath);
                                using (MemoryStream ms = new MemoryStream(imageData))
                                {
                                    pictureBoxFood.Image = Image.FromStream(ms);
                                }
                            }
                        }
                        else
                        {
                            pictureBoxFood.Image = CreateDefaultImage("Ảnh không tồn tại");
                        }
                    }
                    catch (Exception imgEx)
                    {
                        MessageBox.Show($"Không thể tải ảnh: {imgEx.Message}", "Lỗi ảnh",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        pictureBoxFood.Image = CreateDefaultImage("Lỗi tải ảnh");
                    }
                }
                else
                {
                    pictureBoxFood.Image = CreateDefaultImage("Không có ảnh");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi hiển thị món ăn: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                pictureBoxFood.Image = CreateDefaultImage("Lỗi");
            }
        }

        private void HighlightSelectedFood(int id)
        {
            foreach (DataGridViewRow row in dgvFoodList.Rows)
            {
                if (row.Cells["colSTT"].Value != null && Convert.ToInt32(row.Cells["colSTT"].Value) == id)
                {
                    row.Selected = true;
                    dgvFoodList.FirstDisplayedScrollingRowIndex = row.Index;
                    break;
                }
            }
        }

        private void ClearSelection()
        {
            lblFoodName.Text = "";
            lblFoodContributor.Text = "";
            pictureBoxFood.Image = CreateDefaultImage("");
            lblResult.Text = "Chưa chọn món ăn";
        }

        private Bitmap CreateDefaultImage(string text)
        {
            Bitmap bmp = new Bitmap(150, 150);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.WhiteSmoke);

                using (Pen pen = new Pen(Color.LightGray, 1))
                {
                    g.DrawRectangle(pen, 0, 0, 149, 149);
                }

                using (Font iconFont = new Font("Arial", 40))
                {
                    StringFormat sf = new StringFormat();
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;

                    g.DrawString("🍽️", iconFont, Brushes.LightGray,
                        new RectangleF(0, 0, 150, 100), sf);
                }

                using (Font textFont = new Font("Arial", 8))
                {
                    StringFormat sf = new StringFormat();
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;

                    g.DrawString(text, textFont, Brushes.Gray,
                        new RectangleF(0, 100, 150, 50), sf);
                }
            }
            return bmp;
        }
    }
}