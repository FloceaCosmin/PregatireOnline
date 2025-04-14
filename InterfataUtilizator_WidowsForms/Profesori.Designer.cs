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
            this.panelCautare = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textCautare = new System.Windows.Forms.TextBox();
            this.btnCautareProfesor = new System.Windows.Forms.Button();
            this.panelCautare.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(12, 477);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 31);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "BACK";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.UseWaitCursor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // panelCautare
            // 
            this.panelCautare.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panelCautare.Controls.Add(this.btnCautareProfesor);
            this.panelCautare.Controls.Add(this.textCautare);
            this.panelCautare.Controls.Add(this.label1);
            this.panelCautare.Location = new System.Drawing.Point(571, 22);
            this.panelCautare.Name = "panelCautare";
            this.panelCautare.Size = new System.Drawing.Size(373, 211);
            this.panelCautare.TabIndex = 1;
            this.panelCautare.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Introdu nummele profesorului";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textCautare
            // 
            this.textCautare.Location = new System.Drawing.Point(81, 46);
            this.textCautare.Name = "textCautare";
            this.textCautare.Size = new System.Drawing.Size(213, 22);
            this.textCautare.TabIndex = 1;
            // 
            // btnCautareProfesor
            // 
            this.btnCautareProfesor.Location = new System.Drawing.Point(127, 115);
            this.btnCautareProfesor.Name = "btnCautareProfesor";
            this.btnCautareProfesor.Size = new System.Drawing.Size(136, 23);
            this.btnCautareProfesor.TabIndex = 2;
            this.btnCautareProfesor.Text = "Căutare Profesor";
            this.btnCautareProfesor.UseVisualStyleBackColor = true;
            this.btnCautareProfesor.Click += new System.EventHandler(this.btnCautaProfesor_Click);
            // 
            // Profesori
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1082, 533);
            this.Controls.Add(this.panelCautare);
            this.Controls.Add(this.btnBack);
            this.Name = "Profesori";
            this.Text = "Profesori";
            this.UseWaitCursor = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Profesori_Load);
            this.panelCautare.ResumeLayout(false);
            this.panelCautare.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel panelCautare;
        private System.Windows.Forms.Button btnCautareProfesor;
        private System.Windows.Forms.TextBox textCautare;
        private System.Windows.Forms.Label label1;
    }
}

