using OpenGL_Game.Managers;
using OpenGL_Game.OBJLoader;
using OpenGL_Game.Scenes;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_Game.Components
{
    abstract class ComponentShaderNoLight : ComponentShader
    {
        public int uniform_stex;
        public int uniform_mmodelviewproj;
        public int uniform_mmodel;
        public int uniform_diffuse;
        
        protected ComponentShaderNoLight() : base("Shaders/text.vert", "Shaders/text.frag")
        {

        }

        public override void ApplyShader(Matrix4 model, Geometry geometry, GameScene scene)
        {
            
        }
    }
}
