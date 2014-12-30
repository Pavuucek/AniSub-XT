namespace AniSubW
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BW = new System.ComponentModel.BackgroundWorker();
            this.Main_LB01 = new System.Windows.Forms.Label();
            this.Anime = new System.Windows.Forms.Panel();
            this.Main_LB08 = new System.Windows.Forms.Label();
            this.Main_LB07 = new System.Windows.Forms.Label();
            this.Main_LB06 = new System.Windows.Forms.Label();
            this.Main_LB05 = new System.Windows.Forms.Label();
            this.Main_LB04 = new System.Windows.Forms.Label();
            this.Main_LB02 = new System.Windows.Forms.Label();
            this.Main_LB03 = new System.Windows.Forms.Label();
            this.Time = new System.Windows.Forms.Timer(this.components);
            this.Menu = new System.Windows.Forms.Panel();
            this.Main_LB09 = new System.Windows.Forms.Label();
            this.AnimeS_BT01 = new System.Windows.Forms.Button();
            this.AnimeS_BT02 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Episodes = new AniSubW.MyListBox();
            this.AnimeS = new AniSubW.DTGWT();
            this.Anime.SuspendLayout();
            this.Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AnimeS)).BeginInit();
            this.SuspendLayout();
            // 
            // BW
            // 
            this.BW.WorkerReportsProgress = true;
            this.BW.WorkerSupportsCancellation = true;
            this.BW.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BW_DoWork);
            this.BW.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BW_ProgressChanged);
            this.BW.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BW_RunWorkerCompleted);
            // 
            // Main_LB01
            // 
            this.Main_LB01.AutoSize = true;
            this.Main_LB01.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Main_LB01.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(196)))), ((int)(((byte)(248)))));
            this.Main_LB01.Location = new System.Drawing.Point(357, 28);
            this.Main_LB01.Name = "Main_LB01";
            this.Main_LB01.Size = new System.Drawing.Size(123, 33);
            this.Main_LB01.TabIndex = 1;
            this.Main_LB01.Text = "Loading...";
            // 
            // Anime
            // 
            this.Anime.BackColor = System.Drawing.Color.Transparent;
            this.Anime.Controls.Add(this.Episodes);
            this.Anime.Controls.Add(this.Main_LB08);
            this.Anime.Controls.Add(this.Main_LB07);
            this.Anime.Controls.Add(this.Main_LB06);
            this.Anime.Controls.Add(this.Main_LB05);
            this.Anime.Controls.Add(this.Main_LB04);
            this.Anime.Location = new System.Drawing.Point(65, 116);
            this.Anime.Name = "Anime";
            this.Anime.Size = new System.Drawing.Size(900, 450);
            this.Anime.TabIndex = 2;
            // 
            // Main_LB08
            // 
            this.Main_LB08.AutoSize = true;
            this.Main_LB08.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Main_LB08.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(196)))), ((int)(((byte)(248)))));
            this.Main_LB08.Location = new System.Drawing.Point(496, 400);
            this.Main_LB08.Name = "Main_LB08";
            this.Main_LB08.Size = new System.Drawing.Size(97, 26);
            this.Main_LB08.TabIndex = 1;
            this.Main_LB08.Text = "Loading...";
            this.Main_LB08.Visible = false;
            // 
            // Main_LB07
            // 
            this.Main_LB07.AutoSize = true;
            this.Main_LB07.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Main_LB07.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(196)))), ((int)(((byte)(248)))));
            this.Main_LB07.Location = new System.Drawing.Point(497, 374);
            this.Main_LB07.Name = "Main_LB07";
            this.Main_LB07.Size = new System.Drawing.Size(97, 26);
            this.Main_LB07.TabIndex = 1;
            this.Main_LB07.Text = "Loading...";
            this.Main_LB07.Visible = false;
            // 
            // Main_LB06
            // 
            this.Main_LB06.AutoSize = true;
            this.Main_LB06.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Main_LB06.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(196)))), ((int)(((byte)(248)))));
            this.Main_LB06.Location = new System.Drawing.Point(20, 400);
            this.Main_LB06.Name = "Main_LB06";
            this.Main_LB06.Size = new System.Drawing.Size(97, 26);
            this.Main_LB06.TabIndex = 1;
            this.Main_LB06.Text = "Loading...";
            this.Main_LB06.Visible = false;
            // 
            // Main_LB05
            // 
            this.Main_LB05.AutoSize = true;
            this.Main_LB05.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Main_LB05.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(196)))), ((int)(((byte)(248)))));
            this.Main_LB05.Location = new System.Drawing.Point(19, 374);
            this.Main_LB05.Name = "Main_LB05";
            this.Main_LB05.Size = new System.Drawing.Size(97, 26);
            this.Main_LB05.TabIndex = 1;
            this.Main_LB05.Text = "Loading...";
            this.Main_LB05.Visible = false;
            // 
            // Main_LB04
            // 
            this.Main_LB04.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Main_LB04.AutoSize = true;
            this.Main_LB04.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Main_LB04.ForeColor = System.Drawing.Color.White;
            this.Main_LB04.Location = new System.Drawing.Point(19, 341);
            this.Main_LB04.Name = "Main_LB04";
            this.Main_LB04.Size = new System.Drawing.Size(78, 33);
            this.Main_LB04.TabIndex = 1;
            this.Main_LB04.Text = "00:00";
            this.Main_LB04.Visible = false;
            // 
            // Main_LB02
            // 
            this.Main_LB02.AutoSize = true;
            this.Main_LB02.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Main_LB02.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(196)))), ((int)(((byte)(248)))));
            this.Main_LB02.Location = new System.Drawing.Point(3, 8);
            this.Main_LB02.Name = "Main_LB02";
            this.Main_LB02.Size = new System.Drawing.Size(222, 59);
            this.Main_LB02.TabIndex = 1;
            this.Main_LB02.Text = "AniSub W";
            this.Main_LB02.Click += new System.EventHandler(this.Main_LB02_Click);
            // 
            // Main_LB03
            // 
            this.Main_LB03.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Main_LB03.AutoSize = true;
            this.Main_LB03.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Main_LB03.ForeColor = System.Drawing.Color.White;
            this.Main_LB03.Location = new System.Drawing.Point(740, 24);
            this.Main_LB03.Name = "Main_LB03";
            this.Main_LB03.Size = new System.Drawing.Size(90, 39);
            this.Main_LB03.TabIndex = 1;
            this.Main_LB03.Text = "00:00";
            // 
            // Time
            // 
            this.Time.Enabled = true;
            this.Time.Interval = 1000;
            this.Time.Tick += new System.EventHandler(this.Time_Tick);
            // 
            // Menu
            // 
            this.Menu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Menu.BackColor = System.Drawing.Color.Transparent;
            this.Menu.Controls.Add(this.Main_LB02);
            this.Menu.Controls.Add(this.Main_LB09);
            this.Menu.Controls.Add(this.Main_LB01);
            this.Menu.Controls.Add(this.Main_LB03);
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(1055, 80);
            this.Menu.TabIndex = 2;
            // 
            // Main_LB09
            // 
            this.Main_LB09.AutoSize = true;
            this.Main_LB09.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Main_LB09.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(196)))), ((int)(((byte)(248)))));
            this.Main_LB09.Location = new System.Drawing.Point(231, 28);
            this.Main_LB09.Name = "Main_LB09";
            this.Main_LB09.Size = new System.Drawing.Size(120, 33);
            this.Main_LB09.TabIndex = 1;
            this.Main_LB09.Text = " alpha v.3";
            // 
            // AnimeS_BT01
            // 
            this.AnimeS_BT01.FlatAppearance.BorderSize = 0;
            this.AnimeS_BT01.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AnimeS_BT01.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold);
            this.AnimeS_BT01.Location = new System.Drawing.Point(0, 100);
            this.AnimeS_BT01.Name = "AnimeS_BT01";
            this.AnimeS_BT01.Size = new System.Drawing.Size(30, 230);
            this.AnimeS_BT01.TabIndex = 3;
            this.AnimeS_BT01.TabStop = false;
            this.AnimeS_BT01.Text = "<";
            this.AnimeS_BT01.UseVisualStyleBackColor = true;
            this.AnimeS_BT01.Click += new System.EventHandler(this.AnimeS_BT01_Click);
            // 
            // AnimeS_BT02
            // 
            this.AnimeS_BT02.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AnimeS_BT02.FlatAppearance.BorderSize = 0;
            this.AnimeS_BT02.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AnimeS_BT02.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold);
            this.AnimeS_BT02.Location = new System.Drawing.Point(1025, 100);
            this.AnimeS_BT02.Name = "AnimeS_BT02";
            this.AnimeS_BT02.Size = new System.Drawing.Size(30, 230);
            this.AnimeS_BT02.TabIndex = 3;
            this.AnimeS_BT02.TabStop = false;
            this.AnimeS_BT02.Text = ">";
            this.AnimeS_BT02.UseVisualStyleBackColor = true;
            this.AnimeS_BT02.Click += new System.EventHandler(this.AnimeS_BT02_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(0, 625);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1055, 50);
            this.panel1.TabIndex = 4;
            // 
            // Episodes
            // 
            this.Episodes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Episodes.BackColor = System.Drawing.Color.Black;
            this.Episodes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Episodes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Episodes.Font = new System.Drawing.Font("Lucida Sans Unicode", 15.75F);
            this.Episodes.ForeColor = System.Drawing.Color.White;
            this.Episodes.FormattingEnabled = true;
            this.Episodes.ItemHeight = 25;
            this.Episodes.Location = new System.Drawing.Point(374, 10);
            this.Episodes.Margin = new System.Windows.Forms.Padding(10);
            this.Episodes.Name = "Episodes";
            this.Episodes.Size = new System.Drawing.Size(516, 275);
            this.Episodes.TabIndex = 3;
            this.Episodes.TabStop = false;
            this.Episodes.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.Episodes_DrawItem);
            this.Episodes.DoubleClick += new System.EventHandler(this.Episodes_DoubleClick);
            // 
            // AnimeS
            // 
            this.AnimeS.AllowUserToAddRows = false;
            this.AnimeS.AllowUserToDeleteRows = false;
            this.AnimeS.AllowUserToResizeColumns = false;
            this.AnimeS.AllowUserToResizeRows = false;
            this.AnimeS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AnimeS.BackgroundColor = System.Drawing.Color.Black;
            this.AnimeS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AnimeS.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.AnimeS.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AnimeS.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.AnimeS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.AnimeS.ColumnHeadersVisible = false;
            this.AnimeS.EnableHeadersVisualStyles = false;
            this.AnimeS.GridColor = System.Drawing.Color.Black;
            this.AnimeS.Location = new System.Drawing.Point(30, 100);
            this.AnimeS.MultiSelect = false;
            this.AnimeS.Name = "AnimeS";
            this.AnimeS.ReadOnly = true;
            this.AnimeS.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AnimeS.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.AnimeS.RowHeadersVisible = false;
            this.AnimeS.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Transparent;
            this.AnimeS.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.AnimeS.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.AnimeS.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Transparent;
            this.AnimeS.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Transparent;
            this.AnimeS.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Transparent;
            this.AnimeS.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Transparent;
            this.AnimeS.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.AnimeS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullColumnSelect;
            this.AnimeS.ShowCellErrors = false;
            this.AnimeS.ShowCellToolTips = false;
            this.AnimeS.ShowEditingIcon = false;
            this.AnimeS.ShowRowErrors = false;
            this.AnimeS.Size = new System.Drawing.Size(989, 230);
            this.AnimeS.TabIndex = 0;
            this.AnimeS.TabStop = false;
            this.AnimeS.SelectionChanged += new System.EventHandler(this.Anime_SelectionChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1055, 673);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.AnimeS_BT02);
            this.Controls.Add(this.AnimeS_BT01);
            this.Controls.Add(this.Menu);
            this.Controls.Add(this.Anime);
            this.Controls.Add(this.AnimeS);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Main";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "AniSubW";
            this.Load += new System.EventHandler(this.Main_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
            this.Anime.ResumeLayout(false);
            this.Anime.PerformLayout();
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AnimeS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DTGWT AnimeS;
        private System.ComponentModel.BackgroundWorker BW;
        private System.Windows.Forms.Label Main_LB01;
        private System.Windows.Forms.Panel Anime;
        private System.Windows.Forms.Label Main_LB02;
        private System.Windows.Forms.Label Main_LB03;
        private System.Windows.Forms.Timer Time;
        private System.Windows.Forms.Panel Menu;
        private System.Windows.Forms.Label Main_LB04;
        private System.Windows.Forms.Label Main_LB08;
        private System.Windows.Forms.Label Main_LB07;
        private System.Windows.Forms.Label Main_LB06;
        private System.Windows.Forms.Label Main_LB05;
        private MyListBox Episodes;
        private System.Windows.Forms.Button AnimeS_BT01;
        private System.Windows.Forms.Button AnimeS_BT02;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Main_LB09;

    }
}

