using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoEngine;

namespace HarpersPlatformer.Entities;

public class Tree : LevelCanvasEntity
{

	public Tree(Trees tree, int x, int y, float scale = 1f) {
		this.Depth = BackgroundImage.DefaultDepth;
		this.Position = new Vector2(x, y);

		var tree_region = new Region(Engine.Game.Content.Load<Texture2D>("textures/" + tree));
		tree_region.AutoOrigin(DrawFrom.BottomCenter);
		var tree_sprite = new Sprite(tree_region) {
			Scale = new Vector2(scale)
		};
		this.AddSprite("main", tree_sprite);
	}
}

public enum Trees
{
	tree_short,
	tree_tall
}
