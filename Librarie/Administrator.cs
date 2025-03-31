﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Librarie
{
    public class Administrator : Utilizator
    {

        public Administrator(string nume, string email)
            : base(nume, email)
        {
        }

        public  override string Info()
        {
            return "Amininstrator"+base.Info();
        }
    }
}

