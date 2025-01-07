using OpenGL_Game.Game.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_Game.Game.Managers
{
    internal class HighScoreManager
    {
        public Client client;
        public Dictionary<string, int> highScores;

        public HighScoreManager(Client pClient)
        {
            client = pClient;
            highScores = new Dictionary<string, int>();
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

        public void addHighScore(string name, int score)
        {
            client.SendHighscore(name, score);
        }

    }
}
