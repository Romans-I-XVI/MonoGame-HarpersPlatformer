using MonoEngine;

namespace HarpersPlatformer.Entities
{
    public class LevelCanvas : RenderCanvas
    {
        public LevelCanvas(int width, int height) : base(width, height)
        {

        }

        public override void onUpdate(float deltaTime)
        {
            base.onUpdate(deltaTime);
            var player = Engine.GetFirstInstanceByType<Player>();
            if (player != null)
            {
                Position.X = -player.Position.X + Player.PlayerStartX;
                Position.Y = -player.Position.Y + Player.PlayerStartY;
            }
        }
    }
}
