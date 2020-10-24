using CirateSolutions.Bookase.MVP.Interfaces;

namespace CirateSolutions.Bookase.Core.Presenters.Main.Interfaces
{
    public interface IMainView : IView
    {
        void SetButtonText(string text);
    }
}