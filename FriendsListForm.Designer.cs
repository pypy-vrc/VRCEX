namespace VRCEX
{
    partial class FriendsListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listview = new System.Windows.Forms.ListView();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // listview
            // 
            this.listview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listview.Location = new System.Drawing.Point(0, 0);
            this.listview.Margin = new System.Windows.Forms.Padding(0);
            this.listview.MultiSelect = false;
            this.listview.Name = "listview";
            this.listview.ShowItemToolTips = true;
            this.listview.Size = new System.Drawing.Size(384, 561);
            this.listview.TabIndex = 0;
            this.listview.TileSize = new System.Drawing.Size(150, 50);
            this.listview.UseCompatibleStateImageBehavior = false;
            this.listview.View = System.Windows.Forms.View.Tile;
            this.listview.Click += new System.EventHandler(this.listview_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 5000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // FriendsListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 561);
            this.Controls.Add(this.listview);
            this.Name = "FriendsListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Friends List";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FriendsSummaryForm_FormClosed);
            this.Load += new System.EventHandler(this.FriendsSummaryForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listview;
        private System.Windows.Forms.Timer timer;
    }
}