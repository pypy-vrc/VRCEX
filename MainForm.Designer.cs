namespace VRCEX
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.imagelist_listbox = new System.Windows.Forms.ImageList(this.components);
            this.imagelist_picturebox = new System.Windows.Forms.ImageList(this.components);
            this.listview_log = new System.Windows.Forms.ListView();
            this.listview_log_message = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabcontrol_main = new System.Windows.Forms.TabControl();
            this.tabpage_world = new System.Windows.Forms.TabPage();
            this.listview_world_instance_users = new System.Windows.Forms.ListView();
            this.listview_world_instances = new System.Windows.Forms.ListView();
            this.listview_world_instances_instance = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textbox_world_instance_occupants = new System.Windows.Forms.TextBox();
            this.button_world_new = new System.Windows.Forms.Button();
            this.button_world_join = new System.Windows.Forms.Button();
            this.button_world_refresh = new System.Windows.Forms.Button();
            this.button_world_unfavorite = new System.Windows.Forms.Button();
            this.button_world_favorite = new System.Windows.Forms.Button();
            this.textbox_world_description = new System.Windows.Forms.TextBox();
            this.textbox_world_info = new System.Windows.Forms.TextBox();
            this.textbox_world_author = new System.Windows.Forms.TextBox();
            this.textbox_world_name = new System.Windows.Forms.TextBox();
            this.textbox_world_location = new System.Windows.Forms.TextBox();
            this.picturebox_world = new System.Windows.Forms.PictureBox();
            this.tabpage_user = new System.Windows.Forms.TabPage();
            this.textbox_user_status = new System.Windows.Forms.TextBox();
            this.button_user_unfavorite = new System.Windows.Forms.Button();
            this.button_user_hide = new System.Windows.Forms.Button();
            this.button_user_block = new System.Windows.Forms.Button();
            this.button_user_mute = new System.Windows.Forms.Button();
            this.button_user_authored_avatars = new System.Windows.Forms.Button();
            this.button_user_authored_worlds = new System.Windows.Forms.Button();
            this.button_user_friend = new System.Windows.Forms.Button();
            this.button_user_favorite = new System.Windows.Forms.Button();
            this.textbox_user_info = new System.Windows.Forms.TextBox();
            this.textbox_user_level = new System.Windows.Forms.TextBox();
            this.textbox_user_name = new System.Windows.Forms.TextBox();
            this.textbox_user_id = new System.Windows.Forms.TextBox();
            this.picturebox_user = new System.Windows.Forms.PictureBox();
            this.tabpage_search = new System.Windows.Forms.TabPage();
            this.button_search_favorite_worlds = new System.Windows.Forms.Button();
            this.button_search_favorite_users = new System.Windows.Forms.Button();
            this.button_search_my_worlds = new System.Windows.Forms.Button();
            this.button_search_recent_worlds = new System.Windows.Forms.Button();
            this.listview_search_worlds = new System.Windows.Forms.ListView();
            this.listview_search_worlds_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listview_search_worlds_occupants = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listview_search_users = new System.Windows.Forms.ListView();
            this.textbox_search_keyword = new System.Windows.Forms.TextBox();
            this.tabpage_avatar = new System.Windows.Forms.TabPage();
            this.button_avatar_assign = new System.Windows.Forms.Button();
            this.button_avatar_unfavorite = new System.Windows.Forms.Button();
            this.button_avatar_favorite = new System.Windows.Forms.Button();
            this.listview_avatars = new System.Windows.Forms.ListView();
            this.button_avatar_favorite_avatars = new System.Windows.Forms.Button();
            this.button_avatar_my_avatars = new System.Windows.Forms.Button();
            this.textbox_avatar_description = new System.Windows.Forms.TextBox();
            this.textbox_avatar_info = new System.Windows.Forms.TextBox();
            this.textbox_avatar_author = new System.Windows.Forms.TextBox();
            this.textbox_avatar_name = new System.Windows.Forms.TextBox();
            this.textbox_avatar_id = new System.Windows.Forms.TextBox();
            this.picturebox_avatar = new System.Windows.Forms.PictureBox();
            this.tabpage_moderation = new System.Windows.Forms.TabPage();
            this.checkbox_moderation_view_all = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_moderation_refresh = new System.Windows.Forms.Button();
            this.listview_moderations_againstme = new System.Windows.Forms.ListView();
            this.listview_moderations_againstme_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listview_moderations_againstme_type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listview_moderations_againstme_created = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listview_moderations = new System.Windows.Forms.ListView();
            this.listview_moderations_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listview_moderations_type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listview_moderations_created = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabpage_notification = new System.Windows.Forms.TabPage();
            this.button_notification_decline = new System.Windows.Forms.Button();
            this.button_notification_accept = new System.Windows.Forms.Button();
            this.button_notification_refresh = new System.Windows.Forms.Button();
            this.listview_notification = new System.Windows.Forms.ListView();
            this.listview_notification_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listview_notification_type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listview_notification_created_at = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabpage_about = new System.Windows.Forms.TabPage();
            this.button_friends_list = new System.Windows.Forms.Button();
            this.groupbox_status = new System.Windows.Forms.GroupBox();
            this.button_update_status = new System.Windows.Forms.Button();
            this.textbox_status = new System.Windows.Forms.TextBox();
            this.combobox_status = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label_author = new System.Windows.Forms.Label();
            this.label_link = new System.Windows.Forms.Label();
            this.textbox_search_friend = new System.Windows.Forms.TextBox();
            this.label_visits = new System.Windows.Forms.Label();
            this.button_logout = new System.Windows.Forms.Button();
            this.tabcontrol_friends = new System.Windows.Forms.TabControl();
            this.tabpage_online = new System.Windows.Forms.TabPage();
            this.listview_online_friends = new System.Windows.Forms.ListView();
            this.listview_online_friends_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listview_onlnie_friends_world = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabpage_offline = new System.Windows.Forms.TabPage();
            this.listview_offline_friends = new System.Windows.Forms.ListView();
            this.listview_offline_friends_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listview_offline_friends_world = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabcontrol_main.SuspendLayout();
            this.tabpage_world.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_world)).BeginInit();
            this.tabpage_user.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_user)).BeginInit();
            this.tabpage_search.SuspendLayout();
            this.tabpage_avatar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_avatar)).BeginInit();
            this.tabpage_moderation.SuspendLayout();
            this.tabpage_notification.SuspendLayout();
            this.tabpage_about.SuspendLayout();
            this.groupbox_status.SuspendLayout();
            this.tabcontrol_friends.SuspendLayout();
            this.tabpage_online.SuspendLayout();
            this.tabpage_offline.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // imagelist_listbox
            // 
            this.imagelist_listbox.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
            this.imagelist_listbox.ImageSize = new System.Drawing.Size(60, 45);
            this.imagelist_listbox.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imagelist_picturebox
            // 
            this.imagelist_picturebox.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
            this.imagelist_picturebox.ImageSize = new System.Drawing.Size(240, 180);
            this.imagelist_picturebox.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // listview_log
            // 
            this.listview_log.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listview_log_message});
            this.listview_log.FullRowSelect = true;
            this.listview_log.GridLines = true;
            this.listview_log.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listview_log.Location = new System.Drawing.Point(12, 488);
            this.listview_log.Name = "listview_log";
            this.listview_log.ShowItemToolTips = true;
            this.listview_log.Size = new System.Drawing.Size(758, 61);
            this.listview_log.TabIndex = 2;
            this.listview_log.UseCompatibleStateImageBehavior = false;
            this.listview_log.View = System.Windows.Forms.View.Details;
            this.listview_log.DoubleClick += new System.EventHandler(this.listview_log_DoubleClick);
            this.listview_log.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listview_log_KeyDown);
            // 
            // listview_log_message
            // 
            this.listview_log_message.Text = "";
            this.listview_log_message.Width = 730;
            // 
            // tabcontrol_main
            // 
            this.tabcontrol_main.Controls.Add(this.tabpage_world);
            this.tabcontrol_main.Controls.Add(this.tabpage_user);
            this.tabcontrol_main.Controls.Add(this.tabpage_search);
            this.tabcontrol_main.Controls.Add(this.tabpage_avatar);
            this.tabcontrol_main.Controls.Add(this.tabpage_moderation);
            this.tabcontrol_main.Controls.Add(this.tabpage_notification);
            this.tabcontrol_main.Controls.Add(this.tabpage_about);
            this.tabcontrol_main.Location = new System.Drawing.Point(12, 12);
            this.tabcontrol_main.Name = "tabcontrol_main";
            this.tabcontrol_main.SelectedIndex = 0;
            this.tabcontrol_main.Size = new System.Drawing.Size(504, 470);
            this.tabcontrol_main.TabIndex = 0;
            // 
            // tabpage_world
            // 
            this.tabpage_world.Controls.Add(this.listview_world_instance_users);
            this.tabpage_world.Controls.Add(this.listview_world_instances);
            this.tabpage_world.Controls.Add(this.textbox_world_instance_occupants);
            this.tabpage_world.Controls.Add(this.button_world_new);
            this.tabpage_world.Controls.Add(this.button_world_join);
            this.tabpage_world.Controls.Add(this.button_world_refresh);
            this.tabpage_world.Controls.Add(this.button_world_unfavorite);
            this.tabpage_world.Controls.Add(this.button_world_favorite);
            this.tabpage_world.Controls.Add(this.textbox_world_description);
            this.tabpage_world.Controls.Add(this.textbox_world_info);
            this.tabpage_world.Controls.Add(this.textbox_world_author);
            this.tabpage_world.Controls.Add(this.textbox_world_name);
            this.tabpage_world.Controls.Add(this.textbox_world_location);
            this.tabpage_world.Controls.Add(this.picturebox_world);
            this.tabpage_world.Location = new System.Drawing.Point(4, 22);
            this.tabpage_world.Name = "tabpage_world";
            this.tabpage_world.Padding = new System.Windows.Forms.Padding(3);
            this.tabpage_world.Size = new System.Drawing.Size(496, 444);
            this.tabpage_world.TabIndex = 0;
            this.tabpage_world.Text = "World";
            this.tabpage_world.UseVisualStyleBackColor = true;
            // 
            // listview_world_instance_users
            // 
            this.listview_world_instance_users.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listview_world_instance_users.LargeImageList = this.imagelist_listbox;
            this.listview_world_instance_users.Location = new System.Drawing.Point(4, 192);
            this.listview_world_instance_users.MultiSelect = false;
            this.listview_world_instance_users.Name = "listview_world_instance_users";
            this.listview_world_instance_users.ShowGroups = false;
            this.listview_world_instance_users.ShowItemToolTips = true;
            this.listview_world_instance_users.Size = new System.Drawing.Size(486, 190);
            this.listview_world_instance_users.SmallImageList = this.imagelist_listbox;
            this.listview_world_instance_users.TabIndex = 5;
            this.listview_world_instance_users.TileSize = new System.Drawing.Size(150, 50);
            this.listview_world_instance_users.UseCompatibleStateImageBehavior = false;
            this.listview_world_instance_users.View = System.Windows.Forms.View.Tile;
            this.listview_world_instance_users.Click += new System.EventHandler(this.listview_world_instance_users_Click);
            // 
            // listview_world_instances
            // 
            this.listview_world_instances.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listview_world_instances.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listview_world_instances_instance});
            this.listview_world_instances.FullRowSelect = true;
            this.listview_world_instances.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listview_world_instances.Location = new System.Drawing.Point(252, 128);
            this.listview_world_instances.MultiSelect = false;
            this.listview_world_instances.Name = "listview_world_instances";
            this.listview_world_instances.ShowItemToolTips = true;
            this.listview_world_instances.Size = new System.Drawing.Size(238, 58);
            this.listview_world_instances.TabIndex = 4;
            this.listview_world_instances.UseCompatibleStateImageBehavior = false;
            this.listview_world_instances.View = System.Windows.Forms.View.List;
            this.listview_world_instances.Click += new System.EventHandler(this.listview_world_instances_Click);
            // 
            // listview_world_instances_instance
            // 
            this.listview_world_instances_instance.Text = "Instance";
            this.listview_world_instances_instance.Width = 120;
            // 
            // textbox_world_instance_occupants
            // 
            this.textbox_world_instance_occupants.Location = new System.Drawing.Point(454, 388);
            this.textbox_world_instance_occupants.Name = "textbox_world_instance_occupants";
            this.textbox_world_instance_occupants.ReadOnly = true;
            this.textbox_world_instance_occupants.Size = new System.Drawing.Size(35, 21);
            this.textbox_world_instance_occupants.TabIndex = 7;
            this.textbox_world_instance_occupants.Text = "0";
            this.textbox_world_instance_occupants.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_world_new
            // 
            this.button_world_new.Location = new System.Drawing.Point(253, 415);
            this.button_world_new.Name = "button_world_new";
            this.button_world_new.Size = new System.Drawing.Size(75, 23);
            this.button_world_new.TabIndex = 10;
            this.button_world_new.Text = "New";
            this.button_world_new.UseVisualStyleBackColor = true;
            this.button_world_new.Click += new System.EventHandler(this.button_world_new_Click);
            // 
            // button_world_join
            // 
            this.button_world_join.Location = new System.Drawing.Point(334, 415);
            this.button_world_join.Name = "button_world_join";
            this.button_world_join.Size = new System.Drawing.Size(75, 23);
            this.button_world_join.TabIndex = 11;
            this.button_world_join.Text = "Join";
            this.button_world_join.UseVisualStyleBackColor = true;
            this.button_world_join.Click += new System.EventHandler(this.button_world_join_Click);
            // 
            // button_world_refresh
            // 
            this.button_world_refresh.Location = new System.Drawing.Point(415, 415);
            this.button_world_refresh.Name = "button_world_refresh";
            this.button_world_refresh.Size = new System.Drawing.Size(75, 23);
            this.button_world_refresh.TabIndex = 12;
            this.button_world_refresh.Text = "Refresh";
            this.button_world_refresh.UseVisualStyleBackColor = true;
            this.button_world_refresh.Click += new System.EventHandler(this.button_world_refresh_Click);
            // 
            // button_world_unfavorite
            // 
            this.button_world_unfavorite.Location = new System.Drawing.Point(87, 415);
            this.button_world_unfavorite.Name = "button_world_unfavorite";
            this.button_world_unfavorite.Size = new System.Drawing.Size(75, 23);
            this.button_world_unfavorite.TabIndex = 9;
            this.button_world_unfavorite.Text = "Unfavorite";
            this.button_world_unfavorite.UseVisualStyleBackColor = true;
            this.button_world_unfavorite.Click += new System.EventHandler(this.button_world_unfavorite_Click);
            // 
            // button_world_favorite
            // 
            this.button_world_favorite.Location = new System.Drawing.Point(6, 415);
            this.button_world_favorite.Name = "button_world_favorite";
            this.button_world_favorite.Size = new System.Drawing.Size(75, 23);
            this.button_world_favorite.TabIndex = 8;
            this.button_world_favorite.Text = "Favorite";
            this.button_world_favorite.UseVisualStyleBackColor = true;
            this.button_world_favorite.Click += new System.EventHandler(this.button_world_favorite_Click);
            // 
            // textbox_world_description
            // 
            this.textbox_world_description.BackColor = System.Drawing.SystemColors.Window;
            this.textbox_world_description.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textbox_world_description.Location = new System.Drawing.Point(252, 72);
            this.textbox_world_description.Multiline = true;
            this.textbox_world_description.Name = "textbox_world_description";
            this.textbox_world_description.ReadOnly = true;
            this.textbox_world_description.Size = new System.Drawing.Size(238, 50);
            this.textbox_world_description.TabIndex = 3;
            // 
            // textbox_world_info
            // 
            this.textbox_world_info.BackColor = System.Drawing.SystemColors.Window;
            this.textbox_world_info.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textbox_world_info.Location = new System.Drawing.Point(252, 52);
            this.textbox_world_info.Name = "textbox_world_info";
            this.textbox_world_info.ReadOnly = true;
            this.textbox_world_info.Size = new System.Drawing.Size(238, 14);
            this.textbox_world_info.TabIndex = 2;
            this.textbox_world_info.DoubleClick += new System.EventHandler(this.textbox_world_author_DoubleClick);
            // 
            // textbox_world_author
            // 
            this.textbox_world_author.BackColor = System.Drawing.SystemColors.Window;
            this.textbox_world_author.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textbox_world_author.Cursor = System.Windows.Forms.Cursors.UpArrow;
            this.textbox_world_author.Location = new System.Drawing.Point(252, 32);
            this.textbox_world_author.Name = "textbox_world_author";
            this.textbox_world_author.ReadOnly = true;
            this.textbox_world_author.Size = new System.Drawing.Size(238, 14);
            this.textbox_world_author.TabIndex = 1;
            this.textbox_world_author.DoubleClick += new System.EventHandler(this.textbox_world_author_DoubleClick);
            // 
            // textbox_world_name
            // 
            this.textbox_world_name.BackColor = System.Drawing.SystemColors.Window;
            this.textbox_world_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textbox_world_name.Location = new System.Drawing.Point(252, 12);
            this.textbox_world_name.Name = "textbox_world_name";
            this.textbox_world_name.ReadOnly = true;
            this.textbox_world_name.Size = new System.Drawing.Size(238, 14);
            this.textbox_world_name.TabIndex = 0;
            // 
            // textbox_world_location
            // 
            this.textbox_world_location.Location = new System.Drawing.Point(6, 388);
            this.textbox_world_location.Name = "textbox_world_location";
            this.textbox_world_location.Size = new System.Drawing.Size(442, 21);
            this.textbox_world_location.TabIndex = 6;
            this.textbox_world_location.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_world_location_KeyDown);
            // 
            // picturebox_world
            // 
            this.picturebox_world.Location = new System.Drawing.Point(6, 6);
            this.picturebox_world.Name = "picturebox_world";
            this.picturebox_world.Size = new System.Drawing.Size(240, 180);
            this.picturebox_world.TabIndex = 0;
            this.picturebox_world.TabStop = false;
            this.picturebox_world.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.picturebox_world_MouseDoubleClick);
            // 
            // tabpage_user
            // 
            this.tabpage_user.Controls.Add(this.textbox_user_status);
            this.tabpage_user.Controls.Add(this.button_user_unfavorite);
            this.tabpage_user.Controls.Add(this.button_user_hide);
            this.tabpage_user.Controls.Add(this.button_user_block);
            this.tabpage_user.Controls.Add(this.button_user_mute);
            this.tabpage_user.Controls.Add(this.button_user_authored_avatars);
            this.tabpage_user.Controls.Add(this.button_user_authored_worlds);
            this.tabpage_user.Controls.Add(this.button_user_friend);
            this.tabpage_user.Controls.Add(this.button_user_favorite);
            this.tabpage_user.Controls.Add(this.textbox_user_info);
            this.tabpage_user.Controls.Add(this.textbox_user_level);
            this.tabpage_user.Controls.Add(this.textbox_user_name);
            this.tabpage_user.Controls.Add(this.textbox_user_id);
            this.tabpage_user.Controls.Add(this.picturebox_user);
            this.tabpage_user.Location = new System.Drawing.Point(4, 22);
            this.tabpage_user.Name = "tabpage_user";
            this.tabpage_user.Padding = new System.Windows.Forms.Padding(3);
            this.tabpage_user.Size = new System.Drawing.Size(496, 444);
            this.tabpage_user.TabIndex = 1;
            this.tabpage_user.Text = "User";
            this.tabpage_user.UseVisualStyleBackColor = true;
            // 
            // textbox_user_status
            // 
            this.textbox_user_status.BackColor = System.Drawing.SystemColors.Window;
            this.textbox_user_status.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textbox_user_status.Location = new System.Drawing.Point(252, 72);
            this.textbox_user_status.Multiline = true;
            this.textbox_user_status.Name = "textbox_user_status";
            this.textbox_user_status.ReadOnly = true;
            this.textbox_user_status.Size = new System.Drawing.Size(238, 57);
            this.textbox_user_status.TabIndex = 3;
            // 
            // button_user_unfavorite
            // 
            this.button_user_unfavorite.Location = new System.Drawing.Point(87, 415);
            this.button_user_unfavorite.Name = "button_user_unfavorite";
            this.button_user_unfavorite.Size = new System.Drawing.Size(75, 23);
            this.button_user_unfavorite.TabIndex = 10;
            this.button_user_unfavorite.Text = "Unfavorite";
            this.button_user_unfavorite.UseVisualStyleBackColor = true;
            this.button_user_unfavorite.Click += new System.EventHandler(this.button_user_unfavorite_Click);
            // 
            // button_user_hide
            // 
            this.button_user_hide.Location = new System.Drawing.Point(404, 163);
            this.button_user_hide.Name = "button_user_hide";
            this.button_user_hide.Size = new System.Drawing.Size(86, 23);
            this.button_user_hide.TabIndex = 7;
            this.button_user_hide.Text = "HideAvatar";
            this.button_user_hide.UseVisualStyleBackColor = true;
            this.button_user_hide.Click += new System.EventHandler(this.button_user_hide_Click);
            // 
            // button_user_block
            // 
            this.button_user_block.Location = new System.Drawing.Point(328, 163);
            this.button_user_block.Name = "button_user_block";
            this.button_user_block.Size = new System.Drawing.Size(70, 23);
            this.button_user_block.TabIndex = 6;
            this.button_user_block.Text = "Block";
            this.button_user_block.UseVisualStyleBackColor = true;
            this.button_user_block.Click += new System.EventHandler(this.button_user_block_Click);
            // 
            // button_user_mute
            // 
            this.button_user_mute.Location = new System.Drawing.Point(252, 163);
            this.button_user_mute.Name = "button_user_mute";
            this.button_user_mute.Size = new System.Drawing.Size(70, 23);
            this.button_user_mute.TabIndex = 5;
            this.button_user_mute.Text = "Mute";
            this.button_user_mute.UseVisualStyleBackColor = true;
            this.button_user_mute.Click += new System.EventHandler(this.button_user_mute_Click);
            // 
            // button_user_authored_avatars
            // 
            this.button_user_authored_avatars.Location = new System.Drawing.Point(390, 415);
            this.button_user_authored_avatars.Name = "button_user_authored_avatars";
            this.button_user_authored_avatars.Size = new System.Drawing.Size(100, 23);
            this.button_user_authored_avatars.TabIndex = 12;
            this.button_user_authored_avatars.Text = "Public Avatars";
            this.button_user_authored_avatars.UseVisualStyleBackColor = true;
            this.button_user_authored_avatars.Click += new System.EventHandler(this.button_user_authored_avatars_Click);
            // 
            // button_user_authored_worlds
            // 
            this.button_user_authored_worlds.Location = new System.Drawing.Point(284, 415);
            this.button_user_authored_worlds.Name = "button_user_authored_worlds";
            this.button_user_authored_worlds.Size = new System.Drawing.Size(100, 23);
            this.button_user_authored_worlds.TabIndex = 11;
            this.button_user_authored_worlds.Text = "Public Worlds";
            this.button_user_authored_worlds.UseVisualStyleBackColor = true;
            this.button_user_authored_worlds.Click += new System.EventHandler(this.button_user_authored_worlds_Click);
            // 
            // button_user_friend
            // 
            this.button_user_friend.Location = new System.Drawing.Point(252, 134);
            this.button_user_friend.Name = "button_user_friend";
            this.button_user_friend.Size = new System.Drawing.Size(238, 23);
            this.button_user_friend.TabIndex = 4;
            this.button_user_friend.Text = "Add Friend";
            this.button_user_friend.UseVisualStyleBackColor = true;
            this.button_user_friend.Click += new System.EventHandler(this.button_user_friend_Click);
            // 
            // button_user_favorite
            // 
            this.button_user_favorite.Location = new System.Drawing.Point(6, 415);
            this.button_user_favorite.Name = "button_user_favorite";
            this.button_user_favorite.Size = new System.Drawing.Size(75, 23);
            this.button_user_favorite.TabIndex = 9;
            this.button_user_favorite.Text = "Favorite";
            this.button_user_favorite.UseVisualStyleBackColor = true;
            this.button_user_favorite.Click += new System.EventHandler(this.button_user_favorite_Click);
            // 
            // textbox_user_info
            // 
            this.textbox_user_info.BackColor = System.Drawing.SystemColors.Window;
            this.textbox_user_info.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textbox_user_info.Location = new System.Drawing.Point(252, 52);
            this.textbox_user_info.Name = "textbox_user_info";
            this.textbox_user_info.ReadOnly = true;
            this.textbox_user_info.Size = new System.Drawing.Size(238, 14);
            this.textbox_user_info.TabIndex = 2;
            // 
            // textbox_user_level
            // 
            this.textbox_user_level.BackColor = System.Drawing.SystemColors.Window;
            this.textbox_user_level.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textbox_user_level.Location = new System.Drawing.Point(252, 32);
            this.textbox_user_level.Name = "textbox_user_level";
            this.textbox_user_level.ReadOnly = true;
            this.textbox_user_level.Size = new System.Drawing.Size(238, 14);
            this.textbox_user_level.TabIndex = 1;
            // 
            // textbox_user_name
            // 
            this.textbox_user_name.BackColor = System.Drawing.SystemColors.Window;
            this.textbox_user_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textbox_user_name.Location = new System.Drawing.Point(252, 12);
            this.textbox_user_name.Name = "textbox_user_name";
            this.textbox_user_name.ReadOnly = true;
            this.textbox_user_name.Size = new System.Drawing.Size(238, 14);
            this.textbox_user_name.TabIndex = 0;
            // 
            // textbox_user_id
            // 
            this.textbox_user_id.Location = new System.Drawing.Point(6, 388);
            this.textbox_user_id.Name = "textbox_user_id";
            this.textbox_user_id.Size = new System.Drawing.Size(483, 21);
            this.textbox_user_id.TabIndex = 8;
            this.textbox_user_id.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_user_id_KeyDown);
            // 
            // picturebox_user
            // 
            this.picturebox_user.Location = new System.Drawing.Point(6, 6);
            this.picturebox_user.Name = "picturebox_user";
            this.picturebox_user.Size = new System.Drawing.Size(240, 180);
            this.picturebox_user.TabIndex = 1;
            this.picturebox_user.TabStop = false;
            this.picturebox_user.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.picturebox_user_MouseDoubleClick);
            // 
            // tabpage_search
            // 
            this.tabpage_search.Controls.Add(this.button_search_favorite_worlds);
            this.tabpage_search.Controls.Add(this.button_search_favorite_users);
            this.tabpage_search.Controls.Add(this.button_search_my_worlds);
            this.tabpage_search.Controls.Add(this.button_search_recent_worlds);
            this.tabpage_search.Controls.Add(this.listview_search_worlds);
            this.tabpage_search.Controls.Add(this.listview_search_users);
            this.tabpage_search.Controls.Add(this.textbox_search_keyword);
            this.tabpage_search.Location = new System.Drawing.Point(4, 22);
            this.tabpage_search.Name = "tabpage_search";
            this.tabpage_search.Padding = new System.Windows.Forms.Padding(3);
            this.tabpage_search.Size = new System.Drawing.Size(496, 444);
            this.tabpage_search.TabIndex = 3;
            this.tabpage_search.Text = "Search";
            this.tabpage_search.UseVisualStyleBackColor = true;
            // 
            // button_search_favorite_worlds
            // 
            this.button_search_favorite_worlds.Location = new System.Drawing.Point(264, 415);
            this.button_search_favorite_worlds.Name = "button_search_favorite_worlds";
            this.button_search_favorite_worlds.Size = new System.Drawing.Size(110, 23);
            this.button_search_favorite_worlds.TabIndex = 5;
            this.button_search_favorite_worlds.Text = "Favorite Worlds";
            this.button_search_favorite_worlds.UseVisualStyleBackColor = true;
            this.button_search_favorite_worlds.Click += new System.EventHandler(this.button_search_favorite_worlds_Click);
            // 
            // button_search_favorite_users
            // 
            this.button_search_favorite_users.Location = new System.Drawing.Point(6, 415);
            this.button_search_favorite_users.Name = "button_search_favorite_users";
            this.button_search_favorite_users.Size = new System.Drawing.Size(110, 23);
            this.button_search_favorite_users.TabIndex = 3;
            this.button_search_favorite_users.Text = "Favorite Users";
            this.button_search_favorite_users.UseVisualStyleBackColor = true;
            this.button_search_favorite_users.Click += new System.EventHandler(this.button_search_favorite_user_Click);
            // 
            // button_search_my_worlds
            // 
            this.button_search_my_worlds.Location = new System.Drawing.Point(380, 415);
            this.button_search_my_worlds.Name = "button_search_my_worlds";
            this.button_search_my_worlds.Size = new System.Drawing.Size(110, 23);
            this.button_search_my_worlds.TabIndex = 6;
            this.button_search_my_worlds.Text = "My Worlds";
            this.button_search_my_worlds.UseVisualStyleBackColor = true;
            this.button_search_my_worlds.Click += new System.EventHandler(this.button_search_my_worlds_Click);
            // 
            // button_search_recent_worlds
            // 
            this.button_search_recent_worlds.Location = new System.Drawing.Point(148, 415);
            this.button_search_recent_worlds.Name = "button_search_recent_worlds";
            this.button_search_recent_worlds.Size = new System.Drawing.Size(110, 23);
            this.button_search_recent_worlds.TabIndex = 4;
            this.button_search_recent_worlds.Text = "Recent Worlds";
            this.button_search_recent_worlds.UseVisualStyleBackColor = true;
            this.button_search_recent_worlds.Click += new System.EventHandler(this.button_search_recent_worlds_Click);
            // 
            // listview_search_worlds
            // 
            this.listview_search_worlds.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listview_search_worlds_name,
            this.listview_search_worlds_occupants});
            this.listview_search_worlds.LargeImageList = this.imagelist_listbox;
            this.listview_search_worlds.Location = new System.Drawing.Point(6, 33);
            this.listview_search_worlds.MultiSelect = false;
            this.listview_search_worlds.Name = "listview_search_worlds";
            this.listview_search_worlds.ShowItemToolTips = true;
            this.listview_search_worlds.Size = new System.Drawing.Size(484, 185);
            this.listview_search_worlds.SmallImageList = this.imagelist_listbox;
            this.listview_search_worlds.TabIndex = 1;
            this.listview_search_worlds.TileSize = new System.Drawing.Size(230, 50);
            this.listview_search_worlds.UseCompatibleStateImageBehavior = false;
            this.listview_search_worlds.View = System.Windows.Forms.View.Tile;
            this.listview_search_worlds.Click += new System.EventHandler(this.listview_search_worlds_Click);
            // 
            // listview_search_worlds_name
            // 
            this.listview_search_worlds_name.Text = "";
            // 
            // listview_search_worlds_occupants
            // 
            this.listview_search_worlds_occupants.Text = "";
            // 
            // listview_search_users
            // 
            this.listview_search_users.LargeImageList = this.imagelist_listbox;
            this.listview_search_users.Location = new System.Drawing.Point(6, 224);
            this.listview_search_users.MultiSelect = false;
            this.listview_search_users.Name = "listview_search_users";
            this.listview_search_users.ShowItemToolTips = true;
            this.listview_search_users.Size = new System.Drawing.Size(484, 185);
            this.listview_search_users.SmallImageList = this.imagelist_listbox;
            this.listview_search_users.TabIndex = 2;
            this.listview_search_users.TileSize = new System.Drawing.Size(150, 50);
            this.listview_search_users.UseCompatibleStateImageBehavior = false;
            this.listview_search_users.View = System.Windows.Forms.View.Tile;
            this.listview_search_users.Click += new System.EventHandler(this.listview_search_users_Click);
            // 
            // textbox_search_keyword
            // 
            this.textbox_search_keyword.Location = new System.Drawing.Point(6, 6);
            this.textbox_search_keyword.Name = "textbox_search_keyword";
            this.textbox_search_keyword.Size = new System.Drawing.Size(484, 21);
            this.textbox_search_keyword.TabIndex = 0;
            this.textbox_search_keyword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_search_keyword_KeyPress);
            // 
            // tabpage_avatar
            // 
            this.tabpage_avatar.Controls.Add(this.button_avatar_assign);
            this.tabpage_avatar.Controls.Add(this.button_avatar_unfavorite);
            this.tabpage_avatar.Controls.Add(this.button_avatar_favorite);
            this.tabpage_avatar.Controls.Add(this.listview_avatars);
            this.tabpage_avatar.Controls.Add(this.button_avatar_favorite_avatars);
            this.tabpage_avatar.Controls.Add(this.button_avatar_my_avatars);
            this.tabpage_avatar.Controls.Add(this.textbox_avatar_description);
            this.tabpage_avatar.Controls.Add(this.textbox_avatar_info);
            this.tabpage_avatar.Controls.Add(this.textbox_avatar_author);
            this.tabpage_avatar.Controls.Add(this.textbox_avatar_name);
            this.tabpage_avatar.Controls.Add(this.textbox_avatar_id);
            this.tabpage_avatar.Controls.Add(this.picturebox_avatar);
            this.tabpage_avatar.Location = new System.Drawing.Point(4, 22);
            this.tabpage_avatar.Name = "tabpage_avatar";
            this.tabpage_avatar.Padding = new System.Windows.Forms.Padding(3);
            this.tabpage_avatar.Size = new System.Drawing.Size(496, 444);
            this.tabpage_avatar.TabIndex = 2;
            this.tabpage_avatar.Text = "Avatar";
            this.tabpage_avatar.UseVisualStyleBackColor = true;
            // 
            // button_avatar_assign
            // 
            this.button_avatar_assign.Location = new System.Drawing.Point(168, 415);
            this.button_avatar_assign.Name = "button_avatar_assign";
            this.button_avatar_assign.Size = new System.Drawing.Size(75, 23);
            this.button_avatar_assign.TabIndex = 7;
            this.button_avatar_assign.Text = "Assign";
            this.button_avatar_assign.UseVisualStyleBackColor = true;
            this.button_avatar_assign.Click += new System.EventHandler(this.button_avatar_assign_Click);
            // 
            // button_avatar_unfavorite
            // 
            this.button_avatar_unfavorite.Location = new System.Drawing.Point(87, 415);
            this.button_avatar_unfavorite.Name = "button_avatar_unfavorite";
            this.button_avatar_unfavorite.Size = new System.Drawing.Size(75, 23);
            this.button_avatar_unfavorite.TabIndex = 7;
            this.button_avatar_unfavorite.Text = "Unfavorite";
            this.button_avatar_unfavorite.UseVisualStyleBackColor = true;
            this.button_avatar_unfavorite.Click += new System.EventHandler(this.button_avatar_unfavorite_Click);
            // 
            // button_avatar_favorite
            // 
            this.button_avatar_favorite.Location = new System.Drawing.Point(6, 415);
            this.button_avatar_favorite.Name = "button_avatar_favorite";
            this.button_avatar_favorite.Size = new System.Drawing.Size(75, 23);
            this.button_avatar_favorite.TabIndex = 6;
            this.button_avatar_favorite.Text = "Favorite";
            this.button_avatar_favorite.UseVisualStyleBackColor = true;
            this.button_avatar_favorite.Click += new System.EventHandler(this.button_avatar_favorite_Click);
            // 
            // listview_avatars
            // 
            this.listview_avatars.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listview_avatars.LargeImageList = this.imagelist_listbox;
            this.listview_avatars.Location = new System.Drawing.Point(4, 192);
            this.listview_avatars.MultiSelect = false;
            this.listview_avatars.Name = "listview_avatars";
            this.listview_avatars.ShowGroups = false;
            this.listview_avatars.ShowItemToolTips = true;
            this.listview_avatars.Size = new System.Drawing.Size(486, 190);
            this.listview_avatars.SmallImageList = this.imagelist_listbox;
            this.listview_avatars.TabIndex = 4;
            this.listview_avatars.TileSize = new System.Drawing.Size(150, 50);
            this.listview_avatars.UseCompatibleStateImageBehavior = false;
            this.listview_avatars.View = System.Windows.Forms.View.Tile;
            this.listview_avatars.Click += new System.EventHandler(this.listview_avatars_Click);
            // 
            // button_avatar_favorite_avatars
            // 
            this.button_avatar_favorite_avatars.Location = new System.Drawing.Point(264, 415);
            this.button_avatar_favorite_avatars.Name = "button_avatar_favorite_avatars";
            this.button_avatar_favorite_avatars.Size = new System.Drawing.Size(110, 23);
            this.button_avatar_favorite_avatars.TabIndex = 8;
            this.button_avatar_favorite_avatars.Text = "Favorite Avatars";
            this.button_avatar_favorite_avatars.UseVisualStyleBackColor = true;
            this.button_avatar_favorite_avatars.Click += new System.EventHandler(this.button_avatar_favorite_avatars_Click);
            // 
            // button_avatar_my_avatars
            // 
            this.button_avatar_my_avatars.Location = new System.Drawing.Point(380, 415);
            this.button_avatar_my_avatars.Name = "button_avatar_my_avatars";
            this.button_avatar_my_avatars.Size = new System.Drawing.Size(110, 23);
            this.button_avatar_my_avatars.TabIndex = 9;
            this.button_avatar_my_avatars.Text = "My Avatars";
            this.button_avatar_my_avatars.UseVisualStyleBackColor = true;
            this.button_avatar_my_avatars.Click += new System.EventHandler(this.button_avatar_my_avatars_Click);
            // 
            // textbox_avatar_description
            // 
            this.textbox_avatar_description.BackColor = System.Drawing.SystemColors.Window;
            this.textbox_avatar_description.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textbox_avatar_description.Location = new System.Drawing.Point(252, 72);
            this.textbox_avatar_description.Multiline = true;
            this.textbox_avatar_description.Name = "textbox_avatar_description";
            this.textbox_avatar_description.ReadOnly = true;
            this.textbox_avatar_description.Size = new System.Drawing.Size(238, 50);
            this.textbox_avatar_description.TabIndex = 3;
            // 
            // textbox_avatar_info
            // 
            this.textbox_avatar_info.BackColor = System.Drawing.SystemColors.Window;
            this.textbox_avatar_info.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textbox_avatar_info.Location = new System.Drawing.Point(252, 52);
            this.textbox_avatar_info.Name = "textbox_avatar_info";
            this.textbox_avatar_info.ReadOnly = true;
            this.textbox_avatar_info.Size = new System.Drawing.Size(238, 14);
            this.textbox_avatar_info.TabIndex = 2;
            this.textbox_avatar_info.DoubleClick += new System.EventHandler(this.textbox_avatar_author_DoubleClick);
            // 
            // textbox_avatar_author
            // 
            this.textbox_avatar_author.BackColor = System.Drawing.SystemColors.Window;
            this.textbox_avatar_author.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textbox_avatar_author.Cursor = System.Windows.Forms.Cursors.UpArrow;
            this.textbox_avatar_author.Location = new System.Drawing.Point(252, 32);
            this.textbox_avatar_author.Name = "textbox_avatar_author";
            this.textbox_avatar_author.ReadOnly = true;
            this.textbox_avatar_author.Size = new System.Drawing.Size(238, 14);
            this.textbox_avatar_author.TabIndex = 1;
            this.textbox_avatar_author.DoubleClick += new System.EventHandler(this.textbox_avatar_author_DoubleClick);
            // 
            // textbox_avatar_name
            // 
            this.textbox_avatar_name.BackColor = System.Drawing.SystemColors.Window;
            this.textbox_avatar_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textbox_avatar_name.Location = new System.Drawing.Point(252, 12);
            this.textbox_avatar_name.Name = "textbox_avatar_name";
            this.textbox_avatar_name.ReadOnly = true;
            this.textbox_avatar_name.Size = new System.Drawing.Size(238, 14);
            this.textbox_avatar_name.TabIndex = 0;
            // 
            // textbox_avatar_id
            // 
            this.textbox_avatar_id.Location = new System.Drawing.Point(6, 388);
            this.textbox_avatar_id.Name = "textbox_avatar_id";
            this.textbox_avatar_id.Size = new System.Drawing.Size(483, 21);
            this.textbox_avatar_id.TabIndex = 5;
            this.textbox_avatar_id.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_avatar_id_KeyPress);
            // 
            // picturebox_avatar
            // 
            this.picturebox_avatar.Location = new System.Drawing.Point(6, 6);
            this.picturebox_avatar.Name = "picturebox_avatar";
            this.picturebox_avatar.Size = new System.Drawing.Size(240, 180);
            this.picturebox_avatar.TabIndex = 7;
            this.picturebox_avatar.TabStop = false;
            this.picturebox_avatar.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.picturebox_avatar_MouseDoubleClick);
            // 
            // tabpage_moderation
            // 
            this.tabpage_moderation.Controls.Add(this.checkbox_moderation_view_all);
            this.tabpage_moderation.Controls.Add(this.label3);
            this.tabpage_moderation.Controls.Add(this.button_moderation_refresh);
            this.tabpage_moderation.Controls.Add(this.listview_moderations_againstme);
            this.tabpage_moderation.Controls.Add(this.listview_moderations);
            this.tabpage_moderation.Location = new System.Drawing.Point(4, 22);
            this.tabpage_moderation.Name = "tabpage_moderation";
            this.tabpage_moderation.Padding = new System.Windows.Forms.Padding(3);
            this.tabpage_moderation.Size = new System.Drawing.Size(496, 444);
            this.tabpage_moderation.TabIndex = 4;
            this.tabpage_moderation.Text = "Moderation";
            this.tabpage_moderation.UseVisualStyleBackColor = true;
            // 
            // checkbox_moderation_view_all
            // 
            this.checkbox_moderation_view_all.AutoSize = true;
            this.checkbox_moderation_view_all.Location = new System.Drawing.Point(3, 422);
            this.checkbox_moderation_view_all.Name = "checkbox_moderation_view_all";
            this.checkbox_moderation_view_all.Size = new System.Drawing.Size(70, 16);
            this.checkbox_moderation_view_all.TabIndex = 4;
            this.checkbox_moderation_view_all.Text = "View All";
            this.checkbox_moderation_view_all.UseVisualStyleBackColor = true;
            this.checkbox_moderation_view_all.CheckedChanged += new System.EventHandler(this.checkbox_moderation_view_all_CheckedChanged);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label3.Location = new System.Drawing.Point(3, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(488, 1);
            this.label3.TabIndex = 1;
            // 
            // button_moderation_refresh
            // 
            this.button_moderation_refresh.Location = new System.Drawing.Point(415, 415);
            this.button_moderation_refresh.Name = "button_moderation_refresh";
            this.button_moderation_refresh.Size = new System.Drawing.Size(75, 23);
            this.button_moderation_refresh.TabIndex = 3;
            this.button_moderation_refresh.Text = "Refresh";
            this.button_moderation_refresh.UseVisualStyleBackColor = true;
            this.button_moderation_refresh.Click += new System.EventHandler(this.button_moderation_refresh_Click);
            // 
            // listview_moderations_againstme
            // 
            this.listview_moderations_againstme.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listview_moderations_againstme.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listview_moderations_againstme_name,
            this.listview_moderations_againstme_type,
            this.listview_moderations_againstme_created});
            this.listview_moderations_againstme.FullRowSelect = true;
            this.listview_moderations_againstme.GridLines = true;
            this.listview_moderations_againstme.Location = new System.Drawing.Point(6, 213);
            this.listview_moderations_againstme.MultiSelect = false;
            this.listview_moderations_againstme.Name = "listview_moderations_againstme";
            this.listview_moderations_againstme.ShowItemToolTips = true;
            this.listview_moderations_againstme.Size = new System.Drawing.Size(484, 196);
            this.listview_moderations_againstme.TabIndex = 2;
            this.listview_moderations_againstme.UseCompatibleStateImageBehavior = false;
            this.listview_moderations_againstme.View = System.Windows.Forms.View.Details;
            this.listview_moderations_againstme.Click += new System.EventHandler(this.listview_moderations_againstme_Click);
            // 
            // listview_moderations_againstme_name
            // 
            this.listview_moderations_againstme_name.Text = "Sender";
            this.listview_moderations_againstme_name.Width = 200;
            // 
            // listview_moderations_againstme_type
            // 
            this.listview_moderations_againstme_type.Text = "Type";
            this.listview_moderations_againstme_type.Width = 110;
            // 
            // listview_moderations_againstme_created
            // 
            this.listview_moderations_againstme_created.Text = "Time";
            this.listview_moderations_againstme_created.Width = 140;
            // 
            // listview_moderations
            // 
            this.listview_moderations.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listview_moderations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listview_moderations_name,
            this.listview_moderations_type,
            this.listview_moderations_created});
            this.listview_moderations.FullRowSelect = true;
            this.listview_moderations.GridLines = true;
            this.listview_moderations.Location = new System.Drawing.Point(6, 6);
            this.listview_moderations.MultiSelect = false;
            this.listview_moderations.Name = "listview_moderations";
            this.listview_moderations.ShowItemToolTips = true;
            this.listview_moderations.Size = new System.Drawing.Size(484, 196);
            this.listview_moderations.TabIndex = 0;
            this.listview_moderations.UseCompatibleStateImageBehavior = false;
            this.listview_moderations.View = System.Windows.Forms.View.Details;
            this.listview_moderations.Click += new System.EventHandler(this.listview_moderations_Click);
            // 
            // listview_moderations_name
            // 
            this.listview_moderations_name.Text = "Receiver";
            this.listview_moderations_name.Width = 200;
            // 
            // listview_moderations_type
            // 
            this.listview_moderations_type.Text = "Type";
            this.listview_moderations_type.Width = 110;
            // 
            // listview_moderations_created
            // 
            this.listview_moderations_created.Text = "Time";
            this.listview_moderations_created.Width = 140;
            // 
            // tabpage_notification
            // 
            this.tabpage_notification.Controls.Add(this.button_notification_decline);
            this.tabpage_notification.Controls.Add(this.button_notification_accept);
            this.tabpage_notification.Controls.Add(this.button_notification_refresh);
            this.tabpage_notification.Controls.Add(this.listview_notification);
            this.tabpage_notification.Location = new System.Drawing.Point(4, 22);
            this.tabpage_notification.Name = "tabpage_notification";
            this.tabpage_notification.Padding = new System.Windows.Forms.Padding(3);
            this.tabpage_notification.Size = new System.Drawing.Size(496, 444);
            this.tabpage_notification.TabIndex = 5;
            this.tabpage_notification.Text = "Message";
            this.tabpage_notification.UseVisualStyleBackColor = true;
            // 
            // button_notification_decline
            // 
            this.button_notification_decline.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.button_notification_decline.Location = new System.Drawing.Point(87, 415);
            this.button_notification_decline.Name = "button_notification_decline";
            this.button_notification_decline.Size = new System.Drawing.Size(75, 23);
            this.button_notification_decline.TabIndex = 2;
            this.button_notification_decline.Text = "Decline";
            this.button_notification_decline.UseVisualStyleBackColor = true;
            this.button_notification_decline.Click += new System.EventHandler(this.button_notification_decline_Click);
            // 
            // button_notification_accept
            // 
            this.button_notification_accept.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.button_notification_accept.Location = new System.Drawing.Point(6, 415);
            this.button_notification_accept.Name = "button_notification_accept";
            this.button_notification_accept.Size = new System.Drawing.Size(75, 23);
            this.button_notification_accept.TabIndex = 1;
            this.button_notification_accept.Text = "Accept";
            this.button_notification_accept.UseVisualStyleBackColor = true;
            this.button_notification_accept.Click += new System.EventHandler(this.button_notification_accept_Click);
            // 
            // button_notification_refresh
            // 
            this.button_notification_refresh.Location = new System.Drawing.Point(415, 415);
            this.button_notification_refresh.Name = "button_notification_refresh";
            this.button_notification_refresh.Size = new System.Drawing.Size(75, 23);
            this.button_notification_refresh.TabIndex = 3;
            this.button_notification_refresh.Text = "Refresh";
            this.button_notification_refresh.UseVisualStyleBackColor = true;
            this.button_notification_refresh.Click += new System.EventHandler(this.button_notification_refresh_Click);
            // 
            // listview_notification
            // 
            this.listview_notification.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listview_notification.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listview_notification_name,
            this.listview_notification_type,
            this.listview_notification_created_at});
            this.listview_notification.FullRowSelect = true;
            this.listview_notification.GridLines = true;
            this.listview_notification.Location = new System.Drawing.Point(6, 6);
            this.listview_notification.MultiSelect = false;
            this.listview_notification.Name = "listview_notification";
            this.listview_notification.ShowItemToolTips = true;
            this.listview_notification.Size = new System.Drawing.Size(484, 403);
            this.listview_notification.TabIndex = 0;
            this.listview_notification.UseCompatibleStateImageBehavior = false;
            this.listview_notification.View = System.Windows.Forms.View.Details;
            this.listview_notification.Click += new System.EventHandler(this.listview_notification_Click);
            this.listview_notification.DoubleClick += new System.EventHandler(this.listview_notification_DoubleClick);
            this.listview_notification.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listview_notification_KeyDown);
            // 
            // listview_notification_name
            // 
            this.listview_notification_name.Text = "Sender";
            this.listview_notification_name.Width = 200;
            // 
            // listview_notification_type
            // 
            this.listview_notification_type.Text = "Type";
            this.listview_notification_type.Width = 110;
            // 
            // listview_notification_created_at
            // 
            this.listview_notification_created_at.Text = "Time";
            this.listview_notification_created_at.Width = 140;
            // 
            // tabpage_about
            // 
            this.tabpage_about.Controls.Add(this.button_friends_list);
            this.tabpage_about.Controls.Add(this.groupbox_status);
            this.tabpage_about.Controls.Add(this.label2);
            this.tabpage_about.Controls.Add(this.label_author);
            this.tabpage_about.Controls.Add(this.label_link);
            this.tabpage_about.Controls.Add(this.textbox_search_friend);
            this.tabpage_about.Controls.Add(this.label_visits);
            this.tabpage_about.Controls.Add(this.button_logout);
            this.tabpage_about.Location = new System.Drawing.Point(4, 22);
            this.tabpage_about.Name = "tabpage_about";
            this.tabpage_about.Padding = new System.Windows.Forms.Padding(3);
            this.tabpage_about.Size = new System.Drawing.Size(496, 444);
            this.tabpage_about.TabIndex = 6;
            this.tabpage_about.Text = "About";
            this.tabpage_about.UseVisualStyleBackColor = true;
            // 
            // button_friends_list
            // 
            this.button_friends_list.Location = new System.Drawing.Point(8, 139);
            this.button_friends_list.Name = "button_friends_list";
            this.button_friends_list.Size = new System.Drawing.Size(150, 23);
            this.button_friends_list.TabIndex = 4;
            this.button_friends_list.Text = "Online Friends List";
            this.button_friends_list.UseVisualStyleBackColor = true;
            this.button_friends_list.Click += new System.EventHandler(this.button_friends_list_Click);
            // 
            // groupbox_status
            // 
            this.groupbox_status.Controls.Add(this.button_update_status);
            this.groupbox_status.Controls.Add(this.textbox_status);
            this.groupbox_status.Controls.Add(this.combobox_status);
            this.groupbox_status.Location = new System.Drawing.Point(6, 45);
            this.groupbox_status.Name = "groupbox_status";
            this.groupbox_status.Size = new System.Drawing.Size(484, 88);
            this.groupbox_status.TabIndex = 3;
            this.groupbox_status.TabStop = false;
            this.groupbox_status.Text = "Social Status";
            // 
            // button_update_status
            // 
            this.button_update_status.Location = new System.Drawing.Point(399, 52);
            this.button_update_status.Name = "button_update_status";
            this.button_update_status.Size = new System.Drawing.Size(75, 23);
            this.button_update_status.TabIndex = 2;
            this.button_update_status.Text = "Update";
            this.button_update_status.UseVisualStyleBackColor = true;
            this.button_update_status.Click += new System.EventHandler(this.button_update_status_Click);
            // 
            // textbox_status
            // 
            this.textbox_status.Location = new System.Drawing.Point(107, 25);
            this.textbox_status.MaxLength = 32;
            this.textbox_status.Name = "textbox_status";
            this.textbox_status.Size = new System.Drawing.Size(366, 21);
            this.textbox_status.TabIndex = 1;
            // 
            // combobox_status
            // 
            this.combobox_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_status.FormattingEnabled = true;
            this.combobox_status.Location = new System.Drawing.Point(10, 25);
            this.combobox_status.Name = "combobox_status";
            this.combobox_status.Size = new System.Drawing.Size(91, 20);
            this.combobox_status.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 323);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(484, 80);
            this.label2.TabIndex = 5;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // label_author
            // 
            this.label_author.Location = new System.Drawing.Point(240, 425);
            this.label_author.Name = "label_author";
            this.label_author.Size = new System.Drawing.Size(250, 12);
            this.label_author.TabIndex = 7;
            this.label_author.Text = "Version";
            this.label_author.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label_link
            // 
            this.label_link.Cursor = System.Windows.Forms.Cursors.Cross;
            this.label_link.ForeColor = System.Drawing.Color.Blue;
            this.label_link.Location = new System.Drawing.Point(300, 410);
            this.label_link.Name = "label_link";
            this.label_link.Size = new System.Drawing.Size(190, 12);
            this.label_link.TabIndex = 6;
            this.label_link.Text = "DCinside VRChat Minor Gallery";
            this.label_link.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label_link.DoubleClick += new System.EventHandler(this.label_link_DoubleClick);
            // 
            // textbox_search_friend
            // 
            this.textbox_search_friend.Location = new System.Drawing.Point(87, 7);
            this.textbox_search_friend.Name = "textbox_search_friend";
            this.textbox_search_friend.Size = new System.Drawing.Size(150, 21);
            this.textbox_search_friend.TabIndex = 1;
            this.textbox_search_friend.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_search_friend_KeyPress);
            // 
            // label_visits
            // 
            this.label_visits.Location = new System.Drawing.Point(252, 11);
            this.label_visits.Name = "label_visits";
            this.label_visits.Size = new System.Drawing.Size(115, 14);
            this.label_visits.TabIndex = 2;
            this.label_visits.Text = "0 User Online";
            // 
            // button_logout
            // 
            this.button_logout.Location = new System.Drawing.Point(6, 6);
            this.button_logout.Name = "button_logout";
            this.button_logout.Size = new System.Drawing.Size(75, 23);
            this.button_logout.TabIndex = 0;
            this.button_logout.Text = "Logout";
            this.button_logout.UseVisualStyleBackColor = true;
            this.button_logout.Click += new System.EventHandler(this.button_logout_Click);
            // 
            // tabcontrol_friends
            // 
            this.tabcontrol_friends.Controls.Add(this.tabpage_online);
            this.tabcontrol_friends.Controls.Add(this.tabpage_offline);
            this.tabcontrol_friends.Location = new System.Drawing.Point(518, 12);
            this.tabcontrol_friends.Name = "tabcontrol_friends";
            this.tabcontrol_friends.SelectedIndex = 0;
            this.tabcontrol_friends.Size = new System.Drawing.Size(254, 470);
            this.tabcontrol_friends.TabIndex = 1;
            // 
            // tabpage_online
            // 
            this.tabpage_online.Controls.Add(this.listview_online_friends);
            this.tabpage_online.Location = new System.Drawing.Point(4, 22);
            this.tabpage_online.Name = "tabpage_online";
            this.tabpage_online.Padding = new System.Windows.Forms.Padding(3);
            this.tabpage_online.Size = new System.Drawing.Size(246, 444);
            this.tabpage_online.TabIndex = 0;
            this.tabpage_online.Text = "Online";
            this.tabpage_online.UseVisualStyleBackColor = true;
            // 
            // listview_online_friends
            // 
            this.listview_online_friends.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listview_online_friends.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listview_online_friends.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listview_online_friends_name,
            this.listview_onlnie_friends_world});
            this.listview_online_friends.FullRowSelect = true;
            this.listview_online_friends.HideSelection = false;
            this.listview_online_friends.LargeImageList = this.imagelist_listbox;
            this.listview_online_friends.Location = new System.Drawing.Point(0, 0);
            this.listview_online_friends.MultiSelect = false;
            this.listview_online_friends.Name = "listview_online_friends";
            this.listview_online_friends.ShowItemToolTips = true;
            this.listview_online_friends.Size = new System.Drawing.Size(246, 444);
            this.listview_online_friends.SmallImageList = this.imagelist_listbox;
            this.listview_online_friends.TabIndex = 0;
            this.listview_online_friends.TileSize = new System.Drawing.Size(220, 50);
            this.listview_online_friends.UseCompatibleStateImageBehavior = false;
            this.listview_online_friends.View = System.Windows.Forms.View.Tile;
            this.listview_online_friends.Click += new System.EventHandler(this.listview_online_friends_Click);
            // 
            // listview_online_friends_name
            // 
            this.listview_online_friends_name.Text = "";
            // 
            // listview_onlnie_friends_world
            // 
            this.listview_onlnie_friends_world.Text = "";
            // 
            // tabpage_offline
            // 
            this.tabpage_offline.Controls.Add(this.listview_offline_friends);
            this.tabpage_offline.Location = new System.Drawing.Point(4, 22);
            this.tabpage_offline.Name = "tabpage_offline";
            this.tabpage_offline.Padding = new System.Windows.Forms.Padding(3);
            this.tabpage_offline.Size = new System.Drawing.Size(246, 444);
            this.tabpage_offline.TabIndex = 1;
            this.tabpage_offline.Text = "Offline";
            this.tabpage_offline.UseVisualStyleBackColor = true;
            // 
            // listview_offline_friends
            // 
            this.listview_offline_friends.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listview_offline_friends.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listview_offline_friends.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listview_offline_friends_name,
            this.listview_offline_friends_world});
            this.listview_offline_friends.FullRowSelect = true;
            this.listview_offline_friends.HideSelection = false;
            this.listview_offline_friends.LargeImageList = this.imagelist_listbox;
            this.listview_offline_friends.Location = new System.Drawing.Point(0, 0);
            this.listview_offline_friends.MultiSelect = false;
            this.listview_offline_friends.Name = "listview_offline_friends";
            this.listview_offline_friends.ShowItemToolTips = true;
            this.listview_offline_friends.Size = new System.Drawing.Size(246, 444);
            this.listview_offline_friends.SmallImageList = this.imagelist_listbox;
            this.listview_offline_friends.TabIndex = 0;
            this.listview_offline_friends.TileSize = new System.Drawing.Size(220, 50);
            this.listview_offline_friends.UseCompatibleStateImageBehavior = false;
            this.listview_offline_friends.View = System.Windows.Forms.View.Tile;
            this.listview_offline_friends.Click += new System.EventHandler(this.listview_offline_friends_Click);
            // 
            // listview_offline_friends_name
            // 
            this.listview_offline_friends_name.Text = "";
            // 
            // listview_offline_friends_world
            // 
            this.listview_offline_friends_world.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tabcontrol_friends);
            this.Controls.Add(this.listview_log);
            this.Controls.Add(this.tabcontrol_main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VRCEX";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.tabcontrol_main.ResumeLayout(false);
            this.tabpage_world.ResumeLayout(false);
            this.tabpage_world.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_world)).EndInit();
            this.tabpage_user.ResumeLayout(false);
            this.tabpage_user.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_user)).EndInit();
            this.tabpage_search.ResumeLayout(false);
            this.tabpage_search.PerformLayout();
            this.tabpage_avatar.ResumeLayout(false);
            this.tabpage_avatar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_avatar)).EndInit();
            this.tabpage_moderation.ResumeLayout(false);
            this.tabpage_moderation.PerformLayout();
            this.tabpage_notification.ResumeLayout(false);
            this.tabpage_about.ResumeLayout(false);
            this.tabpage_about.PerformLayout();
            this.groupbox_status.ResumeLayout(false);
            this.groupbox_status.PerformLayout();
            this.tabcontrol_friends.ResumeLayout(false);
            this.tabpage_online.ResumeLayout(false);
            this.tabpage_offline.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ListView listview_log;
        private System.Windows.Forms.ColumnHeader listview_log_message;
        private System.Windows.Forms.TabControl tabcontrol_main;
        private System.Windows.Forms.TabPage tabpage_world;
        private System.Windows.Forms.PictureBox picturebox_world;
        private System.Windows.Forms.TextBox textbox_world_name;
        private System.Windows.Forms.TextBox textbox_world_author;
        private System.Windows.Forms.TextBox textbox_world_description;
        private System.Windows.Forms.ListView listview_world_instances;
        private System.Windows.Forms.ColumnHeader listview_world_instances_instance;
        private System.Windows.Forms.ListView listview_world_instance_users;
        private System.Windows.Forms.TextBox textbox_world_location;
        private System.Windows.Forms.TextBox textbox_world_instance_occupants;
        private System.Windows.Forms.Button button_world_favorite;
        private System.Windows.Forms.Button button_world_unfavorite;
        private System.Windows.Forms.Button button_world_new;
        private System.Windows.Forms.Button button_world_join;
        private System.Windows.Forms.Button button_world_refresh;
        private System.Windows.Forms.TabPage tabpage_user;
        private System.Windows.Forms.PictureBox picturebox_user;
        private System.Windows.Forms.TextBox textbox_user_id;
        private System.Windows.Forms.TextBox textbox_user_name;
        private System.Windows.Forms.TextBox textbox_user_status;
        private System.Windows.Forms.Button button_user_friend;
        private System.Windows.Forms.Button button_user_mute;
        private System.Windows.Forms.Button button_user_block;
        private System.Windows.Forms.Button button_user_favorite;
        private System.Windows.Forms.Button button_user_unfavorite;
        private System.Windows.Forms.Button button_user_authored_worlds;
        private System.Windows.Forms.Button button_user_authored_avatars;
        private System.Windows.Forms.TabPage tabpage_search;
        private System.Windows.Forms.TextBox textbox_search_keyword;
        private System.Windows.Forms.ListView listview_search_worlds;
        private System.Windows.Forms.ColumnHeader listview_search_worlds_name;
        private System.Windows.Forms.ColumnHeader listview_search_worlds_occupants;
        private System.Windows.Forms.ListView listview_search_users;
        private System.Windows.Forms.Button button_search_favorite_users;
        private System.Windows.Forms.Button button_search_recent_worlds;
        private System.Windows.Forms.Button button_search_favorite_worlds;
        private System.Windows.Forms.Button button_search_my_worlds;
        private System.Windows.Forms.TabPage tabpage_avatar;
        private System.Windows.Forms.PictureBox picturebox_avatar;
        private System.Windows.Forms.TextBox textbox_avatar_id;
        private System.Windows.Forms.TextBox textbox_avatar_name;
        private System.Windows.Forms.TextBox textbox_avatar_author;
        private System.Windows.Forms.TextBox textbox_avatar_description;
        private System.Windows.Forms.ListView listview_avatars;
        private System.Windows.Forms.Button button_avatar_unfavorite;
        private System.Windows.Forms.Button button_avatar_favorite;
        private System.Windows.Forms.Button button_avatar_favorite_avatars;
        private System.Windows.Forms.Button button_avatar_my_avatars;
        private System.Windows.Forms.TabPage tabpage_moderation;
        private System.Windows.Forms.ListView listview_moderations;
        private System.Windows.Forms.ColumnHeader listview_moderations_name;
        private System.Windows.Forms.ColumnHeader listview_moderations_type;
        private System.Windows.Forms.ColumnHeader listview_moderations_created;
        private System.Windows.Forms.ListView listview_moderations_againstme;
        private System.Windows.Forms.ColumnHeader listview_moderations_againstme_name;
        private System.Windows.Forms.ColumnHeader listview_moderations_againstme_type;
        private System.Windows.Forms.ColumnHeader listview_moderations_againstme_created;
        private System.Windows.Forms.Button button_moderation_refresh;
        private System.Windows.Forms.TabPage tabpage_notification;
        private System.Windows.Forms.ListView listview_notification;
        private System.Windows.Forms.ColumnHeader listview_notification_name;
        private System.Windows.Forms.ColumnHeader listview_notification_type;
        private System.Windows.Forms.ColumnHeader listview_notification_created_at;
        private System.Windows.Forms.Button button_notification_accept;
        private System.Windows.Forms.Button button_notification_decline;
        private System.Windows.Forms.Button button_notification_refresh;
        private System.Windows.Forms.TabPage tabpage_about;
        private System.Windows.Forms.Button button_logout;
        private System.Windows.Forms.TextBox textbox_search_friend;
        private System.Windows.Forms.Label label_visits;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_author;
        private System.Windows.Forms.Label label_link;
        private System.Windows.Forms.TabControl tabcontrol_friends;
        private System.Windows.Forms.TabPage tabpage_online;
        private System.Windows.Forms.ListView listview_online_friends;
        private System.Windows.Forms.ColumnHeader listview_online_friends_name;
        private System.Windows.Forms.ColumnHeader listview_onlnie_friends_world;
        private System.Windows.Forms.TabPage tabpage_offline;
        private System.Windows.Forms.ListView listview_offline_friends;
        private System.Windows.Forms.ColumnHeader listview_offline_friends_name;
        private System.Windows.Forms.ColumnHeader listview_offline_friends_world;
        private System.Windows.Forms.GroupBox groupbox_status;
        private System.Windows.Forms.Button button_update_status;
        private System.Windows.Forms.TextBox textbox_status;
        private System.Windows.Forms.ComboBox combobox_status;
        private System.Windows.Forms.TextBox textbox_world_info;
        private System.Windows.Forms.TextBox textbox_avatar_info;
        private System.Windows.Forms.TextBox textbox_user_level;
        private System.Windows.Forms.TextBox textbox_user_info;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_user_hide;
        private System.Windows.Forms.Button button_friends_list;
        public System.Windows.Forms.ImageList imagelist_listbox;
        private System.Windows.Forms.ImageList imagelist_picturebox;
        private System.Windows.Forms.Button button_avatar_assign;
        private System.Windows.Forms.CheckBox checkbox_moderation_view_all;
    }
}

