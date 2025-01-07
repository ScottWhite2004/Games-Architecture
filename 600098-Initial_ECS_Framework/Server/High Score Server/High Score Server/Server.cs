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


            //Server that can add and retrive high scores
            TcpListener server = new TcpListener(IPAddress.Loopback, 8080);
            server.Start();
            Console.WriteLine("Server started");
            Console.WriteLine();
            TcpClient client = server.AcceptTcpClient();
            while (true)
            {
                try
                {
                    Console.WriteLine("Client connected");
                    NetworkStream stream = client.GetStream();
                    StreamReader sr = new StreamReader(stream);
                    StreamWriter sw = new StreamWriter(stream);
                    sw.AutoFlush = true;
                    string message = sr.ReadLine();
                    Console.WriteLine("Message recieved: " + message);
                    if (message == "get")
                    {
                        string highScore = loadHighScore();
                        sw.WriteLine(highScore);
                        Console.WriteLine("High score sent: " + highScore);
                    }
                    else
                    {
                        addNewScore(message);
                        Console.WriteLine("New high score added: " + message);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e);
                }
            }

        }
    }
}
