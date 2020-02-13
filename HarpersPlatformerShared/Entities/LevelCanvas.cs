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
                if (-player.Position.X + Player.MaxX < this.Position.X)
                    Position.X = -player.Position.X + Player.MaxX;
                else if (-player.Position.X + Player.MinX > this.Position.X)
                    Position.X = -player.Position.X + Player.MinX;

                if (-player.Position.Y + Player.MaxY < this.Position.Y) {
                    Position.Y = -player.Position.Y + Player.MaxY;
                    if (this.Position.Y < -this.OthersRenderTarget.Height + 1080)
                        this.Position.Y = -this.OthersRenderTarget.Height + 1080;
                }
                else if (-player.Position.Y + Player.MinY > this.Position.Y) {
                    Position.Y = -player.Position.Y + Player.MinY;
                    if (this.Position.Y > 0)
                        this.Position.Y = 0;
                }

            }
        }
    }
}
