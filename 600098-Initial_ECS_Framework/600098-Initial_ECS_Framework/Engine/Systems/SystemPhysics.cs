using System;
using System.Collections.Generic;
using System.IO;
using OpenTK.Graphics.OpenGL;
using OpenGL_Game.Engine.OBJLoader;
using OpenTK.Mathematics;
using OpenGL_Game.Engine.Components;
using OpenGL_Game.Engine.Objects;
using OpenGL_Game.Game.Scenes;

namespace OpenGL_Game.Engine.Systems
{
    class SystemPhysics : ISystem
    {
        const ComponentTypes MASK = ComponentTypes.COMPONENT_POSITION | ComponentTypes.COMPONENT_VELOCITY;

        bool enabled = true;

        public SystemPhysics()
        {

        }
        public string Name
        {
            get { return "SystemPhysics"; }
        }

        public void OnAction(List<Entity> entityList)
        {
            if (enabled)
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

                        IComponent velocityComponent = components.Find(delegate (IComponent component)
                        {
                            return component.ComponentType == ComponentTypes.COMPONENT_VELOCITY;
                        });

                        Motion((ComponentPosition)positionComponent, (ComponentVelocity)velocityComponent);
                    }
                }
            }
        }

        public void Motion(ComponentPosition position, ComponentVelocity velocity)
        {
            position.Position += velocity.Velocity * GameScene.dt;
        }

        public void togglePhysic()
        {
            if (enabled)
            {
                enabled = false;
            }
            else
            {
                enabled = true;
            }
        }

        public void reset()
        {
        }
    }
}
