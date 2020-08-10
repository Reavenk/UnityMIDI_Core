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
        // Wrapper for Java's object class using Unity's AndroidJavaClass system.
        // </summary>
        public class JavaObj
        { 
            protected static AndroidJavaClass arrayClass = 
                        new AndroidJavaClass("java.lang.reflect.Array");

            public readonly AndroidJavaObject _ajo;
            public readonly IReporter _r;

            public static JavaObj Null()
            {  return new JavaObj(null, null); }

            public JavaObj(AndroidJavaObject ajo, IReporter reporter)
            { 
                this._ajo = ajo;
                this._r = reporter;
            }

            public bool	equals(AndroidJavaObject o)
            {
                return this._ajo.Call<bool>("equals", o);
            }

            public int hashCode()
            { 
                return this._ajo.Call<int>("hashCode");
            }

            public string toString()
            { 
                return this._ajo.Call<string>("toString");
            }
        }
    }
}
#endif