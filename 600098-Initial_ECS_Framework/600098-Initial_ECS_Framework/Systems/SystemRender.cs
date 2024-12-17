using System;
using System.Collections.Generic;
using System.IO;
using OpenTK.Graphics.OpenGL;
using OpenGL_Game.Components;
using OpenGL_Game.OBJLoader;
using OpenGL_Game.Objects;
using OpenGL_Game.Scenes;
using OpenTK.Mathematics;

namespace OpenGL_Game.Systems
{
    class SystemRender : ISystem
    {
        const ComponentTypes MASK = (ComponentTypes.COMPONENT_POSITION | ComponentTypes.COMPONENT_GEOMETRY | ComponentTypes.COMPONENT_SHADER);

        //protected int pgmID;
        //protected int vsID;
        //protected int fsID;
        //protected int uniform_stex;
        //protected int uniform_mmodelviewproj;
        //protected int uniform_mmodel;
        //protected int uniform_diffuse;

        GameScene scene;

        public SystemRender(GameScene scene)
        {
            scene = this.scene;
            //pgmID = GL.CreateProgram();
            //LoadShader("Shaders/single-light.vert", ShaderType.VertexShader, pgmID, out vsID);
            //LoadShader("Shaders/single-light.frag", ShaderType.FragmentShader, pgmID, out fsID);
            //GL.LinkProgram(pgmID);

            //GL.GetProgram(pgmID, GetProgramParameterName.LinkStatus, out int success);
            //if (success == 0)
            //{
            //    string infoLog = GL.GetProgramInfoLog(pgmID);
            //    Console.WriteLine(infoLog);
            //}

            //Console.WriteLine(GL.GetProgramInfoLog(pgmID));

            //uniform_stex = GL.GetUniformLocation(pgmID, "s_texture");
            //uniform_mmodelviewproj = GL.GetUniformLocation(pgmID, "ModelViewProjMat");
            //uniform_mmodel = GL.GetUniformLocation(pgmID, "ModelMat");
            //uniform_diffuse = GL.GetUniformLocation(pgmID, "v_diffuse");
        }

        //void LoadShader(String filename, ShaderType type, int program, out int address)
        //{
        //    address = GL.CreateShader(type);
        //    using (StreamReader sr = new StreamReader(filename))
        //    {
        //        GL.ShaderSource(address, sr.ReadToEnd());
        //    }
        //    GL.CompileShader(address);


        //    GL.GetShader(address, ShaderParameter.CompileStatus, out int success);
        //    if (success == 0)
        //    {
        //        string infoLog = GL.GetShaderInfoLog(address);
        //        Console.WriteLine(infoLog);
        //    }

        //    GL.AttachShader(program, address);
        //}

        public string Name
        {
            get { return "SystemRender"; }
        }

        public void OnAction(List<Entity> entityList)
        {
            foreach (Entity entity in entityList)
            {
                if ((entity.Mask & MASK) == MASK)
                {
                    List<IComponent> components = entity.Components;

                    IComponent geometryComponent = components.Find(delegate (IComponent component)
                    {
                        return component.ComponentType == ComponentTypes.COMPONENT_GEOMETRY;
                    });
                    Geometry geometry = ((ComponentGeometry)geometryComponent).Geometry();

                    IComponent positionComponent = components.Find(delegate (IComponent component)
                    {
                        return component.ComponentType == ComponentTypes.COMPONENT_POSITION;
                    });
                    Vector3 position = ((ComponentPosition)positionComponent).Position;
                    Matrix4 model = Matrix4.CreateTranslation(position);

                    IComponent shaderComponent = components.Find(delegate (IComponent component)
                    {
                        return component.ComponentType == ComponentTypes.COMPONENT_SHADER;
                    });

                    ComponentShader shader = ((ComponentShader)shaderComponent);

                    Draw(model, geometry, shader);
                }
            }
        }

        public void Draw(Matrix4 model, Geometry geometry, ComponentShader shaderComponent)
        {
            //GL.UseProgram(pgmID);

            //GL.Uniform1(uniform_stex, 0);
            //GL.ActiveTexture(TextureUnit.Texture0);

            //GL.UniformMatrix4(uniform_mmodel, false, ref model);
            //Matrix4 modelViewProjection = model * GameScene.gameInstance.camera.view * GameScene.gameInstance.camera.projection;
            //GL.UniformMatrix4(uniform_mmodelviewproj, false, ref modelViewProjection);

            //geometry.Render(uniform_diffuse);

            //GL.UseProgram(0);
            shaderComponent.ApplyShader(model, geometry, scene);
        }

        public void reset()
        {
        }
    }
}
