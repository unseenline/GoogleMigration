namespace GoogleMigration
{
    partial class AddApiInfo
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
            this.txt_ClientId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_ClientSecret = new System.Windows.Forms.TextBox();
            this.submit_btn = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ClientId:";
            // 
            // txt_ClientId
            // 
            this.txt_ClientId.Location = new System.Drawing.Point(85, 6);
            this.txt_ClientId.Name = "txt_ClientId";
            this.txt_ClientId.Size = new System.Drawing.Size(331, 20);
            this.txt_ClientId.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "ClientSecret:";
            // 
            // txt_ClientSecret
            // 
            this.txt_ClientSecret.Location = new System.Drawing.Point(85, 32);
            this.txt_ClientSecret.Name = "txt_ClientSecret";
            this.txt_ClientSecret.Size = new System.Drawing.Size(331, 20);
            this.txt_ClientSecret.TabIndex = 1;
            // 
            // submit_btn
            // 
            this.submit_btn.Location = new System.Drawing.Point(260, 58);
            this.submit_btn.Name = "submit_btn";
            this.submit_btn.Size = new System.Drawing.Size(75, 23);
            this.submit_btn.TabIndex = 2;
            this.submit_btn.Text = "Submit";
            this.submit_btn.UseVisualStyleBackColor = true;
            this.submit_btn.Click += new System.EventHandler(this.submit_btn_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(341, 58);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 3;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // AddApiInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 88);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.submit_btn);
            this.Controls.Add(this.txt_ClientSecret);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_ClientId);
            this.Controls.Add(this.label1);
            this.Name = "AddApiInfo";
            this.Text = "Add API Info";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_ClientId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_ClientSecret;
        private System.Windows.Forms.Button submit_btn;
        private System.Windows.Forms.Button btn_Cancel;
    }
}