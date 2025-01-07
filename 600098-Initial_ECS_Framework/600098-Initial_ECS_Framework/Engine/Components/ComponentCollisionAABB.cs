using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_Game.Engine.Components
{
    internal class ComponentCollisionAABB : IComponent
    {
        public ComponentTypes ComponentType
        { get { return ComponentTypes.COMPONENT_COLLISIONAABB; } }

        float xMin;
        float xMax;
        float zMin;
        float zMax;

        public ComponentCollisionAABB(float pXMin, float pXMax, float pZMin, float pZMax)
        {
            xMin = pXMin;
            xMax = pXMax;
            zMin = pZMin;
            zMax = pZMax;
        }

        public float XMin
        {
            get { return xMin; }
            set { xMin = value; }
        }

        public float ZMin
        { get { return zMin; } set { zMin = value; } }

        public float XMax
        { get { return xMax; } set { xMax = value; } }

        public float ZMax
        { get { return zMax; } set { zMax = value; } }

        public void Close()
        {

        }
    }
}
