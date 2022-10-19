// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using UnityEngine;

namespace Depra.Unity.Benchmark.Runtime
{
    public abstract class MonoProfilerOutput : MonoBehaviour
    {
        private const string FORMAT = "{0}: {1} ms";

        public abstract void Init(int order);

        public abstract void UpdateInfo(string identifier, long averageSampleDuration);

        protected static string FormatInfo(string identifier, long averageSampleDuration) =>
            string.Format(FORMAT, identifier, averageSampleDuration);
    }
}