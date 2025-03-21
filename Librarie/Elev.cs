﻿using System;
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

        public string Info()
        {
            return $"Elev,{base.Info()},{Clasa},{Varsta}";
        }
    }
}
