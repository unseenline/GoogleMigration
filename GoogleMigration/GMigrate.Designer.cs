namespace GoogleMigration
{
    partial class GMigrate
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
            this.button1 = new System.Windows.Forms.Button();
            this.readPst_btn = new System.Windows.Forms.Button();
            this.pstPath_txt = new System.Windows.Forms.TextBox();
            this.browse_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 94);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Group Upload Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // readPst_btn
            // 
            this.readPst_btn.Location = new System.Drawing.Point(380, 94);
            this.readPst_btn.Name = "readPst_btn";
            this.readPst_btn.Size = new System.Drawing.Size(75, 23);
            this.readPst_btn.TabIndex = 1;
            this.readPst_btn.Text = "Read PST";
            this.readPst_btn.UseVisualStyleBackColor = true;
            this.readPst_btn.Click += new System.EventHandler(this.readPst_btn_Click);
            // 
            // pstPath_txt
            // 
            this.pstPath_txt.Location = new System.Drawing.Point(12, 23);
            this.pstPath_txt.Name = "pstPath_txt";
            this.pstPath_txt.Size = new System.Drawing.Size(362, 20);
            this.pstPath_txt.TabIndex = 2;
            this.pstPath_txt.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // browse_btn
            // 
            this.browse_btn.Location = new System.Drawing.Point(380, 21);
            this.browse_btn.Name = "browse_btn";
            this.browse_btn.Size = new System.Drawing.Size(75, 23);
            this.browse_btn.TabIndex = 3;
            this.browse_btn.Text = "Browse..";
            this.browse_btn.UseVisualStyleBackColor = true;
            this.browse_btn.Click += new System.EventHandler(this.browse_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "PST file path:";
            // 
            // GMigrate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 129);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.browse_btn);
            this.Controls.Add(this.pstPath_txt);
            this.Controls.Add(this.readPst_btn);
            this.Controls.Add(this.button1);
            this.Name = "GMigrate";
            this.Text = "Google Groups Migrate";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button readPst_btn;
        private System.Windows.Forms.TextBox pstPath_txt;
        private System.Windows.Forms.Button browse_btn;
        private System.Windows.Forms.Label label1;
    }
}

