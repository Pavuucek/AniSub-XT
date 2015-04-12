namespace AniDBClient
{
    partial class Calendar
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
            this.Cal = new System.Windows.Forms.MonthCalendar();
            this.SuspendLayout();
            // 
            // Cal
            // 
            this.Cal.BackColor = System.Drawing.Color.White;
            this.Cal.ForeColor = System.Drawing.Color.Black;
            this.Cal.Location = new System.Drawing.Point(0, 0);
            this.Cal.MaxSelectionCount = 1;
            this.Cal.Name = "Cal";
            this.Cal.ShowWeekNumbers = true;
            this.Cal.TabIndex = 0;
            this.Cal.TitleBackColor = System.Drawing.Color.LightBlue;
            this.Cal.TitleForeColor = System.Drawing.Color.Black;
            this.Cal.TrailingForeColor = System.Drawing.Color.Gray;
            // 
            // Calendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(172, 161);
            this.Controls.Add(this.Cal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Calendar";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar Cal;
    }
}