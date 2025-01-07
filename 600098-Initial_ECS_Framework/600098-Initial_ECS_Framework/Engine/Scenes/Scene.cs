using OpenTK.Windowing.Common;
using OpenGL_Game.Game.Managers;

namespace OpenGL_Game.Engine.Scenes
{
    abstract class Scene
    {
        protected SceneManager sceneManager;

        public enum SceneTypes
        {
            SCENE_NON,
            SCENE_MAIN_MENU,
            SCENE_GAME,
            SCENE_GAME_OVER,
            SCENE_HIGH_SCORE,
            SCENE_ENTER_INITIALS,
        }


        public Scene(SceneManager sceneManager)
        {
            this.sceneManager = sceneManager;
        }

        public abstract void Render(FrameEventArgs e);

        public abstract void Update(FrameEventArgs e);

        public abstract void Close();
    }
}
