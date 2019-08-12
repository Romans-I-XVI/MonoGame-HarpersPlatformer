using MonoEngine;

namespace HarpersPlatformer.Entities
{
    public class LevelCanvasEntity : Entity
    {
        public override void onUpdate(float deltaTime)
        {
            base.onUpdate(deltaTime);

            var levelCanvas = Engine.GetFirstInstanceByType<LevelCanvas>();
            RenderTarget = levelCanvas;
        }
    }
}
