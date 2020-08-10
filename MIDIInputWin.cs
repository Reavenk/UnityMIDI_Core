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


#if UNITY_STANDALONE || UNITY_WSA

// <summary>
// Implementation of MIDIInput for Windows.
// </summary>
public class MIDIInputWin : MIDIInput
{ 
    MIDIMgr.MIDIDevice device;

    int deviceID = -1;

    public int DeviceID 
    {get{return this.deviceID; } }

    internal MIDIInputWin(MIDIMgr.MIDIDevice device)
    { 
        this.device = device;
    }

    public bool Equivalent(MIDIInput input)
    { 
        MIDIInputWin inptWin = input as MIDIInputWin;
        if(inptWin == null)
            return false;

        if(this == inptWin)
            return true;

        if(
            this.device.productId == inptWin.device.productId &&
            this.device.port == inptWin.device.port &&
            MIDIMgr.StrCompShort(this.device.name, inptWin.device.name) == true)
        { 
            return true;
        }

        return false;
    }

    public bool Activate()
    {
        if(this.deviceID != -1)
            return true;

        this.deviceID = MIDIMgr.MIDIMgr_OpenMIDIDevice((int)this.device.port);

        if(this.deviceID != -1)
            return true;

        return false;
    }

    public bool Deactivate()
    { 
        if(this.deviceID == -1)
            return false;

        bool ret = MIDIMgr.MIDIMgr_CloseMIDIDevice(this.deviceID);
        this.deviceID = -1;

        return ret;
    }

    public string DeviceName()
    { 
        return this.device.GetName();
    }

    public string Description()
    { 
        return "MIDI input for " + this.DeviceName();
    }
}
#endif
