using System;
using System.Collections.Generic;
using System.Linq;
using OpenTK.Mathematics;
using System.Text;
using System.Threading.Tasks;
using OpenGL_Game.Engine.Components;
using OpenGL_Game.Engine.Objects;

namespace OpenGL_Game.Engine.Systems
{
    internal class SystemBounceBackAndForth : ISystem
    {
        public string Name { get { return "SystemBounceBackAndForth"; } }

        const ComponentTypes MASK = ComponentTypes.COMPONENT_POSITION | ComponentTypes.COMPONENT_BOUNCEBACKFORWARD | ComponentTypes.COMPONENT_VELOCITY;

        public void OnAction(List<Entity> entityList)
        {
            foreach (Entity entity in entityList)
            {
                if ((entity.Mask & MASK) == MASK)
                {

                    List<IComponent> components = entity.Components;

                    IComponent positionComponent = components.Find(delegate (IComponent component)
                    {
                        return component.ComponentType == ComponentTypes.COMPONENT_POSITION;
                    });

                    IComponent bounceBackForwardsComponent = components.Find(delegate (IComponent component)
                    {
                        return component.ComponentType == ComponentTypes.COMPONENT_BOUNCEBACKFORWARD;
                    });

                    IComponent velocityComponent = components.Find(delegate (IComponent component)
                    {
                        return component.ComponentType == ComponentTypes.COMPONENT_VELOCITY;
                    });

                    Vector3 position = ((ComponentPosition)positionComponent).Position;
                    Vector3 startPosition = ((ComponentBounceBackAndForth)bounceBackForwardsComponent).startPoint;
                    Vector3 endPosition = ((ComponentBounceBackAndForth)bounceBackForwardsComponent).endPoint;
                    float floorHeight = ((ComponentBounceBackAndForth)bounceBackForwardsComponent).floorHeight;
                    float maxHeight = ((ComponentBounceBackAndForth)bounceBackForwardsComponent).maxHeight;
                    ((ComponentVelocity)velocityComponent).Velocity = steering(position, maxHeight, floorHeight, startPosition, endPosition);
                }


            }
        }

        public Vector3 steering(Vector3 position, float maxHeight, float minHeight, Vector3 point1, Vector3 point2)
        {
            Vector3 steering = Vector3.Zero;
            if (vectorDistance(position, point1) < 3.0f)
            {
                steering = point2 - position;
                if (maxHeight - position.Y <= 1.0f)
                {
                    float Ysteering = minHeight - position.Y;
                    steering = new Vector3(steering.X, Ysteering, steering.Z);
                }
                else if (minHeight - position.Y <= 1.0f)
                {
                    float Ysteering = maxHeight - position.Y;
                    steering = new Vector3(steering.X, Ysteering, steering.Z);
                }
            }
            else if (vectorDistance(position, point2) < 3.0f)
            {
                steering = point1 - position;
                if (maxHeight - position.Y <= 1.0f)
                {
                    float Ysteering = minHeight - position.Y;
                    steering = new Vector3(steering.X, Ysteering, steering.Z);
                }
                else if (minHeight - position.Y <= 1.0f)
                {
                    float Ysteering = maxHeight - position.Y;
                    steering = new Vector3(steering.X, Ysteering, steering.Z);
                }
            }
            steering = steering.Normalized() * 0.5f;
            return steering;
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
