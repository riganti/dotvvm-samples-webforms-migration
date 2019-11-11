using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotVVM.Framework.ViewModel;

namespace OldWebApp.ViewModels
{
    public abstract class SiteViewModel : DotvvmViewModelBase
    {
        public abstract string Title { get; }
    }
}

