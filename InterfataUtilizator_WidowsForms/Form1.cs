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

        private Label[] lblsNume;
        private Label[] lblsMaterii;

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
            lblNume.ForeColor = Color.DarkBlue;
            this.Controls.Add(lblNume);

            lblMaterii = new Label();
            lblMaterii.Width = LATIME_CONTROL;
            lblMaterii.Text = "Materii Predate";
            lblMaterii.Left = 2 * DIMENSIUNE_PAS_X;
            lblMaterii.ForeColor = Color.DarkBlue;
            this.Controls.Add(lblMaterii);
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
            }
        }
    }
}
