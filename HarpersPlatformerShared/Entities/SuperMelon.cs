using HarpersPlatformer.HarpersPlatformerShared.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoEngine;

namespace HarpersPlatformer.Entities;

public class SuperMelon : LevelCanvasEntity, IMelon
{
	public int Value { get; } = 1;

	public SuperMelon(int x, int y) {
		this.Position = new Vector2(x, y);

		// Add texture
		var texture = Engine.Game.Content.Load<Texture2D>("textures/super_melon");
		var sprite = new Sprite(new Region(texture) {
			Origin = new Vector2(texture.Width / 2f, texture.Height / 2f)
		});
		this.AddSprite("main", sprite);

		this.AddColliderCircle("main", texture.Width / 2f, 0, 0);
	}
}
