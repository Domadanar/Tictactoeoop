using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class TicTacToeGame
    {
        private ConsoleIO consoleIO = new ConsoleIO();

        private int[] playingField = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        private int[][] winCombination = new int[][]
        {
        new int[] {0, 1, 2},
        new int[] {3, 4, 5},
        new int[] {6, 7, 8},
        new int[] {0, 4, 8},
        new int[] {2, 4, 6},
        new int[] {0, 3, 6},
        new int[] {1, 4, 7},
        new int[] {2, 5, 8}
        };

        private bool isGameOver(int n, int[] playingField, bool isCurrentX)
        {
            int row = n - n % 3;
            if (playingField[row] == playingField[row + 1] && playingField[row] == playingField[row + 2])
            {
                return true;
            }

            int column = n % 3;
            if (playingField[column] == playingField[column + 3])
            {
                if (playingField[column] == playingField[column + 6])
                {
                    return true;
                }
            }

            if (n % 2 != 0)
            {
                return false;
            }

            if (n % 4 == 0)
            {

                if (playingField[0] == playingField[4] && playingField[0] == playingField[8])
                {
                    return true;
                }
                if (n != 4)
                {
                    return false;
                }
            }
            return playingField[2] == playingField[4] && playingField[2] == playingField[6];
        }

        private bool Draw
        {
            get
            {
                foreach (int n in playingField)
                {
                    if (n == 0)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public virtual void startGame()
        {
            bool stopGame = false;
            bool isCurrentX = false;
            do
            {
                isCurrentX = !isCurrentX;
                consoleIO.drawPlayingField(playingField);
                Console.WriteLine("mark " + (isCurrentX ? "X" : "O"));
                int n = consoleIO.getNumber(playingField);
                if (n < 0 || n >= playingField.Length || playingField[n] != 0)
                {
                    Console.WriteLine("\n" + "Choose free cell and enter its number");
                    continue;
                }
                playingField[n] = isCurrentX ? 1 : 2;
                stopGame = isGameOver(n, playingField, isCurrentX);
                if (Draw)
                {
                    Console.WriteLine("Draw");
                    return;
                }
            } while (!stopGame);
            consoleIO.drawPlayingField(playingField);
            Console.WriteLine();

            Console.WriteLine("The winner is " + (isCurrentX ? "X" : "O") + "!");
        }
    }

}

