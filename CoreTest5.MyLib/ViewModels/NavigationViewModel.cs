using CoreTest5.MyLib.Models;
using CoreTest5.MyLib.Services;

namespace CoreTest5.MyLib.ViewModels
{
    public class NavigationViewModel : BaseViewModel
    {

        private bool? dialogResult;
        public bool? DialogResult
        {
            get { return dialogResult; }
            set
            {
                SetProperty(ref dialogResult, value);
            }
        }

        private object _selectedView;
        public object SelectedView
        {
            get { return _selectedView; }
            set
            {
                SetProperty(ref _selectedView, value);
            }
        }

        public NavigationViewModel(IDialogService dialogService, IGetNumberService getNumberService)
        {
            NavigationService navigationService = new NavigationService();
            navigationService.NavigateEvent += NavigationService_NavigateEvent;
            CommunicationService.NavigationService = navigationService;
            CommunicationService.DialogService = dialogService;
            CommunicationService.GetNumberService = getNumberService;
            SelectedView = new MainViewModel();
        }

        private void NavigationService_NavigateEvent(object sender, NavigationService.NavigateEventArgs e)
        {
            switch (e.Page)
            {
                case ApplicationPage.MainPage:
                    //                    SelectedView = new AuthenticationPageDummy();
                    SelectedView = new MainViewModel();
                    break;
                case ApplicationPage.DetailsPage:
                    //SelectedView = new SPSitePageDummy();
                    SelectedView = new DetailsViewModel();
                    break;
                default:
                    break;
            }
        }
    }
}
