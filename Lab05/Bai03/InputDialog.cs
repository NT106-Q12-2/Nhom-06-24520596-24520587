using System;
using System.Windows.Forms;

namespace Bai03
{
    public partial class InputDialog : Form
    {
        public string InputText => txtInput.Text;

        public InputDialog(string title, string promptText, string defaultValue)
        {
            InitializeComponent();
            SetupDialog(title, promptText, defaultValue);
        }

        private void SetupDialog(string title, string promptText, string defaultValue)
        {
            this.Text = title;
            lblPrompt.Text = promptText;
            txtInput.Text = defaultValue;
        }

        public static string Show(string title, string promptText, string defaultValue)
        {
            using (var dialog = new InputDialog(title, promptText, defaultValue))
            {
                return dialog.ShowDialog() == DialogResult.OK ? dialog.InputText : null;
            }
        }
    }
}