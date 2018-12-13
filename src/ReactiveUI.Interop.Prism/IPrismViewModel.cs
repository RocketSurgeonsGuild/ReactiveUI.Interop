using Prism.Navigation;

namespace ReactiveUI.Interop.Prism
{
    /// <summary>
    /// Interface that represents a Prism ReactiveUI inter operable view model.
    /// </summary>
    public interface IPrismViewModel :
        IReactiveNotifyPropertyChanged<IReactiveObject>,
        IReactiveObject,
        IHandleObservableErrors,
        INavigationAware,
        IDestructible
    {
    }
}