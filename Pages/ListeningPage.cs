using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using ViewModels;

namespace Pages
{
    public class ListeningPage<T> : Page
        where T: BaseViewModel
    {
        public virtual void HandleNavigatedEvent(object sender, T viewModel)
        {
            DataContext = viewModel;
        }
    }

    public class BasePage : ListeningPage<BaseViewModel>
    {
    }
}
