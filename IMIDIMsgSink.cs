using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MIDISystemMsg
{ 
    TimingClock,
    StartSequence,
    ContinueSequence,
    StopSequence,
    ActiveSensing,
    SystemReset,

    TimingCode,
    SongPosition,
    SongSelect,
    TuneRequest
}

public interface IMIDIMsgSink
{
    void MIDIMsg_OnSystemMsg(MIDIMgr mgr, MIDIInput input, MIDISystemMsg msg);

    void MIDIMsg_OnNoteOff(MIDIInput input, int channel, int keyNum, float velocity);
    void MIDIMsg_OnNoteOn(MIDIInput input, int channel, int keyNum, float velocity);
    void MIDIMsg_OnKeyPressure(MIDIInput input, int channel, int keyNum, float velocity);
    void MIDIMsg_OnControlChange(MIDIInput input, int channel, int controllerNum, int controllerValue);
    void MIDIMsg_OnProgramChange(MIDIInput input, int channel, int program);
    void MIDIMsg_OnChannelPressure(MIDIInput input, float pressure);
    void MIDIMsg_OnPitchBend(MIDIInput input, float msb, float lsb);

    void MIDIMsg_InputDisconnected(MIDIMgr mgr, MIDIInput input);
}
