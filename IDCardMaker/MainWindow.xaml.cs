using System;
using System.Collections.Generic;
using System.IO;
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

namespace IDCardMaker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadImage();
        }

        private void LoadImage()
        {
            //获取资源文件夹路径
            string runningPath = System.IO.Directory.GetCurrentDirectory()+ "\\Source\\Character";
            //获取图片信息
            var info = new DirectoryInfo(runningPath);
            List<string> images = new List<string>();
            foreach(var file in info.GetFiles())
            {
                images.Add(runningPath+"\\"+file.Name);
            }
            int j = 0;
            for(int i = 0; i < images.Count; i++)
            {
                if (i+1 - j * 12 > 12)
                    j++;
                InsertImage(j, i - j * 12, images[i]);
            }
        }
        private void InsertImage(int row,int col,string image)
        { 
            //读取
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.UriSource = new Uri(image, UriKind.Relative);
            bi.DecodePixelHeight = 60;
            bi.DecodePixelWidth = 60;
            bi.EndInit();
            bi.Freeze();
            //显示
            Image temp = new Image();
            temp.Height = 80;
            temp.Width = 80;
            temp.Source = bi;           
            temp.MouseDown += new MouseButtonEventHandler(Image_OnMouseDown);
           

            Border border = new Border();
            border.Child = temp;
            border.Width = 90;
            border.Height = 90;
            border.BorderThickness = new Thickness(3);
            border.CornerRadius = new CornerRadius(3);
            border.BorderBrush = new SolidColorBrush(Color.FromArgb(0,0,0,0));
            border.SetValue(Grid.RowProperty, row);
            border.SetValue(Grid.ColumnProperty, col);
            border.MouseEnter += new MouseEventHandler(Image_OnMouseHover);
            border.MouseLeave += new MouseEventHandler(Image_OnMouseHover);
            CharacterGrid.Children.Add(border);
        }
        private void Image_OnMouseDown(object sender,MouseButtonEventArgs e)
        {
            if(e.ChangedButton==MouseButton.Right)
            {
                var bi = ((Image)sender).Source;
                FormatConvertedBitmap bitmap = new FormatConvertedBitmap();
                bitmap.BeginInit();
                bitmap.Source = (BitmapSource)bi;
                bitmap.DestinationFormat = PixelFormats.Gray32Float;
                bitmap.EndInit();
                bitmap.Freeze();
                ((Image)sender).Source = bitmap;
            }
        }
        private void Image_OnMouseHover(object sender,MouseEventArgs e)
        {
            if(e.RoutedEvent==MouseEnterEvent)
            {
                ((Border)sender).BorderBrush= Brushes.Green;
                return;
            }
            if(e.RoutedEvent==MouseLeaveEvent)
            {
                ((Border)sender).BorderBrush = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
                return;
            }
        }
    }
}
