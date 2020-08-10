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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PxPre
{
    namespace AndWrap
    {

        // <summary>
        // Wrapper for Android's MidiOutputPort Java class.
        // https://developer.android.com/reference/android/media/midi/MidiOutputPort
        // </summary>
        public class MidiOutputPort : JavaObj
        { 
            public MidiOutputPort(AndroidJavaObject ajo, IReporter reporter)
                : base(ajo, reporter)
            { }

            public void close()
            { 
                this._ajo.Call("close");
            }

            public int getPortNumber()
            { 
                return this._ajo.Call<int>("getPortNumber");
            }

            // Abstract callback
            //public void onConnect(MidiReceiver receiver)
            //{ 
            //}
            
            // Abstract callback
            //public void onDisconnect(MidiReceiver receiver)
            //{ 
            //}

            public void connect(MidiReceiver receiver)
            { 
                this._ajo.Call("connect", receiver._ajo);
            }

            public void disconnect(MidiReceiver receiver)
            { 
                this._ajo.Call("disconnect", receiver._ajo);
            }

        }
    }
}
#endif