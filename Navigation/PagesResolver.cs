using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.ComponentModel;
using Pages;
using Navigator.Navigation.Interfaces;

namespace Navigator.Navigation
{
    public class PagesResolver : IPageResolver
    {
        
        private readonly Dictionary<string, Func<Page>> _pagesResolvers = new Dictionary<string, Func<Page>>();

        public PagesResolver()
        {
            _pagesResolvers.Add(Navigation.Page1Alias, () => new Page1());
            _pagesResolvers.Add(Navigation.Page2Alias, () => new Page2());
            _pagesResolvers.Add(Navigation.Page3Alias, () => new Page3());
            _pagesResolvers.Add(Navigation.NotFoundPageAlias, () => new Page404());
        }

        public Page GetPageInstance(string alias)
        {
            if (_pagesResolvers.ContainsKey(alias))
            {
                return _pagesResolvers[alias]();
            }

            return _pagesResolvers[Navigation.NotFoundPageAlias]();
        }
    }
}
