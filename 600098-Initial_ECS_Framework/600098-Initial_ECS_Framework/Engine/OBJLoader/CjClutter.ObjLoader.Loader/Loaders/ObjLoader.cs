﻿using System.Collections.Generic;
using System.IO;
using OpenGL_Game.Engine.OBJLoader.CjClutter.ObjLoader.Loader.Data.DataStore;
using OpenGL_Game.Engine.OBJLoader.CjClutter.ObjLoader.Loader.TypeParsers.Interfaces;

namespace OpenGL_Game.Engine.OBJLoader.CjClutter.ObjLoader.Loader.Loaders
{
    public class ObjLoader : LoaderBase, IObjLoader
    {
        private readonly IDataStore _dataStore;
        private readonly List<ITypeParser> _typeParsers = new List<ITypeParser>();

        private readonly List<string> _unrecognizedLines = new List<string>();

        public static string _path;

        public void SetPath(string path)
        {
            _path = path;
        }

        public static string GetPath()
        {
            return _path;
        }



        public ObjLoader(
            IDataStore dataStore,
            IFaceParser faceParser,
            IGroupParser groupParser,
            INormalParser normalParser,
            ITextureParser textureParser,
            IVertexParser vertexParser,
            IMaterialLibraryParser materialLibraryParser,
            IUseMaterialParser useMaterialParser)
        {
            _dataStore = dataStore;
            SetupTypeParsers(
                vertexParser,
                faceParser,
                normalParser,
                textureParser,
                groupParser,
                materialLibraryParser,
                useMaterialParser);
        }

        private void SetupTypeParsers(params ITypeParser[] parsers)
        {
            foreach (var parser in parsers)
            {
                _typeParsers.Add(parser);
            }
        }

        protected override void ParseLine(string keyword, string data)
        {
            foreach (var typeParser in _typeParsers)
            {
                if (typeParser.CanParse(keyword))
                {
                    typeParser.Parse(data);
                    return;
                }
            }

            _unrecognizedLines.Add(keyword + " " + data);
        }

        public LoadResult Load(Stream lineStream)
        {
            StartLoad(lineStream);

            return CreateResult();
        }

        private LoadResult CreateResult()
        {
            var result = new LoadResult
            {
                Vertices = _dataStore.Vertices,
                Textures = _dataStore.Textures,
                Normals = _dataStore.Normals,
                Groups = _dataStore.Groups,
                Materials = _dataStore.Materials
            };
            return result;
        }
    }
}