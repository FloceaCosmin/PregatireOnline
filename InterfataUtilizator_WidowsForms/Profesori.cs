﻿using System;
using Librarie;
using NivelStocareDate;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace InterfataUtilizator_WindowsForms
{
    public partial class Profesori : Form
    {
        AdministrareProfesori_FisierText adminProfesori;

        private TextBox txtNume;
        private TextBox txtEmail;
        private TextBox txtPunctaj;
        private ComboBox cmbMaterie;


        private Label lblNumeP;
        private Label lblEmail;
        private Label lblMaterii;
        private Label lblPunctaj;
        private Label lblAdminInfo;
        private Button btnAdaugaProfesor;
        private Label lblEroarePunctaj;
        private Label lblEroareMaterie;


        private Label[] lblsNumeP;
        private Label[] lblsEmail;
        private Label[] lblsMaterii;
        private Label[] lblsPunctaj;

        private const int LATIME_CONTROL = 150;
        private const int DIMENSIUNE_PAS_Y = 30;
        private const int DIMENSIUNE_PAS_X = 150;
        Administrator admin = new Administrator("Cosmin", "cosmin@yahoo.com");


        public Profesori()
        {
            InitializeComponent();
            

            string numeFisier1 = ConfigurationManager.AppSettings["NumeFisier1"];

            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier1 = locatieFisierSolutie + "\\" + numeFisier1;

            adminProfesori = new AdministrareProfesori_FisierText(caleCompletaFisier1);

            int nrProfesori = 0;

            Profesor[] profesori = adminProfesori.GetProfesori(out nrProfesori);

            this.Size = new Size(900, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Arial", 10, FontStyle.Bold);
            this.ForeColor = Color.Navy;
            this.Text = "Informatii profesori";

            lblNumeP = new Label();
            lblNumeP.Width = LATIME_CONTROL;
            lblNumeP.Text = "Nume Profesor";
            lblNumeP.Left = DIMENSIUNE_PAS_X;
            lblNumeP.Top = 10;
            lblNumeP.ForeColor = Color.White;
            lblNumeP.BackColor = Color.DarkBlue;
            lblNumeP.TextAlign = ContentAlignment.MiddleCenter;
            lblNumeP.Font = new Font("Arial", 12, FontStyle.Bold);
            lblNumeP.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(lblNumeP);

            lblEmail = new Label();
            lblEmail.Width = LATIME_CONTROL;
            lblEmail.Text = "Email Profesor";
            lblEmail.Left = 2* DIMENSIUNE_PAS_X;
            lblEmail.Top = 10;
            lblEmail.ForeColor = Color.White;
            lblEmail.BackColor = Color.RoyalBlue;
            lblEmail.TextAlign = ContentAlignment.MiddleCenter;
            lblEmail.Font = new Font("Arial", 12, FontStyle.Bold);
            lblEmail.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(lblEmail);

            lblMaterii = new Label();
            lblMaterii.Width = LATIME_CONTROL;
            lblMaterii.Text = "Materii Predate";
            lblMaterii.Left = 3 * DIMENSIUNE_PAS_X;
            lblMaterii.Top = 10;
            lblMaterii.ForeColor = Color.White;
            lblMaterii.BackColor = Color.DarkBlue;
            lblMaterii.TextAlign = ContentAlignment.MiddleCenter;
            lblMaterii.Font = new Font("Arial", 12, FontStyle.Bold);
            lblMaterii.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(lblMaterii);

            lblPunctaj = new Label();
            lblPunctaj.Width = LATIME_CONTROL;
            lblPunctaj.Text = "Punctaj Profesor";
            lblPunctaj.Left = 4 * DIMENSIUNE_PAS_X;
            lblPunctaj.Top = 10;
            lblPunctaj.ForeColor = Color.White;
            lblPunctaj.BackColor = Color.RoyalBlue;
            lblPunctaj.TextAlign = ContentAlignment.MiddleCenter;
            lblPunctaj.Font = new Font("Arial", 12, FontStyle.Bold);
            lblPunctaj.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(lblPunctaj);

            btnAdaugaProfesor = new Button();
            btnAdaugaProfesor.Text = "Adauga Profesor";
            btnAdaugaProfesor.Left = 5 * DIMENSIUNE_PAS_X;
            btnAdaugaProfesor.Top = 10;
            btnAdaugaProfesor.BackColor = Color.BlueViolet;
            btnAdaugaProfesor.ForeColor = Color.White;
            btnAdaugaProfesor.Width = LATIME_CONTROL;
            btnAdaugaProfesor.Click += btnAdaugaProfesor_Click;  
            this.Controls.Add(btnAdaugaProfesor);

            
            Label lblNumeInput = new Label
            {
                Text = "Nume:",
                Left = 5 * DIMENSIUNE_PAS_X,
                Top = 60,
                Width = LATIME_CONTROL
            };
            this.Controls.Add(lblNumeInput);

            txtNume = new TextBox
            {
                Left = 5 * DIMENSIUNE_PAS_X,
                Top = 80,
                Width = LATIME_CONTROL
            };
            this.Controls.Add(txtNume);

            Label lblEmailInput = new Label
            {
                Text = "Email:",
                Left = 5 * DIMENSIUNE_PAS_X,
                Top = 120,
                Width = LATIME_CONTROL
            };
            this.Controls.Add(lblEmailInput);

            txtEmail = new TextBox
            {
                Left = 5 * DIMENSIUNE_PAS_X,
                Top = 140,
                Width = LATIME_CONTROL
            };
            this.Controls.Add(txtEmail);

            Label lblMaterieInput = new Label
            {
                Text = "Materie:",
                Left = 5 * DIMENSIUNE_PAS_X,
                Top = 180,
                Width = LATIME_CONTROL
            };
            this.Controls.Add(lblMaterieInput);

            cmbMaterie = new ComboBox
            {
                Left = 5 * DIMENSIUNE_PAS_X,
                Top = 200,
                Width = LATIME_CONTROL,
                DropDownStyle = ComboBoxStyle.DropDownList 
            };

            
            foreach (var materie in Enum.GetValues(typeof(Materie)))
            {
                if ((Materie)materie != Materie.Nimic)
                    cmbMaterie.Items.Add(materie);
            }

            this.Controls.Add(cmbMaterie);

            lblEroareMaterie = new Label
            {
                Left = 5 * DIMENSIUNE_PAS_X,
                Top = 20,
                Height = 30,
                Width = LATIME_CONTROL,
                ForeColor = Color.Red,
                Font = new Font("Arial", 8, FontStyle.Regular),
                Text = "",
                Visible = false
            };
            this.Controls.Add(lblEroarePunctaj);


            Label lblPunctajInput = new Label
            {
                Text = "Punctaj:",
                Left = 5 * DIMENSIUNE_PAS_X,
                Top = 240,
                Width = LATIME_CONTROL
            };
            this.Controls.Add(lblPunctajInput);

            txtPunctaj = new TextBox
            {
                Left = 5 * DIMENSIUNE_PAS_X,
                Top = 260,
                Width = LATIME_CONTROL
            };
            this.Controls.Add(txtPunctaj);

            lblEroarePunctaj = new Label
            {
                Left = 5 * DIMENSIUNE_PAS_X,
                Top = 290,
                Height = 30,
                Width = LATIME_CONTROL,
                ForeColor = Color.Red,
                Font = new Font("Arial", 8, FontStyle.Regular),
                Text = "",
                Visible = false
            };
            this.Controls.Add(lblEroarePunctaj);


        }

        private void Profesori_Load(object sender, EventArgs e)
        {
            AfiseazaProfesori();
            AdaugaInfoAdministrator(admin);

        }

        private void AdaugaInfoAdministrator(Administrator admin)
        {

            lblAdminInfo = new Label
            {
                Text = admin.Info(),
                Left = this.ClientSize.Width - 300,
                Top = this.ClientSize.Height - 30,
                Width = 280,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 10, FontStyle.Regular),
                ForeColor = Color.Black
            };
            this.Controls.Add(lblAdminInfo);
        }

        private void AfiseazaProfesori()
        {
            Profesor[] profesori = adminProfesori.GetProfesori(out int nrProfesori);
            

            lblsNumeP = new Label[nrProfesori];
            lblsMaterii = new Label[nrProfesori];
            lblsPunctaj = new Label[nrProfesori];
            lblsEmail = new Label[nrProfesori];

            for (int i = 0; i < nrProfesori; i++)
            {
                lblsNumeP[i] = new Label();
                lblsNumeP[i].Width = LATIME_CONTROL;
                lblsNumeP[i].Text = profesori[i].Nume;
                lblsNumeP[i].Left = DIMENSIUNE_PAS_X;
                lblsNumeP[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsNumeP[i]);

                lblsEmail[i] = new Label();
                lblsEmail[i].Width = LATIME_CONTROL;
                lblsEmail[i].Text = profesori[i].Email;
                lblsEmail[i].Left =2 * DIMENSIUNE_PAS_X;
                lblsEmail[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsEmail[i]);

                lblsMaterii[i] = new Label();
                lblsMaterii[i].Width = LATIME_CONTROL;
                lblsMaterii[i].Text = profesori[i].Materie.ToString();
                lblsMaterii[i].Left = 3 * DIMENSIUNE_PAS_X;
                lblsMaterii[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsMaterii[i]);

                lblsPunctaj[i] = new Label();
                lblsPunctaj[i].Width = LATIME_CONTROL;
                lblsPunctaj[i].Text = profesori[i].Punctaj.ToString();
                lblsPunctaj[i].Left = 4 * DIMENSIUNE_PAS_X;
                lblsPunctaj[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsPunctaj[i]);

            }
            
        }

        private void btnAdaugaProfesor_Click(object sender, EventArgs e)
        {
            
            string nume = txtNume.Text.Trim();
            string email = txtEmail.Text.Trim();
            int punctaj;

            
            if (!int.TryParse(txtPunctaj.Text, out punctaj) || punctaj < 1 || punctaj > 10)
            {
                lblEroarePunctaj.Text = "Punctajul trebuie să fie\n un numar între 1 și 10!";
                lblEroarePunctaj.Visible = true;
                return;
            }
            else
            {
                lblEroarePunctaj.Visible = false;
            }


            // 2. Convertire materii bifate în enum (dacă e CheckedListBox)
            Materie materieSelectata = Materie.Nimic;
            if (cmbMaterie.SelectedItem != null)
            {
                materieSelectata = (Materie)Enum.Parse(typeof(Materie), cmbMaterie.SelectedItem.ToString());
            }
            else
            {
                MessageBox.Show("Selectează o materie!");
                return;
            }


            // 3. Creare obiect Profesor
            Profesor profesorNou = new Profesor(nume, email, materieSelectata, punctaj);

            // 4. Salvare în fișier
            adminProfesori.AddProfesor(profesorNou);

            
            Profesori_Load(this, EventArgs.Empty); // reafișează
                                                   
            txtNume.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPunctaj.Text = string.Empty;
            cmbMaterie.SelectedIndex = -1;
        }



    }
}
