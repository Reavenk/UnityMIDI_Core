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

// <summary>
// Wrapper for an implementation of MIDIReceiver class in the
// plugin.
// </summary>

#if UNITY_ANDROID

using UnityEngine;

public class OutputConnection : PxPre.AndWrap.MidiReceiver
{
    public OutputConnection(AndroidJavaObject ajo, PxPre.AndWrap.IReporter reporter)
        : base(ajo, reporter)
    { }

    public void seal()
    { 
        this._ajo.Call("seal");
    }
    

    public int getCount()
    { 
        return this._ajo.Call<int>("getCount");
    }
    

    public bool hasMessages()
    { 
        return this._ajo.Call<bool>("hasMessages");
    }
    

    public OCMidiMsg popMessage()
    {
        AndroidJavaObject ajo = 
            this._ajo.Call<AndroidJavaObject>("popMessage");

        if(ajo == null)
            return null;

        return new OCMidiMsg(ajo, this._r);
    }
}
#endif