using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Windows;
using System.Windows.Input;

namespace WPFTest_PageAndWindowNavigation.WindowArea.ViewModels.Abstracts
{
    abstract class BaseWindowVM : ObservableObject
    {
        public BaseWindowVM()
        {
            OpenNewWindowAndCloseOldCommand = new RelayCommand(OpenNewWindowAndCloseOld);
        }

        public ICommand OpenNewWindowAndCloseOldCommand { get; }

        private void OpenNewWindowAndCloseOld()
        {
            var app = (App)Application.Current;
            app.WinController.ShowWindow(new WorkflowVM());
            app.WinController.HideWindow(this);
        }
    }
}
