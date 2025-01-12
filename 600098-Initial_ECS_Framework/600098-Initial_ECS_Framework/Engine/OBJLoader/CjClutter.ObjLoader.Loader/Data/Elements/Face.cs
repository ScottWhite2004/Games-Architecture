﻿using System.Collections.Generic;

namespace OpenGL_Game.Engine.OBJLoader.CjClutter.ObjLoader.Loader.Data.Elements
{
    public class Face
    {
        private readonly List<FaceVertex> _vertices = new List<FaceVertex>();

        public void AddVertex(FaceVertex vertex)
        {
            _vertices.Add(vertex);
        }

        public FaceVertex this[int i]
        {
            get { return _vertices[i]; }
        }

        public FaceVertex GetVertex(int i)
        {
            return _vertices[i];
        }


        public int Count
        {
            get { return _vertices.Count; }
        }
    }

    public struct FaceVertex
    {
        public FaceVertex(int vertexIndex, int textureIndex, int normalIndex) : this()
        {
            VertexIndex = vertexIndex;
            TextureIndex = textureIndex;
            NormalIndex = normalIndex;
        }

        public int VertexIndex { get; set; }
        public int TextureIndex { get; set; }
        public int NormalIndex { get; set; }
    }
}