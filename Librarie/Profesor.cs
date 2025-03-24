using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Librarie;

namespace PregatiriOnline
{
    public class Profesor : Utilizator
    {
        public  Materie MateriePredata { get; set; }
        public int Punctaj { get; set; }

        public Profesor(string nume, string email,Materie materiePredata, int punctaj)
            : base(nume, email)
        {
            MateriePredata = materiePredata;
            Punctaj = punctaj;
        }

        public  override string Info()
        {
            return   $"Profesor,{base.Info()},{MateriePredata}, {Punctaj}";
        }

        public static Profesor CautaProfesor(List<Profesor> profesori, string numeProfesor)
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
            return $"{Nume};{Email};{MateriePredata};{Punctaj}";
        }

    }
}

