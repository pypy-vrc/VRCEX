namespace VRCEX
{
    partial class FriendsGroupForm
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
            this.button_group1 = new System.Windows.Forms.Button();
            this.button_group2 = new System.Windows.Forms.Button();
            this.button_group3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_group1
            // 
            this.button_group1.Location = new System.Drawing.Point(12, 13);
            this.button_group1.Name = "button_group1";
            this.button_group1.Size = new System.Drawing.Size(280, 40);
            this.button_group1.TabIndex = 0;
            this.button_group1.Text = "Group1";
            this.button_group1.UseVisualStyleBackColor = true;
            this.button_group1.Click += new System.EventHandler(this.button_group1_Click);
            // 
            // button_group2
            // 
            this.button_group2.Location = new System.Drawing.Point(12, 59);
            this.button_group2.Name = "button_group2";
            this.button_group2.Size = new System.Drawing.Size(280, 40);
            this.button_group2.TabIndex = 1;
            this.button_group2.Text = "Group2";
            this.button_group2.UseVisualStyleBackColor = true;
            this.button_group2.Click += new System.EventHandler(this.button_group2_Click);
            // 
            // button_group3
            // 
            this.button_group3.Location = new System.Drawing.Point(12, 105);
            this.button_group3.Name = "button_group3";
            this.button_group3.Size = new System.Drawing.Size(280, 40);
            this.button_group3.TabIndex = 2;
            this.button_group3.Text = "Group3";
            this.button_group3.UseVisualStyleBackColor = true;
            this.button_group3.Click += new System.EventHandler(this.button_group3_Click);
            // 
            // FriendsGroupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 161);
            this.Controls.Add(this.button_group3);
            this.Controls.Add(this.button_group2);
            this.Controls.Add(this.button_group1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FriendsGroupForm";
            this.Text = "Select Group";
            this.Load += new System.EventHandler(this.FriendsGroupForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_group1;
        private System.Windows.Forms.Button button_group2;
        private System.Windows.Forms.Button button_group3;
    }
}