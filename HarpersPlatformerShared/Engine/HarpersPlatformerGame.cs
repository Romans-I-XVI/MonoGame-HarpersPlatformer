using HarpersPlatformer.Rooms;
using Microsoft.Xna.Framework;

namespace MonoEngine
{
    public class HarpersPlatformerGame : EngineGame
    {
        public HarpersPlatformerGame() : base(1920, 1080, 0, 0)
        {
            BackgroundColor = Color.WhiteSmoke;
            IsFixedTimeStep = false;
            Graphics.SynchronizeWithVerticalRetrace = false;
            Graphics.HardwareModeSwitch = false;
            Window.AllowAltF4 = true;
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            Engine.SpawnInstance<Debugger>();
            Engine.ChangeRoom<RoomMain>();
        }
    }
}
