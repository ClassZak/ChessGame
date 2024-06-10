using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    internal class ConverterCoords
    {
        public static char DigitToLetter(uint d)
        {
            char newChar=(char)('a' + d - 1);

            return newChar;

        }
    }
}
