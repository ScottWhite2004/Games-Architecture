using OpenGL_Game.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_Game.Managers
{
    internal class HighScoreManager
    {
        public Client client;
        Dictionary<string, int> highScores;

        public HighScoreManager(Client pClient, Dictionary<string, int> pHighScores)
        {
            client = pClient;
            highScores = pHighScores;
        }


        public void getHighScores()
        {
            string highscores = client.GetHighscores();
            string[] strings = highscores.Split(',');
            foreach (string s in strings)
            {
                string[] scores = s.Split(' ');
                if (scores.Length == 2)
                {
                    highScores.Add(scores[0], int.Parse(scores[1]));
                }
            }
        }

    }
}
