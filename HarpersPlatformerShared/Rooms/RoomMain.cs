using System.Collections.Generic;
using HarpersPlatformer.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoEngine;

namespace HarpersPlatformer.Rooms
{
    public class RoomMain : Room
    {
        public override void onSwitchTo(Room previousRoom, Dictionary<string, object> args)
        {
            var levelCanvas = new LevelCanvas(5000, 10000);
            Engine.SpawnInstance(levelCanvas);
            Engine.SpawnInstance<Player>();
            Engine.SpawnInstance<Butterfly>();
            Engine.SpawnInstance<RespawnControl>();
            Engine.SpawnInstance<ControlReset>();

            for (int i = 0; i < 5; i++)
            {
                var region = new Region(Engine.Game.Content.Load<Texture2D>("textures/ground_1"));
                var sprite = new Sprite(region);
                if (i == 1 || i == 3)
                {
                    sprite.SpriteEffects = SpriteEffects.FlipHorizontally;
                }
                var ground = new BackgroundImage(sprite)
                {
                    Position = new Vector2(i * region.GetWidth(), levelCanvas.OthersRenderTarget.Height - region.GetHeight())
                };
                Engine.SpawnInstance(ground);
            }

            var treeSprite = new Sprite(new Region(Engine.Game.Content.Load<Texture2D>("textures/tree_1")))
            {
                Scale = new Vector2(0.6f)
            };
            var tree = new BackgroundImage(treeSprite)
            {
                Position = new Vector2(800, 550 + 8920)
            };
            Engine.SpawnInstance(tree);
        }

        public override void onSwitchAway(Room nextRoom)
        {
        }

        private class ControlReset : Entity
        {
            public override void onKeyDown(KeyboardEventArgs e) {
                base.onKeyDown(e);
                if (e.Key == Keys.R)
                    Engine.ResetRoom();
            }
        }
    }
}
