﻿using OpenGL_Game.Objects;
using System.Collections.Generic;

namespace OpenGL_Game.Systems
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
