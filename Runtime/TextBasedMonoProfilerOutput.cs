// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using UnityEngine;
using UnityEngine.UI;

namespace Depra.Unity.Benchmark.Runtime
{
    public class TextBasedMonoProfilerOutput : MonoProfilerOutput
    {
        [SerializeField] private Text _text;

        public override void Init(int order) { }

        public override void UpdateInfo(string identifier, long averageSampleDuration) =>
            _text.text = FormatInfo(identifier, averageSampleDuration);
    }
}