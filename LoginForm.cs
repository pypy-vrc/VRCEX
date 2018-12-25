using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VRCEX
{
    public partial class LoginForm : Form
    {
        public static LoginForm Instance { get; private set; } = null;

        private void LoadAuth()
        {
            var auth = LocalConfig.GetSecureString("Auth");
            if (!string.IsNullOrEmpty(auth))
            {
                var a = auth.Split(new[] { '|' }, 2);
                textbox_username.Text = a[0];
                checkbox_username.Checked = true;
                if (a.Length == 2)
                {
                    textbox_password.Text = a[1];
                    checkbox_password.Enabled = true;
                    checkbox_password.Checked = true;
                }
            }
            else
            {
                checkbox_username.Checked = false;
                checkbox_password.Checked = false;
                checkbox_password.Enabled = false;
            }
        }

        private void SaveAuth()
        {
            var auth = string.Empty;
            if (checkbox_username.Checked)
            {
                auth += textbox_username.Text;
                if (checkbox_password.Checked)
                {
                    auth += "|" + textbox_password.Text;
                }
            }
            LocalConfig.SetSecureString("Auth", auth);
        }

        public LoginForm()
        {
            Instance = this;
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            LoadAuth();
            if (MainForm.LastLoginSuccess)
            {
                button_login_Click(null, null); // FIXME: steam login
            }
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveAuth();
            Instance = null;
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            if (Enabled)
            {
                var username = textbox_username.Text;
                var password = textbox_password.Text;
                if (!(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)))
                {
                    Enabled = false;
                    VRCApi.Login(username, password);
                }
            }
        }

        private void button_login_with_steam_Click(object sender, EventArgs e)
        {
            if (Enabled)
            {
                if (VRChatRPC.Update())
                {
                    Enabled = false;
                    VRCApi.ThridPartyLogin("steam", new Dictionary<string, object>
                    {
                        ["steamTicket"] = VRChatRPC.GetAuthSessionTicket()
                    });
                }
                else
                {
                    MessageBox.Show("Login via Steam failed, It only works when VRChat is running.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void checkbox_username_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkbox_username.Checked)
            {
                checkbox_password.Checked = false;
            }
            checkbox_password.Enabled = checkbox_username.Checked;
        }

        public void Reset()
        {
            Enabled = true;
        }
    }
}