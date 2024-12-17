using OpenGL_Game.Components;
using OpenGL_Game.Objects;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace OpenGL_Game.Systems
{
    internal class SystemRoaming : ISystem
    {
        public string Name { get { return "System Roaming"; } }

        const ComponentTypes MASK = (ComponentTypes.COMPONENT_ROAMING | ComponentTypes.COMPONENT_VELOCITY);
        const ComponentTypes POINTMASK = (ComponentTypes.COMPONENT_ROAMINGPOINT | ComponentTypes.COMPONENT_POSITION);
        Vector3 selectedPoint;

        public void OnAction(List<Entity> entityList)
        {
            foreach(Entity entity in entityList)
            {
                
                List<Vector3> points = new List<Vector3> ();
                if((entity.Mask & MASK) == MASK)
                {
                    
                    List<IComponent> components = entity.Components;
                    
                    IComponent positionComponent = components.Find(delegate (IComponent component)
                    {
                        return component.ComponentType == ComponentTypes.COMPONENT_POSITION;
                    });

                    IComponent velocityComponent = components.Find(delegate (IComponent component)
                    {
                        return component.ComponentType == ComponentTypes.COMPONENT_VELOCITY;
                    });

                    foreach(Entity entity1 in entityList)
                    {
                        if((entity1.Mask & POINTMASK) == POINTMASK)
                        {
                            List<IComponent> components1 = entity1.Components;

                            IComponent positionComponent1 = components1.Find(delegate (IComponent component)
                            {
                                return component.ComponentType == ComponentTypes.COMPONENT_POSITION;
                            });

                            Vector3 pointPosition = ((ComponentPosition)positionComponent1).Position;
                            points.Add (pointPosition);
                        }
                    }

                    if (distance(((ComponentPosition)positionComponent).Position, selectedPoint) < 0.1f || selectedPoint.Length == 0)
                    {
                        selectedPoint = randomPoint(points);
                    }
                    ((ComponentVelocity)velocityComponent).Velocity = steering(((ComponentPosition)positionComponent).Position, selectedPoint);
                }
            }
        }


        public Vector3 randomPoint(List<Vector3> points)
        {
            Random rnd = new Random();
            int pointIndex = rnd.Next(points.Count-1);
            return points[pointIndex];
        }
        
        public Vector3 steering(Vector3 position, Vector3 pointPosition)
        {
            return pointPosition - position;
        }

        public float distance(Vector3 point1, Vector3 point2)
        {
            float X = (point2.X - point1.X) * (point2.X - point1.X);
            float Z = (point2.Z - point1.Z) * (point2.Z - point1.Z);
            float dist = X + Z;
            dist = MathF.Sqrt(dist);
            return dist;
        }

        public void reset()
        {
        }
    }
}
