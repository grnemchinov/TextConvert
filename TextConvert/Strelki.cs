using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Practich7
{
    public class Strelki
    {
        public int min, max;
        public ConsoleKeyInfo key;
        public int position;

        public void Strelka()
        {
            key = Console.ReadKey();
            if ((key.Key == ConsoleKey.UpArrow) && (position != 0))
            {
                position--;
            }

            if (key.Key == ConsoleKey.DownArrow)
            {
                position++;
            }
            if (position == min)
            {
                position = min + 1;
            }
            if (position == max + 1)
            {
                position = max;
            }
            if (position != 1)
            {
                Console.SetCursorPosition(0, position - 1);
                Console.Write("  ");
            }
            Console.SetCursorPosition(0, position + 1);
            Console.Write("  ");
            Console.SetCursorPosition(0, position);
            Console.Write("->");
        }
    }
}