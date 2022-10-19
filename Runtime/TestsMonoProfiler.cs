// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using UnityEngine;

namespace Depra.Unity.Benchmark.Runtime
{
    public class TestsMonoProfiler : MonoProfiler
    {
        protected override int Order => 1;
        protected override RuntimeBenchmark Benchmark { get; } = new TestRuntimeBenchmark();

        private class TestRuntimeBenchmark : RuntimeBenchmark
        {
            protected override void Sample()
            {
                var randomValue = Random.Range(float.MinValue, float.MaxValue);
            }
        }
    }
}