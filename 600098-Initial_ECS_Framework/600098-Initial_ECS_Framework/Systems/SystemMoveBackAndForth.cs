using OpenGL_Game.Components;
using OpenGL_Game.Objects;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_Game.Systems
{
    internal class SystemMoveBackAndForth : ISystem
    {
        public string Name { get { return "MoveBackAndForth"; } }

        const ComponentTypes MASK = ComponentTypes.COMPONENT_POSITION | ComponentTypes.COMPONENT_MOVEBACKFORTH | ComponentTypes.COMPONENT_VELOCITY;

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

                    IComponent moveComponent = components.Find(delegate (IComponent component)
                    {
                        return component.ComponentType == ComponentTypes.COMPONENT_MOVEBACKFORTH;
                    });

                    Vector3 entityPosition = ((ComponentPosition)positionComponent).Position;
                    Vector3 startPoint = ((ComponentMoveBackAndForth)moveComponent).startPoint;
                    startPoint = (startPoint.X, entityPosition.Y, startPoint.Z);
                    Vector3 endPoint = ((ComponentMoveBackAndForth)moveComponent).endPoint;
                    endPoint = (endPoint.X, entityPosition.Y,  endPoint.Z);
                    if(vectorDistance(entityPosition,startPoint) < 0.1f)
                    {
                        Vector3 velocity = ((ComponentVelocity)velocityComponent).Velocity;
                        Vector3 steeringVelocity = steering(entityPosition, endPoint);
                        ((ComponentVelocity)velocityComponent).Velocity = new Vector3(steeringVelocity.X, velocity.Y, steeringVelocity.Z);
                    }
                    else if(vectorDistance(entityPosition,endPoint) < 0.1f)
                    {
                        Vector3 velocity = ((ComponentVelocity)velocityComponent).Velocity;
                        Vector3 steeringVelocity = steering(entityPosition, startPoint);
                        ((ComponentVelocity)velocityComponent).Velocity = new Vector3(steeringVelocity.X, velocity.Y, steeringVelocity.Z);
                    }
                }
            }
        }

        public Vector3 steering(Vector3 startPosition, Vector3 targetPosition)
        {
            return targetPosition - startPosition;
        }

        public float vectorDistance(Vector3 point1, Vector3 point2)
        {
            float x = (point2.X - point1.X) * (point2.X - point1.X);
            float y = (point2.Z - point1.Z) * (point2.Z - point1.Z);
            float dist = x + y;
            dist = MathF.Sqrt(dist);
            return dist;
        }
        
        public void reset()
        {

        }
    }
}
