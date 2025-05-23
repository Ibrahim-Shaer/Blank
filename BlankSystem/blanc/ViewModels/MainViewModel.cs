using blanc.Models;
using blanc.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using FontAwesome.Sharp;
using System.Security.AccessControl;
using blanc.Views;

namespace blanc.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        private UserAccountModel? _currentUserAccount;
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;

        private IUserRepository userRepository;

      
        private TablesViewModel _tablesViewModel;
        private CategoryViewModel _categoryViewModel;
        private KitchenViewModel _kitchenViewModel;
        private MenuViewModel _menuViewModel;
        private StaffViewModel _staffViewModel;
        private DashboardViewModel _dashboardViewModel;
 


        public UserAccountModel? CurrentUserAccount
        {
            get
            {
                return _currentUserAccount;
            }
            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }
        public ViewModelBase CurrentChildView
        {
            get
            {
                return _currentChildView;
            }
            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }
        public string Caption
        {
            get
            {
                return _caption;
            }
            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }
        public IconChar Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }


        public ICommand ShowDashboardCommand { get; }
 
        public ICommand ShowCategoryCommand { get; }
        public ICommand ShowMenuCommand { get; }
    
        public ICommand ShowKitchenCommand { get; }
        public ICommand ShowTablesCommand { get; }


        public MainViewModel()
        {
            userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();

           
            ShowCategoryCommand = new ViewModelCommands(ExecuteShowCategoryCommand);
            ShowMenuCommand = new ViewModelCommands(ExecuteShowMenuCommand);
            ShowKitchenCommand = new ViewModelCommands(ExecuteShowKitchenCommand);
            ShowTablesCommand = new ViewModelCommands(ExecuteShowTablesCommand);

            ExecuteShowCategoryCommand(null);



            LoadCurrentUserData();
        }

        private void ExecuteShowTablesCommand(object obj)
        {
            if (_tablesViewModel == null) 
            {
                _tablesViewModel = new TablesViewModel();
            }

            CurrentChildView = _tablesViewModel;
            Caption = "Tables";
            Icon = IconChar.Table;
        }

        private void ExecuteShowKitchenCommand(object obj)
        {
            if (_kitchenViewModel == null)
            {
                _kitchenViewModel = new KitchenViewModel();
            }
            CurrentChildView = _kitchenViewModel;
            Caption = "Kitchen";
            Icon = IconChar.CodeFork;
        }

       
        private void ExecuteShowCategoryCommand(object obj)
        {

            if (_categoryViewModel == null)
            {
                _categoryViewModel = new CategoryViewModel();
            }
            CurrentChildView = _categoryViewModel;
            Caption = "Reservation";
            Icon = IconChar.Table;
        }
        private void ExecuteShowMenuCommand(object obj)
        {

            if (_menuViewModel == null)
            {
                _menuViewModel = new MenuViewModel();
            }
            CurrentChildView = _menuViewModel;
            Caption = "Menu";
            Icon = IconChar.Book;
        }

 
      

       
        private void LoadCurrentUserData()
        {
            if (userRepository != null)
            {
                var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
                if (user != null)
                {
                    CurrentUserAccount = new UserAccountModel()
                    {
                        Username = user.Username,
                        DisplayName = $"{user.Username}",//{user.Id}",
                        ProfilePicture = null
                    };
                }
            }
            else
            {
                MessageBox.Show("Invalid user, not logged in");
                Application.Current.Shutdown();
            }
        }

        private ViewModelCommands? logoutCommand;

        public ICommand LogoutCommand => logoutCommand ??= new ViewModelCommands(Logout);


        private void Logout(object commandParameter)
        {

        }
    }
}
