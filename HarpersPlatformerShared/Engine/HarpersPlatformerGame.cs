using HarpersPlatformer.Rooms;
using Microsoft.Xna.Framework;

namespace MonoEngine
{
    public class HarpersPlatformerGame : EngineGame
    {
        public HarpersPlatformerGame() : base(1920, 1080, 0, 0)
        {
            BackgroundColor = new Color(0x99, 0xCC, 0xFF);
            IsFixedTimeStep = false;
            Graphics.SynchronizeWithVerticalRetrace = false;
            Graphics.HardwareModeSwitch = false;
            Window.AllowAltF4 = true;
            this.Graphics.IsFullScreen = true;
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            Engine.SpawnInstance<Debugger>();
            Engine.ChangeRoom<RoomMain>();
        }
    }
}
