using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Reflection;
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

using Calculator_F.ViewModels;

namespace Calculator_F.Views
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        struct photoData
        {
            public decimal Bonus { get; set; }
            public decimal Multi { get; set; }
        }

        private decimal staticIndex = 0m;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainMenu();
        }

        private void selectAudio(int index)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            if (index == 0)
            {
                Random rd = new Random();
                string[] audioFiles = new[] { "1.wav", "2.wav", "3.wav", "4.wav", "5.wav", "6.wav", "7.wav" };
                SoundPlayer audio = new SoundPlayer(assembly.GetManifestResourceStream(@"Calculator_F.Resources." + audioFiles[rd.Next(0, 7)]));
                audio.Play();
                audio.Dispose();
            }
        }

        private void minimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Gin_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            decimal result = 1m, comboIndex = 1m, actIndex = 1m;


            switch (dmgComboMulti.SelectedIndex)
            {
                case 0:
                    comboIndex = 1m;
                    break;
                case 1:
                    comboIndex = 1.2m;
                    break;
                case 2:
                    comboIndex = 1.4m;
                    break;
                case 3:
                    comboIndex = 1.45m;
                    break;
                case 4:
                    comboIndex = 1.5m;
                    break;
            }
            switch (dmgActMulti.SelectedIndex)
            {
                case 0:
                    actIndex = 1m;
                    break;
                case 1:
                    actIndex = 1.005m;
                    break;
                case 2:
                    actIndex = 1.01m;
                    break;
                case 3:
                    actIndex = 1.015m;
                    break;
                case 4:
                    actIndex = 1.02m;
                    break;
            }

            result = staticIndex
                * (TurnIndex(dmgBasicMulti.Text)) / 100
                * (TurnIndex(dmgPlasmMulti.Text) / 100 + 1)
                * (TurnIndex(dmgCaptainMulti.Text) / 100 + 1)
                * comboIndex * actIndex;
            dmgResult.Content = result.ToString("F2");
            selectAudio(0);
        }

        private void dmgIfCaptain_Click(object sender, RoutedEventArgs e)
        {
            if (dmgIfCaptain.IsChecked == true)
            {
                dmgCaptainMulti.Text = "60.125";
                dmgCaptainMulti.IsEnabled = true;
            }
            else
            {
                dmgCaptainMulti.Text = "0";
                dmgCaptainMulti.IsEnabled = false;
            }
        }

        private void photoSlot_DropDownClosed(object sender, EventArgs e)
        {
            switch (photoSlot.SelectedIndex)
            {
                case 0:
                    photoBonus2.Text = "0";
                    photoMulti2.Text = "0";
                    photoBonus3.Text = "0";
                    photoMulti3.Text = "0";
                    photoBonus4.Text = "0";
                    photoMulti4.Text = "0";
                    photoBonus2.IsEnabled = false;
                    photoMulti2.IsEnabled = false;
                    photoBonus3.IsEnabled = false;
                    photoMulti3.IsEnabled = false;
                    photoBonus4.IsEnabled = false;
                    photoMulti4.IsEnabled = false;
                    break;
                case 1:
                    photoBonus2.IsEnabled = true;
                    photoMulti2.IsEnabled = true;
                    photoBonus3.Text = "0";
                    photoMulti3.Text = "0";
                    photoBonus4.Text = "0";
                    photoMulti4.Text = "0";
                    photoBonus3.IsEnabled = false;
                    photoMulti3.IsEnabled = false;
                    photoBonus4.IsEnabled = false;
                    photoMulti4.IsEnabled = false;
                    break;
                case 2:
                    photoBonus2.IsEnabled = true;
                    photoMulti2.IsEnabled = true;
                    photoBonus3.IsEnabled = true;
                    photoMulti3.IsEnabled = true;
                    photoBonus4.Text = "0";
                    photoMulti4.Text = "0";
                    photoBonus4.IsEnabled = false;
                    photoMulti4.IsEnabled = false;
                    break;
                default:
                    photoBonus2.IsEnabled = true;
                    photoMulti2.IsEnabled = true;
                    photoBonus3.IsEnabled = true;
                    photoMulti3.IsEnabled = true;
                    photoBonus4.IsEnabled = true;
                    photoMulti4.IsEnabled = true;
                    break;
            }
        }

        private void ifAdvance_Click(object sender, RoutedEventArgs e)
        {
            if (ifAdvance.IsChecked == true)
                advancedUI.Visibility = Visibility.Visible;
            else
                advancedUI.Visibility = Visibility.Hidden;
        }

        private void Refresh_indexTotal(object sender, TextChangedEventArgs e)
        {
            if (photoMulti4 != null)
            {
                photoData[] pts = new photoData[4];
                PhotoSlotData(pts);
                staticIndex = (TurnIndex(indexBasic.Text)
                    + TurnIndex(itemBonus1.Text) + TurnIndex(itemBonus2.Text)
                    + pts[0].Bonus + pts[1].Bonus + pts[2].Bonus + pts[3].Bonus)
                    * (pts[0].Multi / 100 + 1) * (pts[1].Multi / 100 + 1) * (pts[2].Multi / 100 + 1) * (pts[3].Multi / 100 + 1)
                    * (1 + TurnIndex(itemMulti1.Text) / 100 + TurnIndex(itemMulti2.Text) / 100);
                indexTotal.Text = staticIndex.ToString($"{0}");
            }
        }

        private void PhotoSlotData(photoData[] pts)
        {
            var photoMultiArray = new[] { photoMulti1, photoMulti2, photoMulti3, photoMulti4 };
            var photoBonusArray = new[] { photoBonus1, photoBonus2, photoBonus3, photoBonus4 };
            int a = (photoSlot.SelectedIndex + 1) / 4;
            int b = (photoSlot.SelectedIndex + 1) % 4;
            for (int i = 0; i < pts.Length; i++)
            {
                pts[i].Multi = TurnIndex(photoMultiArray[i].Text);
                pts[i].Bonus = TurnIndex(photoBonusArray[i].Text);
            }
            if (a == 1)
                for (int i = 0; i < b; i++) pts[i].Bonus *= 1.25m;
            else if (a == 2)
            {
                for (int i = 0; i < pts.Length; i++) pts[i].Bonus *= 1.25m;
                for (int i = 0; i < b; i++) pts[i].Bonus *= 1.2m;
            }
            else if (a == 3)
                for (int i = 0; i < pts.Length; i++) pts[i].Bonus *= 1.5m;
        }

        private decimal TurnIndex(string s)
        {
            decimal index = 0m;
            if (decimal.TryParse(s, out index)) return index;
            else return index;
        }
    }
}