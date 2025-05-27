using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librarie
{
    public class Profesor : Utilizator
    {
        public List<Materie> Materii { get; set; }
        public int Punctaj { get; set; }

        public Profesor(string nume, string email, List<Materie> materii, int punctaj)
            : base(nume, email)
        {
            Materii = materii;
            Punctaj = punctaj;
        }

        public static List<Profesor> CautaProfesoriDupaNume(List<Profesor> profesori, string numeProfesor)
        {
            return profesori.Where(p => p.Nume.ToLower().Contains(numeProfesor.ToLower())).ToList();
        }

        public static List<Profesor> CautaProfesoriDupaMaterie(List<Profesor> profesori, string materie)
        {
            return profesori.Where(p => p.Materii.Any(m => m.ToString().ToLower().Contains(materie.ToLower()))).ToList();
        }

        public override string Info()
        {
            string materiiString = string.Join(", ", Materii);
            return $"Profesor,{base.Info()},{materiiString}, {Punctaj}";
        }

        public static Profesor CautaProfesorNume(List<Profesor> profesori, string numeProfesor)
        {
            foreach (var profesor in profesori)
            {
                if (profesor.Nume.ToLower().Contains(numeProfesor.ToLower()))
                {
                    return profesor;
                }
            }
            return null;
        }

        public string ScrieInFisier()
        {
            string materiiString = string.Join("|", Materii);
            return $"{Nume};{Email};{materiiString};{Punctaj}";
        }
    }
}
