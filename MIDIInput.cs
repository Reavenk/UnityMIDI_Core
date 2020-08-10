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
// A class to wrap the representation of a MIDI Input device.
//
// An implementation should be defined for each platform supported.
// </summary>
public interface MIDIInput
{ 
    /// <summary>
    /// Test if another MIDIInput object represents the same MIDI input device.
    /// </summary>
    /// <param name="input">The other MIDI input device to compare against.</param>
    /// <returns>True if the parameter and invoking object represent the same device.</returns>
    bool Equivalent(MIDIInput input);

    /// <summary>
    /// Activates the MIDI device. This should not be called directly, use
    /// the MIDIMgr to activate the device for proper statekeeping.
    /// </summary>
    /// <returns></returns>
    bool Activate();

    /// <summary>
    /// Deactivates the MIDI device. This should not be called directly, use
    /// the MIDIMgr to deactivate the device for proper statekeeping.
    /// </summary>
    /// <returns></returns>
    bool Deactivate();

    /// <summary>
    /// Name of the MIDI device.
    /// </summary>
    /// <returns></returns>
    string DeviceName();

    /// <summary>
    /// Description of the MIDI device. May be empty.
    /// </summary>
    /// <returns></returns>
    string Description();
}
