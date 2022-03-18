using Microsoft.Xna.Framework.Graphics;
using MonoEngine;

namespace HarpersPlatformer.Entities
{
    public class BackgroundImage : LevelCanvasEntity
    {
        public const int DefaultDepth = 1000;

        public BackgroundImage(Sprite sprite)
        {
            Depth = BackgroundImage.DefaultDepth;
            AddSprite("main", sprite);
        }

        public override void onUpdate(float deltaTime)
        {
            base.onUpdate(deltaTime);

            var levelCanvas = Engine.GetFirstInstanceByType<LevelCanvas>();
            if (levelCanvas != null)
            {
                RenderTarget = levelCanvas;
            }
        }
    }
}
