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
            int currentPlayer = isCurrentX ? 1 : 2;

            var currentWinCombinations = winCombination.Where(c => c.Any(e => e == n));

            foreach (var winCombination in currentWinCombinations)
            {
                if (playingField[winCombination[0]] == currentPlayer && playingField[winCombination[1]] == currentPlayer && playingField[winCombination[2]] == currentPlayer)
                {
                    return true;
                }
            }

            return false;
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

        public void startGame()
        {
            bool stopGame = false;
            bool isCurrentX = false;
            do
            {
                isCurrentX = !isCurrentX;
                consoleIO.drawPlayingField(playingField);
                Console.WriteLine("mark " + (isCurrentX ? "X" : "O"));
                int n = consoleIO.getNumber();
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

