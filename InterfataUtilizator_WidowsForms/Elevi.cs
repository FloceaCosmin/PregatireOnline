using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Librarie;
using NivelStocareDate;

namespace InterfataUtilizator_WindowsForms
{
    public partial class Elevi : Form
    {
        AdministrareElevi_FisierText adminElevi;

        
        private Label lblNume;
        private Label lblEmail;
        private Label lblClasa;
        private Label lblVarsta;
        private Label lblAdminInfo;

        private Label[] lblsNumeE;
        private Label[] lblsEmail;
        private Label[] lblsClasa;
        private Label[] lblsVarsta;

        private const int LATIME_CONTROL = 150;
        private const int DIMENSIUNE_PAS_Y = 30;
        private const int DIMENSIUNE_PAS_X = 150;

        public Elevi()
        {
            InitializeComponent();

            Administrator admin = new Administrator("Cosmin", "cosmin@yahoo.com");

            string numeFisier2 = ConfigurationManager.AppSettings["NumeFisier2"];
            string locatieFisierSolutie = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier2;

            adminElevi = new AdministrareElevi_FisierText(caleCompletaFisier);
            int nrElevi = 0;

            Elev[] elevi = adminElevi.GetElevi(out nrElevi);

            this.Size = new Size(900, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Arial", 10, FontStyle.Bold);
            this.ForeColor = Color.DarkSlateBlue;
            this.Text = "Informații Elevi";

            
            AdaugaEticheteColoane();

            AdaugaInfoAdministrator(admin);
        }

        private void Elevi_Load(object sender, EventArgs e)
        {
            AfiseazaElevi();
        }

        private void AdaugaEticheteColoane()
        {
            // Nume Elev
            lblNume = new Label
            {
                Width = LATIME_CONTROL,
                Text = "Nume Elev",
                Left = DIMENSIUNE_PAS_X,
                Top = 10,
                BackColor = Color.DarkCyan,
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 12, FontStyle.Bold),
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(lblNume);

            // Email
            lblEmail = new Label
            {
                Width = LATIME_CONTROL,
                Text = "Email",
                Left = 2 * DIMENSIUNE_PAS_X,
                Top = 10,
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 12, FontStyle.Bold),
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(lblEmail);

            // Clasa
            lblClasa = new Label
            {
                Width = LATIME_CONTROL,
                Text = "Clasa",
                Left = 3 * DIMENSIUNE_PAS_X,
                Top = 10,
                BackColor = Color.Orange,
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 12, FontStyle.Bold),
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(lblClasa);

            // Vârstă
            lblVarsta = new Label
            {
                Width = LATIME_CONTROL,
                Text = "Vârstă",
                Left = 4 * DIMENSIUNE_PAS_X,
                Top = 10,
                BackColor = Color.Purple,
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 12, FontStyle.Bold),
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(lblVarsta);
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



        private void AfiseazaElevi()
        {
            Elev[] elevi = adminElevi.GetElevi(out int nrElevi);


            lblsNumeE = new Label[nrElevi];
            lblsEmail = new Label[nrElevi];
            lblsClasa = new Label[nrElevi];
            lblsVarsta = new Label[nrElevi];

            for (int i = 0; i < nrElevi; i++)
            {


                // Nume Elev
                lblsNumeE[i] = new Label
                {
                    Width = LATIME_CONTROL,
                    Text = elevi[i].Nume,
                    Left = DIMENSIUNE_PAS_X,
                    Top = (i + 1) * DIMENSIUNE_PAS_Y
                };
                this.Controls.Add(lblsNumeE[i]);

                // Email
                lblsEmail[i] = new Label
                {
                    Width = LATIME_CONTROL,
                    Text = elevi[i].Email,
                    Left = 2 * DIMENSIUNE_PAS_X,
                    Top = (i + 1) * DIMENSIUNE_PAS_Y
                };
                this.Controls.Add(lblsEmail[i]);

                // Clasa
                lblsClasa[i] = new Label
                {
                    Width = LATIME_CONTROL,
                    Text = elevi[i].Clasa.ToString(),
                    Left = 3 * DIMENSIUNE_PAS_X,
                    Top = (i + 1) * DIMENSIUNE_PAS_Y
                };
                this.Controls.Add(lblsClasa[i]);

                // Varsta
                lblsVarsta[i] = new Label
                {
                    Width = LATIME_CONTROL,
                    Text = elevi[i].Varsta.ToString(),
                    Left = 4 * DIMENSIUNE_PAS_X,
                    Top = (i + 1) * DIMENSIUNE_PAS_Y
                };
                this.Controls.Add(lblsVarsta[i]);

            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
