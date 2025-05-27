using InterfataUtilizator_WindowsForms;
using Librarie;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfataUtilizator_WidowsForms
{
    public partial class AdaugareElevForm : Form
    {
        private NivelStocareDate.AdministrareElevi_FisierText adminElevi;
        private Elev elevEditat = null;
        public AdaugareElevForm(NivelStocareDate.AdministrareElevi_FisierText adminElevi, Elev elev)
        {
            InitializeComponent();
            this.adminElevi = adminElevi;
            this.elevEditat = elev;
        }

        private void AdaugareElevForm_Load(object sender, EventArgs e)
        {
            eroarenume.Visible = false;
            eroareemail.Visible = false;
            eroareCLASA.Visible = false;
            eroareVARSTA.Visible = false;
            if (elevEditat != null)
            {
                textBoxNUME.Text = elevEditat.Nume;
                textBoxEMAIL.Text = elevEditat.Email;

                foreach (Control ctrl in panelCLASA.Controls)
                {
                    if (ctrl is RadioButton rb && rb.Text == elevEditat.Clasa.ToString())
                        rb.Checked = true;
                }

                foreach (Control ctrl in panelVARSTA.Controls)
                {
                    if (ctrl is RadioButton rb && rb.Text == elevEditat.Varsta.ToString())
                        rb.Checked = true;
                }

                buttonADDelev.Text = "Salvează";
            }
            else
            {
                buttonADDelev.Text = "Adaugă";
            }
        }

        private void buttonADDelev_Click(object sender, EventArgs e)
        {
            bool valid = true;
            if (string.IsNullOrWhiteSpace(textBoxNUME.Text) || textBoxNUME.Text.Length < 3)
            {
                eroarenume.Visible = true;
                valid = false;
            }
            else
            {
                eroarenume.Visible = false;
            }

            if (string.IsNullOrWhiteSpace(textBoxEMAIL.Text) || !textBoxEMAIL.Text.Contains("@"))
            {
                eroareemail.Visible = true;
                valid = false;
            }
            else
            {
                eroareemail.Visible = false;
            }

            string clasaSelectata = null;
            foreach (Control ctrl in panelCLASA.Controls)
            {
                if (ctrl is RadioButton rb && rb.Checked)
                {
                    clasaSelectata = rb.Text;
                    break;
                }
            }
            if (string.IsNullOrEmpty(clasaSelectata))
            {
                eroareCLASA.Visible = true;
                valid = false;
            }
            else
            {
                eroareCLASA.Visible = false;
            }

            int varstaSelectata = 0;
            foreach (Control ctrl in panelVARSTA.Controls)
            {
                if (ctrl is RadioButton cb && cb.Checked)
                {
                    int.TryParse(cb.Text, out varstaSelectata);

                    break;
                }
            }
            if (varstaSelectata == 0)
            {
                eroareVARSTA.Visible = true;
                valid = false;
            }
            else
            {
                eroareVARSTA.Visible = false;
            }

            if (valid)
            {
                string nume = textBoxNUME.Text.Trim();
                string email = textBoxEMAIL.Text.Trim();
                Clase clasa = (Clase)Enum.Parse(typeof(Clase), clasaSelectata);

                if (elevEditat != null)
                {
                    string numeVechi = elevEditat.Nume;
                    string emailVechi = elevEditat.Email;

                    elevEditat.Nume = nume;
                    elevEditat.Email = email;
                    elevEditat.Clasa = clasa;
                    elevEditat.Varsta = varstaSelectata;

                    adminElevi.UpdateElevi(elevEditat, numeVechi, emailVechi);
                    MessageBox.Show("Elev modificat cu succes!");
                }
                else
                {
                    Elev elevNou = new Elev(nume, email, clasa, varstaSelectata);
                    adminElevi.AddElev(elevNou);
                    MessageBox.Show("Elev adăugat cu succes!");
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }


    }
}
