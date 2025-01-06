using System;

namespace OpenGL_Game.Components
{
    [FlagsAttribute]
    enum ComponentTypes {
        COMPONENT_NONE     = 0,
	    COMPONENT_POSITION = 1 << 0,
        COMPONENT_GEOMETRY = 1 << 1,
        COMPONENT_VELOCITY = 1 << 2,
        COMPONENT_SHADER = 1 << 3,
        COMPONENT_AUDIO = 1 << 4,
        COMPONENT_COLLISIONSPHERE = 1 << 5,
        COMPONENT_COLLISIONAABB = 1 << 6,
        COMPONENT_FOLLOW = 1 << 7,
        COMPONENT_KEYBOARDMOVEMENT = 1 << 8,
        COMPONENT_AIDIRECTPATH = 1 << 9,
        COMPONENT_SKYBOX = 1 << 10,
        COMPONENT_AIPATHFINDING = 1 << 11,
        COMPONENT_PATHPOINT = 1 << 12,
        COMPONENT_ROAMING = 1 << 13,
        COMPONENT_ROAMINGPOINT = 1 << 14,
        COMPONENT_BOUNCING = 1 << 15,
        COMPONENT_MOVEBACKFORTH = 1 << 16,
        COMPONENT_CAMERALOOKAT = 1 << 17,
        COMPONENT_BOUNCEBACKFORWARD = 1 << 18,
    }

    interface IComponent
    {
        ComponentTypes ComponentType
        {
            get;
        }

        public void Close();
    }
}
