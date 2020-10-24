namespace CirateSolutions.Bookase.MVP.Interfaces
{
    public interface IPresenter<TView>
        where TView : IView
    {
        public TView View { get; }
        public void SetView(TView view);
        public void OnViewCreated();
    }
}