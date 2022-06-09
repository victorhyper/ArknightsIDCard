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
using System.Windows.Shapes;

namespace IDCardMaker
{
    /// <summary>
    /// PopWindow.xaml 的交互逻辑
    /// </summary>
    public partial class PopWindow : Window
    {
        public Operator op;
        public PopWindow()
        {
            InitializeComponent();
            for(int i = 1; i < 91; i++)
            {
                Level.Items.Add(i);
            }
            for (int i = 1; i < 7; i++)
            {
                Potential.Items.Add(i);
            }
            Skin.Items.Add("精一");
            Skin.Items.Add("精二");
            Skin.Items.Add("skin1");
            Skin.Items.Add("skin2");
            Skin.Items.Add("skin3");
            Skin.SelectionChanged += new SelectionChangedEventHandler(SkinSelectChanged);
        }
        //皮肤选择变化时检查皮肤是否存在
        private void SkinSelectChanged(object sender,SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            string ImagePath =" ";
            string runningPath = System.IO.Directory.GetCurrentDirectory() + "\\Source\\Character";
            if (e.AddedItems[0].ToString() == "精一")
            {
                ImagePath = runningPath + "\\头像_" + op.Name + ".png";
            }
            else if (e.AddedItems[0].ToString() == "精二")
            {
                ImagePath = runningPath + "\\头像_" + op.Name + "_2.png";
            }
            else if (e.AddedItems[0].ToString() == "skin1")
            {
                ImagePath = runningPath + "\\头像_" + op.Name + "_skin1.png";
            }
            else if (e.AddedItems[0].ToString() == "skin2")
            {
                ImagePath = runningPath + "\\头像_" + op.Name + "_skin2.png";
            }
            else if (e.AddedItems[0].ToString() == "skin3")
            {
                ImagePath = runningPath + "\\头像_" + op.Name + "_skin3.png";
            }
            if(File.Exists(ImagePath))
            {
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.UriSource = new Uri(ImagePath, UriKind.Relative);
                bi.DecodePixelHeight = 180;
                bi.DecodePixelWidth = 180;
                bi.EndInit();
                bi.Freeze();
                Image temp = new Image();
                temp.Height = 80;
                temp.Width = 80;
                op.Source = bi;
                op.ImagePath= ImagePath;
                OperatorPhoto.Source = bi;
                return;
            }
            else
            {
                MessageBox.Show("该干员不存在该皮肤");
                comboBox.SelectedIndex = 0;
            }
        }
    }
}
