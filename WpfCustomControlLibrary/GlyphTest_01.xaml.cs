using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfCustomControlLibrary
{
    /// <summary>
    /// Interaction logic for GlyphTest_01.xaml
    /// </summary>
    public partial class GlyphTest_01 : UserControl
    {
        Random rand = new Random();

        Stopwatch stopwatch;
        long frameCounter = 0;

        GlyphTypeface glyphTypeface;
        double renderingEmSize, advanceWidth, advanceHeight;
        Point baselineOrigin;

        public GlyphTest_01()
        {
            InitializeComponent();

            new Typeface("Consolas").TryGetGlyphTypeface(out this.glyphTypeface);
            this.renderingEmSize = 10;
            this.advanceWidth = this.glyphTypeface.AdvanceWidths[0] * this.renderingEmSize;
            this.advanceHeight = this.glyphTypeface.Height * this.renderingEmSize;
            this.baselineOrigin = new Point(0, this.glyphTypeface.Baseline * this.renderingEmSize);

            CompositionTarget.Rendering += CompositionTarget_Rendering;

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            if (this.stopwatch == null)
                this.stopwatch = Stopwatch.StartNew();

            ++this.frameCounter;

            this.drawingImage.Drawing = this.Render();
        }

        string GenerateRandomString(int length)
        {
            var chars = new char[length];
            for (int i = 0; i < chars.Length; ++i)
                chars[i] = (char)rand.Next('A', 'Z' + 1);

            return new string(chars);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            var seconds = this.stopwatch.Elapsed.TotalSeconds;
            Trace.WriteLine((long)(this.frameCounter / seconds));

            if (seconds > 10)
            {
                this.stopwatch.Restart();
                this.frameCounter = 0;
            }
        }

        private Drawing Render()
        {
            var lines = new string[30];
            for (int i = 0; i < lines.Length; ++i)
                lines[i] = GenerateRandomString(100);

            var drawing = new DrawingGroup();
            using (var drawingContext = drawing.Open())
            {
                // TODO: draw rectangles which represent background.

                // TODO: group of glyphs which has the same color should be drawn together.
                // Following code draws all glyphs in Red color.
                var glyphRun = ConvertTextLinesToGlyphRun(this.glyphTypeface, this.renderingEmSize, this.advanceWidth, this.advanceHeight, this.baselineOrigin, lines);
                drawingContext.DrawGlyphRun(Brushes.Red, glyphRun);
            }

            return drawing;
        }

        static GlyphRun ConvertTextLinesToGlyphRun(GlyphTypeface glyphTypeface, double renderingEmSize, double advanceWidth, double advanceHeight, Point baselineOrigin, string[] lines)
        {
            var glyphIndices = new List<ushort>();
            var advanceWidths = new List<double>();
            var glyphOffsets = new List<Point>();

            var y = baselineOrigin.Y;
            for (int i = 0; i < lines.Length; ++i)
            {
                var line = lines[i];

                var x = baselineOrigin.X;
                for (int j = 0; j < line.Length; ++j)
                {
                    var glyphIndex = glyphTypeface.CharacterToGlyphMap[line[j]];
                    glyphIndices.Add(glyphIndex);
                    advanceWidths.Add(0);
                    glyphOffsets.Add(new Point(x, y));

                    x += advanceWidth;

                }

                y += advanceHeight;
            }

            return new GlyphRun(
                glyphTypeface,
                0,
                false,
                renderingEmSize,
                glyphIndices,
                baselineOrigin,
                advanceWidths,
                glyphOffsets,
                null,
                null,
                null,
                null,
                null);

            //        new GlyphTypeface(new Uri(@"C:\WINDOWS\Fonts\TIMES.TTF")),
            //0,
            //false,
            //13.333333333333334,
            //new ushort[] { 43, 72, 79, 79, 82, 3, 58, 82, 85, 79, 71 },
            //new Point(0, 12.29),
            //new double[]{
            //    9.62666666666667, 7.41333333333333, 2.96,
            //    2.96, 7.41333333333333, 3.70666666666667,
            //    12.5866666666667, 7.41333333333333,
            //    4.44, 2.96, 7.41333333333333},
            //null,
            //null,
            //null,
            //null,
            //null,
            //null

            //);
        }
    }
}
