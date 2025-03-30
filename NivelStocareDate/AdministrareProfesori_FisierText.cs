using System;
using System.Collections.Generic;
using System.IO;
using Librarie;
using PregatiriOnline;

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

                    if (linie.StartsWith("Profesor"))
                    {

                        var date = linie.Split(',');
                        string nume = date[1];
                        string email = date[2];
                        Materie materie = (Materie)Enum.Parse(typeof(Materie), date[3]);
                        int punctaj = int.Parse(date[4]);


                        Profesor profesor = new Profesor(nume, email, materie, punctaj);

                        profesori.Add(profesor);
                        nrProfesori++;
                    }
                }
            }

            return profesori.ToArray();
        }

    }
}
