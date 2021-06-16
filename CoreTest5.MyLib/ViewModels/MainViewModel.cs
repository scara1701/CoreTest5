using CoreTest5.MyLib.Models;
using CoreTest5.MyLib.Services;
using Microsoft.Toolkit.Mvvm.Input;

namespace CoreTest5.MyLib.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private object selectedObject;

        public object SelectedObject
        {
            get { return selectedObject; }
            set
            {
                selectedObject = value;
                OnPropertyChanged(nameof(selectedObject));
            }
        }

        private string selectedFile;

        public string SelectedFile
        {
            get { return selectedFile; }
            set
            {
                selectedFile = value;
                OnPropertyChanged(nameof(SelectedFile));
            }
        }

        IGetNumberService _getNumberService;
        INavigationService _navigationService;
        IDialogService _dialogService;
        public MainViewModel()
        {
            _getNumberService = CommunicationService.GetNumberService;
            _dialogService = CommunicationService.DialogService; ;
            _navigationService = CommunicationService.NavigationService;
            GoToDetailsCommand = new RelayCommand(() => GoToDetails());
            ShowMessageCommand = new RelayCommand(() => ShowMessage());
            OpenFileCommand = new RelayCommand(() => OpenFile());
            SelectObjectCommand = new RelayCommand(() => SelectObject());
        }

        private async void SelectObject()
        {
            SelectObjectViewModel selectObjectViewModel = new SelectObjectViewModel();
            SelectedObject = await _dialogService.GetObject(selectObjectViewModel);
        }

        private async void OpenFile()
        {
            UIPopupOpenFile uIPopupOpenFile = new UIPopupOpenFile("Choose a file", "Text files (*.txt)|*.txt|All files (*.*)|*.*");
            SelectedFile = await _dialogService.SelectFile(uIPopupOpenFile);
        }

        private void ShowMessage()
        {
            UIPopupMessage uIPopupMessage = new UIPopupMessage("Test warning", "This is a test!", DialogType.Warning);
            _dialogService.ShowMessage(uIPopupMessage);
        }

        private void GoToDetails()
        {
            _navigationService.Navigate(ApplicationPage.DetailsPage);
        }

        public int CurrentNumber
        {
            get { return _getNumberService.GetNumber(); }
        }

        public RelayCommand GoToDetailsCommand { get; set; }
        public RelayCommand ShowMessageCommand { get; set; }
        public RelayCommand OpenFileCommand { get; set; }
        public RelayCommand SelectObjectCommand { get; set; }
    }
}
