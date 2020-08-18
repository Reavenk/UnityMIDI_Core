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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MIDIOutputWeb : MIDIOutput
{
    //string connection = "";

    string id               = "";
    string manufacturer     = "";
    string name             = "";
    string version          = "";

    public bool ParseJSON(SimpleJSON.JSONNode n)
    { 
        if(n.IsObject == false)
            return false;

        SimpleJSON.JSONObject jso   = n.AsObject;

        SimpleJSON.JSONNode jsnId   = jso["id"];
        if(jsnId == null)
            return false;
        else
            this.id = jsnId.Value;

        SimpleJSON.JSONNode jsnMan  = jso["manufacturer"];
        if(jsnMan == null)
            return false;
        else
            this.manufacturer = jsnMan.Value;

        SimpleJSON.JSONNode jsnNam  = jso["name"];
        if(jsnNam == null)
            return false;
        else
            this.name = jsnNam.Value;

        SimpleJSON.JSONNode jsnVer  = jso["version"];
        if(jsnVer == null)
            return false;
        else
            this.version = jsnVer.Value;

        return true;
    }

    public bool Equivalent(MIDIOutput output)
    { 
        MIDIOutputWeb mio = output as MIDIOutputWeb;
        if(mio == null)
            return false;

        return 
            this.id             == mio.id &&
            this.manufacturer   == mio.manufacturer &&
            this.name           == mio.name &&
            this.version        == mio.version;
    }

    public int Port()
    { 
        // No idea how to process this, note sure if MIDIWeb has
        // the concept of ports - or at least if it exposes it.
        // (wleu)
        return 0;
    }

    public string DeviceName()
    { 
        return this.name;
    }

    public string Manufacture()
    { 
        return this.manufacturer;
    }

    public string Product()
    { 
        return string.Empty;
    }

    public bool Activate()
    {
        return MIDIWeb.EnableOutputDevice(this.name, this.id);
    }

    public bool Deactivate()
    { 
        return MIDIWeb.DisableOutputDevice(this.name, this.id);
    }

    public bool SendKeyPress(MIDIMgr mgr, int midinote, int channel, sbyte velocity)
    {
        channel = Mathf.Clamp(channel, 1, 16);

        byte[] buffer = new byte[3];
        int numBytes = 0;
        buffer[numBytes++] = (byte)(0x90 + (channel - 1)); // note on
        buffer[numBytes++] = (byte)midinote; // pitch is middle C
        buffer[numBytes++] = (byte)velocity; // max velocity

        MIDIWeb.SendOutputMsg(this.name, this.id, buffer);
        return false;
    }

    public bool SendKeyRelease(MIDIMgr mgr, int midinote, int channel)
    { 
        channel = Mathf.Clamp(channel, 1, 16);

        byte[] buffer = new byte[3];
        int numBytes = 0;
        buffer[numBytes++] = (byte)(0x80 + (channel - 1)); // note off
        buffer[numBytes++] = (byte)midinote; // pitch is middle C
        buffer[numBytes++] = (byte)0;

        MIDIWeb.SendOutputMsg(this.name, this.id, buffer);
        return false;
    }
}
