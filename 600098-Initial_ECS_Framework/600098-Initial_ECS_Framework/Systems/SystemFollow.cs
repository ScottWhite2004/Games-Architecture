using OpenGL_Game.Components;
using OpenGL_Game.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_Game.Systems
{
    internal class SystemFollow : ISystem
    {
        const ComponentTypes MASK = (ComponentTypes.COMPONENT_POSITION | ComponentTypes.COMPONENT_FOLLOW );

        public string Name
        { 
            get { return "SystemFollow"; }
        }

        public void OnAction(List<Entity> entityList)
        {
            throw new NotImplementedException();
        }
    }
}
