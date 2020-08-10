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

namespace PxPre
{
    namespace AndWrap
    { 
        // <summary>
        // Message reporting class for the PxPreAndWrap class. This allows AndWrap classes
        // to redirect logged messages and errors.
        // </summary>
        public interface IReporter
        {
            /// <summary>
            /// Direct a logged message.
            /// </summary>
            /// <param name="log">The message.</param>
            void ReportLog(string log);

            /// <summary>
            /// Direct a logged warning.
            /// </summary>
            /// <param name="log">The warning.</param>
            void ReportWarning(string log);

            /// <summary>
            /// Direct a logged error.
            /// </summary>
            /// <param name="log">The error.</param>
            void ReportError(string log);

            /// <summary>
            /// Direct a logged exception.
            /// </summary>
            /// <param name="log">The exception.</param>
            void ReportException(string log);
        }
    }
}