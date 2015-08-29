namespace AniDBClient.Forms
{
    partial class Tags
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tags));
            this.Tags_Add = new System.Windows.Forms.Button();
            this.Tags_KO = new System.Windows.Forms.Button();
            this.Tags_OK = new System.Windows.Forms.Button();
            this.Tags_Tag = new System.Windows.Forms.TextBox();
            this.Tags_Tags = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // Tags_Add
            // 
            this.Tags_Add.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Tags_Add.BackgroundImage")));
            this.Tags_Add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Tags_Add.Location = new System.Drawing.Point(239, 170);
            this.Tags_Add.Name = "Tags_Add";
            this.Tags_Add.Size = new System.Drawing.Size(36, 36);
            this.Tags_Add.TabIndex = 15;
            this.Tags_Add.UseVisualStyleBackColor = true;
            this.Tags_Add.Click += new System.EventHandler(this.Tags_Add_Click);
            // 
            // Tags_KO
            // 
            this.Tags_KO.BackgroundImage = global::AniDBClient.Properties.Resources.i_Cancel;
            this.Tags_KO.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Tags_KO.Cursor = System.Windows.Forms.Cursors.Default;
            this.Tags_KO.Location = new System.Drawing.Point(403, 170);
            this.Tags_KO.Name = "Tags_KO";
            this.Tags_KO.Size = new System.Drawing.Size(36, 36);
            this.Tags_KO.TabIndex = 13;
            this.Tags_KO.UseVisualStyleBackColor = true;
            this.Tags_KO.Click += new System.EventHandler(this.Tags_KO_Click);
            // 
            // Tags_OK
            // 
            this.Tags_OK.BackgroundImage = global::AniDBClient.Properties.Resources.i_Check;
            this.Tags_OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Tags_OK.Location = new System.Drawing.Point(445, 170);
            this.Tags_OK.Name = "Tags_OK";
            this.Tags_OK.Size = new System.Drawing.Size(36, 36);
            this.Tags_OK.TabIndex = 14;
            this.Tags_OK.UseVisualStyleBackColor = true;
            this.Tags_OK.Click += new System.EventHandler(this.Tags_OK_Click);
            // 
            // Tags_Tag
            // 
            this.Tags_Tag.Location = new System.Drawing.Point(12, 179);
            this.Tags_Tag.Name = "Tags_Tag";
            this.Tags_Tag.Size = new System.Drawing.Size(221, 20);
            this.Tags_Tag.TabIndex = 16;
            // 
            // Tags_Tags
            // 
            this.Tags_Tags.CheckOnClick = true;
            this.Tags_Tags.FormattingEnabled = true;
            this.Tags_Tags.HorizontalScrollbar = true;
            this.Tags_Tags.Location = new System.Drawing.Point(12, 12);
            this.Tags_Tags.MultiColumn = true;
            this.Tags_Tags.Name = "Tags_Tags";
            this.Tags_Tags.Size = new System.Drawing.Size(467, 154);
            this.Tags_Tags.Sorted = true;
            this.Tags_Tags.TabIndex = 17;
            // 
            // Tags
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(491, 217);
            this.Controls.Add(this.Tags_Tags);
            this.Controls.Add(this.Tags_Tag);
            this.Controls.Add(this.Tags_Add);
            this.Controls.Add(this.Tags_KO);
            this.Controls.Add(this.Tags_OK);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Tags";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Tags_Add;
        private System.Windows.Forms.Button Tags_KO;
        private System.Windows.Forms.Button Tags_OK;
        private System.Windows.Forms.TextBox Tags_Tag;
        private System.Windows.Forms.CheckedListBox Tags_Tags;
    }
}