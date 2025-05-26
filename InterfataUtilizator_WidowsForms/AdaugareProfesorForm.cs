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
    public partial class AdaugareProfesorForm: Form
    {
        private NivelStocareDate.AdministrareProfesori_FisierText adminProfesori;
        private Profesor profesorEditat = null;

        public AdaugareProfesorForm(NivelStocareDate.AdministrareProfesori_FisierText adminProfesori, Profesor profesor)
        {
            InitializeComponent();
            this.adminProfesori = adminProfesori;
            this.profesorEditat = profesor;
            this.Load += AdaugareProfesorForm_Load;

        }
        private void AdaugareProfesorForm_Load(object sender, EventArgs e)
        {
            eroarenume.Visible = false;
            eroareemail.Visible = false;
            eroarematerie.Visible = false;
            eroarepunctaj.Visible = false;

            if (profesorEditat != null)
            {
                textBoxNUME.Text = profesorEditat.Nume;
                textBoxEMAIL.Text = profesorEditat.Email;

                foreach (Control ctrl in panelMaterii.Controls)
                {
                    if (ctrl is CheckBox cb)
                        cb.Checked = profesorEditat.Materii.Any(m => string.Equals(m.ToString(), cb.Text, StringComparison.OrdinalIgnoreCase));
                }

                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is RadioButton rb)
                        rb.Checked = rb.Text == profesorEditat.Punctaj.ToString();
                }

                buttonADD.Text = "Salvează";
            }
            else
            {
                buttonADD.Text = "Adaugă";
            }
        }


        private void buttonADD_Click(object sender, EventArgs e)
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

            List<Materie> materiiSelectate = new List<Materie>();
            foreach (Control ctrl in panelMaterii.Controls)
            {
                if (ctrl is CheckBox cb && cb.Checked)
                {
                    if (Enum.TryParse(cb.Text, true, out Materie materie))
                        materiiSelectate.Add(materie);
                }
            }

            if (materiiSelectate.Count == 0)
            {
                eroarematerie.Visible = true;
                valid = false;
            }
            else
            {
                eroarematerie.Visible = false;
            }

            int punctaj = 0;
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is RadioButton rb && rb.Checked)
                {
                    int.TryParse(rb.Text, out punctaj);
                    break;
                }
            }
            if (punctaj == 0)
            {
                eroarepunctaj.Visible = true;
                valid = false;
            }
            else
            {
                eroarepunctaj.Visible = false;
            }

            if (valid)
            {
                string nume = textBoxNUME.Text.Trim();
                string email = textBoxEMAIL.Text.Trim();

                if (profesorEditat != null)
                {
                    string numeVechi = profesorEditat.Nume;
                    string emailVechi = profesorEditat.Email;

                    profesorEditat.Nume = nume;
                    profesorEditat.Email = email;
                    profesorEditat.Materii = materiiSelectate;
                    profesorEditat.Punctaj = punctaj;
                    adminProfesori.UpdateProfesor(profesorEditat, numeVechi, emailVechi);
                    MessageBox.Show("Profesor salvat!");
                }
                else
                {
                    var profesorNou = new Profesor(nume, email, materiiSelectate, punctaj);
                    adminProfesori.AddProfesor(profesorNou);
                    MessageBox.Show("Profesor adăugat cu succes!");
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }

        private void AdaugareProfesorForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
