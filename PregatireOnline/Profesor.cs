using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PregatiriOnline
{
    public class Profesor
    {
        public string Nume;
        public string Materie;
        public string Email;

        public Profesor(string nume, string materie, string email)
        {
            Nume = nume;
            Materie = materie;
            Email = email;
        }
    }
}

