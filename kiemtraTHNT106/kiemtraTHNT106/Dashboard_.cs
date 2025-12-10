using System;
using System.Windows.Forms;

namespace Test
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btn_OpenServer_Click(object sender, EventArgs e)
        {
            try
            {
                ServerForm serverForm = new ServerForm();
                serverForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Khong the mo ServerForm: " + ex.Message);
            }
        }

        private void btn_OpenClient_Click(object sender, EventArgs e)
        {
            try
            {
                ClientForm clientForm = new ClientForm();
                clientForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Khong the mo ClientForm: " + ex.Message);
            }
        }
    }
}
