using Librarie;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NivelStocareDate
{
    public class AdministrareSesiuni_FisierText
    {
        private string numeFisier;

        public AdministrareSesiuni_FisierText(string numeFisier)
        {
            this.numeFisier = numeFisier;
            if (!File.Exists(numeFisier))
            {
                File.Create(numeFisier).Close();
            }
        }

        public void AddSesiune(Sesiune sesiune)
        {
            using (StreamWriter sw = new StreamWriter(numeFisier, true))
            {
                sw.WriteLine(sesiune.ScrieInFisier());
            }
        }

        public Sesiune[] GetSesiuni(out int nrSesiuni)
        {
            List<Sesiune> sesiuni = new List<Sesiune>();
            nrSesiuni = 0;

            using (StreamReader sr = new StreamReader(numeFisier))
            {
                string linie;
                while ((linie = sr.ReadLine()) != null)
                {
                    Sesiune sesiune = Sesiune.CitesteDinLinie(linie);
                    sesiuni.Add(sesiune);
                    nrSesiuni++;
                }
            }

            return sesiuni.ToArray();
        }

        public void UpdateSesiune(Sesiune sesiuneActualizata, Materie materieVeche, string numeProfesorVechi, DateTime dataVeche)
        {
            int nrSesiuni;
            var sesiuni = GetSesiuni(out nrSesiuni).ToList();
            int index = sesiuni.FindIndex(s =>
                s.Materie == materieVeche &&
                s.NumeProfesor == numeProfesorVechi &&
                s.Data == dataVeche);
            if (index != -1)
            {
                sesiuni[index] = sesiuneActualizata;
                File.WriteAllLines(numeFisier, sesiuni.ConvertAll(s => s.ScrieInFisier()));
            }
        }
        public void StergeSesiune(Materie materie, string numeProfesor, DateTime data)
        {
            int nrSesiuni;
            var sesiuni = GetSesiuni(out nrSesiuni).ToList();
            sesiuni.RemoveAll(s =>
                s.Materie == materie &&
                s.NumeProfesor == numeProfesor &&
                s.Data == data);

            File.WriteAllLines(numeFisier, sesiuni.ConvertAll(s => s.ScrieInFisier()));
        }
    }
}