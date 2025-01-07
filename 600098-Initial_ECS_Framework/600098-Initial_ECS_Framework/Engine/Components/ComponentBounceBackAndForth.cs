using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_Game.Engine.Components
{
    internal class ComponentBounceBackAndForth : IComponent
    {
        public ComponentTypes ComponentType { get { return ComponentTypes.COMPONENT_BOUNCEBACKFORWARD; } }

        public float floorHeight;
        public float maxHeight;

        public Vector3 startPoint;
        public Vector3 endPoint;

        public ComponentBounceBackAndForth(float pFloorHeight, float pMaxHeight, Vector3 pStartPoint, Vector3 pEndPoint)
        {
            floorHeight = pFloorHeight;
            maxHeight = pMaxHeight;
            startPoint = pStartPoint;
            endPoint = pEndPoint;
        }

        public void Close()
        {

        }
    }
}
