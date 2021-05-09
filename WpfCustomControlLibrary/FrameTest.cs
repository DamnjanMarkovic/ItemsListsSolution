using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfCustomControlLibrary
{
    public class FrameTest: FrameworkElement
    {
        public string TextUnderImage { get; set; }
        public FrameTest(string someText)
        {
            Height = 50;
            TextUnderImage = someText;
        }

        protected override void OnRender(System.Windows.Media.DrawingContext drawingContext)
        {

            Typeface Typeface1 = new Typeface(new FontFamily("Century"), FontStyles.Normal, FontWeights.Bold, FontStretches.Normal);
            FormattedText ft = new FormattedText(TextUnderImage, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface1, 22, Brushes.Red, 1.0);
            drawingContext.DrawText(ft, new Point(0, 0));

        }





    }
}
