using OpenGL_Game.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_Game.Managers
{
    enum CollisionType
    {
        SPHERE_SPHERE,
        CAMERA_SPHERE,
        POINT_IN_AABB
    }

    struct Collision
    {
        public Entity entity;
        public CollisionType collisionType;
    }
    abstract class CollisionManager
    {

        protected List<Collision> collisionList = new List<Collision>();

        public CollisionManager()
        {  }

        public void clearCollisions()
        {
            collisionList.Clear();
        }








    }
}
