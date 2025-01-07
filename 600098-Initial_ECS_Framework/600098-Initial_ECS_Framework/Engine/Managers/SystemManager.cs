using System.Collections.Generic;
using OpenGL_Game.Engine.Systems;
using OpenGL_Game.Engine.Objects;

namespace OpenGL_Game.Engine.Managers
{
    class SystemManager
    {
        List<ISystem> systemList = new List<ISystem>();

        public SystemManager()
        {
        }

        public void ActionSystems(EntityManager entityManager)
        {
            List<Entity> entityList = entityManager.Entities();
            foreach (ISystem system in systemList)
            {
                system.OnAction(entityList);
            }
        }

        public void AddSystem(ISystem system)
        {
            //ISystem result = FindSystem(system.Name);
            //Debug.Assert(result != null, "System '" + system.Name + "' already exists");
            systemList.Add(system);
        }

        public ISystem FindSystem(string name)
        {
            return systemList.Find(delegate (ISystem system)
            {
                return system.Name == name;
            }
            );
        }

        public void resetSystem(string name)
        {
            FindSystem(name).reset();
        }
    }
}
