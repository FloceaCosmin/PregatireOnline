using System;
using System.Collections.Generic;
using System.IO;
using Librarie;
using PregatiriOnline;

namespace NivelStocareDate
{
    public class AdministrareElevi_FisierText
    {
        private string numeFisier;

        public AdministrareElevi_FisierText(string numeFisier)
        {
            this.numeFisier = numeFisier;
            if (!File.Exists(numeFisier))
            {
                File.Create(numeFisier).Close();
            }
        }

        public void AddElev(Elev elev)
        {
            using (StreamWriter sw = new StreamWriter(numeFisier, true))
            {
                sw.WriteLine(elev.ScrieInFisier());
            }
        }

        public Elev[] GetElevi(out int nrElevi)
        {
            List<Elev> elevi = new List<Elev>();
            nrElevi = 0;

            using (StreamReader reader = new StreamReader(numeFisier))
            {
                string linie;
                while ((linie = reader.ReadLine()) != null)
                {

                    if (linie.StartsWith("Elev"))
                    {

                        var date = linie.Split(',');

                        if (date.Length < 5)
                        {
                            Console.WriteLine($" Linia este invalidă: {linie}");
                            continue;
                        }

                        string nume = date[0];
                        string email = date[1];
                        Clase clasa = (Clase)Enum.Parse(typeof(Clase), date[2]);
                        int varsta = int.Parse(date[3]);


                        Elev elev = new Elev(nume, email, clasa, varsta);

                        elevi.Add(elev);
                        nrElevi++;
                    }
                }
            }

            return elevi.ToArray();
        }
    }
}

