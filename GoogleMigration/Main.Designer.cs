namespace GoogleMigration
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
            this.btn_GroupUpload = new System.Windows.Forms.Button();
            this.readPst_btn = new System.Windows.Forms.Button();
            this.txt_pstPath = new System.Windows.Forms.TextBox();
            this.browse_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_SetClientId = new System.Windows.Forms.Button();
            this.txt_GroupAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_GroupUpload
            // 
            this.btn_GroupUpload.Location = new System.Drawing.Point(157, 94);
            this.btn_GroupUpload.Name = "btn_GroupUpload";
            this.btn_GroupUpload.Size = new System.Drawing.Size(111, 23);
            this.btn_GroupUpload.TabIndex = 0;
            this.btn_GroupUpload.Text = "Group Upload Test";
            this.btn_GroupUpload.UseVisualStyleBackColor = true;
            this.btn_GroupUpload.Click += new System.EventHandler(this.btn_GroupUpload_Click);
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
            // txt_pstPath
            // 
            this.txt_pstPath.Location = new System.Drawing.Point(98, 12);
            this.txt_pstPath.Name = "txt_pstPath";
            this.txt_pstPath.Size = new System.Drawing.Size(362, 20);
            this.txt_pstPath.TabIndex = 2;
            // 
            // browse_btn
            // 
            this.browse_btn.Location = new System.Drawing.Point(385, 43);
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
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "PST file path:";
            // 
            // btn_SetClientId
            // 
            this.btn_SetClientId.Location = new System.Drawing.Point(12, 94);
            this.btn_SetClientId.Name = "btn_SetClientId";
            this.btn_SetClientId.Size = new System.Drawing.Size(99, 23);
            this.btn_SetClientId.TabIndex = 5;
            this.btn_SetClientId.Text = "Set Client API ID";
            this.btn_SetClientId.UseVisualStyleBackColor = true;
            this.btn_SetClientId.Click += new System.EventHandler(this.btn_SetClientId_Click);
            // 
            // txt_GroupAddress
            // 
            this.txt_GroupAddress.Location = new System.Drawing.Point(98, 38);
            this.txt_GroupAddress.Name = "txt_GroupAddress";
            this.txt_GroupAddress.Size = new System.Drawing.Size(170, 20);
            this.txt_GroupAddress.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Group Address:";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 129);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_GroupAddress);
            this.Controls.Add(this.btn_SetClientId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.browse_btn);
            this.Controls.Add(this.txt_pstPath);
            this.Controls.Add(this.readPst_btn);
            this.Controls.Add(this.btn_GroupUpload);
            this.Name = "Main";
            this.Text = "Google Groups Migrate";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_GroupUpload;
        private System.Windows.Forms.Button readPst_btn;
        private System.Windows.Forms.TextBox txt_pstPath;
        private System.Windows.Forms.Button browse_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_SetClientId;
        private System.Windows.Forms.TextBox txt_GroupAddress;
        private System.Windows.Forms.Label label2;
    }
}

