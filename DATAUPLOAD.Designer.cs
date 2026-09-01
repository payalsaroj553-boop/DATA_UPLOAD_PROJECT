namespace DATA_UPLOAD_PROJECT
{
    partial class Dataupload
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnbrowes = new System.Windows.Forms.Button();
            this.cmbcompain = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnupload = new System.Windows.Forms.Button();
            this.btnsubmit = new System.Windows.Forms.Button();
            this.txtexcel = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BTNEXIT = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.btnview = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Honeydew;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1321, 40);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(508, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "DATA   UPLOAD  TOOL";
            // 
            // btnbrowes
            // 
            this.btnbrowes.BackColor = System.Drawing.Color.Silver;
            this.btnbrowes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbrowes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbrowes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbrowes.Location = new System.Drawing.Point(298, 91);
            this.btnbrowes.Name = "btnbrowes";
            this.btnbrowes.Size = new System.Drawing.Size(152, 41);
            this.btnbrowes.TabIndex = 0;
            this.btnbrowes.Text = "Browses";
            this.btnbrowes.UseVisualStyleBackColor = false;
            this.btnbrowes.Click += new System.EventHandler(this.btnbrowes_Click);
            // 
            // cmbcompain
            // 
            this.cmbcompain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbcompain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbcompain.FormattingEnabled = true;
            this.cmbcompain.Items.AddRange(new object[] {
            "Temp1",
            "Temp2",
            "Temp3"});
            this.cmbcompain.Location = new System.Drawing.Point(730, 100);
            this.cmbcompain.Name = "cmbcompain";
            this.cmbcompain.Size = new System.Drawing.Size(190, 26);
            this.cmbcompain.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(537, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Compain  Table";
            // 
            // btnupload
            // 
            this.btnupload.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnupload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnupload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnupload.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnupload.Location = new System.Drawing.Point(298, 167);
            this.btnupload.Name = "btnupload";
            this.btnupload.Size = new System.Drawing.Size(152, 46);
            this.btnupload.TabIndex = 2;
            this.btnupload.Text = "UPLOAD";
            this.btnupload.UseVisualStyleBackColor = false;
            this.btnupload.Click += new System.EventHandler(this.btnupload_Click);
            // 
            // btnsubmit
            // 
            this.btnsubmit.BackColor = System.Drawing.Color.Yellow;
            this.btnsubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnsubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsubmit.Location = new System.Drawing.Point(298, 239);
            this.btnsubmit.Name = "btnsubmit";
            this.btnsubmit.Size = new System.Drawing.Size(152, 46);
            this.btnsubmit.TabIndex = 4;
            this.btnsubmit.Text = "SUBMIT";
            this.btnsubmit.UseVisualStyleBackColor = false;
            this.btnsubmit.Click += new System.EventHandler(this.btnsubmit_Click);
            // 
            // txtexcel
            // 
            this.txtexcel.BackColor = System.Drawing.SystemColors.Info;
            this.txtexcel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtexcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtexcel.Location = new System.Drawing.Point(79, 91);
            this.txtexcel.Multiline = true;
            this.txtexcel.Name = "txtexcel";
            this.txtexcel.ReadOnly = true;
            this.txtexcel.Size = new System.Drawing.Size(152, 41);
            this.txtexcel.TabIndex = 1;
            this.txtexcel.Enter += new System.EventHandler(this.txtexcel_Enter);
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.SystemColors.Info;
            this.progressBar1.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.progressBar1.Location = new System.Drawing.Point(541, 239);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(178, 33);
            this.progressBar1.TabIndex = 7;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress.Location = new System.Drawing.Point(688, 183);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(31, 18);
            this.lblProgress.TabIndex = 8;
            this.lblProgress.Text = "0%";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(537, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 24);
            this.label3.TabIndex = 9;
            this.label3.Text = "Progress";
            // 
            // BTNEXIT
            // 
            this.BTNEXIT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BTNEXIT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNEXIT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNEXIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNEXIT.Location = new System.Drawing.Point(298, 304);
            this.BTNEXIT.Name = "BTNEXIT";
            this.BTNEXIT.Size = new System.Drawing.Size(152, 46);
            this.BTNEXIT.TabIndex = 5;
            this.BTNEXIT.Text = " EXIT";
            this.BTNEXIT.UseVisualStyleBackColor = false;
            this.BTNEXIT.Click += new System.EventHandler(this.BTNEXIT_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(0, 370);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1321, 394);
            this.webBrowser1.TabIndex = 7;
            // 
            // btnview
            // 
            this.btnview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnview.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnview.Location = new System.Drawing.Point(541, 304);
            this.btnview.Name = "btnview";
            this.btnview.Size = new System.Drawing.Size(179, 46);
            this.btnview.TabIndex = 6;
            this.btnview.Text = "View MasterTable";
            this.btnview.UseVisualStyleBackColor = false;
            this.btnview.Click += new System.EventHandler(this.btnview_Click);
            // 
            // Dataupload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(1317, 756);
            this.Controls.Add(this.btnview);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.BTNEXIT);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.txtexcel);
            this.Controls.Add(this.btnsubmit);
            this.Controls.Add(this.btnupload);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbcompain);
            this.Controls.Add(this.btnbrowes);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dataupload";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.Dataupload_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnbrowes;
        private System.Windows.Forms.ComboBox cmbcompain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnupload;
        private System.Windows.Forms.Button btnsubmit;
        private System.Windows.Forms.TextBox txtexcel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BTNEXIT;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button btnview;
    }
}

