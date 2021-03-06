using CoreTest5.MyLib.Models;
using CoreTest5.MyLib.Services;
using CoreTest5.MyLib.ViewModels;
using CoreTest5.MyWPFGUI.Converters;
using CoreTest5.MyWPFGUI.Dialogs;
using Microsoft.Win32;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace CoreTest5.MyWPFGUI.Services
{
    public class DialogService : IDialogService
    {
        public Task<object> GetObject(SelectObjectViewModel viewModel)
        {
            var tcs = new TaskCompletionSource<object>();
            object selectedObject = null;
            Application.Current.Dispatcher.Invoke(() =>
            {
                try
                {
                    SelectObjectDialog selectObjectDialog = new SelectObjectDialog();
                    viewModel.CloseAction = new Action(() => selectObjectDialog.Close());
                    selectObjectDialog.DataContext = viewModel;
                    selectObjectDialog.Owner = Application.Current.MainWindow;
                    selectObjectDialog.ShowDialog();
                    selectedObject = viewModel.SelectedObject;
                }
                finally
                {
                    tcs.TrySetResult(selectedObject);
                }
            }
            );
            return tcs.Task;
        }

        public Task<string> SelectFile(UIPopupOpenFile uIPopupOpenFile)
        {
            var tcs = new TaskCompletionSource<string>();
            string selectedFile = null;
            Application.Current.Dispatcher.Invoke(() =>
            {
                try
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Multiselect = false;
                    openFileDialog.Filter = uIPopupOpenFile.FileTypeFilter;
                    openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    openFileDialog.Title = uIPopupOpenFile.Title;
                    if (openFileDialog.ShowDialog() == true)
                    {
                        selectedFile = openFileDialog.FileName;
                    }
                }
                finally
                {
                    tcs.TrySetResult(selectedFile);
                }
            }
            );
            return tcs.Task;
        }

        public Task ShowMessage(UIPopupMessage viewModel)
        {
            var tcs = new TaskCompletionSource<bool>();

            //Run in UI thread
            Application.Current.Dispatcher.Invoke(() =>
            {
                try
                {
                    //show messagebox
                    MessageBox.Show(Application.Current.MainWindow, viewModel.Message, viewModel.Title, MessageBoxButton.OK, DialogIconConverter.Convert(viewModel.DialogType));
                }
                finally
                {
                    //return completed
                    tcs.TrySetResult(true);
                }
            });
            return tcs.Task;
        }
    }
}
