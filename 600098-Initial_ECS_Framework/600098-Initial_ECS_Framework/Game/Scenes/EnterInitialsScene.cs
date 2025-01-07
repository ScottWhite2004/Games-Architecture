using OpenTK.Windowing.Common;
using SkiaSharp;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenGL_Game.Engine.Scenes;
using OpenGL_Game.Game.Networking;
using OpenGL_Game.Game.Managers;

namespace OpenGL_Game.Game.Scenes
{
    internal class EnterInitialsScene : Scene
    {

        string intitials = "";
        Keys keydown = Keys.Unknown;
        Client client;
        HighScoreManager highScoreManager;
        int score;

        public EnterInitialsScene(SceneManager sceneManager, int pScore) : base(sceneManager)
        {
            highScoreManager = sceneManager.highScoreManager;
            score = pScore;
            // Set the title of the window
            sceneManager.Title = "Enter Initials";
            // Set the Render and Update delegates to the Update and Render methods of this class
            sceneManager.renderer = Render;
            sceneManager.updater = Update;

            sceneManager.mouseDelegate += Mouse_BottonPressed;

            GL.ClearColor(0.2f, 0.75f, 1.0f, 1.0f);
        }

        public override void Close()
        {
            sceneManager.mouseDelegate -= Mouse_BottonPressed;
        }

        public override void Render(FrameEventArgs e)
        {
            GL.Viewport(0, 0, sceneManager.Size.X, sceneManager.Size.Y);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, sceneManager.Size.X, 0, sceneManager.Size.Y, -1, 1);

            //Display the Title using an outlined text
            SKPaint paint = new SKPaint();
            paint.TextSize = 100;
            paint.StrokeWidth = 2;
            paint.TextAlign = SKTextAlign.Center;
            paint.IsAntialias = true;
            paint.Color = SKColors.Yellow;
            paint.Style = SKPaintStyle.Fill;
            GUI.DrawText("Enter Initials", sceneManager.Size.X * 0.5f, 150, paint);
            paint.Color = SKColors.DarkBlue;
            paint.Style = SKPaintStyle.Stroke;
            GUI.DrawText("Enter Initials", sceneManager.Size.X * 0.5f, 150, paint);
            GUI.DrawText(intitials, sceneManager.Size.X * 0.5f, 300, paint);
            GUI.DrawText($"Score: {score}", sceneManager.Size.X * 0.5f, 450, paint);
            GUI.DrawText("Click To Submit", sceneManager.Size.X * 0.5f, 600, paint);
            GUI.Render();
        }

        public override void Update(FrameEventArgs e)
        {
            KeyboardState input = sceneManager.KeyboardState;
            for (int i = 0; i < (int)Keys.LastKey; i++)
            {
                if (input.IsKeyDown((Keys)i) && keydown != (Keys)i)
                {
                    keydown = (Keys)i;
                    intitials += keydown.ToString();
                }
                else if (input.IsKeyReleased((Keys)i))
                {
                    keydown = Keys.Unknown;
                }
            }
        }

        public void Mouse_BottonPressed(MouseButtonEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButton.Left:
                    highScoreManager.addHighScore(intitials, score);
                    sceneManager.ChangeScene(SceneTypes.SCENE_GAME_OVER);
                    break;
            }
        }
    }
}
