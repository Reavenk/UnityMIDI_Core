//MIT License
//
//Copyright (c) 2020 Pixel Precision LLC
//
//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:
//
//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.
//
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.

// This function was brought in here on error will be removed from the MIDI library later.

#if UNITY_ANDROID

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// <summary>
// Wrapper for Android's VibrationEffect Java class.
// </summary>
namespace PxPre
{
    namespace AndWrap
    {
        public class VibrationEffect : JavaObj
        {
            // https://developer.android.com/reference/android/os/VibrationEffect

            public const int DEFAULT_AMPLITUDE = -1;
            public const int EFFECT_CLICK = 0x00000000;
            public const int EFFECT_DOUBLE_CLICK = 0x00000001;
            public const int EFFECT_HEAVY_CLICK = 0x00000005;
            public const int EFFECT_TICK = 0x00000002;

            public VibrationEffect(AndroidJavaObject ajo, IReporter reporter)
                : base(ajo, reporter)
            { }

            // Unimplemented
            //
            //static VibrationEffect createOneShot(long milliseconds, int amplitude)
            //{ 
            //}
            //
            //static VibrationEffect createPredefined(int effectId)
            //{ 
            //}
            //
            //static VibrationEffect createWaveform(long[] timings, int[] amplitudes, int repeat)
            //{ 
            //}
            //
            //static VibrationEffect createWaveform(long[] timings, int repeat)
            //{ 
            //}
            //
            //public int describeContents()
            //{ 
            //}
            //
            //static VibrationEffect.Composition	startComposition()
            //{ 
            //}
        }
    }
}
#endif