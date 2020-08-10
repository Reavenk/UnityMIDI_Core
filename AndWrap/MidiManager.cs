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
        // Wrapper for Android's MidiManager Java class.
        // https://developer.android.com/reference/android/media/midi/MidiManager
        // </summary>
        public class MidiManager : JavaObj
        {
            
#if UNITY_ANDROID && !UNITY_EDITOR
            private static AndroidJavaObject _ajoClass = 
                new AndroidJavaClass("com.unity3d.player.UnityPlayer")
                    .GetStatic<AndroidJavaObject>("currentActivity")
                    .Call<AndroidJavaObject>("getSystemService", "midi");
#else
            private static AndroidJavaObject _ajoClass = null;
#endif
        

            public MidiManager(IReporter reporter)
                : base(_ajoClass, reporter)
            { }

            public List<MidiDeviceInfo> GetDevices()
            { 
                List<MidiDeviceInfo> ret = new List<MidiDeviceInfo>();
                try
                {
                    AndroidJavaObject devices = _ajo.Call<AndroidJavaObject>("getDevices");
                    int arrayLen = AndroidJNI.GetArrayLength(devices.GetRawObject());

                    for(int i = 0; i < arrayLen; ++i)
                    { 
                        AndroidJavaObject ajGet = arrayClass.CallStatic<AndroidJavaObject>("get", devices, i);
                        MidiDeviceInfo amd = new MidiDeviceInfo(ajGet, this._r);
                        ret.Add(amd);
                    }
                }
                catch(System.Exception ex)
                { 
                    DiagnosticScene.InstLog(ex.Message);
                }

                return ret;
            }

            public void openBluetoothDevice(BluetoothDevice bluetoothDevice, OnDeviceOpenedListener listener, Handler handler)
            { 
                this._ajo.Call("openBluetoothDevice", bluetoothDevice._ajo, listener, handler._ajo);
            }

            public void openDevice(MidiDeviceInfo deviceInfo, OnDeviceOpenedListener listener, Handler handler)
            { 
                Debug.Log("Calling openDevice");
                this._ajo.Call("openDevice", deviceInfo._ajo, listener, handler._ajo);
                Debug.Log("Called openDevice");
            }

            //public void registerDeviceCallback(MidiManager.DeviceCallback callback, Handler handler)
            //{ }

            //public void unregisterDeviceCallback(MidiManager.DeviceCallback callback)
            //{ }
        }
    }
}
#endif