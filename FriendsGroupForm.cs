using System;
using System.Windows.Forms;

namespace VRCEX
{
    public partial class FriendsGroupForm : Form
    {
        public FriendsGroupForm()
        {
            InitializeComponent();
        }

        private void FriendsGroupForm_Load(object sender, EventArgs e)
        {
            if (Tag is string[] a &&
                a.Length == 3)
            {
                button_group1.Text = a[0];
                button_group2.Text = a[1];
                button_group3.Text = a[2];
            }
        }

        private void button_group1_Click(object sender, EventArgs e)
        {
            Tag = "group_0";
            Close();
        }

        private void button_group2_Click(object sender, EventArgs e)
        {
            Tag = "group_1";
            Close();
        }

        private void button_group3_Click(object sender, EventArgs e)
        {
            Tag = "group_2";
            Close();
        }
    }
}