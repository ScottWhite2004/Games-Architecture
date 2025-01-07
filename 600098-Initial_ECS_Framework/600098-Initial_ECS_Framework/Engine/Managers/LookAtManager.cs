using OpenGL_Game.Engine.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_Game.Engine.Managers
{
    abstract class LookAtManager
    {
        protected List<Entity> lookAtList = new List<Entity>();
        protected List<Entity> lookAwayList = new List<Entity>();

        public LookAtManager()
        {

        }

        public void clearLookAt()
        {
            lookAtList.Clear();
        }

        public void clearLookAway()
        {
            lookAwayList.Clear();
        }

        public void addLook(Entity entity)
        {
            lookAtList.Add(entity);
        }

        public void addLookAway(Entity entity)
        {
            lookAwayList.Add(entity);
        }

        public abstract void processLooking();

    }
}
