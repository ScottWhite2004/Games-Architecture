using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Input;
using Microsoft.VisualBasic.Devices;

namespace OpenGL_Game.Managers
{
    internal class OpenTKInputManager : InputManager
    {

        public List<Keys> inputList;

        public OpenTKInputManager()
        {
            inputList = new List<Keys>();
        }
        
        public void addInput(Keys input)
        {
            
        }

        public override void processInputs()
        {
            if(KeyboardState)
        }

        public void removeInput(Keys input)
        {
            
        }
    }
}
