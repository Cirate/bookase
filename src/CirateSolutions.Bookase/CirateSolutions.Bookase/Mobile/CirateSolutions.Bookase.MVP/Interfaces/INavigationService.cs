using System;
using System.Threading.Tasks;

namespace CirateSolutions.Bookase.MVP.Interfaces
{
    public interface INavigationService
    {
        Task Navigate<TPresenter>(bool addToBackStack = true) where TPresenter : IPresenter;
        Task Navigate(Type presenterType, bool addToBackStack = true);
        Task Close();
    }
}