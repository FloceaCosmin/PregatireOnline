using System;
using System.Collections.Generic;
using System.IO;
using Librarie;

namespace NivelStocareDate
{
    public class AdministrareProfesori_FisierText
    {
        private string numeFisier;

        public AdministrareProfesori_FisierText(string numeFisier)
        {
            this.numeFisier = numeFisier;
            if (!File.Exists(numeFisier))
            {
                File.Create(numeFisier).Close();
            }
        }

        public void AddProfesor(Profesor profesor)
        {
            using (StreamWriter sw = new StreamWriter(numeFisier, true))
            {
                sw.WriteLine(profesor.ScrieInFisier());
            }
        }

        public Profesor[] GetProfesori(out int nrProfesori)
        {
            List<Profesor> profesori = new List<Profesor>();
            nrProfesori = 0;

            using (StreamReader reader = new StreamReader(numeFisier))
            {
                string linie;
                while ((linie = reader.ReadLine()) != null)
                {
                    var date = linie.Split(';');
                    string nume = date[0];
                    string email = date[1];

                    List<Materie> materii = new List<Materie>();
                    string[] materiiText = date[2].Split('|');
                    foreach (var materieText in materiiText)
                    {
                        if (!string.IsNullOrWhiteSpace(materieText))
                        {
                            materii.Add((Materie)Enum.Parse(typeof(Materie), materieText.Trim()));
                        }
                    }

                    int punctaj = int.Parse(date[3]);

                    Profesor profesor = new Profesor(nume, email, materii, punctaj);
                    profesori.Add(profesor);
                    nrProfesori++;
                }
            }

            return profesori.ToArray();
        }

        public void UpdateProfesor(Profesor profesorActualizat)
        {
            Profesor[] profesori = GetProfesori(out int nrProfesori);

            for (int i = 0; i < nrProfesori; i++)
            {
                if (profesori[i].Email == profesorActualizat.Email)
                {
                    profesori[i] = profesorActualizat;
                    break;
                }
            }

            
            using (StreamWriter writer = new StreamWriter(numeFisier, false))
            {
                foreach (var profesor in profesori)
                {
                    writer.WriteLine(profesor.ScrieInFisier());
                }
            }
        }



    }
}
