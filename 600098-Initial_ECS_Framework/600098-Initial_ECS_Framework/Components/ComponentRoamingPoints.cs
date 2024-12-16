using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_Game.Components
{
    internal class ComponentRoamingPoints : IComponent
    {
        public ComponentTypes ComponentType { get { return ComponentTypes.COMPONENT_ROAMINGPOINT; } }

        public void Close()
        {

        }
    }
}
