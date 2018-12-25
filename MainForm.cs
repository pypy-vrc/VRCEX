using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VRCEX
{
    public partial class MainForm : Form
    {
        public static MainForm Instance { get; private set; } = null;
        public static bool LastLoginSuccess { get; private set; } = true;

        private ApiUser m_CurrentUser = null;
        private DateTime m_NextFetchImage = DateTime.MaxValue;
        private DateTime m_NextFetchVisits = DateTime.MaxValue;
        private DateTime m_NextFetchCurrentUser = DateTime.MaxValue;
        private DateTime m_NextFetchModeration = DateTime.MaxValue;
        private DateTime m_NextFetchNotification = DateTime.MaxValue;
        private DateTime m_LatestNotification = DateTime.MinValue;
        private DateTime m_NextFetchFavorite = DateTime.MaxValue;
        private Dictionary<string, ApiPlayerModeration> m_Moderation = null;
        private HashSet<string> m_ModerationCheck = new HashSet<string>();
        private Dictionary<string, ListViewItem> m_Friends = new Dictionary<string, ListViewItem>();
        private Dictionary<string, int> m_FavoriteFriends = new Dictionary<string, int>();
        private Dictionary<string, string> m_WorldNames = new Dictionary<string, string>();
        private HashSet<string> m_GPS = new HashSet<string>();

        // searching
        private string m_SearchFriendKeyword = string.Empty;
        private string[] m_SearchFriendResult = null;
        private int m_SearchFriendIndex = 0;

        private class FriendsListComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                return ((ListViewItem)x).Index - ((ListViewItem)y).Index;
            }
        }

        private class NotificationListComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                var a = (ListViewItem)x;
                var b = (ListViewItem)y;
                var c = string.Compare(b.SubItems[2].Text, a.SubItems[2].Text);
                if (c == 0)
                {
                    c = string.Compare(a.SubItems[1].Text, b.SubItems[1].Text); 
                    if (c == 0)
                    {
                        c = string.Compare(a.Text, b.Text);
                    }
                }
                return c;
            }
        }

        public MainForm()
        {
            Instance = this;
            InitializeComponent();
            CreateDownloadMenu(picturebox_world);
            CreateDownloadMenu(picturebox_avatar);
            textbox_world_name.Font = new Font(textbox_world_name.Font, FontStyle.Bold);
            textbox_user_name.Font = new Font(textbox_user_name.Font, FontStyle.Bold);
            textbox_avatar_name.Font = new Font(textbox_avatar_name.Font, FontStyle.Bold);
            listview_online_friends.ListViewItemSorter = new FriendsListComparer();
            listview_online_friends.Sorting = SortOrder.Ascending;
            listview_offline_friends.ListViewItemSorter = new FriendsListComparer();
            listview_offline_friends.Sorting = SortOrder.Ascending;
            listview_moderations.ListViewItemSorter = new NotificationListComparer();
            listview_moderations.Sorting = SortOrder.Ascending;
            listview_moderations_againstme.ListViewItemSorter = new NotificationListComparer();
            listview_moderations_againstme.Sorting = SortOrder.Ascending;
            listview_notification.ListViewItemSorter = new NotificationListComparer();
            listview_notification.Sorting = SortOrder.Ascending;
            var imagelist = new ImageList
            {
                ImageSize = new Size(1, 18)
            };
            listview_moderations.SmallImageList = imagelist;
            listview_moderations_againstme.SmallImageList = imagelist;
            listview_notification.SmallImageList = imagelist;
            Utils.SetDoubleBuffering(listview_online_friends);
            Utils.SetDoubleBuffering(listview_offline_friends);
            Utils.SetDoubleBuffering(listview_world_instance_users);
            Utils.SetDoubleBuffering(listview_search_worlds);
            Utils.SetDoubleBuffering(listview_search_users);
            Utils.SetDoubleBuffering(listview_avatars);
            combobox_status.BeginUpdate();
            combobox_status.Items.Add("active");
            combobox_status.Items.Add("join me");
            combobox_status.Items.Add("busy");
            combobox_status.Items.Add("offline");
            combobox_status.EndUpdate();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Text = VRCEX.APP;
            label_author.Text = VRCEX.APP + " by pypy (mina#5656)";
            OnLogin();
            /*BeginInvoke(new MethodInvoker(() =>
            {
                button_friends_list_Click(null, null);
            }));*/
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control &&
                e.KeyCode == Keys.F)
            {
                e.Handled = true;
                tabcontrol_main.SelectedTab = tabpage_about;
                textbox_search_friend.Focus();
            }
        }

        private void CreateDownloadMenu(Control control)
        {
            control.ContextMenu = new ContextMenu(new[]
            {
                new MenuItem("Download AssetBundle", (sender, e) =>
                {
                    if (sender is MenuItem item &&
                        item.Tag is string tag)
                    {
                        Process.Start(tag);
                    }
                })
                {
                    Enabled = false
                },
                new MenuItem("Download UnityPackage", (sender, e) =>
                {
                    if (sender is MenuItem item &&
                        item.Tag is string tag)
                    {
                        Process.Start(tag);
                    }
                })
                {
                    Enabled = false
                }
            });
        }

        private void UpdateDownloadMenu(Control control, string assetUrl, string unityPackageUrl)
        {
            var items = control.ContextMenu.MenuItems;
            var item = items[0];
            item.Tag = assetUrl;
            item.Enabled = !string.IsNullOrEmpty(assetUrl);
            item = items[1];
            item.Tag = unityPackageUrl;
            item.Enabled = !string.IsNullOrEmpty(unityPackageUrl);
        }

        private void FetchImage(string imageUrl, ImageList imageList, PictureBox pictureBox = null)
        {
            var images = imageList.Images;
            if (!images.ContainsKey(imageUrl))
            {
                Task.Run(async () =>
                {
                    try
                    {
                        using (var response = await new HttpClient().GetAsync(imageUrl))
                        {
                            response.EnsureSuccessStatusCode();
                            using (var stream = await response.Content.ReadAsStreamAsync())
                            {
                                var image = Image.FromStream(stream);
                                if (image != null)
                                {
                                    BeginInvoke(new MethodInvoker(() =>
                                    {
                                        images.RemoveByKey(imageUrl);
                                        images.Add(imageUrl, image);
                                        if (pictureBox != null)
                                        {
                                            pictureBox.Tag = imageUrl;
                                            pictureBox.Image = images[imageUrl];
                                        }
                                    }));
                                }
                            }
                        }
                    }
                    catch
                    {
                    }
                });
            }
            else if (pictureBox != null)
            {
                pictureBox.Tag = imageUrl;
                pictureBox.Image = images[imageUrl];
            }
        }

        public void ShowMessage(string message, string tag = "")
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    ShowMessage(message, tag);
                }));
            }
            else
            {
                listview_log.BeginUpdate();
                while (listview_log.Items.Count >= 500)
                {
                    listview_log.Items.RemoveAt(0);
                }
                var item = new ListViewItem
                {
                    Tag = tag,
                    Text = DateTime.Now.ToString("HH:mm") + " " + message,
                    ToolTipText = tag
                };
                listview_log.Items.Add(item);
                item.EnsureVisible();
                listview_log.EndUpdate();
                if (LoginForm.Instance != null)
                {
                    LoginForm.Instance.Reset();
                }
            }
        }

        private void listview_log_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.C)
                {
                    e.Handled = true;
                    if (listview_log.SelectedItems.Count > 0)
                    {
                        var b = new StringBuilder();
                        foreach (ListViewItem item in listview_log.SelectedItems)
                        {
                            b.AppendLine(item.Text);
                        }
                        Clipboard.Clear();
                        Clipboard.SetText(b.ToString());
                    }
                }
            }
            else if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
                listview_log.BeginUpdate();
                foreach (ListViewItem item in listview_log.SelectedItems)
                {
                    item.Remove();
                }
                listview_log.EndUpdate();
            }
        }

        private void listview_log_DoubleClick(object sender, EventArgs e)
        {
            if (listview_log.SelectedItems.Count > 0 &&
                listview_log.SelectedItems[0].Tag is string tag)
            {
                var L = LocationInfo.Parse(tag);
                if (L != null)
                {
                    textbox_world_location.Text = tag;
                    ApiWorld.Fetch(L.WorldId);
                    ApiWorldInstance.Fetch(L.WorldId, L.InstanceId);
                    tabcontrol_main.SelectedTab = tabpage_world;
                    tabpage_world.Focus();
                }
            }
        }

        private void listview_online_friends_Click(object sender, EventArgs e)
        {
            if (listview_online_friends.Focused &&
                listview_online_friends.SelectedItems.Count > 0 &&
                listview_online_friends.SelectedItems[0].Tag is ApiUser user)
            {
                textbox_user_id.Text = user.id;
                ApiUser.Fetch(user.id);
                var L = LocationInfo.Parse(user.location);
                if (L != null)
                {
                    textbox_world_location.Text = user.location;
                    ApiWorld.Fetch(L.WorldId);
                    ApiWorldInstance.Fetch(L.WorldId, L.InstanceId);
                    tabcontrol_main.SelectedTab = tabpage_world;
                    tabpage_world.Focus();
                }
                else
                {
                    tabcontrol_main.SelectedTab = tabpage_user;
                    tabpage_user.Focus();
                }
            }
        }

        private void listview_offline_friends_Click(object sender, EventArgs e)
        {
            if (listview_offline_friends.Focused &&
                listview_offline_friends.SelectedItems.Count > 0 &&
                listview_offline_friends.SelectedItems[0].Tag is ApiUser user)
            {
                textbox_user_id.Text = user.id;
                ApiUser.Fetch(user.id);
                tabcontrol_main.SelectedTab = tabpage_user;
                tabpage_user.Focus();
            }
        }

        private void label_link_DoubleClick(object sender, EventArgs e)
        {
            Process.Start("https://gall.dcinside.com/m/list.php?id=vr");
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (m_CurrentUser != null)
            {
                if (DateTime.Now.CompareTo(m_NextFetchVisits) >= 0)
                {
                    VRCApi.FetchVisits();
                    m_NextFetchVisits = DateTime.Now.AddSeconds(60);
                }
                if (DateTime.Now.CompareTo(m_NextFetchCurrentUser) >= 0)
                {
                    ApiUser.FetchCurrentUser();
                    m_NextFetchCurrentUser = DateTime.Now.AddSeconds(60);
                }
                if (DateTime.Now.CompareTo(m_NextFetchModeration) >= 0)
                {
                    m_ModerationCheck.Clear();
                    listview_moderations.Items.Clear();
                    ApiPlayerModeration.FetchAllMine();
                    ApiPlayerModeration.FetchAllAgainstMe();
                    m_NextFetchModeration = DateTime.Now.AddSeconds(60);
                }
                if (DateTime.Now.CompareTo(m_NextFetchNotification) >= 0)
                {
                    ApiNotification.FetchAll(ApiNotification.NotificationType.All, DateTime.MinValue.Equals(m_LatestNotification) ? string.Empty : m_LatestNotification.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ"));
                    m_NextFetchNotification = DateTime.Now.AddSeconds(60);
                }
                if (DateTime.Now.CompareTo(m_NextFetchFavorite) >= 0)
                {
                    ApiFavorite.FetchList(ApiFavorite.FavoriteType.Friend);
                    m_NextFetchFavorite = DateTime.Now.AddSeconds(60);
                }
            }
            if (DateTime.Now.CompareTo(m_NextFetchImage) >= 0)
            {
                var n = 0;
                foreach (var pair in m_Friends)
                {
                    var s = pair.Value.ImageKey;
                    if (!string.IsNullOrEmpty(s) &&
                        !imagelist_listbox.Images.ContainsKey(s))
                    {
                        FetchImage(s, imagelist_listbox);
                        if (++n >= 25)
                        {
                            break;
                        }
                    }
                }
                m_NextFetchImage = DateTime.Now.AddSeconds(5);
            }
        }

        public List<ApiUser> GetOnlineFriends()
        {
            var result = new List<ApiUser>();
            foreach (ListViewItem item in listview_online_friends.Items)
            {
                if (item.Tag is ApiUser user)
                {
                    result.Add(user);
                }
            }
            return result;
        }

        public bool IsModerated(string id)
        {
            return m_ModerationCheck.Contains(id);
        }

        public void ShowUserDetails(ApiUser user)
        {
            textbox_user_id.Text = user.id;
            ApiUser.Fetch(user.id);
            var L = LocationInfo.Parse(user.location);
            if (L != null)
            {
                textbox_world_location.Text = user.location;
                ApiWorld.Fetch(L.WorldId);
                ApiWorldInstance.Fetch(L.WorldId, L.InstanceId);
                tabcontrol_main.SelectedTab = tabpage_world;
                tabpage_world.Focus();
            }
            else
            {
                tabcontrol_main.SelectedTab = tabpage_user;
                tabpage_user.Focus();
            }
        }

        //
        // Global
        //

        public void OnLogin(ApiUser user = null)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    OnLogin(user);
                }));
            }
            else
            {
                m_CurrentUser = null;
                m_NextFetchImage = DateTime.MinValue;
                m_NextFetchVisits = DateTime.MinValue;
                m_NextFetchCurrentUser = DateTime.MinValue;
                m_NextFetchModeration = DateTime.MinValue;
                m_NextFetchNotification = DateTime.MinValue;
                m_LatestNotification = DateTime.MinValue;
                m_NextFetchFavorite = DateTime.MinValue;
                m_Moderation = null;
                m_ModerationCheck.Clear();
                m_Friends.Clear();
                m_FavoriteFriends.Clear();
                m_GPS.Clear();
                listview_online_friends.Items.Clear();
                listview_offline_friends.Items.Clear();
                listview_moderations.Items.Clear();
                listview_moderations_againstme.Items.Clear();
                listview_notification.Items.Clear();
                if (user == null)
                {
                    ApiUser.FetchCurrentUser(); 
                }
                else
                {
                    OnCurrentUser(user);
                }
            }
        }

        public void OnVisits(string data)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    OnVisits(data);
                }));
            }
            else
            {
                m_NextFetchVisits = DateTime.Now.AddSeconds(60);
                label_visits.Text = $"{data} Users Online";
            }
        }

        //
        // ApiModel
        //

        public void OnResponse(ApiResponse response)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    OnResponse(response);
                }));
            }
            else
            {
                if (response.error != null)
                {
                    var result = response.error;
                    ShowMessage($"code {result.status_code}, {result.message}");
                    if (result.status_code == 401)
                    {
                        m_CurrentUser = null;
                        if (LoginForm.Instance == null)
                        {
                            new LoginForm().ShowDialog(this);
                            if (m_CurrentUser == null)
                            {
                                Application.Exit();
                            }
                        }
                    }
                }
                if (response.success != null)
                {
                    var result = response.success;
                    ShowMessage($"code {result.status_code}, {result.message}");
                }
            }
        }

        //
        // ApiUser
        //

        public void OnSetStatus(ApiUser user)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    OnSetStatus(user);
                }));
            }
            else
            {
                ShowMessage($"SetStatus : [{user.status}] {user.statusDescription}");
                OnCurrentUser(user);
            }
        }

        public void OnCurrentUser(ApiUser user)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    OnCurrentUser(user);
                }));
            }
            else
            {
                LastLoginSuccess = true;
                m_NextFetchCurrentUser = DateTime.Now.AddSeconds(60);
                m_CurrentUser = user;
                ApiUser.FetchFriends();
                if (user.friends != null)
                {
                    var friends = user.friends;
                    var set = new HashSet<string>();
                    foreach (var pair in m_Friends)
                    {
                        if (!friends.Contains(pair.Key))
                        {
                            set.Add(pair.Key);
                        }
                    }
                    if (set.Count > 0)
                    {
                        listview_online_friends.BeginUpdate();
                        listview_offline_friends.BeginUpdate();
                        foreach (var id in set)
                        {
                            if (m_Friends.TryGetValue(id, out ListViewItem item))
                            {
                                m_Friends.Remove(id);
                                item.Remove();
                                ApiUser.CheckFriendStatus(id); // FIXME: 너무 많은 요청을 보낼듯
                            }
                        }
                        listview_offline_friends.EndUpdate();
                        listview_online_friends.EndUpdate();
                        tabpage_online.Text = $"Online({listview_online_friends.Items.Count})";
                        tabpage_offline.Text = $"Offline({listview_offline_friends.Items.Count})";
                    }
                }
                combobox_status.Text = user.status;
                textbox_status.Text = user.statusDescription;
                if (LoginForm.Instance != null)
                {
                    LoginForm.Instance.Close();
                }
            }
        }

        public void OnFriendStatus(string userId, ApiUser.FriendStatus status)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    OnFriendStatus(userId, status);
                }));
            }
            else if (textbox_user_id.Text.Equals(userId))
            {
                if (status.isFriend)
                {
                    button_user_friend.Text = "Unfriend";
                }
                else if (status.incomingRequest)
                {
                    button_user_friend.Text = "Accept Friend Request";
                }
                else if (status.outgoingRequest)
                {
                    button_user_friend.Text = "Cancel Friend Request";
                }
                else
                {
                    button_user_friend.Text = "Add Friend";
                }
            }
        }

        public void OnUser(ApiUser user)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    OnUser(user);
                }));
            }
            else if (textbox_user_id.Text.Equals(user.id))
            {
                ApiUser.CheckFriendStatus(user.id);
                FetchImage(user.currentAvatarThumbnailImageUrl, imagelist_picturebox, picturebox_user);
                textbox_user_id.Text = user.id;
                textbox_user_name.Text = $"{user.displayName} ({user.username})";
                textbox_user_level.Text = user.GetTrustLevel().ToString();
                textbox_user_info.Text = DateTime.TryParse(user.last_login, out DateTime last_login) ? last_login.ToString("yyyy-MM-dd HH:mm:ss") : user.last_login;
                textbox_user_status.Text = $"[{user.status}] {user.statusDescription}";
                button_user_friend.Text = "Loading";
                button_user_mute.Text = m_ModerationCheck.Contains($"{user.id}_mute") ? "Unmute" : "Mute";
                button_user_block.Text = m_ModerationCheck.Contains($"{user.id}_block") ? "Unblock" : "Block";
                button_user_hide.Text = m_ModerationCheck.Contains($"{user.id}_hideavatar") ? "ShowAvatar" : "HideAvatar";
                if (m_Friends.ContainsKey(user.id))
                {
                    OnFriends(new List<ApiUser>
                    {
                        user
                    });
                }
            }
        }

        public void OnUsers(List<ApiUser> users)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    OnUsers(users);
                }));
            }
            else
            {
                listview_search_users.BeginUpdate();
                listview_search_users.Items.Clear();
                if (listview_search_users.ShowGroups)
                {
                    listview_search_users.Groups.Clear();
                    if (m_CurrentUser != null)
                    {
                        for (var i = 0; i < 3; ++i)
                        {
                            listview_search_users.Groups.Add("group_" + i, m_CurrentUser.GetFriendsGroupDisplayName(i));
                        }
                    }
                }
                foreach (var user in users)
                {
                    FetchImage(user.currentAvatarThumbnailImageUrl, imagelist_listbox);
                    var item = new ListViewItem
                    {
                        Tag = user,
                        Text = user.displayName,
                        ToolTipText = $"{user.displayName} ({user.username})\r\n{user.GetTrustLevel()}\r\n[{user.status}] {user.statusDescription}",
                        ImageKey = user.currentAvatarThumbnailImageUrl,
                        ForeColor = user.GetColor(),
                    };
                    if (listview_search_users.ShowGroups &&
                        m_FavoriteFriends.TryGetValue(user.id, out int group) &&
                        group >= 1 &&
                        group <= 3 &&
                        group - 1 < listview_search_users.Groups.Count)
                    {
                        item.Group = listview_search_users.Groups[group - 1];
                    }
                    var style = FontStyle.Regular;
                    if (item.Group != null)
                    {
                        if (!"offline".Equals(user.location, StringComparison.OrdinalIgnoreCase))
                        {
                            style |= FontStyle.Underline;
                        }
                    }
                    else if (m_Friends.ContainsKey(user.id))
                    {
                        style |= FontStyle.Underline;
                    }
                    if (m_ModerationCheck.Contains(user.id))
                    {
                        style |= FontStyle.Strikeout;
                    }
                    if (style != FontStyle.Regular)
                    {
                        item.Font = new Font(listview_search_users.Font, style);
                    }
                    listview_search_users.Items.Add(item);
                }
                foreach (ListViewGroup group in listview_search_users.Groups)
                {
                    group.Header += " (" + group.Items.Count + ")";
                }
                listview_search_users.EndUpdate();
            }
        }

        public void OnFriends(List<ApiUser> users)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    OnFriends(users);
                }));
            }
            else
            {
                listview_online_friends.BeginUpdate();
                listview_offline_friends.BeginUpdate();
                foreach (var user in users)
                {
                    var is_offline = "offline".Equals(user.location, StringComparison.OrdinalIgnoreCase);
                    if (!is_offline)
                    {
                        FetchImage(user.currentAvatarThumbnailImageUrl, imagelist_listbox);
                    }
                    var group = is_offline ? listview_offline_friends : listview_online_friends;
                    if (m_Friends.TryGetValue(user.id, out ListViewItem item))
                    {
                        if (item.Tag is ApiUser _user)
                        {
                            user.pastLocation = _user.location;
                            user.pastLocationInfo = _user.locationInfo;
                        }
                        if (!group.Equals(item.ListView))
                        {
                            item.Remove();
                            group.Items.Insert(0, item);
                        }
                    }
                    else
                    {
                        item = new ListViewItem
                        {
                            UseItemStyleForSubItems = false
                        };
                        item.SubItems.Add(new ListViewItem.ListViewSubItem()
                        {
                            ForeColor = Color.Gray
                        });
                        group.Items.Add(item);
                        m_Friends[user.id] = item;
                    }
                    var notify = true;
                    var locationInfo = user.location;
                    var L = LocationInfo.Parse(user.location);
                    if (L != null)
                    {
                        if (m_WorldNames.TryGetValue(L.WorldId, out string worldName))
                        {
                            locationInfo = $"{worldName} {L.InstanceInfo}";
                        }
                        else
                        {
                            notify = false;
                            if (m_GPS.Add(L.WorldId))
                            {
                                ApiWorld.Fetch(L.WorldId);
                            }
                        }
                    }
                    user.locationInfo = locationInfo;
                    if (!string.IsNullOrEmpty(user.pastLocation) &&
                        !string.Equals(user.pastLocation, user.location))
                    {
                        if (is_offline)
                        {
                            ShowMessage($"[Logout] {user.displayName} : {user.pastLocationInfo}", user.pastLocation);
                        }
                        else if ("offline".Equals(user.pastLocation, StringComparison.OrdinalIgnoreCase))
                        {
                            ShowMessage($"[Login] {user.displayName} : {locationInfo}", user.location);
                        }
                        else if (notify)
                        {
                            ShowMessage($"{user.displayName} : {locationInfo}", user.location);
                        }
                    }
                    item.Tag = user;
                    item.Text = user.displayName;
                    item.SubItems[1].Text = locationInfo;
                    item.ToolTipText = $"{user.displayName} ({user.username})\r\n{user.GetTrustLevel()}\r\n{locationInfo}\r\n[{user.status}] {user.statusDescription}";
                    item.ImageKey = user.currentAvatarThumbnailImageUrl;
                    item.ForeColor = user.GetColor();
                    if (m_ModerationCheck.Contains(user.id))
                    {
                        item.Font = new Font(item.ListView.Font, FontStyle.Strikeout);
                    }
                }
                listview_offline_friends.EndUpdate();
                listview_online_friends.EndUpdate();
                tabpage_online.Text = $"Online({listview_online_friends.Items.Count})";
                tabpage_offline.Text = $"Offline({listview_offline_friends.Items.Count})";
            }
        }

        public void OnSendFriendRequest(string userId, ApiNotification notification)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    OnSendFriendRequest(userId, notification);
                }));
            }
            else
            {
                ShowMessage("Friend request sent");
                ApiUser.CheckFriendStatus(userId);
            }
        }

        public void OnCancelFriendRequest(string userId, ApiResponse response)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    OnCancelFriendRequest(userId, response);
                }));
            }
            else
            {
                OnResponse(response);
                ApiUser.CheckFriendStatus(userId);
            }
        }

        public void OnUnfriendUser(string userId, ApiResponse response)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    OnUnfriendUser(userId, response);
                }));
            }
            else
            {
                OnResponse(response);
                m_NextFetchCurrentUser = DateTime.MinValue;
                ApiUser.CheckFriendStatus(userId);
            }
        }

        public void OnAcceptFriendRequest(string notificationId, ApiResponse response)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    OnAcceptFriendRequest(notificationId, response);
                }));
            }
            else
            {
                OnResponse(response);
                m_NextFetchCurrentUser = DateTime.MinValue;
                DeleteNoticifation(notificationId);
            }
        }

        public void OnDeclineFriendRequest(ApiNotification notification)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    OnDeclineFriendRequest(notification);
                }));
            }
            else
            {
                ShowMessage($"Decline({notification.type}) : {notification.senderUsername}");
                ApiUser.CheckFriendStatus(notification.senderUserId);
                DeleteNoticifation(notification.id);
            }
        }

        //
        // ApiWorld
        //

        public void OnWorld(ApiWorld world)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    OnWorld(world);
                }));
            }
            else
            {
                m_WorldNames[world.id] = world.name;
                if (m_GPS.Remove(world.id))
                {
                    listview_online_friends.BeginUpdate();
                    foreach (ListViewItem item in listview_online_friends.Items)
                    {
                        if (item.Tag is ApiUser user)
                        {
                            var L1 = LocationInfo.Parse(user.location);
                            if (L1 != null &&
                                L1.WorldId.Equals(world.id))
                            {
                                var locationInfo = $"{world.name} {L1.InstanceInfo}";
                                user.locationInfo = locationInfo;
                                item.SubItems[1].Text = locationInfo;
                                item.ToolTipText = $"{user.displayName} ({user.username})\r\n{user.GetTrustLevel()}\r\n{locationInfo}\r\n[{user.status}] {user.statusDescription}";
                                if (!string.IsNullOrEmpty(user.pastLocation))
                                {
                                    ShowMessage($"{user.displayName} : {locationInfo}", user.location);
                                }
                            }
                        }
                    }
                    listview_online_friends.EndUpdate();
                }
                var L2 = LocationInfo.Parse(textbox_world_location.Text, false);
                if (L2 != null &&
                    L2.WorldId.Equals(world.id))
                {
                    ApiFile.ParseAndFetch(world.assetUrl, world);
                    UpdateDownloadMenu(picturebox_world, world.assetUrl, world.unityPackageUrl);
                    FetchImage(world.thumbnailImageUrl, imagelist_picturebox, picturebox_world);
                    textbox_world_name.Text = world.name;
                    textbox_world_author.Tag = world.authorId;
                    textbox_world_author.Text = $"{world.authorName}, {world.releaseStatus}, {world.occupants}/{world.capacity}";
                    textbox_world_info.Text = "Loading";
                    textbox_world_description.Text = world.description;
                    listview_world_instances.BeginUpdate();
                    listview_world_instances.Items.Clear();
                    foreach (var data in world.instances)
                    {
                        var location = $"{L2.WorldId}:{data[0]}";
                        var L3 = LocationInfo.Parse(location);
                        listview_world_instances.Items.Add(new ListViewItem
                        {
                            Tag = location,
                            Text = (L3 != null) ? $"{L3.InstanceInfo} ({data[1]})" : $"{data[0]} ({data[1]})",
                            ToolTipText = data[0]
                        });
                    }
                    listview_world_instances.EndUpdate();
                }
            }
        }

        public void OnWorlds(List<ApiWorld> worlds)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    OnWorlds(worlds);
                }));
            }
            else
            {
                listview_search_worlds.BeginUpdate();
                listview_search_worlds.Items.Clear();
                foreach (var world in worlds)
                {
                    FetchImage(world.thumbnailImageUrl, imagelist_listbox);
                    var item = new ListViewItem
                    {
                        Tag = world,
                        Text = world.name,
                        ToolTipText = $"{world.name}\r\nby {world.authorName}",
                        ImageKey = world.thumbnailImageUrl,
                        UseItemStyleForSubItems = false
                    };
                    item.SubItems.Add(new ListViewItem.ListViewSubItem()
                    {
                        Text = (world.occupants > 0) ? $"({world.occupants})" : string.Empty,
                        ForeColor = Color.Gray
                    });
                    listview_search_worlds.Items.Add(item);
                }
                listview_search_worlds.EndUpdate();
            }
        }

        public void OnWorldInstance(ApiWorldInstance instance)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    OnWorldInstance(instance);
                }));
            }
            else
            {
                var L = LocationInfo.Parse(textbox_world_location.Text);
                if (L != null &&
                    L.InstanceId.Equals(instance.id))
                {
                    listview_world_instance_users.BeginUpdate();
                    listview_world_instance_users.Items.Clear();
                    foreach (var user in instance.users)
                    {
                        FetchImage(user.currentAvatarThumbnailImageUrl, imagelist_listbox);
                        var item = new ListViewItem
                        {
                            Tag = user,
                            Text = user.displayName,
                            ToolTipText = $"{user.displayName} ({user.username})\r\n{user.GetTrustLevel()}",
                            ImageKey = user.currentAvatarThumbnailImageUrl,
                            ForeColor = user.GetColor()
                        };
                        var style = FontStyle.Regular;
                        if (instance.id.Contains($"({user.id})"))
                        {
                            style |= FontStyle.Bold;
                        }
                        if (m_Friends.ContainsKey(user.id))
                        {
                            style |= FontStyle.Underline;
                        }
                        if (m_ModerationCheck.Contains(user.id))
                        {
                            style |= FontStyle.Strikeout;
                        }
                        if (style != FontStyle.Regular)
                        {
                            item.Font = new Font(listview_world_instance_users.Font, style);
                        }
                        listview_world_instance_users.Items.Add(item);
                    }
                    listview_world_instance_users.EndUpdate();
                    textbox_world_instance_occupants.Text = listview_world_instance_users.Items.Count.ToString();
                }
            }
        }

        //
        // ApiAvatar
        //

        public void OnAvatar(ApiAvatar avatar)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    OnAvatar(avatar);
                }));
            }
            else if (textbox_avatar_id.Text.Equals(avatar.id))
            {
                ApiFile.ParseAndFetch(avatar.assetUrl, avatar);
                UpdateDownloadMenu(picturebox_avatar, avatar.assetUrl, avatar.unityPackageUrl);
                FetchImage(avatar.thumbnailImageUrl, imagelist_picturebox, picturebox_avatar);
                textbox_avatar_id.Text = avatar.id;
                textbox_avatar_name.Text = avatar.name;
                textbox_avatar_author.Tag = avatar.authorId;
                textbox_avatar_author.Text = $"{avatar.authorName}, {avatar.releaseStatus}";
                textbox_avatar_info.Text = "Loading";
                textbox_avatar_description.Text = avatar.description;
            }
        }

        public void OnAvatars(List<ApiAvatar> avatars)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    OnAvatars(avatars);
                }));
            }
            else
            {
                listview_avatars.BeginUpdate();
                foreach (var avatar in avatars)
                {
                    FetchImage(avatar.thumbnailImageUrl, imagelist_listbox);
                    listview_avatars.Items.Add(new ListViewItem
                    {
                        Tag = avatar,
                        Text = avatar.name,
                        ToolTipText = $"{avatar.name}\r\nby {avatar.authorName}",
                        ImageKey = avatar.thumbnailImageUrl
                    });
                }
                listview_avatars.EndUpdate();
                tabpage_avatar.Text = $"Avatar({listview_avatars.Items.Count})";
            }
        }

        //
        // ApiFavorite
        //

        public void OnFavorites(ApiFavorite.FavoriteType type, List<ApiFavorite> favorites)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    OnFavorites(type, favorites);
                }));
            }
            else if (type == ApiFavorite.FavoriteType.Friend)
            {
                m_FavoriteFriends.Clear();
                foreach (var favorite in favorites)
                {
                    var group = 0;
                    if (favorite.tags != null)
                    {
                        if (favorite.tags.Contains("group_0"))
                        {
                            group = 1;
                        }
                        else if (favorite.tags.Contains("group_1"))
                        {
                            group = 2;
                        }
                        else if (favorite.tags.Contains("group_2"))
                        {
                            group = 3;
                        }
                    }
                    m_FavoriteFriends[favorite.favoriteId] = group;
                }
            }
        }

        public void OnAddFavorite(ApiFavorite favorite)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    OnAddFavorite(favorite);
                }));
            }
            else
            {
                ShowMessage($"Favorite({favorite.type}) : {favorite.favoriteId}");
            }
        }

        public void OnRemoveFavorite(ApiResponse response)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    OnRemoveFavorite(response);
                }));
            }
            else
            {
                OnResponse(response);
            }
        }

        //
        // ApiModeration
        //

        public void OnPlayerModerations(List<ApiPlayerModeration> moderations)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    OnPlayerModerations(moderations);
                }));
            }
            else
            {
                m_NextFetchModeration = DateTime.Now.AddSeconds(60);
                listview_moderations.BeginUpdate();
                foreach (var moderation in moderations)
                {
                    if ("block".Equals(moderation.type, StringComparison.OrdinalIgnoreCase) ||
                        "mute".Equals(moderation.type, StringComparison.OrdinalIgnoreCase) ||
                        "hideAvatar".Equals(moderation.type, StringComparison.OrdinalIgnoreCase))
                    {
                        m_ModerationCheck.Add(moderation.targetUserId);
                        m_ModerationCheck.Add($"{moderation.targetUserId}_{moderation.type.ToLower()}");
                        var item = new ListViewItem
                        {
                            Tag = moderation,
                            Text = moderation.targetDisplayName,
                            ToolTipText = moderation.targetDisplayName
                        };
                        item.SubItems.Add(new ListViewItem.ListViewSubItem()
                        {
                            Text = moderation.type
                        });
                        item.SubItems.Add(new ListViewItem.ListViewSubItem()
                        {
                            Text = DateTime.TryParse(moderation.created, out DateTime created) ? created.ToString("yyyy-MM-dd HH:mm:ss") : moderation.created
                        });
                        listview_moderations.Items.Add(item);
                    }
                }
                listview_moderations.Sort();
                listview_moderations.EndUpdate();
                tabpage_moderation.Text = $"Moderation({listview_moderations.Items.Count}/{listview_moderations_againstme.Items.Count})";

                // FIXME
                var id = textbox_user_id.Text;
                if (!string.IsNullOrEmpty(id))
                {
                    button_user_mute.Text = m_ModerationCheck.Contains($"{id}_mute") ? "Unmute" : "Mute";
                    button_user_block.Text = m_ModerationCheck.Contains($"{id}_block") ? "Unblock" : "Block";
                    button_user_hide.Text = m_ModerationCheck.Contains($"{id}_hideavatar") ? "ShowAvatar" : "HideAvatar";
                }
            }
        }

        public void OnPlayerModerationsAgainstMe(List<ApiPlayerModeration> moderations)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    OnPlayerModerationsAgainstMe(moderations);
                }));
            }
            else
            {
                m_NextFetchModeration = DateTime.Now.AddSeconds(60);
                var dic = new Dictionary<string, ApiPlayerModeration>();
                listview_moderations_againstme.BeginUpdate();
                listview_moderations_againstme.Items.Clear();
                foreach (var moderation in moderations)
                {
                    if ("block".Equals(moderation.type, StringComparison.OrdinalIgnoreCase) ||
                        "mute".Equals(moderation.type, StringComparison.OrdinalIgnoreCase) ||
                        "hideAvatar".Equals(moderation.type, StringComparison.OrdinalIgnoreCase))
                    {
                        m_ModerationCheck.Add(moderation.sourceUserId);
                        var item = new ListViewItem
                        {
                            Tag = moderation,
                            Text = moderation.sourceDisplayName,
                            ToolTipText = moderation.sourceDisplayName
                        };
                        item.SubItems.Add(new ListViewItem.ListViewSubItem()
                        {
                            Text = moderation.type
                        });
                        item.SubItems.Add(new ListViewItem.ListViewSubItem()
                        {
                            Text = DateTime.TryParse(moderation.created, out DateTime created) ? created.ToString("yyyy-MM-dd HH:mm:ss") : moderation.created
                        });
                        listview_moderations_againstme.Items.Add(item);
                        if (m_Moderation != null &&
                            !m_Moderation.Remove(moderation.id))
                        {
                            if ("block".Equals(moderation.type, StringComparison.OrdinalIgnoreCase))
                            {
                                ShowMessage("[Moderation] " + moderation.sourceDisplayName + " has blocked you");
                            }
                            else if ("mute".Equals(moderation.type, StringComparison.OrdinalIgnoreCase))
                            {
                                ShowMessage("[Moderation] " + moderation.sourceDisplayName + " has muted you");
                            }
                            else if ("hideAvatar".Equals(moderation.type, StringComparison.OrdinalIgnoreCase))
                            {
                                ShowMessage("[Moderation] " + moderation.sourceDisplayName + " has hidden you");
                            }
                        }
                        dic[moderation.id] = moderation;
                    }
                }
                if (m_Moderation != null)
                {
                    foreach (var pair in m_Moderation)
                    {
                        var moderation = pair.Value;
                        if ("block".Equals(moderation.type, StringComparison.OrdinalIgnoreCase))
                        {
                            ShowMessage("[Moderation] " + moderation.sourceDisplayName + " has unblocked you");
                        }
                        else if ("mute".Equals(moderation.type, StringComparison.OrdinalIgnoreCase))
                        {
                            ShowMessage("[Moderation] " + moderation.sourceDisplayName + " has unmuted you");
                        }
                        else if ("hideAvatar".Equals(moderation.type, StringComparison.OrdinalIgnoreCase))
                        {
                            ShowMessage("[Moderation] " + moderation.sourceDisplayName + " has showed you");
                        }
                    }
                }
                m_Moderation = dic;
                listview_moderations_againstme.Sort();
                listview_moderations_againstme.EndUpdate();
                tabpage_moderation.Text = $"Moderation({listview_moderations.Items.Count}/{listview_moderations_againstme.Items.Count})";
            }
        }

        public void OnSendModeration(ApiPlayerModeration moderation)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    OnSendModeration(moderation);
                }));
            }
            else
            {
                ShowMessage($"PlayerModeration({moderation.type}) : {moderation.targetDisplayName}");
                m_NextFetchModeration = DateTime.MinValue;
            }
        }

        public void OnDeleteModeration(ApiResponse response)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    OnDeleteModeration(response);
                }));
            }
            else
            {
                m_NextFetchModeration = DateTime.MinValue;
                OnResponse(response);
            }
        }

        //
        // ApiNotification
        //

        private void DeleteNoticifation(string id)
        {
            ListViewItem target = null;
            foreach (ListViewItem item in listview_notification.Items)
            {
                if (item.Tag is ApiNotification notification &&
                    id.Equals(notification.id))
                {
                    if ("friendRequest".Equals(notification.type, StringComparison.OrdinalIgnoreCase))
                    {
                        ApiUser.CheckFriendStatus(notification.senderUserId);
                    }
                    target = item;
                    break;
                }
            }
            if (target != null)
            {
                listview_notification.BeginUpdate();
                target.Remove();
                listview_notification.EndUpdate();
                tabpage_notification.Text = $"Message({listview_notification.Items.Count})";
            }
        }

        public void OnNotifications(List<ApiNotification> notifications)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    OnNotifications(notifications);
                }));
            }
            else
            {
                m_NextFetchNotification = DateTime.Now.AddSeconds(60);
                listview_notification.BeginUpdate();
                foreach (var notification in notifications)
                {
                    var item = new ListViewItem
                    {
                        Tag = notification,
                        Text = notification.senderUsername,
                        ToolTipText = notification.senderUsername
                    };
                    item.SubItems.Add(new ListViewItem.ListViewSubItem()
                    {
                        Text = notification.type
                    });
                    if (DateTime.TryParse(notification.created_at, out DateTime created_at))
                    {
                        if (created_at.CompareTo(m_LatestNotification) > 0)
                        {
                            m_LatestNotification = created_at.AddSeconds(1);
                        }
                        item.SubItems.Add(new ListViewItem.ListViewSubItem()
                        {
                            Text = created_at.ToString("yyyy-MM-dd HH:mm:ss")
                        });
                    }
                    else
                    {
                        item.SubItems.Add(new ListViewItem.ListViewSubItem()
                        {
                            Text = notification.created_at
                        });
                    }
                    listview_notification.Items.Add(item);
                }
                listview_notification.Sort();
                listview_notification.EndUpdate();
                tabpage_notification.Text = $"Message({listview_notification.Items.Count})";
            }
        }

        //
        // ApiFile
        //

        public void OnFile(object arg, ApiFile file)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    OnFile(arg, file);
                }));
            }
            else if (file.versions != null &&
                file.versions.Count > 0)
            {
                var F = file.versions[file.versions.Count - 1];
                if (F.file != null &&
                    DateTime.TryParse(F.created_at, out DateTime created_at))
                {
                    var s = $"{created_at.ToString("yyyy-MM-dd HH:mm:ss")}, {Math.Round(F.file.sizeInBytes / 1048576f, 2)}MB";
                    if (arg is ApiWorld world)
                    {
                        var L = LocationInfo.Parse(textbox_world_location.Text, false);
                        if (L != null &&
                            L.WorldId.Equals(world.id))
                        {
                            textbox_world_info.Text = s;
                        }
                    }
                    else if (arg is ApiAvatar avatar)
                    {
                        if (textbox_avatar_id.Text.Equals(avatar.id))
                        {
                            textbox_avatar_info.Text = s;
                        }
                    }
                }
            }
        }

        //
        // World
        //

        private void picturebox_world_DoubleClick(object sender, EventArgs e)
        {
            if (picturebox_world.Tag is string url &&
                !string.IsNullOrEmpty(url))
            {
                Process.Start(url);
            }
        }

        private void textbox_world_location_KeyDown(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                e.Handled = true;
                button_world_refresh_Click(sender, e);
            }
        }

        private void textbox_world_author_DoubleClick(object sender, EventArgs e)
        {
            if (textbox_world_author.Tag is string id &&
                !string.IsNullOrEmpty(id))
            {
                textbox_user_id.Text = id;
                ApiUser.Fetch(id);
                tabcontrol_main.SelectedTab = tabpage_user;
                tabpage_user.Focus();
            }
        }

        private void listview_world_instances_Click(object sender, EventArgs e)
        {
            if (listview_world_instances.Focused &&
                listview_world_instances.SelectedItems.Count > 0 &&
                listview_world_instances.SelectedItems[0].Tag is string tag)
            {
                var L = LocationInfo.Parse(tag);
                if (L != null)
                {
                    textbox_world_location.Text = tag;
                    ApiWorldInstance.Fetch(L.WorldId, L.InstanceId);
                }
            }
        }

        private void listview_world_instance_users_Click(object sender, EventArgs e)
        {
            if (listview_world_instance_users.Focused &&
                listview_world_instance_users.SelectedItems.Count > 0 &&
                listview_world_instance_users.SelectedItems[0].Tag is ApiUser user)
            {
                textbox_user_id.Text = user.id;
                ApiUser.Fetch(user.id);
                tabcontrol_main.SelectedTab = tabpage_user;
                tabpage_user.Focus();
            }
        }

        private void button_world_favorite_Click(object sender, EventArgs e)
        {
            var L = LocationInfo.Parse(textbox_world_location.Text, false);
            if (L != null)
            {
                m_NextFetchFavorite = DateTime.MinValue;
                ApiFavorite.AddFavorite(L.WorldId, ApiFavorite.FavoriteType.World);
            }
        }

        private void button_world_unfavorite_Click(object sender, EventArgs e)
        {
            var L = LocationInfo.Parse(textbox_world_location.Text, false);
            if (L != null)
            {
                m_NextFetchFavorite = DateTime.MinValue;
                ApiFavorite.RemoveFavorite(L.WorldId);
            }
        }

        private void button_world_new_Click(object sender, EventArgs e)
        {
            if (m_CurrentUser != null)
            {
                var world = string.Empty;
                var L = LocationInfo.Parse(textbox_world_location.Text, false);
                if (L != null)
                {
                    world = L.WorldId;
                }
                new NewInstanceForm().Run(m_CurrentUser.id, world);
            }
        }

        private void button_world_join_Click(object sender, EventArgs e)
        {
            var location = textbox_world_location.Text;
            var L = LocationInfo.Parse(location);
            if (L != null)
            {
                var s = $"vrchat://launch?id={location}";
                if (MessageBox.Show(this, s, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Process.Start(s);
                }
            }
        }

        private void button_world_refresh_Click(object sender, EventArgs e)
        {
            var L = LocationInfo.Parse(textbox_world_location.Text, false);
            if (L != null)
            {
                if (!string.IsNullOrEmpty(L.InstanceId))
                {
                    ApiWorld.Fetch(L.WorldId);
                    ApiWorldInstance.Fetch(L.WorldId, L.InstanceId);
                }
                else
                {
                    listview_world_instance_users.Items.Clear();
                    textbox_world_instance_occupants.Text = string.Empty;
                    ApiWorld.Fetch(L.WorldId);
                }
            }
        }

        //
        // User
        //

        private void picturebox_user_DoubleClick(object sender, EventArgs e)
        {
            if (picturebox_user.Tag is string url &&
                !string.IsNullOrEmpty(url))
            {
                Process.Start(url);
            }
        }

        private void textbox_user_id_KeyDown(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                var id = textbox_user_id.Text;
                if (!string.IsNullOrEmpty(id))
                {
                    ApiUser.Fetch(id);
                    e.Handled = true;
                }
            }
        }

        private void button_user_friend_Click(object sender, EventArgs e)
        {
            var id = textbox_user_id.Text;
            if (!string.IsNullOrEmpty(id))
            {
                switch (button_user_friend.Text)
                {
                    case "Add Friend":
                        ApiUser.SendFriendRequest(id);
                        break;
                    case "Unfriend":
                        if (MessageBox.Show($"Are you sure you want to remove {textbox_user_name.Text} as your friend?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            ApiUser.UnfriendUser(id);
                        }
                        break;
                    case "Cancel Friend Request":
                        ApiUser.CancelFriendRequest(id);
                        break;
                    case "Accept Friend Request":
                        foreach (ListViewItem item in listview_notification.Items)
                        {
                            if (item.Tag is ApiNotification notification &&
                                "friendRequest".Equals(notification.type, StringComparison.OrdinalIgnoreCase) &&
                                id.Equals(notification.senderUserId))
                            {
                                ApiUser.AcceptFriendRequest(notification.id);
                                break;
                            }
                        }
                        break;
                }
            }
        }

        private void button_user_mute_Click(object sender, EventArgs e)
        {
            var id = textbox_user_id.Text;
            if (!string.IsNullOrEmpty(id))
            {
                switch (button_user_mute.Text)
                {
                    case "Mute":
                        ApiPlayerModeration.SendModeration(id, ApiPlayerModeration.ModerationType.Mute);
                        break;
                    case "Unmute":
                        ApiPlayerModeration.DeleteModeration(id, ApiPlayerModeration.ModerationType.Mute);
                        break;
                }
            }
        }

        private void button_user_block_Click(object sender, EventArgs e)
        {
            var id = textbox_user_id.Text;
            if (!string.IsNullOrEmpty(id))
            {
                switch (button_user_block.Text)
                {
                    case "Block":
                        ApiPlayerModeration.SendModeration(id, ApiPlayerModeration.ModerationType.Block);
                        break;
                    case "Unblock":
                        ApiPlayerModeration.DeleteModeration(id, ApiPlayerModeration.ModerationType.Block);
                        break;
                }
            }
        }

        private void button_user_hide_Click(object sender, EventArgs e)
        {
            var id = textbox_user_id.Text;
            if (!string.IsNullOrEmpty(id))
            {
                switch (button_user_hide.Text)
                {
                    case "HideAvatar":
                        ApiPlayerModeration.SendModeration(id, ApiPlayerModeration.ModerationType.HideAvatar);
                        break;
                    case "ShowAvatar":
                        ApiPlayerModeration.DeleteModeration(id, ApiPlayerModeration.ModerationType.HideAvatar);
                        break;
                }
            }
        }

        private void button_user_favorite_Click(object sender, EventArgs e)
        {
            var id = textbox_user_id.Text;
            if (!string.IsNullOrEmpty(id))
            {
                if (m_CurrentUser != null)
                {
                    var form = new FriendsGroupForm
                    {
                        StartPosition = FormStartPosition.CenterParent,
                        Tag = new[]
                        {
                            m_CurrentUser.GetFriendsGroupDisplayName(0),
                            m_CurrentUser.GetFriendsGroupDisplayName(1),
                            m_CurrentUser.GetFriendsGroupDisplayName(2)
                        }
                    };
                    form.ShowDialog(this);
                    if (form.Tag is string tag)
                    {
                        m_NextFetchFavorite = DateTime.MinValue;
                        ApiFavorite.AddFavorite(id, ApiFavorite.FavoriteType.Friend, tag);
                    }
                }
            }
        }

        private void button_user_unfavorite_Click(object sender, EventArgs e)
        {
            var id = textbox_user_id.Text;
            if (!string.IsNullOrEmpty(id))
            {
                m_NextFetchFavorite = DateTime.MinValue;
                ApiFavorite.RemoveFavorite(id);
            }
        }
        
        private void button_user_authored_worlds_Click(object sender, EventArgs e)
        {
            var id = textbox_user_id.Text;
            if (!string.IsNullOrEmpty(id))
            {
                ApiWorld.FetchListByUser(id);
                tabcontrol_main.SelectedTab = tabpage_search;
                tabpage_search.Focus();
            }
        }

        private void button_user_authored_avatars_Click(object sender, EventArgs e)
        {
            var id = textbox_user_id.Text;
            if (!string.IsNullOrEmpty(id))
            {
                listview_avatars.Items.Clear();
                ApiAvatar.FetchListByUser(id);
                tabcontrol_main.SelectedTab = tabpage_avatar;
                tabpage_avatar.Focus();
            }
        }

        //
        // Search
        //

        private void textbox_search_keyword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                var keyword = textbox_search_keyword.Text;
                if (!string.IsNullOrEmpty(keyword))
                {
                    e.Handled = true;
                    ApiWorld.FetchList(keyword);
                    listview_search_users.ShowGroups = false;
                    ApiUser.FetchUsers(keyword);
                }
            }
        }

        private void listview_search_worlds_Click(object sender, EventArgs e)
        {
            if (listview_search_worlds.Focused &&
                listview_search_worlds.SelectedItems.Count > 0 &&
                listview_search_worlds.SelectedItems[0].Tag is ApiWorld world)
            {
                listview_world_instance_users.Items.Clear();
                textbox_world_instance_occupants.Text = string.Empty;
                textbox_world_location.Text = world.id;
                ApiWorld.Fetch(world.id);
                tabcontrol_main.SelectedTab = tabpage_world;
                tabpage_world.Focus();
            }
        }

        private void listview_search_users_Click(object sender, EventArgs e)
        {
            if (listview_search_users.Focused &&
                listview_search_users.SelectedItems.Count > 0 &&
                listview_search_users.SelectedItems[0].Tag is ApiUser user)
            {
                textbox_user_id.Text = user.id;
                ApiUser.Fetch(user.id);
                tabcontrol_main.SelectedTab = tabpage_user;
                tabpage_user.Focus();
            }
        }

        private void button_search_favorite_user_Click(object sender, EventArgs e)
        {
            listview_search_users.ShowGroups = true;
            ApiUser.FetchAllFavoriteFriends();
        }

        private void button_search_recent_worlds_Click(object sender, EventArgs e)
        {
            ApiWorld.FetchRecentList();
        }

        private void button_search_favorite_worlds_Click(object sender, EventArgs e)
        {
            ApiWorld.FetchFavoriteList();
        }

        private void button_search_my_worlds_Click(object sender, EventArgs e)
        {
            ApiWorld.FetchMyList();
        }

        //
        // Avatar
        //

        private void picturebox_avatar_DoubleClick(object sender, EventArgs e)
        {
            if (picturebox_avatar.Tag is string url &&
                !string.IsNullOrEmpty(url))
            {
                Process.Start(url);
            }
        }

        private void textbox_avatar_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                var id = textbox_avatar_id.Text;
                if (!string.IsNullOrEmpty(id))
                {
                    e.Handled = true;
                    ApiAvatar.Fetch(id);
                }
            }
        }

        private void textbox_avatar_author_DoubleClick(object sender, EventArgs e)
        {
            if (textbox_avatar_author.Tag is string id &&
                !string.IsNullOrEmpty(id))
            {
                textbox_user_id.Text = id;
                ApiUser.Fetch(id);
                tabcontrol_main.SelectedTab = tabpage_user;
                tabpage_user.Focus();
            }
        }

        private void listview_avatars_Click(object sender, EventArgs e)
        {
            if (listview_avatars.Focused &&
                listview_avatars.SelectedItems.Count > 0 &&
                listview_avatars.SelectedItems[0].Tag is ApiAvatar avatar)
            {
                textbox_avatar_id.Text = avatar.id;
                ApiAvatar.Fetch(avatar.id);
            }
        }

        private void button_avatar_favorite_Click(object sender, EventArgs e)
        {
            var id = textbox_avatar_id.Text;
            if (!string.IsNullOrEmpty(id))
            {
                m_NextFetchFavorite = DateTime.MinValue;
                ApiFavorite.AddFavorite(id, ApiFavorite.FavoriteType.Avatar);
            }
        }

        private void button_avatar_unfavorite_Click(object sender, EventArgs e)
        {
            var id = textbox_avatar_id.Text;
            if (!string.IsNullOrEmpty(id))
            {
                m_NextFetchFavorite = DateTime.MinValue;
                ApiFavorite.RemoveFavorite(id);
            }
        }

        private void button_avatar_favorite_avatars_Click(object sender, EventArgs e)
        {
            listview_avatars.Items.Clear();
            ApiAvatar.FetchFavoriteList();
        }

        private void button_avatar_my_avatars_Click(object sender, EventArgs e)
        {
            if (m_CurrentUser != null)
            {
                var id = m_CurrentUser.currentAvatar;
                if (!string.IsNullOrEmpty(id))
                {
                    textbox_avatar_id.Text = id;
                    ApiAvatar.Fetch(id);
                }
                listview_avatars.Items.Clear();
                ApiAvatar.FetchMyList();
            }
        }

        //
        // Moderation
        //

        private void listview_moderations_Click(object sender, EventArgs e)
        {
            if (listview_moderations.Focused &&
                listview_moderations.SelectedItems.Count > 0 &&
                listview_moderations.SelectedItems[0].Tag is ApiPlayerModeration moderation)
            {
                textbox_user_id.Text = moderation.targetUserId;
                ApiUser.Fetch(moderation.targetUserId);
                tabcontrol_main.SelectedTab = tabpage_user;
                tabpage_user.Focus();
            }
        }

        private void listview_moderations_againstme_Click(object sender, EventArgs e)
        {
            if (listview_moderations_againstme.Focused &&
                listview_moderations_againstme.SelectedItems.Count > 0 &&
                listview_moderations_againstme.SelectedItems[0].Tag is ApiPlayerModeration moderation)
            {
                textbox_user_id.Text = moderation.sourceUserId;
                ApiUser.Fetch(moderation.sourceUserId);
                tabcontrol_main.SelectedTab = tabpage_user;
                tabpage_user.Focus();
            }
        }

        private void button_moderation_refresh_Click(object sender, EventArgs e)
        {
            m_NextFetchModeration = DateTime.MinValue;
        }

        //
        // Notification
        //

        private void listview_notification_Click(object sender, EventArgs e)
        {
            if (listview_notification.Focused &&
                listview_notification.SelectedItems.Count > 0 &&
                listview_notification.SelectedItems[0].Tag is ApiNotification notification)
            {
                if ("message".Equals(notification.type, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(notification.message);
                }
            }
        }

        private void listview_notification_DoubleClick(object sender, EventArgs e)
        {
            if (listview_notification.Focused &&
                listview_notification.SelectedItems.Count > 0 &&
                listview_notification.SelectedItems[0].Tag is ApiNotification notification)
            {
                textbox_user_id.Text = notification.senderUserId;
                ApiUser.Fetch(notification.senderUserId);
                tabcontrol_main.SelectedTab = tabpage_user;
                tabpage_user.Focus();
            }
        }

        private void listview_notification_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
                button_notification_decline_Click(sender, e);
            }
        }

        private void button_notification_accept_Click(object sender, EventArgs e)
        {
            if (listview_notification.SelectedItems.Count > 0 &&
                listview_notification.SelectedItems[0].Tag is ApiNotification notification)
            {
                ApiUser.AcceptFriendRequest(notification.id);
            }
        }

        private void button_notification_decline_Click(object sender, EventArgs e)
        {
            if (listview_notification.SelectedItems.Count > 0 &&
                listview_notification.SelectedItems[0].Tag is ApiNotification notification)
            {
                ApiUser.DeclineFriendRequest(notification.id);
            }
        }

        private void button_notification_refresh_Click(object sender, EventArgs e)
        {
            m_NextFetchNotification = DateTime.MinValue;
            m_LatestNotification = DateTime.MinValue;
            listview_notification.Items.Clear();
        }

        //
        // Option
        //

        private void button_logout_Click(object sender, EventArgs e)
        {
            LastLoginSuccess = false;
            VRCApi.ClearCookie();
            OnLogin();
        }

        private void button_friends_list_Click(object sender, EventArgs e)
        {
            if (FriendsListForm.Instance == null)
            {
                var form = new FriendsListForm();
                form.Location = new Point(Location.X + (Width - form.Width) / 2, Location.Y + (Height - form.Height) / 2);
                form.Show();
            }
        }

        private void button_update_status_Click(object sender, EventArgs e)
        {
            if (m_CurrentUser != null)
            {
                ApiUser.SetStatus(m_CurrentUser.id, combobox_status.Text, textbox_status.Text);
            }
        }

        private void textbox_search_friend_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                var keyword = textbox_search_friend.Text;
                if (!string.IsNullOrEmpty(keyword))
                {
                    if (m_SearchFriendResult == null ||
                        !keyword.Equals(m_SearchFriendKeyword))
                    {
                        var result = new List<string>();
                        foreach (ListViewItem item in listview_online_friends.Items)
                        {
                            if (item.Tag is ApiUser user &&
                                !string.IsNullOrEmpty(user.displayName) &&
                                user.displayName.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                result.Add(user.id);
                            }
                        }
                        foreach (ListViewItem item in listview_offline_friends.Items)
                        {
                            if (item.Tag is ApiUser user &&
                                !string.IsNullOrEmpty(user.displayName) &&
                                user.displayName.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                result.Add(user.id);
                            }
                        }
                        m_SearchFriendKeyword = keyword;
                        m_SearchFriendResult = result.ToArray();
                        m_SearchFriendIndex = 0;
                    }
                    if (m_SearchFriendResult.Length > 0)
                    {
                        if (m_Friends.TryGetValue(m_SearchFriendResult[m_SearchFriendIndex], out ListViewItem item) &&
                            item.Tag is ApiUser user)
                        {
                            var listview = item.ListView;
                            if (listview != null &&
                                listview.Parent is TabPage tabpage)
                            {
                                tabcontrol_friends.SelectedTab = tabpage;
                                listview.BeginUpdate();
                                item.Focused = true;
                                item.Selected = true;
                                item.EnsureVisible();
                                listview.EndUpdate();
                            }
                        }
                        m_SearchFriendIndex = (m_SearchFriendIndex + 1) % m_SearchFriendResult.Length;
                    }
                }
                textbox_search_friend.Focus();
                e.Handled = m_SearchFriendResult != null && m_SearchFriendResult.Length > 0; // remove ding sound
            }
        }
    }
}