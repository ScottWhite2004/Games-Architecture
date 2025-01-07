using OpenGL_Game.Engine.OBJLoader;
using OpenGL_Game.Game.Scenes;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_Game.Engine.Components
{
    abstract class ComponentShaderNoLight : ComponentShader
    {
        public int uniform_stex;
        public int uniform_mmodelviewproj;
        public int uniform_mmodel;
        public int uniform_diffuse;

        protected ComponentShaderNoLight() : base("Engine/Shaders/text.vert", "Engine/Shaders/text.frag")
        {

        }

        public override void ApplyShader(Matrix4 model, Geometry geometry, GameScene scene)
        {

        }
    }
}
