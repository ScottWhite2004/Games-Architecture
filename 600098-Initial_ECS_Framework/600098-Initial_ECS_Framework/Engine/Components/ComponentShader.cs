using OpenGL_Game.Engine.Managers;
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
    abstract class ComponentShader : IComponent
    {
        public ComponentTypes ComponentType
        { get { return ComponentTypes.COMPONENT_SHADER; } }

        public int pgmID;

        public ComponentShader(string vertexShaderName, string fragmentShaderName)
        {
            pgmID = GL.CreateProgram();
            GL.AttachShader(pgmID, ResourceManager.LoadShaders(vertexShaderName, ShaderType.VertexShader));
            GL.AttachShader(pgmID, ResourceManager.LoadShaders(fragmentShaderName, ShaderType.FragmentShader));
            GL.LinkProgram(pgmID);
        }

        public abstract void ApplyShader(Matrix4 model, Geometry geometry, GameScene scene);

        public void Close()
        {
        }
    }
}
