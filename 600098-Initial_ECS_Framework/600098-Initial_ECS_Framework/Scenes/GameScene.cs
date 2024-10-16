﻿using OpenTK.Graphics.OpenGL;
using OpenGL_Game.Components;
using OpenGL_Game.Systems;
using OpenGL_Game.Managers;
using OpenGL_Game.Objects;
using System;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Mathematics;
using SkiaSharp;

namespace OpenGL_Game.Scenes
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    class GameScene : Scene
    {
        public static float dt = 0;
        EntityManager entityManager;
        SystemManager systemManager;
        public Camera camera;
        public static GameScene gameInstance;
        bool[] keysPressed;

        public GameScene(SceneManager sceneManager) : base(sceneManager)
        {
            // Set Camera
            camera = new Camera(new Vector3(0, 4, 7), new Vector3(0, 0, 0), (float)(sceneManager.Size.X) / (float)(sceneManager.Size.Y), 0.1f, 100f);
            gameInstance = this;
            entityManager = new EntityManager();
            systemManager = new SystemManager();
            keysPressed = new bool[511];

            // Set the title of the window
            sceneManager.Title = "Game";
            // Set the Render and Update delegates to the Update and Render methods of this class
            sceneManager.renderer = Render;
            sceneManager.updater = Update;
            // Set Keyboard events to go to a method in this class
            sceneManager.keyboardDownDelegate += Keyboard_KeyDown;
            sceneManager.keyboardUpDelegate += Keyboard_KeyUp;

            // Enable Depth Testing
            GL.Enable(EnableCap.DepthTest);
            GL.DepthMask(true);
            GL.Enable(EnableCap.CullFace);
            GL.CullFace(CullFaceMode.Back);

            GL.ClearColor(0.0f, 0.0f, 0.0f, 1.0f);



            CreateEntities();
            CreateSystems();

            // TODO: Add your initialization logic here
        }

        private void CreateEntities()
        {
            Entity newEntity;
            Entity newEntity2;

            newEntity = new Entity("Moon");
            newEntity.AddComponent(new ComponentPosition(-2.0f, 0.0f, 0.0f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Moon/moon.obj"));
            newEntity.AddComponent(new ComponentShaderDefault());
            entityManager.AddEntity(newEntity);

            newEntity2 = new Entity("Wraith_Raider_Starship");
            newEntity2.AddComponent(new ComponentPosition(2.0f, 0.0f, 0.0f));
            newEntity2.AddComponent(new ComponentGeometry("Geometry/Intergalactic_Spaceship/Intergalactic_Spaceship.obj"));
            newEntity2.AddComponent(new ComponentVelocity(0.0f, 0.0f, 0.2f));
            entityManager.AddEntity(newEntity2);

        }

        private void CreateSystems()
        {
            ISystem newSystem;

            newSystem = new SystemRender(gameInstance);
            systemManager.AddSystem(newSystem);
            newSystem = new SystemPhysics();
            systemManager.AddSystem(newSystem);
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="e">Provides a snapshot of timing values.</param>
        public override void Update(FrameEventArgs e)
        {
            dt = (float)e.Time;

            //switch (e.Key)
            //{
            //    case Keys.Up:
            //        camera.MoveForward(0.1f);
            //        break;
            //    case Keys.Down:
            //        camera.MoveForward(-0.1f);
            //        break;
            //    case Keys.Left:
            //        camera.RotateY(-0.01f);
            //        break;
            //    case Keys.Right:
            //        camera.RotateY(0.01f);
            //        break;
            //    case Keys.M:
            //        sceneManager.ChangeScene(SceneTypes.SCENE_GAME_OVER);
            //        break;
            //}

            if (keysPressed[(char)Keys.Up])
            {
                camera.MoveForward(1.0f * dt);
            }
            if (keysPressed[(char)Keys.Down])
            {
                camera.MoveForward(-1.0f * dt);
            }
            if (keysPressed[(char)Keys.Right])
            {
                camera.RotateY(0.1f * dt);
            }
            if (keysPressed[(char)Keys.Left])
            {
                camera.RotateY(-0.1f * dt);
            }
            if (keysPressed[(char)Keys.M])
            {
                sceneManager.ChangeScene(SceneTypes.SCENE_GAME_OVER);
            }


            //System.Console.WriteLine("fps=" + (int)(1.0/dt));

            // TODO: Add your update logic here
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="e">Provides a snapshot of timing values.</param>
        public override void Render(FrameEventArgs e)
        {
            GL.Viewport(0, 0, sceneManager.Size.X, sceneManager.Size.Y);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            // Action ALL systems
            systemManager.ActionSystems(entityManager);

            // Render score
            GUI.DrawText("Score: 000", 30, 80, 30, 255, 255, 255);
            GUI.Render();
        }

        /// <summary>
        /// This is called when the game exits.
        /// </summary>
        public override void Close()
        {
            
            sceneManager.keyboardDownDelegate -= Keyboard_KeyDown;
            sceneManager.keyboardUpDelegate -= Keyboard_KeyUp;
            //ResourceManager.RemoveAllAssets();
            // Need to remove assets (except Text) from Resource Manager
        }

        public void Keyboard_KeyDown(KeyboardKeyEventArgs e)
        {
            keysPressed[(Char)e.Key] = true;
        }

        public void Keyboard_KeyUp(KeyboardKeyEventArgs e)
        {
            keysPressed[((Char)e.Key)] = false;
        }
    }
}