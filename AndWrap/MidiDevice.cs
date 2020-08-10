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
        // Wrapper for Android's MidiDevices Java class.
        // https://developer.android.com/reference/android/media/midi/MidiDevice
        // </summary>
        public class MidiDevice : JavaObj
        {
            public MidiDevice(AndroidJavaObject ajo, IReporter reporter)
                : base(ajo, reporter)
            { }

            public void close()
            { 
                this._ajo.Call("close");
            }

            public MidiConnection connectPorts(MidiInputPort inputPort, int outputPortNumber)
            { 
                AndroidJavaObject ajo = this._ajo.Call<AndroidJavaObject>("connectionPorts", inputPort._ajo, outputPortNumber);
                return new MidiConnection(ajo, this._r);
            }

            public MidiDeviceInfo getInfo()
            { 
                AndroidJavaObject ajo = this._ajo.Call<AndroidJavaObject>("getInfo");
                return new MidiDeviceInfo(ajo, this._r);
            }

            public MidiInputPort openInputPort(int portNumber)
            { 
                AndroidJavaObject ajo = this._ajo.Call<AndroidJavaObject>("openInputPort", portNumber);
                return new MidiInputPort(ajo, this._r);
            }

            public MidiOutputPort openOutputPort(int portNumber)
            { 
                AndroidJavaObject ajo = this._ajo.Call<AndroidJavaObject>("openOutputPort", portNumber);
                return new MidiOutputPort(ajo, this._r);
            }

        }
    }
}
#endif