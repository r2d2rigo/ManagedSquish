// ManagedSquish - Copyright (c) 2011 Rodrigo 'r2d2rigo' Díaz
//
// Permission is hereby granted, free of charge, to any person obtaining a
// copy of this software and associated documentation files (the "Software"),
// to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
// IN THE SOFTWARE.

namespace ManagedSquish
{
    /// <summary>
    /// Same flag values as specified in squish.h
    /// Refer to libsquish's documentation for actual usage.
    /// </summary>
    public enum SquishFlags
    {
        Dxt1 = (1 << 0),
        Dxt3 = (1 << 1),
        Dxt5 = (1 << 2),
        ColourClusterFit = (1 << 3),
        ColourRangeFit = (1 << 4),
        ColourMetricPerceptual = (1 << 5),
        ColourMetricUniform = (1 << 6), 
        WeightColourByAlpha = (1 << 7),
        ColourIterativeClusterFit = (1 << 8)
    };
}
