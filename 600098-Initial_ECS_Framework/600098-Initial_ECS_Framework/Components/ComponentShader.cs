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
    abstract class ComponentShader : IComponent
    {
        public ComponentTypes ComponentType
        { get { return ComponentTypes.COMPONENT_SHADER; } }

        public int pgmID;

        public ComponentShader(string vertexShaderName, string fragmentShaderName)
        {
            pgmID = GL.CreateProgram();
            GL.AttachShader(pgmID, ResourceManager.LoadShaders(vertexShaderName,ShaderType.VertexShader));
            GL.AttachShader(pgmID, ResourceManager.LoadShaders(fragmentShaderName,ShaderType.FragmentShader));
            GL.LinkProgram(pgmID);
        }

        public abstract void ApplyShader(Matrix4 model, Geometry geometry, GameScene scene);

    }
}
