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
    public class MenuModel : NotifyObject
    {
        public MenuModel()
        {
            ShowMore = new CommandObject(_show);
            ShowDmgUI = new CommandObject(_showDmgUI);
        }
        public CommandObject ShowMore { get; set; }
        public CommandObject ShowDmgUI { get; set; }

        private DmgView dmgView = new DmgView();//实例化用户控件



        private string dmgUIState = "Hidden";
        public string DmgUIState 
        {
            get { return dmgUIState; }
            set 
            { 
                dmgUIState = value;
                Notify(nameof(DmgUIState));
            } 
        } 

        private string menuUIState = "Visible";
        public string MenuUIState
        { 
            get { return menuUIState; }
            set 
            {
                menuUIState = value;
                Notify(nameof(MenuUIState));
            }
        }

        private string advancedUIState = "Hidden";
        public string AdvancedUIState
        {
            get { return advancedUIState; }
            set
            {
                advancedUIState = value;
                Notify(nameof(AdvancedUIState));
            }
        }

        private string basicUIState = "Hidden";
        public string BasicUIState
        {
            get { return basicUIState; }
            set
            {
                basicUIState = value;
                Notify(nameof(BasicUIState));
            }
        }

        private void _showDmgUI()
        {
            MenuUIState = "Hidden";
            DmgUIState = "Visible";
            BasicUIState = "Visible";
        }
        private void _show()
        {
            UserContent = dmgView;
        }

        private UserControl content;
        public UserControl UserContent
        {
            get { return content; }
            set
            {
                content = value;
                Notify(nameof(UserControl));
            }
        }
    }
}