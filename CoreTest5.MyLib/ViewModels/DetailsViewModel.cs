using CoreTest5.MyLib.Models;
using CoreTest5.MyLib.Services;
using Microsoft.Toolkit.Mvvm.Input;
using System.Collections.Generic;

namespace CoreTest5.MyLib.ViewModels
{
    public class DetailsViewModel : BaseViewModel
    {
        IGetNumberService _getNumberService;
        INavigationService _navigationService;
        public RelayCommand GoBackCommand { get; set; }
        public DetailsViewModel()
        {
            _getNumberService = CommunicationService.GetNumberService;
            _navigationService = CommunicationService.NavigationService;
            GoBackCommand = new RelayCommand(() => GoBack());
        }


        public List<MyObject> TheList
        {
            get { return ListService.MyObjects(_getNumberService); }
        }


        private void GoBack()
        {
            _navigationService.GoBack();
        }
    }
}
