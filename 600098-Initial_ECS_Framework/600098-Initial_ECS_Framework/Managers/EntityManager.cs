﻿using System.Collections.Generic;
using OpenGL_Game.Components;
using OpenGL_Game.Objects;
//using System.Diagnostics;

namespace OpenGL_Game.Managers
{
    class EntityManager
    {
        List<Entity> entityList;

        public EntityManager()
        {
            entityList = new List<Entity>();
        }

        public void AddEntity(Entity entity)
        {
            //Entity result = FindEntity(entity.Name);
            //Debug.Assert(result == null, "Entity '" + entity.Name + "' already exists");
            entityList.Add(entity);
        }

        public Entity FindEntity(string name)
        {
            return entityList.Find(delegate(Entity e)
            {
                return e.Name == name;
            }
            );
        }

        public List<Entity> Entities()
        {
            return entityList;
        }

        public void Clear()
        {
            foreach (Entity entity in entityList)
            {
                foreach(IComponent component in entity.Components)
                {
                    component.Close();
                }
            }
        }
    }
}
