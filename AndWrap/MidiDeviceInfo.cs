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

using System.Collections.Generic;
using UnityEngine;

namespace PxPre
{
    namespace AndWrap
    { 

        // <summary>
        // Wrapper for Android's MidiDeviceInfo Java class.
        // https://developer.android.com/reference/android/media/midi/MidiDeviceInfo
        // </summary>
        public class MidiDeviceInfo : JavaObj
        { 
            public const string PROPERTY_BLUETOOTH_DEVICE   = "bluetooth_device";
            public const string PROPERTY_MANUFACTURER       = "manufacturer";
            public const string PROPERTY_NAME               = "name";
            public const string PROPERTY_PRODUCT            = "product";
            public const string PROPERTY_SERIAL_NUMBER      = "serial_number";
            public const string PROPERTY_USB_DEVICE         = "usb_device";
            public const string PROPERTY_VERSION            = "version";

            public const int TYPE_BLUETOOTH                 = 0x00000003;
            public const int TYPE_USB                       = 0x00000001;
            public const int TYPE_VIRTUAL                   = 0x00000002;

            public MidiDeviceInfo(AndroidJavaObject ajo, IReporter reporter)
                : base(ajo, reporter)
            { }

            public int	describeContents()
            {
                return this._ajo.Call<int>("describeContents");
            }

            public int getId()
            { 
                return this._ajo.Call<int>("getId");
            }

            public int getInputPortCount()
            { 
                return this._ajo.Call<int>("getInputPortCount");
            }

            public int getOutputPortCount()
            {
                return this._ajo.Call<int>("getOutputPortCount");
            }

            public List<PortInfo> getPorts()
            { 
                List<PortInfo> ret = new List<PortInfo>();

                AndroidJavaObject ports = _ajo.Call<AndroidJavaObject>("getPorts");
                int arrayLen = AndroidJNI.GetArrayLength(ports.GetRawObject());

                for(int i = 0; i < arrayLen; ++i)
                { 
                    AndroidJavaObject ajGet = arrayClass.CallStatic<AndroidJavaObject>("get", ports, i);
                    PortInfo pi = new PortInfo(ajGet, this._r);
                    ret.Add(pi);
                }

                return ret;
            }

            public Bundle getProperties()
            { 
                AndroidJavaObject ajo = this._ajo.Call<AndroidJavaObject>("getProperties");
                return new Bundle(ajo, this._r);
            }

            public int getType()
            { 
                return this._ajo.Call<int>("getType");
            }


            public bool isPrivate()
            { 
                return this._ajo.Call<bool>("isPrivate");
            }

            public void writeToParcel(Parcel parcel, int flags)
            {
                this._ajo.Call("writeToParcel", parcel._ajo, flags);
            }
        }
    }
}

#endif