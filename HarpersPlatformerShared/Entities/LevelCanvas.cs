using MonoEngine;

namespace HarpersPlatformer.Entities
{
    public class LevelCanvas : RenderCanvas
    {
        private const int PlayerMinY = 250;
        private const int PlayerMaxY = 1080 / 2 + 100;
        private const int PlayerMinX = 1920 / 3;
        private const int PlayerMaxX = 1920 - 1920 / 3;

        public LevelCanvas(int width, int height) : base(width, height)
        {

        }

        public override void onUpdate(float deltaTime)
        {
            base.onUpdate(deltaTime);
            var player = Engine.GetFirstInstanceByType<Player>();
            if (player != null)
            {
                if (-player.Position.X + LevelCanvas.PlayerMaxX < this.Position.X) {
                    Position.X = -player.Position.X + LevelCanvas.PlayerMaxX;
                    if (this.Position.X < -this.OthersRenderTarget.Width + 1920)
                        this.Position.X = -this.OthersRenderTarget.Width + 1920;
                } else if (-player.Position.X + LevelCanvas.PlayerMinX > this.Position.X) {
                    Position.X = -player.Position.X + LevelCanvas.PlayerMinX;
                    if (this.Position.X > 0)
                        this.Position.X = 0;
                }

                if (-player.Position.Y + LevelCanvas.PlayerMaxY < this.Position.Y) {
                    Position.Y = -player.Position.Y + LevelCanvas.PlayerMaxY;
                    if (this.Position.Y < -this.OthersRenderTarget.Height + 1080)
                        this.Position.Y = -this.OthersRenderTarget.Height + 1080;
                }
                else if (-player.Position.Y + LevelCanvas.PlayerMinY > this.Position.Y) {
                    Position.Y = -player.Position.Y + LevelCanvas.PlayerMinY;
                    if (this.Position.Y > 0)
                        this.Position.Y = 0;
                }

            }
        }
    }
}
