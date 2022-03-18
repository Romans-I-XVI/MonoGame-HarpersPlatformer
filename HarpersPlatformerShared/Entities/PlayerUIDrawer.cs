using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoEngine;

namespace HarpersPlatformer.Entities;

public class PlayerUIDrawer : Entity
{
	private Player Player = null;
	private readonly SpriteFont Font = Engine.Game.Content.Load<SpriteFont>("fonts/DINPro");
	private readonly Vector2 CoinPosition = new Vector2(75, 60);

	public PlayerUIDrawer() {
		this.Player = Engine.GetFirstInstanceByType<Player>();
	}

	public override void onUpdate(float dt) {
		base.onUpdate(dt);

		if (this.Player == null || this.Player.IsExpired) {
			this.Player = Engine.GetFirstInstanceByType<Player>();
		}
	}

	public override void onDraw(SpriteBatch sprite_batch) {
		base.onDraw(sprite_batch);

		sprite_batch.DrawString(this.Font, "Coins: " + this.Player.Coins.ToString(), this.CoinPosition, Color.Black);
	}
}
