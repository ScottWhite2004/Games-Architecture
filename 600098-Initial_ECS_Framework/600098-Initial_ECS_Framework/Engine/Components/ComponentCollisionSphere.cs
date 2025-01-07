using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_Game.Engine.Components
{
    internal class ComponentCollisionSphere : IComponent
    {
        float radius;

        public ComponentTypes ComponentType
        {
            get
            {
                return ComponentTypes.COMPONENT_COLLISIONSPHERE;
            }
        }

        public float Radius
        {
            get { return radius; }
            set { radius = value; }
        }


        public ComponentCollisionSphere(float pRadius)
        {
            radius = pRadius;
        }

        public void Close()
        {

        }
    }
}
