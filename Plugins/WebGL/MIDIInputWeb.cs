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

public class MIDIInputWeb : MIDIInput
{
    string id           = "";
    string manufacturer = "";
    string name         = "";
    string version      = "";

    public bool ParseJSON(SimpleJSON.JSONNode n)
    { 
        if(n.IsObject == false)
            return false;

        SimpleJSON.JSONObject jso = n.AsObject;

        SimpleJSON.JSONNode jsnId = jso["id"];
        if(jsnId == null)
            return false;
        else
            this.id = jsnId.Value;

        SimpleJSON.JSONNode jsnMan = jso["manufacturer"];
        if(jsnMan == null)
            return false;
        else
            this.manufacturer = jsnMan.Value;

        SimpleJSON.JSONNode jsnNam = jso["name"];
        if(jsnNam == null)
            return false;
        else
            this.name = jsnNam.Value;

        SimpleJSON.JSONNode jsnVer = jso["version"];
        if(jsnVer == null)
            return false;
        else
            this.version = jsnVer.Value;

        return true;
    }

    public bool Equivalent(MIDIInput input)
    { 
        MIDIInputWeb mii = input as MIDIInputWeb;
        if(mii == null)
            return false;

        return 
            this.id             == mii.id &&
            this.manufacturer   == mii.manufacturer &&
            this.name           == mii.name &&
            this.version        == mii.version;
    }

    public bool Activate()
    { 
        return MIDIWeb.EnableInputDevice(this.name, this.id);
    }

    public bool Deactivate()
    { 
        return MIDIWeb.DisableInputDevice(this.name, this.id);
    }

    public string DeviceName()
    {
        return this.name;
    }

    public string Description()
    { 
        return this.manufacturer;
    }
}
