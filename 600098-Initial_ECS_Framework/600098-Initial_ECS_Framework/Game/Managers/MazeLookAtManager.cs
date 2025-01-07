using OpenGL_Game.Engine.Components;
using OpenGL_Game.Engine.Managers;
using OpenGL_Game.Engine.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_Game.Game.Managers
{
    internal class MazeLookAtManager : LookAtManager
    {
        public override void processLooking()
        {
            foreach (Entity entity in lookAtList)
            {
                if (entity.Name == "Drone")
                {
                    playSound(entity);
                }
            }
            foreach (Entity entity in lookAwayList)
            {
                if (entity.Name == "Drone")
                {
                    stopSound(entity);
                }
            }
            clearLookAt();
            clearLookAway();
        }

        public void playSound(Entity entity)
        {
            const ComponentTypes MASK = ComponentTypes.COMPONENT_AUDIO;

            if ((entity.Mask & MASK) == MASK)
            {
                List<IComponent> components = entity.Components;

                IComponent audioComponent = components.Find(delegate (IComponent component)
                {
                    return component.ComponentType == ComponentTypes.COMPONENT_AUDIO;
                });

                ((ComponentAudio)audioComponent).Play();
            }
        }

        public void stopSound(Entity entity)
        {
            const ComponentTypes MASK = ComponentTypes.COMPONENT_AUDIO;

            if ((entity.Mask & MASK) == MASK)
            {
                List<IComponent> components = entity.Components;

                IComponent audioComponent = components.Find(delegate (IComponent component)
                {
                    return component.ComponentType == ComponentTypes.COMPONENT_AUDIO;
                });

                ((ComponentAudio)audioComponent).Stop();
            }
        }
    }


}
