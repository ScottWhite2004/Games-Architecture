using OpenGL_Game.Managers;
using OpenTK.Audio.OpenAL;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_Game.Components
{
    internal class ComponentAudio : IComponent
    {
        int audioSource;
        int audioBuffer;
        public ComponentAudio(string audioName, bool isTriggered)
        {
            audioBuffer = ResourceManager.LoadAudio(audioName);
            audioSource = AL.GenSource();
            AL.Source(audioSource, ALSourcei.Buffer, audioBuffer); // attach the buffer to a source
            AL.Source(audioSource, ALSourceb.Looping, !isTriggered); // source loops infinitely
            Vector3 sourcePosition = new Vector3(-2.0f, 0.0f, 0.0f); // place the source a position at the centre of the Moon
            AL.Source(audioSource, ALSource3f.Position, ref sourcePosition);
            if (!isTriggered)
            {
                AL.SourcePlay(audioSource);// play the ausio source
            }
        }

        public ComponentTypes ComponentType
        {
            get { return ComponentTypes.COMPONENT_AUDIO; }
        }
        public void Play()
        {
            AL.SourcePlay(audioSource);
        }

        public void Stop()
        {
            AL.SourceStop(audioSource);
        }

        public void Close()
        {
            Stop();
        }

        public void setPosition(Vector3 emitterPosition)
        {
            AL.Source(audioSource, ALSource3f.Position, ref emitterPosition);
        }
    }
}
