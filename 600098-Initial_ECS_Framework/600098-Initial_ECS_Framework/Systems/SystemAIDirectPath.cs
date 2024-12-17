using OpenGL_Game.Components;
using OpenGL_Game.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK.Mathematics;
using System.Threading.Tasks;

namespace OpenGL_Game.Systems
{
    internal class SystemAIDirectPath : ISystem
    {

        Camera camera;

        const ComponentTypes MASK = ComponentTypes.COMPONENT_POSITION | ComponentTypes.COMPONENT_AIDIRECTPATH | ComponentTypes.COMPONENT_VELOCITY;
        public string Name
        { get { return "SystemAIDirectPath"; } }

        public SystemAIDirectPath(Camera pCamera)
        {
            camera = pCamera;
        }

        public void OnAction(List<Entity> entityList)
        {
            foreach(Entity entity in entityList)
            {
               if((entity.Mask & MASK) == MASK)
                {
                    List<IComponent> components = entity.Components;

                    IComponent velocityComponent = components.Find(delegate (IComponent component)
                    {
                        return component.ComponentType == ComponentTypes.COMPONENT_VELOCITY;
                    });

                    IComponent positionComponent = components.Find(delegate (IComponent component)
                    {
                        return component.ComponentType == ComponentTypes.COMPONENT_POSITION;
                    });

                    IComponent pathComponent = components.Find(delegate (IComponent component)
                    {
                        return component.ComponentType == ComponentTypes.COMPONENT_AIDIRECTPATH;
                    });

                    ComponentAIDirectPath directPath = (ComponentAIDirectPath)pathComponent;
                    ComponentPosition position = (ComponentPosition)positionComponent;

                    ((ComponentVelocity)velocityComponent).Velocity = Steering(directPath.detectionDistance, position.Position, camera.cameraPosition, directPath.moveSpeed);

                }

            }
        }

        public Vector3 Steering(float detectionDistance, Vector3 startPosition, Vector3 targetPosition, float speed)
        {
            float distance = ((startPosition.X - targetPosition.X) * (startPosition.X - targetPosition.X)) + ((startPosition.Z - targetPosition.Z) * (startPosition.Z - targetPosition.Z));
            distance = MathF.Sqrt(distance);
            if(distance <= detectionDistance)
            {
                return (((targetPosition - startPosition).Normalized()) * speed);
            }
            else
            {
                return new Vector3(0.0f, 0.0f, 0.0f);
            }
        }

        public void reset()
        {
        }
    }
}
