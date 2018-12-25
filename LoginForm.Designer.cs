namespace VRCEX
{
    partial class LoginForm
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
            this.label_username = new System.Windows.Forms.Label();
            this.label_password = new System.Windows.Forms.Label();
            this.textbox_username = new System.Windows.Forms.TextBox();
            this.textbox_password = new System.Windows.Forms.TextBox();
            this.button_login = new System.Windows.Forms.Button();
            this.checkbox_username = new System.Windows.Forms.CheckBox();
            this.checkbox_password = new System.Windows.Forms.CheckBox();
            this.button_login_with_steam = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_username
            // 
            this.label_username.AutoSize = true;
            this.label_username.Location = new System.Drawing.Point(12, 15);
            this.label_username.Name = "label_username";
            this.label_username.Size = new System.Drawing.Size(63, 12);
            this.label_username.TabIndex = 0;
            this.label_username.Text = "Username";
            // 
            // label_password
            // 
            this.label_password.AutoSize = true;
            this.label_password.Location = new System.Drawing.Point(12, 42);
            this.label_password.Name = "label_password";
            this.label_password.Size = new System.Drawing.Size(62, 12);
            this.label_password.TabIndex = 3;
            this.label_password.Text = "Password";
            // 
            // textbox_username
            // 
            this.textbox_username.Location = new System.Drawing.Point(81, 12);
            this.textbox_username.MaxLength = 256;
            this.textbox_username.Name = "textbox_username";
            this.textbox_username.Size = new System.Drawing.Size(156, 21);
            this.textbox_username.TabIndex = 1;
            // 
            // textbox_password
            // 
            this.textbox_password.Location = new System.Drawing.Point(81, 39);
            this.textbox_password.MaxLength = 256;
            this.textbox_password.Name = "textbox_password";
            this.textbox_password.PasswordChar = '*';
            this.textbox_password.Size = new System.Drawing.Size(156, 21);
            this.textbox_password.TabIndex = 4;
            // 
            // button_login
            // 
            this.button_login.Location = new System.Drawing.Point(183, 66);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(75, 23);
            this.button_login.TabIndex = 7;
            this.button_login.Text = "Login";
            this.button_login.UseVisualStyleBackColor = true;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // checkbox_username
            // 
            this.checkbox_username.AutoSize = true;
            this.checkbox_username.Location = new System.Drawing.Point(243, 15);
            this.checkbox_username.Name = "checkbox_username";
            this.checkbox_username.Size = new System.Drawing.Size(15, 14);
            this.checkbox_username.TabIndex = 2;
            this.checkbox_username.UseVisualStyleBackColor = true;
            this.checkbox_username.CheckedChanged += new System.EventHandler(this.checkbox_username_CheckedChanged);
            // 
            // checkbox_password
            // 
            this.checkbox_password.AutoSize = true;
            this.checkbox_password.Location = new System.Drawing.Point(243, 42);
            this.checkbox_password.Name = "checkbox_password";
            this.checkbox_password.Size = new System.Drawing.Size(15, 14);
            this.checkbox_password.TabIndex = 5;
            this.checkbox_password.UseVisualStyleBackColor = true;
            // 
            // button_login_with_steam
            // 
            this.button_login_with_steam.Location = new System.Drawing.Point(57, 66);
            this.button_login_with_steam.Name = "button_login_with_steam";
            this.button_login_with_steam.Size = new System.Drawing.Size(120, 23);
            this.button_login_with_steam.TabIndex = 6;
            this.button_login_with_steam.Text = "Login with Steam";
            this.button_login_with_steam.UseVisualStyleBackColor = true;
            this.button_login_with_steam.Click += new System.EventHandler(this.button_login_with_steam_Click);
            // 
            // LoginForm
            // 
            this.AcceptButton = this.button_login;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 101);
            this.Controls.Add(this.checkbox_password);
            this.Controls.Add(this.checkbox_username);
            this.Controls.Add(this.button_login_with_steam);
            this.Controls.Add(this.button_login);
            this.Controls.Add(this.textbox_password);
            this.Controls.Add(this.textbox_username);
            this.Controls.Add(this.label_password);
            this.Controls.Add(this.label_username);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "VRChat Login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LoginForm_FormClosed);
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_username;
        private System.Windows.Forms.Label label_password;
        private System.Windows.Forms.TextBox textbox_username;
        private System.Windows.Forms.TextBox textbox_password;
        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.CheckBox checkbox_username;
        private System.Windows.Forms.CheckBox checkbox_password;
        private System.Windows.Forms.Button button_login_with_steam;
    }
}