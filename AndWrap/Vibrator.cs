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

using UnityEngine;

namespace PxPre
{
    namespace AndWrap
    {
        // <summary>
        // Wrapper for Android's Vibrator Java class.
        // </summary>
        public class Vibrator : JavaObj
        { 
            // https://developer.android.com/reference/android/os/Vibrator

            public const int VIBRATION_EFFECT_SUPPORT_NO        = 0x00000002;
            public const int VIBRATION_EFFECT_SUPPORT_UNKNOWN   = 0x00000000;
            public const int VIBRATION_EFFECT_SUPPORT_YES       = 0x00000001;

            public Vibrator(AndroidJavaObject ajo, IReporter reporter)
                : base(ajo, reporter)
            { }

            public int areAllEffectsSupported(params int [] effectIds)
            { 
                object arrayObj = effectIds;
                return this._ajo.Call<int>("areAllEffectsSupported", arrayObj);
            }

            public bool areAllPrimitivesSupported(params int [] primitiveIds)
            { 
                return this._ajo.Call<bool>("areAllPrimitivesSupported", primitiveIds);
            }

            public int[] areEffectsSupported(params int [] effectIds)
            { 
                return this._ajo.Call<int[]>("areEffectsSupported", effectIds);
            }

            public bool [] arePrimitivesSupported(params int [] primitiveIds)
            { 
                return this._ajo.Call<bool[]>("arePrimitivesSupported", primitiveIds);
            }

            public void cancel()
            { 
                this._ajo.Call("cancel");
            }

            public bool hasAmplitudeControl()
            { 
                return this._ajo.Call<bool>("hasAmplitudeControl");
            }

            public bool hasVibrator()
            {
                return this._ajo.Call<bool>("hasVibrator");
            }

            public void vibrate(long milliseconds)
            { 
                this._ajo.Call("vibrate", milliseconds);
            }

            public void vibrate(long[] pattern, int repeat)
            { 
                this._ajo.Call("vibrate", pattern, repeat);
            }

            public void vibrate(VibrationEffect vibe, AudioAttributes attributes)
            { 
                this._ajo.Call("vibrate", vibe._ajo, attributes._ajo);
            }

            public void vibrate(long milliseconds, AudioAttributes attributes)
            { }

            public void vibrate(VibrationEffect vibe)
            { 
                this._ajo.Call("vibrate", vibe._ajo);
            }

            public void vibrate(long[] pattern, int repeat, AudioAttributes attributes)
            { 
                this._ajo.Call("vibrate", pattern, repeat, attributes._ajo);
            }
        }
    }
}

#endif