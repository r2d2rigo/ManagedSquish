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

using System;

namespace ManagedSquish
{
    public class SquishWrapper
    {
        private static bool isx64;

        static SquishWrapper()
        {
            isx64 = (IntPtr.Size == 8);
        }

        public static byte[] CompressImage(byte[] rgba, int width, int height, SquishFlags flags)
        {
            int finalSize = GetStorageRequirements(width, height, flags);
            byte[] finalData = new byte[finalSize];

            unsafe
            {
                fixed (byte* rgbaPointer = rgba)
                {
                    fixed (byte* dataPointer = finalData)
                    {
                        if (isx64)
                        {
                            Wrapperx64.CompressImage(rgbaPointer, width, height, dataPointer, (int)flags);
                        }
                        else
                        {
                            Wrapperx86.CompressImage(rgbaPointer, width, height, dataPointer, (int)flags);
                        }
                    }
                }
            }

            return finalData;
        }

        public static byte[] DecompressImage(byte[] dxtBlocks, int width, int height, SquishFlags flags)
        {
            int finalSize = width * height * 4;
            byte[] finalData = new byte[finalSize];

            unsafe
            {
                fixed (byte* dxtPointer = dxtBlocks)
                {
                    fixed (byte* dataPointer = finalData)
                    {
                        if (isx64)
                        {
                            Wrapperx64.DecompressImage(dataPointer, width, height, dxtPointer, (int)flags);
                        }
                        else
                        {
                            Wrapperx86.DecompressImage(dataPointer, width, height, dxtPointer, (int)flags);
                        }
                    }
                }
            }

            return finalData;
        }

        public static int GetStorageRequirements(int width, int height, SquishFlags flags)
        {
            if (isx64)
            {
                return Wrapperx64.GetStorageRequirements(width, height, (int)flags);
            }
            else
            {
                return Wrapperx86.GetStorageRequirements(width, height, (int)flags);
            }
        }
    }
}