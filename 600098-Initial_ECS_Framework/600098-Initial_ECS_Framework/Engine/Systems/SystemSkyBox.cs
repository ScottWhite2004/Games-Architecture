using OpenGL_Game.Engine.Components;
using OpenGL_Game.Engine.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_Game.Engine.Systems
{
    internal class SystemSkyBox : ISystem
    {

        const ComponentTypes MASK = ComponentTypes.COMPONENT_POSITION | ComponentTypes.COMPONENT_SKYBOX;

        Camera camera;


        public SystemSkyBox(Camera pCamera)
        {
            camera = pCamera;
        }



        public string Name { get { return "SystemSkyBox"; } }

        public void OnAction(List<Entity> entityList)
        {
            foreach (Entity entity in entityList)
            {
                if ((entity.Mask & MASK) == MASK)
                {
                    List<IComponent> components = entity.Components;

                    IComponent skyboxComponent = components.Find(delegate (IComponent component)
                    {
                        return component.ComponentType == ComponentTypes.COMPONENT_SKYBOX;
                    });

                    IComponent positionComponent = components.Find(delegate (IComponent component)
                    {
                        return component.ComponentType == ComponentTypes.COMPONENT_POSITION;
                    });

                    updateSkybox((ComponentPosition)positionComponent, (ComponentSkyBox)skyboxComponent);
                }
            }
        }

        public void reset()
        {
        }

        public void updateSkybox(ComponentPosition position, ComponentSkyBox skyBox)
        {
            position.Position = camera.cameraPosition;
        }
    }


}
