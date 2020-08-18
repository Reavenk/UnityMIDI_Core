#if UNITY_WEBGL

using System.Runtime.InteropServices;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using UnityEngine;

public class MIDIWeb
{
    [DllImport("__Internal")]
    private static extern bool MIDI_Init();

    [DllImport("__Internal")]
    private static extern bool MIDI_Check();

    [DllImport("__Internal")]
    private static extern string MIDI_QueryOutputDevices();

    [DllImport("__Internal")]
    private static extern string MIDI_QueryInputDevices();

    [DllImport("__Internal")]
    private static extern bool MIDI_EnableInputDevice(string name, string id);

    [DllImport("__Internal")]
    public static extern bool MIDI_DisableInputDevice(string name, string id);

    [DllImport("__Internal")]
    private static extern bool MIDI_IsInputConnected(string name, string id);

    [DllImport("__Internal")]
    private static extern bool MIDI_EnableOutputDevice(string name, string id);

    [DllImport("__Internal")]
    public static extern bool MIDI_DisableOutputDevice(string name, string id);

    [DllImport("__Internal")]
    public static extern bool MIDI_IsOutputConnected(string name, string id);

    [DllImport("__Internal")]
    public static extern int MIDI_InputMessageCount();

    [DllImport("__Internal")]
    public static extern string MIDI_FlushMessagesJSON();

    [DllImport("__Internal")]
    public static extern bool MIDI_SendOutputMsg(string name, string id, string jsonPayload);

    public static bool Init()
    { 
    #if !UNITY_EDITOR
        Debug.Log("Doing MIDI Init");
        return MIDI_Init();
    #endif

        return false;
    }

    public static bool Supported()
    { 
    #if !UNITY_EDITOR && UNITY_WEBGL
        return MIDI_Check();
    #else
        return true;
    #endif
    }

    public static string QueryInputDevicesJSON()
    { 
        return MIDI_QueryInputDevices();
    }

    public static string QueryOutputDevicesJSON()
    {
        return MIDI_QueryOutputDevices();
    }

    public static bool EnableInputDevice(string name, string id)
    { 
        return MIDI_EnableInputDevice(name, id);
    }

    public static bool DisableInputDevice(string name, string id)
    { 
        return MIDI_DisableInputDevice(name, id);
    }

    public static bool IsInputConnected(string name, string id)
    { 
        return MIDI_IsInputConnected(name, id);
    }

    public static bool EnableOutputDevice(string name, string id)
    { 
        return MIDI_EnableOutputDevice(name, id);
    }

    public static bool DisableOutputDevice(string name, string id)
    { 
        return MIDI_DisableOutputDevice(name, id);
    }

    public static bool IsOutputConnected(string name, string id)
    { 
        return MIDI_IsOutputConnected(name, id);
    }

    public static int InputMessageCount()
    { 
        return MIDI_InputMessageCount();
    }

    public static string FlushInputMessagesJSON()
    { 
        string ret = MIDI_FlushMessagesJSON();
        //Debug.Log(ret);
        return ret;
    }


    public static bool SendOutputMsg(string name, string id, byte [] payload)
    { 
        SimpleJSON.JSONArray jsa = new SimpleJSON.JSONArray();
        foreach(byte b in payload)
            jsa.Add( new SimpleJSON.JSONNumber(b.ToString()));
        
        string jsonPayload = jsa.ToString();
        return MIDI_SendOutputMsg(name, id, jsonPayload);
    }
}
#endif
