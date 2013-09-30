using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers;
using System.ComponentModel;
using Navigator.Navigation;
using ViewModels.Interfaces;

namespace ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Constants

        public static readonly string Page1ViewModelAlias = "Page1VM";
        public static readonly string Page2ViewModelAlias = "Page2VM";
        public static readonly string Page3ViewModelAlias = "Page3VM";
        public static readonly string NotFoundPageViewModelAlias = "404VM";

        #endregion

        #region Fields

        private readonly IViewModelsResolver _resolver;

        private RelayCommand<string> _goToPathCommand;

        private RelayCommand<INotifyPropertyChanged> _goToPage1Command;

        private RelayCommand<INotifyPropertyChanged> _goToPage2Command;

        private RelayCommand<INotifyPropertyChanged> _goToPage3Command;

        private readonly INotifyPropertyChanged _p1ViewModel;
        private readonly INotifyPropertyChanged _p2ViewModel;
        private readonly INotifyPropertyChanged _p3ViewModel;

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

        public RelayCommand<INotifyPropertyChanged> GoToPage1Command
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

        public RelayCommand<INotifyPropertyChanged> GoToPage2Command
        {
            get { return _goToPage2Command; }
            set
            {
                _goToPage2Command = value;
                RaisePropertyChanged("GoToPage2Command");
            }
        }

        public RelayCommand<INotifyPropertyChanged> GoToPage3Command
        {
            get { return _goToPage3Command; }
            set
            {
                _goToPage3Command = value;
                RaisePropertyChanged("GoToPage3Command");
            }
        }

        public INotifyPropertyChanged Page1ViewModel
        {
            get { return _p1ViewModel; }
        }

        public INotifyPropertyChanged Page2ViewModel
        {
            get { return _p2ViewModel; }
        }

        public INotifyPropertyChanged Page3ViewModel
        {
            get { return _p3ViewModel; }
        }

        #endregion


        #region Constructors

        public MainViewModel(IViewModelsResolver resolver)
        {
            _resolver = resolver;

            _p1ViewModel = _resolver.GetViewModelInstance(Page1ViewModelAlias);
            _p2ViewModel = _resolver.GetViewModelInstance(Page2ViewModelAlias);
            _p3ViewModel = _resolver.GetViewModelInstance(Page3ViewModelAlias);

            InitializeCommands();
        }

        #endregion



        private void InitializeCommands()
        {
            
            GoToPathCommand = new RelayCommand<string>(GoToPathCommandExecute);

            GoToPage1Command = new RelayCommand<INotifyPropertyChanged>(GoToPage1CommandExecute);

            GoToPage2Command = new RelayCommand<INotifyPropertyChanged>(GoToPage2CommandExecute);

            GoToPage3Command = new RelayCommand<INotifyPropertyChanged>(GoToPage3CommandExecute);
        }

        private void GoToPathCommandExecute(string alias)
        {
            if (string.IsNullOrWhiteSpace(alias))
            {
                return;
            }
            
            Navigation.Navigate(alias);
        }

        private void GoToPage1CommandExecute(INotifyPropertyChanged viewModel)
        {
            Navigation.Navigate(Navigation.Page1Alias, Page1ViewModel);
        }

        private void GoToPage2CommandExecute(INotifyPropertyChanged viewModel)
        {
            Navigation.Navigate(Navigation.Page2Alias, Page1ViewModel);
        }

        private void GoToPage3CommandExecute(INotifyPropertyChanged viewModel)
        {
            Navigation.Navigate(Navigation.Page3Alias, Page1ViewModel);
        }
    }
}
