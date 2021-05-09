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
            //Height = 50;
            this.ImageName = ImageName;
            this.TextUnder = TextUnder;

            AddImagesAndText();


        }

        private void AddImagesAndText()
        {


            FrameWorkElementImages image = new FrameWorkElementImages(ImageName) ;
            this.Children.Add(image);



            FrameTest text = new FrameTest(TextUnder);
            Canvas.SetTop(text, image.Height);
            Canvas.SetLeft(text, 20);
            this.Children.Add(text);

            Border border = new Border();
            border.CornerRadius = new CornerRadius(5);
            border.BorderBrush = Brushes.Red;
            border.BorderThickness = new Thickness(3);
            border.Width = 50;
            border.Height = image.Height + text.Height;
            this.Children.Add(border);



            this.Height = image.Height + text.Height;




            //Button btn = new Button();
            //btn.Background = Brushes.Red;
            //btn.Width = 50;
            //btn.Height = 50;
            //this.Children.Add(btn);
        }
    }
}
