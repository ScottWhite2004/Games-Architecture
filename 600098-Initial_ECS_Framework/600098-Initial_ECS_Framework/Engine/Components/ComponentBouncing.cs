using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_Game.Engine.Components
{
    internal class ComponentBouncing : IComponent
    {

        public float maxHeight;
        public float floorHeight;
        public ComponentTypes ComponentType { get { return ComponentTypes.COMPONENT_BOUNCING; } }

        public ComponentBouncing(float pMaxHeight, float pFloorHeight)
        {
            maxHeight = pMaxHeight;
            floorHeight = pFloorHeight;
        }

        public void Close()
        {

        }
    }
}
