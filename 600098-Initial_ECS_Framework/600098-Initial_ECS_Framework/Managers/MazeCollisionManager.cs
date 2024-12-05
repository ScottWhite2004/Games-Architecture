using OpenGL_Game.Scenes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_Game.Managers
{
    internal class MazeCollisionManager : CollisionManager
    {
        GameScene sceneInstance;
        
        public MazeCollisionManager(GameScene pSceneInstance)
        {
            sceneInstance = pSceneInstance;
        }

        public override void ProcessCollisions()
        {
            foreach(Collision coll in collisionList)
            {
                switch (coll.collisionType)
                {
                    case CollisionType.SPHERE_SPHERE:
                        break;
                    case CollisionType.CAMERA_SPHERE:
                        if(coll.entity.Name == "Key")
                        {
                            sceneInstance.score++;
                            sceneInstance.camera.MoveForward(-0.01f);
                            sceneInstance.entityManager.RemoveEntity(coll.entity);
                        }
                        if(coll.entity.Name == "Portal")
                        {
                            if(sceneInstance.score == 3)
                            {
                                sceneInstance.endGame();
                            }
                            else
                            {
                                sceneInstance.camera.MoveForward(-0.5f);
                            }
                        }
                        if (coll.entity.Name == "Drone")
                        {
                            if (sceneInstance.lives > 0)
                            {
                                sceneInstance.entityManager.RemoveEntity(coll.entity);
                                sceneInstance.resetPositions();
                                sceneInstance.lives--;
                            }
                            else
                            {
                                sceneInstance.endGame();
                            }
                        }
                        break;
                    case CollisionType.POINT_IN_AABB:
                        if(coll.entity.Name == "Wall")
                        {
                            sceneInstance.camera.cameraDirection = -sceneInstance.camera.cameraDirection;
                            sceneInstance.camera.MoveForward(0.5f);
                        }
                        break;
                
                }

            }

            this.collisionList.Clear();
        }
    }
}
