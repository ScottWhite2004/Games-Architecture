﻿using OpenGL_Game.Components;
using OpenGL_Game.Objects;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_Game.Systems
{
    internal class SystemFollow : ISystem
    {
        const ComponentTypes MASK = (ComponentTypes.COMPONENT_POSITION | ComponentTypes.COMPONENT_FOLLOW );

        public string Name
        { 
            get { return "SystemFollow"; }
        }

        public void OnAction(List<Entity> entityList)
        {
            foreach (Entity entity in entityList)
            {
                if((entity.Mask & MASK) == MASK)
                {
                    List<IComponent> components = entity.Components;

                    IComponent positionComponent = components.Find(delegate (IComponent component)
                    {
                        return component.ComponentType == ComponentTypes.COMPONENT_POSITION;
                    });

                    IComponent followComponent = components.Find(delegate (IComponent component)
                    {
                        return component.ComponentType == ComponentTypes.COMPONENT_FOLLOW;
                    });

                    Vector3 position = ((ComponentPosition)positionComponent).Position;
                    updatePosition((ComponentFollow)followComponent, position);
                }

            }
        }

        public void reset()
        {
        }

        public void updatePosition(ComponentFollow componentFollow, Vector3 position)
        {
            componentFollow.camera.cameraPosition = (position.X,position.Y, position.Z+3);
            componentFollow.camera.UpdateView();
        }
    }
}
