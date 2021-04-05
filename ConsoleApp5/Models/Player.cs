using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ConsoleApp5.Models
{
    class Player
    {
        TcpClient playerClient;
        public NetworkStream playerStream;
        byte[] bytes = new byte[256];

        public Player(TcpClient client)
        {
            playerClient = client;
            playerStream = playerClient.GetStream();
        }

        internal bool CheckDataAvalible()
        {
            return playerStream.DataAvailable;
        }

        internal void WriteLine(string msg)
        {

            byte[] messageToSend = Encoding.UTF8.GetBytes(msg);
            playerStream.Write(messageToSend, 0, messageToSend.Length);

        }

        internal string ReadLine()
        {
            int i;
            String data = null;
            while ((i = playerStream.Read(bytes, 0, bytes.Length)) != 0)
            {
                data = Encoding.UTF8.GetString(bytes, 0, i);
                return data;
            }
            return "error";
        }

        internal int ParseInput()
        {
            WriteLine("Input n (0-8):");
            return int.Parse(ReadLine());
        }

        internal void Close()
        {
            playerClient.Close();
        }
    }
}
