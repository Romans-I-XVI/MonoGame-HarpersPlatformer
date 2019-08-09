using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoEngine;

namespace HarpersPlatformer.Entities
{
    public class Player : Entity
    {
        public const float MoveSpeed = 10;

        private VirtualButton _buttonMoveRight;
        private VirtualButton _buttonMoveLeft;

        public Player()
        {
            Position = new Vector2(200, 700);

            // Add texture
            var texture = Engine.Game.Content.Load<Texture2D>("textures/player");
            var sprite = new Sprite(new Region(texture));
            AddSprite("main", sprite);

            _buttonMoveRight = new VirtualButton();
            _buttonMoveRight.AddKey(Keys.D);
            _buttonMoveRight.AddKey(Keys.Right);
            _buttonMoveRight.AddButton(Buttons.DPadRight);

            _buttonMoveLeft = new VirtualButton();
            _buttonMoveLeft.AddKey(Keys.A);
            _buttonMoveLeft.AddKey(Keys.Left);
            _buttonMoveLeft.AddButton(Buttons.DPadLeft);
        }

        public override void onUpdate(float deltaTime)
        {
            base.onUpdate(deltaTime);

            if (_buttonMoveRight.IsHeld())
            {
                Position.X += MoveSpeed * 60 * deltaTime;
            }
            else if (_buttonMoveLeft.IsHeld())
            {
                Position.X -= MoveSpeed * 60 * deltaTime;
            }
        }
    }
}
