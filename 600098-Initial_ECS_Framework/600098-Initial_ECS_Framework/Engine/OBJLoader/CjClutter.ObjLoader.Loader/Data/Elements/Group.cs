﻿using System.Collections.Generic;
using OpenGL_Game.Engine.OBJLoader.CjClutter.ObjLoader.Loader.Data;
using OpenGL_Game.Engine.OBJLoader.CjClutter.ObjLoader.Loader.Data.DataStore;

namespace OpenGL_Game.Engine.OBJLoader.CjClutter.ObjLoader.Loader.Data.Elements
{
    public class Group : IFaceGroup
    {
        private readonly List<Face> _faces = new List<Face>();

        public Group(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
        public Material Material { get; set; }

        public IList<Face> Faces { get { return _faces; } }

        public void AddFace(Face face)
        {
            _faces.Add(face);
        }
    }
}