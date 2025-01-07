using OpenGL_Game.Engine.Components;
using OpenGL_Game.Engine.Managers;
using OpenGL_Game.Engine.Objects;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace OpenGL_Game.Engine.Systems
{
    internal class SystemCameraLookAt : ISystem
    {
        public string Name { get { return "SystemCameraLookAt"; } }
        LookAtManager manager;

        public SystemCameraLookAt(LookAtManager pManager)
        {
            manager = pManager;
        }

        public ComponentTypes MASK = ComponentTypes.COMPONENT_POSITION | ComponentTypes.COMPONENT_CAMERALOOKAT;

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

                    IComponent lookAtComponent = components.Find(delegate (IComponent component)
                    {
                        return component.ComponentType == ComponentTypes.COMPONENT_CAMERALOOKAT;
                    });

                    Vector3 position = ((ComponentPosition)positionComponent).Position;
                    Camera camera = ((ComponentCameraLookAt)lookAtComponent).camera;

                    if (isLookingAt(camera, position))
                    {
                        manager.addLook(entity);
                    }
                    else
                    {
                        manager.addLookAway(entity);
                    }
                }


            }
        }

        public void reset()
        {

        }

        public bool isLookingAt(Camera camera, Vector3 position)
        {
            Vector3 check = camera.cameraPosition + camera.cameraDirection * 10.0f;
            if ((check - position).Length < 10.0f)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
