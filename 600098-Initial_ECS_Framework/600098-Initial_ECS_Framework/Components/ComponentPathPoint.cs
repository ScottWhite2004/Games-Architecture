using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_Game.Components
{
    internal class ComponentPathPoint : IComponent
    {
        public ComponentTypes ComponentType { get { return ComponentTypes.COMPONENT_PATHPOINT; } }

        public void Close()
        {
            throw new NotImplementedException();
        }
    }
}
