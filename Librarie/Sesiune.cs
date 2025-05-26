using System;

namespace Librarie
{
    public class Sesiune
    {
        public Materie Materie { get; set; }
        public string NumeProfesor { get; set; }

        public string Link { get; set; }
        public DateTime Data { get; set; }

        public Sesiune(Materie materie, string numeProfesor, string link, DateTime data)
        {
            this.Materie = materie;
            this.NumeProfesor = numeProfesor;
            this.Link = link;
            this.Data = data;
        }

        public Sesiune() { }

        public string ScrieInFisier()
        {
            return $"{Materie};{NumeProfesor};{Link};{Data:dd.MM.yyyy HH:mm}";
        }

        public static Sesiune CitesteDinLinie(string linie)
        {
            string[] date = linie.Split(';');
            return new Sesiune
            {
                Materie = (Materie)Enum.Parse(typeof(Materie), date[0]),
                NumeProfesor = date[1],
                Link = date[2],
                Data = DateTime.ParseExact(date[3], "dd.MM.yyyy HH:mm", null)
            };
        }
    }
}