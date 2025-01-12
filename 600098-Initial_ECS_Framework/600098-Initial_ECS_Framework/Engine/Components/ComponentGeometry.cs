﻿using OpenGL_Game.Engine.Managers;
using OpenGL_Game.Engine.OBJLoader;

namespace OpenGL_Game.Engine.Components
{
    class ComponentGeometry : IComponent
    {
        Geometry geometry;

        public ComponentGeometry(string geometryName)
        {
            geometry = ResourceManager.LoadGeometry(geometryName);
        }

        public ComponentTypes ComponentType
        {
            get { return ComponentTypes.COMPONENT_GEOMETRY; }
        }

        public void Close()
        {

        }

        public Geometry Geometry()
        {
            return geometry;
        }
    }
}
