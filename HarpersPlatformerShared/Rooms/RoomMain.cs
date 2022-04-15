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

            // Add coins
            Engine.SpawnInstance(new Coin(2088, 9639));
            // -- Star Formation
            Engine.SpawnInstance(new Coin(2746, 8370));
            Engine.SpawnInstance(new Coin(2944, 8343));
            Engine.SpawnInstance(new Coin(2800, 8445));
            Engine.SpawnInstance(new Coin(2752, 8501));
            Engine.SpawnInstance(new Coin(2739, 8230));
            Engine.SpawnInstance(new Coin(2654, 8305));
            Engine.SpawnInstance(new Coin(2844, 8295));
            Engine.SpawnInstance(new Coin(2557, 8350));
            Engine.SpawnInstance(new Coin(2742, 8311));
            Engine.SpawnInstance(new Coin(2657, 8373));
            Engine.SpawnInstance(new Coin(2690, 8451));
            Engine.SpawnInstance(new Coin(2844, 8370));
            // -- Castle Formation
            Engine.SpawnInstance(new Coin(1534, 8305));
            Engine.SpawnInstance(new Coin(1817, 8499));

            // Add dragons
            // Engine.SpawnInstance(new Dragon(Dragon.AvailableDragons.fire_dragon, new Vector2(1181, 7948), new Vector2(2080, 7948), 5000, Tween.SinusoidalTween));
            // Engine.SpawnInstance(new Dragon(Dragon.AvailableDragons.spike_dragon, new Vector2(2211, 7386), new Vector2(940, 7386), 5000, Tween.SinusoidalTween));
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
