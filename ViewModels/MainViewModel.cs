using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NavigationHelpers;
using Helpers;

namespace ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Fields

        private RelayCommand<string> _goToPathCommand;

        private RelayCommand<Page1ViewModel> _goToPage1Command;

        private RelayCommand<Page2ViewModel> _goToPage2Command;

        private RelayCommand<Page3ViewModel> _goToPage3Command;

        #endregion


        #region Properties

        public RelayCommand<string> GoToPathCommand
        {
            get { return _goToPathCommand; }
            set
            {
                _goToPathCommand = value;
                RaisePropertyChanged("GoToPathCommand");
            }
        }

        public RelayCommand<Page1ViewModel> GoToPage1Command
        {
            get 
            { 
                return _goToPage1Command; 
            }
            set
            {
                _goToPage1Command = value;
                RaisePropertyChanged("GoToPage1Command");
            }
        }

        public RelayCommand<Page2ViewModel> GoToPage2Command
        {
            get { return _goToPage2Command; }
            set
            {
                _goToPage2Command = value;
                RaisePropertyChanged("GoToPage2Command");
            }
        }

        public RelayCommand<Page3ViewModel> GoToPage3Command
        {
            get { return _goToPage3Command; }
            set
            {
                _goToPage3Command = value;
                RaisePropertyChanged("GoToPage3Command");
            }
        }

        private Page1ViewModel _p1ViewModel = new Page1ViewModel();
        public Page1ViewModel Page1ViewModel
        {
            get { return _p1ViewModel; }
        }

        private Page2ViewModel _p2ViewModel = new Page2ViewModel();
        public Page2ViewModel Page2ViewModel
        {
            get { return _p2ViewModel; }
        }

        private Page3ViewModel _p3ViewModel = new Page3ViewModel();
        public Page3ViewModel Page3ViewModel
        {
            get { return _p3ViewModel; }
        }

        #endregion


        #region Constructors

        public MainViewModel()
        {
            InitializeCommands();
        }

        #endregion



        private void InitializeCommands()
        {
            
            GoToPathCommand = new RelayCommand<string>(GoToPathCommandExecute);

            GoToPage1Command = new RelayCommand<Page1ViewModel>(GoToPage1CommandExecute);

            GoToPage2Command = new RelayCommand<Page2ViewModel>(GoToPage2CommandExecute);

            GoToPage3Command = new RelayCommand<Page3ViewModel>(GoToPage3CommandExecute);
        }

        private void GoToPathCommandExecute(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return;
            }
            
            var uri = new Uri(path);

            Navigation.Navigate(uri);
        }

        private void GoToPage1CommandExecute(Page1ViewModel viewModel)
        {
            var uri = new Uri("pack://application:,,,/Pages;component/Page1.xaml");

            Navigation.Navigate(uri, new Page1ViewModel());
        }

        private void GoToPage2CommandExecute(Page2ViewModel viewModel)
        {
            var uri = new Uri("pack://application:,,,/Pages;component/Page2.xaml");

            Navigation.Navigate(uri, new Page2ViewModel());
        }

        private void GoToPage3CommandExecute(Page3ViewModel viewModel)
        {
            var uri = new Uri("pack://application:,,,/Pages;component/Page3.xaml");

            Navigation.Navigate(uri, new Page3ViewModel());
        }
    }
}
