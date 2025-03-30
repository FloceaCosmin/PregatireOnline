using System;

namespace Librarie
{
    [Flags]
    public enum Materie
    {
        Nimic = 0,            // 0000
        Matematica = 1,       // 0001
        Romana = 2,           // 0010
        Informatica = 4,      // 0100
        Biologie = 8,         // 1000
        Chimie = 16           // 10000
    }
}
