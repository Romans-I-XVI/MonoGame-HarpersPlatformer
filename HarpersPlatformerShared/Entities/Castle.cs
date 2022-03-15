using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoEngine;

namespace HarpersPlatformer.Entities;

public class Castle : BackgroundImage
{
	private const int PlatformOffsetX = 12;
	private const int PlatformOffsetY = 520;
	private const int PlatformWidth = 650;
	private const int PlatformHeight = 94;
	private readonly Platform Platform;

	public Castle(int x, int y) : base(new Sprite(new Region(Engine.Game.Content.Load<Texture2D>("textures/castle")))) {
		this.Position = new Vector2(x, y);

		var platform_rect = new Rectangle(
			(int)this.Position.X + Castle.PlatformOffsetX,
			(int)this.Position.Y + Castle.PlatformOffsetY,
			Castle.PlatformWidth,
			Castle.PlatformHeight
			);
		this.Platform = new Platform(platform_rect);
		Engine.SpawnInstance(this.Platform);
	}

	public override void onUpdate(float deltaTime) {
		base.onUpdate(deltaTime);

		this.Platform.Position.X = this.Position.X + Castle.PlatformOffsetX;
		this.Platform.Position.Y = this.Position.Y + Castle.PlatformOffsetY;
	}

	public override void onDestroy() {
		base.onDestroy();
		this.Platform.IsExpired = true;
	}
}
