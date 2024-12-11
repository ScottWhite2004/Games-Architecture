using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_Game.Components
{
    internal class ComponentAIPathfinding : IComponent
    {
        Vector3 targetPosition;
        public float speed;

        public ComponentAIPathfinding(Vector3 pTargetPosition, float pSpeed)
        {
            targetPosition = pTargetPosition;
            speed = pSpeed;
        }
        
        public ComponentTypes ComponentType { get { return ComponentTypes.COMPONENT_AIPATHFINDING; } }

        public void Close()
        {
            
        }
    }
}
