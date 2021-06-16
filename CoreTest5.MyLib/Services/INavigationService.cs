using CoreTest5.MyLib.Models;

namespace CoreTest5.MyLib.Services
{
    /// <summary>
    /// Interface for navigation commands in UI
    /// </summary>
    public interface INavigationService
    {
        void Navigate(ApplicationPage sourcePage);
        void GoBack();
    }
}
