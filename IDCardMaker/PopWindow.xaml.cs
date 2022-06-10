using MaterialDesignThemes.Wpf;
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
        public bool Refresh;
        public PopWindow()
        {
            Refresh = false;
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
                op.Skin = e.AddedItems[0].ToString();
                OperatorPhoto.Source = bi;
                return;
            }
            else
            {
                MessageBox.Show("该干员不存在该皮肤");
                comboBox.SelectedIndex = 0;
            }
        }
        //确认按钮点击
        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            Refresh = true;
            op.Enable = true;
            this.Close();
        }
        //取消按钮
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Refresh = false;
            this.Close();
        }
        //精英等级切换
        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            ListBoxItem listBoxItem = sender as ListBoxItem;
            var sel=listBoxItem.Content as string;
            if(sel=="未精")
            {
                op.Elite = 0;
                EliteShow.Content = 0;
                ButtonProgressAssist.SetValue(EliteShow,0);
            }
            if(sel=="精一")
            {
                op.Elite = 1;
                EliteShow.Content = 1;
                ButtonProgressAssist.SetValue(EliteShow, 50);
            }
            if(sel=="精二")
            {
                op.Elite = 2;
                EliteShow.Content = 2;
                ButtonProgressAssist.SetValue(EliteShow, 100);
            }
        }

        public void SetShow()
        {
            //关联
            EliteSel.SelectedIndex = op.Elite;
            Level.SelectedIndex = op.Level-1;
            Potential.SelectedIndex = op.Potential;
            Skin.SelectedValue = op.Skin;

            LevelShow.Content = "LV" + op.Level;
            EliteShow.Content = op.Elite;
            PotenialShow.Content = op.Potential;

            ButtonProgressAssist.SetValue(LevelShow, (op.Level / 90.0)*100);
            ButtonProgressAssist.SetValue(EliteShow, (op.Elite / 2.0)*100);
            ButtonProgressAssist.SetValue(PotenialShow, (op.Potential / 6.0)*100);

            skill1.Value = op.Skill1;
            skill2.Value = op.Skill2;
            skill3.Value = op.Skill3;

            if(op.Star==2)
            {
                skill1.IsEnabled = false;
                skill2.IsEnabled = false;
                skill3.IsEnabled = false;
                return;
            }
            if(op.Star==3)
            {
                skill1.IsEnabled = true;
                skill2.IsEnabled = false;
                skill3.IsEnabled = false;
                return ;
            }
            if (op.Star == 4||op.Star==5)
            {
                skill1.IsEnabled = true;
                skill2.IsEnabled = true;
                skill3.IsEnabled = false;
                return;
            }
            if (op.Star == 6)
            {
                skill1.IsEnabled = true;
                skill2.IsEnabled = true;
                skill3.IsEnabled = true;
                return;
            }
        }

        public void RefreshShow()
        {
            LevelShow.Content = "LV" + op.Level;
            EliteShow.Content = op.Elite;
            PotenialShow.Content = op.Potential;

            ButtonProgressAssist.SetValue(LevelShow, (op.Level / 90.0) * 100);
            ButtonProgressAssist.SetValue(EliteShow, (op.Elite / 2.0) * 100);
            ButtonProgressAssist.SetValue(PotenialShow, (op.Potential / 6.0) * 100);
        }

        private void Level_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var sel = e.AddedItems[0];
            int level = Convert.ToInt32(sel.ToString());
            op.Level = level;
            RefreshShow();
        }

        private void Potential_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var sel = e.AddedItems[0];
            int potenial = Convert.ToInt32(sel.ToString());
            op.Potential = potenial;
            RefreshShow();
        }
    }
}
