using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_Game.Engine.Components
{
    internal class ComponentFollow : IComponent
    {

        public Camera camera;
        public ComponentTypes ComponentType
        { get { return ComponentTypes.COMPONENT_FOLLOW; } }

        public ComponentFollow(Camera pCamera)
        {
            camera = pCamera;
        }

        public void Close()
        {

        }
    }
}
