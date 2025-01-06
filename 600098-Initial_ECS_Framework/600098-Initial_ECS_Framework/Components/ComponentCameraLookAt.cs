using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_Game.Components
{
    internal class ComponentCameraLookAt : IComponent
    {
        public ComponentTypes ComponentType { get { return ComponentTypes.COMPONENT_CAMERALOOKAT; } }

        public Camera camera;

        public ComponentCameraLookAt(Camera pCamera)
        {
            camera = pCamera;
        }

        public void Close()
        {
            throw new NotImplementedException();
        }
    }
}
