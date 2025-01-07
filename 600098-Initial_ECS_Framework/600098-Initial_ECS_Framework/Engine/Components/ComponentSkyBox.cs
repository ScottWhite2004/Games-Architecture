using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_Game.Engine.Components
{
    internal class ComponentSkyBox : IComponent
    {
        public Vector3 boxCentre;

        public ComponentTypes ComponentType { get { return ComponentTypes.COMPONENT_SKYBOX; } }

        public ComponentSkyBox(Vector3 pBoxCentre)
        {
            boxCentre = pBoxCentre;
        }

        public void Close()
        {

        }
    }
}
