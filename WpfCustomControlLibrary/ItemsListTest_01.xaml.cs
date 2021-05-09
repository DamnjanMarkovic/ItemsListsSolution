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
    /// Interaction logic for ItemsListTest_01.xaml
    /// </summary>
    public partial class ItemsListTest_01 : UserControl
    {
        public ItemsListTest_01()
        {
            InitializeComponent();
            SetTextIntoPanel();
            SetUsersIntoPanel();
            SetFrameTest();
            SetImageIntoPanel();
            SetImageText();

        }

        private void SetImageText()
        {
            List<ImageText> items = new List<ImageText>();
            items.Add(new ImageText("rejected.png", "1"));
            items.Add(new ImageText("Selected.png", "2"));
            items.Add(new ImageText("Stitched.png", "3"));
            items.Add(new ImageText("Stored.png", "4"));
            items.Add(new ImageText("Storing.png", "5"));
            listImageText.ItemsSource = items;
        }

        private void SetImageIntoPanel()
        {
            List<Image> items = new List<Image>();
            items.Add(CreateImage("rejected.png"));
            items.Add(CreateImage("Selected.png"));
            items.Add(CreateImage("Stitched.png"));
            items.Add(CreateImage("Stored.png"));
            items.Add(CreateImage("Storing.png"));
            listImages.ItemsSource = items;

            List<FrameWorkElementImages> itemsImagesFramework = new List<FrameWorkElementImages>();
            itemsImagesFramework.Add(new FrameWorkElementImages("rejected.png") );
            itemsImagesFramework.Add(new FrameWorkElementImages("Selected.png") );
            itemsImagesFramework.Add(new FrameWorkElementImages("Stitched.png") );
            itemsImagesFramework.Add(new FrameWorkElementImages("Stored.png") );
            itemsImagesFramework.Add(new FrameWorkElementImages("Storing.png") );
            listFrameWorkImages.ItemsSource = itemsImagesFramework;


        }

        private Image CreateImage(string imageName)
        {
            var imageLocation = $"pack://application:,,,/Resources/{imageName}";
            var source = new BitmapImage(new Uri(imageLocation, UriKind.Absolute));
            Image imagetest = new Image();
            imagetest.Source = source;
            imagetest.Height = 50;
            return imagetest;
        }

        private void SetFrameTest()
        {
            List<FrameTest> items = new List<FrameTest>();
            items.Add(new FrameTest("1") );
            items.Add(new FrameTest("2") );
            items.Add(new FrameTest("3") );
            items.Add(new FrameTest("4") );
            items.Add(new FrameTest("5") );
            items.Add(new FrameTest("6") );
            listFrameText.ItemsSource = items;
        }

        private void SetUsersIntoPanel()
        {
            List<User> items = new List<User>();
            items.Add(new User() { Name = "John Doe", Age = 42 });
            items.Add(new User() { Name = "Jane Doe", Age = 39 });
            items.Add(new User() { Name = "Sammy Doe", Age = 13 });
            listUsers.ItemsSource = items;
        }

        private void SetTextIntoPanel()
        {
            List<SomeText> itemsText = new List<SomeText>();

            itemsText.Add(new SomeText() { Text = "jedan", FontSize = 28, Height = 50 });
            itemsText.Add(new SomeText() { Text = "dva", FontSize = 28, Height = 50 });
            itemsText.Add(new SomeText() { Text = "tri", FontSize = 28, Height = 50 });
            itemsText.Add(new SomeText() { Text = "cetiri", FontSize = 28, Height = 50 });
            itemsText.Add(new SomeText() { Text = "pet", FontSize = 28, Height = 50 });
            listText.ItemsSource = itemsText;
            
        }


    }

    public class User
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return this.Name + ", " + this.Age + " years old";
        }
    }
}
