using ConsoleApp5.Models;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace ConsoleApp5
{
    class Server
    {
        TcpListener server = null;
        IPAddress localAddr = IPAddress.Parse("0.0.0.0");
        int port = 13000;
       private Game game = new Game();

 
        public void Start()
        {
            try
            {
                server = new TcpListener(localAddr, port);
                server.Start();

                while (true)
                {
                    Console.Write("Waiting for a connection player1... ");
                    var player1 = new Player(server.AcceptTcpClient());
                    Console.WriteLine(" connected!");

                    Console.Write("Waiting for a connection player2... ");
                    var player2 = new Player(server.AcceptTcpClient());
                    Console.WriteLine(" connected!");

                    game = new Game();

                    player1.WriteLine(game.GetField());
                    player2.WriteLine(game.GetField());
                    int n;
                    string status;
                    Player currentPlayer;
                    while (true)
                    {

                        string turn = game.CheckMove();

                        if (turn == "X")
                            currentPlayer = player1;
                        else
                            currentPlayer = player2;

                        if (currentPlayer.CheckDataAvalible())
                            currentPlayer.ReadLine();

                        currentPlayer.WriteLine("YOUR TURN!\n");
                        n = currentPlayer.ParseInput();



                        if (n < 0 || n >= game.playingField.Length || game.playingField[n] != 0)
                        {
                            currentPlayer.WriteLine("Wrong coordinate!\n");
                            continue;
                        }
                        else
                        {
                            player1.WriteLine(game.GetField());
                            player2.WriteLine(game.GetField());

                            status = game.CheckStatus();
                            if (status == Game.WIN)
                            {
                                player1.WriteLine($"{turn} wins!");
                                player2.WriteLine($"{turn} wins!");
                                break;
                            }
                            else if (status == Game.DRAW)
                            {
                                player1.WriteLine("Draw!");
                                player2.WriteLine("Draw!");
                                break;
                            }
                        }
                    }
                    player1.Close();
                    player2.Close();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                server.Stop();
            }

            Console.WriteLine("\nHit enter to continue...");
            Console.Read();
        }
    }
}

