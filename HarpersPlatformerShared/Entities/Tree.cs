using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoEngine;

namespace HarpersPlatformer.Entities;

public class Tree : LevelCanvasEntity
{
	public Tree(int x, int y) {
		this.Depth = BackgroundImage.DefaultDepth;
		this.Position = new Vector2(x, y);

		var tree_region = new Region(Engine.Game.Content.Load<Texture2D>("textures/tree_1"));
		tree_region.AutoOrigin(DrawFrom.BottomCenter);
		this.AddSprite("main", new Sprite(tree_region));
	}
}
