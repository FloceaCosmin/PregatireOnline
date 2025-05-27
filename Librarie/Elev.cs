using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Librarie;

namespace Librarie
{
    public class Elev : Utilizator
    {
        public Clase Clasa { get; set; }
        public int Varsta { get; set; }

        public Elev(string nume, string email, Clase clasa, int varsta)
            : base(nume, email)
        {
            Clasa = clasa;
            Varsta = varsta;

        }


        public override string Info()
        {
            return $"Elev,{base.Info()},{Clasa},{Varsta}";
        }

        public static List<Elev> CautaEleviDupaNume(List<Elev> elevi, string numeElev)
        {
            return elevi.Where(e => e.Nume.ToLower().Contains(numeElev.ToLower())).ToList();
        }

        public static List<Elev> CautaEleviDupaVarsta(List<Elev> elevi, int varsta)
        {
            return elevi.Where(e => e.Varsta == varsta).ToList();
        }

        public static List<Elev> CautaEleviDupaClasa(List<Elev> elevi, string clasa)
        {
            return elevi.Where(e => e.Clasa.ToString().Equals(clasa, StringComparison.OrdinalIgnoreCase)).ToList();
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
