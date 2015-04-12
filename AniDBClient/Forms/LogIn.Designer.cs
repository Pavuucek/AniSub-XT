namespace AniDB
{
    partial class LogIn
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
            this.LogIn_LB01 = new System.Windows.Forms.Label();
            this.LogIn_LB02 = new System.Windows.Forms.Label();
            this.LogIn_User = new System.Windows.Forms.TextBox();
            this.LogIn_Password = new System.Windows.Forms.TextBox();
            this.LogIn_CH01 = new System.Windows.Forms.CheckBox();
            this.LogIn_LogIn = new System.Windows.Forms.Button();
            this.LogIn_Accounts = new System.Windows.Forms.ComboBox();
            this.LogIn_Register = new System.Windows.Forms.Button();
            this.LogIn_Language = new System.Windows.Forms.ComboBox();
            this.LogIn_LB03 = new System.Windows.Forms.Label();
            this.LogIn_LogOut = new System.Windows.Forms.Button();
            this.LogIn_Panel = new System.Windows.Forms.Panel();
            this.LogIn_LB07 = new System.Windows.Forms.LinkLabel();
            this.LogIn_LB06 = new System.Windows.Forms.LinkLabel();
            this.LogIn_LB05 = new System.Windows.Forms.LinkLabel();
            this.LogIn_LB04 = new System.Windows.Forms.Label();
            this.LogIn_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LogIn_LB01
            // 
            this.LogIn_LB01.AutoSize = true;
            this.LogIn_LB01.BackColor = System.Drawing.Color.Transparent;
            this.LogIn_LB01.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LogIn_LB01.Location = new System.Drawing.Point(283, 231);
            this.LogIn_LB01.Name = "LogIn_LB01";
            this.LogIn_LB01.Size = new System.Drawing.Size(41, 13);
            this.LogIn_LB01.TabIndex = 0;
            this.LogIn_LB01.Text = "label1";
            // 
            // LogIn_LB02
            // 
            this.LogIn_LB02.AutoSize = true;
            this.LogIn_LB02.BackColor = System.Drawing.Color.Transparent;
            this.LogIn_LB02.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LogIn_LB02.Location = new System.Drawing.Point(283, 257);
            this.LogIn_LB02.Name = "LogIn_LB02";
            this.LogIn_LB02.Size = new System.Drawing.Size(41, 13);
            this.LogIn_LB02.TabIndex = 1;
            this.LogIn_LB02.Text = "label2";
            // 
            // LogIn_User
            // 
            this.LogIn_User.Location = new System.Drawing.Point(411, 228);
            this.LogIn_User.Name = "LogIn_User";
            this.LogIn_User.Size = new System.Drawing.Size(216, 20);
            this.LogIn_User.TabIndex = 4;
            this.LogIn_User.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.LogIn_User.TextChanged += new System.EventHandler(this.LogIn_User_TextChanged);
            // 
            // LogIn_Password
            // 
            this.LogIn_Password.Location = new System.Drawing.Point(411, 254);
            this.LogIn_Password.Name = "LogIn_Password";
            this.LogIn_Password.PasswordChar = '*';
            this.LogIn_Password.Size = new System.Drawing.Size(216, 20);
            this.LogIn_Password.TabIndex = 5;
            this.LogIn_Password.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LogIn_CH01
            // 
            this.LogIn_CH01.AutoSize = true;
            this.LogIn_CH01.BackColor = System.Drawing.Color.Transparent;
            this.LogIn_CH01.Location = new System.Drawing.Point(283, 284);
            this.LogIn_CH01.Name = "LogIn_CH01";
            this.LogIn_CH01.Size = new System.Drawing.Size(80, 17);
            this.LogIn_CH01.TabIndex = 6;
            this.LogIn_CH01.Text = "checkBox1";
            this.LogIn_CH01.UseVisualStyleBackColor = false;
            // 
            // LogIn_LogIn
            // 
            this.LogIn_LogIn.DialogResult = System.Windows.Forms.DialogResult.No;
            this.LogIn_LogIn.Enabled = false;
            this.LogIn_LogIn.Location = new System.Drawing.Point(540, 364);
            this.LogIn_LogIn.Name = "LogIn_LogIn";
            this.LogIn_LogIn.Size = new System.Drawing.Size(87, 23);
            this.LogIn_LogIn.TabIndex = 11;
            this.LogIn_LogIn.Text = "button1";
            this.LogIn_LogIn.UseVisualStyleBackColor = true;
            this.LogIn_LogIn.Click += new System.EventHandler(this.LogIn_LogIn_Click);
            // 
            // LogIn_Accounts
            // 
            this.LogIn_Accounts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LogIn_Accounts.FormattingEnabled = true;
            this.LogIn_Accounts.Location = new System.Drawing.Point(411, 201);
            this.LogIn_Accounts.Name = "LogIn_Accounts";
            this.LogIn_Accounts.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LogIn_Accounts.Size = new System.Drawing.Size(216, 21);
            this.LogIn_Accounts.TabIndex = 3;
            this.LogIn_Accounts.SelectedIndexChanged += new System.EventHandler(this.LogIn_Accounts_SelectedIndexChanged);
            // 
            // LogIn_Register
            // 
            this.LogIn_Register.Location = new System.Drawing.Point(354, 364);
            this.LogIn_Register.Name = "LogIn_Register";
            this.LogIn_Register.Size = new System.Drawing.Size(87, 23);
            this.LogIn_Register.TabIndex = 9;
            this.LogIn_Register.Text = "button1";
            this.LogIn_Register.UseVisualStyleBackColor = true;
            this.LogIn_Register.Click += new System.EventHandler(this.LogIn_Register_Click);
            // 
            // LogIn_Language
            // 
            this.LogIn_Language.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LogIn_Language.FormattingEnabled = true;
            this.LogIn_Language.Items.AddRange(new object[] {
            "en-US",
            "cs-CZ"});
            this.LogIn_Language.Location = new System.Drawing.Point(497, 278);
            this.LogIn_Language.Name = "LogIn_Language";
            this.LogIn_Language.Size = new System.Drawing.Size(130, 21);
            this.LogIn_Language.TabIndex = 7;
            this.LogIn_Language.SelectedIndexChanged += new System.EventHandler(this.LogIn_Language_SelectedIndexChanged);
            // 
            // LogIn_LB03
            // 
            this.LogIn_LB03.BackColor = System.Drawing.Color.Transparent;
            this.LogIn_LB03.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LogIn_LB03.Location = new System.Drawing.Point(280, 8);
            this.LogIn_LB03.Name = "LogIn_LB03";
            this.LogIn_LB03.Size = new System.Drawing.Size(347, 150);
            this.LogIn_LB03.TabIndex = 1;
            this.LogIn_LB03.Text = "label2";
            // 
            // LogIn_LogOut
            // 
            this.LogIn_LogOut.Location = new System.Drawing.Point(447, 364);
            this.LogIn_LogOut.Name = "LogIn_LogOut";
            this.LogIn_LogOut.Size = new System.Drawing.Size(87, 23);
            this.LogIn_LogOut.TabIndex = 10;
            this.LogIn_LogOut.Text = "button1";
            this.LogIn_LogOut.UseVisualStyleBackColor = true;
            this.LogIn_LogOut.Click += new System.EventHandler(this.LogIn_LogOut_Click);
            // 
            // LogIn_Panel
            // 
            this.LogIn_Panel.BackColor = System.Drawing.Color.Transparent;
            this.LogIn_Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LogIn_Panel.Controls.Add(this.LogIn_LB07);
            this.LogIn_Panel.Controls.Add(this.LogIn_LB06);
            this.LogIn_Panel.Controls.Add(this.LogIn_LB05);
            this.LogIn_Panel.Controls.Add(this.LogIn_LB03);
            this.LogIn_Panel.Controls.Add(this.LogIn_Language);
            this.LogIn_Panel.Controls.Add(this.LogIn_LB04);
            this.LogIn_Panel.Controls.Add(this.LogIn_LB01);
            this.LogIn_Panel.Controls.Add(this.LogIn_Register);
            this.LogIn_Panel.Controls.Add(this.LogIn_LB02);
            this.LogIn_Panel.Controls.Add(this.LogIn_Accounts);
            this.LogIn_Panel.Controls.Add(this.LogIn_User);
            this.LogIn_Panel.Controls.Add(this.LogIn_LogOut);
            this.LogIn_Panel.Controls.Add(this.LogIn_Password);
            this.LogIn_Panel.Controls.Add(this.LogIn_LogIn);
            this.LogIn_Panel.Controls.Add(this.LogIn_CH01);
            this.LogIn_Panel.Location = new System.Drawing.Point(0, 0);
            this.LogIn_Panel.Name = "LogIn_Panel";
            this.LogIn_Panel.Size = new System.Drawing.Size(640, 400);
            this.LogIn_Panel.TabIndex = 9;
            // 
            // LogIn_LB07
            // 
            this.LogIn_LB07.AutoSize = true;
            this.LogIn_LB07.Location = new System.Drawing.Point(408, 335);
            this.LogIn_LB07.Name = "LogIn_LB07";
            this.LogIn_LB07.Size = new System.Drawing.Size(44, 13);
            this.LogIn_LB07.TabIndex = 8;
            this.LogIn_LB07.TabStop = true;
            this.LogIn_LB07.Text = "License";
            this.LogIn_LB07.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LogIn_LB07_LinkClicked);
            // 
            // LogIn_LB06
            // 
            this.LogIn_LB06.AutoSize = true;
            this.LogIn_LB06.Location = new System.Drawing.Point(586, 168);
            this.LogIn_LB06.Name = "LogIn_LB06";
            this.LogIn_LB06.Size = new System.Drawing.Size(41, 13);
            this.LogIn_LB06.TabIndex = 2;
            this.LogIn_LB06.TabStop = true;
            this.LogIn_LB06.Text = "English";
            this.LogIn_LB06.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LogIn_LB06_LinkClicked);
            // 
            // LogIn_LB05
            // 
            this.LogIn_LB05.AutoSize = true;
            this.LogIn_LB05.Location = new System.Drawing.Point(513, 168);
            this.LogIn_LB05.Name = "LogIn_LB05";
            this.LogIn_LB05.Size = new System.Drawing.Size(36, 13);
            this.LogIn_LB05.TabIndex = 1;
            this.LogIn_LB05.TabStop = true;
            this.LogIn_LB05.Text = "Česky";
            this.LogIn_LB05.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LogIn_LB05_LinkClicked);
            // 
            // LogIn_LB04
            // 
            this.LogIn_LB04.AutoSize = true;
            this.LogIn_LB04.BackColor = System.Drawing.Color.Transparent;
            this.LogIn_LB04.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LogIn_LB04.Location = new System.Drawing.Point(408, 168);
            this.LogIn_LB04.Name = "LogIn_LB04";
            this.LogIn_LB04.Size = new System.Drawing.Size(41, 13);
            this.LogIn_LB04.TabIndex = 0;
            this.LogIn_LB04.Text = "label1";
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 400);
            this.Controls.Add(this.LogIn_Panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LogIn";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LogIn_KeyDown);
            this.LogIn_Panel.ResumeLayout(false);
            this.LogIn_Panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LogIn_LB01;
        private System.Windows.Forms.Label LogIn_LB02;
        private System.Windows.Forms.TextBox LogIn_User;
        private System.Windows.Forms.TextBox LogIn_Password;
        private System.Windows.Forms.CheckBox LogIn_CH01;
        private System.Windows.Forms.Button LogIn_LogIn;
        private System.Windows.Forms.ComboBox LogIn_Accounts;
        private System.Windows.Forms.Button LogIn_Register;
        private System.Windows.Forms.ComboBox LogIn_Language;
        private System.Windows.Forms.Label LogIn_LB03;
        private System.Windows.Forms.Button LogIn_LogOut;
        private System.Windows.Forms.Panel LogIn_Panel;
        private System.Windows.Forms.LinkLabel LogIn_LB06;
        private System.Windows.Forms.LinkLabel LogIn_LB05;
        private System.Windows.Forms.Label LogIn_LB04;
        private System.Windows.Forms.LinkLabel LogIn_LB07;
    }
}