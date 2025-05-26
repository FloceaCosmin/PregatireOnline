using InterfataUtilizator_WidowsForms;
using Librarie;
using NivelStocareDate;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using RadioButton = System.Windows.Forms.RadioButton;

namespace InterfataUtilizator_WindowsForms
{
    public partial class Profesori : Form
    {
        AdministrareProfesori_FisierText adminProfesori;
        private AdministrareElevi_FisierText adminElevi;

        private Label lblAdminInfo;
        Administrator admin = new Administrator("Cosmin", "cosmin@yahoo.com");

        private Panel panelListaProfesori;
        private Panel panelAdaugareProfesor;
        private Panel panelCautareProfesor;

        private DataGridView dgvProfesori;
        private RadioButton rbCautaNume;
        private RadioButton rbCautaMaterie;
        private TextBox txtCautare;
        private Button btnAfiseazaRezultate;
        private Label lblCauta;
        private ListView listViewElevi;

        private ContextMenuStrip contextMenuProfesori;
        private int profesorIndexSelectat = -1;

        private string caleCompletaFisier1;
        private string caleCompletaFisier2;
        private ContextMenuStrip contextMenuElevi;
        private int elevIndexSelectat = -1;

        private Panel panelCautareElevi;
        private RadioButton rbCautareNumeElev;
        private RadioButton rbCautareVarstaElev;
        private RadioButton rbCautareClasaElev;
        private TextBox txtCautareElev;
        private Button btnAfiseazaRezultateElevi;

        public Profesori()
        {
            InitializeComponent();

            string numeFisier1 = ConfigurationManager.AppSettings["NumeFisier1"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            this.caleCompletaFisier1 = Path.Combine(locatieFisierSolutie, numeFisier1);
            string numeFisier2 = ConfigurationManager.AppSettings["NumeFisier2"];
            this.caleCompletaFisier2 = Path.Combine(locatieFisierSolutie, numeFisier2);
            adminElevi = new AdministrareElevi_FisierText(caleCompletaFisier2);

            dgvProfesori = new DataGridView
            {
                Location = new Point(150, 50),
                Size = new Size(400, 350),
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            this.Controls.Add(dgvProfesori);

            dgvProfesori.EnableHeadersVisualStyles = false;
            dgvProfesori.ColumnHeadersDefaultCellStyle.BackColor = Color.MediumSlateBlue;
            dgvProfesori.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvProfesori.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11, FontStyle.Bold);

            dgvProfesori.DefaultCellStyle.BackColor = Color.White;
            dgvProfesori.DefaultCellStyle.ForeColor = Color.Navy;
            dgvProfesori.DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Regular);

            dgvProfesori.AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender;

            dgvProfesori.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvProfesori.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvProfesori.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProfesori.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            contextMenuProfesori = new ContextMenuStrip();
            contextMenuProfesori.Items.Add("Editare", null, ContextMenu_Editare_Click);
            contextMenuProfesori.Items.Add("Ștergere", null, ContextMenu_Stergere_Click);
            dgvProfesori.ContextMenuStrip = contextMenuProfesori;

            // Selectează rândul la click dreapta
            dgvProfesori.MouseDown += DgvProfesori_MouseDown;

            listViewElevi = new ListView
            {
                Location = new Point(150, 50),
                Size = new Size(600, 350),
                View = View.Details,
                FullRowSelect = true,
                GridLines = true
            };
            listViewElevi.Columns.Add("Nume", 150);
            listViewElevi.Columns.Add("Email", 200);
            listViewElevi.Columns.Add("Clasa", 80);
            listViewElevi.Columns.Add("Vârstă", 80);
            listViewElevi.Visible = false;
            this.Controls.Add(listViewElevi);

            contextMenuElevi = new ContextMenuStrip();
            contextMenuElevi.Items.Add("Editare",null, ContextMenu_EditareElev_Click);
            contextMenuElevi.Items.Add("Ștergere", null, ContextMenu_StergereElev_Click);

            listViewElevi.ContextMenuStrip = contextMenuElevi;
            listViewElevi.MouseDown += ListViewElevi_MouseDown;

           

            Panel panelMeniu = new Panel
            {
                Width = 150,
                Height = this.ClientSize.Height,
                BackColor = Color.CadetBlue,
                Dock = DockStyle.Left,
                Text = "Meniu"
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

            adminProfesori = new AdministrareProfesori_FisierText(caleCompletaFisier1);

            int nrProfesori = 0;

            Profesor[] profesori = adminProfesori.GetProfesori(out nrProfesori);

            this.Size = new Size(1000, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Arial", 10, FontStyle.Bold);
            this.ForeColor = Color.Navy;
            this.Text = "Informatii profesori";

            dgvProfesori.Visible = false;

            panelCautareElevi = new Panel
            {
                Location = new Point(200, 30),
                Size = new Size(500, 120),
                Visible = false
            };


            this.Controls.Add(lblCauta);

            rbCautareNumeElev = new RadioButton
            {
                Text = "Nume",
                Location = new Point(10, 10),
                Width = 80,
                Checked = true
            };
            panelCautareElevi.Controls.Add(rbCautareNumeElev);

            rbCautareVarstaElev = new RadioButton
            {
                Text = "Vârstă",
                Location = new Point(100, 10),
                Width = 80
            };
            panelCautareElevi.Controls.Add(rbCautareVarstaElev);

            rbCautareClasaElev = new RadioButton
            {
                Text = "Clasă",
                Location = new Point(190, 10),
                Width = 80
            };
            panelCautareElevi.Controls.Add(rbCautareClasaElev);

            txtCautareElev = new TextBox
            {
                Location = new Point(10, 50),
                Width = 200
            };
            panelCautareElevi.Controls.Add(txtCautareElev);

            btnAfiseazaRezultateElevi = new Button
            {
                Text = "Caută elevi",
                Location = new Point(230, 48),
                Width = 120
            };
            btnAfiseazaRezultateElevi.Click += BtnAfiseazaRezultateElevi_Click;
            panelCautareElevi.Controls.Add(btnAfiseazaRezultateElevi);

            this.Controls.Add(panelCautareElevi);
        }

        private void Profesori_Load(object sender, EventArgs e)
        {
            AfiseazaProfesori();
            AdaugaInfoAdministrator(admin);
            if (listViewElevi != null) listViewElevi.Visible = false;
            panelCautareElevi.Visible = false;
        }

        private void AdaugaInfoAdministrator(Administrator admin)
        {
            lblAdminInfo = new Label
            {
                Text = admin.Info(),
                Left = this.ClientSize.Width - 300,
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
            AscundeFormularCautare();
            panelCautareElevi.Visible = false;
            if (listViewElevi != null) listViewElevi.Visible = false;
            Profesor[] profesori = adminProfesori.GetProfesori(out int nrProfesori);

            var listaAfisare = profesori.Select(p => new
            {
                Nume = p.Nume,
                Email = p.Email,
                Materii = string.Join(", ", p.Materii),
                Punctaj = p.Punctaj
            }).ToList();

            dgvProfesori.DataSource = null;
            dgvProfesori.DataSource = listaAfisare;

            dgvProfesori.AutoResizeColumns();
            dgvProfesori.AutoResizeRows();

            int totalWidth = dgvProfesori.RowHeadersWidth;
            foreach (DataGridViewColumn col in dgvProfesori.Columns)
                totalWidth += col.Width;

            int totalHeight = dgvProfesori.ColumnHeadersHeight;
            foreach (DataGridViewRow row in dgvProfesori.Rows)
                totalHeight += row.Height;

            int maxWidth = this.ClientSize.Width - dgvProfesori.Left - 20;
            int maxHeight = this.ClientSize.Height - dgvProfesori.Top - 20;
            dgvProfesori.Width = Math.Min(totalWidth + 2, maxWidth);
            dgvProfesori.Height = Math.Min(totalHeight + 2, maxHeight);
        }

        private void AfiseazaElevi()
        {
            int nrElevi;
            Elev[] elevi = adminElevi.GetElevi(out nrElevi);
            AscundeFormularCautare();
            panelCautareElevi.Visible = false;

            listViewElevi.Items.Clear();
            foreach (var e in elevi)
            {
                var item = new ListViewItem(e.Nume);
                item.SubItems.Add(e.Email);
                item.SubItems.Add(e.Clasa.ToString());
                item.SubItems.Add(e.Varsta.ToString());
                listViewElevi.Items.Add(item);
            }
            listViewElevi.Visible = true;
            dgvProfesori.Visible = false;
        }

        private void btnlistaElevi_Click(object sender, EventArgs e)
        {
            AscundeFormularCautare();
            dgvProfesori.Visible = false;
            AfiseazaElevi();
            panelCautareElevi.Visible = false;
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        private void btnListaProfesori_Click(object sender, EventArgs e)
        {
            dgvProfesori.Visible = true;
            AfiseazaProfesori();
            AscundeFormularCautare();
            panelCautareElevi.Visible = false;
        }

        private void btnaddProf_Click(object sender, EventArgs e)
        {
            if (listViewElevi != null) listViewElevi.Visible = false;
            AscundeFormularCautare();
            panelCautareElevi.Visible = false;

            var frm = new AdaugareProfesorForm(adminProfesori, null);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                AfiseazaProfesori();
            }
        }

        private void btncautare_Click(object sender, EventArgs e)
        {
            if (listViewElevi != null) listViewElevi.Visible = false;
            dgvProfesori.Visible = false;
            panelCautareElevi.Visible = false;


            if (rbCautaNume == null)
            {
                lblCauta = new Label
                {
                    Text = "Caută după:",
                    Left = 350,
                    Top = 60,
                    Width = 100
                };
                this.Controls.Add(lblCauta);

                rbCautaMaterie = new RadioButton
                {
                    Text = "Materie",
                    Left = 350,
                    Top = lblCauta.Bottom + 5,
                    Width = 80,
                    Checked = true
                };
                this.Controls.Add(rbCautaMaterie);

                rbCautaNume = new RadioButton
                {
                    Text = "Nume",
                    Left = rbCautaMaterie.Right + 20,
                    Top = lblCauta.Bottom + 5,
                    Width = 80
                };
                this.Controls.Add(rbCautaNume);

                txtCautare = new TextBox
                {
                    Left = 350,
                    Top = rbCautaMaterie.Bottom + 10,
                    Width = 200
                };
                this.Controls.Add(txtCautare);

                btnAfiseazaRezultate = new Button
                {
                    Text = "Afișează profesori",
                    Left = txtCautare.Right + 20,
                    Top = txtCautare.Top,
                    Width = 140
                };
                btnAfiseazaRezultate.Click += BtnAfiseazaRezultate_Click;
                this.Controls.Add(btnAfiseazaRezultate);
            }
            else
            {
                lblCauta.Visible = true;
                rbCautaMaterie.Visible = true;
                rbCautaNume.Visible = true;
                txtCautare.Visible = true;
                btnAfiseazaRezultate.Visible = true;
            }

            int dgvTop = btnAfiseazaRezultate.Bottom + 20;
            dgvProfesori.Left = 200;
            dgvProfesori.Top = dgvTop;
            dgvProfesori.Width = 700;
            dgvProfesori.Height = this.ClientSize.Height - dgvTop - 40;
        }

        private void BtnAfiseazaRezultate_Click(object sender, EventArgs e)
        {
            if (listViewElevi != null) listViewElevi.Visible = false;
            string criteriu = txtCautare.Text.Trim();

            Profesor[] totiProfesorii = adminProfesori.GetProfesori(out int nrProfesori);
            List<Profesor> profesoriGasiti = new List<Profesor>();

            if (rbCautaMaterie.Checked)
            {
                foreach (var profesor in totiProfesorii)
                {
                    if (profesor.Materii.Any(m => m.ToString().ToLower().Contains(criteriu.ToLower())))
                    {
                        profesoriGasiti.Add(profesor);
                    }
                }
            }
            else
            {
                foreach (var profesor in totiProfesorii)
                {
                    if (profesor.Nume.ToLower().Contains(criteriu.ToLower()))
                    {
                        profesoriGasiti.Add(profesor);
                    }
                }
            }

            if (profesoriGasiti.Count == 0)
            {
                MessageBox.Show("Nu s-a găsit niciun profesor cu acest criteriu.");
                return;
            }

            // Afișează rezultatele în DataGridView
            dgvProfesori.Visible = true;
            dgvProfesori.DataSource = profesoriGasiti.Select(p => new
            {
                Nume = p.Nume,
                Email = p.Email,
                Materii = string.Join(", ", p.Materii),
                Punctaj = p.Punctaj
            }).ToList();

            // Elimină border și header de rânduri
            dgvProfesori.BorderStyle = BorderStyle.None;
            dgvProfesori.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProfesori.RowHeadersVisible = false;

            // Redimensionează coloanele la conținut
            dgvProfesori.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvProfesori.AutoResizeColumns();
            dgvProfesori.AutoResizeRows();

            // Oprește auto-size ca să poți calcula lățimea exactă
            dgvProfesori.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            // Calculează lățimea totală
            int totalWidth = 0;
            foreach (DataGridViewColumn col in dgvProfesori.Columns)
                totalWidth += col.Width;
            dgvProfesori.Width = totalWidth + 2; // +2 pentru a evita scroll bar-ul vertical

            // Calculează înălțimea totală
            int totalHeight = dgvProfesori.ColumnHeadersHeight;
            foreach (DataGridViewRow row in dgvProfesori.Rows)
                totalHeight += row.Height;
            dgvProfesori.Height = totalHeight + 2;

            // Centrează DataGridView-ul
            dgvProfesori.Left = (this.ClientSize.Width - dgvProfesori.Width) / 2;
            dgvProfesori.Top = btnAfiseazaRezultate.Bottom + 20;
        }

        private void DgvProfesori_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = dgvProfesori.HitTest(e.X, e.Y);
                if (hit.RowIndex >= 0)
                {
                    dgvProfesori.ClearSelection();
                    dgvProfesori.Rows[hit.RowIndex].Selected = true;
                    profesorIndexSelectat = hit.RowIndex;
                }
                else
                {
                    profesorIndexSelectat = -1;
                }
            }
        }


        private void ListViewElevi_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var item = listViewElevi.GetItemAt(e.X, e.Y);
                if (item != null)
                {
                    item.Selected = true;
                    elevIndexSelectat = item.Index;
                }
                else
                {
                    listViewElevi.SelectedItems.Clear();
                    elevIndexSelectat = -1;
                }
            }
        }


        private void ContextMenu_Editare_Click(object sender, EventArgs e)
        {
            if (profesorIndexSelectat < 0) return;

            var profesori = adminProfesori.GetProfesori(out int nrProfesori);
            if (profesorIndexSelectat >= profesori.Length) return;
            var profesor = profesori[profesorIndexSelectat];

            var frm = new AdaugareProfesorForm(adminProfesori, profesor);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                AfiseazaProfesori();
            }
        }

        private void ContextMenu_Stergere_Click(object sender, EventArgs e)
        {
            if (profesorIndexSelectat < 0) return;

            var profesori = adminProfesori.GetProfesori(out int nrProfesori);
            if (profesorIndexSelectat >= profesori.Length) return;
            var profesor = profesori[profesorIndexSelectat];

            var confirm = MessageBox.Show($"Sigur vrei să ștergi profesorul {profesor.Nume}?", "Confirmare ștergere", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                var lista = profesori.ToList();
                lista.RemoveAt(profesorIndexSelectat);
                File.WriteAllLines(caleCompletaFisier1, lista.Select(p => p.ScrieInFisier()));
                AfiseazaProfesori();
                dgvProfesori.Visible = true;
            }
        }

        private void AscundeFormularCautare()
        {
            if (lblCauta != null) lblCauta.Visible = false;
            if (rbCautaMaterie != null) rbCautaMaterie.Visible = false;
            if (rbCautaNume != null) rbCautaNume.Visible = false;
            if (txtCautare != null) txtCautare.Visible = false;
            if (btnAfiseazaRezultate != null) btnAfiseazaRezultate.Visible = false;
        }

        private void ContextMenu_StergereElev_Click(object sender, EventArgs e)
        {
            if (elevIndexSelectat < 0) return;

            int nrElevi;
            var elevi = adminElevi.GetElevi(out nrElevi);
            if (elevIndexSelectat >= elevi.Length) return;
            var elev = elevi[elevIndexSelectat];

            var confirm = MessageBox.Show($"Sigur vrei să ștergi elevul {elev.Nume}?", "Confirmare ștergere", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                var lista = elevi.ToList();
                lista.RemoveAt(elevIndexSelectat);
                File.WriteAllLines(caleCompletaFisier2, lista.Select(el => el.ScrieInFisier()));
                AfiseazaElevi();
                listViewElevi.Visible = true;


            }
        }

        private void buttonAddelevi_Click(object sender, EventArgs e)
        {
            var frm = new AdaugareElevForm(adminElevi, null);
            AscundeFormularCautare();
            panelCautareElevi.Visible = false;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                AfiseazaElevi();
            }

        }
        private void ContextMenu_EditareElev_Click(object sender, EventArgs e)
        {
            if (elevIndexSelectat < 0) return;

            int nrElevi;
            var elevi = adminElevi.GetElevi(out nrElevi);
            if (elevIndexSelectat >= elevi.Length) return;
            var elev = elevi[elevIndexSelectat];

            var frm = new AdaugareElevForm(adminElevi, elev);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                AfiseazaElevi();
            }
        }

        private void BtnAfiseazaRezultateElevi_Click(object sender, EventArgs e)
        {
            string criteriu = txtCautareElev.Text.Trim();
            AscundeFormularCautare();
            panelCautareElevi.Visible = false;
            if (string.IsNullOrEmpty(criteriu))
            {
                MessageBox.Show("Introduceți un criteriu de căutare!");
                return;
            }

            int nrElevi;
            Elev[] elevi = adminElevi.GetElevi(out nrElevi);
            List<Elev> eleviGasiti = new List<Elev>();

            if (rbCautareNumeElev.Checked)
            {
                eleviGasiti = elevi.Where(el => el.Nume.IndexOf(criteriu, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }
            else if (rbCautareVarstaElev.Checked)
            {
                if (int.TryParse(criteriu, out int varstaCautata))
                    eleviGasiti = elevi.Where(el => el.Varsta == varstaCautata).ToList();
                else
                {
                    MessageBox.Show("Introduceți o vârstă validă!");
                    return;
                }
            }
            else if (rbCautareClasaElev.Checked)
            {
                eleviGasiti = elevi.Where(el => el.Clasa.ToString().Equals(criteriu, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            if (eleviGasiti.Count == 0)
            {
                MessageBox.Show("Nu s-a găsit niciun elev cu acest criteriu.");
                return;
            }

            // Afișează rezultatele în ListView
            listViewElevi.Items.Clear();
            foreach (var el in eleviGasiti)
            {
                var item = new ListViewItem(el.Nume);
                item.SubItems.Add(el.Email);
                item.SubItems.Add(el.Clasa.ToString());
                item.SubItems.Add(el.Varsta.ToString());
                listViewElevi.Items.Add(item);
            }
            listViewElevi.Visible = true;
            dgvProfesori.Visible = false;
            panelCautareElevi.Visible = false;
        }

        private void buttonCautareElevi_Click(object sender, EventArgs e)
        {
            dgvProfesori.Visible = false;
            if (listViewElevi != null) listViewElevi.Visible = false;
            panelCautareElevi.Visible = true;
            AscundeFormularCautare();
        }
    }
}
