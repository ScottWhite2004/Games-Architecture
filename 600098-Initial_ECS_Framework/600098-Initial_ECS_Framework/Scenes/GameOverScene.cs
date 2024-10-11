﻿using OpenGL_Game.Managers;
using OpenTK.Graphics.ES30;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OpenGL_Game.Scenes.Scene;
using ClearBufferMask = OpenTK.Graphics.OpenGL.ClearBufferMask;
using GL = OpenTK.Graphics.OpenGL.GL;
using MatrixMode = OpenTK.Graphics.OpenGL.MatrixMode;

namespace OpenGL_Game.Scenes
{
    class GameOverScene : Scene
    {
        public GameOverScene(SceneManager sceneManager) : base(sceneManager)
        {
            // Set the title of the window
            sceneManager.Title = "Game Over";
            // Set the Render and Update delegates to the Update and Render methods of this class
            sceneManager.renderer = Render;
            sceneManager.updater = Update;

            sceneManager.mouseDelegate += Mouse_BottonPressed;

            GL.ClearColor(0.2f, 0.75f, 1.0f, 1.0f);
        }
        public override void Update(FrameEventArgs e)
        {
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
            paint.Color = SKColors.Red;
            paint.Style = SKPaintStyle.Fill;
            GUI.DrawText("Game Over", sceneManager.Size.X * 0.5f, 150, paint);
            paint.Color = SKColors.Black;
            paint.Style = SKPaintStyle.Stroke;
            GUI.DrawText("Game Over", sceneManager.Size.X * 0.5f, 150, paint);
            GUI.Render();
        }

        public void Mouse_BottonPressed(MouseButtonEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButton.Left:
                    sceneManager.ChangeScene(SceneTypes.SCENE_MAIN_MENU);
                    break;
            }
        }

        public override void Close()
        {
            sceneManager.mouseDelegate -= Mouse_BottonPressed;
        }
    }
}
