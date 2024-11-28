using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_Game.Components
{
    internal class ComponentFollow : IComponent
    {
        public ComponentTypes ComponentType
        { get { return ComponentTypes.COMPONENT_FOLLOW; } }

        public ComponentFollow()
        {

        }

        public void Close()
        {

        }
    }
}
