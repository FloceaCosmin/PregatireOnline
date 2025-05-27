using Librarie;
using NivelStocareDate;
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
    public partial class AdaugareSesiune : Form
    {
        private AdministrareSesiuni_FisierText adminSesiuni;

        public AdaugareSesiune(AdministrareSesiuni_FisierText adminSesiuni)
        {
            InitializeComponent();
            this.adminSesiuni = adminSesiuni;
        }

        private void btAddSesiune_Click(object sender, EventArgs e)
        {
            bool valid = true;

            if (string.IsNullOrWhiteSpace(tboxProfesor.Text))
            {
                MessageBox.Show("Introduceți numele profesorului!");
                valid = false;
            }

            Materie materieSelectata = Materie.Nimic;
            if (radioButtonMS.Checked) materieSelectata = Materie.Matematica;
            else if (radioButtonRS.Checked) materieSelectata = Materie.Romana;
            else if (radioButtonIS.Checked) materieSelectata = Materie.Informatica;
            else if (radioButtonBS.Checked) materieSelectata = Materie.Biologie;
            else if (radioButtonCS.Checked) materieSelectata = Materie.Chimie;
            else
            {
                MessageBox.Show("Selectați o materie!");
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(txtBoxLink.Text))
            {
                MessageBox.Show("Introduceți link-ul sesiunii!");
                valid = false;
            }

            if (valid)
            {
                string numeProfesor = tboxProfesor.Text.Trim();
                string link = txtBoxLink.Text.Trim();
                DateTime dataSesiune = dateTimePicker1.Value;

                Sesiune sesiuneNoua = new Sesiune(materieSelectata, numeProfesor, link, dataSesiune);
                adminSesiuni.AddSesiune(sesiuneNoua);

                MessageBox.Show("Sesiune adăugată cu succes!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }

        private void AdaugareSesiune_Load(object sender, EventArgs e)
        {

        }
    }
}
