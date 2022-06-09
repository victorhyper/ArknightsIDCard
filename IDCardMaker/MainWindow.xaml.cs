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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IDCardMaker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public class Operator
    {
        //图片
        public ImageSource Source { get; set; }
        //图片路径
        public string ImagePath { get; set; }
        //皮肤
        public string Skin { get; set; }
        //名字
        public string Name { get; set; }
        //精英等级
        public int Elite { get; set; }
        //等级
        public int Level { get; set; }
        //星级
        public int Star { get; set; }
        //潜能
        public int Potential { get; set; }
        //技能
        public int Skill1 { get; set; }
        public int Skill2 { get; set; }
        public int Skill3 { get; set; }
        //模组
        public string Mod { get; set; }
        //是否拥有
        public bool Enable { get; set; }
    }
    public partial class MainWindow : Window
    {
        public List<Operator> operators;
        public MainWindow()
        {
            InitializeComponent();
            operators = new List<Operator>();
            StreamReader streamReader = new StreamReader(System.IO.Directory.GetCurrentDirectory() + "\\Source\\BoxData.json");
            string line,jstr="";
            while ((line = streamReader.ReadLine()) != null)
            {
                jstr += line;
            }
            operators=JsonProcess.LoadJson(jstr);
            LoadImage();
        }

        private void LoadImage()
        {
            //获取资源文件夹路径
            string runningPath = System.IO.Directory.GetCurrentDirectory()+ "\\Source\\Character";
            //获取图片信息
            var info = new DirectoryInfo(runningPath);

            for (int i = 0; i < operators.Count; i++)
            {
                if (operators[i].Skin=="精一")
                {
                    operators[i].ImagePath = runningPath + "\\头像_" + operators[i].Name + ".png";
                }                  
                else if(operators[i].Skin=="精二")
                {
                    operators[i].ImagePath = runningPath + "\\头像_" + operators[i].Name + "_2.png";
                }
                else if(operators[i].Skin=="skin1")
                {
                    operators[i].ImagePath = runningPath + "\\头像_" + operators[i].Name + "_skin1.png";
                }
                else if (operators[i].Skin == "skin2")
                {
                    operators[i].ImagePath = runningPath + "\\头像_" + operators[i].Name + "_skin2.png";
                }
                else if (operators[i].Skin == "skin3")
                {
                    operators[i].ImagePath = runningPath + "\\头像_" + operators[i].Name + "_skin3.png";
                }
            }
            int j = 0;
            for(int i = 0; i < operators.Count; i++)
            {
                if (i+1 - j * 12 > 12)
                    j++;
                InsertImage(j, i - j * 12, operators[i].ImagePath, operators[i]);
            }
        }
        private void InsertImage(int row,int col,string image,Operator op)
        {
            //读取
            FormatConvertedBitmap bitmap = new FormatConvertedBitmap();
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.UriSource = new Uri(image, UriKind.Relative);
            bi.DecodePixelHeight = 180;
            bi.DecodePixelWidth = 180;
            bi.EndInit();
            bi.Freeze();
            if (!op.Enable)
            {
                bitmap.BeginInit();
                bitmap.Source = (BitmapSource)bi;
                bitmap.DestinationFormat = PixelFormats.Gray32Float;
                bitmap.DestinationFormat = PixelFormats.Indexed4;
                //自定义调色板
                List<System.Windows.Media.Color> colors = new List<System.Windows.Media.Color>();
                colors.Add(Color.FromRgb(91,91,91));
                colors.Add(Color.FromRgb(92,92,92));
                colors.Add(Color.FromRgb(93,93,93));
                colors.Add(Color.FromRgb(94,94,94));
                colors.Add(Color.FromRgb(95,95,95));
                colors.Add(Color.FromRgb(111,111,111));
                colors.Add(Color.FromRgb(127,127,127));
                colors.Add(Color.FromRgb(143,143,143));
                colors.Add(Color.FromRgb(159,159,159));
                colors.Add(Color.FromRgb(175,175,175));
                colors.Add(Color.FromRgb(191,191,191));
                colors.Add(Color.FromRgb(207,207,207));
                colors.Add(Color.FromRgb(223,223,223));
                colors.Add(Color.FromRgb(239,239,239));
                colors.Add(Color.FromRgb(255, 255, 255));
                BitmapPalette myPalette = new BitmapPalette(colors);
                bitmap.DestinationPalette = myPalette;
                bitmap.EndInit();
                //bitmap.Freeze();
            }
           
            //显示
            Image temp = new Image();
            temp.Height = 80;
            temp.Width = 80;
            if (op.Enable)
                op.Source = bi;
            else
                op.Source = bitmap;
            temp.DataContext = op;
            if(op.Enable)
                temp.Source = bi;
            else
                temp.Source = bitmap;
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
            //右键单击
            if(e.ChangedButton==MouseButton.Right)
            {
                Operator op = (Operator)(((Image)sender).DataContext);
                if(op.Enable)
                {
                    var bi = ((Image)sender).Source;
                    FormatConvertedBitmap bitmap = new FormatConvertedBitmap();
                    bitmap.BeginInit();
                    bitmap.Source = (BitmapSource)bi;
                    bitmap.DestinationFormat = PixelFormats.Gray32Float;
                    bitmap.DestinationFormat = PixelFormats.Indexed4;
                    //自定义调色板
                    List<System.Windows.Media.Color> colors = new List<System.Windows.Media.Color>();
                    colors.Add(Color.FromRgb(91, 91, 91));
                    colors.Add(Color.FromRgb(92, 92, 92));
                    colors.Add(Color.FromRgb(93, 93, 93));
                    colors.Add(Color.FromRgb(94, 94, 94));
                    colors.Add(Color.FromRgb(95, 95, 95));
                    colors.Add(Color.FromRgb(111, 111, 111));
                    colors.Add(Color.FromRgb(127, 127, 127));
                    colors.Add(Color.FromRgb(143, 143, 143));
                    colors.Add(Color.FromRgb(159, 159, 159));
                    colors.Add(Color.FromRgb(175, 175, 175));
                    colors.Add(Color.FromRgb(191, 191, 191));
                    colors.Add(Color.FromRgb(207, 207, 207));
                    colors.Add(Color.FromRgb(223, 223, 223));
                    colors.Add(Color.FromRgb(239, 239, 239));
                    colors.Add(Color.FromRgb(255, 255, 255));
                    BitmapPalette myPalette = new BitmapPalette(colors);
                    bitmap.DestinationPalette = myPalette;
                    bitmap.EndInit();
                    //bitmap.Freeze();
                    ((Image)sender).Source = bitmap;
                    op.Enable = false;
                }
                else
                {
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(op.ImagePath, UriKind.Relative);
                    bitmap.DecodePixelHeight = 60;
                    bitmap.DecodePixelWidth = 60;
                    bitmap.EndInit();
                    bitmap.Freeze();
                    ((Image)sender).Source = bitmap;
                    op.Enable = true;
                }
                return;
            }
            //左键双击
            if(e.ChangedButton== MouseButton.Left&&e.ClickCount==2)
            {
                PopWindow popWindow = new PopWindow();
                var op =(Operator)((Image)sender).DataContext;
                popWindow.op = op;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(op.ImagePath, UriKind.Relative);
                bitmap.DecodePixelHeight = 180;
                bitmap.DecodePixelWidth = 180;
                bitmap.EndInit();
                bitmap.Freeze();
                popWindow.OperatorPhoto.Source = bitmap;
                popWindow.ShowDialog();
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
