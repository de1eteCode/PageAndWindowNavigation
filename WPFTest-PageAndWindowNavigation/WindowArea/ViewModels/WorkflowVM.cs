using WPFTest_PageAndWindowNavigation.PageArea.ViewModels;
using WPFTest_PageAndWindowNavigation.PageArea.Views;
using WPFTest_PageAndWindowNavigation.WindowArea.ViewModels.Abstracts;

namespace WPFTest_PageAndWindowNavigation.WindowArea.ViewModels
{
    internal class WorkflowVM : BaseWindowVMWithPages
    {
        public WorkflowVM()
        {
            RegisterPageWithVm<InfoVM, Info>();
            RegisterPageWithVm<AboutVM, About>();
        }
    }
}
