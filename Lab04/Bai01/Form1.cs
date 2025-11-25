using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string getHTML(string szURL)
        {
            WebRequest request = WebRequest.Create(szURL);


            WebResponse response = request.GetResponse();


            Stream dataStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(dataStream);

            string responseFromServer = reader.ReadToEnd();

            response.Close();

            return responseFromServer;
        }

        private void btn_get_Click(object sender, EventArgs e)
        {
            try
            {
                string url = txt_url.Text.Trim();

                if (url == "")
                {
                    MessageBox.Show("Vui lòng nhập URL!");
                    return;
                }


                string html = getHTML(url);

                txt_html.Text = html;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
    
}
