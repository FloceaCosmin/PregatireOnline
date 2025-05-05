namespace InterfataUtilizator_WindowsForms
{
    public partial class Profesori
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
            this.btnBack = new System.Windows.Forms.Button();
            this.radioButtonAdaugare = new System.Windows.Forms.RadioButton();
            this.radioButtonEditare = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.DarkBlue;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(12, 490);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 31);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "BACK";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.UseWaitCursor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // radioButtonAdaugare
            // 
            this.radioButtonAdaugare.AutoSize = true;
            this.radioButtonAdaugare.Location = new System.Drawing.Point(732, 304);
            this.radioButtonAdaugare.Name = "radioButtonAdaugare";
            this.radioButtonAdaugare.Size = new System.Drawing.Size(175, 20);
            this.radioButtonAdaugare.TabIndex = 1;
            this.radioButtonAdaugare.TabStop = true;
            this.radioButtonAdaugare.Text = "Adaugare Profesor NOU";
            this.radioButtonAdaugare.UseVisualStyleBackColor = true;
            this.radioButtonAdaugare.CheckedChanged += new System.EventHandler(this.radioButtonAdaugare_CheckedChanged);
            // 
            // radioButtonEditare
            // 
            this.radioButtonEditare.AutoSize = true;
            this.radioButtonEditare.Location = new System.Drawing.Point(732, 331);
            this.radioButtonEditare.Name = "radioButtonEditare";
            this.radioButtonEditare.Size = new System.Drawing.Size(125, 20);
            this.radioButtonEditare.TabIndex = 2;
            this.radioButtonEditare.TabStop = true;
            this.radioButtonEditare.Text = "Editare Profesor";
            this.radioButtonEditare.UseVisualStyleBackColor = true;
            this.radioButtonEditare.CheckedChanged += new System.EventHandler(this.radioButtonEditare_CheckedChanged);
            // 
            // Profesori
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1082, 533);
            this.Controls.Add(this.radioButtonEditare);
            this.Controls.Add(this.radioButtonAdaugare);
            this.Controls.Add(this.btnBack);
            this.Name = "Profesori";
            this.Text = "Profesori";
            this.UseWaitCursor = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Profesori_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.RadioButton radioButtonAdaugare;
        private System.Windows.Forms.RadioButton radioButtonEditare;
    }
}

