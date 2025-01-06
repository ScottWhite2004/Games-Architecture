using OpenGL_Game.Managers;
using OpenTK.Windowing.Common;
using SkiaSharp;
using System;
using System.Collections.Generic;
using OpenTK.Graphics.OpenGL;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace OpenGL_Game.Scenes
{
    internal class HighScoreScene : Scene
    {
        
        public Dictionary<string, int> highScores;
        public int score;
        public HighScoreManager highScoreManager;


        public HighScoreScene(SceneManager sceneManager, Dictionary<string, int> pHighScores, int pScore, HighScoreManager pHighScoreManager) : base(sceneManager)
        {
            sceneManager.Title = "High Scores";
            sceneManager.renderer = Render;
            sceneManager.updater = Update;
            highScores = pHighScores;
            score = pScore;
            GL.ClearColor(0.2f, 0.75f, 1.0f, 1.0f);
            sceneManager.mouseDelegate += Mouse_BottonPressed;
            highScoreManager = pHighScoreManager;
        }

        public override void Close()
        {
            sceneManager.mouseDelegate -= Mouse_BottonPressed;
        }

        public override void Render(FrameEventArgs e)
        {
            //opengl scene with textbox to enter text
            GL.Viewport(0, 0, sceneManager.Size.X, sceneManager.Size.Y);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, sceneManager.Size.X, 0, sceneManager.Size.Y, -1, 1);

            SKPaint paint = new SKPaint();
            paint.TextSize = 50;
            paint.StrokeWidth = 2;
            paint.TextAlign = SKTextAlign.Center;
            paint.IsAntialias = true;
            paint.Color = SKColors.Yellow;
            paint.Style = SKPaintStyle.Fill;
            GUI.DrawText("High Scores", sceneManager.Size.X * 0.5f, 150, paint);
            paint.Color = SKColors.DarkBlue;
            paint.Style = SKPaintStyle.Stroke;
            GUI.DrawText("High Scores", sceneManager.Size.X * 0.5f, 150, paint);
            paint.Color = SKColors.DarkGreen;
            paint.TextSize = 30;
            int i = 0;
            foreach (KeyValuePair<string, int> entry in highScores)
            {
                GUI.DrawText(entry.Key + " : " + entry.Value, sceneManager.Size.X * 0.5f, 300 + i * 50, paint);
                i++;
            }
            GUI.Render();
        }

        public void Mouse_BottonPressed(MouseButtonEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButton.Left:
                    sceneManager.ChangeScene(SceneTypes.SCENE_ENTER_INITIALS);
                    break;
            }
        }

        public override void Update(FrameEventArgs e)
        {
        }
    }
}
