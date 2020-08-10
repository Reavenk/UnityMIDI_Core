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
// A class to wrap the representation of a MIDI Output device.
// </summary>

public interface MIDIOutput
{ 
    /// <summary>
    /// Test if another MIDIOutput object represents the same MIDI output device.
    /// </summary>
    /// <param name="output">The other MIDI output device to compare against.</param>
    /// <returns>True if the parameter and invoking object represent the same device.</returns>
    bool Equivalent(MIDIOutput output);

    /// <summary>
    /// The port id of the MIDI output device.
    /// </summary>
    /// <returns></returns>
    int Port();

    /// <summary>
    /// The name of the MIDI output device.
    /// </summary>
    /// <returns></returns>
    string DeviceName();

    /// <summary>
    /// The manufacture of the MIDI output device. May be empty.
    /// </summary>
    /// <returns></returns>
    string Manufacture();

    /// <summary>
    /// The product name of the MIDI output device. May be empty.
    /// </summary>
    /// <returns></returns>
    string Product();

    /// <summary>
    /// Activates the MIDI device. This should not be called directly, use 
    /// the MIDIMgr to activate the device for proper statekeeping.
    /// </summary>
    /// <returns>Returns true if the MIDI state was changed.</returns>
    bool Activate();

    /// <summary>
    /// Deactivates the MIDI device. This should not be called directly, use
    /// the MIDIMgr to deactivate the device for proper statekeeping.
    /// </summary>
    /// <returns>Returns true the if the MIDI device was deactivated.</returns>
    bool Deactivate();

    /// <summary>
    /// When activated, send a key press message to the device.
    /// </summary>
    /// <param name="mgr">The MIDI manager to reference as needed. Its relevance and use will vary between implementations.</param>
    /// <param name="midinote">The MIDI note id to press.</param>
    /// <param name="channel">The channel the message is sent on. This should be between the range [1,16].</param>
    /// <param name="velocity">The velocity of the note press. This should be between the range [0,127].</param>
    /// <returns>Returns true if the message was successfully sent.</returns>
    bool SendKeyPress(MIDIMgr mgr, int midinote, int channel, sbyte velocity);

    /// <summary>
    /// When activated, send a key release message to the device.
    /// </summary>
    /// <param name="mgr">The MIDI manager to reference as needed. Its relevance and use will varyt between implementations.</param>
    /// <param name="midinote">The MIDI note id to release.</param>
    /// <param name="channel">The channel the message is sent on. This should be between the range [1,16].</param>
    /// <returns>Returns true of the message was successfully sent.</returns>
    bool SendKeyRelease(MIDIMgr mgr, int midinote, int channel);
}