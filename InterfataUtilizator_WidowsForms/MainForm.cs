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
        private Button btnProfesori;
        private Button btnElevi;

        public MainForm()
        {
            InitializeComponent();
            InitializeMeniu();
        }

        private void InitializeMeniu()
        {
            this.Text = "Meniu Principal";
            this.Size = new Size(600, 400);

            btnProfesori = new Button();
            btnProfesori.Text = "Profesori";
            btnProfesori.Font = new Font("Segoe UI", 16);
            btnProfesori.Size = new Size(200, 100);
            btnProfesori.Location = new Point(100, 100);
            btnProfesori.Click += BtnProfesori_Click;

            btnElevi = new Button();
            btnElevi.Text = "Elevi";
            btnElevi.Font = new Font("Segoe UI", 16);
            btnElevi.Size = new Size(200, 100);
            btnElevi.Location = new Point(320, 100);
            btnElevi.Click += BtnElevi_Click;

            this.Controls.Add(btnProfesori);
            this.Controls.Add(btnElevi);
        }

        private void BtnProfesori_Click(object sender, EventArgs e)
        {
            AscundeMeniul();
            Profesori formProfesori = new Profesori();
            formProfesori.FormClosed += (s, args) => this.Show(); 
            formProfesori.Show();
        }

        private void BtnElevi_Click(object sender, EventArgs e)
        {
            AscundeMeniul();
            Elevi formElevi = new Elevi();
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
