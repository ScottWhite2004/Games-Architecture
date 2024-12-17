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
        public Vector3 currentNode;

        public ComponentAIPathfinding(Vector3 pTargetPosition, float pSpeed)
        {
            targetPosition = pTargetPosition;
            speed = pSpeed;
            currentNode = new Vector3(0,0,0);
        }
        
        public ComponentTypes ComponentType { get { return ComponentTypes.COMPONENT_AIPATHFINDING; } }

        public void Close()
        {
            
        }
    }
}
