using CoreTest5.MyLib.Services;
using CoreTest5.MyLib.ViewModels;
using CoreTest5.MyWPFGUI.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace CoreTest5.MyWPFGUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public new static App Current => (App)Application.Current;
        public NavigationViewModel NavVM => Services.GetService<NavigationViewModel>();
        public IServiceProvider Services { get; }

        public App()
        {
            Services = ConfigureServices();
        }

        private IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            GetNumberService getNumberService = new GetNumberService(100);
            services.AddSingleton<IGetNumberService>(x => getNumberService);
            services.AddSingleton<IDialogService, DialogService>();
            services.AddSingleton<NavigationViewModel>();

            return services.BuildServiceProvider();
        }

    }
}
