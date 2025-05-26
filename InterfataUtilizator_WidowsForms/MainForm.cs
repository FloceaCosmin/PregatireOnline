using InterfataUtilizator_WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfataUtilizator_WindowsForms
{
    public partial class MainForm : Form
    {
        private Button btnProfesori_Elevi;
        private Button btnSesiuni;

        public MainForm()
        {
            InitializeComponent();
            InitializeMeniu();
        }

        private void InitializeMeniu()
        {
            this.Text = "Meniu Principal";
            this.Size = new Size(600, 400);

            btnProfesori_Elevi = new Button();
            btnProfesori_Elevi.Text = "Gestionare Profesori/Elevi";
            btnProfesori_Elevi.Font = new Font("Segoe UI", 16);
            btnProfesori_Elevi.Size = new Size(200, 100);
            btnProfesori_Elevi.Location = new Point(100, 100);
            btnProfesori_Elevi.Click += BtnProfesori_Click;

            btnSesiuni = new Button();
            btnSesiuni.Text = "Sesiuni de pregatire";
            btnSesiuni.Font = new Font("Segoe UI", 16);
            btnSesiuni.Size = new Size(200, 100);
            btnSesiuni.Location = new Point(320, 100);
            btnSesiuni.Click += BtnElevi_Click;

            this.Controls.Add(btnProfesori_Elevi);
            this.Controls.Add(btnSesiuni);
        }

        private void BtnProfesori_Click(object sender, EventArgs e)
        {
            AscundeMeniul();
            Profesori formProfesori = new Profesori();
            formProfesori.WindowState = FormWindowState.Normal;
            formProfesori.FormClosed += (s, args) => this.Show(); 
            formProfesori.Show();
        }

        private void BtnElevi_Click(object sender, EventArgs e)
        {
            AscundeMeniul();
            Sesiuni formElevi = new Sesiuni();
            formElevi.FormClosed += (s, args) => this.Show();
            formElevi.Show();
        }

        private void AscundeMeniul()
        {
            this.Hide();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Formularul a fost încărcat.");
        }
    }

}
