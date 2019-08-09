using System;
using MonoEngine;

namespace HarpersPlatformer.Entities
{
    public class RespawnControl : Entity
    {
        private bool _spawning = false;

        public RespawnControl()
        {
        }

        public override void onUpdate(float deltaTime)
        {
            base.onUpdate(deltaTime);

            if (Engine.InstanceCount<Player>() == 0 && !_spawning)
            {
                _spawning = true;
                Action respawn = () =>
                {
                    Engine.SpawnInstance<Player>();
                    _spawning = false;
                };
                var execution = new TimedExecution(500, respawn);
                Engine.SpawnInstance(execution);
            }
        }
    }
}
