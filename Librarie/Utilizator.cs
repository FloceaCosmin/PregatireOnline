﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librarie
{
    public abstract class Utilizator
    {
        public string Nume { get; set; }
        public string Email { get; set; }

        public Utilizator(string nume, string email)
        {
            Nume = nume;
            Email = email;
        }

        public   virtual string Info()
        {
            return $"{Nume},{Email}";
        }
    }
}
