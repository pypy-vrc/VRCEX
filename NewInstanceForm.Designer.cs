namespace VRCEX
{
    partial class NewInstanceForm
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
            this.radiobutton_public = new System.Windows.Forms.RadioButton();
            this.radiobutton_friendsonly = new System.Windows.Forms.RadioButton();
            this.radiobutton_friendsofguests = new System.Windows.Forms.RadioButton();
            this.radiobutton_inviteplus = new System.Windows.Forms.RadioButton();
            this.radiobutton_inviteonly = new System.Windows.Forms.RadioButton();
            this.textbox_world_id = new System.Windows.Forms.TextBox();
            this.button_launch = new System.Windows.Forms.Button();
            this.textbox_vrchat_link = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textbox_web_link = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // radiobutton_public
            // 
            this.radiobutton_public.AutoSize = true;
            this.radiobutton_public.Location = new System.Drawing.Point(12, 12);
            this.radiobutton_public.Name = "radiobutton_public";
            this.radiobutton_public.Size = new System.Drawing.Size(170, 16);
            this.radiobutton_public.TabIndex = 0;
            this.radiobutton_public.Text = "Public — Anyone can join";
            this.radiobutton_public.UseVisualStyleBackColor = true;
            this.radiobutton_public.CheckedChanged += new System.EventHandler(this.radiobutton_CheckedChanged);
            // 
            // radiobutton_friendsonly
            // 
            this.radiobutton_friendsonly.AutoSize = true;
            this.radiobutton_friendsonly.Location = new System.Drawing.Point(12, 56);
            this.radiobutton_friendsonly.Name = "radiobutton_friendsonly";
            this.radiobutton_friendsonly.Size = new System.Drawing.Size(235, 16);
            this.radiobutton_friendsonly.TabIndex = 2;
            this.radiobutton_friendsonly.TabStop = true;
            this.radiobutton_friendsonly.Text = "Friends — Only your friends may join";
            this.radiobutton_friendsonly.UseVisualStyleBackColor = true;
            this.radiobutton_friendsonly.CheckedChanged += new System.EventHandler(this.radiobutton_CheckedChanged);
            // 
            // radiobutton_friendsofguests
            // 
            this.radiobutton_friendsofguests.AutoSize = true;
            this.radiobutton_friendsofguests.Location = new System.Drawing.Point(12, 34);
            this.radiobutton_friendsofguests.Name = "radiobutton_friendsofguests";
            this.radiobutton_friendsofguests.Size = new System.Drawing.Size(342, 16);
            this.radiobutton_friendsofguests.TabIndex = 1;
            this.radiobutton_friendsofguests.TabStop = true;
            this.radiobutton_friendsofguests.Text = "Friends+ — Any friend of a user in the instance may join";
            this.radiobutton_friendsofguests.UseVisualStyleBackColor = true;
            this.radiobutton_friendsofguests.CheckedChanged += new System.EventHandler(this.radiobutton_CheckedChanged);
            // 
            // radiobutton_inviteplus
            // 
            this.radiobutton_inviteplus.AutoSize = true;
            this.radiobutton_inviteplus.Location = new System.Drawing.Point(12, 78);
            this.radiobutton_inviteplus.Name = "radiobutton_inviteplus";
            this.radiobutton_inviteplus.Size = new System.Drawing.Size(366, 16);
            this.radiobutton_inviteplus.TabIndex = 3;
            this.radiobutton_inviteplus.TabStop = true;
            this.radiobutton_inviteplus.Text = "Invite+ — You can invite others. Joiners can accept requests";
            this.radiobutton_inviteplus.UseVisualStyleBackColor = true;
            this.radiobutton_inviteplus.CheckedChanged += new System.EventHandler(this.radiobutton_CheckedChanged);
            // 
            // radiobutton_inviteonly
            // 
            this.radiobutton_inviteonly.AutoSize = true;
            this.radiobutton_inviteonly.Location = new System.Drawing.Point(12, 100);
            this.radiobutton_inviteonly.Name = "radiobutton_inviteonly";
            this.radiobutton_inviteonly.Size = new System.Drawing.Size(370, 16);
            this.radiobutton_inviteonly.TabIndex = 4;
            this.radiobutton_inviteonly.TabStop = true;
            this.radiobutton_inviteonly.Text = "Invite — You can invite others. Only you can accept requests";
            this.radiobutton_inviteonly.UseVisualStyleBackColor = true;
            this.radiobutton_inviteonly.CheckedChanged += new System.EventHandler(this.radiobutton_CheckedChanged);
            // 
            // textbox_world_id
            // 
            this.textbox_world_id.BackColor = System.Drawing.SystemColors.Window;
            this.textbox_world_id.Location = new System.Drawing.Point(12, 144);
            this.textbox_world_id.Name = "textbox_world_id";
            this.textbox_world_id.Size = new System.Drawing.Size(460, 21);
            this.textbox_world_id.TabIndex = 6;
            this.textbox_world_id.TextChanged += new System.EventHandler(this.textbox_world_id_TextChanged);
            // 
            // button_launch
            // 
            this.button_launch.Location = new System.Drawing.Point(12, 247);
            this.button_launch.Name = "button_launch";
            this.button_launch.Size = new System.Drawing.Size(461, 25);
            this.button_launch.TabIndex = 10;
            this.button_launch.Text = "Launch";
            this.button_launch.UseVisualStyleBackColor = true;
            this.button_launch.Click += new System.EventHandler(this.button_launch_Click);
            // 
            // textbox_vrchat_link
            // 
            this.textbox_vrchat_link.BackColor = System.Drawing.SystemColors.Window;
            this.textbox_vrchat_link.Location = new System.Drawing.Point(12, 171);
            this.textbox_vrchat_link.Name = "textbox_vrchat_link";
            this.textbox_vrchat_link.ReadOnly = true;
            this.textbox_vrchat_link.Size = new System.Drawing.Size(460, 21);
            this.textbox_vrchat_link.TabIndex = 7;
            this.textbox_vrchat_link.Click += new System.EventHandler(this.textbox_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "World ID";
            // 
            // textbox_web_link
            // 
            this.textbox_web_link.BackColor = System.Drawing.SystemColors.Window;
            this.textbox_web_link.Location = new System.Drawing.Point(12, 215);
            this.textbox_web_link.Name = "textbox_web_link";
            this.textbox_web_link.ReadOnly = true;
            this.textbox_web_link.Size = new System.Drawing.Size(460, 21);
            this.textbox_web_link.TabIndex = 9;
            this.textbox_web_link.Click += new System.EventHandler(this.textbox_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "Share Link";
            // 
            // NewInstanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 281);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textbox_web_link);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textbox_vrchat_link);
            this.Controls.Add(this.button_launch);
            this.Controls.Add(this.textbox_world_id);
            this.Controls.Add(this.radiobutton_inviteonly);
            this.Controls.Add(this.radiobutton_inviteplus);
            this.Controls.Add(this.radiobutton_friendsofguests);
            this.Controls.Add(this.radiobutton_friendsonly);
            this.Controls.Add(this.radiobutton_public);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewInstanceForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Instance";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NewWorldInstanceForm_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radiobutton_public;
        private System.Windows.Forms.RadioButton radiobutton_friendsonly;
        private System.Windows.Forms.RadioButton radiobutton_friendsofguests;
        private System.Windows.Forms.RadioButton radiobutton_inviteplus;
        private System.Windows.Forms.RadioButton radiobutton_inviteonly;
        private System.Windows.Forms.TextBox textbox_world_id;
        private System.Windows.Forms.Button button_launch;
        private System.Windows.Forms.TextBox textbox_vrchat_link;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textbox_web_link;
        private System.Windows.Forms.Label label3;
    }
}