using Microsoft.Xna.Framework.Input;
using MonoEngine;

namespace HarpersPlatformer.Entities;

public class ControlFullscreen : Entity
{
	public ControlFullscreen() {
		this.IsPersistent = true;
		this.IsPauseable = false;
	}

	public override void onKeyDown(KeyboardEventArgs e) {
		base.onKeyDown(e);
		if (e.Key == Keys.F11) {
			Engine.Game.Graphics.ToggleFullScreen();
		}
	}
}
