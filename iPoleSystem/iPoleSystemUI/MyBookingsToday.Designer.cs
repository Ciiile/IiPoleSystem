namespace iPoleSystemUI
{
    partial class MyBookingsToday
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
            this.Title = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ChooseAllCheckbox = new System.Windows.Forms.CheckBox();
            this.AttendButton = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonLogOut = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(267, 29);
            this.Title.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(463, 55);
            this.Title.TabIndex = 13;
            this.Title.Text = "My Bookings Today";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ChooseAllCheckbox);
            this.panel1.Controls.Add(this.AttendButton);
            this.panel1.Location = new System.Drawing.Point(276, 105);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(446, 43);
            this.panel1.TabIndex = 14;
            // 
            // ChooseAllCheckbox
            // 
            this.ChooseAllCheckbox.AutoSize = true;
            this.ChooseAllCheckbox.Location = new System.Drawing.Point(19, 25);
            this.ChooseAllCheckbox.Margin = new System.Windows.Forms.Padding(2);
            this.ChooseAllCheckbox.Name = "ChooseAllCheckbox";
            this.ChooseAllCheckbox.Size = new System.Drawing.Size(76, 17);
            this.ChooseAllCheckbox.TabIndex = 5;
            this.ChooseAllCheckbox.Text = "Choose All";
            this.ChooseAllCheckbox.UseVisualStyleBackColor = true;
            this.ChooseAllCheckbox.CheckedChanged += new System.EventHandler(this.ChooseAllCheckbox_CheckedChanged);
            // 
            // AttendButton
            // 
            this.AttendButton.Location = new System.Drawing.Point(364, 21);
            this.AttendButton.Margin = new System.Windows.Forms.Padding(2);
            this.AttendButton.Name = "AttendButton";
            this.AttendButton.Size = new System.Drawing.Size(50, 19);
            this.AttendButton.TabIndex = 6;
            this.AttendButton.Text = "Attend";
            this.AttendButton.UseVisualStyleBackColor = true;
            this.AttendButton.Click += new System.EventHandler(this.AttendButton_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(575, 390);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(134, 21);
            this.button4.TabIndex = 17;
            this.button4.Text = "Book A Class";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(263, 390);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(134, 21);
            this.button3.TabIndex = 16;
            this.button3.Text = "My Future Bookings";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.MyFutureBookingsButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(415, 289);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(134, 21);
            this.button2.TabIndex = 15;
            this.button2.Text = "Attend Open Gym";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.AttendOpenGymButton_Click);
            // 
            // buttonLogOut
            // 
            this.buttonLogOut.Location = new System.Drawing.Point(903, 29);
            this.buttonLogOut.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonLogOut.Name = "buttonLogOut";
            this.buttonLogOut.Size = new System.Drawing.Size(75, 23);
            this.buttonLogOut.TabIndex = 18;
            this.buttonLogOut.Text = "Log out";
            this.buttonLogOut.UseVisualStyleBackColor = true;
            this.buttonLogOut.Click += new System.EventHandler(this.LogOutButton_Click);
            // 
            // MyBookingsToday
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1009, 498);
            this.Controls.Add(this.buttonLogOut);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MyBookingsToday";
            this.Text = "MyBookingsToday";
            this.Load += new System.EventHandler(this.MyBookingsToday_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox ChooseAllCheckbox;
        private System.Windows.Forms.Button AttendButton;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonLogOut;
    }
}