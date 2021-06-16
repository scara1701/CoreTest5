using CoreTest5.MyLib.ViewModels;
using System.Windows;

namespace CoreTest5.MyWPFGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = App.Current.NavVM;
        }
    }
}
