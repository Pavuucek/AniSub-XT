namespace AniDBClient.Forms
{
    partial class Backups
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
            this.Backups_KO = new System.Windows.Forms.Button();
            this.Backups_OK = new System.Windows.Forms.Button();
            this.Backups_Del = new System.Windows.Forms.Button();
            this.Backups_List = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // Backups_KO
            // 
            this.Backups_KO.BackgroundImage = global::AniDBClient.Properties.Resources.i_Cancel;
            this.Backups_KO.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Backups_KO.Cursor = System.Windows.Forms.Cursors.Default;
            this.Backups_KO.Location = new System.Drawing.Point(239, 170);
            this.Backups_KO.Name = "Backups_KO";
            this.Backups_KO.Size = new System.Drawing.Size(36, 36);
            this.Backups_KO.TabIndex = 8;
            this.Backups_KO.UseVisualStyleBackColor = true;
            this.Backups_KO.Click += new System.EventHandler(this.Backups_KO_Click);
            // 
            // Backups_OK
            // 
            this.Backups_OK.BackgroundImage = global::AniDBClient.Properties.Resources.i_Check;
            this.Backups_OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Backups_OK.Location = new System.Drawing.Point(281, 170);
            this.Backups_OK.Name = "Backups_OK";
            this.Backups_OK.Size = new System.Drawing.Size(36, 36);
            this.Backups_OK.TabIndex = 9;
            this.Backups_OK.UseVisualStyleBackColor = true;
            this.Backups_OK.Click += new System.EventHandler(this.Backups_OK_Click);
            // 
            // Backups_Del
            // 
            this.Backups_Del.BackgroundImage = global::AniDBClient.Properties.Resources.i_Delete;
            this.Backups_Del.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Backups_Del.Location = new System.Drawing.Point(445, 170);
            this.Backups_Del.Name = "Backups_Del";
            this.Backups_Del.Size = new System.Drawing.Size(36, 36);
            this.Backups_Del.TabIndex = 12;
            this.Backups_Del.UseVisualStyleBackColor = true;
            this.Backups_Del.Click += new System.EventHandler(this.Backups_Del_Click);
            // 
            // Backups_List
            // 
            this.Backups_List.ForeColor = System.Drawing.Color.Black;
            this.Backups_List.FormattingEnabled = true;
            this.Backups_List.Location = new System.Drawing.Point(12, 12);
            this.Backups_List.Name = "Backups_List";
            this.Backups_List.Size = new System.Drawing.Size(465, 147);
            this.Backups_List.TabIndex = 13;
            // 
            // Backups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(489, 215);
            this.Controls.Add(this.Backups_List);
            this.Controls.Add(this.Backups_Del);
            this.Controls.Add(this.Backups_KO);
            this.Controls.Add(this.Backups_OK);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Backups";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Backups_KO;
        private System.Windows.Forms.Button Backups_OK;
        private System.Windows.Forms.Button Backups_Del;
        private System.Windows.Forms.ListBox Backups_List;
    }
}