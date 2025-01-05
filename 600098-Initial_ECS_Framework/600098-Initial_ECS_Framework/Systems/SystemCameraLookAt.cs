using OpenGL_Game.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_Game.Systems
{
    internal class SystemCameraLookAt : ISystem
    {
        public string Name { get { return "SystemCameraLookAt"; } }

        public void OnAction(List<Entity> entityList)
        {
            throw new NotImplementedException();
        }

        public void reset()
        {
            throw new NotImplementedException();
        }
    }
}
