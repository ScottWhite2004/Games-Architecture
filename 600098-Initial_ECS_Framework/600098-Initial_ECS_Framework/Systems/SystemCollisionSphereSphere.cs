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
    internal class SystemCollisionSphereSphere : ISystem
    {
        
        const ComponentTypes MASK = (ComponentTypes.COMPONENT_POSITION | ComponentTypes.COMPONENT_COLLISIONSPHERE);
        
        public string Name
        { get
            { return "SystemCollisionSphereSphere"; }
        }

        public void OnAction(List<Entity> entityList)
        {
            for (int i = 0; i < entityList.Count; i++)
            {
                Vector3 position1;
                Vector3 position2;
                float radius1;
                float radius2;
                Entity entity = entityList[i];
                if ((entity.Mask & MASK) == MASK)
                {
                    List<IComponent> components = entity.Components;

                    IComponent positionComponent = components.Find(delegate (IComponent component)
                    {
                        return component.ComponentType == ComponentTypes.COMPONENT_POSITION;
                    });

                    IComponent sphereCollisionComponent = components.Find(delegate (IComponent component)
                        {
                            return component.ComponentType == ComponentTypes.COMPONENT_COLLISIONSPHERE;
                        });
                    position1 = ((ComponentPosition)positionComponent).Position;
                    radius1 = ((ComponentCollisionSphere)sphereCollisionComponent).Radius;
                }
                else
                {
                    continue;
                }
                for (int j = 0; j < entityList.Count; j++)
                {
                    if (j == i)
                    {
                        continue;
                    }
                    Entity entity2 = entityList[j];
                    if ((entity2.Mask & MASK) == MASK)
                    {
                        List<IComponent> components = entity2.Components;
                        IComponent positionComponent = components.Find(delegate (IComponent component)
                        {
                            return component.ComponentType == ComponentTypes.COMPONENT_POSITION;
                        });

                        IComponent sphereCollisionComponent = components.Find(delegate (IComponent component)
                        {
                            return component.ComponentType == ComponentTypes.COMPONENT_COLLISIONSPHERE;
                        });
                        position2 = ((ComponentPosition)positionComponent).Position;
                        radius2 = ((ComponentCollisionSphere)sphereCollisionComponent).Radius;
                        hasCollided(position1, position2, radius1, radius2);
                    }

                }
            }
        }

        public bool hasCollided(Vector3 object1Position, Vector3 object2Position, float object1Radius, float object2Radius)
        {
            if((object1Position-object2Position).Length < object1Radius + object2Radius)
            {
                return true;
            }
            return false;
        }
    }
}
