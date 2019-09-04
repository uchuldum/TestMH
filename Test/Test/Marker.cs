using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using SkiaSharp;
namespace Test
{
    public class Marker
    {
        private List<MarkerCoordinate> Markers = new List<MarkerCoordinate>();
        private SKBitmap _bitmap = SKBitmap.Decode("resources/image_part_001.jpg");
        private class MarkerCoordinate
        {
            public string Name { get; set; }
            public int X { get; set; }
            public int Y { get; set; }

            public MarkerCoordinate() { }
            public MarkerCoordinate(string Name, int X, int Y)
            {
                this.Name = Name;
                this.X = X;
                this.Y = Y;
            }
        }

        public void AddMarker(string name, int x, int y)
        {
            Markers.Add(new MarkerCoordinate(name, x, y));
        }

        public void ClearMarkers()
        {
            if (Markers == null) return;
            Markers.Clear();
        }

        public void DrawMarkers(SKCanvas canvas, int width, int height)
        {
            if (Markers == null) return;
            string path = "resources/marker.png";
            foreach (var marker in Markers)
            {
                float nX = marker.X * width / 10 / _bitmap.Width - width / 52;
                float nY = marker.Y * height / 10 / _bitmap.Height - height / 26;
                
               
                SKBitmap bitmap = SKBitmap.Decode(path).Resize(new SKImageInfo(width/26, height/20), SKBitmapResizeMethod.Box);
                canvas.DrawBitmap(bitmap, nX , nY);
                canvas.DrawText(marker.Name, nX, nY, new SKPaint { TextSize = 20});
            }
        }
    }
}
