using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace VRCEX
{
    public partial class FriendsListForm : Form
    {
        public static FriendsListForm Instance { get; private set; } = null;

        /*private class ListComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                return ((ListViewItem)x).Index - ((ListViewItem)y).Index;
            }
        }*/

        public FriendsListForm()
        {
            Instance = this;
            InitializeComponent();
            // listview.ListViewItemSorter = new ListComparer();
            // listview.Sorting = SortOrder.Ascending;
            listview.SmallImageList = MainForm.Instance.imagelist_listbox;
            listview.LargeImageList = MainForm.Instance.imagelist_listbox;
            Utils.SetDoubleBuffering(listview);
        }

        private void FriendsSummaryForm_Load(object sender, EventArgs e)
        {
            timer_Tick(null, null);
        }

        private void FriendsSummaryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instance = null;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            listview.BeginUpdate();
            var dic = new Dictionary<string, ListViewItem>();
            foreach (ListViewItem item in listview.Items)
            {
                if (item.Tag is ApiUser user)
                {
                    dic[user.id] = item;
                }
            }
            foreach (var user in MainForm.Instance.GetOnlineFriends())
            {
                var group = listview.Groups[user.location];
                if (group != null)
                {
                    group.Header = user.locationInfo;
                }
                else
                {
                    group = listview.Groups.Add(user.location, user.locationInfo);
                }
                if (dic.TryGetValue(user.id, out ListViewItem item))
                {
                    dic.Remove(user.id);
                    if (!group.Equals(item.Group))
                    {
                        item.Remove();
                    }
                }
                else
                {
                    item = new ListViewItem();
                }
                item.Tag = user;
                item.Text = user.displayName;
                item.ToolTipText = $"{user.displayName} ({user.username})\r\n{user.GetTrustLevel()}";
                item.ImageKey = user.currentAvatarThumbnailImageUrl;
                item.ForeColor = user.GetColor();
                var style = FontStyle.Regular;
                if (user.location.Contains($"({user.id})"))
                {
                    style |= FontStyle.Bold;
                }
                /*if (m_Friends.ContainsKey(user.id))
                {
                    style |= FontStyle.Underline;
                }*/
                if (MainForm.Instance.IsModerated(user.id))
                {
                    style |= FontStyle.Strikeout;
                }
                if (style != FontStyle.Regular)
                {
                    item.Font = new Font(listview.Font, style);
                }
                if (item.ListView == null)
                {
                    listview.Items.Add(item);
                    group.Items.Add(item);
                }
            }
            var groups = new List<ListViewGroup>();
            foreach (var pair in dic)
            {
                var item = pair.Value;
                if (item.Group != null &&
                    item.Group.Items.Count <= 1)
                {
                    groups.Add(item.Group);
                }
                item.Remove();
            }
            foreach (var group in groups)
            {
                listview.Groups.Remove(group);
            }
            listview.EndUpdate();
        }

        private void listview_Click(object sender, EventArgs e)
        {
            if (listview.Focused &&
                listview.SelectedItems.Count > 0 &&
                listview.SelectedItems[0].Tag is ApiUser user)
            {
                MainForm.Instance.ShowUserDetails(user);
            }
        }
    }
}