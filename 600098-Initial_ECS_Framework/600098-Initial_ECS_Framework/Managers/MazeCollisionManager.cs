using OpenGL_Game.Components;
using OpenGL_Game.Objects;
using OpenGL_Game.Scenes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using IComponent = OpenGL_Game.Components.IComponent;

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
                            playSoundEffect(coll.entity);
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
                        if(coll.entity.Name == "Rolling Obstacle")
                        {
                            if(sceneInstance.lives > 0)
                            {
                                sceneInstance.lives--;
                                sceneInstance.camera.MoveForward(-1.0f);
                            }
                            else
                            {
                                sceneInstance.endGame();
                            }
                        }
                        if(coll.entity.Name == "Bouncing Obstacle")
                        {
                            if(sceneInstance.lives > 0)
                            {
                                sceneInstance.lives--;
                                sceneInstance.camera.MoveForward(-1.0f);
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

        public void playSoundEffect(Entity entity)
        {
            const ComponentTypes MASK = ComponentTypes.COMPONENT_AUDIO;

            if((entity.Mask & MASK) == MASK)
            {
                List<IComponent> components = entity.Components;

                IComponent audioComponent = components.Find(delegate (IComponent component)
                {
                    return component.ComponentType == ComponentTypes.COMPONENT_AUDIO;
                });

                ((ComponentAudio)audioComponent).Play();
            }
        }
    }
}
