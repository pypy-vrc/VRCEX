using System;
using System.Windows.Forms;

namespace VRCEX
{
    public partial class MessageForm : Form
    {
        private string m_User = string.Empty;

        public MessageForm()
        {
            InitializeComponent();
        }

        public void Run(string id, string name)
        {
            m_User = id;
            textbox_user.Text = name;
            ShowDialog(MainForm.Instance);
        }

        private void MessageForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                e.Handled = true;
                Close();
            }
        }

        private void button_send_Click(object sender, EventArgs e)
        {
            ApiUser.SendMessage(m_User, textbox_message.Text);
            Close();
        }
    }
}