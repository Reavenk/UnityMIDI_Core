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

/// <summary>
/// MIDI system messages.
/// See IMIDIMsgSink.MIDIMsg_OnSystemMsg() for more details.
/// </summary>
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

/// <summary>
/// Interface for code to subscribe to MIDI messages.
/// </summary>
public interface IMIDIMsgSink
{
    /// <summary>
    /// Callback for when a MIDI system message is sent.
    /// </summary>
    /// <param name="mgr"></param>
    /// <param name="input"></param>
    /// <param name="msg"></param>
    void MIDIMsg_OnSystemMsg(MIDIMgr mgr, MIDIInput input, MIDISystemMsg msg);

    /// <summary>
    /// Callback for when a MIDI note is released.
    /// </summary>
    /// <param name="input">The MIDI device the message was received from.</param>
    /// <param name="channel"></param>
    /// <param name="keyNum"></param>
    /// <param name="velocity"></param>
    void MIDIMsg_OnNoteOff(MIDIInput input, int channel, int keyNum, float velocity);

    /// <summary>
    /// Callback for when a MIDI note is pressed.
    /// </summary>
    /// <param name="input">The MIDI input device the message was received from.</param>
    /// <param name="channel"></param>
    /// <param name="keyNum"></param>
    /// <param name="velocity"></param>
    void MIDIMsg_OnNoteOn(MIDIInput input, int channel, int keyNum, float velocity);

    /// <summary>
    /// Callback for when a pressed MIDI note changes in pressure.
    /// </summary>
    /// <param name="input">The MIDI input device the message was received from.</param>
    /// <param name="channel"></param>
    /// <param name="keyNum"></param>
    /// <param name="velocity"></param>
    void MIDIMsg_OnKeyPressure(MIDIInput input, int channel, int keyNum, float velocity);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <param name="channel"></param>
    /// <param name="controllerNum"></param>
    /// <param name="controllerValue"></param>
    void MIDIMsg_OnControlChange(MIDIInput input, int channel, int controllerNum, int controllerValue);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <param name="channel"></param>
    /// <param name="program"></param>
    void MIDIMsg_OnProgramChange(MIDIInput input, int channel, int program);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <param name="pressure"></param>
    void MIDIMsg_OnChannelPressure(MIDIInput input, float pressure);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <param name="msb"></param>
    /// <param name="lsb"></param>
    void MIDIMsg_OnPitchBend(MIDIInput input, float msb, float lsb);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mgr"></param>
    /// <param name="input"></param>
    void MIDIMsg_InputDisconnected(MIDIMgr mgr, MIDIInput input);
}
