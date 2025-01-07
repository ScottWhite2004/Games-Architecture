using OpenTK.Graphics.OpenGL;
using System;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Mathematics;
using OpenTK.Audio.OpenAL;
using System.Collections.Generic;
using OpenGL_Game.Game.Managers;
using OpenGL_Game.Game.Networking;
using OpenGL_Game.Engine.Scenes;
using OpenGL_Game.Engine.Objects;
using OpenGL_Game.Engine.Systems;
using OpenGL_Game.Engine.Managers;
using OpenGL_Game.Engine.Components;
using OpenGL_Game.Engine;

namespace OpenGL_Game.Game.Scenes
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    class GameScene : Scene
    {
        public static float dt = 0;
        public int score = 0;
        public int time = 0;
        public int lives = 3;
        public EntityManager entityManager;
        SystemManager systemManager;
        MazeCollisionManager collisionManager;
        public Camera camera;
        public static GameScene gameInstance;
        MazeLookAtManager lookAtManager;
        public HighScoreManager highScoreManager;
        public Dictionary<string, int> highScores;
        bool[] keysPressed;
        Vector3 playerStart;
        Vector3 droneStart;
        public bool[] keysCollected;
        Client client;

        public GameScene(SceneManager sceneManager) : base(sceneManager)
        {
            // Set Camera
            playerStart = new Vector3(-4.0f, 2.0f, 53.5f);
            droneStart = new Vector3(-30.0f, 1.0f, 30.0f);
            highScores = new Dictionary<string, int>();
            camera = new Camera(new Vector3(playerStart), new Vector3(-50, 2, 50), sceneManager.Size.X / (float)sceneManager.Size.Y, 0.1f, 100f);
            gameInstance = this;
            entityManager = new EntityManager();
            systemManager = new SystemManager();
            lookAtManager = new MazeLookAtManager();
            collisionManager = new MazeCollisionManager(this, entityManager);
            keysPressed = new bool[511];
            keysCollected = new bool[3];
            highScoreManager = sceneManager.highScoreManager;
            highScoreManager.getHighScores();


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
            newEntity.AddComponent(new ComponentGeometry("Game/Geometry/Maze/maze.obj"));
            newEntity.AddComponent(new ComponentShaderDefault());
            entityManager.AddEntity(newEntity);

            #region wallEntities
            newEntity = new Entity("Wall");
            newEntity.AddComponent(new ComponentPosition(0.0f, 0.0f, 0.0f));
            newEntity.AddComponent(new ComponentCollisionAABB(-100f, 0, 0, 1.5f));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Wall");
            newEntity.AddComponent(new ComponentPosition(0.0f, 0.0f, 0.0f));
            newEntity.AddComponent(new ComponentCollisionAABB(-1.5f, 0, 0, 100f));
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
            newEntity.AddComponent(new ComponentCollisionAABB(-55.0f, -54.5f, 0.0f, 54.0f));
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

            newEntity = new Entity("Key 3");
            newEntity.AddComponent(new ComponentPosition(-10.0f, 1.0f, 10.0f));
            newEntity.AddComponent(new ComponentCollisionSphere(2.5f));
            newEntity.AddComponent(new ComponentGeometry("Game/Geometry/Key/Key.obj"));
            newEntity.AddComponent(new ComponentAudio("Game/Audio/coin.wav", true));
            newEntity.AddComponent(new ComponentShaderDefault());
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Key 2");
            newEntity.AddComponent(new ComponentPosition(-45.0f, 1.0f, 10.0f));
            newEntity.AddComponent(new ComponentCollisionSphere(2.5f));
            newEntity.AddComponent(new ComponentGeometry("Game/Geometry/Key/Key.obj"));
            newEntity.AddComponent(new ComponentAudio("Game/Audio/coin.wav", true));
            newEntity.AddComponent(new ComponentShaderDefault());
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Key 1");
            newEntity.AddComponent(new ComponentPosition(-45.0f, 1.0f, 50.0f));
            newEntity.AddComponent(new ComponentCollisionSphere(2.5f));
            newEntity.AddComponent(new ComponentGeometry("Game/Geometry/Key/Key.obj"));
            newEntity.AddComponent(new ComponentAudio("Game/Audio/coin.wav", true));
            newEntity.AddComponent(new ComponentShaderDefault());
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Portal");
            newEntity.AddComponent(new ComponentPosition(-14.0f, 0.0f, 53.5f));
            newEntity.AddComponent(new ComponentCollisionSphere(2.5f));
            newEntity.AddComponent(new ComponentGeometry("Game/Geometry/Portal/Portal.obj"));
            newEntity.AddComponent(new ComponentShaderDefault());
            newEntity.AddComponent(new ComponentAudio("Game/Audio/buzz.wav", false));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Drone");
            newEntity.AddComponent(new ComponentPosition(droneStart));
            newEntity.AddComponent(new ComponentCollisionSphere(1.5f));
            newEntity.AddComponent(new ComponentGeometry("Game/Geometry/Drone/Drone.obj"));
            newEntity.AddComponent(new ComponentShaderDefault());
            newEntity.AddComponent(new ComponentVelocity(new Vector3(0.0f, 0.0f, 0.0f)));
            newEntity.AddComponent(new ComponentAIPathfinding(camera.cameraPosition, 2.0f));
            newEntity.AddComponent(new ComponentAudio("Game/Audio/buzz.wav", false));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Skybox");
            newEntity.AddComponent(new ComponentPosition(droneStart));
            newEntity.AddComponent(new ComponentGeometry("Game/Geometry/Skybox/Skybox.obj"));
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

            newEntity = new Entity("Point");
            newEntity.AddComponent(new ComponentPosition(-50.0f, 1.0f, 28.0f));
            newEntity.AddComponent(new ComponentPathPoint());
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Point");
            newEntity.AddComponent(new ComponentPosition(-50.0f, 1.0f, 48.0f));
            newEntity.AddComponent(new ComponentPathPoint());
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Point");
            newEntity.AddComponent(new ComponentPosition(-28.0f, 1.0f, 48.0f));
            newEntity.AddComponent(new ComponentPathPoint());
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Rolling Obstacle");
            newEntity.AddComponent(new ComponentPosition(-45.0f, 0.0f, 45.0f));
            newEntity.AddComponent(new ComponentGeometry("Game/Geometry/Rolling/rolling.obj"));
            newEntity.AddComponent(new ComponentShaderDefault());
            newEntity.AddComponent(new ComponentCollisionSphere(4.0f));
            newEntity.AddComponent(new ComponentRoaming());
            newEntity.AddComponent(new ComponentVelocity(0.0f, 0.0f, 0.0f));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Roaming Point");
            newEntity.AddComponent(new ComponentPosition(-43.0f, 0.0f, 53.0f));
            newEntity.AddComponent(new ComponentRoamingPoints());
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Roaming Point");
            newEntity.AddComponent(new ComponentPosition(-48.0f, 0.0f, 53.0f));
            newEntity.AddComponent(new ComponentRoamingPoints());
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Roaming Point");
            newEntity.AddComponent(new ComponentPosition(-52.0f, 0.0f, 53.0f));
            newEntity.AddComponent(new ComponentRoamingPoints());
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Roaming Point");
            newEntity.AddComponent(new ComponentPosition(-43.0f, 0.0f, 43.0f));
            newEntity.AddComponent(new ComponentRoamingPoints());
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Roaming Point");
            newEntity.AddComponent(new ComponentPosition(-48.0f, 0.0f, 43.0f));
            newEntity.AddComponent(new ComponentRoamingPoints());
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Roaming Point");
            newEntity.AddComponent(new ComponentPosition(-52.0f, 0.0f, 43.0f));
            newEntity.AddComponent(new ComponentRoamingPoints());
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Bouncing Obstacle");
            newEntity.AddComponent(new ComponentPosition(-50.0f, 1.0f, 15.0f));
            newEntity.AddComponent(new ComponentGeometry("Game/Geometry/Bouncing_Ball/bouncing_ball.obj"));
            newEntity.AddComponent(new ComponentShaderDefault());
            newEntity.AddComponent(new ComponentCollisionSphere(2.0f));
            newEntity.AddComponent(new ComponentVelocity(0.0f, 0.0f, 0.0f));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Player Hurt");
            newEntity.AddComponent(new ComponentPosition(0.0f, 0.0f, 0.0f));
            newEntity.AddComponent(new ComponentAudio("Game/Audio/pain1.wav", true));
            newEntity.AddComponent(new ComponentFollow(camera));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("All Coins Collected");
            newEntity.AddComponent(new ComponentPosition(0.0f, 0.0f, 0.0f));
            newEntity.AddComponent(new ComponentAudio("Game/Audio/gmae.wav", true));
            newEntity.AddComponent(new ComponentFollow(camera));
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
            newSystem = new SystemRoaming();
            systemManager.AddSystem(newSystem);
            newSystem = new SystemBouncing();
            systemManager.AddSystem(newSystem);
            newSystem = new SystemMoveBackAndForth();
            systemManager.AddSystem(newSystem);
            newSystem = new SystemCameraLookAt(lookAtManager);
            systemManager.AddSystem(newSystem);
            newSystem = new SystemBounceBackAndForth();
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
            time += 1;
            if (keysPressed[(char)Keys.Up])
            {
                camera.MoveForward(3.0f * dt);
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
                toggleMovement();
            }
            if (keysPressed[(char)Keys.C])
            {
                toggleWallCollision();
            }


            AL.Listener(ALListener3f.Position, ref camera.cameraPosition);
            AL.Listener(ALListenerfv.Orientation, ref camera.cameraDirection, ref camera.cameraUp);
            collisionManager.ProcessCollisions();
            lookAtManager.processLooking();

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
            GUI.DrawText($"Score: {time}", 30, 70, 30, 255, 255, 255);
            GUI.DrawText($"X: {camera.cameraPosition.X}, Y: {camera.cameraPosition.Y}, Z: {camera.cameraPosition.Z}", 30, 110, 30, 255, 255, 255);
            drawLives();
            drawKeys();
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
            keysPressed[(char)e.Key] = true;
        }

        public void Keyboard_KeyUp(KeyboardKeyEventArgs e)
        {
            keysPressed[(char)e.Key] = false;
        }

        public void endGame()
        {
            sceneManager.ChangeScene(SceneTypes.SCENE_GAME_OVER);
        }

        public void winGame()
        {
            sceneManager.ChangeScene(SceneTypes.SCENE_HIGH_SCORE);
        }

        public void resetPositions()
        {
            camera.cameraPosition = playerStart;
            Entity newEntity;
            newEntity = new Entity("Drone");
            newEntity.AddComponent(new ComponentPosition(droneStart));
            newEntity.AddComponent(new ComponentCollisionSphere(1.5f));
            newEntity.AddComponent(new ComponentGeometry("Game/Geometry/Drone/Drone.obj"));
            newEntity.AddComponent(new ComponentShaderDefault());
            newEntity.AddComponent(new ComponentVelocity(new Vector3(0.0f, 0.0f, 0.0f)));
            newEntity.AddComponent(new ComponentAIPathfinding(camera.cameraPosition, 2.0f));
            newEntity.AddComponent(new ComponentAudio("Game/Audio/buzz.wav", false));
            entityManager.AddEntity(newEntity);
        }

        public void drawLives()
        {
            if (lives == 3)
            {
                GUI.DrawImage("Game/UI/Heart.png", 1700, 80);
                GUI.DrawImage("Game/UI/Heart.png", 1740, 80);
                GUI.DrawImage("Game/UI/Heart.png", 1780, 80);
            }
            else if (lives == 2)
            {
                GUI.DrawImage("Game/UI/Heart.png", 1740, 80);
                GUI.DrawImage("Game/UI/Heart.png", 1780, 80);
            }
            else if (lives == 1)
            {
                GUI.DrawImage("Game/UI/Heart.png", 1780, 80);
            }
        }

        public void drawKeys()
        {
            if (keysCollected[0] == false)
            {
                GUI.DrawImage("Game/UI/Key.png", 30, 200);
                GUI.DrawText("Room 1 Key Not Collected", 85, 240, 30, 255, 255, 255);
            }
            if (keysCollected[1] == false)
            {
                GUI.DrawImage("Game/UI/Key.png", 30, 280);
                GUI.DrawText("Room 2 Key Not Collected", 85, 320, 30, 255, 255, 255);
            }
            if (keysCollected[2] == false)
            {
                GUI.DrawImage("Game/UI/Key.png", 30, 360);
                GUI.DrawText("Room 3 Key Not Collected", 85, 400, 30, 255, 255, 255);
            }
        }

        public void toggleMovement()
        {
            ISystem physicsSystem = systemManager.FindSystem("SystemPhysics");
            ((SystemPhysics)physicsSystem).togglePhysic();
        }

        public void toggleWallCollision()
        {
            bool wallsEnabled = collisionManager.wallsEnabled;
            if (wallsEnabled)
            {
                collisionManager.wallsEnabled = false;
            }
            else
            {
                collisionManager.wallsEnabled = true;
            }
        }
    }
}