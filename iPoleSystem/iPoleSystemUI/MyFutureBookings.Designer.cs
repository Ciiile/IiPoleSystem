namespace iPoleSystemUI
{
    partial class MyFutureBookings
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
            this.LogOutButton = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.Label();
            this.BookAClassButton = new System.Windows.Forms.Button();
            this.ReturnButton = new System.Windows.Forms.Button();
            this.AttendButton = new System.Windows.Forms.Button();
            this.ChooseAllCheckbox = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LogOutButton
            // 
            this.LogOutButton.Location = new System.Drawing.Point(1204, 36);
            this.LogOutButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LogOutButton.Name = "LogOutButton";
            this.LogOutButton.Size = new System.Drawing.Size(100, 28);
            this.LogOutButton.TabIndex = 19;
            this.LogOutButton.Text = "Log out";
            this.LogOutButton.UseVisualStyleBackColor = true;
            this.LogOutButton.Click += new System.EventHandler(this.LogOutButton_Click);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(356, 36);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(578, 69);
            this.Title.TabIndex = 20;
            this.Title.Text = "My Future Bookings";
            // 
            // BookAClassButton
            // 
            this.BookAClassButton.Location = new System.Drawing.Point(767, 480);
            this.BookAClassButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BookAClassButton.Name = "BookAClassButton";
            this.BookAClassButton.Size = new System.Drawing.Size(179, 26);
            this.BookAClassButton.TabIndex = 22;
            this.BookAClassButton.Text = "Book A Class";
            this.BookAClassButton.UseVisualStyleBackColor = true;
            this.BookAClassButton.Click += new System.EventHandler(this.BookAClassButton_Click);
            // 
            // ReturnButton
            // 
            this.ReturnButton.Location = new System.Drawing.Point(43, 36);
            this.ReturnButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ReturnButton.Name = "ReturnButton";
            this.ReturnButton.Size = new System.Drawing.Size(100, 28);
            this.ReturnButton.TabIndex = 23;
            this.ReturnButton.Text = "Return";
            this.ReturnButton.UseVisualStyleBackColor = true;
            this.ReturnButton.Click += new System.EventHandler(this.ReturnButton_Click);
            // 
            // AttendButton
            // 
            this.AttendButton.Location = new System.Drawing.Point(485, 26);
            this.AttendButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AttendButton.Name = "AttendButton";
            this.AttendButton.Size = new System.Drawing.Size(67, 23);
            this.AttendButton.TabIndex = 6;
            this.AttendButton.Text = "Attend";
            this.AttendButton.UseVisualStyleBackColor = true;
            this.AttendButton.Click += new System.EventHandler(this.AttendButton_Click);
            // 
            // ChooseAllCheckbox
            // 
            this.ChooseAllCheckbox.AutoSize = true;
            this.ChooseAllCheckbox.Location = new System.Drawing.Point(25, 31);
            this.ChooseAllCheckbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChooseAllCheckbox.Name = "ChooseAllCheckbox";
            this.ChooseAllCheckbox.Size = new System.Drawing.Size(97, 21);
            this.ChooseAllCheckbox.TabIndex = 5;
            this.ChooseAllCheckbox.Text = "Choose All";
            this.ChooseAllCheckbox.UseVisualStyleBackColor = true;
            this.ChooseAllCheckbox.CheckedChanged += new System.EventHandler(this.ChooseAllCheckbox_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ChooseAllCheckbox);
            this.panel1.Controls.Add(this.AttendButton);
            this.panel1.Location = new System.Drawing.Point(368, 129);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(595, 53);
            this.panel1.TabIndex = 21;
            // 
            // MyFutureBookings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1377, 649);
            this.Controls.Add(this.ReturnButton);
            this.Controls.Add(this.BookAClassButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.LogOutButton);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MyFutureBookings";
            this.Text = "MyFutureBookings";
            this.Load += new System.EventHandler(this.MyFutureBookings_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LogOutButton;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Button BookAClassButton;
        private System.Windows.Forms.Button ReturnButton;
        private System.Windows.Forms.Button AttendButton;
        private System.Windows.Forms.CheckBox ChooseAllCheckbox;
        private System.Windows.Forms.Panel panel1;
    }
}