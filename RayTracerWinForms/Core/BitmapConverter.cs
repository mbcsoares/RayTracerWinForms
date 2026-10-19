using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace RayTracerWinForms.Core;

/// <summary>
/// Converte o buffer de cores (Vec3[,]) em Bitmap.
/// Usa LockBits para performance (evita SetPixel).
/// </summary>
public static class BitmapConverter
{
    public static Bitmap ToBitmap(Vec3[,] buffer)
    {
        int h = buffer.GetLength(0);
        int w = buffer.GetLength(1);

        var bmp = new Bitmap(w, h, PixelFormat.Format24bppRgb);

        BitmapData data = bmp.LockBits(
            new Rectangle(0, 0, w, h),
            ImageLockMode.WriteOnly,
            PixelFormat.Format24bppRgb);

        try
        {
            int stride = data.Stride;
            byte[] pixels = new byte[stride * h];

            for (int j = 0; j < h; j++)
            {
                int rowOffset = j * stride;
                for (int i = 0; i < w; i++)
                {
                    Vec3 c = buffer[j, i];
                    int r = (int)(Math.Clamp(c.X, 0.0, 1.0) * 255.0);
                    int g = (int)(Math.Clamp(c.Y, 0.0, 1.0) * 255.0);
                    int b = (int)(Math.Clamp(c.Z, 0.0, 1.0) * 255.0);

                    int idx = rowOffset + i * 3;
                    // Ordem BGR no Format24bppRgb
                    pixels[idx + 0] = (byte)b;
                    pixels[idx + 1] = (byte)g;
                    pixels[idx + 2] = (byte)r;
                }
            }

            Marshal.Copy(pixels, 0, data.Scan0, pixels.Length);
        }
        finally
        {
            bmp.UnlockBits(data);
        }

        return bmp;
    }
}