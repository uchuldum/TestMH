using SkiaSharp;
using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Test
{
    public class MergeImages
    {
        private class Coordinate
        {
            public int X { get; set; }
            public int Y { get; set; }
            public string Path { get; set; }

            public Coordinate()
            {
                X = 0;
                Y = 0;
                Path = "";
            }
        }
        private int Capacity(int num)
        {
            int cap = 0;
            while (num > 0)
            {
                cap++;
                num /= 10;
            }
            return cap;
        }
        private Coordinate ConvertPath(int number, int width, int height)
        {
            Coordinate coordinate = new Coordinate();
            coordinate.Path = "resources/image_part_";
            SKBitmap bitmap = SKBitmap.Decode(coordinate.Path+"001.jpg");
            int num = 3 - Capacity(number + 1);
            for (int i = 0; i < num; ++i)
                coordinate.Path += "0";
            coordinate.Path += (number + 1).ToString() + ".jpg";
            Debug.WriteLine("bitmap:"+width+"\t"+bitmap.Width);
            coordinate.X = number % 10 * width;
            coordinate.Y = number / 10 * height;
           
            
            return coordinate;
        }
        public MergeImages(SKCanvas canvas, int can_width, int can_height)
        {
            try
            {
                canvas.Clear();
               
                int width = can_width / 10;
                int height = can_height / 10;
                for (int i = 0; i < 100; ++i)
                {
                    Coordinate coordinate = ConvertPath(i, width, height);
                    SKBitmap bitmap = SKBitmap.Decode(coordinate.Path);
                    SKBitmap resizedbitmap = bitmap.Resize(new SKImageInfo(width, height), SKBitmapResizeMethod.Box);
                    canvas.DrawBitmap(resizedbitmap, coordinate.X, coordinate.Y);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
