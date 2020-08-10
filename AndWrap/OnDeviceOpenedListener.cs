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

#if UNITY_ANDROID

using UnityEngine;

namespace PxPre
{
    namespace AndWrap
    { 

        // <summary>
        // Wrapper for Android's OnDeviceOpenedListener Java interface.
        // https://developer.android.com/reference/android/media/midi/MidiManager.OnDeviceOpenedListener
        // </summary>
        public abstract class OnDeviceOpenedListener : AndroidJavaProxy
        {
            public readonly IReporter reporter;

            public OnDeviceOpenedListener()
                : base("android.media.midi.MidiManager$OnDeviceOpenedListener")
            { }

            public void onDeviceOpened(AndroidJavaObject ajo)
            { 
                this._impl_OnDeviceOpened(new MidiDevice(ajo, null));
            }

            public abstract void _impl_OnDeviceOpened(MidiDevice device);

            public override bool equals(AndroidJavaObject obj)
            { 
                return base.equals(obj);
            }
        
            public override int hashCode()
            { 
                return base.hashCode();
            }
        
            public override AndroidJavaObject Invoke(string methodName, object[] args)
            { 
                return base.Invoke(methodName, args);
            }
        
            public override AndroidJavaObject Invoke(string methodName, AndroidJavaObject[] javaArgs)
            { 
                return base.Invoke(methodName, javaArgs);
            }
        
            public override string toString()
            { 
                return base.toString();
            }
        }
    }
}

#endif
