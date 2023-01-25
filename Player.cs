using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XO
{
    public class Player
    {
        static public string sym = "";
        static public bool X = true;
        static Player()
        {
            sym = X ? "X" : "0";
        }
    }
}
