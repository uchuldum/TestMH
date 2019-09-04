using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System.Reflection;
using System.IO;

namespace Test
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();
            
            SKCanvasView canvasView = new SKCanvasView();
            canvasView.PaintSurface += OnCanvasViewPaintSurface;
            Content = canvasView;
            

        }
        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;
           
            MergeImages mergeImages = new MergeImages(canvas, info.Width, info.Height);
            Marker marker = new Marker();
            marker.AddMarker("площадь Карла Маркса", 825, 1600);
            marker.AddMarker("площадь Калинина", 950, 712);
            marker.AddMarker("Первомайский сквер", 987, 1075);
            marker.AddMarker("Речной вокзал", 1090, 1279);
            marker.DrawMarkers(canvas, info.Width, info.Height);
            
        }
    }
}
