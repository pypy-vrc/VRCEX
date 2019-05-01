namespace VRCEX
{
    partial class MessageForm
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
            this.button_send = new System.Windows.Forms.Button();
            this.textbox_user = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textbox_message = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_send
            // 
            this.button_send.Location = new System.Drawing.Point(12, 124);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(311, 25);
            this.button_send.TabIndex = 2;
            this.button_send.Text = "Send";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // textbox_user
            // 
            this.textbox_user.BackColor = System.Drawing.SystemColors.Window;
            this.textbox_user.Location = new System.Drawing.Point(12, 24);
            this.textbox_user.Name = "textbox_user";
            this.textbox_user.ReadOnly = true;
            this.textbox_user.Size = new System.Drawing.Size(310, 21);
            this.textbox_user.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Receiver";
            // 
            // textbox_message
            // 
            this.textbox_message.BackColor = System.Drawing.SystemColors.Window;
            this.textbox_message.Location = new System.Drawing.Point(12, 68);
            this.textbox_message.Multiline = true;
            this.textbox_message.Name = "textbox_message";
            this.textbox_message.Size = new System.Drawing.Size(310, 50);
            this.textbox_message.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "Message";
            // 
            // MessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 161);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textbox_message);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textbox_user);
            this.Controls.Add(this.button_send);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MessageForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Send Message";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MessageForm_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.TextBox textbox_user;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textbox_message;
        private System.Windows.Forms.Label label3;
    }
}