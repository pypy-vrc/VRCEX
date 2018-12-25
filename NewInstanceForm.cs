using System;
using System.Text;
using System.Windows.Forms;

namespace VRCEX
{
    public partial class NewInstanceForm : Form
    {
        private Random m_Random = new Random();
        private string m_User = string.Empty;
        private string m_Instance = string.Empty;

        public NewInstanceForm()
        {
            InitializeComponent();
        }

        public void Run(string user, string world)
        {
            m_User = user;
            textbox_world_id.Text = world;
            radiobutton_public.Checked = true;
            ShowDialog(MainForm.Instance);
        }

        private void NewWorldInstanceForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                e.Handled = true;
                Close();
            }
        }

        private void radiobutton_CheckedChanged(object sender, EventArgs e)
        {
            var b = new StringBuilder();
            b.Append(m_Random.Next(1, 99999));
            if (!radiobutton_public.Checked)
            {
                var type = "private";
                if (radiobutton_friendsofguests.Checked)
                {
                    type = "hidden";
                }
                else if (radiobutton_friendsonly.Checked)
                {
                    type = "friends";
                }
                b.AppendFormat("~{0}({1})~nonce({2})", type, m_User, Guid.NewGuid());
                if (radiobutton_inviteplus.Checked)
                {
                    b.Append("~canRequestInvite");
                }
            }
            m_Instance = b.ToString();
            textbox_world_id_TextChanged(sender, e);
        }

        private void textbox_world_id_TextChanged(object sender, EventArgs e)
        {
            var world = textbox_world_id.Text.Trim();
            if (!string.IsNullOrEmpty(world))
            {
                textbox_vrchat_link.Text = "vrchat://launch?id=" + world + ":" + m_Instance;
                textbox_web_link.Text = "https://www.vrchat.net/home/launch?worldId=" + world + "&instanceId=" + m_Instance;
            }
        }

        private void textbox_Click(object sender, EventArgs e)
        {
            if (sender is TextBox textbox)
            {
                textbox.SelectAll();
            }
        }

        private void button_launch_Click(object sender, EventArgs e)
        {
            var s = textbox_vrchat_link.Text;
            if (!string.IsNullOrEmpty(s) &&
                MessageBox.Show(this, s, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(s);
            }
        }
    }
}