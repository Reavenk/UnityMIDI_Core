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

// <summary>
// A management interface to be used with MIDIOutputPollScope and MIDIInputPollScope
// to track when polling should happen because something is watching the MIDI input 
// devices or MIDI output devices.
// </summary>
public interface IMIDIPollCountering
{
    /// <summary>
    /// Increment the input poll counter. While the input poll counter is greater than
    /// 0, polling of MIDI inputs will happen at a regular rate.
    /// </summary>
    /// <returns></returns>
    bool IncrementInputPollCounter();

    /// <summary>
    /// Decrement the input poll counter. While the input poll counter is zero, polling
    /// MIDI inputs at a regular rate is disabled.
    /// </summary>
    /// <returns></returns>
    bool DecrementInputPollCounter();

    /// <summary>
    /// Increment the output poll counter. While the output poll counter is greater than
    /// 0, polling of MIDI outputs will happen at a regular rate.
    /// </summary>
    /// <returns></returns>
    bool IncrementOutputPollCounter();

    /// <summary>
    /// Decrement the output poll counter. While the output poll counter is zero, polling
    /// MIDI outputs at a regular rate is disabled.
    /// </summary>
    /// <returns></returns>
    bool DecrementOutputPollCounter();
}
