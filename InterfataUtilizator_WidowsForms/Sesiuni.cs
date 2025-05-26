using InterfataUtilizator_WidowsForms;
using Librarie;
using NivelStocareDate;
using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace InterfataUtilizator_WindowsForms
{
    public partial class Sesiuni : Form
    {
        private Label lblAdminInfo;
        private ListView listViewSesiuni;
        private AdministrareSesiuni_FisierText adminSesiuni;

        public Sesiuni()
        {
            InitializeComponent();
            listViewSesiuni = new ListView
            {
                Location = new Point(150, 50),
                Size = new Size(800, 350),
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                Visible = false
            };

            listViewSesiuni.Columns.Add("Materie", 150);
            listViewSesiuni.Columns.Add("Profesor", 150);
            listViewSesiuni.Columns.Add("Link", 350);
            listViewSesiuni.Columns.Add("Data și Ora", 200);

            AscundeControale();

            this.Controls.Add(listViewSesiuni);

            Administrator admin = new Administrator("Cosmin", "cosmin@yahoo.com");

            string locatieFisierSolutie = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

            
            string filePath = Path.Combine(locatieFisierSolutie, "sesiuni.txt");
            adminSesiuni = new AdministrareSesiuni_FisierText(filePath);

            AdaugaInfoAdministrator(admin);
        }

        private void Sesiuni_Load(object sender, EventArgs e)
        {

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

        private void btnListSes_Click(object sender, EventArgs e)
        {
            int nrSesiuni;
            Sesiune[] sesiuni = adminSesiuni.GetSesiuni(out nrSesiuni);

            listViewSesiuni.Items.Clear();
            foreach (var s in sesiuni)
            {
                var item = new ListViewItem(s.Materie.ToString());
                item.SubItems.Add(s.NumeProfesor);
                item.SubItems.Add(s.Link);
                item.SubItems.Add(s.Data.ToString("dd.MM.yyyy HH:mm"));
                listViewSesiuni.Items.Add(item);
            }

            listViewSesiuni.Visible = true;

        }

        private void btnAddSes_Click(object sender, EventArgs e)
        {
            if (listViewSesiuni != null)
                listViewSesiuni.Visible = false;

            // Creează și afișează formularul de adăugare sesiune
            var frmAdaugareSesiune = new AdaugareSesiune(adminSesiuni);
            if (frmAdaugareSesiune.ShowDialog() == DialogResult.OK)
            {
                // Reîmprospătează lista de sesiuni după adăugare
                if (listViewSesiuni != null && listViewSesiuni.Visible)
                    btnListSes_Click(sender, e);
            }

        }

        private void btnBACK_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();

        }

        private void AscundeControale()
        {
            if (listViewSesiuni != null)
                listViewSesiuni.Visible = false;
        }
    }
}
