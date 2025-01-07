using OpenGL_Game.Engine.Objects;
using System.Collections.Generic;

namespace OpenGL_Game.Engine.Systems
{
    interface ISystem
    {
        void OnAction(List<Entity> entityList);

        void reset();

        // Property signatures: 
        string Name
        {
            get;
        }

    }
}
