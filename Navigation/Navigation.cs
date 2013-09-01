using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;

using System.Windows.Navigation;
using System.Windows.Controls;

namespace NavigationHelpers
{
    public sealed class Navigation
    {
        #region Fields

        private NavigationService _navService = null;

        #endregion


        #region Properties

        public static NavigationService Service
        {
            get { return Instance._navService; }
            set
            {
                if (Instance._navService != null)
                {
                    Instance._navService.Navigated -= Instance._navService_Navigated;
                }                
                
                Instance._navService = value;
                Instance._navService.Navigated += Instance._navService_Navigated;
            }
        }

        #endregion


        #region Public Methods

        public static void Navigate(Page page, object context)
        {
            if (Instance._navService == null || page == null)
            {
                return;
            }

            Instance._navService.Navigate(page, context);
        }

        public static void Navigate(Page page)
        {
            Navigate(page, null);
        }

        public static void Navigate(Uri uri, object context)
        {
            if (Instance._navService == null || uri == null)
            {
                return;
            }

            Instance._navService.Navigate(uri, context);
        }

        public static void Navigate(Uri uri)
        {
            Navigate(uri, null);
        }

        #endregion


        #region Private Methods

        void _navService_Navigated(object sender, NavigationEventArgs e)
        {
            var page = e.Content as Page;

            if (page == null)
            {
                return;
            }

            page.DataContext = e.ExtraData;
        }

        #endregion


        #region Singleton

        private static volatile Navigation instance;
        private static object syncRoot = new Object();

        private Navigation() { }

        private static Navigation Instance
        {
            get 
            {
                if (instance == null) 
                {
                    lock (syncRoot) 
                    {
                        if (instance == null)
                            instance = new Navigation();
                    }
                }

                return instance;
            }
        }
        #endregion
    }
}
