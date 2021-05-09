using System;
using System.Collections.Generic;
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

namespace WpfCustomControlLibrary
{
    /// <summary>
    /// Interaction logic for ImageText.xaml
    /// </summary>
    public partial class ImageText : Canvas
    {

        public string ImageName { get; set; }
        public string TextUnder { get; set; }

        public ImageText(string ImageName, string TextUnder)
        {
            InitializeComponent();
            this.ImageName = ImageName;
            this.TextUnder = TextUnder;

            AddImagesAndText();


        }

        private void AddImagesAndText()
        {


            FrameWorkElementImages image = new FrameWorkElementImages(ImageName);
            this.Children.Add(image);



            FrameTest text = new FrameTest(TextUnder);
            Canvas.SetTop(text, image.Height);
            Canvas.SetLeft(text, image.Width / 2);
            this.Children.Add(text);




            Margin = new Thickness(10);



            //Border border = new Border();
            //border.CornerRadius = new CornerRadius(5);
            //border.BorderBrush = Brushes.Red;
            //border.BorderThickness = new Thickness(3);
            //border.Width = 50;
            //border.Height = image.Height + text.Height;
            //this.Children.Add(border);



            string PlayBack_01String = ("m323.332031 26.625c-3.863281-2.25-8.636719-2.25-12.5 0l-281.625 162.5c-3.359375 1.96875-5.621093 5.386719-6.125 9.25v-185.875c0-6.90625-5.59375-12.5-12.5-12.5-6.902343 0-12.5 5.59375-12.5 12.5v375c0 6.90625 5.597657 12.5 12.5 12.5 6.90625 0 12.5-5.59375 12.5-12.5v-186c.46875 3.875 2.742188 7.304688 6.125 9.25l281.625 162.625c3.886719 2.167969 8.617188 2.167969 12.5 0 3.878907-2.246094 6.261719-6.390625 6.25-10.875v-325.125c.039063-4.453125-2.359375-8.578125-6.25-10.75zm-18.75 314.375-244.125-141 244.125-141zm0 0");
            Geometry PlayBackUntilEnd_01 = Geometry.Parse(PlayBack_01String);


            Path path = new Path();
            path.Data = PlayBackUntilEnd_01;
            path.Fill = Brushes.Red;
            path.Width = 40;
            path.Height = 40;
            path.Stretch = Stretch.Fill;
            Canvas.SetTop(path, image.Height + 10);
            Canvas.SetLeft(path, 20);
            this.Children.Add(path);


            //this.Height = 50;
            //this.Width = 50;





            //Button btn = new Button();
            //btn.Background = Brushes.Red;
            //btn.Width = 50;
            //btn.Height = 50;
            //this.Children.Add(btn);
        }

        protected override void OnRender(System.Windows.Media.DrawingContext drawingContext)
        {


            Rect bounds = new Rect(0, 0, Width, Height);
            Pen pen = new Pen(Brushes.Green, 4);
            drawingContext.DrawRoundedRectangle(Brushes.Yellow, pen, bounds, 5, 5);


            string ImagePawnString = ("M35.54,35.2H14.46A.64.64,0,0,1,14,35a.66.66,0,0,1-.13-.51,11.4,11.4,0,0,1,5.27-7.72,7.43,7.43,0,1,1,11.76,0,11.4,11.4,0,0,1,5.27,7.72A.66.66,0,0,1,36,35,.64.64,0,0,1,35.54,35.2ZM15.23,34H34.77a10.13,10.13,0,0,0-5.15-6.47A.62.62,0,0,1,29.3,27a.61.61,0,0,1,.16-.53,6.18,6.18,0,1,0-8.92,0,.61.61,0,0,1,.16.53.62.62,0,0,1-.32.46A10.13,10.13,0,0,0,15.23,34Z");
            Geometry ImagePawn = Geometry.Parse(ImagePawnString);


            //Rect boundsGeometry = new Rect(100, 100, 80, 80);
            Pen penGeometry = new Pen(Brushes.Orange, 2);
            drawingContext.DrawGeometry(Brushes.Pink, pen, ImagePawn);



            this.Height = 100;
            this.Width = 80;

        }

    }
}
