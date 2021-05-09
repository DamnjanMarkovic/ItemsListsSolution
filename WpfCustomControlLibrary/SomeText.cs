using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace WpfCustomControlLibrary
{
    public class SomeText : FrameworkElement
    {
        public FontFamily FontFamily { get; set; }
        public FontWeight FontWeight { get; set; }
        public FontStyle FontStyle { get; set; }
        public int FontSize { get; set; }
        public int Stroke { get; set; }

        public SolidColorBrush Background { get; set; }
        public SolidColorBrush Foreground { get; set; }
        public SolidColorBrush BorderBrush { get; set; }

        private Typeface Typeface;
        private VisualCollection Visuals;
        private Action RenderTextAction;
        private DispatcherOperation CurrentDispatcherOperation;

        private string text;
        public string Text
        {
            get { return text; }
            set
            {
                if (String.Equals(text, value, StringComparison.CurrentCulture))
                    return;

                text = value;
                QueueRenderText();
            }
        }

        public SomeText()
        {
            Visuals = new VisualCollection(this);

            FontFamily = new FontFamily("Century");
            FontWeight = FontWeights.Bold;
            FontStyle = FontStyles.Normal;
            FontSize = 24;
            Stroke = 1;
            Typeface = new Typeface(FontFamily, FontStyle, FontWeight, FontStretches.Normal);

            Foreground = Brushes.Black;
            BorderBrush = Brushes.Gold;

            RenderTextAction = () => { RenderText(); };
            Loaded += (o, e) => { QueueRenderText(); };
        }

        private void QueueRenderText()
        {
            if (CurrentDispatcherOperation != null)
                CurrentDispatcherOperation.Abort();

            CurrentDispatcherOperation = Dispatcher.BeginInvoke(RenderTextAction, DispatcherPriority.Render, null);

            CurrentDispatcherOperation.Aborted += (o, e) => { CurrentDispatcherOperation = null; };
            CurrentDispatcherOperation.Completed += (o, e) => { CurrentDispatcherOperation = null; };
        }

        private void RenderText()
        {
            Visuals.Clear();

            DrawingVisual visual = new DrawingVisual();
            using (DrawingContext dc = visual.RenderOpen())
            {
                FormattedText ft = new FormattedText(Text, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, Typeface, FontSize, Foreground, 1.0);
                Geometry geometry = ft.BuildGeometry(new Point(0.0, 0.0));
                dc.DrawText(ft, new Point(0.0, 0.0));
                dc.DrawGeometry(null, new Pen(BorderBrush, Stroke), geometry);

            }
            Visuals.Add(visual);
        }

        protected override Visual GetVisualChild(int index)
        {
            return Visuals[index];
        }

        protected override int VisualChildrenCount
        {
            get { return Visuals.Count; }
        }
    }
}
