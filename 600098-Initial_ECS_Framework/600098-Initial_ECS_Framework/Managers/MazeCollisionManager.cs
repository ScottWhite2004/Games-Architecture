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
                            Debug.Assert(false, "Collided with the moon");
                        }
                        else
                        {
                            Debug.Assert(false, "Camera collided with something");
                        }
                        break;
                    case CollisionType.POINT_IN_AABB:
                        break;
                
                }

            }
        }
    }
}
