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
/// A token that increments the output counter of a IMDIPollCountering during
/// its lifetime.
/// 
/// Use in a using(){} block as much as possible to maintain scope.
/// </summary>
public class MIDIOutputPollScope : System.IDisposable
{
    private IMIDIPollCountering counter = null;

    public MIDIOutputPollScope(IMIDIPollCountering counter)
    { 
        if(counter == null)
            return;

        this.counter = counter;
        this.counter.IncrementOutputPollCounter();
    }

    void System.IDisposable.Dispose()
    { 
        if(this.counter != null)
            this.counter.DecrementOutputPollCounter();

        // Seal the object.
        this.counter = null;
    }
}
