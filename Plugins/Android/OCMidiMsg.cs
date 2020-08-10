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
// Wrapper for the android class representing a MIDI message from the android Plugin.
// </summary>

#if UNITY_ANDROID

using UnityEngine;

public class OCMidiMsg : PxPre.AndWrap.JavaObj
{
    public OCMidiMsg(AndroidJavaObject ajo, PxPre.AndWrap.IReporter reporter)
        : base(ajo, reporter)
    { }

    public byte[] bytes 
    {
        get
        { 
            return this._ajo.Get<byte[]>("bytes"); 
        } 
    }

    public long timestamp 
    {
        get
        {
            return this._ajo.Get<long>("timestamp"); 
        } 
    }
}
#endif