using PregatiriOnline;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NivelStocareDate
{
    public class AdministrareProfesoriElevi_FisierText
    {
        private string numeFisier;

        public AdministrareProfesoriElevi_FisierText(string numeFisier)
        {
            this.numeFisier = numeFisier;
            
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public void AddProfesor(Profesor profesor)
        {
            using (StreamWriter writer = new StreamWriter(numeFisier, true))
            {
                writer.WriteLine(profesor.Info());
            }
        }

        public void AddElev(Elev elev)
        {
            using (StreamWriter writer = new StreamWriter(numeFisier, true))
            {
                writer.WriteLine(elev.Info());
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
                        string materie = date[3];   
                        int punctaj = int.Parse(date[4]); 

                        
                        Profesor profesor = new Profesor(nume, email, materie, punctaj);

                        profesori.Add(profesor);
                        nrProfesori++;
                    }
                }
            }

            return profesori.ToArray();
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

                        string nume = date[1];       
                        string email = date[2];      
                        string clasa = date[3];      
                        int varsta = int.Parse(date[4]); 

                        
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
