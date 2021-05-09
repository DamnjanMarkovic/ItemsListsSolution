using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfCustomControlLibrary
{
    public class FrameWorkElementImages: FrameworkElement
    {

        public ImageSource imageSource { get; set; }

        public FrameWorkElementImages(string imageName)
        {

            var imageLocation = $"pack://application:,,,/Resources/{imageName}";
            this.imageSource = new BitmapImage(new Uri(imageLocation, UriKind.Absolute));

            Height = this.imageSource.Height;
            Width = this.imageSource.Width;

        }

        protected override void OnRender(System.Windows.Media.DrawingContext drawingContext)
        {

            Rect bounds = new Rect(0, 0, Width, Height);
            drawingContext.DrawImage(this.imageSource, bounds);

        }

    }
}
