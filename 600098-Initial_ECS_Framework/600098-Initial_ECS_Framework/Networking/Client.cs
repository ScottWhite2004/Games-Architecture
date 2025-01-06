using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_Game.Networking
{
    public class Client
    {
        // Send highscore to a server
        TcpClient client;
        int port = 8080;
        NetworkStream stream;

        public Client()
        {
            client = new TcpClient("localhost", port);
            stream = client.GetStream();
        }


        public void SendHighscore(string name, int score)
        {
            // create a writer and reader
            StreamReader reader = new StreamReader(stream, Encoding.ASCII);
            StreamWriter writer = new StreamWriter(stream, Encoding.ASCII) { AutoFlush = true };

            try
            {
                // send to the server
                writer.WriteLine("," + name + " " + score);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

        }

        // Get highscores from a server
        public string GetHighscores()
        {
            StreamReader reader = new StreamReader(stream, Encoding.ASCII);
            StreamWriter writer = new StreamWriter(stream, Encoding.ASCII) { AutoFlush = true };
            try
            {
                // send to the server
                writer.WriteLine("get");
                // read from the server
                string highscores = reader.ReadLine();
                // close the connection
                return highscores;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return null;
            }
        }


    }
}
