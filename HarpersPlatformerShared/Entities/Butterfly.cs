using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoEngine;

namespace HarpersPlatformer.Entities
{
    public class Butterfly : LevelCanvasEntity
    {
        private Oscillator _oscillatorX;
        private Oscillator _oscillatorY;
        public Butterfly()
        {
            // Add texture
            var texture = Engine.Game.Content.Load<Texture2D>("textures/butterfly1");
            var sprite = new Sprite(new Region(texture));
            AddSprite("main", sprite);

            _oscillatorX = new Oscillator(500, 1500, 2000, Tween.SinusoidalTween);
            _oscillatorY = new Oscillator(300, 600, 500, Tween.SinusoidalTween);
            Position = new Vector2(500, 300);

            AddColliderRectangle("main", 0, 0, sprite.Region.GetWidth(), sprite.Region.GetHeight());
        }

        public override void onUpdate(float deltaTime)
        {
            base.onUpdate(deltaTime);
            _oscillatorX.Update();
            _oscillatorY.Update();
            Position.X = _oscillatorX.Tweener.Current;
            Position.Y = _oscillatorY.Tweener.Current;
        }
    }
}
