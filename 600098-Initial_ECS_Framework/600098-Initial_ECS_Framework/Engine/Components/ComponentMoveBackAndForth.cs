using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_Game.Engine.Components
{
    internal class ComponentMoveBackAndForth : IComponent
    {

        public Vector3 endPoint;
        public Vector3 startPoint;
        public ComponentTypes ComponentType { get { return ComponentTypes.COMPONENT_MOVEBACKFORTH; } }

        public ComponentMoveBackAndForth(Vector3 pEndPoint, Vector3 pStartPoint)
        {
            endPoint = pEndPoint;
            startPoint = pStartPoint;
        }

        public void Close()
        {
        }
    }
}
