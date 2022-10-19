// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using UnityEngine;

namespace Depra.Unity.Benchmark.Runtime
{
    public class GuiBasedMonoProfilerOutput : MonoProfilerOutput
    {
        [SerializeField] private Color _color = Color.white;

        private Rect _area;
        private GUIStyle _style;
        
        private string _identifier;
        private long _averageSampleDuration;

        public override void Init(int order)
        {
            var height = Screen.height / 10f;
            _area = new Rect(0f, order * height, Screen.width, height);

            _style = new GUIStyle("label")
            {
                fontSize = 32,
                alignment = TextAnchor.UpperLeft,
            };
        }

        public override void UpdateInfo(string identifier, long averageSampleDuration) 
        {
            _identifier = identifier;
            _averageSampleDuration = averageSampleDuration;
            
            GUI.color = _color;
            var formattedText = FormatInfo(identifier, averageSampleDuration);
            GUI.Label(_area, formattedText, _style);
        }

        private void OnGUI() 
        {
            GUI.color = _color;
            var formattedText = FormatInfo(_identifier, _averageSampleDuration);
            GUI.Label(_area, formattedText, _style);
        }
    }
}