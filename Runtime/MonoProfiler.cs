// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using UnityEngine;

namespace Depra.Unity.Benchmark.Runtime
{
    public abstract class MonoProfiler : MonoBehaviour
    {
        [Min(1)] [SerializeField] private int _iterations;
        [SerializeField] private string _identifier;
        [SerializeField] private MonoProfilerOutput _output;

        protected abstract int Order { get; }
        protected abstract RuntimeBenchmark Benchmark { get; }

        private void Update()
        {
            Benchmark.BeginSamples(_identifier, _iterations);
            UpdateInfo();
        }

        private void OnEnable() => _output.Init(Order);

        private void UpdateInfo() => _output.UpdateInfo(_identifier, Benchmark.AverageSampleDuration());
    }
}