using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PregatiriOnline
{
    public class Profesor : Utilizator
    {
        public string Materie { get; set; }
        public int Punctaj { get; set; }

        public Profesor(string nume, string email, string materie, int punctaj)
            : base(nume, email)
        {
            Materie = materie;
            Punctaj = punctaj;
        }

        public  string Info()
        {
            return base.Info() + $"Materie: {Materie}, Punctaj: {Punctaj}";
        }
    }
}

