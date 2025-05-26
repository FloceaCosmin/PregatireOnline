namespace InterfataUtilizator_WindowsForms
{
    public partial class Sesiuni
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
            this.btnBACK = new System.Windows.Forms.Button();
            this.btnAddSes = new System.Windows.Forms.Button();
            this.btnListSes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(23, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 22);
            this.label1.TabIndex = 13;
            this.label1.Text = "MENIU";
            this.label1.UseWaitCursor = true;
            // 
            // btnBACK
            // 
            this.btnBACK.BackColor = System.Drawing.Color.DarkBlue;
            this.btnBACK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBACK.ForeColor = System.Drawing.Color.White;
            this.btnBACK.Location = new System.Drawing.Point(5, 503);
            this.btnBACK.Name = "btnBACK";
            this.btnBACK.Size = new System.Drawing.Size(108, 31);
            this.btnBACK.TabIndex = 8;
            this.btnBACK.Text = "BACK";
            this.btnBACK.UseVisualStyleBackColor = false;
            this.btnBACK.UseWaitCursor = true;
            this.btnBACK.Click += new System.EventHandler(this.btnBACK_Click_1);
            // 
            // btnAddSes
            // 
            this.btnAddSes.BackColor = System.Drawing.Color.DarkBlue;
            this.btnAddSes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSes.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAddSes.Location = new System.Drawing.Point(5, 170);
            this.btnAddSes.Name = "btnAddSes";
            this.btnAddSes.Size = new System.Drawing.Size(108, 82);
            this.btnAddSes.TabIndex = 16;
            this.btnAddSes.Text = "Adaugare\r\nsesiune";
            this.btnAddSes.UseVisualStyleBackColor = false;
            this.btnAddSes.UseWaitCursor = true;
            this.btnAddSes.Click += new System.EventHandler(this.btnAddSes_Click);
            // 
            // btnListSes
            // 
            this.btnListSes.BackColor = System.Drawing.Color.DarkBlue;
            this.btnListSes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListSes.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnListSes.Location = new System.Drawing.Point(5, 68);
            this.btnListSes.Name = "btnListSes";
            this.btnListSes.Size = new System.Drawing.Size(108, 83);
            this.btnListSes.TabIndex = 17;
            this.btnListSes.Text = "Sesiuni\r\n   de \r\npregatire";
            this.btnListSes.UseVisualStyleBackColor = false;
            this.btnListSes.UseWaitCursor = true;
            this.btnListSes.Click += new System.EventHandler(this.btnListSes_Click);
            // 
            // Sesiuni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1354, 558);
            this.Controls.Add(this.btnListSes);
            this.Controls.Add(this.btnAddSes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBACK);
            this.Name = "Sesiuni";
            this.Text = "Elevi";
            this.Load += new System.EventHandler(this.Sesiuni_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBACK;
        private System.Windows.Forms.Button btnAddSes;
        private System.Windows.Forms.Button btnListSes;
    }
}

