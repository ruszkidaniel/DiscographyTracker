namespace DiscographyTracker
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.artistCB = new System.Windows.Forms.ComboBox();
            this.albumCB = new System.Windows.Forms.ComboBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pbox = new System.Windows.Forms.PictureBox();
            this.addDiscographyBTN = new System.Windows.Forms.Button();
            this.rtbInfo = new System.Windows.Forms.RichTextBox();
            this.urlLabel = new System.Windows.Forms.LinkLabel();
            this.searchTB = new System.Windows.Forms.TextBox();
            this.addUrlBTN = new System.Windows.Forms.Button();
            this.editSelectedBTN = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Artist";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(150, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Album";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Search in track\'s title";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(367, 308);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "URL (if any):";
            // 
            // artistCB
            // 
            this.artistCB.FormattingEnabled = true;
            this.artistCB.Location = new System.Drawing.Point(10, 46);
            this.artistCB.Name = "artistCB";
            this.artistCB.Size = new System.Drawing.Size(121, 21);
            this.artistCB.TabIndex = 1;
            this.artistCB.SelectedIndexChanged += new System.EventHandler(this.artistCB_SelectedIndexChanged);
            // 
            // albumCB
            // 
            this.albumCB.FormattingEnabled = true;
            this.albumCB.Location = new System.Drawing.Point(153, 46);
            this.albumCB.Name = "albumCB";
            this.albumCB.Size = new System.Drawing.Size(121, 21);
            this.albumCB.TabIndex = 1;
            this.albumCB.SelectedIndexChanged += new System.EventHandler(this.albumCB_SelectedIndexChanged);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Title,
            this.Length});
            this.dgv.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgv.Location = new System.Drawing.Point(10, 153);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.Size = new System.Drawing.Size(264, 260);
            this.dgv.TabIndex = 2;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // Title
            // 
            this.Title.HeaderText = "Title";
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            // 
            // Length
            // 
            this.Length.HeaderText = "Length";
            this.Length.Name = "Length";
            this.Length.ReadOnly = true;
            // 
            // pbox
            // 
            this.pbox.Location = new System.Drawing.Point(307, 153);
            this.pbox.Name = "pbox";
            this.pbox.Size = new System.Drawing.Size(126, 126);
            this.pbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbox.TabIndex = 3;
            this.pbox.TabStop = false;
            // 
            // addDiscographyBTN
            // 
            this.addDiscographyBTN.Location = new System.Drawing.Point(301, 350);
            this.addDiscographyBTN.Name = "addDiscographyBTN";
            this.addDiscographyBTN.Size = new System.Drawing.Size(132, 63);
            this.addDiscographyBTN.TabIndex = 4;
            this.addDiscographyBTN.Text = "Add Discography";
            this.addDiscographyBTN.UseVisualStyleBackColor = true;
            this.addDiscographyBTN.Click += new System.EventHandler(this.AddDiscography);
            // 
            // rtbInfo
            // 
            this.rtbInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rtbInfo.Location = new System.Drawing.Point(458, 154);
            this.rtbInfo.Name = "rtbInfo";
            this.rtbInfo.Size = new System.Drawing.Size(251, 126);
            this.rtbInfo.TabIndex = 5;
            this.rtbInfo.Text = "";
            // 
            // urlLabel
            // 
            this.urlLabel.AutoSize = true;
            this.urlLabel.Location = new System.Drawing.Point(455, 308);
            this.urlLabel.Name = "urlLabel";
            this.urlLabel.Size = new System.Drawing.Size(37, 13);
            this.urlLabel.TabIndex = 6;
            this.urlLabel.TabStop = true;
            this.urlLabel.Text = "NOPE";
            this.urlLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.urlLabel_LinkClicked);
            // 
            // searchTB
            // 
            this.searchTB.Location = new System.Drawing.Point(10, 110);
            this.searchTB.Name = "searchTB";
            this.searchTB.Size = new System.Drawing.Size(264, 20);
            this.searchTB.TabIndex = 7;
            this.searchTB.TextChanged += new System.EventHandler(this.searchTB_TextChanged);
            // 
            // addUrlBTN
            // 
            this.addUrlBTN.Location = new System.Drawing.Point(439, 350);
            this.addUrlBTN.Name = "addUrlBTN";
            this.addUrlBTN.Size = new System.Drawing.Size(132, 63);
            this.addUrlBTN.TabIndex = 4;
            this.addUrlBTN.Text = "Add URL";
            this.addUrlBTN.UseVisualStyleBackColor = true;
            this.addUrlBTN.Click += new System.EventHandler(this.addUrlBTN_Click);
            // 
            // editSelectedBTN
            // 
            this.editSelectedBTN.Location = new System.Drawing.Point(577, 350);
            this.editSelectedBTN.Name = "editSelectedBTN";
            this.editSelectedBTN.Size = new System.Drawing.Size(132, 63);
            this.editSelectedBTN.TabIndex = 4;
            this.editSelectedBTN.Text = "Edit Selected";
            this.editSelectedBTN.UseVisualStyleBackColor = true;
            this.editSelectedBTN.Click += new System.EventHandler(this.editSelectedBTN_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 423);
            this.Controls.Add(this.searchTB);
            this.Controls.Add(this.urlLabel);
            this.Controls.Add(this.rtbInfo);
            this.Controls.Add(this.editSelectedBTN);
            this.Controls.Add(this.addUrlBTN);
            this.Controls.Add(this.addDiscographyBTN);
            this.Controls.Add(this.pbox);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.albumCB);
            this.Controls.Add(this.artistCB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Discography Tracker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox artistCB;
        private System.Windows.Forms.ComboBox albumCB;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Length;
        private System.Windows.Forms.PictureBox pbox;
        private System.Windows.Forms.Button addDiscographyBTN;
        private System.Windows.Forms.RichTextBox rtbInfo;
        private System.Windows.Forms.LinkLabel urlLabel;
        private System.Windows.Forms.TextBox searchTB;
        private System.Windows.Forms.Button addUrlBTN;
        private System.Windows.Forms.Button editSelectedBTN;
    }
}

