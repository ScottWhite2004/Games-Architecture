using OpenGL_Game.Components;
using OpenGL_Game.Objects;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_Game.Systems
{
    internal class SystemAIPathfinding : ISystem
    {
        public string Name { get { return "SystemAIPathfinding"; } }

        const ComponentTypes MASK = (ComponentTypes.COMPONENT_POSITION | ComponentTypes.COMPONENT_AIPATHFINDING | ComponentTypes.COMPONENT_VELOCITY);
        const ComponentTypes MASK2 = (ComponentTypes.COMPONENT_POSITION | ComponentTypes.COMPONENT_PATHPOINT);

        Camera camera;
        List<Vector3> Nodes;

        private Vector3 currentNode;
        private Entity nextNode;
        public SystemAIPathfinding(Camera pCamera)
        {
            camera = pCamera;
            Nodes = new List<Vector3>();
        }
        
        public void OnAction(List<Entity> entityList)
        {
            for(int i = 0; i < entityList.Count; i++)
            {
                Nodes.Clear();
                
                if ((entityList[i].Mask & MASK) == MASK)
                {
                    List<IComponent> components = entityList[i].Components;

                    IComponent velocityComponent = components.Find(delegate (IComponent component)
                    {
                        return component.ComponentType == ComponentTypes.COMPONENT_VELOCITY;
                    });

                    IComponent positionComponent = components.Find(delegate (IComponent component)
                    {
                        return component.ComponentType == ComponentTypes.COMPONENT_POSITION;
                    });

                    IComponent pathfindingComponent = components.Find(delegate (IComponent component)
                    {
                        return component.ComponentType == ComponentTypes.COMPONENT_AIPATHFINDING;
                    });

                    float speed = ((ComponentAIPathfinding)pathfindingComponent).speed;
                    
                    for (int j = 0; j < entityList.Count; j++)
                    {
                        if (j == i)
                        {
                            continue;
                        }
                        if ((entityList[j].Mask & MASK2) == MASK2)
                        {
                            
                            List<IComponent> components2 = entityList[j].Components;
                            
                            IComponent positionComponent2 = components2.Find(delegate (IComponent component)
                            {
                                return component.ComponentType == ComponentTypes.COMPONENT_POSITION;
                            });

                            Vector3 nodePosition = ((ComponentPosition)positionComponent2).Position;
                            Nodes.Add(nodePosition);
                        }
                    }


                    Vector3 nodeToGoTo = pathFinding(Nodes, ((ComponentPosition)positionComponent).Position, camera.cameraPosition);
                    ((ComponentVelocity)velocityComponent).Velocity = steering(((ComponentPosition)positionComponent).Position, nodeToGoTo, speed);
                    if(vectorDistance(((ComponentPosition)positionComponent).Position, nodeToGoTo) < 0.1f)
                    {
                        currentNode = nodeToGoTo;
                    }
                }
                else
                {
                    continue;
                }
            }
        }

        public float vectorDistance(Vector3 point1, Vector3 point2)
        {
            float X = ((point2.X - point1.X) * (point2.X - point1.X));
            float Y = ((point2.Z - point1.Z) * (point2.Z - point1.Z));
            float distance = X + Y;
            distance = MathF.Sqrt(distance);
            return distance;
        }

        public float weightedDistance(Vector3 startPosition, Vector3 pointPosition, Vector3 goalPosition)
        {
            float targetDistance = vectorDistance(startPosition, pointPosition);
            float pointDistance = vectorDistance(pointPosition, goalPosition);
            return targetDistance + pointDistance;

        }

        public Vector3 pathFinding(List<Vector3> pNodes, Vector3 startPosition, Vector3 targetPosition)
        {
            float distance = 0;
            Vector3 chosenNode = new Vector3(0, 0, 0);
            foreach(Vector3 node in pNodes)
            {

                float weightedDist;
                if(node == currentNode)
                {
                    continue;
                }
                if (currentNode.LengthSquared == 0)
                {
                    weightedDist = weightedDistance(startPosition, node, targetPosition);
                }
                else
                {
                    weightedDist = weightedDistance(currentNode, node, targetPosition);
                }
                if(weightedDist < distance || distance == 0)
                {
                    chosenNode = node;
                    distance = weightedDist;
                }
            }
            if((vectorDistance(startPosition,targetPosition)) < 10)
            {
                return (targetPosition.X, 1.0f, targetPosition.Z);
            }
            return chosenNode;
        }

        public Vector3 steering(Vector3 startPosition, Vector3 targetPosition, float speed)
        {
           Vector3 force = targetPosition - startPosition;
            if (force.Length == 0)
            {
                return Vector3.Zero;
            }
            else
            {
                return force.Normalized() * speed;
            }
        }
    }
}
