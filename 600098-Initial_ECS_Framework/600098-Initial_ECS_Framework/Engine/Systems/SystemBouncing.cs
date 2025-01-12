﻿using OpenGL_Game.Engine.Components;
using OpenGL_Game.Engine.Objects;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_Game.Engine.Systems
{
    internal class SystemBouncing : ISystem
    {
        public string Name { get { return "SystemBouncing"; } }

        const ComponentTypes MASK = ComponentTypes.COMPONENT_VELOCITY | ComponentTypes.COMPONENT_POSITION | ComponentTypes.COMPONENT_BOUNCING;

        public void OnAction(List<Entity> entityList)
        {
            foreach (Entity entity in entityList)
            {
                if ((entity.Mask & MASK) == MASK)
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

                    IComponent bouncingComponent = components.Find(delegate (IComponent component)
                    {
                        return component.ComponentType == ComponentTypes.COMPONENT_BOUNCING;
                    });

                    float min = ((ComponentBouncing)bouncingComponent).floorHeight;
                    float max = ((ComponentBouncing)bouncingComponent).maxHeight;

                    Vector3 velocity = ((ComponentVelocity)velocityComponent).Velocity;
                    Vector3 bounceVelocity = bounce(min, max, (ComponentPosition)positionComponent);
                    ((ComponentVelocity)velocityComponent).Velocity = (velocity.X, bounceVelocity.Y, velocity.Z);

                }
            }
        }

        public void reset()
        {

        }

        public Vector3 bounce(float minPoint, float maxPoint, ComponentPosition position)
        {
            if (position.Position.Y <= minPoint)
            {
                return new Vector3(0, 7, 0);
            }
            if (position.Position.Y >= maxPoint)
            {
                return new Vector3(0, -7, 0);
            }
            return new Vector3(0, 0, 0);
        }
    }
}
