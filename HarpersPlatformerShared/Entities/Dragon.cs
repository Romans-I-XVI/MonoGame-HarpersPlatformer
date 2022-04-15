using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoEngine;

namespace HarpersPlatformer.Entities;

public class Dragon : LevelCanvasEntity
{
	private readonly Oscillator OscillatorX;
	private readonly Oscillator OscillatorY;
	private float PreviousX;

	public Dragon(AvailableDragons dragon, Vector2 position_1, Vector2 position_2, int move_duration, Tween move_tween)
	{
		// Add texture
		var texture = Engine.Game.Content.Load<Texture2D>("textures/" + dragon);
		var sprite = new Sprite(new Region(texture));
		AddSprite("main", sprite);

		this.OscillatorX = new Oscillator(position_1.X, position_2.X, move_duration, move_tween);
		this.OscillatorY = new Oscillator(position_1.Y, position_2.Y, move_duration, move_tween);
		this.Position = position_1;

		AddColliderRectangle("main", 0, 0, sprite.Region.GetWidth(), sprite.Region.GetHeight());
	}

	public override void onUpdate(float deltaTime)
	{
		base.onUpdate(deltaTime);
		this.OscillatorX.Update();
		this.OscillatorY.Update();
		this.Position.X = this.OscillatorX.Tweener.Current;
		this.Position.Y = this.OscillatorY.Tweener.Current;

		this.GetSprite("main").SpriteEffects = (this.Position.X > this.PreviousX) ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
		this.PreviousX = this.Position.X;
	}

	public enum AvailableDragons
	{
		fire_dragon,
		spike_dragon
	}
}
