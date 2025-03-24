using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PregatiriOnline
{
    public class Elev : Utilizator
    {
        public string Clasa { get; set; }
        public int Varsta { get; set; }

        public Elev(string nume, string email, string clasa, int varsta)
            : base(nume, email)
        {
            Clasa = clasa;
            Varsta = varsta;

        }


        public override string Info()
        {
            return $"Elev,{base.Info()},{Clasa},{Varsta}";
        }

        public static Elev CautaElev(List<Elev> elevi, string numeElev)
        {
            foreach (var elev in elevi)
            {
                if (elev.Nume.ToLower().Contains(numeElev.ToLower()))
                {
                    return elev;
                }
            }
            return null;
        }
        public string ScrieInFisier()
        {
            return $"{Nume};{Email};{Clasa};{Varsta}";
        }

    }
}
