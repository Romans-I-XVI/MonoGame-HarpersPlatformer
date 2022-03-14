using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoEngine;

namespace HarpersPlatformer.Entities
{
    public class Player : LevelCanvasEntity
    {
        public const float MoveSpeed = 15;
        private const int StartX = 350;
        private const int StartY = 10000 - 42;
        private const int EdgeBuffer = 100;
        private const float JumpSpeed = -30f;
        private const float Gravity = 2.5f;
        private const float MaxFallSpeed = 15f;
        public bool Invincible = false;

        private VirtualButton _buttonMoveRight;
        private VirtualButton _buttonMoveLeft;
        private VirtualButton _buttonJump;

        public Player() {
            Position = new Vector2(Player.StartX, Player.StartY);

            // Add texture
            var texture = Engine.Game.Content.Load<Texture2D>("textures/player");
            var sprite = new Sprite(new Region(texture) {
                Origin = new Vector2(texture.Width / 2f, texture.Height)
            });
            AddSprite("main", sprite);

            _buttonMoveRight = new VirtualButton();
            _buttonMoveRight.AddKey(Keys.D);
            _buttonMoveRight.AddKey(Keys.Right);
            _buttonMoveRight.AddButton(Buttons.DPadRight);

            _buttonMoveLeft = new VirtualButton();
            _buttonMoveLeft.AddKey(Keys.A);
            _buttonMoveLeft.AddKey(Keys.Left);
            _buttonMoveLeft.AddButton(Buttons.DPadLeft);

            _buttonJump = new VirtualButton();
            _buttonJump.AddKey(Keys.Space);
            _buttonJump.AddButton(Buttons.A);

            AddColliderRectangle("main", -texture.Width / 2, -texture.Height, sprite.Region.GetWidth(), sprite.Region.GetHeight());
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

            if (Position.X < Player.EdgeBuffer)
            {
                Position.X = Player.EdgeBuffer;
            }
            else if (RenderTarget != null && Position.X > RenderTarget.OthersRenderTarget.Width - Player.EdgeBuffer)
            {
                Position.X = RenderTarget.OthersRenderTarget.Width - Player.EdgeBuffer;
            }

            // Jump if pressed
            if (this._buttonJump.IsPressed()) {
                this.Speed.Y = Player.JumpSpeed;
            }

            // Update Y speed based on gravity
            this.Speed.Y += Player.Gravity * 60 * deltaTime;
            if (this.Speed.Y > Player.MaxFallSpeed)
                this.Speed.Y = Player.MaxFallSpeed;
            if (this.Position.Y >= Player.StartY && this.Speed.Y > 0) {
                this.Position.Y = Player.StartY;
                this.Speed.Y = 0;
            }
        }

        public override void onCollision(Collider collider, Collider otherCollider, Entity otherInstance)
        {
            base.onCollision(collider, otherCollider, otherInstance);
            if (!this.Invincible) {
                this.IsExpired = true;
            }
        }
    }
}
