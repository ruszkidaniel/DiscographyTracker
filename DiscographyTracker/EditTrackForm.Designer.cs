namespace DiscographyTracker
{
    partial class EditTrackForm
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
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.saveBTN = new System.Windows.Forms.Button();
            this.trackID = new System.Windows.Forms.TextBox();
            this.trackAlbum = new System.Windows.Forms.TextBox();
            this.trackTitle = new System.Windows.Forms.TextBox();
            this.trackLength = new System.Windows.Forms.TextBox();
            this.trackURL = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(101, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Edit track";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Track ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Track Album:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Track Title:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Track Length:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 197);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Track URL:";
            // 
            // saveBTN
            // 
            this.saveBTN.Location = new System.Drawing.Point(93, 241);
            this.saveBTN.Name = "saveBTN";
            this.saveBTN.Size = new System.Drawing.Size(101, 42);
            this.saveBTN.TabIndex = 2;
            this.saveBTN.Text = "Close";
            this.saveBTN.UseVisualStyleBackColor = true;
            this.saveBTN.Click += new System.EventHandler(this.saveBTN_Click);
            // 
            // trackID
            // 
            this.trackID.Location = new System.Drawing.Point(109, 61);
            this.trackID.Name = "trackID";
            this.trackID.ReadOnly = true;
            this.trackID.Size = new System.Drawing.Size(100, 20);
            this.trackID.TabIndex = 3;
            // 
            // trackAlbum
            // 
            this.trackAlbum.Location = new System.Drawing.Point(109, 98);
            this.trackAlbum.Name = "trackAlbum";
            this.trackAlbum.Size = new System.Drawing.Size(154, 20);
            this.trackAlbum.TabIndex = 3;
            // 
            // trackTitle
            // 
            this.trackTitle.Location = new System.Drawing.Point(109, 132);
            this.trackTitle.Name = "trackTitle";
            this.trackTitle.Size = new System.Drawing.Size(154, 20);
            this.trackTitle.TabIndex = 3;
            // 
            // trackLength
            // 
            this.trackLength.Location = new System.Drawing.Point(109, 162);
            this.trackLength.Name = "trackLength";
            this.trackLength.Size = new System.Drawing.Size(154, 20);
            this.trackLength.TabIndex = 3;
            // 
            // trackURL
            // 
            this.trackURL.Location = new System.Drawing.Point(109, 194);
            this.trackURL.Name = "trackURL";
            this.trackURL.Size = new System.Drawing.Size(154, 20);
            this.trackURL.TabIndex = 3;
            // 
            // EditTrackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 295);
            this.Controls.Add(this.trackURL);
            this.Controls.Add(this.trackLength);
            this.Controls.Add(this.trackTitle);
            this.Controls.Add(this.trackAlbum);
            this.Controls.Add(this.trackID);
            this.Controls.Add(this.saveBTN);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EditTrackForm";
            this.Text = "EditTrackForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button saveBTN;
        internal System.Windows.Forms.TextBox trackID;
        internal System.Windows.Forms.TextBox trackAlbum;
        internal System.Windows.Forms.TextBox trackTitle;
        internal System.Windows.Forms.TextBox trackLength;
        internal System.Windows.Forms.TextBox trackURL;
    }
}