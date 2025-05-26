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
            this.btnListaProfesori = new System.Windows.Forms.Button();
            this.btnaddProf = new System.Windows.Forms.Button();
            this.btncautare = new System.Windows.Forms.Button();
            this.btnlistaElevi = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAddelevi = new System.Windows.Forms.Button();
            this.buttonCautareElevi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.DarkBlue;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(39, 478);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(108, 31);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "BACK";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.UseWaitCursor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnListaProfesori
            // 
            this.btnListaProfesori.BackColor = System.Drawing.Color.DarkBlue;
            this.btnListaProfesori.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListaProfesori.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnListaProfesori.Location = new System.Drawing.Point(39, 34);
            this.btnListaProfesori.Name = "btnListaProfesori";
            this.btnListaProfesori.Size = new System.Drawing.Size(108, 37);
            this.btnListaProfesori.TabIndex = 1;
            this.btnListaProfesori.Text = "Profesori";
            this.btnListaProfesori.UseVisualStyleBackColor = false;
            this.btnListaProfesori.UseWaitCursor = true;
            this.btnListaProfesori.Click += new System.EventHandler(this.btnListaProfesori_Click);
            // 
            // btnaddProf
            // 
            this.btnaddProf.BackColor = System.Drawing.Color.DarkBlue;
            this.btnaddProf.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnaddProf.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnaddProf.Location = new System.Drawing.Point(39, 77);
            this.btnaddProf.Name = "btnaddProf";
            this.btnaddProf.Size = new System.Drawing.Size(108, 72);
            this.btnaddProf.TabIndex = 2;
            this.btnaddProf.Text = "Adaugarre Profesor";
            this.btnaddProf.UseVisualStyleBackColor = false;
            this.btnaddProf.UseWaitCursor = true;
            this.btnaddProf.Click += new System.EventHandler(this.btnaddProf_Click);
            // 
            // btncautare
            // 
            this.btncautare.BackColor = System.Drawing.Color.DarkBlue;
            this.btncautare.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncautare.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btncautare.Location = new System.Drawing.Point(39, 155);
            this.btncautare.Name = "btncautare";
            this.btncautare.Size = new System.Drawing.Size(108, 84);
            this.btncautare.TabIndex = 3;
            this.btncautare.Text = "Cautare Profesori / Materii";
            this.btncautare.UseVisualStyleBackColor = false;
            this.btncautare.UseWaitCursor = true;
            this.btncautare.Click += new System.EventHandler(this.btncautare_Click);
            // 
            // btnlistaElevi
            // 
            this.btnlistaElevi.BackColor = System.Drawing.Color.DarkBlue;
            this.btnlistaElevi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlistaElevi.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnlistaElevi.Location = new System.Drawing.Point(39, 258);
            this.btnlistaElevi.Name = "btnlistaElevi";
            this.btnlistaElevi.Size = new System.Drawing.Size(108, 41);
            this.btnlistaElevi.TabIndex = 4;
            this.btnlistaElevi.Text = "Elevi";
            this.btnlistaElevi.UseVisualStyleBackColor = false;
            this.btnlistaElevi.UseWaitCursor = true;
            this.btnlistaElevi.Click += new System.EventHandler(this.btnlistaElevi_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(55, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 22);
            this.label1.TabIndex = 5;
            this.label1.Text = "MENIU";
            this.label1.UseWaitCursor = true;
            // 
            // buttonAddelevi
            // 
            this.buttonAddelevi.BackColor = System.Drawing.Color.DarkBlue;
            this.buttonAddelevi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddelevi.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonAddelevi.Location = new System.Drawing.Point(39, 305);
            this.buttonAddelevi.Name = "buttonAddelevi";
            this.buttonAddelevi.Size = new System.Drawing.Size(108, 72);
            this.buttonAddelevi.TabIndex = 6;
            this.buttonAddelevi.Text = "Adaugare Elevi";
            this.buttonAddelevi.UseVisualStyleBackColor = false;
            this.buttonAddelevi.UseWaitCursor = true;
            this.buttonAddelevi.Click += new System.EventHandler(this.buttonAddelevi_Click);
            // 
            // buttonCautareElevi
            // 
            this.buttonCautareElevi.BackColor = System.Drawing.Color.DarkBlue;
            this.buttonCautareElevi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCautareElevi.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonCautareElevi.Location = new System.Drawing.Point(39, 383);
            this.buttonCautareElevi.Name = "buttonCautareElevi";
            this.buttonCautareElevi.Size = new System.Drawing.Size(108, 84);
            this.buttonCautareElevi.TabIndex = 7;
            this.buttonCautareElevi.Text = "Cautare Elevi";
            this.buttonCautareElevi.UseVisualStyleBackColor = false;
            this.buttonCautareElevi.UseWaitCursor = true;
            this.buttonCautareElevi.Click += new System.EventHandler(this.buttonCautareElevi_Click);
            // 
            // Profesori
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1082, 533);
            this.Controls.Add(this.buttonCautareElevi);
            this.Controls.Add(this.buttonAddelevi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnlistaElevi);
            this.Controls.Add(this.btncautare);
            this.Controls.Add(this.btnaddProf);
            this.Controls.Add(this.btnListaProfesori);
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
        private System.Windows.Forms.Button btnListaProfesori;
        private System.Windows.Forms.Button btnaddProf;
        private System.Windows.Forms.Button btncautare;
        private System.Windows.Forms.Button btnlistaElevi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAddelevi;
        private System.Windows.Forms.Button buttonCautareElevi;
        private System.Windows.Forms.DataGridView dgvElevi;
    }
}

