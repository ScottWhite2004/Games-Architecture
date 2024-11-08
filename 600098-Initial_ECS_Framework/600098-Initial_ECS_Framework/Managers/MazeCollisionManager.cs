﻿using OpenGL_Game.Scenes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
                        if(coll.entity.Name == "Moon")
                        {
                            sceneInstance.score++;
                        }
                        else
                        {
                            Debug.Assert(false, "Camera collided with something");
                        }
                        break;
                    case CollisionType.POINT_IN_AABB:
                        Debug.Assert(false, "Camera collided with something");
                        break;
                
                }

            }
        }
    }
}
