using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_Game.Components
{
    internal class ComponentAIDirectPath : IComponent
    {
        //public Vector3 targetPosition;
        public float detectionDistance;
        public float moveSpeed;
        
        public ComponentTypes ComponentType {  get { return ComponentTypes.COMPONENT_AIDIRECTPATH; } }

        public ComponentAIDirectPath(/*ref Vector3 pTargetPosition, */float pDetectionDistance, float pMoveSpeed)
        {
            //targetPosition = pTargetPosition;
            detectionDistance = pDetectionDistance;
            moveSpeed = pMoveSpeed;
        }

        public void Close()
        {
            
        }
    }
}
