using System;
using Librarie;
using NivelStocareDate;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace InterfataUtilizator_WindowsForms
{
    public partial class Form1 : Form
    {
        AdministrareProfesori_FisierText adminProfesori;

        private Label lblNume;
        private Label lblMaterii;
        private Label lblPunctaj;

        private Label[] lblsNume;
        private Label[] lblsMaterii;
        private Label[] lblsPunctaj;

        private const int LATIME_CONTROL = 150;
        private const int DIMENSIUNE_PAS_Y = 30;
        private const int DIMENSIUNE_PAS_X = 200;

        public Form1()
        {
            InitializeComponent();
            string numeFisier1 = ConfigurationManager.AppSettings["NumeFisier1"];

            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier1;

            adminProfesori = new AdministrareProfesori_FisierText(caleCompletaFisier);
            int nrProfesori = 0;

            Profesor[] profesori = adminProfesori.GetProfesori(out nrProfesori);

            this.Size = new Size(600, 300);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Arial", 10, FontStyle.Bold);
            this.ForeColor = Color.Navy;
            this.Text = "Informatii profesori";

            lblNume = new Label();
            lblNume.Width = LATIME_CONTROL;
            lblNume.Text = "Nume Profesor";
            lblNume.Left = DIMENSIUNE_PAS_X;
            lblNume.Top = 10;
            lblNume.ForeColor = Color.White;
            lblNume.BackColor = Color.DarkBlue;
            lblNume.TextAlign = ContentAlignment.MiddleCenter;
            lblNume.Font = new Font("Arial", 12, FontStyle.Bold);
            lblNume.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(lblNume);

            lblMaterii = new Label();
            lblMaterii.Width = LATIME_CONTROL;
            lblMaterii.Text = "Materii Predate";
            lblMaterii.Left = 2 * DIMENSIUNE_PAS_X;
            lblMaterii.Top = 10;
            lblMaterii.ForeColor = Color.White;
            lblMaterii.BackColor = Color.DarkGreen;
            lblMaterii.TextAlign = ContentAlignment.MiddleCenter;
            lblMaterii.Font = new Font("Arial", 12, FontStyle.Bold);
            lblMaterii.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(lblMaterii);

            lblPunctaj = new Label();
            lblPunctaj.Width = LATIME_CONTROL;
            lblPunctaj.Text = "Punctaj Profesori";
            lblPunctaj.Left = 3 * DIMENSIUNE_PAS_X;
            lblPunctaj.Top = 10;
            lblPunctaj.ForeColor = Color.White;
            lblPunctaj.BackColor = Color.DarkRed;
            lblPunctaj.TextAlign = ContentAlignment.MiddleCenter;
            lblPunctaj.Font = new Font("Arial", 12, FontStyle.Bold);
            lblPunctaj.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(lblPunctaj);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AfiseazaProfesori();
        }

        private void AfiseazaProfesori()
        {
            Profesor[] profesori = adminProfesori.GetProfesori(out int nrProfesori);

            lblsNume = new Label[nrProfesori];
            lblsMaterii = new Label[nrProfesori];
            lblsPunctaj = new Label[nrProfesori];

            for (int i = 0; i < nrProfesori; i++)
            {
                lblsNume[i] = new Label();
                lblsNume[i].Width = LATIME_CONTROL;
                lblsNume[i].Text = profesori[i].Nume;
                lblsNume[i].Left = DIMENSIUNE_PAS_X;
                lblsNume[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsNume[i]);

                lblsMaterii[i] = new Label();
                lblsMaterii[i].Width = LATIME_CONTROL;
                lblsMaterii[i].Text = profesori[i].Materie.ToString();
                lblsMaterii[i].Left = 2 * DIMENSIUNE_PAS_X;
                lblsMaterii[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsMaterii[i]);

                lblsPunctaj[i] = new Label();
                lblsPunctaj[i].Width = LATIME_CONTROL;
                lblsPunctaj[i].Text = profesori[i].Punctaj.ToString();
                lblsPunctaj[i].Left = 3 * DIMENSIUNE_PAS_X;
                lblsPunctaj[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsPunctaj[i]);

            }
        }
    }
}
