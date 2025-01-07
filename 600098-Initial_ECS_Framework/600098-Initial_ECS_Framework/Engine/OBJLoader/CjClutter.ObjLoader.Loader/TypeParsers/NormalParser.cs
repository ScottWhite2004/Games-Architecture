using OpenGL_Game.Engine.OBJLoader.CjClutter.ObjLoader.Loader.Data;
using OpenGL_Game.Engine.OBJLoader.CjClutter.ObjLoader.Loader.Data.VertexData;
using OpenGL_Game.Engine.OBJLoader.CjClutter.ObjLoader.Loader.Common;
using OpenGL_Game.Engine.OBJLoader.CjClutter.ObjLoader.Loader.Data.DataStore;
using OpenGL_Game.Engine.OBJLoader.CjClutter.ObjLoader.Loader.TypeParsers.Interfaces;

namespace OpenGL_Game.Engine.OBJLoader.CjClutter.ObjLoader.Loader.TypeParsers
{
    public class NormalParser : TypeParserBase, INormalParser
    {
        private readonly INormalDataStore _normalDataStore;

        public NormalParser(INormalDataStore normalDataStore)
        {
            _normalDataStore = normalDataStore;
        }

        protected override string Keyword
        {
            get { return "vn"; }
        }

        public override void Parse(string line)
        {
            string[] parts = line.Split(' ');

            float x = parts[0].ParseInvariantFloat();
            float y = parts[1].ParseInvariantFloat();
            float z = parts[2].ParseInvariantFloat();

            var normal = new Normal(x, y, z);
            _normalDataStore.AddNormal(normal);
        }
    }
}