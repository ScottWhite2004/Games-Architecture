using OpenGL_Game.Components;
using OpenGL_Game.Managers;
using OpenGL_Game.Objects;
using OpenTK.Graphics.ES11;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_Game.Systems
{
    internal class SystemCollisionPointInAABB : ISystem
    {
        CollisionManager _collisionManager;
        Vector3 _point;
        Camera _camera;

        const ComponentTypes MASK = (ComponentTypes.COMPONENT_POSITION | ComponentTypes.COMPONENT_COLLISIONAABB);

        public SystemCollisionPointInAABB(CollisionManager collisionManager, Camera camera)
        {
            _collisionManager = collisionManager;
            _camera = camera;
        }

        public string Name
        {
            get { return "SystemCollisionPointInAABB"; } 
        }

        public void OnAction(List<Entity> entityList)
        {
            _point = _camera.cameraPosition;
            foreach(Entity entity in entityList)
            {
                if((entity.Mask & MASK) == MASK)
                {
                    List<IComponent> components = new List<IComponent>();

                    IComponent aabbCollisionComponent = components.Find(delegate (IComponent component)
                    {
                        return component.ComponentType == ComponentTypes.COMPONENT_COLLISIONAABB;
                    });

                    if (hasCollided((ComponentCollisionAABB)aabbCollisionComponent, _point))
                    {
                        _collisionManager.CollisionBetweenCamera(entity, CollisionType.POINT_IN_AABB);
                    }

                }
            }
        }

        public bool hasCollided(ComponentCollisionAABB collisionAABB, Vector3 point)
        {
            if (point.X < collisionAABB.XMax && point.X > collisionAABB.XMin && point.Z < collisionAABB.ZMax && point.Z > collisionAABB.ZMin)
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
