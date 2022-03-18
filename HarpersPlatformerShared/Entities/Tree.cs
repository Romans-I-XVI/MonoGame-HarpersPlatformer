using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoEngine;

namespace HarpersPlatformer.Entities;

public class Tree : LevelCanvasEntity
{
	private readonly int PlatformOffsetX = -85;
	private readonly int PlatformWidth = 168;
	private readonly int PlatformHeight = 50;
	private readonly Dictionary<Trees, int> PlatformOffsetsY = new Dictionary<Trees, int> {
		[Trees.tree_short] = -279,
		[Trees.tree_tall] = -279 - 66
	};
	private readonly int PlatformOffsetY;
	private readonly Platform Platform;

	public Tree(Trees tree, int x, int y, float scale = 1f) {
		this.Depth = BackgroundImage.DefaultDepth;
		this.Position = new Vector2(x, y);
		this.PlatformOffsetY = this.PlatformOffsetsY[tree];

		var tree_region = new Region(Engine.Game.Content.Load<Texture2D>("textures/" + tree));
		tree_region.AutoOrigin(DrawFrom.BottomCenter);
		var tree_sprite = new Sprite(tree_region) {
			Scale = new Vector2(scale)
		};
		this.AddSprite("main", tree_sprite);

		var platform_rect = new Rectangle(
			(int)this.Position.X + this.PlatformOffsetX,
			(int)this.Position.Y + this.PlatformOffsetY,
			this.PlatformWidth,
			this.PlatformHeight
		);
		this.Platform = new Platform(platform_rect);
		Engine.SpawnInstance(this.Platform);
	}

	public override void onUpdate(float deltaTime) {
		base.onUpdate(deltaTime);

		this.Platform.Position.X = this.Position.X + this.PlatformOffsetX;
		this.Platform.Position.Y = this.Position.Y + this.PlatformOffsetY;
	}

	public override void onDestroy() {
		base.onDestroy();
		this.Platform.IsExpired = true;
	}
}

public enum Trees
{
	tree_short,
	tree_tall
}
