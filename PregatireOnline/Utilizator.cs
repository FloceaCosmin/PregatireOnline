using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PregatiriOnline
{
    public abstract class Utilizator
    {
        public string Nume { get; set; }
        public string Email { get; set; }
        public string TipUtilizator { get; set; }

        public Utilizator(string nume, string email)
        {
            Nume = nume;
            Email = email;
        }

        public   virtual string Info()
        {
            return $" {TipUtilizator}:  Nume: {Nume}, Email: {Email}";
        }
    }
}
