using System;
using Librarie;
using NivelStocareDate;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using InterfataUtilizator_WidowsForms;
using System.Linq;

namespace InterfataUtilizator_WindowsForms
{
    public partial class Profesori : Form
    {
        AdministrareProfesori_FisierText adminProfesori;

        private TextBox txtNume;
        private TextBox txtEmail;


        private Label lblNumeP;
        private Label lblEmail;
        private Label lblMaterii;
        private Label lblPunctaj;
        private Label lblAdminInfo;
        private Button btnAdaugaProfesor;
        private Label lblEroarePunctaj;


        private Label[] lblsNumeP;
        private Label[] lblsEmail;
        private Label[] lblsMaterii;
        private Label[] lblsPunctaj;

        private const int LATIME_CONTROL = 150;
        private const int DIMENSIUNE_PAS_Y = 30;
        private const int DIMENSIUNE_PAS_X = 150;
        Administrator admin = new Administrator("Cosmin", "cosmin@yahoo.com");

        private Panel panelListaProfesori;
        private Panel panelAdaugareProfesor;
        private Panel panelCautareProfesor;

        private CheckBox[] checkBoxMaterii;
        private RadioButton[] radioButtonsPunctaj;



        public Profesori()
        {
            InitializeComponent();

            Panel panelMeniu = new Panel
            {
                Width = 100,
                Height = this.ClientSize.Height,
                BackColor = Color.LightSlateGray,
                Dock = DockStyle.Left,
                Text="Meniu"
            };
            this.Controls.Add(panelMeniu);

            panelListaProfesori = new Panel
            {
                Dock = DockStyle.Fill,
                Visible = false
            };
            this.Controls.Add(panelListaProfesori);

            panelAdaugareProfesor = new Panel
            {
                Dock = DockStyle.Fill,
                Visible = false
            };
            this.Controls.Add(panelAdaugareProfesor);

            panelCautareProfesor = new Panel
            {
                Dock = DockStyle.Fill,
                Visible = false
            };
            this.Controls.Add(panelCautareProfesor);



            Button btnMeniuAdaugare = new Button
            {
                Text = "Adăugare\nProfesori",
                Width = 80,
                Height = 40,
                Top = 20,
                Left = 10,
                BackColor = Color.MediumSlateBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnMeniuAdaugare.FlatAppearance.BorderSize = 0;
            btnMeniuAdaugare.Click += btnAdaugaProfesor_Click; 
            panelMeniu.Controls.Add(btnMeniuAdaugare);

            
            Button btnCautaProfesor = new Button
            {
                Text = "Caută\nProfesor",
                Width = 80,
                Height = 40,
                Top = 70,
                Left = 10,
                BackColor = Color.MediumSlateBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnCautaProfesor.Click += btnCautaProfesor_Click;

            
            btnCautaProfesor.FlatAppearance.BorderSize = 0;
            panelMeniu.Controls.Add(btnCautaProfesor);

            
            Button btnElevi = new Button
            {
                Text = "Lista Elevi",
                Width = 80,
                Height = 40,
                Top = 120,
                Left = 10,
                BackColor = Color.MediumSlateBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnElevi.FlatAppearance.BorderSize = 0;
            btnElevi.Click += BtnElevi_Click;
            panelMeniu.Controls.Add(btnElevi);


            

            string numeFisier1 = ConfigurationManager.AppSettings["NumeFisier1"];

            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier1 = locatieFisierSolutie + "\\" + numeFisier1;

            adminProfesori = new AdministrareProfesori_FisierText(caleCompletaFisier1);

            int nrProfesori = 0;

            Profesor[] profesori = adminProfesori.GetProfesori(out nrProfesori);

            this.Size = new Size(1000, 500);
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
            btnAdaugaProfesor.Left = 6 * DIMENSIUNE_PAS_X;
            btnAdaugaProfesor.Top = 10;
            btnAdaugaProfesor.BackColor = Color.BlueViolet;
            btnAdaugaProfesor.ForeColor = Color.White;
            btnAdaugaProfesor.Width = LATIME_CONTROL;
            btnAdaugaProfesor.Click += btnAdaugaProfesor_Click;  
            this.Controls.Add(btnAdaugaProfesor);

            
            Label lblNumeInput = new Label
            {
                Text = "Nume:",
                Left = 6 * DIMENSIUNE_PAS_X,
                Top = 60,
                Width = LATIME_CONTROL
            };
            this.Controls.Add(lblNumeInput);

            txtNume = new TextBox
            {
                Left = 6 * DIMENSIUNE_PAS_X,
                Top = 80,
                Width = LATIME_CONTROL
            };
            this.Controls.Add(txtNume);

            Label lblEmailInput = new Label
            {
                Text = "Email:",
                Left = 6 * DIMENSIUNE_PAS_X,
                Top = 120,
                Width = LATIME_CONTROL
            };
            this.Controls.Add(lblEmailInput);

            txtEmail = new TextBox
            {
                Left = 6 * DIMENSIUNE_PAS_X,
                Top = 140,
                Width = LATIME_CONTROL
            };
            this.Controls.Add(txtEmail);

            Label lblMaterieInput = new Label
            {
                Text = "Materie:",
                Left = 6 * DIMENSIUNE_PAS_X,
                Top = 180,
                Width = LATIME_CONTROL
            };
            this.Controls.Add(lblMaterieInput);

           
            Panel panelMaterii = new Panel
            {
                Left = 6 * DIMENSIUNE_PAS_X,
                Top = 200,
                Width = LATIME_CONTROL * 2,
                Height = 100,
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(panelMaterii);


            List<Materie> listaMaterii = new List<Materie>();

            foreach (Materie materie in Enum.GetValues(typeof(Materie)))
            {
                if (materie != Materie.Nimic)
                {
                    listaMaterii.Add(materie);
                }
            }

            Materie[] materii = listaMaterii.ToArray();


            checkBoxMaterii = new CheckBox[materii.Length];
            int checkBoxWidth = LATIME_CONTROL - 20;
            int checkBoxHeight = 25;
            int coloanaWidth = checkBoxWidth;
            int nrPerColoana = (materii.Length + 1) / 2;

            for (int i = 0; i < materii.Length; i++)
            {
                checkBoxMaterii[i] = new CheckBox
                {
                    Text = materii[i].ToString(),
                    Width = checkBoxWidth,
                    Height = checkBoxHeight,
                    Left = (i >= nrPerColoana ? coloanaWidth : 0) + 10,
                    Top = ((i % nrPerColoana) * checkBoxHeight) + 5,
                    Font = new Font("Arial", 9)
                };
                panelMaterii.Controls.Add(checkBoxMaterii[i]);
            }

            Label lblPunctajInput = new Label
            {
                Text = "Punctaj:",
                Left = 6 * DIMENSIUNE_PAS_X,
                Top = 300, 
                Width = LATIME_CONTROL,
            };
            this.Controls.Add(lblPunctajInput);


            Panel panelPunctaj = new Panel
            {
                Left = 6 * DIMENSIUNE_PAS_X,
                Top = 320,
                Width = LATIME_CONTROL * 2,
                Height = 60,
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(panelPunctaj);

            radioButtonsPunctaj = new RadioButton[5];
            for (int i = 0; i < 5; i++)
            {
                radioButtonsPunctaj[i] = new RadioButton
                {
                    Text = (i + 1).ToString(),
                    Left = 10 + i * 30, 
                    Top = 20,
                    Width = 30,
                    Height = 20
                };
                panelPunctaj.Controls.Add(radioButtonsPunctaj[i]);
            }


            lblEroarePunctaj = new Label
            {
                Left = 6 * DIMENSIUNE_PAS_X,
                Top = 370,
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
                Left = this.ClientSize.Width-300,
                Top = this.ClientSize.Height - 50,
                Width = 280,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 10, FontStyle.Regular),
                ForeColor = Color.Black
            };
            lblAdminInfo.BringToFront();
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
                lblsMaterii[i].Text = string.Join(", ", profesori[i].Materii);
                lblsMaterii[i].Left = 3 * DIMENSIUNE_PAS_X;
                lblsMaterii[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsMaterii[i]);


                lblsPunctaj[i] = new Label();
                lblsPunctaj[i].Width = LATIME_CONTROL;
                lblsPunctaj[i].Text = profesori[i].Punctaj.ToString();
                lblsPunctaj[i].Left = 4 * DIMENSIUNE_PAS_X;
                lblsPunctaj[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsPunctaj[i]);

                Button[] btnsEditare = new Button[nrProfesori];
                    btnsEditare[i] = new Button
                    {
                        Text = "Editează",
                        Width = 80,
                        Height = 25,
                        Left = 5 * DIMENSIUNE_PAS_X,
                        Top = (i + 1) * DIMENSIUNE_PAS_Y,
                        Tag = profesori[i] 
                    };
                    btnsEditare[i].Click += BtnEditare_Click;
                    this.Controls.Add(btnsEditare[i]);


            }

        }

        private void BtnEditare_Click(object sender, EventArgs e)
        {
            Button btnEditare = sender as Button;
            Profesor profesorSelectat = btnEditare.Tag as Profesor;

            if (profesorSelectat != null)
            {
                txtNume.Text = profesorSelectat.Nume;
                txtEmail.Text = profesorSelectat.Email;

                foreach (var cb in checkBoxMaterii)
                {
                    cb.Checked = profesorSelectat.Materii.Contains((Materie)Enum.Parse(typeof(Materie), cb.Text));
                }

                for (int i = 0; i < radioButtonsPunctaj.Length; i++)
                {
                    radioButtonsPunctaj[i].Checked = (i + 1) == profesorSelectat.Punctaj;
                }

                
                btnAdaugaProfesor.Tag = profesorSelectat;
                btnAdaugaProfesor.Text = "Salvează";
            }
        }

        private void btnAdaugaProfesor_Click(object sender, EventArgs e)
        {
            string nume = txtNume.Text.Trim();
            string email = txtEmail.Text.Trim();
            int punctaj = GetPunctajSelectat();
            if (punctaj == 0)
            {
                MessageBox.Show("Te rog selectează un punctaj!");
                return;
            }
            else
            {
                lblEroarePunctaj.Visible = false;
            }
            List<Materie> materiiSelectate = new List<Materie>();

            
            foreach (var checkBox in checkBoxMaterii)
            {
                
                if (checkBox.Checked)
                {
                    Materie materie = (Materie)Enum.Parse(typeof(Materie), checkBox.Text);
                    materiiSelectate.Add(materie);
                }
            }

            if (!materiiSelectate.Any())
            {
                MessageBox.Show("Selectați cel puțin o materie!");
                return;
            }

            Profesor profesorSelectat = btnAdaugaProfesor.Tag as Profesor;

            if (profesorSelectat != null)
            {
                
                profesorSelectat.Nume = nume;
                profesorSelectat.Email = email;
                profesorSelectat.Punctaj = punctaj;
                profesorSelectat.Materii = materiiSelectate;

                adminProfesori.UpdateProfesor(profesorSelectat);


                MessageBox.Show("Profesorul a fost actualizat cu succes!");
                btnAdaugaProfesor.Tag = null;
                btnAdaugaProfesor.Text = "Adaugă Profesor";
            }

            else
            {
                
                Profesor profesorNou = new Profesor(nume, email, materiiSelectate, punctaj);
                adminProfesori.AddProfesor(profesorNou);
            }
            AfiseazaProfesori();

            Profesori_Load(this, EventArgs.Empty);

            txtNume.Text = string.Empty;
            txtEmail.Text = string.Empty;

           
            foreach (var cb in checkBoxMaterii)
            {
                cb.Checked = false;
            }
            foreach (var rb in radioButtonsPunctaj)
            {
                rb.Checked = false;
            }

        }

        private void BtnElevi_Click(object sender, EventArgs e)
        {
            Elevi frmElevi = new Elevi();
            frmElevi.Show(); 
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        private void btnCautaProfesor_Click(object sender, EventArgs e)
        {
           // Console.WriteLine("Butonul de căutare a fost apăsat.");

            string cautaNume = txtNume.Text.Trim(); 

            if (string.IsNullOrEmpty(cautaNume))
            {
                MessageBox.Show("Introduceți un nume de profesor pentru căutare.");
                return;
            }

            Profesor[] totiProfesorii = adminProfesori.GetProfesori(out int nrProfesori);

            
            List<Profesor> profesoriFiltrati = new List<Profesor>();
            foreach (var profesor in totiProfesorii)
            {
                if (profesor.Nume.ToLower().Contains(cautaNume.ToLower()))
                {
                    profesoriFiltrati.Add(profesor);
                }
            }

            
            Profesor[] profesoriGasiti = profesoriFiltrati.ToArray();


            if (profesoriGasiti.Length == 0)
            {
                MessageBox.Show("Nu s-a găsit niciun profesor cu acest nume.");
                return;
            }

            foreach (var lbl in lblsNumeP)
                this.Controls.Remove(lbl);
            foreach (var lbl in lblsEmail)
                this.Controls.Remove(lbl);
            foreach (var lbl in lblsMaterii)
                this.Controls.Remove(lbl);
            foreach (var lbl in lblsPunctaj)
                this.Controls.Remove(lbl);

            lblsNumeP = new Label[profesoriGasiti.Length];
            lblsEmail = new Label[profesoriGasiti.Length];
            lblsMaterii = new Label[profesoriGasiti.Length];
            lblsPunctaj = new Label[profesoriGasiti.Length];

            for (int i = 0; i < profesoriGasiti.Length; i++)
            {
                lblsNumeP[i] = new Label();
                lblsNumeP[i].Width = LATIME_CONTROL;
                lblsNumeP[i].Text = profesoriGasiti[i].Nume;
                lblsNumeP[i].Left = DIMENSIUNE_PAS_X;
                lblsNumeP[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsNumeP[i]);

                lblsEmail[i] = new Label();
                lblsEmail[i].Width = LATIME_CONTROL;
                lblsEmail[i].Text = profesoriGasiti[i].Email;
                lblsEmail[i].Left = 2 * DIMENSIUNE_PAS_X;
                lblsEmail[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsEmail[i]);

                lblsMaterii[i] = new Label();
                lblsMaterii[i].Width = LATIME_CONTROL;
                lblsMaterii[i].Text = string.Join(", ", profesoriGasiti[i].Materii);
                lblsMaterii[i].Left = 3 * DIMENSIUNE_PAS_X;
                lblsMaterii[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsMaterii[i]);

                lblsPunctaj[i] = new Label();
                lblsPunctaj[i].Width = LATIME_CONTROL;
                lblsPunctaj[i].Text = profesoriGasiti[i].Punctaj.ToString();
                lblsPunctaj[i].Left = 4 * DIMENSIUNE_PAS_X;
                lblsPunctaj[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsPunctaj[i]);
            }
        }
        private int GetPunctajSelectat()
        {

            for (int i = 0; i < radioButtonsPunctaj.Length; i++)
            {
                if (radioButtonsPunctaj[i] != null && radioButtonsPunctaj[i].Checked)
                {
                    return i + 1;
                }
            }

            return 0;
        }

    }
}
