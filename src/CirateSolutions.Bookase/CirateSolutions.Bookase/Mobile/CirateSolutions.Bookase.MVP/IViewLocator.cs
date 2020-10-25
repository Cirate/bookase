using System;

namespace CirateSolutions.Bookase.MVP
{
    public interface IViewLocator
    {
        Type GetViewType<TPresenter>();
        Type GetViewType(Type presenterType);
    }
}