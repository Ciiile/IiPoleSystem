namespace iPoleSystemUI
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
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxMemberID = new System.Windows.Forms.TextBox();
            this.TextMemberID = new System.Windows.Forms.Label();
            this.TextPassword = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(377, 206);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(302, 20);
            this.textBoxPassword.TabIndex = 15;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // textBoxMemberID
            // 
            this.textBoxMemberID.Location = new System.Drawing.Point(377, 167);
            this.textBoxMemberID.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBoxMemberID.Name = "textBoxMemberID";
            this.textBoxMemberID.Size = new System.Drawing.Size(302, 20);
            this.textBoxMemberID.TabIndex = 14;
            // 
            // TextMemberID
            // 
            this.TextMemberID.AutoSize = true;
            this.TextMemberID.Location = new System.Drawing.Point(271, 170);
            this.TextMemberID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TextMemberID.Name = "TextMemberID";
            this.TextMemberID.Size = new System.Drawing.Size(62, 13);
            this.TextMemberID.TabIndex = 13;
            this.TextMemberID.Text = "Member ID:";
            // 
            // TextPassword
            // 
            this.TextPassword.AutoSize = true;
            this.TextPassword.Location = new System.Drawing.Point(271, 209);
            this.TextPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TextPassword.Name = "TextPassword";
            this.TextPassword.Size = new System.Drawing.Size(56, 13);
            this.TextPassword.TabIndex = 12;
            this.TextPassword.Text = "Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(267, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(412, 55);
            this.label2.TabIndex = 11;
            this.label2.Text = "Welcome to iPole";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(449, 296);
            this.buttonLogin.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(71, 26);
            this.buttonLogin.TabIndex = 10;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1009, 498);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxMemberID);
            this.Controls.Add(this.TextMemberID);
            this.Controls.Add(this.TextPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonLogin);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "LoginForm";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxMemberID;
        private System.Windows.Forms.Label TextMemberID;
        private System.Windows.Forms.Label TextPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonLogin;
    }
}

