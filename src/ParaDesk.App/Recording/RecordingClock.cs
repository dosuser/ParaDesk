using System;
using System.Diagnostics;

namespace ParaDesk.Recording
{
    /// <summary>Monotonic recording time. Pauses and saving time are excluded.</summary>
    internal sealed class RecordingClock
    {
        private readonly object _sync = new object();
        private readonly Func<long> _timestamp;
        private readonly long _frequency;
        private long _elapsed, _started;
        private bool _running;

        internal RecordingClock(Func<long> timestamp, long frequency)
        {
            if (timestamp == null) throw new ArgumentNullException(nameof(timestamp));
            if (frequency <= 0) throw new ArgumentOutOfRangeException(nameof(frequency));
            _timestamp = timestamp;
            _frequency = frequency;
        }

        public static RecordingClock StartNew()
        {
            var clock = new RecordingClock(Stopwatch.GetTimestamp, Stopwatch.Frequency);
            clock.Start();
            return clock;
        }

        public TimeSpan Elapsed
        {
            get
            {
                lock (_sync)
                {
                    long ticks = _elapsed + (_running ? Math.Max(0, _timestamp() - _started) : 0);
                    return TimeSpan.FromTicks((long)(ticks * (TimeSpan.TicksPerSecond / (double)_frequency)));
                }
            }
        }

        public void Start()
        {
            lock (_sync)
            {
                if (_running) return;
                _started = _timestamp();
                _running = true;
            }
        }

        public void Stop()
        {
            lock (_sync)
            {
                if (!_running) return;
                _elapsed += Math.Max(0, _timestamp() - _started);
                _running = false;
            }
        }

        public void Reset()
        {
            lock (_sync) { _elapsed = 0; _running = false; }
        }
    }
}
