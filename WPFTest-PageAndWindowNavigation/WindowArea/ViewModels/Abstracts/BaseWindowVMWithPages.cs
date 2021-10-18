using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Collections.ObjectModel;
using WPFTest_PageAndWindowNavigation.Core;
using WPFTest_PageAndWindowNavigation.Core.Abstract;
using System.Collections.Generic;

namespace WPFTest_PageAndWindowNavigation.WindowArea.ViewModels.Abstracts
{
    abstract class BaseWindowVMWithPages : BaseWindowVM
    {
        private readonly PageController _pageController;
        private Page? _currentPage;

        public BaseWindowVMWithPages()
        {
            _pageController = new PageController();

            ChangePageCommand = new RelayCommand<IPageVM>(SwitchPage);
            ClosePageCommand = new RelayCommand(ClosePage);
        }

        public IEnumerable<IPageVM> Pages => _pageController.Pages;

        public Page CurrentPage
        {
            get => _currentPage;
            set
            {
                if (_currentPage != value)
                {
                    _currentPage = value;
                    OnPropertyChanged();
                }
            }
        }

        #region Commands

        public ICommand ChangePageCommand { get; }
        public ICommand ClosePageCommand { get; }

        #endregion

        protected void RegisterPageWithVm<VM, Pag>()
            where VM : IPageVM
            where Pag : Page
        {
            _pageController.RegisterVMAndPage<VM, Pag>();

            if (CurrentPage is null)
            {
                SwitchPage((IPageVM)_pageController.GetFirstPage().DataContext);
            }
        }

        private void SwitchPage(IPageVM vm)
        {
            if (vm != CurrentPage?.DataContext)
            {
                CurrentPage = _pageController.GetPage(vm);
            }
        }

        private void ClosePage()
        {
            IPageVM vmForClose = (IPageVM)_currentPage.DataContext;
            CurrentPage = _pageController.GetLastPage();
            _pageController.HidePage(vmForClose);
        }
    }
}
