using OpenGL_Game.Components;
using OpenGL_Game.Managers;
using OpenGL_Game.Objects;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_Game.Systems
{
    internal class SystemCollisionCameraSphere : ISystem
    {
        Camera _camera;
        CollisionManager _collisionManager;

        const ComponentTypes MASK = (ComponentTypes.COMPONENT_POSITION | ComponentTypes.COMPONENT_COLLISIONSPHERE);

        public SystemCollisionCameraSphere(Camera pCamera, CollisionManager pManager)
        {
            _camera = pCamera;
            _collisionManager = pManager;
        }
        public string Name
        {
            get { return "SystemCollisionCameraSphere"; }
        }

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

                    IComponent sphereCollisionComponent = components.Find(delegate (IComponent component)
                    {
                        return component.ComponentType == ComponentTypes.COMPONENT_COLLISIONSPHERE;
                    });
                    hasCollided(((ComponentPosition)positionComponent).Position, _camera.cameraPosition, ((ComponentCollisionSphere)sphereCollisionComponent).Radius);
                }
            }


        }

        public bool hasCollided(Vector3 spherePosition, Vector3 cameraPosition, float sphereRadius)
        {
            if((spherePosition - cameraPosition).Length < sphereRadius)
            {
                return true;
            }
            return false;
        }
    }
}
