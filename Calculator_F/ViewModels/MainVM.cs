using Calculator_F.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Calculator_F.ViewModels
{
    public class MainVM : NotifyObject
    {
        public MainVM()
        {
            /*菜单相关控件Command*/
            ShowMore = new CommandObject(_show);
            ShutDown = new CommandObject(_shutdown);
            Minimize = new CommandObject(_minimize);

            /* */
        }

        public CommandObject ShowMore { get; set; }
        public CommandObject ShutDown { get; set; }
        public CommandObject Minimize { get; set; }
        public CommandObject ShowDmgUI { get; set; }
        private void _show()
        {
            MessageBox.Show("敬请期待");
        }
        private void _showDmgUI()
        {

        }
        private void _shutdown()
        {
            Application.Current.Shutdown();
        }
        private void _minimize()
        {
            var mainWindow = Application.Current.MainWindow;
            mainWindow.WindowState = WindowState.Minimized;
        }

    }
}