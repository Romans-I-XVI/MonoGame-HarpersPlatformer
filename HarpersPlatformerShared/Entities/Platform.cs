using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoEngine;

namespace HarpersPlatformer.Entities;

public class Platform : Entity
{
	public Platform(Rectangle rectangle) {
		this.Position = new Vector2(rectangle.X, rectangle.Y);

		this.AddColliderRectangle("main", 0, 0, rectangle.Width, rectangle.Height);
	}
}
