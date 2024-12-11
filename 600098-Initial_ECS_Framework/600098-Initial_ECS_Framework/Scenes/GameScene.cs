using OpenTK.Graphics.OpenGL;
using OpenGL_Game.Components;
using OpenGL_Game.Systems;
using OpenGL_Game.Managers;
using OpenGL_Game.Objects;
using System;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Mathematics;
using SkiaSharp;
using OpenTK.Audio.OpenAL;

namespace OpenGL_Game.Scenes
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    class GameScene : Scene
    {
        public static float dt = 0;
        public int score = 0;
        public int lives = 3;
        public EntityManager entityManager;
        SystemManager systemManager;
        MazeCollisionManager collisionManager;
        public Camera camera;
        public static GameScene gameInstance;
        bool[] keysPressed;
        Vector3 playerStart;
        Vector3 droneStart;

        public GameScene(SceneManager sceneManager) : base(sceneManager)
        {
            // Set Camera
            playerStart = new Vector3(-40.0f, 2.0f, 9.0f);
            droneStart = new Vector3(-30.0f, 1.0f, 30.0f);
            camera = new Camera(new Vector3(playerStart), new Vector3(-50, 2, 50), (float)(sceneManager.Size.X) / (float)(sceneManager.Size.Y), 0.1f, 100f);
            gameInstance = this;
            entityManager = new EntityManager();
            systemManager = new SystemManager();
            collisionManager = new MazeCollisionManager(this);
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

            newEntity = new Entity("Maze");
            newEntity.AddComponent(new ComponentPosition(0.0f, 0.0f, 0.0f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Maze/maze.obj"));
            newEntity.AddComponent(new ComponentShaderDefault());
            entityManager.AddEntity(newEntity);

            #region wallEntities
            newEntity = new Entity("Wall");
            newEntity.AddComponent(new ComponentPosition(0.0f,0.0f,0.0f));
            newEntity.AddComponent(new ComponentCollisionAABB(-100f,0,0,1.5f));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Wall");
            newEntity.AddComponent(new ComponentPosition(0.0f, 0.0f, 0.0f));
            newEntity.AddComponent(new ComponentCollisionAABB(-1.5f,0,0,100f));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Wall");
            newEntity.AddComponent(new ComponentPosition(0, 0.0f, 0.0f));
            newEntity.AddComponent(new ComponentCollisionAABB(-7.0f, 0.0f, 14.0f, 15.0f));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Wall");
            newEntity.AddComponent(new ComponentPosition(0, 0.0f, 0.0f));
            newEntity.AddComponent(new ComponentCollisionAABB(-7.0f, -6.0f, 15.0f, 40.0f));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Wall");
            newEntity.AddComponent(new ComponentPosition(0, 0.0f, 0.0f));
            newEntity.AddComponent(new ComponentCollisionAABB(-7.0f, 0.0f, 40.0f, 41.0f));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Wall");
            newEntity.AddComponent(new ComponentPosition(0, 0.0f, 0.0f));
            newEntity.AddComponent(new ComponentCollisionAABB(-100f, 0.0f, 54.0f, 55.5f));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Wall");
            newEntity.AddComponent(new ComponentPosition(0, 0.0f, 0.0f));
            newEntity.AddComponent(new ComponentCollisionAABB(-16.0f, -14.0f, 50.0f, 54.0f));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Wall");
            newEntity.AddComponent(new ComponentPosition(0, 0.0f, 0.0f));
            newEntity.AddComponent(new ComponentCollisionAABB(-40.0f, -16.0f, 50.0f, 52.0f));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Wall");
            newEntity.AddComponent(new ComponentPosition(0, 0.0f, 0.0f));
            newEntity.AddComponent(new ComponentCollisionAABB(-42.0f, -40.0f, 49.0f, 54.0f));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Wall");
            newEntity.AddComponent(new ComponentPosition(0, 0.0f, 0.0f));
            newEntity.AddComponent(new ComponentCollisionAABB(-55.0f, -54.5f,0.0f, 54.0f));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Wall");
            newEntity.AddComponent(new ComponentPosition(0, 0.0f, 0.0f));
            newEntity.AddComponent(new ComponentCollisionAABB(-55.0f, -51.0f, 41.0f, 42.5f));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Wall");
            newEntity.AddComponent(new ComponentPosition(0, 0.0f, 0.0f));
            newEntity.AddComponent(new ComponentCollisionAABB(-50.0f, -49.5f, 14.0f, 42.0f));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Wall");
            newEntity.AddComponent(new ComponentPosition(0, 0.0f, 0.0f));
            newEntity.AddComponent(new ComponentCollisionAABB(-55.0f, -51.0f, 14.0f, 15.0f));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Wall");
            newEntity.AddComponent(new ComponentPosition(0, 0.0f, 0.0f));
            newEntity.AddComponent(new ComponentCollisionAABB(-42.5f, -40.0f, 0.0f, 6.0f));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Wall");
            newEntity.AddComponent(new ComponentPosition(0, 0.0f, 0.0f));
            newEntity.AddComponent(new ComponentCollisionAABB(-42.5f, -14.0f, 6.0f, 7.5f));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Wall");
            newEntity.AddComponent(new ComponentPosition(0, 0.0f, 0.0f));
            newEntity.AddComponent(new ComponentCollisionAABB(-15.0f, -14.0f, 0.0f, 7.5f));
            entityManager.AddEntity(newEntity);
            #endregion

            newEntity = new Entity("Key");
            newEntity.AddComponent(new ComponentPosition(-10.0f,1.0f,10.0f));
            newEntity.AddComponent(new ComponentCollisionSphere(2.5f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Key/Key.obj"));
            newEntity.AddComponent(new ComponentShaderDefault());
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Key");
            newEntity.AddComponent(new ComponentPosition(-45.0f, 1.0f, 10.0f));
            newEntity.AddComponent(new ComponentCollisionSphere(2.5f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Key/Key.obj"));
            newEntity.AddComponent(new ComponentShaderDefault());
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Key");
            newEntity.AddComponent(new ComponentPosition(-45.0f, 1.0f, 50.0f));
            newEntity.AddComponent(new ComponentCollisionSphere(2.5f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Key/Key.obj"));
            newEntity.AddComponent(new ComponentShaderDefault());
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Portal");
            newEntity.AddComponent(new ComponentPosition(-14.0f, 0.0f, 53.5f));
            newEntity.AddComponent(new ComponentCollisionSphere(2.5f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Portal/Portal.obj"));
            newEntity.AddComponent(new ComponentShaderDefault());
            newEntity.AddComponent(new ComponentAudio("Audio/buzz.wav"));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Drone");
            newEntity.AddComponent(new ComponentPosition(droneStart));
            newEntity.AddComponent(new ComponentCollisionSphere(1.5f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Drone/Drone.obj"));
            newEntity.AddComponent(new ComponentShaderDefault());
            newEntity.AddComponent(new ComponentVelocity(new Vector3(0.0f, 0.0f, 0.0f)));
            newEntity.AddComponent(new ComponentAIPathfinding(camera.cameraPosition, 1.0f));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Skybox");
            newEntity.AddComponent(new ComponentPosition(droneStart));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Skybox/Skybox.obj"));
            newEntity.AddComponent(new ComponentShaderDefault());
            newEntity.AddComponent(new ComponentSkyBox(camera.cameraPosition));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Point");
            newEntity.AddComponent(new ComponentPosition(droneStart));
            newEntity.AddComponent(new ComponentPathPoint());
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Point");
            newEntity.AddComponent(new ComponentPosition(-8.0f, 1.0f, 28.0f));
            newEntity.AddComponent(new ComponentPathPoint());
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Point");
            newEntity.AddComponent(new ComponentPosition(-8.0f, 1.0f, 48.0f));
            newEntity.AddComponent(new ComponentPathPoint());
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Point");
            newEntity.AddComponent(new ComponentPosition(-8.0f, 1.0f, 9.0f));
            newEntity.AddComponent(new ComponentPathPoint());
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Point");
            newEntity.AddComponent(new ComponentPosition(-28.0f, 1.0f, 9.0f));
            newEntity.AddComponent(new ComponentPathPoint());
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Point");
            newEntity.AddComponent(new ComponentPosition(-50.0f, 1.0f, 9.0f));
            newEntity.AddComponent(new ComponentPathPoint());
            entityManager.AddEntity(newEntity);

            newEntity.AddComponent(new ComponentPosition(-50.0f, 1.0f, 28.0f));
            newEntity.AddComponent(new ComponentPathPoint());
            entityManager.AddEntity(newEntity);

            newEntity.AddComponent(new ComponentPosition(-50.0f, 1.0f, 48.0f));
            newEntity.AddComponent(new ComponentPathPoint());
            entityManager.AddEntity(newEntity);

            newEntity.AddComponent(new ComponentPosition(-28.0f, 1.0f, 48.0f));
            newEntity.AddComponent(new ComponentPathPoint());
            entityManager.AddEntity(newEntity);



        }

        private void CreateSystems()
        {
            ISystem newSystem;

            newSystem = new SystemRender(gameInstance);
            systemManager.AddSystem(newSystem);
            newSystem = new SystemPhysics();
            systemManager.AddSystem(newSystem);
            newSystem = new SystemAudio();
            systemManager.AddSystem(newSystem);
            newSystem = new SystemCollisionSphereSphere();
            systemManager.AddSystem(newSystem);
            newSystem = new SystemCollisionCameraSphere(camera, collisionManager);
            systemManager.AddSystem(newSystem);
            newSystem = new SystemCollisionPointInAABB(collisionManager, camera);
            systemManager.AddSystem(newSystem);
            newSystem = new SystemFollow();
            systemManager.AddSystem(newSystem);
            newSystem = new SystemAIDirectPath(camera);
            systemManager.AddSystem(newSystem);
            newSystem = new SystemSkyBox(camera);
            systemManager.AddSystem(newSystem);
            newSystem = new SystemAIPathfinding(camera);
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

            if (keysPressed[(char)Keys.Up])
            {
                camera.MoveForward(3.0f *  dt);
            }
            if (keysPressed[(char)Keys.Down])
            {
                camera.MoveForward(-3.0f * dt);
            }
            if (keysPressed[(char)Keys.Right])
            {
                camera.RotateY(0.5f * dt);
            }
            if (keysPressed[(char)Keys.Left])
            {
                camera.RotateY(-0.5f * dt);
            }
            if (keysPressed[(char)Keys.M])
            {
                endGame();
            }
            

            AL.Listener(ALListener3f.Position, ref camera.cameraPosition);
            AL.Listener(ALListenerfv.Orientation, ref camera.cameraDirection, ref camera.cameraUp);
            collisionManager.ProcessCollisions();

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

            // Render score and lives
            GUI.DrawText($"Score: {score}", 30, 80, 30, 255, 255, 255);
            GUI.DrawText($"X: {camera.cameraPosition.X}, Y: {camera.cameraPosition.Y}, Z: {camera.cameraPosition.Z}", 30, 110, 30, 255, 255, 255);
            GUI.DrawText($"Lives: {lives}", 30, 140, 30, 255, 255, 255);
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
            entityManager.Clear();
        }

        public void Keyboard_KeyDown(KeyboardKeyEventArgs e)
        {
            keysPressed[(Char)e.Key] = true;
        }

        public void Keyboard_KeyUp(KeyboardKeyEventArgs e)
        {
            keysPressed[((Char)e.Key)] = false;
        }

        public void endGame()
        {
            sceneManager.ChangeScene(SceneTypes.SCENE_GAME_OVER);
        }

        public void resetPositions()
        {
            camera.cameraPosition = playerStart;
            Entity newEntity;
            newEntity = new Entity("Drone");
            newEntity.AddComponent(new ComponentPosition(droneStart));
            newEntity.AddComponent(new ComponentCollisionSphere(1.5f));
            newEntity.AddComponent(new ComponentGeometry("Geometry/Drone/Drone.obj"));
            newEntity.AddComponent(new ComponentShaderDefault());
            newEntity.AddComponent(new ComponentVelocity(new Vector3(0.0f, 0.0f, 0.0f)));
            newEntity.AddComponent(new ComponentAIPathfinding(camera.cameraPosition, 1.0f));
            entityManager.AddEntity(newEntity);

        }
    }
}