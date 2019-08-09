using System;
using MonoEngine;

namespace HarpersPlatformer.Entities
{
    public class TimedExecution : Entity
    {
        private readonly GameTimeSpan _timer = new GameTimeSpan();
        private readonly Action _exec;
        private bool _executed;
        private readonly int _timeToWait;

        public TimedExecution(int msToWait, Action exec, bool persistent = false)
        {
            IsPersistent = persistent;
            _timeToWait = msToWait;
            _exec = exec;
        }

        public override void onUpdate(float deltaTime)
        {
            if (_timer.TotalMilliseconds >= _timeToWait && !_executed)
            {
                _exec();
                _executed = true;
                IsExpired = true;
            }

            base.onUpdate(deltaTime);
        }

        public override void onResume(int pauseTime)
        {
            base.onResume(pauseTime);
            _timer.RemoveTime(pauseTime);
        }
    }
}
