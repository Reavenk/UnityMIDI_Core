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
// A system for tracking what a MIDI device is reserved for. Designed to work with
// MIDIInputAnd, MIDIOutputAnd and MidiMgr.
// </summary>

#if UNITY_ANDROID

using System.Collections.Generic;

public class AndroidMIDIDeviceRecord
{
    static AndroidMIDIDeviceRecord inst;

    public static AndroidMIDIDeviceRecord Inst()
    { 
        if(inst == null)
            inst = new AndroidMIDIDeviceRecord();

        return inst;
    }

    List<PxPre.AndWrap.MidiDeviceInfo> inputConnections = new List<PxPre.AndWrap.MidiDeviceInfo>();
    List<PxPre.AndWrap.MidiDeviceInfo> outputConnections = new List<PxPre.AndWrap.MidiDeviceInfo>();

    public bool ContainsInput(PxPre.AndWrap.MidiDeviceInfo mdi)
    {
        foreach(PxPre.AndWrap.MidiDeviceInfo mi in this.inputConnections)
        {
            if(CompareDeviceInfo(mi, mdi) == true)
                return true;
        }
        return false;
    }

    public bool ContainsOutput(PxPre.AndWrap.MidiDeviceInfo mdi)
    { 
        foreach(PxPre.AndWrap.MidiDeviceInfo mo in this.outputConnections)
        {
            if(CompareDeviceInfo(mo, mdi) == true)
                return true;
        }
        return false;
    }

    public bool Contains(PxPre.AndWrap.MidiDeviceInfo mdi)
    { 
        foreach(PxPre.AndWrap.MidiDeviceInfo mi in this.inputConnections)
        {
            if(CompareDeviceInfo(mi, mdi) == true)
                return true;
        }

        foreach(PxPre.AndWrap.MidiDeviceInfo mo in this.outputConnections)
        {
            if(CompareDeviceInfo(mo, mdi) == true)
                return true;
        }

        return false;
    }

    public bool AddInput(PxPre.AndWrap.MidiDeviceInfo mdi)
    { 
        foreach(PxPre.AndWrap.MidiDeviceInfo mi in this.inputConnections)
        {
            if(CompareDeviceInfo(mi, mdi) == true)
                return false;
        }
        this.inputConnections.Add(mdi);
        return true;
    }

    public bool AddOutput(PxPre.AndWrap.MidiDeviceInfo mdi)
    { 
        foreach(PxPre.AndWrap.MidiDeviceInfo mo in this.outputConnections)
        {
            if(CompareDeviceInfo(mo, mdi) == true)
                return false;
        }
        this.outputConnections.Add(mdi);
        return true;
    }

    public bool RemoveInput(PxPre.AndWrap.MidiDeviceInfo mdi)
    { 
        for(int i = 0; i < this.inputConnections.Count; ++i)
        {
            if(CompareDeviceInfo(this.inputConnections[i], mdi) == true)
            {
                this.inputConnections.RemoveAt(i);
                return  true;
            }
        }
        return false;
    }

    public bool RemoveOutput(PxPre.AndWrap.MidiDeviceInfo mdi)
    { 
        for(int i = 0; i <  this.outputConnections.Count; ++i)
        {
            if(CompareDeviceInfo(this.outputConnections[i], mdi) == true)
            { 
                this.outputConnections.RemoveAt(i);
                return true;
            }
        }
        return false;
    }

    public static bool CompareDeviceInfo(PxPre.AndWrap.MidiDeviceInfo mdia, PxPre.AndWrap.MidiDeviceInfo mdib)
    { 
        return mdia.getId() == mdib.getId();
    }
}
#endif