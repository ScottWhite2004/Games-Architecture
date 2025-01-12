namespace OpenGL_Game.Engine.OBJLoader.CjClutter.ObjLoader.Loader.Data.VertexData
{
    public struct Normal
    {
        public Normal(float x, float y, float z) : this()
        {
            X = x;
            Y = y;
            Z = z;
        }

        public float X { get; private set; }
        public float Y { get; private set; }
        public float Z { get; private set; }
    }
}