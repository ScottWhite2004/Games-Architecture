using OpenGL_Game.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_Game.Managers
{
    internal class MazeLookAtManager : LookAtManager
    {
        public override void processLooking()
        {
            clearLookAt();
            clearLookAway();
            foreach(Entity entity in lookAtList)
            {
                if(entity.Name == "Drone")
                {
                    playSound();
                }
            }
            foreach(Entity entity in lookAwayList)
            {
                if(entity.Name == "Drone")
                {
                    stopSound();
                }
            }
        }

        public void playSound()
        {

        }

        public void stopSound()
        {

        }
    }


}
