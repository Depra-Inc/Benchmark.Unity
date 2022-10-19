// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine.Profiling;

namespace Depra.Unity.Benchmark.Runtime
{
    public abstract class RuntimeBenchmark
    {
        private const int SAMPLE_COUNT = 32;
        private readonly Stopwatch _stopwatch = new Stopwatch();
        private readonly Stack<long> _samples = new Stack<long>(SAMPLE_COUNT);

        public void BeginSamples(string identifier, int iterationsCount)
        {
#if ENABLE_PROFILER
            Profiler.BeginSample(identifier);
#endif
            BeginSamplesPrivate(iterationsCount);
#if ENABLE_PROFILER
            Profiler.EndSample();
#endif
        }

        public long AverageSampleDuration()
        {
            if (_samples.Count == 0)
            {
                return 0;
            }

            var total = _samples.Sum();
            var average = total / _samples.Count;

            return average;
        }
        
        protected abstract void Sample();

        private void BeginSamplesPrivate(int iterationsCount)
        {
            _stopwatch.Restart();

            for (var i = 0; i < iterationsCount; i++)
            {
                Sample();
            }

            _stopwatch.Stop();
            _samples.Push(_stopwatch.ElapsedMilliseconds);
        }
    }
}