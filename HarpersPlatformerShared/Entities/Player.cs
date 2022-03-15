using System;
using HarpersPlatformer.HarpersPlatformerShared.Interfaces;
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
        private readonly Rectangle ColliderRectangle = new Rectangle(36, 1, 62, 158);
        public bool Invincible = false;

        private VirtualButton _buttonMoveRight;
        private VirtualButton _buttonMoveLeft;
        private VirtualButton _buttonJump;

        private ColliderRectangle MainCollider;

        public Player() {
            this.Position = new Vector2(Player.StartX, Player.StartY);

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

            AddColliderRectangle("main", -texture.Width / 2 + this.ColliderRectangle.X, -texture.Height + this.ColliderRectangle.Y, this.ColliderRectangle.Width, this.ColliderRectangle.Height);
            this.MainCollider = (ColliderRectangle)this.GetCollider("main");
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

            if (otherInstance is IEnemy) {
                this.OnCollisionWithEnemy();
            } else if (otherInstance is Platform) {
                this.OnCollisionWithPlatform((Platform)otherInstance);
            }
        }

        private void OnCollisionWithEnemy() {
            if (!this.Invincible) {
                this.IsExpired = true;
            }
        }

        private void OnCollisionWithPlatform(Platform platform) {
            System.Diagnostics.Debug.WriteLine("OnCollisionWithPlatform");

            const float collision_threshold = 20;
            float feet_y = this.Position.Y + this.MainCollider.Offset.Y + this.MainCollider.Height;
            float platform_y = platform.Position.Y;
            if (this.Speed.Y > 0 && Math.Abs(feet_y - platform_y) < collision_threshold) {
                this.Speed.Y = 0;
                this.Position.Y = platform_y + (this.Position.Y - feet_y);
                System.Diagnostics.Debug.WriteLine("SetPosition");
            }
        }
    }
}
