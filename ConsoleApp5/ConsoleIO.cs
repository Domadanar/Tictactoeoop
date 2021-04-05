using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class ConsoleIO
    {
        public void drawPlayingField(int[] playingField)
        {
            Console.WriteLine("     |     |     ");
            for (int i = 0; i < playingField.Length; i++)
            {
                if (i != 0)
                {
                    if (i % 3 == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("_____|_____|_____");
                        Console.WriteLine("     |     |     ");
                    }
                    else
                    {
                        Console.Write("|");
                    }
                }

                if (playingField[i] == 0)
                {
                    Console.Write("  " + i + "  ");
                }
                if (playingField[i] == 1)
                {
                    Console.Write("  X  ");
                }
                if (playingField[i] == 2)
                {
                    Console.Write("  O  ");
                }
            }
            Console.WriteLine();
            Console.WriteLine("     |     |     ");
        }

        public int getNumber()
        {

            while (true)
            {
                try
                {
                    int n = int.Parse(Console.ReadLine());
                    return n;
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Please enter the number");
                }


            }
        }

    }
}
