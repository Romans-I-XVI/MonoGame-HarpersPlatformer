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
            var levelCanvas = new LevelCanvas(10000, 10000);
            Engine.SpawnInstance(levelCanvas);
            Engine.SpawnInstance<Player>();
            Engine.SpawnInstance<PlayerUIDrawer>();
            Engine.SpawnInstance<Butterfly>();
            Engine.SpawnInstance<RespawnControl>();
            Engine.SpawnInstance<ControlReset>();
            Engine.SpawnInstance<ControlFullscreen>();

            for (int i = 0; i < 15; i++)
            {
                var region = new Region(Engine.Game.Content.Load<Texture2D>("textures/ground_1"));
                var sprite = new Sprite(region);
                if (i % 2 != 0)
                {
                    sprite.SpriteEffects = SpriteEffects.FlipHorizontally;
                }
                var ground = new BackgroundImage(sprite)
                {
                    Position = new Vector2(i * region.GetWidth(), levelCanvas.OthersRenderTarget.Height - region.GetHeight())
                };
                Engine.SpawnInstance(ground);
            }

            Engine.SpawnInstance(new Castle(1315, 8032));

            // Add trees
            Engine.SpawnInstance(new Tree(Trees.tree_short, 985, 9976));
            Engine.SpawnInstance(new Tree(Trees.tree_tall, 1282, 9924));
            Engine.SpawnInstance(new Tree(Trees.tree_short, 1527, 9969));
            Engine.SpawnInstance(new Tree(Trees.tree_short, 1842, 9935));
            Engine.SpawnInstance(new Tree(Trees.tree_tall, 2094, 9987));

            // Add melons
            Engine.SpawnInstance(new SuperMelon(1216, 9606));
            Engine.SpawnInstance(new SuperMelon(1323, 9682));
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
