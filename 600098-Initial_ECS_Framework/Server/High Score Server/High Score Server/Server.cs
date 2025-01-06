using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;

using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace High_Score_Server
{
    public class Server
    {
        public static void Main(string[] args)
        {

            string loadHighScore()
            {
                // Load high score from file
                string path = "D:\\Uni Work\\Games Architecture\\Games-Architecture\\600098-Initial_ECS_Framework\\Server\\High Score Server\\High Score Server\\highscore.txt";
                string[] lines = File.ReadAllLines(path);
                string result;
                StringBuilder sb = new StringBuilder();
                foreach (string line in lines)
                {
                    sb.Append($",{line}");
                }
                result = sb.ToString();
                return result;
            }

            void addNewScore(string newScore)
            {
                // Load high score from file
                string path = "D:\\Uni Work\\Games Architecture\\Games-Architecture\\600098-Initial_ECS_Framework\\Server\\High Score Server\\High Score Server\\highscore.txt";
                string[] lines = File.ReadAllLines(path);
                string result;
                StringBuilder sb = new StringBuilder();
                foreach (string line in lines)
                {
                    sb.AppendLine(line);
                }
                result = sb.ToString();
                // Add new score to high score
                result += newScore;
                // Write new high score to file
                File.WriteAllText(path, result);
            }



            while (true)
            {
                int port = 8080;

                TcpListener listener = new TcpListener(IPAddress.Loopback, port);

                listener.Start();

                TcpClient client = listener.AcceptTcpClient();

                NetworkStream stream = client.GetStream();

                StreamWriter writer = new StreamWriter(stream, Encoding.ASCII) { AutoFlush = true };
                StreamReader reader = new StreamReader(stream, Encoding.ASCII);

                try
                {
                    Console.WriteLine("Server is running");
                    string inputLine = "";
                    while (inputLine != null)
                    {
                        inputLine = reader.ReadLine();
                        if (inputLine == "get")
                        {
                            Console.WriteLine("Getting High Scores");
                            string send = loadHighScore();
                            writer.WriteLine(send);
                        }
                        else
                        {
                            Console.WriteLine("Adding New High Score");
                            addNewScore(reader.ReadLine());
                            writer.WriteLine("New High Score Added");
                            Console.WriteLine("New High Score Added");
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    listener.Stop();
                    client.Close();
                }
            }
        }
    }
}
