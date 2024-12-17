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
    internal class SystemAudio : ISystem
    {

        const ComponentTypes MASK = (ComponentTypes.COMPONENT_POSITION | ComponentTypes.COMPONENT_AUDIO);
        public string Name
        { get { return "SystemAudio"; } }

        public void OnAction(List<Entity> entities)
        {
            foreach (Entity entity in entities)
            {
                if ((entity.Mask & MASK) == MASK)
                {
                    List<IComponent> components = entity.Components;

                    IComponent positionComponent = components.Find(delegate (IComponent component)
                    {
                        return component.ComponentType == ComponentTypes.COMPONENT_POSITION;
                    });

                    IComponent audioComponent = components.Find(delegate (IComponent component)
                    {
                        return component.ComponentType == ComponentTypes.COMPONENT_AUDIO;
                    });

                    ComponentPosition position = (ComponentPosition)positionComponent;

                    setPosition(position.Position, (ComponentAudio)audioComponent);

                }
            }
        }

        public void setPosition(Vector3 emitterPosition, ComponentAudio emitterAudio)
        {
            emitterAudio.setPosition(emitterPosition);
        }

        public void reset()
        {
        }

        public SystemAudio()
        {

        }
    }
}
